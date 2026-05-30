using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAbsencePersonnel.Modele
{
    /// <summary>
    /// Représente un personnel avec un identifiant, un nom, un prénom, un numéro de téléphone, une adresse e-mail et un service associé.
    /// </summary>
    public class Personnel
    {
        public int Idpersonnel { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public int IdService { get; set; }

        // Ajoute cette propriété pour l'affichage dans les ComboBox
        public string NomPrenom
        {
            get { return $"{Nom} {Prenom}"; }
        }
    }
}
