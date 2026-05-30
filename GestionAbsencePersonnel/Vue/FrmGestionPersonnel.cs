using GestionAbsencePersonnel.controller;
using GestionAbsencePersonnel.Modele;
using GestionAbsencePersonnel.Vue;
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
    /// Représente le formulaire de gestion du personnel (affichage, ajout, modification, suppression)
    /// </summary>
    public partial class FrmGestionPersonnel : Form
    {
        private FrmGestionPersonnelController controller;
        // Constructeur : initialise le formulaire et le controller
        public FrmGestionPersonnel()
        {
            InitializeComponent();
            this.controller = new FrmGestionPersonnelController();

        }
        // Chargement du formulaire : charge la liste des personnels dans le DataGridView
        private void FrmGestionPersonnel_Load(object sender, EventArgs e)
        {
            ChargerPersonnels();
        }
        // Méthode pour charger la liste des personnels depuis le controller et l'afficher dans le DataGridView
        private void ChargerPersonnels()
        {
            dgvPersonnel.DataSource = null;
            dgvPersonnel.DataSource = this.controller.GetPersonnels();
            // Cache la colonne IdentifiantAbsence (elle existe dans l'objet mais n'est pas affichée)
            if (dgvPersonnel.Columns.Contains("NomPrenom"))
            {
                dgvPersonnel.Columns["NomPrenom"].Visible = false;
            }
        }
        // Bouton Ajouter : ouvre le formulaire de saisie d'un nouveau personnel, et si la saisie est validée, ajoute le personnel via le controller et recharge la liste
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            FrmAjoutModiPersonnel frm = new FrmAjoutModiPersonnel();
            // Si le formulaire est validé (DialogResult.OK), récupérer le personnel saisi et l'ajouter via le controller, puis recharger la liste des personnels
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.controller.AddPersonnel(frm.Personnel);
                ChargerPersonnels();
            }
        }
        // Bouton Modifier : si une ligne est sélectionnée, ouvre le formulaire de modification avec les données du personnel sélectionné, et si la modification est validée, met à jour le personnel via le controller et recharge la liste
        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvPersonnel.CurrentRow != null)
            {
                Personnel p = (Personnel)dgvPersonnel.CurrentRow.DataBoundItem;
                FrmAjoutModiPersonnel frm = new FrmAjoutModiPersonnel(p);
                // Si le formulaire est validé (DialogResult.OK), récupérer le personnel modifié et le mettre à jour via le controller, puis recharger la liste des personnels
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.controller.UpdatePersonnel(frm.Personnel);
                    ChargerPersonnels();
                    MessageBox.Show("Personnel modifié avec succès !");
                }
                
            }
        }
        // Bouton Supprimer : si une ligne est sélectionnée, demande une confirmation, puis supprime le personnel via le controller et recharge la liste

        private void btnSupprimer_Click_1(object sender, EventArgs e)
        {
            // Vérifier qu'une ligne est sélectionnée dans le DataGridView
            if (dgvPersonnel.CurrentRow != null)
            {
                Personnel p = (Personnel)dgvPersonnel.CurrentRow.DataBoundItem;
                // Afficher une boîte de dialogue de confirmation avant de supprimer le personnel
                if (MessageBox.Show("Supprimer ce personnel ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.controller.DeletePersonnel(p.Idpersonnel);
                    ChargerPersonnels();
                    MessageBox.Show("Personnel supprimé avec succès !");
                }
                
            }
        }
        // Bouton Gérer Absences : ouvre le formulaire de gestion des absences
        private void btnGererAbsence_Click(object sender, EventArgs e)
        {
            FrmGestionAbsence frm = new FrmGestionAbsence();
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChargerPersonnels();
        }

    }
}
