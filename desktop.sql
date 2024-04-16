-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Ápr 16. 21:45
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `desktop`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `owners`
--

CREATE TABLE `owners` (
  `Id` int(11) NOT NULL,
  `LastName` varchar(255) NOT NULL,
  `FirstName` varchar(255) NOT NULL,
  `BirthsDay` date DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Ownership` varchar(255) DEFAULT NULL,
  `Settlement` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `owners`
--

INSERT INTO `owners` (`Id`, `LastName`, `FirstName`, `BirthsDay`, `Email`, `Address`, `Ownership`, `Settlement`) VALUES
(1, 'asd', 'asd', '0001-01-01', 'asd', 'asd', 'asd', 'das');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `trainers`
--

CREATE TABLE `trainers` (
  `Id` int(11) NOT NULL,
  `LastName` varchar(255) NOT NULL,
  `FirstName` varchar(255) NOT NULL,
  `BirthsDay` date DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `WorkingLevels` varchar(255) DEFAULT NULL,
  `Young` tinyint(1) DEFAULT NULL,
  `Middle` tinyint(1) DEFAULT NULL,
  `Old` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `trainers`
--

INSERT INTO `trainers` (`Id`, `LastName`, `FirstName`, `BirthsDay`, `Email`, `Address`, `WorkingLevels`, `Young`, `Middle`, `Old`) VALUES
(1, 'asd', 'asd', '0001-01-01', 'asd', 'asd', 'HIT edzés', 0, 1, 1),
(2, 'asd', 'asd', '0001-01-01', 'asd', 'das', 'HIT edzés', 1, 1, 0);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `visitors`
--

CREATE TABLE `visitors` (
  `Id` int(11) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `BirthsDay` date NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Address` varchar(255) NOT NULL,
  `WorkingForm` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `visitors`
--

INSERT INTO `visitors` (`Id`, `LastName`, `FirstName`, `BirthsDay`, `Email`, `Address`, `WorkingForm`) VALUES
(5, 'Kovács', 'Tamás', '2004-02-18', 'kovacs.tamas0218@gmail.com', 'Szeged, Nagyszombati utca 24/A', 'Izomépítés'),
(6, 'asd', 'asd', '0001-01-01', 'ads', 'ads', 'Plusz tömeg felvétele');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `owners`
--
ALTER TABLE `owners`
  ADD PRIMARY KEY (`Id`);

--
-- A tábla indexei `trainers`
--
ALTER TABLE `trainers`
  ADD PRIMARY KEY (`Id`);

--
-- A tábla indexei `visitors`
--
ALTER TABLE `visitors`
  ADD PRIMARY KEY (`Id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `owners`
--
ALTER TABLE `owners`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT a táblához `trainers`
--
ALTER TABLE `trainers`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT a táblához `visitors`
--
ALTER TABLE `visitors`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

CREATE USER 'desktop_user'@'localhost' IDENTIFIED BY 'password';

GRANT ALL PRIVILEGES ON desktop_vizsgaremek.* TO 'desktop_user'@'localhost';

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
