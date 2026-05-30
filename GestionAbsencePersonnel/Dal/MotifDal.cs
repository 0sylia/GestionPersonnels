using MySql.Data.MySqlClient;
using GestionAbsencePersonnel.BddManager;
using GestionAbsencePersonnel.Modele;
using System.Collections.Generic;

namespace GestionAbsencePersonnel.Dal
{
    /// <summary>
    /// Représente la classe d'accès aux données (DAL) pour les opérations liées aux motifs d'absence. Permet de récupérer la liste des motifs d'absence depuis la base de données. Utilise le BddManagerClasse pour exécuter les requêtes SQL et gérer la connexion à la base de données.
    /// </summary>
    public class MotifDal
    {
        private BddManagerClasse bddManager;
        
        // Constructeur : initialise le BddManagerClasse pour gérer la connexion à la base de données
        public MotifDal()
        {
            this.bddManager = BddManagerClasse.GetInstance();
        }
        // Méthode pour récupérer la liste de tous les motifs d'absence depuis la base de données
        public List<Motif> GetAllMotifs()
        {
            List<Motif> motifs = new List<Motif>();
            string req = "SELECT idmotif, libelle FROM motif";
            MySqlDataReader reader = this.bddManager.ReqSelect(req);
            // Parcours des résultats de la requête et création d'objets Motif pour chaque enregistrement, puis ajout à la liste
            while (reader.Read())
            {
                Motif m = new Motif();
                m.Idmotif = reader.GetInt32("idmotif");
                m.Libelle = reader.GetString("libelle");
                motifs.Add(m);
            }
            reader.Close();
            this.bddManager.CloseConnection();
            // Retourne la liste des motifs d'absence récupérés de la base de données
            return motifs;
        }
    }
}