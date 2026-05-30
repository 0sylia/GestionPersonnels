using GestionAbsencePersonnel.Dal;
using GestionAbsencePersonnel.Modele;
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
    /// Reeprésente le formulaire de saisie/modification d'une absence du personnel. Permet de saisir les dates de début et de fin de l'absence, de sélectionner le personnel concerné et le motif de l'absence, et de valider ou annuler la saisie/modification.
    /// </summary>
    public partial class FrmAjoutModifAbsence : Form
    {
        private Absence absence;
        private List<Personnel> personnels;
        private List<Motif> motifs;
        private bool isModif = false;

        public Absence Absence { get { return this.absence; } }
        // Constructeur pour AJOUT
        public FrmAjoutModifAbsence()
        {
            InitializeComponent();
            this.absence = new Absence();
            this.isModif = false;
            ChargerComboBox();
        }

        // Constructeur pour MODIFICATION
        public FrmAjoutModifAbsence(Absence a)
        {
            InitializeComponent();
            this.absence = a;
            this.isModif = true;
            ChargerComboBox();
            AfficherAbsence();
        }
        // Charge les données dans les ComboBox
        private void ChargerComboBox()
        {
            PersonnelDal personnelDal = new PersonnelDal();
            MotifDal motifDal = new MotifDal();

            this.personnels = personnelDal.GetAllPersonnels();
            this.motifs = motifDal.GetAllMotifs();

            cboPersonnel.DisplayMember = "NomPrenom";
            cboPersonnel.ValueMember = "Idpersonnel";
            cboPersonnel.DataSource = this.personnels;

            cboMotif.DisplayMember = "Libelle";
            cboMotif.ValueMember = "Idmotif";
            cboMotif.DataSource = this.motifs;
        }
        // Affiche les données de l'absence à modifier dans les champs du formulaire
        private void AfficherAbsence()
        {
            dtpDateDebut.Value = this.absence.DateDebut;
            dtpDateFin.Value = this.absence.DateFin;
            cboPersonnel.SelectedValue = this.absence.IdPersonnel;
            cboMotif.SelectedValue = this.absence.IdMotif;
        }
        // Bouton Valider : vérifie que la date de fin est après la date de début, met à jour l'objet absence avec les données saisies, puis ferme le formulaire avec DialogResult.OK
        private void btnEnregistrerAbsence_Click(object sender, EventArgs e)
        {
            // Vérification que la date de fin est après la date de début
            if (dtpDateDebut.Value > dtpDateFin.Value)
            {
                MessageBox.Show("La date de fin doit être après la date de début");
                return;
            }
            this.absence.DateDebut = dtpDateDebut.Value;
            this.absence.DateFin = dtpDateFin.Value;
            this.absence.IdPersonnel = (int)cboPersonnel.SelectedValue;
            this.absence.IdMotif = (int)cboMotif.SelectedValue;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        // Bouton Annuler : ferme le formulaire avec DialogResult.Cancel
        private void btnAnnulerAbsence_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmAjoutModifAbsence_Load(object sender, EventArgs e)
        {

        }
    }
}
