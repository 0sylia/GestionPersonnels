using MySql.Data.MySqlClient;
using GestionAbsencePersonnel.BddManager;
using GestionAbsencePersonnel.Modele;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAbsencePersonnel.Dal
{
    /// <summary>
    /// Représente la classe d'accès aux données (DAL) pour les opérations liées au personnel. Permet de récupérer la liste des personnels, d'ajouter un nouveau personnel, de modifier un personnel existant et de supprimer un personnel de la base de données. Utilise le BddManagerClasse pour exécuter les requêtes SQL et gérer la connexion à la base de données.
    /// </summary>
    public class PersonnelDal
    {
        private BddManagerClasse bddManager;
        // Constructeur : initialise le BddManagerClasse pour gérer la connexion à la base de données
        public PersonnelDal()
        {
            this.bddManager = BddManagerClasse.GetInstance();
        }
        // Méthode pour récupérer la liste de tous les personnels depuis la base de données
        public List<Personnel> GetAllPersonnels()
        {
            List<Personnel> personnels = new List<Personnel>();
            string req = "SELECT idpersonnel, nom, prenom, tel, mail, idservice FROM personnel";
            MySqlDataReader reader = this.bddManager.ReqSelect(req);

            while (reader.Read())
            {
                Personnel personnel = new Personnel
                {
                    Idpersonnel = reader.GetInt32("idpersonnel"),
                    Nom = reader.GetString("nom"),
                    Prenom = reader.GetString("prenom"),
                    Tel = reader.GetString("tel"),
                    Mail = reader.GetString("mail"),
                    IdService = reader.GetInt32("idservice"),
                };
                personnels.Add(personnel);
            }

            reader.Close();  // ← Ferme le reader
            this.bddManager.CloseConnection();  // ← Ferme la connexion

            return personnels;
        }
        // Méthode pour ajouter un nouveau personnel à la base de données en exécutant une requête INSERT avec les données du personnel
        public void AddPersonnel(Personnel personnel)
        {
            string req = $"INSERT INTO personnel (nom, prenom, tel ,mail, idservice) VALUES ('{personnel.Nom}', '{personnel.Prenom}', '{personnel.Tel}', '{personnel.Mail}', {personnel.IdService})";
            this.bddManager.ReqAction(req);
        }
        // Méthode pour modifier un personnel existant dans la base de données en exécutant une requête UPDATE avec les données du personnel et son ID
        public void UpdatePersonnel(Personnel personnel)
        {
            string req = $"UPDATE personnel SET nom='{personnel.Nom}', prenom='{personnel.Prenom}', tel='{personnel.Tel}', mail='{personnel.Mail}', idservice={personnel.IdService} WHERE idpersonnel={personnel.Idpersonnel}";
            this.bddManager.ReqAction(req);
        }
        // Méthode pour supprimer un personnel de la base de données en exécutant une requête DELETE avec l'ID du personnel
        public void DeletePersonnel(int id)
        {
            string req = $"DELETE FROM personnel WHERE idpersonnel={id}";
            this.bddManager.ReqAction(req);
        }

    }
}
