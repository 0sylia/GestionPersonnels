# Gestion des Absences des Personnels
Application C# (Windows Forms .NET Framework) développée sous Visual Studio 2022, exploitant une base de données MySQL pour la gestion des personnels et de leurs absences.

##  Présentation de l'application

### Objectif de l’application

L’application **GestionPersonnelAbsences** permet au responsable :
- de s’authentifier de manière sécurisée ;
- de consulter la liste du personnel et de leurs absences ;
- d’ajouter, modifier ou supprimer une absence ;
- de visualiser les motifs d’absence prédéfinis (vacances, maladie, motif familial, congé parental) et les services (administratif, médiation culturelle, prêt).

## Structure de la base de données

Voici le schéma conceptuel des données (MCD) de la base de données, au format MySQL :
![MCD GestionPersonnelAbsences](C:\Users\yangs\OneDrive\VisualStudio_Projets\GestionAbsencePersonnel)

### Interface et Fonctionnalités

Voici à quoi doit ressembler la fenêtre principale de l'application :

*(<img width="713" height="537" alt="image" src="https://github.com/user-attachments/assets/aff95f6a-64fb-409f-897c-ff60e361d248" />
)*

L'application permet de :
-   **Gérer le personnel** : Afficher la liste des employés (nom, prénom, service, mail). Permettre l'ajout, la modification et la suppression d'une fiche employé.
-   **Gérer les absences** : Pour un employé sélectionné, visualiser la liste de ses absences (dates, motif). Permettre l'ajout et la suppression d'une absence.
-   **Sécuriser l'accès** : Un formulaire d'authentification limite l'accès à l'application au seul responsable, dont les identifiants sont sécurisés dans la base de données.

###Diagramme de Paquetages (Architecture MVC)

L'application est structurée dans le respect du pattern Modèle-Vue-Contrôleur (MVC).

*(<img width="863" height="791" alt="MediaTek86-mcd" src="https://github.com/user-attachments/assets/bce42af6-e43e-4293-914f-30a90273b265" />
)*

### Explications sur les couches supplémentaires

L'application contient deux paquetages supplémentaires par rapport au MVC classique :
-   **`bddmanager`** : Contient la classe `BddManager` (design pattern **Singleton**). Cette classe est indépendante et réutilisable. Elle est la seule à connaître MySQL et à exécuter les requêtes SQL brutes.
-   **`dal`** (Data Access Layer) : Fait le lien entre le contrôleur et `bddmanager`. Le contrôleur lui envoie une demande (ex: "donne-moi la liste du personnel"), et la DAL prépare la requête SQL, l'envoie à `bddmanager`, puis formate le résultat reçu avant de le renvoyer au contrôleur.
  
Il y a plusieurs avantages:
Le contrôleur est complètement décorrélé de la source de données. Il ignore si les informations qu'il manipule proviennent d'une base de données MySQL, d'un fichier XML ou d'un service web externe. Cette séparation des responsabilités rend l'application plus flexible et plus facile à faire évoluer.
Le changement de système de gestion de base de données est simplifié. Si l'entreprise décidait de migrer de MySQL vers PostgreSQL (ou tout autre SGBDR), seules les modifications au sein de la classe BddManager seraient nécessaires. Le reste de l'application, notamment les couches dal, controller et view, resterait parfaitement inchangé.
Le code gagne en clarté, en modularité et en maintenabilité. Chaque couche ayant un rôle bien défini (affichage, logique métier, accès aux données), l'application est plus facile à comprendre, à déboguer et à faire évoluer. Cette organisation limite les risques d'effets de bord lors de l'ajout de nouvelles fonctionnalités.


### Présentation du Cheminement (Flux des données)

1.  **Point d'entrée :** L'application démarre sur la vue `FrmConnexion` (située dans le package Vue).
2.  **Authentification : **La vue crée une instance du contrôleur associé. Au clic sur "Se connecter", le contrôleur appelle la méthode de contrôle de la classe `Access` (dans `dal`) pour vérifier les identifiants dans la base.
3.  **Requête :**La classe `Access` prépare une requête SQL SELECT et l'envoie à `BddManagerClasse pour exécution`.
4.  **Résultat :** Si le responsable est trouvé, la DAL retourne true au contrôleur, qui autorise l'ouverture de la vue principale `FrmGestionPersonnel`.
5.  **Gestion :** `FrmGestion` appelle son contrôleur `FrmGestionPersonnelController`, qui appelle la DAL (`PersonnelDal`, `AbsenceDal`) pour effectuer les opérations CRUD (Create, Read, Update, Delete).


## Étapes de construction de l'application

L'évolution du projet est visible à travers l'historique des commits sur GitHub.

**Commit "Phase 1 : Structure MVC et BDD Manager"**
    - Création de l'architecture des dossiers (`view`, `controller`, `model`, `dal`, `bddmanager`).
    - Création des classes métiers (`Personnel`, `Service`, `Motif`, `Absence`) correspondant aux tables de la base de données.
    - Implémentation du singleton `BddManager` (dans le package `bddmanager`) pour la connexion à la base de données MySQL, sur le modèle de l'application Habilitations.
    
**Commit "Phase 2 : DAL et vues principales"**
    - Création du package `dal` avec les classes d'accès aux données (`PersonnelDal`, `ServiceDal`, `MotifDal`, `AbsenceDal`) suivant la logique d'Habilitations.
    - Intégration de la propriété de chaîne de connexion dans la classe `Access` avec sa méthode de récupération.
    - Codage de l'interface utilisateur (partie Vue) : `FrmConnexion`, `FrmGestionPersonnel`, `FrmGestionAbsence`, `FrmAjoutModiPersonnel`, `FrmAjoutModifAbsence`.
    - Remplissage du `DataGridView` pour le personnel et les absences.
    
**Commit "Phase 3 : CRUD complet"**
    - Implémentation des fonctionnalités attendues dans chaque cas d'utilisation (dans le respect du MVC).
    - Ajout, modification et suppression d’un employé.
    - Ajout et suppression d’une absence pour un employé sélectionné.
    - Génération de la documentation technique (`Documentation.zip`) à partir des commentaires normalisés, intégration dans le projet et sauvegarde.
    
**Commit "Phase 4 : Authentification"**
    - Création du formulaire `FrmConnexion` pour l'authentification.
    - Alimentation de la table `responsable` avec un login et un mot de passe chiffré.
    - Sécurisation de l'accès : l'application principale (`FrmGestionPersonnel`) ne s'ouvre qu'après vérification du login/pwd (comparaison avec le hash stocké en base).
    - Remplissage des tables de référence : `motif` (vacances, maladie, motif familial, congé parental) et `service` (administratif, médiation culturelle, prêt).
    - Génération de données aléatoires pour les tables `personnel` (une dizaine d’exemples) et `absence` (une cinquantaine d’exemples) via un site de génération automatique d’insert.*
    - L'application est distribuée via un installeur unique généré avec **Inno Setup** dû à l'encontre de quelque problème avec Visual Studio Installer Package
**[Télécharger l'installeur (GestionAbsencePersonnels_setup.exe)]** (https://github.com/0sylia/GestionAbsencePersonnels/releases/download/v1.0.0/GestionAbsencePersonnels_setup.exe)


## Installation
Avant d'installer l'application, assurez-vous que votre environnement respecte les prérequis suivants :

-   **SGBDR MySQL** : Un serveur MySQL doit être installé et accessible (via WampServer, Laragon, XAMPP, ou un serveur dédié).
-   **Système d'exploitation** : Windows 10, Windows 11 ou version ultérieure (serveur ou poste de travail).
