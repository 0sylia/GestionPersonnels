using System;
using GestionAbsencePersonnel.controller;
using GestionAbsencePersonnel.Modele;
using System.Windows.Forms;

namespace GestionAbsencePersonnel.Vue
{
    /// <summary>
    /// Représente le formulaire de gestion des absences du personnel, permettant d'afficher la liste des absences, d'ajouter une nouvelle absence, de modifier une absence existante ou de supprimer une absence. Le formulaire utilise un controller pour interagir avec les données et mettre à jour l'affichage en conséquence.
    /// </summary>
    public partial class FrmGestionAbsence : Form
    {
        private FrmGestionAbsenceController controller;
        // Constructeur : initialise le formulaire et le controller
        public FrmGestionAbsence()
        {
            InitializeComponent();
            this.controller = new FrmGestionAbsenceController();
        }
        // Chargement du formulaire : charge la liste des absences dans le DataGridView
        private void FrmGestionAbsence_Load(object sender, EventArgs e)
        {
            ChargerAbsences();
        }
        // Méthode pour charger la liste des absences depuis le controller et l'afficher dans le DataGridView
        private void ChargerAbsences()
        {
            dgvAbsences.DataSource = null;
            dgvAbsences.DataSource = this.controller.GetAbsences();
            // Cache la colonne IdentifiantAbsence (elle existe dans l'objet mais n'est pas affichée)
            if (dgvAbsences.Columns.Contains("IdentifiantAbsence"))
            {
                dgvAbsences.Columns["IdentifiantAbsence"].Visible = false;
            }
            
        }
        // Evenement du bouton ajouter qui ouvre le formulaire de saisie d'une nouvelle absence et ajoute l'absence après validation
        private void btnAjouterAbsence_Click(object sender, EventArgs e)
        {
            FrmAjoutModifAbsence frm = new FrmAjoutModifAbsence();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.controller.AddAbsence(frm.Absence);
                ChargerAbsences();
            }
        }
        // Evenement du bouton modifier qui ouvre le formulaire de modification avec les données de l'absence sélectionnée et met à jour l'absence après validation
        private void btnModifierAbsence_Click(object sender, EventArgs e)
        {
            if (dgvAbsences.CurrentRow != null)
            {
                Absence a = (Absence)dgvAbsences.CurrentRow.DataBoundItem;
                FrmAjoutModifAbsence frm = new FrmAjoutModifAbsence(a);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.controller.UpdateAbsence(frm.Absence);
                    ChargerAbsences();
                }
            }
        }
        // Evenement du bouton supprimer qui demande une confirmation avant de supprimer l'absence sélectionnée et de recharger la liste des absences
        private void btnSupprimerAbsence_Click(object sender, EventArgs e)
        {
            if (dgvAbsences.CurrentRow != null)
            {
                Absence a = (Absence)dgvAbsences.CurrentRow.DataBoundItem;
                if (MessageBox.Show("Supprimer cette absence ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.controller.DeleteAbsence(a);
                    ChargerAbsences();
                }
            }
        }
        // Evenement du bouton retour qui ferme le formulaire
        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dgvAbsences_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
