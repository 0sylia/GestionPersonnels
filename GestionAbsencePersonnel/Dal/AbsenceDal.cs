using MySql.Data.MySqlClient;
using GestionAbsencePersonnel.BddManager;
using GestionAbsencePersonnel.Modele;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace GestionAbsencePersonnel.Dal
{
    /// <summary>
    /// Représente la classe d'accès aux données (DAL) pour les opérations liées aux absences du personnel. Permet de récupérer la liste des absences, d'ajouter une nouvelle absence, de modifier une absence existante et de supprimer une absence de la base de données. Utilise le BddManagerClasse pour exécuter les requêtes SQL et gérer la connexion à la base de données.
    /// </summary>
    public class AbsenceDal
    {
        private BddManagerClasse bddManager;
        // Constructeur : initialise le BddManagerClasse pour gérer la connexion à la base de données
        public AbsenceDal()
        {
            this.bddManager = BddManagerClasse.GetInstance();
        }
        // Récupère la liste de toutes les absences depuis la base de données et retourne une liste d'objets Absence.
        public List<Absence> GetAllAbsences()
        {
            List<Absence> absences = new List<Absence>();
            string req = "SELECT idpersonnel, idmotif , datedebut, datefin FROM absence";
            MySqlDataReader reader = this.bddManager.ReqSelect(req);
            // Parcours des résultats de la requête et création d'objets Absence pour chaque enregistrement, puis ajout à la liste
            while (reader.Read())
            {
                Absence a = new Absence();
                // Récupère les dates de manière sécurisée
                a.IdPersonnel = reader.GetInt32("idpersonnel");
                a.IdMotif = reader.GetInt32("idmotif");

                // Gère le cas où les dates sont NULL ou invalides
                if (!reader.IsDBNull(reader.GetOrdinal("datedebut")))
                    a.DateDebut = reader.GetDateTime("datedebut");
                else
                    a.DateDebut = DateTime.MinValue;

                if (!reader.IsDBNull(reader.GetOrdinal("datefin")))
                    a.DateFin = reader.GetDateTime("datefin");
                else
                    a.DateFin = DateTime.MinValue;

                absences.Add(a);
            }
            reader.Close();
            this.bddManager.CloseConnection();
            // Retourne la liste des absences récupérées de la base de données
            return absences;
        }
        // Ajoute une nouvelleabsence à la base de données en fonction des données de l'objet Absence passé en paramètre.
        public void AddAbsence(Absence absence)
        {
            string req = $"INSERT INTO absence ( idpersonnel, idmotif, datedebut, datefin) VALUES ({absence.IdPersonnel}, {absence.IdMotif}, '{absence.DateDebut:yyyy-MM-dd}', '{absence.DateFin:yyyy-MM-dd}')";
            this.bddManager.ReqAction(req);
        }
        // Modifie une absence existante dans la base de données en fonction de son id.
        public void UpdateAbsence(Absence absence)
        {
            string req = $"UPDATE absence SET idmotif = {absence.IdMotif}, datefin = '{absence.DateFin:yyyy-MM-dd}' WHERE idpersonnel = {absence.IdPersonnel} AND datedebut = '{absence.DateDebut:yyyy-MM-dd}'";
            this.bddManager.ReqAction(req);
        }
        // Supprime une absence de la base de données en fonction de son id.
        public void DeleteAbsence(int Idpersonnel, DateTime dateDebut)
        {
            string req = $"DELETE FROM absence WHERE idpersonnel = {Idpersonnel} AND datedebut = '{dateDebut:yyyy-MM-dd}'";
            this.bddManager.ReqAction(req);
        }
    }
}