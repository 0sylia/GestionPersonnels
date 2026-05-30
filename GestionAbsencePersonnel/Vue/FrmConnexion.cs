using GestionAbsencePersonnel.BddManager;
using GestionAbsencePersonnel.Dal;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionAbsencePersonnel.Vue
{
    /// <summary>
    /// Représente le formulaire de connexion pour l'application de gestion des absences du personnel. Permet aux responsables de se connecter en saisissant leur login et mot de passe, et d'accéder au formulaire de gestion du personnel si les identifiants sont corrects.
    /// </summary>
    public partial class FrmConnexion : Form
    {
        private BddManagerClasse bddManager;
        // Constructeur : initialise le formulaire et la connexion à la base de données
        public FrmConnexion()
        {
            InitializeComponent();
            this.bddManager = BddManagerClasse.GetInstance();
            txtMdp.PasswordChar = '*';
        }
        // Bouton se connecter : vérifie les identifiants de connexion et ouvre le formulaire de gestion du personnel si la connexion est réussie, sinon affiche un message d'erreur
        private void btnSeConnecter_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string pwd = txtMdp.Text.Trim();
            // Vérification que les champs ne sont pas vides
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("Veuillez saisir login et mot de passe");
                return;
            }
            // Requête SQL pour vérifier les identifiants de connexion
            string req = $"SELECT * FROM responsable WHERE login = '{login}' AND pwd = SHA2('{pwd}', 256)";
            MySqlDataReader reader = this.bddManager.ReqSelect(req);
            // Si un résultat est trouvé, la connexion est réussie, sinon afficher un message d'erreur
            if (reader.Read())
            {
                reader.Close();
                this.bddManager.GetConnection().Close();
                this.Hide();
                FrmGestionPersonnel frm = new FrmGestionPersonnel();
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                reader.Close();
                this.bddManager.GetConnection().Close();
                MessageBox.Show("Login ou mot de passe incorrect");
                txtLogin.Clear();
                txtMdp.Clear();
                txtLogin.Focus();
            }

        }
        // Bouton quitter : ferme l'application
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void FrmConnexion_Load(object sender, EventArgs e)
        {

        }
    }
}
