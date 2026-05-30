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
    /// Représente la classe d'accès aux données (DAL) pour les opérations liées aux services. Permet de récupérer la liste des services depuis la base de données. Utilise le BddManagerClasse pour exécuter les requêtes SQL et gérer la connexion à la base de données.
    /// </summary>
    public class ServiceDal
    {
        private BddManagerClasse bddManager;
        // Constructeur : initialise le BddManagerClasse pour gérer la connexion à la base de données
        public ServiceDal()
        {
            this.bddManager = BddManagerClasse.GetInstance();
        }
        // Méthode pour récupérer la liste de tous les services depuis la base de données
        public List<Service> GetAllServices()
        {
            List<Service> services = new List<Service>();
            string req = "SELECT idservice, nom FROM service";
            MySqlDataReader reader = this.bddManager.ReqSelect(req);

            // Parcours des résultats de la requête et création d'objets Service pour chaque enregistrement, puis ajout à la liste
            while (reader.Read())
            {
                Service s = new Service();
                s.Idservice = reader.GetInt32("idservice");
                s.Nom = reader.GetString("nom");
                services.Add(s);
            }
            reader.Close();
            this.bddManager.CloseConnection();
            // Retourne la liste des services récupérés de la base de données
            return services;
        }
    }
}
