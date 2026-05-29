using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GestionAbsencePersonnel.BddManager
{
    /// <summary>
    /// Gère la connexion à la base de données (singleton)
    /// </summary>
    public class BddManager
    {
        /// <summary>
        /// instance unique de la classe
        /// </summary>
        private static BddManager instance = null;

        /// <summary>
        /// objet de connexion à MySQL
        /// </summary>
        private readonly MySqlConnection connection;
        /// <summary>
        /// chaîne de connexion à la BDD 
        /// </summary>
        private string connectionString;

        /// <summary>
        /// Constructeur privé + initialise la chaîne de connexion et l'objet MySqlConnection
        /// </summary>
        private BddManager()
        {
            connectionString = "server=localhost; port=3306; user id=responsable; password=TOUF._.mdpuser; database=absence_db;";
            connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Récupère l'instance unique de la classe (si elle n'existe pas, elle est créée)
        /// </summary>
        /// <returns>L'instance unique de BddManager</returns>
        public static BddManager GetInstance()
        {
            if (instance == null)
            {
                instance = new BddManager();
            }
            return instance;
        }

        /// <summary>
        /// Exécute une requête action SQL (INSERT, UPDATE, DELETE)
        /// </summary>
        /// <param name="query">requête SQL</param>
        public void ReqUpdate(string query)
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }


        /// <summary>
        /// Exécute une requête SELECT et retourne un curseur (DataReader)
        /// </summary>
        /// <param name="stringQuery">requête SQL SELECT</param>
        /// <returns>MySqlDataReader pour lire les résultats</returns>
        public MySqlDataReader ReqSelect(string query)
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            return cmd.ExecuteReader();
        }

    }
}
