-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Gegenereerd op: 27 jun 2025 om 14:14
-- Serverversie: 10.4.32-MariaDB
-- PHP-versie: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `stemwijzer`
--

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `partijen`
--

CREATE TABLE `partijen` (
  `id` int(11) NOT NULL,
  `naam` varchar(45) NOT NULL,
  `logo` varchar(50) NOT NULL,
  `contact` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Gegevens worden geëxporteerd voor tabel `partijen`
--

INSERT INTO `partijen` (`id`, `naam`, `logo`, `contact`) VALUES
(1, 'BBB', '', ''),
(2, 'SGP', '', ''),
(3, 'PVV', '', ''),
(4, 'FVD', '', ''),
(5, 'NSC', '', ''),
(6, 'GL-PVDA', '', ''),
(7, 'VVD', '', ''),
(9, 'D66', '..\\..\\PartijLogos\\D66.png', 'email: laldlladlada.com telefoon: 02486482'),
(10, 'CDA', '', '');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `partij_meningen`
--

CREATE TABLE `partij_meningen` (
  `id` int(11) NOT NULL,
  `partij_id` int(11) NOT NULL,
  `vraag_id` int(11) NOT NULL,
  `mening` varchar(14) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Gegevens worden geëxporteerd voor tabel `partij_meningen`
--

INSERT INTO `partij_meningen` (`id`, `partij_id`, `vraag_id`, `mening`) VALUES
(3, 1, 8, 'oneens'),
(4, 1, 9, 'eens'),
(5, 1, 10, 'eens'),
(6, 1, 11, 'eens'),
(7, 1, 12, 'eens'),
(8, 1, 13, 'eens'),
(9, 1, 14, 'oneens'),
(10, 1, 15, 'eens'),
(11, 1, 16, 'oneens'),
(12, 1, 17, 'eens'),
(13, 1, 18, 'oneens'),
(14, 1, 19, 'eens'),
(15, 1, 20, 'oneens'),
(16, 1, 21, 'eens'),
(17, 1, 22, 'oneens'),
(18, 2, 8, 'oneens'),
(19, 2, 9, 'eens'),
(20, 2, 10, 'oneens'),
(21, 2, 11, 'oneens'),
(22, 2, 12, 'oneens'),
(23, 2, 13, 'oneens'),
(24, 2, 14, 'oneens'),
(25, 2, 15, 'eens'),
(27, 2, 16, 'oneens'),
(28, 2, 17, 'eens'),
(29, 2, 17, 'eens'),
(30, 2, 18, 'eens'),
(31, 2, 19, 'oneens'),
(32, 2, 20, 'oneens'),
(33, 2, 21, 'eens'),
(34, 2, 22, 'oneens'),
(35, 3, 8, 'oneens'),
(36, 3, 9, 'eens'),
(37, 3, 10, 'eens'),
(38, 3, 11, 'oneens'),
(39, 3, 12, 'eens'),
(40, 3, 13, 'oneens'),
(41, 3, 14, 'oneens'),
(42, 3, 15, 'oneens'),
(43, 3, 16, 'oneens'),
(44, 3, 17, 'eens'),
(45, 3, 18, 'oneens'),
(46, 3, 19, 'eens'),
(47, 3, 20, 'eens'),
(48, 3, 21, 'eens'),
(49, 3, 22, 'eens'),
(50, 4, 8, 'oneens'),
(51, 4, 9, 'eens'),
(52, 4, 10, 'oneens'),
(53, 4, 11, 'oneens'),
(54, 4, 12, 'eens'),
(55, 4, 13, 'oneens'),
(56, 4, 14, 'oneens'),
(57, 4, 15, 'eens'),
(58, 4, 16, 'eens'),
(59, 4, 17, 'eens'),
(60, 4, 18, 'oneens'),
(61, 4, 19, 'eens'),
(62, 4, 20, 'oneens'),
(63, 4, 21, 'eens'),
(64, 4, 22, 'oneens'),
(65, 5, 8, 'oneens'),
(66, 5, 9, 'eens'),
(67, 5, 10, 'oneens'),
(68, 5, 11, 'eens'),
(69, 5, 12, 'oneens'),
(70, 5, 13, 'oneens'),
(71, 5, 14, 'eens'),
(72, 5, 15, 'eens'),
(73, 5, 16, 'oneens'),
(74, 5, 17, 'eens'),
(75, 5, 18, 'eens'),
(76, 5, 19, 'oneens'),
(77, 5, 20, 'eens'),
(78, 5, 21, 'eens'),
(79, 5, 22, 'oneens'),
(80, 6, 8, 'eens'),
(81, 6, 9, 'oneens'),
(82, 6, 10, 'eens'),
(83, 6, 11, 'oneens'),
(84, 6, 12, 'oneens'),
(85, 6, 13, 'oneens'),
(86, 6, 14, 'eens'),
(87, 6, 15, 'eens'),
(88, 6, 16, 'eens'),
(89, 6, 17, 'oneens'),
(90, 6, 18, 'eens'),
(91, 6, 19, 'eens'),
(92, 6, 20, 'eens'),
(93, 6, 21, 'oneens'),
(94, 6, 22, 'eens'),
(95, 7, 8, 'oneens'),
(96, 7, 9, 'eens'),
(97, 7, 10, 'oneens'),
(98, 7, 11, 'oneens'),
(99, 7, 12, 'oneens'),
(100, 7, 13, 'eens'),
(101, 7, 14, 'oneens'),
(102, 7, 15, 'eens'),
(103, 7, 16, 'oneens'),
(104, 7, 17, 'eens'),
(105, 7, 18, 'oneens'),
(106, 7, 19, 'eens'),
(107, 7, 20, 'oneens'),
(108, 7, 21, 'eens'),
(109, 7, 22, 'oneens'),
(110, 10, 8, 'oneens'),
(111, 10, 9, 'eens'),
(112, 10, 10, 'oneens'),
(113, 10, 11, 'eens'),
(114, 10, 12, 'oneens'),
(115, 10, 13, 'oneens'),
(116, 10, 14, 'eens'),
(117, 10, 15, 'eens'),
(118, 10, 16, 'oneens'),
(119, 10, 17, 'eens'),
(120, 10, 18, 'eens'),
(121, 10, 19, 'eens'),
(122, 10, 20, 'eens'),
(123, 10, 21, 'eens'),
(124, 10, 22, 'oneens'),
(125, 9, 8, 'eens'),
(126, 9, 9, 'oneens'),
(127, 9, 10, 'oneens'),
(128, 9, 11, 'eens'),
(129, 9, 12, 'oneens'),
(130, 9, 13, 'eens'),
(131, 9, 14, 'eens'),
(132, 9, 15, 'eens'),
(133, 9, 16, 'eens'),
(134, 9, 17, 'eens'),
(135, 9, 18, 'eens'),
(136, 9, 19, 'eens'),
(137, 9, 20, 'eens'),
(138, 9, 21, 'oneens'),
(139, 9, 22, 'eens');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `gebruikersnaam` varchar(15) NOT NULL,
  `email` varchar(40) NOT NULL,
  `wachtwoord` varchar(20) NOT NULL,
  `machtiging` varchar(10) NOT NULL,
  `geboorte_datum` date NOT NULL,
  `account_bijgewerkt` date NOT NULL,
  `account_gemaakt` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Gegevens worden geëxporteerd voor tabel `users`
--

INSERT INTO `users` (`id`, `gebruikersnaam`, `email`, `wachtwoord`, `machtiging`, `geboorte_datum`, `account_bijgewerkt`, `account_gemaakt`) VALUES
(1, 'jansenpeter', 'peterj@example.com', 'Welkom123', 'gebruiker', '1990-04-12', '2025-06-01', '2023-01-15'),
(2, 'mariekedevries', 'marieke@example.com', 'Passw0rd!', 'admin', '1988-11-30', '2025-05-25', '2022-03-20'),
(3, 'tomklaassen', 'tomk@example.com', 'Qwerty123', 'gebruiker', '1995-07-22', '2025-06-03', '2021-10-11'),
(4, 'sannebakker', 'sanneb@example.com', 'Test1234', 'gebruiker', '2000-01-01', '2025-06-01', '2023-04-02'),
(5, 'dirkjansen', 'dirk@example.com', 'Hello2023', 'admin', '1985-05-10', '2025-05-30', '2020-12-31'),
(6, 'lisavdhout', 'lisah@example.com', 'Flower22', 'gebruiker', '1999-09-09', '2025-06-02', '2022-02-28'),
(7, 'karenmeijer', 'karenm@example.com', 'Sunshine1', 'gebruiker', '1994-03-14', '2025-06-21', '2023-03-14'),
(8, 'robertsmits', 'roberts@example.com', 'Smits2022', 'admin', '1982-12-12', '2025-06-01', '2021-01-01'),
(9, 'eva.jong', 'eva.jong@example.com', 'Eva2021!', 'gebruiker', '1998-06-06', '2025-05-31', '2022-06-06'),
(10, 'lucasvdb', 'lucas@example.com', 'Welkom1', 'gebruiker', '1996-02-20', '2025-06-03', '2021-07-07'),
(11, 'sophievdberg', 'sophie@example.com', '123Welkom', 'admin', '1987-10-25', '2025-05-29', '2020-09-09'),
(12, 'rickjager', 'rick@example.com', 'Jager123', 'gebruiker', '1993-08-15', '2025-06-02', '2023-05-05'),
(13, 'annemiekes', 'anne@example.com', 'Anne2022', 'gebruiker', '1992-11-11', '2025-05-28', '2022-11-11'),
(14, 'marthadeboer', 'martha@example.com', 'Boer123!', 'admin', '1989-04-04', '2025-06-01', '2021-04-04'),
(15, 'janwillem', 'jan@example.com', 'Jan123456', 'gebruiker', '1991-01-01', '2025-06-03', '2023-01-01'),
(16, 'kimvddijk', 'kim@example.com', 'Dijk2023', 'gebruiker', '1997-05-05', '2025-06-02', '2022-05-05'),
(17, 'nielsbos', 'niels@example.com', 'Bosje123', 'gebruiker', '1990-10-10', '2025-05-30', '2021-10-10'),
(18, 'iris.klein', 'iris@example.com', 'IrisWacht1', 'admin', '1984-03-03', '2025-05-29', '2020-03-03'),
(19, 'daanvdr', 'daan@example.com', 'Daan123!', 'gebruiker', '1999-07-07', '2025-06-01', '2023-07-07'),
(20, 'chantaldk', 'chantal@example.com', 'Chantal1', 'gebruiker', '1996-09-09', '2025-06-04', '2021-09-09'),
(21, 'maartenvdl', 'maarten@example.com', 'Maarten22', 'admin', '1993-12-12', '2025-05-28', '2022-12-12'),
(22, 'romyvdmeer', 'romy@example.com', 'Romy2023', 'gebruiker', '1995-06-06', '2025-06-02', '2023-06-06'),
(23, 'timvdheuvel', 'tim@example.com', 'Tim1234!', 'gebruiker', '1986-11-11', '2025-06-01', '2020-11-11'),
(24, 'sabrinajans', 'sabrina@example.com', 'Sabrina!', 'admin', '1983-08-08', '2025-06-03', '2021-08-08'),
(25, 'nataliebos', 'natalie@example.com', 'Natalie1', 'gebruiker', '1997-03-03', '2025-05-30', '2022-03-03'),
(26, 'vincentvdb', 'vincent@example.com', 'Vincent1', 'gebruiker', '1989-05-05', '2025-06-21', '2023-05-05'),
(27, 'femkevddijk', 'femke@example.com', 'Femke123', 'admin', '1992-10-10', '2025-05-29', '2021-10-10'),
(28, 'stefanjong', 'stefan@example.com', 'StefanPW', 'gebruiker', '1994-07-07', '2025-06-02', '2022-07-07'),
(29, 'lauravdkamp', 'laura@example.com', 'LauraPass', 'gebruiker', '1990-02-02', '2025-06-03', '2020-02-02'),
(30, 'mikevdbos', 'mike@example.com', 'Mike123!', 'admin', '1985-01-01', '2025-06-01', '2021-01-01'),
(31, 'm', 'm@m.m', 'm', 'medewerker', '2025-06-04', '2025-06-04', '2025-06-04'),
(32, 'a', 'a@a.a', 'a', 'admin', '2025-06-04', '2025-06-04', '2025-06-04'),
(33, 'o', 'o@o.o', 'o', 'owner', '2025-06-04', '2025-06-04', '2025-06-04');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `verkiezingen`
--

CREATE TABLE `verkiezingen` (
  `id` int(11) NOT NULL,
  `titel` varchar(45) NOT NULL,
  `beschrijving` text NOT NULL,
  `start_datum` datetime NOT NULL,
  `eind_datum` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Gegevens worden geëxporteerd voor tabel `verkiezingen`
--

INSERT INTO `verkiezingen` (`id`, `titel`, `beschrijving`, `start_datum`, `eind_datum`) VALUES
(1, 'tweede kamerverkiezing', 'gewoon een verkiezing hoor MMMMMM AM ADJAG DAY Y AOUFGYGF UGFG SHGOASGFSGOU Y SAGFYSAGOFUGAS ASGFOASFG UAGFSAGF ASGF ASG SGSGAF GAYIGF AFS YAYF GS SGF AS FSAFAS FASG SAYYGF AGFAYS FASYGFAYSGF AOIFSAGF AS IFAS ASI FA AOIGS SFASAYGAS O SSAYS SAG ASGY SAGSAOI F IAS FS SA IYSOASG SAF AFIY SAIFASFI SAFAS FYAS FIA FYS AYFAS F ASYT YFAS YST FSYATFY AIA F gewoon ', '2026-06-17 12:00:00', '2026-07-24 14:55:00'),
(2, 'zverkiezing', 'adagag sgdsaasg', '2025-06-18 12:33:41', '2025-06-18 12:33:41'),
(3, 'averkiezing', 'aafsafafs', '2025-06-18 12:34:06', '2025-06-18 12:34:06');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `vragenarregement`
--

CREATE TABLE `vragenarregement` (
  `id` int(11) NOT NULL,
  `vraag` varchar(200) NOT NULL,
  `verkiezing_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Gegevens worden geëxporteerd voor tabel `vragenarregement`
--

INSERT INTO `vragenarregement` (`id`, `vraag`, `verkiezing_id`) VALUES
(8, '1. De regering moet ervoor zorgen dat de hoeveelheid vee minstens de helft kleiner wordt.', 1),
(9, '2. De accijns op benzine, gas en diesel moet omlaag.', 1),
(10, '3. Het eigen risico bij zorgverzekeringen moet worden afgeschaft.', 1),
(11, '4. Elke regio in Nederland moet een vast aantal mensen in de 2de kamer krijgen.', 1),
(12, '5. Mensen vanaf 65 jaar moeten gratis met trein, tram en bus kunnen reizen.', 1),
(13, '6. De regering moet meer investeren in opslag van CO2 onder de grond.', 1),
(14, '7. De regering moet ervoor zorgen dat Surinamers zonder visum naar Nederland kunnen reizen. ', 1),
(15, '8. Er moet een wet komen waarin staat dat Nederland altijd 2% van het bruto binnenlands product uitgeeft aan defensie.', 1),
(16, '9.De overheid moet meer geld geven aan scholen voor lessen in kunst en cultuur.', 1),
(17, '10. In Nederland moeten meer kerncentrales komen.', 1),
(18, '11. De Belasting op vliegreizen moet omhoog.', 1),
(19, '12. Huurders moeten het recht krijgen om hun sociale huurwoning te kopen van de woningcorporatie.', 1),
(20, '13. Kinderopvang mag alleen worden aangeboden door organisaties die geen winst maken.', 1),
(21, '14. Als een vluchteling in Nederland mag blijven, mag het gezin nu naar Nederland komen. De regering moet dat beperken.', 1),
(22, '15. De belasting op vermogen boven 57000 euro moet omhoog.', 1);

--
-- Indexen voor geëxporteerde tabellen
--

--
-- Indexen voor tabel `partijen`
--
ALTER TABLE `partijen`
  ADD PRIMARY KEY (`id`);

--
-- Indexen voor tabel `partij_meningen`
--
ALTER TABLE `partij_meningen`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_partij` (`partij_id`),
  ADD KEY `fk_vraag` (`vraag_id`);

--
-- Indexen voor tabel `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- Indexen voor tabel `verkiezingen`
--
ALTER TABLE `verkiezingen`
  ADD PRIMARY KEY (`id`);

--
-- Indexen voor tabel `vragenarregement`
--
ALTER TABLE `vragenarregement`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_vragenarregement_verkiezing` (`verkiezing_id`);

--
-- AUTO_INCREMENT voor geëxporteerde tabellen
--

--
-- AUTO_INCREMENT voor een tabel `partijen`
--
ALTER TABLE `partijen`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT voor een tabel `partij_meningen`
--
ALTER TABLE `partij_meningen`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=141;

--
-- AUTO_INCREMENT voor een tabel `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=38;

--
-- AUTO_INCREMENT voor een tabel `verkiezingen`
--
ALTER TABLE `verkiezingen`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT voor een tabel `vragenarregement`
--
ALTER TABLE `vragenarregement`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- Beperkingen voor geëxporteerde tabellen
--

--
-- Beperkingen voor tabel `partij_meningen`
--
ALTER TABLE `partij_meningen`
  ADD CONSTRAINT `fk_partij` FOREIGN KEY (`partij_id`) REFERENCES `partijen` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_vraag` FOREIGN KEY (`vraag_id`) REFERENCES `vragenarregement` (`id`) ON DELETE CASCADE;

--
-- Beperkingen voor tabel `vragenarregement`
--
ALTER TABLE `vragenarregement`
  ADD CONSTRAINT `fk_vragenarregement_verkiezing` FOREIGN KEY (`verkiezing_id`) REFERENCES `verkiezingen` (`id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
