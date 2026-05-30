using GestionAbsencePersonnel.Dal;
using GestionAbsencePersonnel.Modele;
using System.Collections.Generic;

namespace GestionAbsencePersonnel.controller
{
    /// <summary>
    /// Représente le contrôleur pour le formulaire de gestion du personnel. Permet de gérer les interactions entre la vue (formulaire) et le modèle (données du personnel).
    /// Fournit des méthodes pour récupérer la liste du personnel, ajouter un nouveau membre du personnel, modifier les informations d'un membre du personnel existant et supprimer un membre du personnel de la base de données. Utilise la classe PersonnelDal pour effectuer les opérations d'accès aux données liées au personnel.
    /// </summary>
    public class FrmGestionPersonnelController
    {
        private PersonnelDal personnelDal;
        // Constructeur : initialise le PersonnelDal pour gérer les opérations d'accès aux données liées au personnel
        public FrmGestionPersonnelController()
        {
            this.personnelDal = new PersonnelDal();
        }
        // Méthode pour récupérer la liste de tous les membres du personnel depuis la base de données en utilisant le PersonnelDal, et retourne une liste d'objets Personnel.
        public List<Personnel> GetPersonnels()
        {
            return this.personnelDal.GetAllPersonnels();
        }
        // Méthode pour ajouter un nouveau membre du personnel à la base de données en fonction des données de l'objet Personnel passé en paramètre, en utilisant le PersonnelDal.
        public void AddPersonnel(Personnel personnel)
        {
            this.personnelDal.AddPersonnel(personnel);
        }
        // Méthode pour modifier les informations d'un membre du personnel existant dans la base de données en fonction de son id, en utilisant le PersonnelDal.
        public void UpdatePersonnel(Personnel personnel)
        {
            this.personnelDal.UpdatePersonnel(personnel);
        }
        // Méthode pour supprimer un membre du personnel de la base de données en fonction de son id, en utilisant le PersonnelDal.
        public void DeletePersonnel(int id)
        {
            this.personnelDal.DeletePersonnel(id);
        }
    }
}