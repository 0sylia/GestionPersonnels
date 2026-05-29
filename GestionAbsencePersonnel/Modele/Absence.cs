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
    internal class Absence
    {
        public int Idabsence { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public Motif Motif { get; set; }
        public Personnel Personnel { get; set; }
    }
}
