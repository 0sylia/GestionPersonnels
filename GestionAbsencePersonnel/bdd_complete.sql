-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : sam. 30 mai 2026 à 22:56
-- Version du serveur : 8.4.7
-- Version de PHP : 8.3.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `absence_db`
--

-- --------------------------------------------------------

--
-- Structure de la table `absence`
--

DROP TABLE IF EXISTS `absence`;
CREATE TABLE IF NOT EXISTS `absence` (
  `idpersonnel` int NOT NULL,
  `idmotif` int NOT NULL,
  `datedebut` date DEFAULT NULL,
  `datefin` date DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `absence`
--

INSERT INTO `absence` (`idpersonnel`, `idmotif`, `datedebut`, `datefin`) VALUES
(1, 1, '2026-05-12', '2026-05-30'),
(2, 2, '2024-02-10', '2024-02-15'),
(3, 1, '2024-03-01', '2024-03-05'),
(4, 3, '2005-11-24', '2024-02-27'),
(7, 1, '2026-05-30', '2026-06-12'),
(9, 2, '2008-07-25', '2030-11-25'),
(3, 1, '2024-02-21', '2020-11-26'),
(4, 2, '2020-02-21', '2008-10-26'),
(11, 3, '2014-02-25', '2025-06-25'),
(12, 1, '2024-12-23', '2023-04-26'),
(9, 3, '2026-05-26', '2016-01-26'),
(3, 1, '2004-08-20', '2013-01-26'),
(11, 2, '2031-10-24', '2028-05-27'),
(8, 2, '2019-05-25', '2022-12-26'),
(2, 2, '2029-11-20', '2026-12-26'),
(6, 2, '2031-03-27', '2021-06-26'),
(8, 2, '2031-10-23', '2016-03-27'),
(10, 2, '2016-11-21', '2023-10-25'),
(6, 2, '2009-04-22', '2024-03-26'),
(10, 1, '2012-07-21', '2021-02-27'),
(6, 3, '2005-03-24', '2002-03-26'),
(6, 1, '2007-03-26', '2030-08-26'),
(6, 2, '2010-12-26', '2020-06-25'),
(6, 2, '2030-05-21', '2025-03-27'),
(7, 2, '2006-02-21', '2010-10-26'),
(12, 4, '2026-05-30', '2026-06-11'),
(8, 3, '2029-04-22', '2026-03-26'),
(5, 2, '2029-08-26', '2012-09-26'),
(8, 3, '2002-12-22', '2027-08-25'),
(9, 2, '2003-10-23', '2009-10-26'),
(6, 2, '2021-08-24', '2015-10-25'),
(11, 3, '2012-03-23', '2017-05-27'),
(10, 1, '2018-12-21', '2005-07-26'),
(3, 3, '2014-04-24', '2006-03-26'),
(6, 3, '2001-11-24', '2014-04-27'),
(3, 1, '2020-01-26', '2009-09-26'),
(6, 2, '2024-08-22', '2016-07-26'),
(8, 1, '2022-01-23', '2027-05-27'),
(2, 2, '2028-01-22', '2013-09-25'),
(10, 2, '2027-12-23', '2007-11-26'),
(6, 2, '2020-09-21', '2031-01-26'),
(7, 2, '2016-10-23', '2024-09-26'),
(9, 2, '2017-06-21', '2029-12-26'),
(11, 1, '2022-11-23', '2030-03-27'),
(5, 1, '2026-09-22', '2024-07-26'),
(11, 1, '2005-08-26', '2019-09-26'),
(1, 2, '2012-12-23', '2004-09-25'),
(7, 3, '2021-08-26', '2007-09-25'),
(10, 3, '2008-12-22', '2028-03-27'),
(8, 1, '2007-03-22', '2002-08-25'),
(9, 1, '2018-01-24', '2027-07-26'),
(5, 3, '2019-05-25', '2007-06-26'),
(10, 1, '2007-04-25', '2009-03-26'),
(2, 2, '2004-04-26', '2027-05-27'),
(7, 2, '2015-11-23', '2014-12-25'),
(11, 3, '2025-11-24', '2007-03-26'),
(5, 4, '2026-05-30', '2026-06-20'),
(1, 1, '2026-05-04', '2026-05-30'),
(13, 4, '2026-05-15', '2026-05-30'),
(1, 1, '2026-05-04', '2026-05-30'),
(1, 1, '2026-05-11', '2026-05-29'),
(11, 4, '2026-03-10', '2026-03-19'),
(9, 4, '2024-05-23', '2024-05-31');

-- --------------------------------------------------------

--
-- Structure de la table `motif`
--

DROP TABLE IF EXISTS `motif`;
CREATE TABLE IF NOT EXISTS `motif` (
  `idmotif` int NOT NULL,
  `libelle` varchar(64) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `motif`
--

INSERT INTO `motif` (`idmotif`, `libelle`) VALUES
(1, 'vacances'),
(2, 'maladie'),
(3, 'motif familial'),
(4, 'congé parental');

-- --------------------------------------------------------

--
-- Structure de la table `mytable`
--

DROP TABLE IF EXISTS `mytable`;
CREATE TABLE IF NOT EXISTS `mytable` (
  `id` mediumint UNSIGNED NOT NULL AUTO_INCREMENT,
  `idpersonnnel` mediumint DEFAULT NULL,
  `idmotif` mediumint DEFAULT NULL,
  `datedebut` varchar(255) DEFAULT NULL,
  `datefin` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=57 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `mytable`
--

INSERT INTO `mytable` (`id`, `idpersonnnel`, `idmotif`, `datedebut`, `datefin`) VALUES
(1, 4, 3, '05-11-24', '24-02-27'),
(2, 3, 3, '06-09-22', '11-06-25'),
(3, 9, 2, '08-07-25', '30-11-25'),
(4, 3, 1, '24-02-21', '20-11-26'),
(5, 4, 2, '20-02-21', '08-10-26'),
(6, 11, 3, '14-02-25', '25-06-25'),
(7, 12, 1, '24-12-23', '23-04-26'),
(8, 9, 3, '26-05-26', '16-01-26'),
(9, 3, 1, '04-08-20', '13-01-26'),
(10, 2, 2, '27-11-23', '25-02-27'),
(11, 11, 2, '31-10-24', '28-05-27'),
(12, 8, 2, '19-05-25', '22-12-26'),
(13, 2, 2, '29-11-20', '26-12-26'),
(14, 6, 2, '31-03-27', '21-06-26'),
(15, 8, 2, '31-10-23', '16-03-27'),
(16, 10, 2, '16-11-21', '23-10-25'),
(17, 6, 2, '09-04-22', '24-03-26'),
(18, 10, 1, '12-07-21', '21-02-27'),
(19, 6, 3, '05-03-24', '02-03-26'),
(20, 8, 2, '03-02-26', '19-09-25'),
(21, 6, 1, '07-03-26', '30-08-26'),
(22, 6, 2, '10-12-26', '20-06-25'),
(23, 6, 2, '30-05-21', '25-03-27'),
(24, 7, 2, '06-02-21', '10-10-26'),
(25, 3, 3, '15-01-27', '20-12-26'),
(26, 8, 3, '29-04-22', '26-03-26'),
(27, 5, 2, '29-08-26', '12-09-26'),
(28, 8, 3, '02-12-22', '27-08-25'),
(29, 9, 2, '03-10-23', '09-10-26'),
(30, 2, 1, '27-04-25', '02-02-27'),
(31, 6, 2, '21-08-24', '15-10-25'),
(32, 11, 3, '12-03-23', '17-05-27'),
(33, 10, 1, '18-12-21', '05-07-26'),
(34, 3, 3, '14-04-24', '06-03-26'),
(35, 6, 3, '01-11-24', '14-04-27'),
(36, 3, 1, '20-01-26', '09-09-26'),
(37, 6, 2, '24-08-22', '16-07-26'),
(38, 8, 1, '22-01-23', '27-05-27'),
(39, 2, 2, '28-01-22', '13-09-25'),
(40, 10, 2, '27-12-23', '07-11-26'),
(41, 6, 2, '20-09-21', '31-01-26'),
(42, 7, 2, '16-10-23', '24-09-26'),
(43, 9, 2, '17-06-21', '29-12-26'),
(44, 11, 1, '22-11-23', '30-03-27'),
(45, 5, 1, '26-09-22', '24-07-26'),
(46, 11, 1, '05-08-26', '19-09-26'),
(47, 1, 2, '12-12-23', '04-09-25'),
(48, 7, 3, '21-08-26', '07-09-25'),
(49, 10, 3, '08-12-22', '28-03-27'),
(50, 8, 1, '07-03-22', '02-08-25'),
(51, 9, 1, '18-01-24', '27-07-26'),
(52, 5, 3, '19-05-25', '07-06-26'),
(53, 10, 1, '07-04-25', '09-03-26'),
(54, 2, 2, '04-04-26', '27-05-27'),
(55, 7, 2, '15-11-23', '14-12-25'),
(56, 11, 3, '25-11-24', '07-03-26');

-- --------------------------------------------------------

--
-- Structure de la table `personnel`
--

DROP TABLE IF EXISTS `personnel`;
CREATE TABLE IF NOT EXISTS `personnel` (
  `idpersonnel` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(64) NOT NULL,
  `prenom` varchar(64) NOT NULL,
  `tel` varchar(64) NOT NULL,
  `mail` varchar(64) NOT NULL,
  `idservice` int NOT NULL,
  PRIMARY KEY (`idpersonnel`)
) ENGINE=MyISAM AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `personnel`
--

INSERT INTO `personnel` (`idpersonnel`, `nom`, `prenom`, `tel`, `mail`, `idservice`) VALUES
(1, 'TIOLO', 'Evan', '1-333-263-3449', 'phasellus.dolor@protonmail.edu', 2),
(2, 'Octavia', ' Mcfadden', '1-677-376-1733', 'euismod.enim@protonmail.org', 2),
(4, 'Kibo', ' Stephens', '(952) 521-8542', 'tempor.arcu@yahoo.edu', 3),
(5, 'Seth', ' Carr', '(861) 126-8785', 'elit.erat@outlook.couk', 1),
(6, 'Walker', 'Spears', '1-335-555-1938', 'dictum@icloud.couk', 2),
(7, 'Rudyard', ' Cantu', '1-871-837-4575', 'et.risus@icloud.ca', 3),
(8, 'Salvador', ' Foreman', '1-960-722-3238', 'amet.metus@yahoo.net', 2),
(12, 'Lafrousse', 'Tim', '356173842', 'timfrousse@icloud.com', 3),
(9, 'Ignatius', ' Emerson', '(862) 621-8489', 'phasellus.fermentum.convallis@protonmail.org', 3),
(11, 'Nolo', 'Pierre', '23 34 33 33 33', 'pierreboule@icloud.com', 1),
(13, 'PIerre', 'Jean', '355671345', 'yuiiirri@ddsd', 3);

-- --------------------------------------------------------

--
-- Structure de la table `responsable`
--

DROP TABLE IF EXISTS `responsable`;
CREATE TABLE IF NOT EXISTS `responsable` (
  `login` varchar(64) NOT NULL,
  `pwd` varchar(64) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `responsable`
--

INSERT INTO `responsable` (`login`, `pwd`) VALUES
('responsable', '4fb4241e519d1667d98f8946298ee8f7bbc66edbd30962ca197b145a739dccce');

-- --------------------------------------------------------

--
-- Structure de la table `service`
--

DROP TABLE IF EXISTS `service`;
CREATE TABLE IF NOT EXISTS `service` (
  `idservice` int NOT NULL,
  `nom` varchar(64) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `service`
--

INSERT INTO `service` (`idservice`, `nom`) VALUES
(1, 'administratif'),
(2, 'médiation culturelle'),
(3, 'prêt');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
