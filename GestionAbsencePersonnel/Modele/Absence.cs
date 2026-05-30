using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAbsencePersonnel.Modele
{
    /// <summary>
    /// Représente une absence avec un identifiant, une date de début, une date de fin, un motif associé et un personnel associé.
    /// </summary>
    public class Absence
    {
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int IdMotif { get; set; }
        public int IdPersonnel { get; set; }
        // Pour identifier une absence unique (sans utiliser id)
        public string IdentifiantAbsence => $"{IdPersonnel}_{DateDebut:ddMMyyyy}";

    }
}
