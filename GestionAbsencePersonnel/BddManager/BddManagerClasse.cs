using GestionAbsencePersonnel.Dal;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GestionAbsencePersonnel.BddManager
{
    /// <summary>
    /// Gère la connexion à la base de données (singleton)
    /// </summary>
    public class BddManagerClasse
    {
        /// <summary>
        /// Instance unique de la classe (singleton)
        /// </summary>
        private static BddManagerClasse instance = null;

        /// <summary>
        /// objet de connexion à MySQL
        /// </summary>
        private MySqlConnection connection;
        /// <summary>
        /// chaîne de connexion à la BDD 
        /// </summary>
        private string connectionString;

        /// <summary>
        /// Constructeur privé + initialise la chaîne de connexion et l'objet MySqlConnection
        /// </summary>
        private BddManagerClasse()
        { }

        /// <summary>
        /// Récupère l'instance unique de la classe (si elle n'existe pas, elle est créée)
        /// </summary>
        /// <returns>L'instance unique de BddManager</returns>
        public static BddManagerClasse GetInstance()
        {
            if (instance == null)
            {
                instance = new BddManagerClasse();
            }
            return instance;
        }
        /// <summary>
        /// Retourne l'objet de connexion à la base de données. Si la connexion n'est pas encore créée, elle est initialisée avec la chaîne de connexion obtenue depuis Access.GetConnectionString().
        /// La connexion est ensuite ouverte et prête à être utilisée pour exécuter des requêtes SQL.
        /// </summary>
        /// <returns></returns>
        public MySqlConnection GetConnection()
        {
            if (this.connection == null)
            {
                string chaine = Access.GetConnectionString();
                this.connection = new MySqlConnection(chaine);
            }
            return this.connection;
        }

        /// <summary>
        /// Exécute une requête action SQL autre que "select" (INSERT, UPDATE, DELETE)
        /// </summary>
        /// <param name="query">requête SQL</param>
        public void ReqAction(string query)
        {
            if (this.GetConnection().State != System.Data.ConnectionState.Open)
            {
                this.GetConnection().Open();
            }
            MySqlCommand cmd = new MySqlCommand(query, this.connection);
            cmd.ExecuteNonQuery();
            this.connection.Close();

        }


        /// <summary>
        /// Exécute une requête SELECT et retourne un curseur (DataReader)
        /// </summary>
        /// <param name="stringQuery">requête SQL SELECT</param>
        /// <returns>MySqlDataReader pour lire les résultats</returns>
        public MySqlDataReader ReqSelect(string query)
        {
            // Vérifie si la connexion est déjà ouverte avant de l'ouvrir
            if (this.GetConnection().State != System.Data.ConnectionState.Open)
            {
                this.GetConnection().Open();
            }
            MySqlCommand cmd = new MySqlCommand(query, this.connection);
            return cmd.ExecuteReader();
        }

        /// <summary>
        /// Ferme la connexion à la base de données si elle est ouverte
        /// </summary>
        public void CloseConnection()
        {
            if (this.connection != null && this.connection.State == System.Data.ConnectionState.Open)
            {
                this.connection.Close();
            }
        }

    }
}
