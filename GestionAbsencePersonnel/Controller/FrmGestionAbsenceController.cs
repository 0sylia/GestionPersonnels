using GestionAbsencePersonnel.Dal;
using GestionAbsencePersonnel.Modele;
using System.Collections.Generic;
using System;

namespace GestionAbsencePersonnel.controller
{
    /// <summary>
    /// Représente le contrôleur pour le formulaire de gestion des absences du personnel. Permet de gérer les interactions entre la vue (formulaire) et les données (DAL) liées aux absences, au personnel et aux motifs d'absence. Fournit des méthodes pour récupérer les listes d'absences, de personnels et de motifs, ainsi que pour ajouter, modifier et supprimer des absences dans la base de données.
    /// </summary>
    public class FrmGestionAbsenceController
    {
        private AbsenceDal absenceDal;
        private PersonnelDal personnelDal;
        private MotifDal motifDal;
        // Constructeur : initialise les DAL pour les absences, le personnel et les motifs d'absence
        public FrmGestionAbsenceController()
        {
            this.absenceDal = new AbsenceDal();
            this.personnelDal = new PersonnelDal();
            this.motifDal = new MotifDal();
        }
        // Méthode pour récupérer la liste de toutes les absences depuis le DAL et retourner une liste d'objets Absence.
        public List<Absence> GetAbsences()
        {
            return this.absenceDal.GetAllAbsences();
        }
        // Méthode pour récupérer la liste de tous les personnels depuis le DAL et retourner une liste d'objets Personnel.
        public List<Personnel> GetPersonnels()
        {
            return this.personnelDal.GetAllPersonnels();
        }
        // Méthode pour récupérer la liste de tous les motifs d'absence depuis le DAL et retourner une liste d'objets Motif.
        public List<Motif> GetMotifs()
        {
            return this.motifDal.GetAllMotifs();
        }
        // Méthode pour ajouter une nouvelle absence à la base de données en fonction des données de l'objet Absence passé en paramètre.
        public void AddAbsence(Absence absence)
        {
            this.absenceDal.AddAbsence(absence);
        }
        // Méthode pour modifier une absence existante dans la base de données en fonction de son id.
        public void UpdateAbsence(Absence absence)
        {
            this.absenceDal.UpdateAbsence(absence);
        }
        // Méthode pour supprimer une absence de la base de données en fonction de son id.
        public void DeleteAbsence(Absence absence)
        {
            this.absenceDal.DeleteAbsence(absence.IdPersonnel, absence.DateDebut);
        }
    }
}