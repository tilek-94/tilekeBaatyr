-- --------------------------------------------------------
-- Хост:                         localhost
-- Версия сервера:               5.7.29-log - MySQL Community Server (GPL)
-- Операционная система:         Win64
-- HeidiSQL Версия:              11.0.0.5919
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Дамп структуры базы данных u_system
CREATE DATABASE IF NOT EXISTS `u_system` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `u_system`;

-- Дамп структуры для представление u_system.analis_cars
-- Создание временной таблицы для обработки ошибок зависимостей представлений
CREATE TABLE `analis_cars` (
	`id` INT(11) NOT NULL,
	`name` VARCHAR(50) NULL COLLATE 'utf8_general_ci',
	`marka` CHAR(50) NULL COLLATE 'utf8_general_ci',
	`data` CHAR(50) NULL COLLATE 'utf8_general_ci',
	`A1` DOUBLE(22,0) NULL,
	`A2` DOUBLE(22,0) NULL,
	`B1` DOUBLE(22,0) NULL,
	`B2` DOUBLE(22,0) NULL
) ENGINE=MyISAM;

-- Дамп структуры для таблица u_system.bisnesclass
CREATE TABLE IF NOT EXISTS `bisnesclass` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `dom_id` int(11) NOT NULL DEFAULT '0',
  `name` mediumtext CHARACTER SET utf8,
  `m2` int(11) DEFAULT NULL,
  `info` mediumtext CHARACTER SET utf8,
  `remov` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Дамп данных таблицы u_system.bisnesclass: ~3 rows (приблизительно)
/*!40000 ALTER TABLE `bisnesclass` DISABLE KEYS */;
INSERT INTO `bisnesclass` (`id`, `dom_id`, `name`, `m2`, `info`, `remov`) VALUES
	(1, 21, '1-sector', 83, '0000', 0),
	(2, 21, '2-sector', 25, 'dsfdfd', 0),
	(3, 21, '3-sector', 22, 'sdf', 0);
/*!40000 ALTER TABLE `bisnesclass` ENABLE KEYS */;

-- Дамп структуры для таблица u_system.bron
CREATE TABLE IF NOT EXISTS `bron` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `client_id` int(11) DEFAULT NULL,
  `dom_id` int(11) DEFAULT NULL,
  `number_f` int(11) DEFAULT NULL,
  `price_kv` double DEFAULT NULL,
  `typev` char(50) DEFAULT NULL,
  `kurs` int(11) DEFAULT NULL,
  `sotrudnic_id` int(11) DEFAULT NULL,
  `data` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `remov` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.bron: ~4 rows (приблизительно)
/*!40000 ALTER TABLE `bron` DISABLE KEYS */;
INSERT INTO `bron` (`id`, `client_id`, `dom_id`, `number_f`, `price_kv`, `typev`, `kurs`, `sotrudnic_id`, `data`, `remov`) VALUES
	(17, 15, 21, 7, 550, '(USD)', 186, 12, '2020-08-08 17:21:21', 0),
	(18, 16, 21, 9, 500, '(USD)', 187, 13, '2020-08-08 17:21:26', 8),
	(19, 15, 21, 8, 500, '(USD)', 188, 12, '2020-08-08 17:21:29', 0),
	(20, 16, 21, 3, 500, '(USD)', 192, 13, '2020-08-08 17:21:31', 0);
/*!40000 ALTER TABLE `bron` ENABLE KEYS */;

-- Дамп структуры для представление u_system.bron_pres
-- Создание временной таблицы для обработки ошибок зависимостей представлений
CREATE TABLE `bron_pres` (
	`id` INT(11) NOT NULL,
	`number_f` INT(11) NULL,
	`client` VARCHAR(50) NULL COLLATE 'utf8_general_ci',
	`to_usd` DOUBLE(22,0) NULL,
	`Rto_kgs` DOUBLE(22,0) NULL,
	`data` TIMESTAMP NULL,
	`name` VARCHAR(50) NULL COLLATE 'utf8mb4_general_ci',
	`dom_id` INT(11) NULL
) ENGINE=MyISAM;

-- Дамп структуры для таблица u_system.cars
CREATE TABLE IF NOT EXISTS `cars` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `marka` char(50) DEFAULT NULL,
  `data` char(50) DEFAULT NULL,
  `nomer` char(50) DEFAULT NULL,
  `condition_c` text,
  `prih_summ` double DEFAULT NULL,
  `type_v` char(50) DEFAULT NULL,
  `kurs` int(11) DEFAULT NULL,
  `client_id` int(11) DEFAULT NULL,
  `datatim` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `remov` int(11) DEFAULT '0',
  `prod_cars` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.cars: ~4 rows (приблизительно)
/*!40000 ALTER TABLE `cars` DISABLE KEYS */;
INSERT INTO `cars` (`id`, `marka`, `data`, `nomer`, `condition_c`, `prih_summ`, `type_v`, `kurs`, `client_id`, `datatim`, `remov`, `prod_cars`) VALUES
	(28, 'Honda accord III', '22.07.2020', 'AO4512B', 'Жакшы', 5600, '(USD)', 179, 17, '2020-08-09 20:42:33', 7, 0),
	(29, 'Inspatye', '24.07.2020', 'ABZ 1245 02', 'aaa', 3500, '(USD)', 180, 18, '2020-08-04 19:09:07', 0, 0),
	(30, 'Inspatye2', '24.07.2020', 'DC4512', 'aaa', 740000, '(KGS)', 192, 19, '2020-08-04 19:09:11', 7, 7),
	(31, 'Inspatye3', '24.07.2020', 'ODS 02521', 'aaa', 630000, '(KGS)', 192, 16, '2020-08-05 19:42:41', 7, 7),
	(32, 'BMW x6', '14.09.2017', 'AS1212', 'отличное', 8900, '(USD)', 260, 18, '2020-08-09 20:30:14', 7, 7);
/*!40000 ALTER TABLE `cars` ENABLE KEYS */;

-- Дамп структуры для представление u_system.carsid
-- Создание временной таблицы для обработки ошибок зависимостей представлений
CREATE TABLE `carsid` (
	`id` INT(11) NOT NULL,
	`marka` CHAR(50) NULL COLLATE 'utf8_general_ci',
	`data` CHAR(50) NULL COLLATE 'utf8_general_ci',
	`nomer` CHAR(50) NULL COLLATE 'utf8_general_ci',
	`condition_c` TEXT(65535) NULL COLLATE 'utf8_general_ci',
	`client` VARCHAR(50) NULL COLLATE 'utf8_general_ci',
	`datatim` TIMESTAMP NULL,
	`to_usd` DOUBLE(22,0) NULL,
	`Rto_kgs` DOUBLE(22,0) NULL,
	`kurs` INT(11) NULL
) ENGINE=MyISAM;

-- Дамп структуры для таблица u_system.client
CREATE TABLE IF NOT EXISTS `client` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) DEFAULT NULL,
  `data` varchar(50) DEFAULT NULL,
  `tel_nom` varchar(50) DEFAULT NULL,
  `AN` varchar(50) DEFAULT NULL,
  `data_vdan` varchar(50) DEFAULT NULL,
  `vdan_uch` varchar(50) DEFAULT NULL,
  `address_pas` text,
  `address` text,
  `foto` longblob,
  `remov` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.client: ~4 rows (приблизительно)
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
INSERT INTO `client` (`id`, `name`, `data`, `tel_nom`, `AN`, `data_vdan`, `vdan_uch`, `address_pas`, `address`, `foto`, `remov`) VALUES
	(15, 'Умаров Тилек Муталибович', '20.03.1994', '+996 777 48 08 68', 'AN 266 82 83', '29.11.2011', 'MKK 50-34', 'КараСуу району бирдик айылы', 'Ош шаары ленин кочосу 328 ', NULL, 0),
	(16, 'Албазбеков Аскар Даниярович', '22.07.2020', '0777 44 56 21', 'AN 245 85 86', '12.06.2019', 'MKK 50-45', 'Араван району', 'Ош шаары Ленин', NULL, 0),
	(17, 'Калмаматов Баймат Калмаматович', '17.03.1994', '0771 28 05 86', 'AN 256 58 59', '11.03.2012', 'MKK 52 45', 'ЖалалАбад обл. Ноокен райноу', 'Ош Шаары КурманжанДатка 328', NULL, 0),
	(18, 'Асилов Залкар Аблатович', '30.01.1994', '0777 145141', 'AN 256 89 84', '10.11.2012', 'MKK 30-36', 'Ноокат району ', 'Ош шаары ленина 328', NULL, 0),
	(19, 'Асан уулу Баяман', '10.02.1995', '0777 47 45 56', 'AN 356 12 23', '12.01.2016', 'MKK 55-30', 'Карасуу ', 'Ош шаары ленин кочосу', NULL, 0);
/*!40000 ALTER TABLE `client` ENABLE KEYS */;

-- Дамп структуры для таблица u_system.currency
CREATE TABLE IF NOT EXISTS `currency` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `usd` double DEFAULT NULL,
  `eur` double DEFAULT NULL,
  `rub` double DEFAULT NULL,
  `data` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=263 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.currency: ~234 rows (приблизительно)
/*!40000 ALTER TABLE `currency` DISABLE KEYS */;
INSERT INTO `currency` (`id`, `usd`, `eur`, `rub`, `data`) VALUES
	(2, 74.5, 84.3, 1.114, '2020-06-29 09:34:36'),
	(3, 0, 0, 0, '2020-06-29 14:58:00'),
	(4, 0, 0, 0, '2020-06-29 15:08:47'),
	(5, 10, 0, 0, '2020-06-29 16:35:46'),
	(6, 75.9887, 85.5177, 1.0863, '2020-06-29 16:59:30'),
	(7, 74.5, 0, 0, '2020-06-29 17:30:14'),
	(8, 74.5, 0, 0, '2020-06-29 17:30:46'),
	(9, 75.9887, 85.5177, 1.0863, '2020-06-29 17:55:35'),
	(10, 75.9887, 85.5177, 1.0863, '2020-06-29 17:57:32'),
	(11, 74, 0, 0, '2020-06-29 17:59:39'),
	(12, 75.9887, 85.5177, 1.0863, '2020-06-29 18:00:15'),
	(13, 75.9887, 85.5177, 1.0863, '2020-06-29 18:02:16'),
	(14, 74, 0, 0, '2020-06-29 18:03:45'),
	(15, 75.9887, 85.5177, 1.0863, '2020-06-29 18:04:04'),
	(16, 75.9887, 85.5177, 1.0863, '2020-06-29 18:22:17'),
	(17, 75.9887, 85.5177, 1.0863, '2020-06-29 18:24:58'),
	(18, 75.9887, 85.5177, 1.0863, '2020-06-29 18:27:26'),
	(19, 75.9887, 85.5177, 1.0863, '2020-06-29 18:31:58'),
	(20, 75.9887, 85.5177, 1.0863, '2020-06-29 18:39:57'),
	(21, 75.9887, 85.5177, 1.0863, '2020-06-29 18:42:26'),
	(22, 74, 0, 0, '2020-06-29 18:42:35'),
	(23, 75.9887, 85.5177, 1.0863, '2020-06-29 18:42:51'),
	(24, 0, 0, 0, '2020-06-29 18:44:51'),
	(25, 75.9887, 85.5177, 1.0863, '2020-06-29 18:45:01'),
	(26, 75.9887, 85.5177, 1.0863, '2020-06-29 18:52:05'),
	(27, 75.9887, 85.5177, 1.0863, '2020-06-29 19:43:26'),
	(28, 75.9887, 85.5177, 1.0863, '2020-06-29 19:49:32'),
	(29, 75.9887, 85.5177, 1.0863, '2020-06-29 19:53:46'),
	(30, 75.9887, 85.5177, 1.0863, '2020-06-29 19:59:18'),
	(31, 74, 0, 0, '2020-06-29 20:00:55'),
	(32, 75.9887, 85.5177, 1.0863, '2020-06-29 20:01:32'),
	(33, 0, 0, 0, '2020-06-29 20:04:31'),
	(34, 75.9887, 85.5177, 1.0863, '2020-06-29 21:40:52'),
	(35, 75.9887, 85.5177, 1.0863, '2020-06-29 21:42:41'),
	(36, 75.9887, 85.5177, 1.0863, '2020-06-30 08:07:54'),
	(37, 75.9887, 85.5177, 1.0863, '2020-06-30 08:11:08'),
	(38, 75.9887, 85.5177, 1.0863, '2020-06-30 08:13:17'),
	(39, 75.9887, 85.5177, 1.0863, '2020-06-30 08:14:34'),
	(40, 75.9887, 85.5177, 1.0863, '2020-06-30 08:32:44'),
	(41, 75.9887, 85.5177, 1.0863, '2020-06-30 08:33:46'),
	(42, 75.9887, 85.5177, 1.0863, '2020-06-30 08:36:10'),
	(43, 75.9887, 85.5177, 1.0863, '2020-06-30 08:42:16'),
	(44, 75.9887, 85.5177, 1.0863, '2020-06-30 08:47:00'),
	(45, 75.9887, 85.5177, 1.0863, '2020-06-30 09:11:53'),
	(46, 75.9887, 85.5177, 1.0863, '2020-06-30 09:14:43'),
	(47, 75.9887, 85.5177, 1.0863, '2020-06-30 09:29:04'),
	(48, 75.9887, 85.5177, 1.0863, '2020-06-30 11:09:25'),
	(49, 75.9887, 85.5177, 1.0863, '2020-06-30 11:22:38'),
	(50, 75.9887, 85.5177, 1.0863, '2020-06-30 11:24:57'),
	(51, 75.9887, 85.5177, 1.0863, '2020-06-30 11:27:23'),
	(52, 75.9887, 85.5177, 1.0863, '2020-06-30 11:29:56'),
	(53, 75.9887, 85.5177, 1.0863, '2020-06-30 11:31:04'),
	(54, 75.9887, 85.5177, 1.0863, '2020-06-30 11:43:51'),
	(55, 75.9887, 85.5177, 1.0863, '2020-06-30 11:46:28'),
	(56, 75.9887, 85.5177, 1.0863, '2020-06-30 11:48:41'),
	(57, 75.9887, 85.5177, 1.0863, '2020-06-30 11:50:09'),
	(58, 75.9887, 85.5177, 1.0863, '2020-06-30 13:35:47'),
	(59, 75.9887, 85.5177, 1.0863, '2020-06-30 14:33:30'),
	(60, 75.9887, 85.5177, 1.0863, '2020-06-30 14:55:59'),
	(61, 75.9887, 85.5177, 1.0863, '2020-06-30 15:04:41'),
	(62, 75.9887, 85.5177, 1.0863, '2020-06-30 15:12:42'),
	(63, 75.9887, 85.5177, 1.0863, '2020-06-30 15:19:31'),
	(64, 75.9887, 85.5177, 1.0863, '2020-06-30 15:28:18'),
	(65, 75.9887, 85.5177, 1.0863, '2020-06-30 16:06:43'),
	(66, 75.9887, 85.2479, 1.0788, '2020-07-01 08:14:35'),
	(67, 75.9887, 85.2479, 1.0788, '2020-07-01 08:30:44'),
	(68, 75.9887, 85.2479, 1.0788, '2020-07-01 08:52:37'),
	(69, 75.9887, 85.2479, 1.0788, '2020-07-01 09:07:03'),
	(70, 75.9887, 85.2479, 1.0788, '2020-07-01 09:13:55'),
	(71, 75.9887, 85.2479, 1.0788, '2020-07-01 09:23:28'),
	(72, 75.9887, 85.2479, 1.0788, '2020-07-01 09:34:47'),
	(73, 75.9887, 85.2479, 1.0788, '2020-07-01 09:53:11'),
	(74, 75.9887, 85.2479, 1.0788, '2020-07-01 09:57:44'),
	(75, 75.9887, 85.2479, 1.0788, '2020-07-01 15:33:00'),
	(76, 75.9887, 85.2479, 1.0788, '2020-07-01 15:36:40'),
	(77, 75.9887, 85.2479, 1.0788, '2020-07-01 15:38:59'),
	(78, 75.9887, 85.2479, 1.0788, '2020-07-01 16:02:43'),
	(79, 78.6899, 88.4042, 1.1171, '2020-07-01 21:50:35'),
	(80, 78.6899, 88.4042, 1.1171, '2020-07-02 01:33:40'),
	(81, 78.6899, 88.4042, 1.1171, '2020-07-02 01:39:09'),
	(82, 78.6899, 88.4042, 1.1171, '2020-07-02 01:41:21'),
	(83, 78.6899, 88.4042, 1.1171, '2020-07-02 01:45:31'),
	(84, 78.6899, 88.4042, 1.1171, '2020-07-02 01:48:20'),
	(85, 78.6899, 88.4042, 1.1171, '2020-07-02 01:54:06'),
	(86, 78.7872, 89.0098, 1.1172, '2020-07-02 21:31:08'),
	(87, 77.1102, 86.614, 1.0938, '2020-07-04 11:37:05'),
	(88, 77.1102, 86.614, 1.0938, '2020-07-04 13:47:37'),
	(89, 77.1102, 86.614, 1.0938, '2020-07-04 15:05:10'),
	(90, 77.1102, 86.614, 1.0938, '2020-07-04 15:10:08'),
	(91, 77.1102, 86.614, 1.0938, '2020-07-04 15:16:17'),
	(92, 77.1102, 86.614, 1.0938, '2020-07-04 15:48:09'),
	(93, 77.1102, 86.614, 1.0938, '2020-07-04 15:55:43'),
	(94, 77.1102, 86.614, 1.0938, '2020-07-04 15:58:55'),
	(95, 77.1102, 86.614, 1.0938, '2020-07-04 16:04:08'),
	(96, 77.1102, 86.614, 1.0938, '2020-07-04 16:05:21'),
	(97, 77.1102, 86.614, 1.0938, '2020-07-04 16:06:48'),
	(98, 77.1102, 86.614, 1.0938, '2020-07-04 16:08:05'),
	(99, 77.1102, 86.614, 1.0938, '2020-07-04 16:12:02'),
	(100, 77.1102, 86.614, 1.0938, '2020-07-04 16:13:16'),
	(101, 77.1102, 86.614, 1.0938, '2020-07-04 16:15:58'),
	(102, 77.1102, 86.614, 1.0938, '2020-07-04 16:17:21'),
	(103, 77.1102, 86.614, 1.0938, '2020-07-04 16:21:20'),
	(104, 77.1102, 86.614, 1.0938, '2020-07-04 16:22:30'),
	(105, 77.1102, 86.614, 1.0938, '2020-07-04 20:12:54'),
	(106, 77.1102, 86.614, 1.0938, '2020-07-04 20:17:56'),
	(107, 77.1102, 86.614, 1.0938, '2020-07-04 20:32:00'),
	(108, 77.1102, 86.614, 1.0938, '2020-07-04 20:37:19'),
	(109, 77.1102, 86.614, 1.0938, '2020-07-04 20:39:57'),
	(110, 77.1102, 86.614, 1.0938, '2020-07-04 20:41:27'),
	(111, 77.1102, 86.614, 1.0938, '2020-07-04 20:44:14'),
	(112, 77.1102, 86.614, 1.0938, '2020-07-04 20:47:00'),
	(113, 77.1102, 86.614, 1.0938, '2020-07-04 20:49:01'),
	(114, 77.1102, 86.614, 1.0938, '2020-07-04 21:33:38'),
	(115, 77.1102, 86.614, 1.0938, '2020-07-04 21:35:25'),
	(116, 77.1102, 86.614, 1.0938, '2020-07-04 21:37:05'),
	(117, 77.1102, 86.614, 1.0938, '2020-07-06 02:30:24'),
	(118, 77.1102, 86.614, 1.0938, '2020-07-06 08:48:15'),
	(119, 77.1102, 86.614, 1.0938, '2020-07-06 08:50:34'),
	(120, 77.1102, 86.614, 1.0938, '2020-07-06 08:51:30'),
	(121, 77.1102, 86.614, 1.0938, '2020-07-06 08:58:43'),
	(122, 78.0266, 88.0062, 1.0953, '2020-07-08 17:18:17'),
	(123, 78.0266, 88.0062, 1.0953, '2020-07-08 18:33:56'),
	(124, 78.0266, 88.0062, 1.0953, '2020-07-08 18:34:27'),
	(125, 78.0266, 88.0062, 1.0953, '2020-07-08 20:29:53'),
	(126, 78.0266, 88.0062, 1.0953, '2020-07-08 20:39:29'),
	(127, 78.0266, 88.0062, 1.0953, '2020-07-08 20:44:45'),
	(128, 78.0266, 88.0062, 1.0953, '2020-07-08 20:46:14'),
	(129, 78.0266, 88.0062, 1.0953, '2020-07-08 20:49:01'),
	(130, 78.0266, 88.0062, 1.0953, '2020-07-08 20:51:05'),
	(131, 78.0266, 88.0062, 1.0953, '2020-07-08 21:25:49'),
	(132, 78.0266, 88.0062, 1.0953, '2020-07-08 21:26:35'),
	(133, 78.0266, 88.0062, 1.0953, '2020-07-09 09:14:02'),
	(134, 78.0266, 88.0062, 1.0953, '2020-07-09 09:34:07'),
	(135, 78.0266, 88.0062, 1.0953, '2020-07-09 09:39:28'),
	(136, 74.4, 82.335, 1.26, '2020-07-09 09:39:55'),
	(137, 78.0266, 88.0062, 1.0953, '2020-07-09 09:42:09'),
	(138, 78.0266, 88.0062, 1.0953, '2020-07-09 09:56:54'),
	(139, 78.0266, 88.0062, 1.0953, '2020-07-09 09:59:48'),
	(140, 75.5, 0, 0, '2020-07-09 10:19:04'),
	(141, 75.2, 0, 0, '2020-07-09 10:35:33'),
	(142, 78.0266, 88.0062, 1.0953, '2020-07-09 10:40:56'),
	(143, 78.0266, 88.0062, 1.0953, '2020-07-09 10:43:59'),
	(144, 78.0266, 88.0062, 1.0953, '2020-07-09 10:45:22'),
	(145, 78.0266, 88.0062, 1.0953, '2020-07-09 15:39:55'),
	(146, 78.0266, 88.0062, 1.0953, '2020-07-09 15:41:23'),
	(147, 78.0266, 88.0062, 1.0953, '2020-07-09 15:42:08'),
	(148, 77.7979, 88.1334, 1.0976, '2020-07-09 16:29:39'),
	(149, 77.7979, 88.1334, 1.0976, '2020-07-09 16:38:23'),
	(150, 77.7979, 88.1334, 1.0976, '2020-07-09 16:39:32'),
	(151, 70, 0, 0, '2020-07-09 16:40:48'),
	(152, 77.7979, 88.1334, 1.0976, '2020-07-09 16:57:36'),
	(153, 77.7979, 88.1334, 1.0976, '2020-07-09 16:57:42'),
	(154, 70, 0, 0, '2020-07-09 16:57:50'),
	(155, 77.8, 87.8362, 1.0922, '2020-07-10 19:28:34'),
	(156, 77.8, 87.8362, 1.0922, '2020-07-10 19:35:27'),
	(157, 77.8, 87.8362, 1.0922, '2020-07-10 19:53:30'),
	(158, 77.8, 87.8362, 1.0922, '2020-07-11 17:40:22'),
	(159, 77.8, 87.8362, 1.0922, '2020-07-11 17:43:23'),
	(160, 77.8, 87.8362, 1.0922, '2020-07-11 18:30:33'),
	(161, 77.8, 87.8362, 1.0922, '2020-07-11 18:39:35'),
	(162, 77.8, 87.8362, 1.0922, '2020-07-11 18:47:20'),
	(163, 77.8, 87.8362, 1.0922, '2020-07-11 18:57:00'),
	(164, 77.8, 87.8362, 1.0922, '2020-07-11 23:55:52'),
	(165, 77.8, 87.8362, 1.0922, '2020-07-12 15:06:26'),
	(166, 77.8, 87.8362, 1.0922, '2020-07-12 15:14:15'),
	(167, 77.8, 87.8362, 1.0922, '2020-07-12 15:18:48'),
	(168, 77.8, 87.8362, 1.0922, '2020-07-12 15:27:28'),
	(169, 77.8, 87.8362, 1.0922, '2020-07-12 15:32:01'),
	(170, 77.6206, 88.7747, 1.0963, '2020-07-16 05:29:16'),
	(171, 77.6206, 88.7747, 1.0963, '2020-07-16 08:53:06'),
	(172, 77.6206, 88.7747, 1.0963, '2020-07-16 08:58:06'),
	(173, 77.6206, 88.7747, 1.0963, '2020-07-16 09:04:09'),
	(174, 77.6206, 88.7747, 1.0963, '2020-07-16 09:18:56'),
	(175, 77.6206, 88.7747, 1.0963, '2020-07-16 09:22:00'),
	(176, 77.6206, 88.7747, 1.0963, '2020-07-16 09:24:30'),
	(177, 77.6206, 88.7747, 1.0963, '2020-07-16 09:26:34'),
	(178, 77.5397, 88.8062, 1.0775, '2020-07-20 19:50:47'),
	(179, 77.28, 88.4045, 1.089, '2020-07-22 10:54:40'),
	(180, 77.28, 88.4045, 1.089, '2020-07-22 12:27:09'),
	(181, 77.28, 88.4045, 1.089, '2020-07-22 13:13:52'),
	(182, 77.28, 88.4045, 1.089, '2020-07-22 15:20:35'),
	(183, 70, 0, 0, '2020-07-22 18:55:02'),
	(184, 76.5244, 88.1714, 1.081, '2020-07-23 10:21:51'),
	(185, 76.5244, 88.1714, 1.081, '2020-07-23 10:48:42'),
	(186, 76.5244, 88.1714, 1.081, '2020-07-23 10:52:11'),
	(187, 76.5244, 88.1714, 1.081, '2020-07-23 11:37:07'),
	(188, 76.5244, 88.1714, 1.081, '2020-07-23 11:40:20'),
	(189, 76.4989, 88.6622, 1.078, '2020-07-23 18:38:44'),
	(190, 76.4989, 88.6622, 1.078, '2020-07-24 00:17:22'),
	(191, 76.4989, 88.6622, 1.078, '2020-07-24 00:42:28'),
	(192, 76.4989, 88.6622, 1.078, '2020-07-24 10:26:55'),
	(193, 76.6643, 88.9383, 1.0708, '2020-07-26 13:06:03'),
	(194, 76.6643, 88.9383, 1.0708, '2020-07-26 16:26:20'),
	(195, 76.6643, 88.9383, 1.0708, '2020-07-26 16:48:17'),
	(196, 76.6643, 88.9383, 1.0708, '2020-07-27 13:00:26'),
	(197, 76.6224, 89.6137, 1.0704, '2020-07-27 17:39:11'),
	(198, 76.5534, 89.7282, 1.0644, '2020-07-28 20:05:07'),
	(199, 76.5534, 89.7282, 1.0644, '2020-07-28 20:14:54'),
	(200, 76.5534, 89.7282, 1.0644, '2020-07-28 20:17:04'),
	(201, 76.7808, 90.2251, 1.0629, '2020-07-30 09:56:55'),
	(202, 76.7808, 90.2251, 1.0629, '2020-07-30 11:16:08'),
	(203, 76.7808, 90.2251, 1.0629, '2020-07-30 11:18:24'),
	(204, 76.7808, 90.2251, 1.0629, '2020-07-30 11:40:23'),
	(205, 76.7808, 90.2251, 1.0629, '2020-07-30 11:42:31'),
	(206, 76.7808, 90.2251, 1.0629, '2020-07-30 12:17:39'),
	(207, 76.7553, 90.0877, 1.0462, '2020-07-30 17:33:14'),
	(208, 76.7553, 90.0877, 1.0462, '2020-07-30 17:53:25'),
	(209, 76.7553, 90.0877, 1.0462, '2020-07-30 17:55:00'),
	(210, 76.7553, 90.0877, 1.0462, '2020-07-30 17:59:12'),
	(211, 80, 0, 0, '2020-07-30 18:01:53'),
	(212, 76.7553, 90.0877, 1.0462, '2020-07-30 18:23:38'),
	(213, 76.7553, 90.0877, 1.0462, '2020-07-30 18:24:36'),
	(214, 76.7553, 90.0877, 1.0462, '2020-07-30 18:27:54'),
	(215, 76.7553, 90.0877, 1.0462, '2020-07-30 18:28:44'),
	(216, 76.7553, 90.0877, 1.0462, '2020-07-30 18:32:06'),
	(217, 76.7553, 90.0877, 1.0462, '2020-07-30 18:43:32'),
	(218, 76.7553, 90.0877, 1.0462, '2020-07-30 18:48:40'),
	(219, 76.7553, 90.0877, 1.0462, '2020-07-30 19:01:03'),
	(220, 76.7553, 90.0877, 1.0462, '2020-07-30 19:02:45'),
	(221, 76.7553, 90.0877, 1.0462, '2020-07-30 19:06:21'),
	(222, 70, 0, 0, '2020-08-01 16:59:56'),
	(223, 76.7553, 90.0877, 1.0462, '2020-08-01 17:20:14'),
	(224, 70, 0, 0, '2020-08-01 18:52:59'),
	(225, 70, 0, 0, '2020-08-01 18:58:11'),
	(226, 76.7553, 90.0877, 1.0462, '2020-08-02 17:18:18'),
	(227, 76.7553, 90.0877, 1.0462, '2020-08-02 17:21:20'),
	(228, 76.7553, 90.0877, 1.0462, '2020-08-02 20:03:28'),
	(229, 76.7553, 90.0877, 1.0462, '2020-08-02 20:21:17'),
	(230, 76.7553, 90.0877, 1.0462, '2020-08-03 13:05:53'),
	(231, 76.7553, 90.0877, 1.0462, '2020-08-03 13:08:43'),
	(232, 76.7553, 90.0877, 1.0462, '2020-08-03 13:09:54'),
	(233, 70, 0, 0, '2020-08-03 15:41:03'),
	(234, 70, 0, 0, '2020-08-03 15:42:46'),
	(235, 70, 0, 0, '2020-08-03 15:49:30'),
	(236, 76.7553, 90.0877, 1.0462, '2020-08-03 15:52:37'),
	(237, 76.7553, 90.0877, 1.0462, '2020-08-03 15:56:10'),
	(238, 76.8433, 90.4984, 1.0362, '2020-08-03 16:30:50'),
	(239, 76.8433, 90.4984, 1.0362, '2020-08-03 16:35:07'),
	(240, 76.9019, 91.0557, 1.0494, '2020-08-05 19:42:21'),
	(241, 76.9019, 91.0557, 1.0494, '2020-08-05 20:23:50'),
	(242, 76.9019, 91.0557, 1.0494, '2020-08-05 20:30:04'),
	(243, 76.9205, 91.0969, 1.0531, '2020-08-07 11:09:05'),
	(244, 76.9205, 91.0969, 1.0531, '2020-08-07 11:15:14'),
	(245, 76.9205, 91.0969, 1.0531, '2020-08-07 11:20:08'),
	(246, 76.9205, 91.0969, 1.0531, '2020-08-07 11:32:30'),
	(247, 77.05, 91.1694, 1.0463, '2020-08-08 18:01:05'),
	(248, 77.05, 91.1694, 1.0463, '2020-08-09 15:38:24'),
	(249, 77.05, 91.1694, 1.0463, '2020-08-09 16:23:34'),
	(250, 77.05, 91.1694, 1.0463, '2020-08-09 16:49:15'),
	(251, 77.05, 91.1694, 1.0463, '2020-08-09 16:51:29'),
	(252, 77.05, 91.1694, 1.0463, '2020-08-09 16:53:22'),
	(253, 77.05, 91.1694, 1.0463, '2020-08-09 16:56:13'),
	(254, 77.05, 91.1694, 1.0463, '2020-08-09 17:44:06'),
	(255, 77.05, 91.1694, 1.0463, '2020-08-09 17:48:04'),
	(256, 77.05, 91.1694, 1.0463, '2020-08-09 17:59:08'),
	(257, 77.05, 91.1694, 1.0463, '2020-08-09 18:04:59'),
	(258, 77.05, 91.1694, 1.0463, '2020-08-09 20:19:18'),
	(259, 77.05, 91.1694, 1.0463, '2020-08-09 20:22:14'),
	(260, 77.05, 91.1694, 1.0463, '2020-08-09 20:22:45'),
	(261, 77.05, 91.1694, 1.0463, '2020-08-09 20:25:06'),
	(262, 77.05, 91.1694, 1.0463, '2020-08-09 20:30:07');
/*!40000 ALTER TABLE `currency` ENABLE KEYS */;

-- Дамп структуры для представление u_system.display
-- Создание временной таблицы для обработки ошибок зависимостей представлений
CREATE TABLE `display` (
	`remov` TINYINT(4) NULL,
	`Zid` INT(11) NULL,
	`id` INT(11) NOT NULL,
	`number_f` INT(11) NULL,
	`floor` INT(11) NULL,
	`porch` INT(11) NULL,
	`kvm` DOUBLE(23,0) NULL,
	`contract` TEXT(65535) NULL COLLATE 'utf8_general_ci',
	`client` VARCHAR(50) NULL COLLATE 'utf8_general_ci',
	`Cars` VARCHAR(6) NOT NULL COLLATE 'utf8mb4_general_ci',
	`to_usd` DOUBLE(22,0) NULL,
	`Rto_kgs` DOUBLE(22,0) NULL,
	`data_n` DATE NULL,
	`data_k` DATE NULL,
	`klient_id` INT(11) NULL,
	`cars_id` TEXT(65535) NULL COLLATE 'utf8_general_ci',
	`dom_id` INT(11) NULL
) ENGINE=MyISAM;

-- Дамп структуры для представление u_system.displayzakaz
-- Создание временной таблицы для обработки ошибок зависимостей представлений
CREATE TABLE `displayzakaz` (
	`Названия комплекс` TEXT(65535) NULL COLLATE 'utf8_general_ci',
	`Клиент` VARCHAR(50) NULL COLLATE 'utf8_general_ci',
	`Номер квартира` INT(11) NULL,
	`Марка машина` CHAR(50) NULL COLLATE 'utf8_general_ci',
	`Сумма` DOUBLE(22,0) NULL,
	`Курс валюта` DOUBLE(22,0) NULL
) ENGINE=MyISAM;

-- Дамп структуры для таблица u_system.dom
CREATE TABLE IF NOT EXISTS `dom` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` text,
  `floor` int(11) DEFAULT NULL,
  `porch` int(11) DEFAULT NULL,
  `count_kv` int(11) DEFAULT NULL,
  `parking` int(11) DEFAULT NULL,
  `nom_flat` int(11) DEFAULT NULL,
  `addres` text,
  `remov` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.dom: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `dom` DISABLE KEYS */;
INSERT INTO `dom` (`id`, `name`, `floor`, `porch`, `count_kv`, `parking`, `nom_flat`, `addres`, `remov`) VALUES
	(21, '"Ош турак жай" комплекси ', 15, 2, 165, 54, 10, 'Новои 10', 0),
	(22, '"Корона Ош" комплекси ', 13, 5, 205, 60, 22, 'Ленина 428', 0);
/*!40000 ALTER TABLE `dom` ENABLE KEYS */;

-- Дамп структуры для представление u_system.dysplayaddbuild
-- Создание временной таблицы для обработки ошибок зависимостей представлений
CREATE TABLE `dysplayaddbuild` (
	`id` INT(11) NOT NULL,
	`number_f` INT(11) NULL,
	`floor` INT(11) NULL,
	`porch` INT(11) NULL,
	`kvm` DOUBLE(23,0) NULL,
	`contract` TEXT(65535) NULL COLLATE 'utf8_general_ci',
	`client` VARCHAR(50) NULL COLLATE 'utf8_general_ci',
	`Cars` VARCHAR(50) NULL COLLATE 'utf8_general_ci',
	`to_usd` DOUBLE(22,0) NULL,
	`Rto_kgs` DOUBLE(22,0) NULL,
	`data_n` DATE NULL,
	`data_k` DATE NULL,
	`klient_id` INT(11) NULL,
	`cars_id` TEXT(65535) NULL COLLATE 'utf8_general_ci',
	`dom_id` INT(11) NULL
) ENGINE=MyISAM;

-- Дамп структуры для таблица u_system.exchange
CREATE TABLE IF NOT EXISTS `exchange` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `client_id` int(11) NOT NULL DEFAULT '0',
  `product_id` int(11) NOT NULL DEFAULT '0',
  `number_f` int(11) NOT NULL DEFAULT '0',
  `data` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `dom_id` int(11) NOT NULL DEFAULT '0',
  `remov` int(11) NOT NULL DEFAULT '0',
  `emp` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- Дамп данных таблицы u_system.exchange: ~3 rows (приблизительно)
/*!40000 ALTER TABLE `exchange` DISABLE KEYS */;
INSERT INTO `exchange` (`id`, `client_id`, `product_id`, `number_f`, `data`, `dom_id`, `remov`, `emp`) VALUES
	(2, 16, 11, 2, '2020-07-24 10:27:36', 21, 0, 12),
	(3, 16, 11, 7, '2020-07-27 12:54:10', 21, 0, 13),
	(4, 16, 11, 1, '2020-07-30 10:08:52', 21, 0, 12);
/*!40000 ALTER TABLE `exchange` ENABLE KEYS */;

-- Дамп структуры для таблица u_system.finance
CREATE TABLE IF NOT EXISTS `finance` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `operationU` mediumtext CHARACTER SET utf8,
  `organ` mediumtext CHARACTER SET utf8,
  `summa` double DEFAULT NULL,
  `currency` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `data` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `typeO` tinyint(4) DEFAULT NULL,
  `sotrud` int(11) DEFAULT NULL,
  `remov` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Дамп данных таблицы u_system.finance: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `finance` DISABLE KEYS */;
/*!40000 ALTER TABLE `finance` ENABLE KEYS */;

-- Дамп структуры для таблица u_system.flat
CREATE TABLE IF NOT EXISTS `flat` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `dom_id` int(11) DEFAULT NULL,
  `floor` int(11) DEFAULT NULL,
  `porch` int(11) DEFAULT NULL,
  `room` int(11) DEFAULT NULL,
  `type_flat` varchar(50) DEFAULT NULL,
  `number_f` int(11) DEFAULT NULL,
  `remov` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=55 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.flat: ~20 rows (приблизительно)
/*!40000 ALTER TABLE `flat` DISABLE KEYS */;
INSERT INTO `flat` (`id`, `dom_id`, `floor`, `porch`, `room`, `type_flat`, `number_f`, `remov`) VALUES
	(32, 21, 3, 1, 1, '1-тип', 1, 0),
	(33, 21, 4, 1, 1, '1-тип', 3, 0),
	(34, 21, 5, 1, 1, '1-тип', 4, 0),
	(35, 21, 5, 1, 1, '1-тип', 8, 0),
	(36, 21, 5, 2, 2, '1-тип', 2, 0),
	(37, 21, 5, 2, 2, '1-тип', 6, 0),
	(38, 21, 5, 2, 2, '1-тип', 12, 0),
	(39, 21, 8, 2, 2, '1-тип', 9, 0),
	(40, 21, 9, 2, 2, '1-тип', 10, 0),
	(41, 21, 2, 1, 1, '1-тип', 5, 0),
	(42, 21, 2, 1, 1, '1-тип', 11, 0),
	(43, 21, 2, 1, 1, '1-тип', 7, 0),
	(44, 21, 2, 1, 1, '1-тип', 18, 0),
	(45, 21, 2, 1, 1, '1-тип', 20, 0),
	(46, 21, 2, 1, 1, '1-тип', 17, 0),
	(47, 21, 2, 1, 1, '1-тип', 15, 0),
	(48, 21, 2, 1, 1, '1-тип', 19, 0),
	(49, 21, 2, 1, 1, '1-тип', 23, 0),
	(50, 21, 2, 1, 1, '1-тип', 16, 0),
	(51, 21, 2, 1, 1, '1-тип', 13, 0),
	(52, 21, 2, 1, 1, '1-тип', 21, 0),
	(53, 22, 3, 1, 2, '3-тип', 4, 0),
	(54, 22, 4, 1, 2, '3-тип', 205, 0);
/*!40000 ALTER TABLE `flat` ENABLE KEYS */;

-- Дамп структуры для представление u_system.grafplat
-- Создание временной таблицы для обработки ошибок зависимостей представлений
CREATE TABLE `grafplat` (
	`id` INT(11) NOT NULL,
	`to_usd` DOUBLE(22,0) NULL,
	`Rto_kgs` DOUBLE(22,0) NULL,
	`itogu` DOUBLE(22,0) NULL,
	`itogk` DOUBLE(22,0) NULL,
	`vznosu` DOUBLE(22,0) NULL,
	`vznosk` DOUBLE(22,0) NULL,
	`debu` DOUBLE(22,0) NULL,
	`debk` DOUBLE(22,0) NULL,
	`CountData` BIGINT(21) NULL,
	`d1` INT(2) NULL,
	`m1` INT(2) NULL,
	`y1` INT(4) NULL,
	`d2` INT(2) NULL,
	`m2` INT(2) NULL,
	`y2` INT(4) NULL
) ENGINE=MyISAM;

-- Дамп структуры для процедура u_system.ins_cust
DELIMITER //
CREATE PROCEDURE `ins_cust`(n TEXT(255), e TEXT(255))
BEGIN 

END//
DELIMITER ;

-- Дамп структуры для процедура u_system.ins_cust1
DELIMITER //
CREATE PROCEDURE `ins_cust1`(n TEXT(255), e TEXT(255))
BEGIN 

END//
DELIMITER ;

-- Дамп структуры для таблица u_system.operation
CREATE TABLE IF NOT EXISTS `operation` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` mediumtext CHARACTER SET utf8,
  `remov` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Дамп данных таблицы u_system.operation: ~2 rows (приблизительно)
/*!40000 ALTER TABLE `operation` DISABLE KEYS */;
INSERT INTO `operation` (`id`, `name`, `remov`) VALUES
	(1, 'Темир', 0),
	(2, 'Арматура', 0);
/*!40000 ALTER TABLE `operation` ENABLE KEYS */;

-- Дамп структуры для таблица u_system.organization
CREATE TABLE IF NOT EXISTS `organization` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `pname` text CHARACTER SET utf8,
  `inn` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `data_registr` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `registr_s` varchar(50) CHARACTER SET utf8 COLLATE utf8_german2_ci DEFAULT NULL,
  `addres` text CHARACTER SET utf8,
  `tel` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `direct` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `data` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `remov` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Дамп данных таблицы u_system.organization: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `organization` DISABLE KEYS */;
INSERT INTO `organization` (`id`, `name`, `pname`, `inn`, `data_registr`, `registr_s`, `addres`, `tel`, `direct`, `data`, `remov`) VALUES
	(1, 'Ош турак жай', 'Ош турак жай', '20.03.2019', '0333245', '0332250', '0777 48 08 68', 'Ош шаары ленин кочосу', 'Саматов Арген', '2020-07-24 12:10:18', 0);
/*!40000 ALTER TABLE `organization` ENABLE KEYS */;

-- Дамп структуры для представление u_system.otchetprihod
-- Создание временной таблицы для обработки ошибок зависимостей представлений
CREATE TABLE `otchetprihod` (
	`tabl` VARCHAR(10) NOT NULL COLLATE 'utf8mb4_general_ci',
	`class` VARCHAR(19) NOT NULL COLLATE 'utf8mb4_general_ci',
	`to_usd` DOUBLE(22,0) NULL,
	`Rto_kgs` DOUBLE(22,0) NULL,
	`data` DATETIME NULL
) ENGINE=MyISAM;

-- Дамп структуры для таблица u_system.parking
CREATE TABLE IF NOT EXISTS `parking` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `dom_id` int(11) NOT NULL DEFAULT '0',
  `number` int(11) DEFAULT NULL,
  `client_id` int(11) DEFAULT NULL,
  `cars_id` text,
  `itogPrice` double(22,0) DEFAULT NULL,
  `zadol` double(22,0) DEFAULT NULL,
  `typev` char(50) DEFAULT NULL,
  `curr_id` int(11) DEFAULT NULL,
  `data` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `remov` int(11) DEFAULT '0',
  `emp` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

-- Дамп данных таблицы u_system.parking: ~14 rows (приблизительно)
/*!40000 ALTER TABLE `parking` DISABLE KEYS */;
INSERT INTO `parking` (`id`, `dom_id`, `number`, `client_id`, `cars_id`, `itogPrice`, `zadol`, `typev`, `curr_id`, `data`, `remov`, `emp`) VALUES
	(1, 21, 1, 16, '28', -5100, NULL, '(USD)', 191, '2020-07-30 10:34:29', 0, 12),
	(2, 21, 2, 16, '28', -392768, NULL, '(KGS)', 191, '2020-07-30 10:34:29', 8, 13),
	(3, 21, 2, 18, '29', 45308, NULL, '(KGS)', 205, '2020-07-30 11:45:15', 0, 12),
	(4, 21, 3, 18, '', 0, NULL, '(USD)', 205, '2020-07-30 11:45:40', 8, 13),
	(5, 21, 4, 18, '', 3500, NULL, '(USD)', 206, '2020-07-30 12:18:06', 0, 12),
	(6, 21, 5, 17, '[{"Id": 29, "Kgs": 270480, "Usd": 3500, "Name": "Inspatye"}]', 1500, 0, '(USD)', 213, '2020-07-30 18:24:52', 0, 12),
	(7, 21, 6, 19, '[{"Id": 28, "Kgs": 432768, "Usd": 5600, "Name": "Honda accord III"}]', 15000, 9400, '(USD)', 216, '2020-07-30 18:32:16', 0, 12),
	(8, 21, 7, 19, '[{"Id": 28, "Kgs": 432768, "Usd": 5600, "Name": "Honda accord III"}]', 15000, 0, '(USD)', 216, '2020-07-30 18:33:03', 0, 13),
	(9, 21, 8, 19, '', 150000, 0, '(KGS)', 216, '2020-07-30 18:34:07', 0, 12),
	(10, 21, 9, 16, '[{"Id": 29, "Kgs": 270480, "Usd": 3500, "Name": "Inspatye"}]', 5000, 0, '(USD)', 218, '2020-07-30 18:49:02', 0, 13),
	(11, 21, 10, 16, '', 13000, 0, '(KGS)', 218, '2020-07-30 18:50:17', 0, 12),
	(12, 21, 11, 16, '', 5600, 5600, '(USD)', 221, '2020-07-30 19:06:32', 0, 13),
	(13, 21, 3, 18, '', 5000, 5000, '(USD)', 242, '2020-08-05 20:30:45', 0, 12),
	(14, 21, 12, 18, '', 5000, 0, '(USD)', 248, '2020-08-09 15:39:04', 0, 0);
/*!40000 ALTER TABLE `parking` ENABLE KEYS */;

-- Дамп структуры для таблица u_system.phous
CREATE TABLE IF NOT EXISTS `phous` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `dom_id` int(11) DEFAULT NULL,
  `remov` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- Дамп данных таблицы u_system.phous: ~4 rows (приблизительно)
/*!40000 ALTER TABLE `phous` DISABLE KEYS */;
INSERT INTO `phous` (`id`, `name`, `dom_id`, `remov`) VALUES
	(1, '1-s', 21, 0),
	(2, '2-s', 21, 0),
	(3, 'Хоус1', 21, 0),
	(4, 'Хоус4', 21, 0);
/*!40000 ALTER TABLE `phous` ENABLE KEYS */;

-- Дамп структуры для таблица u_system.prihod
CREATE TABLE IF NOT EXISTS `prihod` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `operationU` mediumtext CHARACTER SET utf8,
  `organ` mediumtext CHARACTER SET utf8,
  `summa` double(22,0) DEFAULT NULL,
  `typev` char(50) DEFAULT NULL,
  `kurs` int(11) DEFAULT NULL,
  `data` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `sotrud` int(11) DEFAULT NULL,
  `remov` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

-- Дамп данных таблицы u_system.prihod: ~6 rows (приблизительно)
/*!40000 ALTER TABLE `prihod` DISABLE KEYS */;
INSERT INTO `prihod` (`id`, `operationU`, `organ`, `summa`, `typev`, `kurs`, `data`, `sotrud`, `remov`) VALUES
	(3, 'Темир', 'Албазбеков Аскар Даниярович', 5000, '(USD)', 193, '2020-08-24 11:49:42', 8, 0),
	(4, 'Темир', 'Албазбеков Аскар Даниярович', 55000, '(USD)', 198, '2020-08-24 11:55:30', 8, 0),
	(5, 'Арматура', 'Умаров Тилек Муталибович', 5500, '(USD)', 197, '2020-07-24 12:07:13', 8, 0),
	(6, 'Арматура', 'Албазбеков Аскар Даниярович', 5265, '(KGS)', 243, '2020-08-07 11:10:21', 13, 0),
	(7, 'Арматура', 'Асилов Залкар Аблатович', 5000, '(USD)', 244, '2020-08-07 11:15:34', 13, 0),
	(8, 'Арматура', 'Ош турак жай', 1500, '(USD)', 247, '2020-08-08 18:01:21', 13, 0);
/*!40000 ALTER TABLE `prihod` ENABLE KEYS */;

-- Дамп структуры для таблица u_system.prodbclass
CREATE TABLE IF NOT EXISTS `prodbclass` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `number_id` int(11) DEFAULT NULL,
  `client_id` int(11) DEFAULT NULL,
  `price` double DEFAULT NULL,
  `summ` double DEFAULT NULL,
  `typev` char(50) DEFAULT NULL,
  `kurs` int(11) DEFAULT NULL,
  `data` date DEFAULT NULL,
  `remov` int(11) DEFAULT '0',
  `emp` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- Дамп данных таблицы u_system.prodbclass: ~5 rows (приблизительно)
/*!40000 ALTER TABLE `prodbclass` DISABLE KEYS */;
INSERT INTO `prodbclass` (`id`, `number_id`, `client_id`, `price`, `summ`, `typev`, `kurs`, `data`, `remov`, `emp`) VALUES
	(2, 1, 16, 580, 44518.07, '(USD)', 192, '2020-08-03', 0, 12),
	(3, 1, 16, 580, 4336821.88, '(KGS)', 178, '2020-08-03', 13, 12),
	(4, 3, 18, 550, 42263.82, '(USD)', 238, '2020-08-03', 13, 13),
	(5, 3, 16, 880, 67622.1, '(USD)', 239, '2020-08-03', 0, 13);
/*!40000 ALTER TABLE `prodbclass` ENABLE KEYS */;

-- Дамп структуры для таблица u_system.prodphous
CREATE TABLE IF NOT EXISTS `prodphous` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `dom_id` int(11) DEFAULT NULL,
  `client_id` int(11) DEFAULT NULL,
  `phous_id` int(11) DEFAULT NULL,
  `cars_id` text,
  `contract` char(50) DEFAULT NULL,
  `price_kvm` double(22,0) DEFAULT '0',
  `itog_price` double(22,0) DEFAULT '0',
  `vznos` double(22,0) DEFAULT '0',
  `debu_za` double(22,0) DEFAULT '0',
  `typev` char(50) DEFAULT NULL,
  `kurs` double(22,0) DEFAULT NULL,
  `data_n` date DEFAULT NULL,
  `data_k` date DEFAULT NULL,
  `kvm` double(22,0) DEFAULT NULL,
  `remov` int(11) DEFAULT '0',
  `emp` int(11) DEFAULT '0',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.prodphous: ~1 rows (приблизительно)
/*!40000 ALTER TABLE `prodphous` DISABLE KEYS */;
INSERT INTO `prodphous` (`id`, `dom_id`, `client_id`, `phous_id`, `cars_id`, `contract`, `price_kvm`, `itog_price`, `vznos`, `debu_za`, `typev`, `kurs`, `data_n`, `data_k`, `kvm`, `remov`, `emp`) VALUES
	(35, 21, 17, 3, NULL, '120', 500, 35000, 5000, 30000, '(USD)', 197, NULL, NULL, 22, 0, 0),
	(36, 21, 17, 1, '[{"Id":28,"Name":"Honda accord III","Usd":5600.0,"Kgs":432768.0}]', '127', 750, 16500, 5600, 10900, '(USD)', 227, '2020-08-02', '2020-10-01', 22, 0, 8);
/*!40000 ALTER TABLE `prodphous` ENABLE KEYS */;

-- Дамп структуры для таблица u_system.product
CREATE TABLE IF NOT EXISTS `product` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` text,
  `price` decimal(10,0) DEFAULT NULL,
  `typev` char(50) DEFAULT NULL,
  `kurs` decimal(10,0) DEFAULT NULL,
  `remov` int(11) DEFAULT '0',
  `data` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.product: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` (`id`, `name`, `price`, `typev`, `kurs`, `remov`, `data`) VALUES
	(11, 'Темир', 350000, '(USD)', 183, 0, '2020-07-22 18:55:23');
/*!40000 ALTER TABLE `product` ENABLE KEYS */;

-- Дамп структуры для таблица u_system.prod_cars
CREATE TABLE IF NOT EXISTS `prod_cars` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cars_id` int(11) NOT NULL DEFAULT '0',
  `client_id` int(11) NOT NULL DEFAULT '0',
  `price` double NOT NULL DEFAULT '0',
  `typev` char(50) CHARACTER SET utf8 DEFAULT NULL,
  `curren_id` int(11) NOT NULL,
  `data` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `remov` int(11) NOT NULL DEFAULT '0',
  `employee_id` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- Дамп данных таблицы u_system.prod_cars: ~4 rows (приблизительно)
/*!40000 ALTER TABLE `prod_cars` DISABLE KEYS */;
INSERT INTO `prod_cars` (`id`, `cars_id`, `client_id`, `price`, `typev`, `curren_id`, `data`, `remov`, `employee_id`) VALUES
	(1, 30, 18, 500, '(USD)', 196, '2020-07-27 13:00:33', 0, 12),
	(2, 31, 18, 8500, '(USD)', 240, '2020-08-05 19:42:41', 0, 12),
	(3, 32, 19, 9000, '(USD)', 262, '2020-08-09 20:30:14', 0, 7),
	(4, 32, 19, 9000, '(USD)', 262, '2020-08-09 20:30:31', 0, 7);
/*!40000 ALTER TABLE `prod_cars` ENABLE KEYS */;

-- Дамп структуры для представление u_system.prod_cars_pred
-- Создание временной таблицы для обработки ошибок зависимостей представлений
CREATE TABLE `prod_cars_pred` (
	`id` INT(11) NOT NULL,
	`cars` VARCHAR(50) NULL COLLATE 'utf8_general_ci',
	`client` VARCHAR(50) NULL COLLATE 'utf8_general_ci',
	`to_usd` DOUBLE(22,0) NULL,
	`Rto_kgs` DOUBLE(22,0) NULL,
	`data` TIMESTAMP NOT NULL,
	`name` VARCHAR(50) NULL COLLATE 'utf8mb4_general_ci'
) ENGINE=MyISAM;

-- Дамп структуры для таблица u_system.prod_parking
CREATE TABLE IF NOT EXISTS `prod_parking` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `dom_id` int(11) DEFAULT NULL,
  `klient_id` int(11) DEFAULT NULL,
  `number_f` int(11) DEFAULT NULL,
  `cars_id` mediumtext,
  `contract` mediumtext,
  `price` double(22,0) DEFAULT '0',
  `vznos` double(22,0) DEFAULT '0',
  `cars_summ` double(22,0) DEFAULT '0',
  `debu_za` double(22,0) DEFAULT '0',
  `typev` char(50) DEFAULT NULL,
  `kurs` double(22,0) DEFAULT NULL,
  `data_n` date DEFAULT NULL,
  `data_k` date DEFAULT NULL,
  `data` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `remov` int(11) DEFAULT '0',
  `emp` int(11) DEFAULT '0',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.prod_parking: ~4 rows (приблизительно)
/*!40000 ALTER TABLE `prod_parking` DISABLE KEYS */;
INSERT INTO `prod_parking` (`id`, `dom_id`, `klient_id`, `number_f`, `cars_id`, `contract`, `price`, `vznos`, `cars_summ`, `debu_za`, `typev`, `kurs`, `data_n`, `data_k`, `data`, `remov`, `emp`) VALUES
	(36, 21, 17, 16, '', '128', 0, 0, 0, 40645, '(USD)', 249, '2020-08-09', '2021-01-01', '2020-08-09 16:24:14', 0, 12),
	(38, 21, 17, 13, '', '124', 7000, 3500, 0, 3500, '(USD)', 255, '2020-08-09', '2020-12-01', '2020-08-09 17:49:42', 0, 12),
	(39, 21, 17, 1, '[{"Id":29,"Name":"Inspatye","Usd":3500.0,"Kgs":270480.0}]', '126', 5000, 3500, 3500, 1500, '(USD)', 257, '2020-08-09', '2021-03-01', '2020-08-09 18:05:57', 0, 13),
	(40, 21, 18, 3, '', '129', 5000, 3000, 0, 2000, '(USD)', 258, '2020-08-09', '2021-07-01', '2020-08-09 20:21:10', 0, 12);
/*!40000 ALTER TABLE `prod_parking` ENABLE KEYS */;

-- Дамп структуры для таблица u_system.rashod
CREATE TABLE IF NOT EXISTS `rashod` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `operationU` mediumtext CHARACTER SET utf8,
  `organ` mediumtext CHARACTER SET utf8,
  `summa` double(22,0) DEFAULT NULL,
  `typev` char(50) DEFAULT NULL,
  `kurs` int(11) DEFAULT NULL,
  `data` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `sotrud` int(11) DEFAULT NULL,
  `remov` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

-- Дамп данных таблицы u_system.rashod: ~2 rows (приблизительно)
/*!40000 ALTER TABLE `rashod` DISABLE KEYS */;
INSERT INTO `rashod` (`id`, `operationU`, `organ`, `summa`, `typev`, `kurs`, `data`, `sotrud`, `remov`) VALUES
	(1, NULL, NULL, NULL, NULL, NULL, '2020-08-07 11:19:36', NULL, 0),
	(8, 'Темир', 'Асилов Залкар Аблатович', 5500, '(USD)', 245, '2020-08-07 11:20:14', 13, 0),
	(9, 'Темир', 'Калмаматов Баймат Калмаматович', 550, '(USD)', 246, '2020-08-07 11:32:47', 13, 0);
/*!40000 ALTER TABLE `rashod` ENABLE KEYS */;

-- Дамп структуры для таблица u_system.redemption
CREATE TABLE IF NOT EXISTS `redemption` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `client_id` int(11) DEFAULT NULL,
  `summa` int(11) DEFAULT NULL,
  `data` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.redemption: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `redemption` DISABLE KEYS */;
/*!40000 ALTER TABLE `redemption` ENABLE KEYS */;

-- Дамп структуры для таблица u_system.repayment
CREATE TABLE IF NOT EXISTS `repayment` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `dom_id` int(11) NOT NULL DEFAULT '0',
  `number_f` int(11) NOT NULL DEFAULT '0',
  `client_id` int(11) DEFAULT NULL,
  `summa` double DEFAULT NULL,
  `usd` double DEFAULT NULL,
  `data_month` date DEFAULT NULL,
  `data` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `remov` int(11) DEFAULT '0',
  `emp` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.repayment: ~8 rows (приблизительно)
/*!40000 ALTER TABLE `repayment` DISABLE KEYS */;
INSERT INTO `repayment` (`id`, `dom_id`, `number_f`, `client_id`, `summa`, `usd`, `data_month`, `data`, `remov`, `emp`) VALUES
	(1, 21, 7, 17, 1314, 100763, '2020-07-31', '2020-07-31 13:44:58', 0, 0),
	(2, 21, 10, 17, 1797, 137833, '2020-08-01', '2020-07-31 13:46:49', 0, 0),
	(3, 21, 10, 17, 500, 1000, '2020-08-01', '2020-07-31 13:47:29', 0, 0),
	(4, 21, 10, 17, 500, 1000, '2020-08-01', '2020-07-31 13:47:54', 0, 0),
	(5, 21, 10, 17, 1797, 137833, '2020-06-01', '2020-07-31 13:49:14', 0, 0),
	(6, 21, 10, 17, 13733, 1797, '2020-07-01', '2020-07-31 13:49:57', 0, 0),
	(7, 21, 15, 15, 406450, 3125677.73, '2020-08-05', '2020-08-05 20:26:30', 0, 0),
	(8, 21, 10, 17, 1797, 137833, '2020-10-01', '2020-08-09 20:34:27', 0, 0),
	(9, 21, 10, 17, 1500, 130000, '2022-05-01', '2020-08-09 20:36:52', 0, 0);
/*!40000 ALTER TABLE `repayment` ENABLE KEYS */;

-- Дамп структуры для таблица u_system.repayment_parking
CREATE TABLE IF NOT EXISTS `repayment_parking` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `dom_id` int(11) NOT NULL DEFAULT '0',
  `number_f` int(11) NOT NULL DEFAULT '0',
  `client_id` int(11) DEFAULT NULL,
  `summa` double(22,0) DEFAULT NULL,
  `usd` double(22,0) DEFAULT NULL,
  `data_month` date DEFAULT NULL,
  `data` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `remov` int(11) DEFAULT '0',
  `emp` int(11) DEFAULT '0',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.repayment_parking: ~2 rows (приблизительно)
/*!40000 ALTER TABLE `repayment_parking` DISABLE KEYS */;
INSERT INTO `repayment_parking` (`id`, `dom_id`, `number_f`, `client_id`, `summa`, `usd`, `data_month`, `data`, `remov`, `emp`) VALUES
	(8, 21, 13, 13, 78000, 1000, '2020-08-09', '2020-08-09 19:38:52', 0, 12),
	(9, 21, 1, 13, 78000, 1000, '2020-08-09', '2020-08-10 12:02:01', 0, 13);
/*!40000 ALTER TABLE `repayment_parking` ENABLE KEYS */;

-- Дамп структуры для таблица u_system.reppar
CREATE TABLE IF NOT EXISTS `reppar` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `dom_id` int(11) NOT NULL DEFAULT '0',
  `number_p` int(11) NOT NULL DEFAULT '0',
  `client_id` int(11) DEFAULT NULL,
  `summa` double(22,0) DEFAULT NULL,
  `usd` double(22,0) DEFAULT NULL,
  `data_month` date DEFAULT NULL,
  `data` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `remov` int(11) DEFAULT '0',
  `emp` int(11) DEFAULT '0',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.reppar: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `reppar` DISABLE KEYS */;
/*!40000 ALTER TABLE `reppar` ENABLE KEYS */;

-- Дамп структуры для таблица u_system.roles
CREATE TABLE IF NOT EXISTS `roles` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(50) DEFAULT NULL,
  `name_p` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4;

-- Дамп данных таблицы u_system.roles: ~4 rows (приблизительно)
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` (`id`, `name`, `name_p`) VALUES
	(5, 'director', 'Директор'),
	(6, 'admin', 'Администратор'),
	(7, 'manager', 'Менеджер'),
	(8, 'accountant', 'Бухгалтер');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;

-- Дамп структуры для таблица u_system.typephous
CREATE TABLE IF NOT EXISTS `typephous` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `phous_id` int(11) DEFAULT NULL,
  `name` mediumtext CHARACTER SET utf8,
  `m2` double DEFAULT NULL,
  `remov` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Дамп данных таблицы u_system.typephous: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `typephous` DISABLE KEYS */;
INSERT INTO `typephous` (`id`, `phous_id`, `name`, `m2`, `remov`) VALUES
	(1, 1, 'Кухня', 22, 0);
/*!40000 ALTER TABLE `typephous` ENABLE KEYS */;

-- Дамп структуры для таблица u_system.type_flat
CREATE TABLE IF NOT EXISTS `type_flat` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `dom_id` int(11) DEFAULT NULL,
  `porch` int(11) DEFAULT NULL,
  `room` int(11) DEFAULT NULL,
  `type` varchar(50) DEFAULT NULL,
  `name` varchar(50) DEFAULT NULL,
  `kvm` double DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.type_flat: ~14 rows (приблизительно)
/*!40000 ALTER TABLE `type_flat` DISABLE KEYS */;
INSERT INTO `type_flat` (`id`, `dom_id`, `porch`, `room`, `type`, `name`, `kvm`) VALUES
	(15, 21, 1, 1, '1-тип', 'Кухня ', 12.5),
	(16, 21, 1, 1, '1-тип', 'Балкон ', 13.2),
	(17, 21, 1, 1, '1-тип', 'Спальня ', 18.3),
	(18, 21, 1, 1, '1-тип', 'Хол', 18.2),
	(19, 21, 1, 1, '1-тип', 'Санузел ', 11.7),
	(20, 21, 2, 2, '1-тип', 'Кухня ', 18.6),
	(21, 21, 2, 2, '1-тип', 'Балкон ', 11.4),
	(22, 21, 2, 2, '1-тип', 'Спальня ', 18.6),
	(23, 21, 2, 2, '1-тип', 'Спальня', 17.2),
	(24, 21, 2, 2, '1-тип', 'Хол', 16.3),
	(25, 21, 2, 2, '1-тип', 'Санузел ', 12.9),
	(26, 21, 1, 1, '2-тип', 'Кухня ', 12.6),
	(27, 21, 1, 1, '2-тип', 'Балкон ', 18.3),
	(28, 21, 1, 1, '2-тип', 'Спальня ', 14.6),
	(29, 22, 1, 2, '3-тип', 'кухня', 12.5),
	(30, 22, 1, 2, '3-тип', 'ванна', 12.6);
/*!40000 ALTER TABLE `type_flat` ENABLE KEYS */;

-- Дамп структуры для таблица u_system.users
CREATE TABLE IF NOT EXISTS `users` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(50) DEFAULT NULL,
  `rol` varchar(50) DEFAULT NULL,
  `login` varchar(50) DEFAULT NULL,
  `parol` text,
  `data_r` varchar(50) DEFAULT NULL,
  `tel_nom` varchar(50) DEFAULT NULL,
  `addres` text,
  `an` varchar(50) DEFAULT NULL,
  `data_p` varchar(50) DEFAULT NULL,
  `vdan` varchar(50) DEFAULT NULL,
  `address_p` text,
  `remov` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4;

-- Дамп данных таблицы u_system.users: ~2 rows (приблизительно)
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` (`id`, `name`, `rol`, `login`, `parol`, `data_r`, `tel_nom`, `addres`, `an`, `data_p`, `vdan`, `address_p`, `remov`) VALUES
	(12, 'Асанов Самат', 'admin', 'samat', 'AKzi5bS+rBiT2HOrAjGikggGWCHNyd6UW9Oeh3Z7QabzuWXft72D3g1rr3F2K45CxA==', '17.07.2020', '0777 48 08 68', 'Ош шаары', 'АН266 45 56', '09.07.2020', 'МКК-55 43', 'КараСуу району', 0),
	(13, 'Касымбеков Арген', 'director', 'Admin', 'AIshTV7Qly9ClMklxqP684rX7RKlf+JVDo5/3bAtb+JU1+I3tcn8w1SO1hYhzx7xMg==', '22.07.2020', '0777 48 00 45', 'Ош шаары', 'AN 255 12 12', '15.07.2020', 'МКК-55 40', 'Ноокен', 0);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;

-- Дамп структуры для таблица u_system.user_roles
CREATE TABLE IF NOT EXISTS `user_roles` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `user_id` int(10) unsigned DEFAULT NULL,
  `role_id` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_user_roles_users` (`user_id`),
  KEY `FK_user_roles_roles` (`role_id`),
  CONSTRAINT `FK_user_roles_roles` FOREIGN KEY (`role_id`) REFERENCES `roles` (`id`),
  CONSTRAINT `FK_user_roles_users` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Дамп данных таблицы u_system.user_roles: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `user_roles` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_roles` ENABLE KEYS */;

-- Дамп структуры для таблица u_system.zakaz
CREATE TABLE IF NOT EXISTS `zakaz` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `dom_id` int(11) DEFAULT NULL,
  `klient_id` int(11) DEFAULT NULL,
  `number_f` int(11) DEFAULT NULL,
  `cars_id` text,
  `contract` text,
  `price_kvm` double DEFAULT '0',
  `itog_price` double DEFAULT '0',
  `vznos` double DEFAULT '0',
  `cars_summ` double(22,0) DEFAULT '0',
  `debu_za` double DEFAULT '0',
  `typev` char(50) DEFAULT NULL,
  `kurs` double DEFAULT NULL,
  `data_n` date DEFAULT NULL,
  `data_k` date DEFAULT NULL,
  `data` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `kvm` double DEFAULT NULL,
  `remov` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.zakaz: ~11 rows (приблизительно)
/*!40000 ALTER TABLE `zakaz` DISABLE KEYS */;
INSERT INTO `zakaz` (`id`, `dom_id`, `klient_id`, `number_f`, `cars_id`, `contract`, `price_kvm`, `itog_price`, `vznos`, `cars_summ`, `debu_za`, `typev`, `kurs`, `data_n`, `data_k`, `data`, `kvm`, `remov`) VALUES
	(23, 21, 15, 4, '[{"Id": 29, "Kgs": 52, "Usd": 0.67, "Name": "Inspatye"}, {"Id": 28, "Kgs": 432768, "Usd": 5600, "Name": "Honda accord III"}]', '124', 500, 36950, 3500, 0, 33450, '(USD)', 178, '2020-07-20', '2022-07-20', '2020-08-05 19:45:49', 73.9, 0),
	(24, 21, 16, 5, '[{"Id": 29, "Kgs": 52, "Usd": 0.67, "Name": "Inspatye"}, {"Id": 28, "Kgs": 432768, "Usd": 5600, "Name": "Honda accord III"}]', '127', 550, 40645, 13600.67, 0, 27044.33, '(USD)', 184, '2020-07-23', '2022-07-23', '2020-08-05 19:45:49', 73.9, 8),
	(25, 21, 17, 7, '[{"Id": 28, "Kgs": 432768, "Usd": 5600, "Name": "Honda accord III"}, {"Id": 31, "Kgs": 630000, "Usd": 8152.17, "Name": "Inspatye3"}]', '126', 550, 40645, 9100.67, 0, 31544.33, '(USD)', 193, '2020-07-26', '2022-07-26', '2020-08-05 19:45:49', 73.9, 8),
	(27, 21, 17, 10, '[{"Id": 29, "Kgs": 52, "Usd": 0.67, "Name": "Inspatye"}, {"Id": 28, "Kgs": 432768, "Usd": 5600, "Name": "Honda accord III"}]', '126', 550, 52250, 9100.67, 0, 43149.33, '(USD)', 193, '2020-07-26', '2022-07-26', '2020-08-05 19:45:49', 95, 0),
	(28, 21, 17, 9, '[{"Id": 28, "Kgs": 432768, "Usd": 5600, "Name": "Honda accord III"}]', '129', 550, 52250, 11100, 0, 41150, '(USD)', 194, '2020-07-26', '2021-02-01', '2020-08-05 19:45:49', 95, 0),
	(30, 21, 17, 5, '', '122', 500, 36950, 9100, 0, 27850, '(USD)', 199, '2020-07-28', '2022-07-28', '2020-08-05 19:45:49', 73.9, 0),
	(31, 21, 17, 11, '[{"Id": 31, "Kgs": 630000, "Usd": 8152.17, "Name": "Inspatye3"}, {"Id": 29, "Kgs": 270480, "Usd": 3500, "Name": "Inspatye"}, {"Id": 28, "Kgs": 432768, "Usd": 5600, "Name": "Honda accord III"}]', '122', 500, 36950, 17252.17, 0, 19697.83, '(USD)', 200, '2020-07-28', '2020-07-28', '2020-08-05 19:45:49', 73.9, 0),
	(32, 21, 18, 12, '[{"Id": 28, "Kgs": 432768, "Usd": 5600, "Name": "Honda accord III"}]', '124', 500, 47500, 8600, 0, 38900, '(USD)', 201, '2020-07-30', '2020-07-30', '2020-08-05 19:45:49', 95, 0),
	(33, 21, 16, 13, '', '136', 500, 36950, 3000, 0, 33950, '(USD)', 220, '2020-07-30', '2020-07-30', '2020-08-05 19:45:49', 73.9, 0),
	(34, 21, 16, 6, '[{"Id":29,"Name":"Inspatye","Usd":3500.0,"Kgs":270480.0}]', '141', 500, 47500, 3500, 0, 44000, '(USD)', 223, '2020-08-01', '2022-08-01', '2020-08-05 19:45:49', 95, 0),
	(35, 21, 15, 15, '', '123', 550, 40645, 0, 0, 40645, '(USD)', 241, '2020-08-05', '2020-10-01', '2020-08-05 20:24:25', 73.9, 0),
	(36, 21, 18, 18, '[{"Id":32,"Name":"BMW x6","Usd":8900.0,"Kgs":685745.0}]', '165', 519.14, 38364.7, 3244.65, 0, 26220.05, '(USD)', 261, '2020-08-09', '2023-08-09', '2020-08-09 20:29:13', 73.9, 7);
/*!40000 ALTER TABLE `zakaz` ENABLE KEYS */;

-- Дамп структуры для представление u_system._graf_parking
-- Создание временной таблицы для обработки ошибок зависимостей представлений
CREATE TABLE `_graf_parking` (
	`id` INT(11) NOT NULL,
	`to_usd` DOUBLE(22,2) NULL,
	`Rto_kgs` DOUBLE(22,2) NULL,
	`vznosu` DOUBLE(22,2) NULL,
	`vznosk` DOUBLE(22,2) NULL,
	`debu` DOUBLE(22,2) NULL,
	`debk` DOUBLE(22,2) NULL,
	`cars_usd` DOUBLE(22,2) NULL,
	`cars_kgs` DOUBLE(22,2) NULL,
	`CountData` BIGINT(21) NULL,
	`d1` INT(2) NULL,
	`m1` INT(2) NULL,
	`y1` INT(4) NULL,
	`d2` INT(2) NULL,
	`m2` INT(2) NULL,
	`y2` INT(4) NULL
) ENGINE=MyISAM;

-- Дамп структуры для представление u_system._otchet_bclass
-- Создание временной таблицы для обработки ошибок зависимостей представлений
CREATE TABLE `_otchet_bclass` (
	`id` INT(11) NOT NULL,
	`dom` MEDIUMTEXT NULL COLLATE 'utf8_general_ci',
	`name` MEDIUMTEXT NULL COLLATE 'utf8_general_ci',
	`contragent` VARCHAR(50) NULL COLLATE 'utf8_general_ci',
	`usd` DOUBLE(22,0) NULL,
	`kgs` DOUBLE(22,0) NULL,
	`data` DATE NULL,
	`emp` VARCHAR(50) NULL COLLATE 'utf8mb4_general_ci'
) ENGINE=MyISAM;

-- Дамп структуры для представление u_system._prod_parking
-- Создание временной таблицы для обработки ошибок зависимостей представлений
CREATE TABLE `_prod_parking` (
	`id` INT(11) NOT NULL,
	`number_f` INT(11) NULL,
	`name` VARCHAR(50) NULL COLLATE 'utf8_general_ci',
	`usd` DOUBLE(22,2) NULL,
	`kgs` DOUBLE(22,2) NULL,
	`d_usd` DOUBLE(19,2) NULL,
	`d_kgs` DOUBLE(22,2) NULL,
	`data_n` DATE NULL,
	`data_k` DATE NULL,
	`dom_id` INT(11) NULL,
	`klient_id` INT(11) NULL,
	`cars_id` MEDIUMTEXT NULL COLLATE 'utf8_general_ci',
	`cars1` VARCHAR(5) NOT NULL COLLATE 'utf8mb4_general_ci',
	`emp` VARCHAR(50) NULL COLLATE 'utf8mb4_general_ci'
) ENGINE=MyISAM;

-- Дамп структуры для представление u_system.analis_cars
-- Удаление временной таблицы и создание окончательной структуры представления
DROP TABLE IF EXISTS `analis_cars`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `analis_cars` AS select `c`.`id` AS `id`,`cl`.`name` AS `name`,`c`.`marka` AS `marka`,`c`.`data` AS `data`,if((`c`.`type_v` = '(KGS)'),round((`c`.`prih_summ` / (select `cur`.`usd` from `currency` `cur` where (`cur`.`id` = `c`.`kurs`))),2),`c`.`prih_summ`) AS `A1`,if((`c`.`type_v` = '(USD)'),round((`c`.`prih_summ` * (select `cur`.`usd` from `currency` `cur` where (`cur`.`id` = `c`.`kurs`))),2),`c`.`prih_summ`) AS `A2`,if((`p`.`typev` = '(KGS)'),round((`p`.`price` / (select `cur`.`usd` from `currency` `cur` where (`cur`.`id` = `p`.`curren_id`))),2),`p`.`price`) AS `B1`,if((`p`.`typev` = '(USD)'),round((`p`.`price` * (select `cur`.`usd` from `currency` `cur` where (`cur`.`id` = `p`.`curren_id`))),2),`p`.`price`) AS `B2` from ((`cars` `c` join `client` `cl` on((`c`.`client_id` = `cl`.`id`))) left join `prod_cars` `p` on((`c`.`id` = `p`.`cars_id`))) order by `c`.`id`;

-- Дамп структуры для представление u_system.bron_pres
-- Удаление временной таблицы и создание окончательной структуры представления
DROP TABLE IF EXISTS `bron_pres`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `bron_pres` AS select `b`.`id` AS `id`,`b`.`number_f` AS `number_f`,(select `client`.`name` from `client` where (`client`.`id` = `b`.`client_id`)) AS `client`,if((`b`.`typev` = '(KGS)'),round((`b`.`price_kv` / `cur`.`usd`),2),`b`.`price_kv`) AS `to_usd`,if((`b`.`typev` = '(USD)'),round((`b`.`price_kv` * `cur`.`usd`),2),`b`.`price_kv`) AS `Rto_kgs`,`b`.`data` AS `data`,`u`.`name` AS `name`,`b`.`dom_id` AS `dom_id` from ((`bron` `b` join `currency` `cur`) join `users` `u` on(((`b`.`kurs` = `cur`.`id`) and (`b`.`sotrudnic_id` = `u`.`id`)))) where (`b`.`remov` = '0') order by `b`.`id` desc;

-- Дамп структуры для представление u_system.carsid
-- Удаление временной таблицы и создание окончательной структуры представления
DROP TABLE IF EXISTS `carsid`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `carsid` AS select `c`.`id` AS `id`,`c`.`marka` AS `marka`,`c`.`data` AS `data`,`c`.`nomer` AS `nomer`,`c`.`condition_c` AS `condition_c`,(select `client`.`name` from `client` where (`client`.`id` = `c`.`client_id`)) AS `client`,`c`.`datatim` AS `datatim`,if((`c`.`type_v` = '(KGS)'),round((`c`.`prih_summ` / `cur`.`usd`),2),`c`.`prih_summ`) AS `to_usd`,if((`c`.`type_v` = '(USD)'),round((`c`.`prih_summ` * `cur`.`usd`),2),`c`.`prih_summ`) AS `Rto_kgs`,`c`.`kurs` AS `kurs` from (`cars` `c` join `currency` `cur` on((`c`.`kurs` = `cur`.`id`)));

-- Дамп структуры для представление u_system.display
-- Удаление временной таблицы и создание окончательной структуры представления
DROP TABLE IF EXISTS `display`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `display` AS select `f`.`remov` AS `remov`,`z`.`id` AS `Zid`,`f`.`id` AS `id`,`f`.`number_f` AS `number_f`,`f`.`floor` AS `floor`,`f`.`porch` AS `porch`,(select sum(`type_flat`.`kvm`) from `type_flat` where ((`type_flat`.`dom_id` = `f`.`dom_id`) and (`type_flat`.`porch` = `f`.`porch`) and (`type_flat`.`type` = `f`.`type_flat`) and (`type_flat`.`room` = `f`.`room`))) AS `kvm`,`z`.`contract` AS `contract`,(case when ((select `b`.`id` from `bron` `b` where ((`b`.`dom_id` = `f`.`dom_id`) and (`b`.`number_f` = `f`.`number_f`) and (`b`.`remov` = 0))) > 0) then 'Бранированный' when ((select `e`.`id` from `exchange` `e` where ((`e`.`dom_id` = `f`.`dom_id`) and (`e`.`number_f` = `f`.`number_f`) and (`e`.`remov` = 0))) > 0) then 'Обмен' else (select `c`.`name` from `client` `c` where (`c`.`id` = `z`.`klient_id`)) end) AS `client`,if((`z`.`cars_id` <> ''),'Имеиит','') AS `Cars`,if((`z`.`typev` = '(KGS)'),round((`z`.`price_kvm` / `cur`.`usd`),2),`z`.`price_kvm`) AS `to_usd`,if((`z`.`typev` = '(USD)'),round((`z`.`price_kvm` * `cur`.`usd`),2),`z`.`price_kvm`) AS `Rto_kgs`,`z`.`data_n` AS `data_n`,`z`.`data_k` AS `data_k`,`z`.`klient_id` AS `klient_id`,`z`.`cars_id` AS `cars_id`,`f`.`dom_id` AS `dom_id` from (`flat` `f` left join (`zakaz` `z` join `currency` `cur`) on(((`f`.`dom_id` = `z`.`dom_id`) and (`f`.`number_f` = `z`.`number_f`) and (`z`.`kurs` = `cur`.`id`) and (`z`.`remov` = 0)))) order by `f`.`number_f`;

-- Дамп структуры для представление u_system.displayzakaz
-- Удаление временной таблицы и создание окончательной структуры представления
DROP TABLE IF EXISTS `displayzakaz`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `displayzakaz` AS select `dom`.`name` AS `Названия комплекс`,`client`.`name` AS `Клиент`,`flat`.`number_f` AS `Номер квартира`,`cars`.`marka` AS `Марка машина`,`zakaz`.`price_kvm` AS `Сумма`,`zakaz`.`kurs` AS `Курс валюта` from ((((`zakaz` join `dom`) join `flat`) join `client`) join `cars`) where ((`zakaz`.`dom_id` = `dom`.`id`) and (`zakaz`.`klient_id` = `client`.`id`) and (`zakaz`.`number_f` = `flat`.`number_f`) and (`zakaz`.`cars_id` = `cars`.`id`));

-- Дамп структуры для представление u_system.dysplayaddbuild
-- Удаление временной таблицы и создание окончательной структуры представления
DROP TABLE IF EXISTS `dysplayaddbuild`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `dysplayaddbuild` AS select `z`.`id` AS `id`,`f`.`number_f` AS `number_f`,`f`.`floor` AS `floor`,`f`.`porch` AS `porch`,(select sum(`type_flat`.`kvm`) from `type_flat` where ((`type_flat`.`dom_id` = `f`.`dom_id`) and (`type_flat`.`porch` = `f`.`porch`) and (`type_flat`.`type` = `f`.`type_flat`) and (`type_flat`.`room` = `f`.`room`))) AS `kvm`,`z`.`contract` AS `contract`,(select `client`.`name` from `client` where (`client`.`id` = `z`.`klient_id`)) AS `client`,(select `cars`.`marka` from `cars` where (`z`.`cars_id` = `cars`.`id`)) AS `Cars`,if((`z`.`typev` = '(KGS)'),round((`z`.`price_kvm` / `cur`.`usd`),2),`z`.`price_kvm`) AS `to_usd`,if((`z`.`typev` = '(USD)'),round((`z`.`price_kvm` * `cur`.`usd`),2),`z`.`price_kvm`) AS `Rto_kgs`,`z`.`data_n` AS `data_n`,`z`.`data_k` AS `data_k`,`z`.`klient_id` AS `klient_id`,`z`.`cars_id` AS `cars_id`,`f`.`dom_id` AS `dom_id` from (`flat` `f` join (`zakaz` `z` join `currency` `cur`) on(((`f`.`dom_id` = `z`.`dom_id`) and (`f`.`number_f` = `z`.`number_f`) and (`z`.`kurs` = `cur`.`id`) and (`z`.`remov` = '0')))) order by `f`.`number_f`;

-- Дамп структуры для представление u_system.grafplat
-- Удаление временной таблицы и создание окончательной структуры представления
DROP TABLE IF EXISTS `grafplat`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `grafplat` AS select `z`.`id` AS `id`,if((`z`.`typev` = '(KGS)'),round((`z`.`price_kvm` / `cur`.`usd`),2),`z`.`price_kvm`) AS `to_usd`,if((`z`.`typev` = '(USD)'),round((`z`.`price_kvm` * `cur`.`usd`),2),`z`.`price_kvm`) AS `Rto_kgs`,if((`z`.`typev` = '(KGS)'),round((`z`.`itog_price` / `cur`.`usd`),2),`z`.`itog_price`) AS `itogu`,if((`z`.`typev` = '(USD)'),round((`z`.`itog_price` * `cur`.`usd`),2),`z`.`itog_price`) AS `itogk`,if((`z`.`typev` = '(KGS)'),round((`z`.`vznos` / `cur`.`usd`),2),`z`.`vznos`) AS `vznosu`,if((`z`.`typev` = '(USD)'),round((`z`.`vznos` * `cur`.`usd`),2),`z`.`vznos`) AS `vznosk`,if((`z`.`typev` = '(KGS)'),round((`z`.`debu_za` / `cur`.`usd`),2),`z`.`debu_za`) AS `debu`,if((`z`.`typev` = '(USD)'),round((`z`.`debu_za` * `cur`.`usd`),2),`z`.`debu_za`) AS `debk`,timestampdiff(MONTH,`z`.`data_n`,`z`.`data_k`) AS `CountData`,dayofmonth(`z`.`data_n`) AS `d1`,month(`z`.`data_n`) AS `m1`,year(`z`.`data_n`) AS `y1`,dayofmonth(`z`.`data_k`) AS `d2`,month(`z`.`data_k`) AS `m2`,year(`z`.`data_k`) AS `y2` from (`zakaz` `z` join `currency` `cur` on((`z`.`kurs` = `cur`.`id`)));

-- Дамп структуры для представление u_system.otchetprihod
-- Удаление временной таблицы и создание окончательной структуры представления
DROP TABLE IF EXISTS `otchetprihod`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `otchetprihod` AS select 'prodbclass' AS `tabl`,'Проджа бизнес класс' AS `class`,if((`p`.`typev` = '(KGS)'),round((`p`.`summ` / `cur`.`usd`),2),`p`.`summ`) AS `to_usd`,if((`p`.`typev` = '(USD)'),round((`p`.`summ` * `cur`.`usd`),2),`p`.`summ`) AS `Rto_kgs`,`p`.`data` AS `data` from (`prodbclass` `p` join `currency` `cur` on(((`p`.`kurs` = `cur`.`id`) and (`p`.`summ` > 0) and (`p`.`remov` = '0') and (month(`p`.`data`) = month(now())) and (year(`p`.`data`) = year(now()))))) union select 'prod_cars' AS `tabl`,'Продажа машина' AS `class`,if((`pr`.`typev` = '(KGS)'),round((`pr`.`price` / `cur`.`usd`),2),`pr`.`price`) AS `to_usd`,if((`pr`.`typev` = '(USD)'),round((`pr`.`price` * `cur`.`usd`),2),`pr`.`price`) AS `Rto_kgs`,`pr`.`data` AS `data` from (`prod_cars` `pr` join `currency` `cur` on(((`pr`.`curren_id` = `cur`.`id`) and (`pr`.`price` > 0) and (`pr`.`remov` = '0') and (month(`pr`.`data`) = month(now())) and (year(`pr`.`data`) = year(now()))))) union select 'parking' AS `tabl`,'Парковка' AS `class`,if((`par`.`typev` = '(KGS)'),round((`par`.`zadol` / `cur`.`usd`),2),`par`.`zadol`) AS `to_usd`,if((`par`.`typev` = '(USD)'),round((`par`.`zadol` * `cur`.`usd`),2),`par`.`zadol`) AS `Rto_kgs`,`par`.`data` AS `data` from (`parking` `par` join `currency` `cur` on(((`par`.`curr_id` = `cur`.`id`) and (`par`.`zadol` > 0) and (`par`.`remov` = '0') and (month(`par`.`data`) = month(now())) and (year(`par`.`data`) = year(now()))))) union select 'repayment' AS `tabl`,'Платеж дом' AS `class`,`r`.`summa` AS `summa`,`r`.`usd` AS `usd`,`r`.`data` AS `data` from `repayment` `r` where ((`r`.`remov` = '0') and (month(`r`.`data`) = month(now())) and (year(`r`.`data`) = year(now()))) union select 'prihod' AS `tabl`,'Наличный' AS `class`,if((`pri`.`typev` = '(KGS)'),round((`pri`.`summa` / `cur`.`usd`),2),`pri`.`summa`) AS `to_usd`,if((`pri`.`typev` = '(USD)'),round((`pri`.`summa` * `cur`.`usd`),2),`pri`.`summa`) AS `Rto_kgs`,`pri`.`data` AS `data` from (`prihod` `pri` join `currency` `cur` on(((`pri`.`kurs` = `cur`.`id`) and (`pri`.`summa` > 0) and (`pri`.`remov` = '0') and (month(`pri`.`data`) = month(now())) and (year(`pri`.`data`) = year(now())))));

-- Дамп структуры для представление u_system.prod_cars_pred
-- Удаление временной таблицы и создание окончательной структуры представления
DROP TABLE IF EXISTS `prod_cars_pred`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `prod_cars_pred` AS select `p`.`id` AS `id`,(select `cars`.`marka` from `cars` where (`cars`.`id` = `p`.`cars_id`)) AS `cars`,(select `client`.`name` from `client` where (`client`.`id` = `p`.`client_id`)) AS `client`,if((`p`.`typev` = '(KGS)'),round((`p`.`price` / `cur`.`usd`),2),`p`.`price`) AS `to_usd`,if((`p`.`typev` = '(USD)'),round((`p`.`price` * `cur`.`usd`),2),`p`.`price`) AS `Rto_kgs`,`p`.`data` AS `data`,`u`.`name` AS `name` from ((`prod_cars` `p` join `currency` `cur`) join `users` `u` on(((`p`.`curren_id` = `cur`.`id`) and (`p`.`employee_id` = `u`.`id`)))) where (`p`.`remov` = '0') order by `p`.`id` desc;

-- Дамп структуры для представление u_system._graf_parking
-- Удаление временной таблицы и создание окончательной структуры представления
DROP TABLE IF EXISTS `_graf_parking`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `_graf_parking` AS select `z`.`id` AS `id`,if((`z`.`typev` = '(KGS)'),round((`z`.`price` / `cur`.`usd`),2),`z`.`price`) AS `to_usd`,if((`z`.`typev` = '(USD)'),round((`z`.`price` * `cur`.`usd`),2),`z`.`price`) AS `Rto_kgs`,if((`z`.`typev` = '(KGS)'),round((`z`.`vznos` / `cur`.`usd`),2),`z`.`vznos`) AS `vznosu`,if((`z`.`typev` = '(USD)'),round((`z`.`vznos` * `cur`.`usd`),2),`z`.`vznos`) AS `vznosk`,if((`z`.`typev` = '(KGS)'),round((`z`.`debu_za` / `cur`.`usd`),2),`z`.`debu_za`) AS `debu`,if((`z`.`typev` = '(USD)'),round((`z`.`debu_za` * `cur`.`usd`),2),`z`.`debu_za`) AS `debk`,if((`z`.`typev` = '(KGS)'),round((`z`.`cars_summ` / `cur`.`usd`),2),`z`.`cars_summ`) AS `cars_usd`,if((`z`.`typev` = '(USD)'),round((`z`.`cars_summ` * `cur`.`usd`),2),`z`.`cars_summ`) AS `cars_kgs`,timestampdiff(MONTH,`z`.`data_n`,`z`.`data_k`) AS `CountData`,dayofmonth(`z`.`data_n`) AS `d1`,month(`z`.`data_n`) AS `m1`,year(`z`.`data_n`) AS `y1`,dayofmonth(`z`.`data_k`) AS `d2`,month(`z`.`data_k`) AS `m2`,year(`z`.`data_k`) AS `y2` from (`prod_parking` `z` join `currency` `cur` on((`z`.`kurs` = `cur`.`id`)));

-- Дамп структуры для представление u_system._otchet_bclass
-- Удаление временной таблицы и создание окончательной структуры представления
DROP TABLE IF EXISTS `_otchet_bclass`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `_otchet_bclass` AS select `p`.`id` AS `id`,(select `dom`.`name` from `dom` where (`b`.`dom_id` = `dom`.`id`)) AS `dom`,`b`.`name` AS `name`,(select `client`.`name` from `client` where (`client`.`id` = `p`.`client_id`)) AS `contragent`,if((`p`.`typev` = '(KGS)'),round((`p`.`summ` / `cur`.`usd`),2),`p`.`summ`) AS `usd`,if((`p`.`typev` = '(USD)'),round((`p`.`summ` * `cur`.`usd`),2),`p`.`summ`) AS `kgs`,`p`.`data` AS `data`,(select `users`.`name` from `users` where (`users`.`id` = `p`.`emp`)) AS `emp` from ((`prodbclass` `p` join `currency` `cur`) join `bisnesclass` `b` on(((`p`.`kurs` = `cur`.`id`) and (`p`.`summ` > 0) and (`p`.`remov` = '0') and (`p`.`number_id` = `b`.`id`))));

-- Дамп структуры для представление u_system._prod_parking
-- Удаление временной таблицы и создание окончательной структуры представления
DROP TABLE IF EXISTS `_prod_parking`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `_prod_parking` AS select `p`.`id` AS `id`,`p`.`number_f` AS `number_f`,`c`.`name` AS `name`,if((`p`.`typev` = '(KGS)'),round((`p`.`price` / `cur`.`usd`),2),`p`.`price`) AS `usd`,if((`p`.`typev` = '(USD)'),round((`p`.`price` * `cur`.`usd`),2),`p`.`price`) AS `kgs`,(if((`p`.`typev` = '(KGS)'),round((`p`.`debu_za` / `cur`.`usd`),2),`p`.`debu_za`) - (select if(isnull(sum(`r`.`usd`)),0,sum(`r`.`usd`)) from `repayment_parking` `r` where ((`p`.`dom_id` = `r`.`dom_id`) and (`r`.`number_f` = `p`.`number_f`)))) AS `d_usd`,if((`p`.`typev` = '(USD)'),round((`p`.`debu_za` * `cur`.`usd`),2),`p`.`debu_za`) AS `d_kgs`,`p`.`data_n` AS `data_n`,`p`.`data_k` AS `data_k`,`p`.`dom_id` AS `dom_id`,`p`.`klient_id` AS `klient_id`,`p`.`cars_id` AS `cars_id`,if((`p`.`cars_id` = ''),' ','Имеит') AS `cars1`,`u`.`name` AS `emp` from (((`prod_parking` `p` join `currency` `cur`) join `client` `c`) join `users` `u` on(((`p`.`kurs` = `cur`.`id`) and (`p`.`klient_id` = `c`.`id`) and (`p`.`emp` = `u`.`id`) and (`p`.`remov` = '0'))));

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
