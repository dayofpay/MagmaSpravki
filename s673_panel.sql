-- phpMyAdmin SQL Dump
-- version 4.4.15.10
-- https://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time:  7 ное 2021 в 05:13
-- Версия на сървъра: 10.5.12-MariaDB
-- PHP Version: 7.4.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `s673_panel`
--

-- --------------------------------------------------------

--
-- Структура на таблица `punishments`
--

CREATE TABLE IF NOT EXISTS `punishments` (
  `punish_date` varchar(256) NOT NULL,
  `punish_reason` varchar(256) NOT NULL,
  `punish_issuer` varchar(256) NOT NULL,
  `punish_user` varchar(256) NOT NULL,
  `punish_remove_points` int(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Схема на данните от таблица `punishments`
--

INSERT INTO `punishments` (`punish_date`, `punish_reason`, `punish_issuer`, `punish_user`, `punish_remove_points`) VALUES
('1.1.2011', 'Test', 'asd', 'dayofpay', 1),
('1.1.2012', 'Test2', 'asd2', 'dayofpay', 1),
('7.11.2021 ?. 4:14:09', 'test', 'dayofpay', 'dayofpay', 1);

-- --------------------------------------------------------

--
-- Структура на таблица `staffmembers`
--

CREATE TABLE IF NOT EXISTS `staffmembers` (
  `user` varchar(256) NOT NULL,
  `password` varchar(256) NOT NULL,
  `rank` varchar(256) NOT NULL,
  `current_points` int(200) NOT NULL,
  `added_by` varchar(256) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Схема на данните от таблица `staffmembers`
--

INSERT INTO `staffmembers` (`user`, `password`, `rank`, `current_points`, `added_by`) VALUES
('Alexcho360BG', 'magma4271', 'Chat-Helper', 11, 'dayofpay'),
('dayofpay', 'magma123!@', 'Admin', 7, ''),
('Decay', 'magma2740', 'Admin', 11, 'dayofpay'),
('Ghosst23', 'magma6201', 'Chat-Helper', 11, 'dayofpay'),
('Jigitaeca', 'magma9151', 'Moderator', 10, 'dayofpay'),
('Marti49BG', 'magma5724', 'Admin', 15, 'dayofpay'),
('Marto06BG', 'magma7926', 'Chat-Helper', 10, 'dayofpay'),
('Preskow', 'magma8923', 'Moderator', 3, ''),
('sk_acho', 'magma3307', 'Helper', 14, 'dayofpay'),
('splashybarbecue', 'magma1500', 'Chat-Helper', 9, 'dayofpay'),
('tattos_love', 'magma8063', 'Chat-Helper', 10, 'dayofpay'),
('Vexs', 'magma6583', 'Helper', 9, 'dayofpay'),
('Whatasd12', 'magma9094', 'Chat-Helper', 10, 'dayofpay'),
('xGucciDreqm_', 'magma9563', 'Helper', 15, 'dayofpay'),
('XxKizzerXx', 'magma7571', 'Helper', 10, 'dayofpay'),
('XxVesoXx', 'magma8202', 'Admin', 10, 'dayofpay'),
('_Incubus__', 'magma4934', 'Helper', 4, 'dayofpay');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `punishments`
--
ALTER TABLE `punishments`
  ADD PRIMARY KEY (`punish_date`);

--
-- Indexes for table `staffmembers`
--
ALTER TABLE `staffmembers`
  ADD PRIMARY KEY (`user`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
