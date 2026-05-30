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
    /// Représente le formulaire de saisie/modification d'un personnel
    /// </summary>
    public partial class FrmAjoutModiPersonnel : Form
    {
        private Personnel personnel;
        private List<Service> services;
        private bool isModif = false;

        public Personnel Personnel { get { return this.personnel; } }

        // Constructeur pour AJOUT
        public FrmAjoutModiPersonnel()
        {
            InitializeComponent();
            this.personnel = new Personnel();
            this.isModif = false;
            ChargerServices();

        }
        // Constructeur pour MODIFICATION
        public FrmAjoutModiPersonnel(Personnel p)
        {
            InitializeComponent();
            this.personnel = p;
            this.isModif = true;
            ChargerServices();
            AfficherPersonnel();
        }
        //Charge la liste des services dans le comboBox et sélectionne le service du personnel si en mode modification
        private void ChargerServices()
        {
            ServiceDal serviceDal = new ServiceDal();
            this.services = serviceDal.GetAllServices();
            cboService.DataSource = null;
            cboService.DisplayMember = "Nom";
            cboService.ValueMember = "Id";
            cboService.DataSource = this.services;

            if (this.isModif && this.personnel.IdService > 0)
            {
                cboService.SelectedValue = this.personnel.IdService;
            }
        }
        // Affiche les données du personnel à modifier dans les champs du formulaire
        private void AfficherPersonnel()
        {
            txtNom.Text = this.personnel.Nom;
            txtPrenom.Text = this.personnel.Prenom;
            txtTel.Text = this.personnel.Tel;
            txtMail.Text = this.personnel.Mail;
            // Sélectionner le bon service dans le ComboBox
            for (int i = 0; i < cboService.Items.Count; i++)
            {
                Service s = (Service)cboService.Items[i];
                if (s.Idservice == this.personnel.IdService)
                {
                    cboService.SelectedIndex = i;
                    break;
                }
            }

        }
        //Bouton Valider : vérifie les champs obligatoires, met à jour l'objet personnel avec les données saisies, puis ferme le formulaire avec DialogResult.OK
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            // Vérification que les champs nom et prénom ne sont pas vides
            if (string.IsNullOrEmpty(txtNom.Text) || string.IsNullOrEmpty(txtPrenom.Text))
            {
                MessageBox.Show("Nom et prénom obligatoires");
                return;
            }
            this.personnel.Nom = txtNom.Text.Trim();
            this.personnel.Prenom = txtPrenom.Text.Trim();
            this.personnel.Tel = txtTel.Text.Trim();
            this.personnel.Mail = txtMail.Text.Trim();
            if (cboService.SelectedItem != null)
            {
                Service service = (Service)cboService.SelectedItem;
                this.personnel.IdService = service.Idservice;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        //Bouton Annuler : ferme le formulaire sans enregistrer les modifications
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void FrmAjoutModiPersonnel_Load(object sender, EventArgs e)
        {

        }

        private void txtTel_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
