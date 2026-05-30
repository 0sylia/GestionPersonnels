using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAbsencePersonnel.Dal
{
    /// <summary>
    /// Accès à la base de données MySQL pour la gestion des absences du personnel
    /// </summary>
    public class Access
    {
        /// <summary>
        /// Retourne la chaîne de connexion à la base de données MySQL pour la gestion des absences du personnel.
        /// </summary>
        /// <returns>Chaîne de connexion MySQL</returns>
        public static string GetConnectionString()
        {
            return "server=localhost; port=3306; user id=responsable; password=TOUF._.mdpuser; database=absence_db;";
        }
    }
}
