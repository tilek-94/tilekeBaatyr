-- --------------------------------------------------------
-- Хост:                         192.168.1.126
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

-- Дамп структуры для таблица u_system.bisnesclass
CREATE TABLE IF NOT EXISTS `bisnesclass` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `dom_id` int(11) NOT NULL DEFAULT '0',
  `name` mediumtext CHARACTER SET utf8,
  `m2` int(11) DEFAULT NULL,
  `info` mediumtext CHARACTER SET utf8,
  `remov` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Дамп данных таблицы u_system.bisnesclass: ~1 rows (приблизительно)
/*!40000 ALTER TABLE `bisnesclass` DISABLE KEYS */;
INSERT INTO `bisnesclass` (`id`, `dom_id`, `name`, `m2`, `info`, `remov`) VALUES
	(1, 1, 'fghfghfg', 45454, 'fgyhfgh', 15),
	(2, 1, '54141очень ', 5, 'ggg', 0);
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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.bron: ~4 rows (приблизительно)
/*!40000 ALTER TABLE `bron` DISABLE KEYS */;
INSERT INTO `bron` (`id`, `client_id`, `dom_id`, `number_f`, `price_kv`, `typev`, `kurs`, `sotrudnic_id`, `data`, `remov`) VALUES
	(1, 1, 1, 160, 450, '(USD)', 46, 15, '2020-08-22 19:39:37', 0),
	(2, 1, 1, 167, 550, '(USD)', 58, 15, '2020-08-23 13:35:55', 0),
	(3, 1, 1, 54, 500, '(USD)', 62, 18, '2020-08-23 15:29:33', 0),
	(4, 1, 1, 19, 550, '(USD)', 63, 15, '2020-08-23 15:30:44', 0),
	(5, 1, 1, 34, 650, '(USD)', 69, 15, '2020-08-23 18:01:51', 0),
	(6, 1, 1, 30, 680, '(USD)', 70, 15, '2020-08-23 18:40:24', 0);
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.cars: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `cars` DISABLE KEYS */;
INSERT INTO `cars` (`id`, `marka`, `data`, `nomer`, `condition_c`, `prih_summ`, `type_v`, `kurs`, `client_id`, `datatim`, `remov`, `prod_cars`) VALUES
	(1, 'Хундай портер', '01.08.1999', 'О4914Е', 'Средние', 380000, '(KGS)', 43, 9, '2020-08-23 15:04:27', 0, 15);
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
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.client: ~28 rows (приблизительно)
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
INSERT INTO `client` (`id`, `name`, `data`, `tel_nom`, `AN`, `data_vdan`, `vdan_uch`, `address_pas`, `address`, `foto`, `remov`) VALUES
	(1, 'Абдувап кызы Айгерим', '27.08.2001', '0 778 51 85 54', 'ID0326251', '06.10.2017', 'MKK216063', 'Ошская область, Узгенский район, село Кызыл-Сенир', 'Ошская область, Узгенский район, село Кызыл-Сенир', NULL, 0),
	(2, 'Гапарова Чынаргул Закировна', '28.01.1981', '0 502 07 07 39', 'AN2301002', '11.04.2019', 'MKK50-76', 'Ошская обл, Чон-Алайский район, село Жар-Башы', 'Ошская обл, Чон-Алайский район, село Жар-Башы', NULL, 17),
	(3, 'Абдирахманов Рашидин Абаралиевич', '07.10.1959', '0 554 20 20 21', 'AN3597685', '24.07.2013', 'MKK 50-41', 'Ош мкрн. Ак-Тилек, ул, 34 дом 32', 'Ош мкрн. Ак-Тилек, ул, 34 дом 32', NULL, 0),
	(4, 'Гапарова Чынаргул Закировна', '28.01.1981', '0 502 07 07 39', 'AN2301002', '11.04.2019', 'MKK 50-76', 'Ошская обл, Чон-Алайский район, село Жар-Башы', 'Ошская обл, Чон-Алайский район, село Жар-Башы', NULL, 0),
	(5, 'Джоробекова Бужамал Тиленовна ', '15.11.1967', '0 772 30 45 31; 0 555 30 45 31', 'AN3767370', '23.01.2014', 'МКК 50-41', 'г Ош', 'г Ош', NULL, 0),
	(6, 'Кабыл-Ахунова Диора Ибраимжановна', '02.02.1985', '0 772 90 62 70', 'ID0905102', '01.10.2018', 'МКК 216063', 'г Ош', 'г Ош', NULL, 0),
	(7, 'Сатыбалдиева Наргиза Урайымовна', '03.03.1986', '0 776 62 08 43', 'ID1013114', '08.01.2019', 'МКК 212011', 'г Ош, ул Моторная 2а/3, кв 94', 'г Ош, ул Моторная 2а/3, кв 94', NULL, 0),
	(8, 'Назарова Айнагул Буркановна', '25.05.1964', '0 770 18 06 16', 'ID093834', '02.11.2018', 'МКК 212011', 'г Ош, улица А.Навои №26 ', 'г Ош, улица А.Навои №26 ', NULL, 0),
	(9, 'Амитов Элдияр Мамаражапович', '22.05.1999', '0 779 18 88 98  0 771 524 771', 'AN 4816641', '07.02.2017', 'МКК', 'Ош.Обл., Чон-Алай р-ну, Жекенди А.', 'Ош.Обл., Чон-Алай р-ну, Жекенди А.', NULL, 0),
	(10, 'Татибекова Рита Джамалдиновна', '02.06.1985', 'нету', 'AN2708380', '04.02.2012', 'МКК 50-00', 'г. Ош, ул.Салиев К. дом. №5,кв №46', 'г. Ош, ул.Салиев К. дом. №5,кв №46', NULL, 0),
	(11, 'Амракулова Бермет Шеркуловна', '12.12.1965', '0 778 11 33 09', 'ID0803959', '12.07.2018', 'MKK 216036', 'Ошская обл, Кара-Сууйский р-н, с.Толойкон ', 'Ошская обл, Кара-Сууйский р-н, с.Толойкон ', NULL, 0),
	(12, 'Жаныбек уулу Айбек', '12.03.1991', '0777 175 175', 'AN 2297302', '08.04.2011', 'МКК 50-47', 'Ошская обл, Узгенский р-н, с. Кара-Дыйкан, ул. Акматов 81', 'Ошская обл, Узгенский р-н, с. Кара-Дыйкан, ул. Акматов 81', NULL, 0),
	(13, 'Эгемназаров Бектур Таалайбекович', '13.07.1984', 'нету', 'AN 2514912', '24.08.2011', 'МКК', 'Ошская область. Кара-Сууский район,  село Кызыл-Байрак', 'Ошская область. Кара-Сууский район,  село Кызыл-Байрак', NULL, 0),
	(14, 'Калмурзаев Тынарбек Абдижапарович ', '14.02.1986', '0 554 04 65 10', 'AN 3464173', '14.05.2013', 'МКК', 'Ошская обл. Кара-сууйский район, ул. Большевик А', 'Ошская обл. Кара-сууйский район, ул. Большевик А', NULL, 0),
	(15, 'Маматов Мирбек Жанбаевич', '12.03.1978', '0 775 02 50 50', 'AN3107495', '31.10.2012', 'МКК 50-34', 'Кара-Сууйский р-н, с.Савай', 'Кара-Сууйский р-н, с.Савай', NULL, 0),
	(16, 'Азимбаев Усонбай Мамазайирович ', '05.01.1956', '0 772 90 62 70', 'ID0815983 ', '19.07.2018', 'МКК 216042 ', 'Ошская Область. Кара-кулжинский район  село Сары-булак', 'Ошская Область. Кара-кулжинский район  село Сары-булак', NULL, 0),
	(17, 'Уркунов Калыбай Султамамытович', '05.04.1983', '0 755 06 60 05', 'АN4675703', '13.10.2016', 'МКК 50-42', 'Ошская область Кара-Кулжинский    район. Село Ой-Тал', 'Ошская область Кара-Кулжинский    район. Село Ой-Тал', NULL, 0),
	(18, 'Рысбаев Нурлан Разакович', '02.02.1985', '0 557 74 74 35', 'AN2251299', '17.03.2011', 'ИИМ 50-47', 'Ошская обл, Узгенский р-н, с Красный Маяк', 'Ошская обл, Узгенский р-н, с Красный Маяк', NULL, 0),
	(19, 'Иминахунова Хурсанай Манаповна ', '15.09.1985', '0 779 41 45 41', 'AN2003435', '27.10.2010', 'ИИM 50-34 ', 'Кра-Сууский    район. село Кызыл-Кыштак ул.Бешкапа.', 'Кара-Сууский район, село Кызыл-Кыштак ул.Бешкапа.', NULL, 0),
	(20, 'Ибраимова Замира Олжобаевна ', '15.08.1982', '0 779 99 10 96', 'ID1164777', '09.04.2019', 'МКК 212011', 'Ошская обл., г. Ош, ул Ашимахунова 8/10', 'Ошская обл., г. Ош, ул Ашимахунова 8/10', NULL, 0),
	(21, 'Мамираимов Нышанбай Турумбекович', '06.02.1967', '0 773 58 27 06; 0 777 65 75 08', 'AN3413251', '17.04.2013', 'MKK 50-42', 'Ошская обл, Кара-Кулжинский р-н, с.Кара-Кулжа, ул Б.Исаева', 'Ошская обл, Кара-Кулжинский р-н, с.Кара-Кулжа, ул Б.Исаева', NULL, 0),
	(22, 'Алишев Сыргак Рысбаевич', '24.11.1971', '0 777 87 36 02', 'ID0722667', '03.05.2018', 'МКК 216042', 'Ошская обл, Кара-Кулжинскик р-н, с.Биринчи Май', 'Ошская обл, Кара-Кулжинскик р-н, с.Биринчи Май', NULL, 0),
	(23, 'Иминахунова Хурсанай Манаповна', '15.09.1985', '0 779 41 45 41', 'AN2003435', '27.10.2010', 'ИИM 50-34 ', 'Ошская область.   Кра-Сууский    район, село Кызыл-Кыштак ул.Бешкапа', 'Ошская область.   Кра-Сууский    район,село Кызыл-Кыштак ул.Бешкапа', NULL, 0),
	(24, 'Кыязов Муктараит Шералиевич', '07.10.1996', '0779 70 00 96', 'ID1065000', '07.02.2019', 'МКК 216071', 'Ошская область, Чон-Алайский район, село Шибе ', 'Ошская область, Чон-Алайский район, село Шибе ', NULL, 0),
	(25, 'Аманбаева Алтынай Сатиевна', '03.05.1959', '0 777 37 66 56 ; 0554 43 50 51', 'ID1390023', '12.09.2019', 'MKK216031', 'Ошская обл, Кара-Суускик р-н, с.Отуз адыр.ул Ажибекова 4', 'Ошская обл, Кара-Суускик р-н, с.Отуз адыр.ул Ажибекова 4', NULL, 0),
	(26, 'Парманкулов Замирбек Зулпукарович', '25.11.1988', '0558 251188', 'AN 2569308', '10.10.2011', 'МКК 50-40', 'Ошкий обл, Ноокатский р-н, Найман', 'Ошкий обл, Ноокатский р-н, ', NULL, 0),
	(27, 'Лифт', '21.08.2020', '0', 'рапрп', '06.08.2020', 'лифт', 'Лифт', 'Лифт', NULL, 0),
	(28, 'Аманбаева Алтынай Сатиевна', '03.05.1959', '0 777 37 66 56 ; 0554 43 50 51', 'ID1390023', '12.09.2019', 'MKK216031', 'Кара-Суускик р-н, с.Отуз адыр.', 'Кара-Суускик р-н, с.Отуз адыр.', NULL, 0);
/*!40000 ALTER TABLE `client` ENABLE KEYS */;

-- Дамп структуры для таблица u_system.currency
CREATE TABLE IF NOT EXISTS `currency` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `usd` double DEFAULT NULL,
  `eur` double DEFAULT NULL,
  `rub` double DEFAULT NULL,
  `data` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=72 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.currency: ~68 rows (приблизительно)
/*!40000 ALTER TABLE `currency` DISABLE KEYS */;
INSERT INTO `currency` (`id`, `usd`, `eur`, `rub`, `data`) VALUES
	(1, 69.8, 0, 0, '2020-08-18 11:30:51'),
	(2, 69.8, 0, 0, '2020-08-18 11:38:55'),
	(3, 69.8, 0, 0, '2020-08-18 11:39:03'),
	(4, 69.8, 0, 0, '2020-08-18 11:39:17'),
	(5, 69.8, 0, 0, '2020-08-18 11:50:10'),
	(6, 69.8, 0, 0, '2020-08-19 09:59:28'),
	(7, 69.84, 0, 0, '2020-08-19 10:05:23'),
	(8, 69.8, 0, 0, '2020-08-23 18:20:33'),
	(9, 69.8, 0, 0, '2020-08-19 10:18:08'),
	(10, 69.8, 0, 0, '2020-08-19 10:36:01'),
	(11, 69.8, 0, 0, '2020-08-19 10:41:38'),
	(12, 70, 0, 0, '2020-08-19 10:42:23'),
	(13, 70, 0, 0, '2020-08-19 10:42:39'),
	(14, 69.7, 0, 0, '2020-08-19 10:48:10'),
	(15, 69.8, 0, 0, '2020-08-19 10:51:58'),
	(16, 69.7, 0, 0, '2020-08-19 10:52:15'),
	(17, 69.7, 0, 0, '2020-08-19 10:52:40'),
	(18, 69.7, 0, 0, '2020-08-19 10:54:08'),
	(19, 69.7, 0, 0, '2020-08-19 10:54:56'),
	(20, 69.7, 0, 0, '2020-08-19 10:55:29'),
	(21, 69.7, 0, 0, '2020-08-19 11:01:33'),
	(22, 69.7, 0, 0, '2020-08-19 11:02:56'),
	(23, 69.7, 0, 0, '2020-08-19 11:03:24'),
	(24, 69.75, 0, 0, '2020-08-19 11:06:54'),
	(25, 69.7, 0, 0, '2020-08-19 11:10:19'),
	(26, 70, 0, 0, '2020-08-19 11:15:29'),
	(27, 70, 0, 0, '2020-08-19 11:19:40'),
	(28, 69.8, 0, 0, '2020-08-20 10:26:48'),
	(29, 69.8, 0, 0, '2020-08-20 10:31:04'),
	(30, 70, 0, 0, '2020-08-20 10:39:32'),
	(31, 69.8, 0, 0, '2020-08-20 10:44:08'),
	(32, 69.8, 0, 0, '2020-08-20 10:53:15'),
	(33, 69.8, 0, 0, '2020-08-20 10:56:56'),
	(34, 0, 0, 0, '2020-08-20 10:57:01'),
	(35, 69.8, 0, 0, '2020-08-20 10:57:06'),
	(36, 69.8, 0, 0, '2020-08-20 11:04:00'),
	(37, 69.8, 0, 0, '2020-08-20 11:19:56'),
	(38, 69.7, 0, 0, '2020-08-20 11:25:27'),
	(39, 69.8, 0, 0, '2020-08-20 11:29:18'),
	(40, 69.8, 0, 0, '2020-08-20 11:30:24'),
	(41, 69.8, 0, 0, '2020-08-20 11:31:29'),
	(42, 69.8, 0, 0, '2020-08-20 11:45:48'),
	(43, 69.8, 0, 0, '2020-08-22 10:08:26'),
	(44, 69.8, 0, 0, '2020-08-22 10:18:26'),
	(45, 69.8, 0, 0, '2020-08-22 10:54:29'),
	(46, 70, 0, 0, '2020-08-22 19:39:25'),
	(47, 70, 0, 0, '2020-08-22 19:45:06'),
	(48, 70, 0, 0, '2020-08-22 19:48:10'),
	(49, 70, 0, 0, '2020-08-22 19:59:23'),
	(50, 70, 0, 0, '2020-08-22 20:00:10'),
	(51, 70, 0, 0, '2020-08-22 20:00:55'),
	(52, 77.9456, 92.0732, 1.0519, '2020-08-22 20:09:47'),
	(53, 70, 0, 0, '2020-08-22 20:28:21'),
	(54, 70, 0, 0, '2020-08-23 11:18:38'),
	(55, 70, 0, 0, '2020-08-23 11:43:57'),
	(56, 70, 0, 0, '2020-08-23 13:28:14'),
	(57, 70, 0, 0, '2020-08-23 13:29:10'),
	(58, 70, 0, 0, '2020-08-23 13:35:41'),
	(59, 77.9456, 92.0732, 1.0519, '2020-08-23 14:30:09'),
	(60, 77.9456, 92.0732, 1.0519, '2020-08-23 14:55:03'),
	(61, 77.9456, 92.0732, 1.0519, '2020-08-23 15:04:21'),
	(62, 69.8, 0, 0, '2020-08-23 15:29:24'),
	(63, 70, 0, 0, '2020-08-23 15:30:33'),
	(64, 77.9456, 92.0732, 1.0519, '2020-08-23 15:54:20'),
	(65, 70, 0, 0, '2020-08-23 15:55:36'),
	(66, 70, 0, 0, '2020-08-23 15:57:08'),
	(67, 70, 0, 0, '2020-08-23 15:57:15'),
	(68, 77.9456, 92.0732, 1.0519, '2020-08-23 17:16:34'),
	(69, 77.9456, 92.0732, 1.0519, '2020-08-23 18:01:39'),
	(70, 70, 0, 0, '2020-08-23 18:40:15'),
	(71, 0, 0, 0, '2020-08-23 18:41:36');
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.dom: ~2 rows (приблизительно)
/*!40000 ALTER TABLE `dom` DISABLE KEYS */;
INSERT INTO `dom` (`id`, `name`, `floor`, `porch`, `count_kv`, `parking`, `nom_flat`, `addres`, `remov`) VALUES
	(1, 'Жилой Комплекс "ДАТКА"', 15, 2, 168, 38, 10, 'Ул. А. Навои 10', 0),
	(2, 'ЖК "ТИЛЕКЕ БААТЫР"', 12, 5, 275, 0, 2, 'ул. Тилеке Баатыр 2', 0);
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
  `client_id` text CHARACTER SET utf8 NOT NULL,
  `product_id` text CHARACTER SET utf8 NOT NULL,
  `number_f` int(11) NOT NULL DEFAULT '0',
  `data` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `dom_id` int(11) NOT NULL DEFAULT '0',
  `remov` int(11) NOT NULL DEFAULT '0',
  `emp` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

-- Дамп данных таблицы u_system.exchange: ~4 rows (приблизительно)
/*!40000 ALTER TABLE `exchange` DISABLE KEYS */;
INSERT INTO `exchange` (`id`, `client_id`, `product_id`, `number_f`, `data`, `dom_id`, `remov`, `emp`) VALUES
	(8, 'Гапарова Чынаргул Закировна', 'Темир', 4, '2020-08-23 14:51:36', 1, 15, 15),
	(9, 'ОсОО "Икар-А"', 'Темир', 5, '2020-08-23 14:51:46', 1, 0, 15),
	(10, 'Абдувап кызы Айгерим', 'ПРоо', 55, '2020-08-23 15:27:31', 1, 0, 18),
	(11, 'Кунболот', 'Кирпич', 13, '2020-08-23 17:11:26', 1, 0, 15),
	(12, 'ааппап', 'кипич', 30, '2020-08-23 18:00:50', 1, 15, 15);
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
) ENGINE=InnoDB AUTO_INCREMENT=169 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.flat: ~155 rows (приблизительно)
/*!40000 ALTER TABLE `flat` DISABLE KEYS */;
INSERT INTO `flat` (`id`, `dom_id`, `floor`, `porch`, `room`, `type_flat`, `number_f`, `remov`) VALUES
	(1, 1, 4, 1, 1, '4-тип', 1, 0),
	(2, 1, 4, 1, 1, '1-тип', 6, 0),
	(3, 1, 4, 1, 1, '3-тип', 7, 0),
	(4, 1, 4, 1, 1, '6-тип', 3, 0),
	(5, 1, 4, 1, 2, '1-тип', 4, 0),
	(6, 1, 4, 1, 2, '2-тип', 5, 0),
	(7, 1, 4, 1, 3, '1-тип', 2, 0),
	(8, 1, 4, 2, 1, '1-тип', 86, 0),
	(9, 1, 4, 2, 1, '2-тип', 85, 0),
	(10, 1, 4, 2, 1, '5-тип', 91, 0),
	(11, 1, 4, 2, 1, '6-тип', 89, 0),
	(12, 1, 4, 2, 2, '1-тип', 88, 0),
	(13, 1, 4, 2, 2, '2-тип', 87, 0),
	(14, 1, 4, 2, 3, '1-тип', 90, 0),
	(15, 1, 5, 1, 1, '1-тип', 13, 0),
	(16, 1, 5, 1, 1, '3-тип', 14, 0),
	(17, 1, 5, 1, 1, '4-тип', 8, 0),
	(18, 1, 5, 1, 1, '6-тип', 10, 0),
	(19, 1, 5, 1, 2, '1-тип', 11, 0),
	(20, 1, 5, 1, 2, '2-тип', 12, 0),
	(21, 1, 5, 1, 3, '1-тип', 9, 0),
	(22, 1, 5, 2, 1, '1-тип', 93, 0),
	(23, 1, 5, 2, 1, '2-тип', 92, 0),
	(24, 1, 5, 2, 1, '5-тип', 98, 0),
	(25, 1, 5, 2, 1, '6-тип', 96, 0),
	(26, 1, 5, 2, 2, '1-тип', 95, 0),
	(27, 1, 5, 2, 2, '2-тип', 94, 0),
	(28, 1, 5, 2, 3, '1-тип', 97, 0),
	(29, 1, 6, 1, 1, '1-тип', 20, 0),
	(30, 1, 6, 1, 1, '3-тип', 21, 0),
	(31, 1, 6, 1, 1, '4-тип', 15, 0),
	(32, 1, 6, 1, 1, '6-тип', 17, 0),
	(33, 1, 6, 1, 2, '1-тип', 18, 0),
	(34, 1, 6, 1, 2, '2-тип', 19, 0),
	(35, 1, 6, 1, 3, '1-тип', 16, 0),
	(36, 1, 6, 2, 1, '1-тип', 100, 0),
	(37, 1, 6, 2, 1, '2-тип', 99, 0),
	(38, 1, 6, 2, 1, '5-тип', 105, 0),
	(39, 1, 6, 2, 1, '6-тип', 103, 0),
	(40, 1, 6, 2, 2, '1-тип', 102, 0),
	(41, 1, 6, 2, 2, '2-тип', 101, 0),
	(42, 1, 6, 2, 3, '1-тип', 104, 0),
	(43, 1, 7, 1, 1, '1-тип', 27, 0),
	(44, 1, 7, 1, 1, '3-тип', 28, 0),
	(45, 1, 7, 1, 1, '4-тип', 22, 0),
	(46, 1, 7, 1, 1, '6-тип', 24, 0),
	(47, 1, 7, 1, 2, '1-тип', 25, 0),
	(48, 1, 7, 1, 2, '2-тип', 26, 0),
	(49, 1, 7, 1, 3, '1-тип', 23, 0),
	(50, 1, 7, 2, 1, '1-тип', 107, 0),
	(51, 1, 7, 2, 1, '2-тип', 106, 0),
	(52, 1, 7, 2, 1, '5-тип', 112, 0),
	(53, 1, 7, 2, 1, '6-тип', 110, 0),
	(54, 1, 7, 2, 2, '1-тип', 109, 0),
	(55, 1, 7, 2, 2, '2-тип', 108, 0),
	(56, 1, 7, 2, 3, '1-тип', 111, 0),
	(57, 1, 8, 1, 1, '1-тип', 34, 0),
	(58, 1, 8, 1, 1, '3-тип', 35, 0),
	(59, 1, 8, 1, 1, '4-тип', 29, 0),
	(60, 1, 8, 1, 1, '6-тип', 31, 0),
	(61, 1, 8, 1, 2, '1-тип', 32, 0),
	(62, 1, 8, 1, 2, '2-тип', 33, 0),
	(63, 1, 8, 1, 3, '1-тип', 30, 0),
	(64, 1, 8, 2, 1, '1-тип', 114, 0),
	(65, 1, 8, 2, 1, '2-тип', 113, 0),
	(66, 1, 8, 2, 1, '5-тип', 119, 0),
	(67, 1, 8, 2, 1, '6-тип', 117, 0),
	(68, 1, 8, 2, 2, '1-тип', 116, 0),
	(69, 1, 8, 2, 2, '2-тип', 115, 0),
	(70, 1, 8, 2, 3, '1-тип', 118, 0),
	(71, 1, 9, 1, 1, '1-тип', 41, 0),
	(72, 1, 9, 1, 1, '3-тип', 42, 0),
	(73, 1, 9, 1, 1, '4-тип', 36, 0),
	(74, 1, 9, 1, 1, '6-тип', 38, 0),
	(75, 1, 9, 1, 2, '1-тип', 39, 0),
	(76, 1, 9, 1, 2, '2-тип', 40, 0),
	(77, 1, 9, 1, 3, '1-тип', 37, 0),
	(78, 1, 9, 2, 1, '1-тип', 121, 0),
	(79, 1, 9, 2, 1, '2-тип', 120, 0),
	(80, 1, 9, 2, 1, '5-тип', 126, 0),
	(81, 1, 9, 2, 1, '6-тип', 124, 0),
	(82, 1, 9, 2, 2, '1-тип', 123, 0),
	(83, 1, 9, 2, 2, '2-тип', 122, 0),
	(84, 1, 9, 2, 3, '1-тип', 125, 0),
	(85, 1, 10, 1, 1, '1-тип', 48, 0),
	(86, 1, 10, 1, 1, '3-тип', 49, 0),
	(87, 1, 10, 1, 1, '4-тип', 43, 0),
	(88, 1, 10, 1, 1, '6-тип', 45, 0),
	(89, 1, 10, 1, 2, '1-тип', 46, 0),
	(90, 1, 10, 1, 2, '2-тип', 47, 0),
	(91, 1, 10, 1, 3, '1-тип', 44, 0),
	(92, 1, 10, 2, 1, '1-тип', 128, 0),
	(93, 1, 10, 2, 1, '2-тип', 127, 0),
	(94, 1, 10, 2, 1, '5-тип', 133, 0),
	(95, 1, 10, 2, 1, '6-тип', 131, 0),
	(96, 1, 10, 2, 2, '1-тип', 130, 0),
	(97, 1, 10, 2, 2, '2-тип', 129, 0),
	(98, 1, 10, 2, 3, '1-тип', 132, 0),
	(99, 1, 11, 1, 1, '1-тип', 55, 0),
	(100, 1, 11, 1, 1, '3-тип', 56, 0),
	(101, 1, 11, 1, 1, '4-тип', 50, 0),
	(102, 1, 11, 1, 1, '6-тип', 52, 0),
	(103, 1, 11, 1, 2, '1-тип', 53, 0),
	(104, 1, 11, 1, 2, '2-тип', 54, 0),
	(105, 1, 11, 1, 3, '1-тип', 51, 0),
	(106, 1, 11, 2, 1, '1-тип', 135, 0),
	(107, 1, 11, 2, 1, '2-тип', 134, 0),
	(108, 1, 11, 2, 1, '5-тип', 140, 0),
	(109, 1, 11, 2, 1, '6-тип', 138, 0),
	(110, 1, 11, 2, 2, '1-тип', 137, 0),
	(111, 1, 11, 2, 2, '2-тип', 136, 0),
	(112, 1, 11, 2, 3, '1-тип', 139, 0),
	(113, 1, 12, 1, 1, '1-тип', 62, 0),
	(114, 1, 12, 1, 1, '3-тип', 63, 0),
	(115, 1, 12, 1, 1, '4-тип', 57, 0),
	(116, 1, 12, 1, 1, '6-тип', 59, 0),
	(117, 1, 12, 1, 2, '1-тип', 60, 0),
	(118, 1, 12, 1, 2, '2-тип', 61, 0),
	(119, 1, 12, 1, 3, '1-тип', 58, 0),
	(120, 1, 12, 2, 1, '1-тип', 142, 0),
	(121, 1, 12, 2, 1, '2-тип', 141, 0),
	(122, 1, 12, 2, 1, '5-тип', 147, 0),
	(123, 1, 12, 2, 1, '6-тип', 145, 0),
	(124, 1, 12, 2, 2, '1-тип', 144, 0),
	(125, 1, 12, 2, 2, '2-тип', 143, 0),
	(126, 1, 12, 2, 3, '1-тип', 146, 0),
	(127, 1, 13, 1, 1, '1-тип', 69, 0),
	(128, 1, 13, 1, 1, '3-тип', 70, 0),
	(129, 1, 13, 1, 1, '4-тип', 64, 0),
	(130, 1, 13, 1, 1, '6-тип', 66, 0),
	(131, 1, 13, 1, 2, '1-тип', 67, 0),
	(132, 1, 13, 1, 2, '2-тип', 68, 0),
	(133, 1, 13, 1, 3, '1-тип', 65, 0),
	(134, 1, 13, 2, 1, '1-тип', 149, 0),
	(135, 1, 13, 2, 1, '2-тип', 148, 0),
	(136, 1, 13, 2, 1, '5-тип', 154, 0),
	(137, 1, 13, 2, 1, '6-тип', 152, 0),
	(138, 1, 13, 2, 2, '1-тип', 151, 0),
	(139, 1, 13, 2, 2, '2-тип', 150, 0),
	(140, 1, 13, 2, 3, '1-тип', 153, 0),
	(141, 1, 14, 1, 1, '1-тип', 76, 0),
	(142, 1, 14, 1, 1, '3-тип', 77, 0),
	(143, 1, 14, 1, 1, '4-тип', 71, 0),
	(144, 1, 14, 1, 1, '6-тип', 73, 0),
	(145, 1, 14, 1, 2, '1-тип', 74, 0),
	(146, 1, 14, 1, 2, '2-тип', 75, 0),
	(147, 1, 14, 1, 3, '1-тип', 72, 0),
	(148, 1, 14, 2, 1, '1-тип', 156, 0),
	(149, 1, 14, 2, 1, '2-тип', 155, 0),
	(150, 1, 14, 2, 1, '5-тип', 161, 0),
	(151, 1, 14, 2, 1, '6-тип', 159, 0),
	(152, 1, 14, 2, 2, '1-тип', 158, 0),
	(153, 1, 14, 2, 2, '2-тип', 157, 0),
	(154, 1, 14, 2, 3, '1-тип', 160, 0),
	(155, 1, 15, 1, 1, '1-тип', 83, 0),
	(156, 1, 15, 1, 1, '3-тип', 84, 0),
	(157, 1, 15, 1, 1, '4-тип', 78, 0),
	(158, 1, 15, 1, 1, '6-тип', 80, 0),
	(159, 1, 15, 1, 2, '1-тип', 81, 0),
	(160, 1, 15, 1, 2, '2-тип', 82, 0),
	(161, 1, 15, 1, 3, '1-тип', 79, 0),
	(162, 1, 15, 2, 1, '1-тип', 163, 0),
	(163, 1, 15, 2, 1, '2-тип', 162, 0),
	(164, 1, 15, 2, 1, '5-тип', 168, 0),
	(165, 1, 15, 2, 1, '6-тип', 166, 0),
	(166, 1, 15, 2, 2, '1-тип', 165, 0),
	(167, 1, 15, 2, 3, '1-тип', 167, 0),
	(168, 1, 15, 2, 2, '2-тип', 164, 0);
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Дамп данных таблицы u_system.operation: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `operation` DISABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;

-- Дамп данных таблицы u_system.organization: ~3 rows (приблизительно)
/*!40000 ALTER TABLE `organization` DISABLE KEYS */;
INSERT INTO `organization` (`id`, `name`, `pname`, `inn`, `data_registr`, `registr_s`, `addres`, `tel`, `direct`, `data`, `remov`) VALUES
	(1, 'ОсОО "Икар-А"', 'ОсОО "Икар-А"', '', '', 'ОФ ОАО "Optima" 1092020037690185', '0550039 29 73', 'Исанов кочосу 22', 'Эсенкулов Манас Бактыбекович', '2020-08-22 10:03:40', 0),
	(18, 'ОсОО "Эр Жанар"', '', '', '', '', '', '', 'Умаров Тилек', '2020-08-23 16:00:10', 0),
	(19, '', '', '', '', '', '', '', '', '2020-08-23 17:27:01', 15),
	(20, 'пргнг', '', '', '', '', '', 'енгоггпр', 'поенго', '2020-08-23 18:03:37', 0);
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Дамп данных таблицы u_system.parking: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `parking` DISABLE KEYS */;
/*!40000 ALTER TABLE `parking` ENABLE KEYS */;

-- Дамп структуры для таблица u_system.phous
CREATE TABLE IF NOT EXISTS `phous` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `dom_id` int(11) DEFAULT NULL,
  `remov` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Дамп данных таблицы u_system.phous: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `phous` DISABLE KEYS */;
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
  `emp` int(11) DEFAULT NULL,
  `remov` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Дамп данных таблицы u_system.prihod: ~3 rows (приблизительно)
/*!40000 ALTER TABLE `prihod` DISABLE KEYS */;
INSERT INTO `prihod` (`id`, `operationU`, `organ`, `summa`, `typev`, `kurs`, `data`, `emp`, `remov`) VALUES
	(1, '1', NULL, NULL, NULL, NULL, '2020-08-22 19:41:24', NULL, 0),
	(2, 'за квартиру', 'Арстан ака прораб', 60000, '(KGS)', 65, '2020-08-23 15:55:52', 15, 0),
	(3, 'Портер', 'Данияр яерез Сапарбек ака', 290000, '(KGS)', 67, '2020-08-23 15:57:23', 15, 0);
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Дамп данных таблицы u_system.prodbclass: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `prodbclass` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.prodphous: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `prodphous` DISABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.product: ~1 rows (приблизительно)
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` (`id`, `name`, `price`, `typev`, `kurs`, `remov`, `data`) VALUES
	(1, 'Темир', 15000, '(USD)', 59, 0, '2020-08-23 14:30:17');
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

-- Дамп данных таблицы u_system.prod_cars: ~1 rows (приблизительно)
/*!40000 ALTER TABLE `prod_cars` DISABLE KEYS */;
INSERT INTO `prod_cars` (`id`, `cars_id`, `client_id`, `price`, `typev`, `curren_id`, `data`, `remov`, `employee_id`) VALUES
	(4, 1, 1, 290000, '(KGS)', 61, '2020-08-23 15:04:27', 0, 15);
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.prod_parking: ~1 rows (приблизительно)
/*!40000 ALTER TABLE `prod_parking` DISABLE KEYS */;
INSERT INTO `prod_parking` (`id`, `dom_id`, `klient_id`, `number_f`, `cars_id`, `contract`, `price`, `vznos`, `cars_summ`, `debu_za`, `typev`, `kurs`, `data_n`, `data_k`, `data`, `remov`, `emp`) VALUES
	(1, 1, 1, 1, '[]', '12', 7000, 3500, 0, 3500, '(USD)', 54, '2020-08-23', '2021-08-23', '2020-08-23 11:20:04', 0, 15);
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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

-- Дамп данных таблицы u_system.rashod: ~6 rows (приблизительно)
/*!40000 ALTER TABLE `rashod` DISABLE KEYS */;
INSERT INTO `rashod` (`id`, `operationU`, `organ`, `summa`, `typev`, `kurs`, `data`, `sotrud`, `remov`) VALUES
	(1, '1', NULL, NULL, NULL, NULL, '2020-08-22 19:41:09', NULL, 15),
	(2, 'апапап', 'ааапрапр', 10643, '(KGS)', 49, '2020-08-22 19:59:32', 15, 15),
	(3, 'кенкенк', 'кенкнк', 8000, '(USD)', 51, '2020-08-22 20:01:04', 15, 15),
	(4, 'За прогрумму', 'Умаров Тилек', 50000, '(KGS)', 55, '2020-08-23 11:44:13', 15, 0),
	(5, 'ГСМ', 'ОсОО "Икар-А"', 477, '(USD)', 64, '2020-08-23 15:54:30', 15, 0),
	(6, 'Соцфонд', 'СоцФонд КР', 42122, '(KGS)', 68, '2020-08-23 17:16:42', 15, 0);
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
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.repayment: ~7 rows (приблизительно)
/*!40000 ALTER TABLE `repayment` DISABLE KEYS */;
INSERT INTO `repayment` (`id`, `dom_id`, `number_f`, `client_id`, `summa`, `usd`, `data_month`, `data`, `remov`, `emp`) VALUES
	(1, 1, 1, 1, 545, 38100, '2019-12-22', '2020-08-22 16:50:00', 0, 15),
	(2, 1, 3, 5, 980, 68482, '2020-01-22', '2020-08-22 16:54:41', 0, 15),
	(3, 1, 1, 1, 550, 38390, '2020-01-23', '2020-08-23 10:40:35', 0, 15),
	(4, 1, 1, 1, 545.83, 38100, '2020-02-23', '2020-08-23 11:15:43', 0, 15),
	(5, 1, 1, 1, 1430, 100000, '2020-03-23', '2020-08-23 11:51:06', 0, 15),
	(6, 1, 85, 26, 464, 32387, '2019-09-23', '2020-08-23 15:52:11', 0, 15),
	(7, 1, 107, 21, 538.5, 37592, '2019-12-23', '2020-08-23 17:14:24', 0, 15);
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.repayment_parking: ~1 rows (приблизительно)
/*!40000 ALTER TABLE `repayment_parking` DISABLE KEYS */;
INSERT INTO `repayment_parking` (`id`, `dom_id`, `number_f`, `client_id`, `summa`, `usd`, `data_month`, `data`, `remov`, `emp`) VALUES
	(1, 1, 1, 1, 35000, 500, '2020-08-23', '2020-08-23 11:08:11', 0, 15),
	(2, 1, 1, 1, 20416, 291, '2020-09-23', '2020-08-23 18:14:21', 0, 15);
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Дамп данных таблицы u_system.typephous: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `typephous` DISABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=116 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.type_flat: ~99 rows (приблизительно)
/*!40000 ALTER TABLE `type_flat` DISABLE KEYS */;
INSERT INTO `type_flat` (`id`, `dom_id`, `porch`, `room`, `type`, `name`, `kvm`) VALUES
	(1, 1, 1, 1, '1-тип', 'Гостиная ', 16.7),
	(2, 1, 1, 1, '1-тип', 'Приожая', 8.4),
	(3, 1, 1, 1, '1-тип', 'Балкон', 2.3),
	(4, 1, 1, 1, '1-тип', 'Кухня', 8.3),
	(5, 1, 1, 1, '1-тип', 'Ванная ', 3.4),
	(11, 1, 1, 1, '3-тип', 'Гостиная', 16.7),
	(12, 1, 1, 1, '3-тип', 'Прихожая', 8.4),
	(13, 1, 1, 1, '3-тип', 'Ванная', 3.6),
	(14, 1, 1, 1, '3-тип', 'Кухня', 8.3),
	(15, 1, 1, 1, '3-тип', 'Балкон', 2.3),
	(16, 1, 1, 1, '3-тип', 'Балкон', 2.5),
	(17, 1, 1, 1, '4-тип', 'Гостиная', 18.4),
	(18, 1, 1, 1, '4-тип', 'Прихожая', 10.8),
	(19, 1, 1, 1, '4-тип', 'Балкон', 2.9),
	(20, 1, 1, 1, '4-тип', 'Кухня', 12.15),
	(21, 1, 1, 1, '4-тип', 'Ванная', 3.95),
	(28, 1, 1, 1, '6-тип', 'Гостиная', 26),
	(29, 1, 1, 1, '6-тип', 'Кухня', 14.6),
	(30, 1, 1, 1, '6-тип', 'Балкон', 3.2),
	(31, 1, 1, 1, '6-тип', 'Прихожая', 9.1),
	(32, 1, 1, 1, '6-тип', 'Ванная', 4.6),
	(33, 1, 1, 2, '1-тип', 'Гостиная', 22.1),
	(34, 1, 1, 2, '1-тип', 'Спальня', 19.15),
	(35, 1, 1, 2, '1-тип', 'Кухня', 13.75),
	(36, 1, 1, 2, '1-тип', 'Балкон', 2.85),
	(37, 1, 1, 2, '1-тип', 'Санузел', 2.2),
	(38, 1, 1, 2, '1-тип', 'Кладовая', 1.3),
	(39, 1, 1, 2, '1-тип', 'Прихожая ', 18.15),
	(40, 1, 1, 2, '1-тип', 'Ванная ', 3.65),
	(41, 1, 1, 2, '2-тип', 'Гостиная', 23.2),
	(42, 1, 1, 2, '2-тип', 'Спальня', 18.3),
	(43, 1, 1, 2, '2-тип', 'Прихожая', 21.5),
	(44, 1, 1, 2, '2-тип', 'Балкон', 3.65),
	(45, 1, 1, 2, '2-тип', 'Балкон', 3.65),
	(46, 1, 1, 2, '2-тип', 'Ванная', 4.8),
	(47, 1, 1, 2, '2-тип', 'Санузел', 2.05),
	(48, 1, 1, 2, '2-тип', 'Кухня', 17.25),
	(49, 1, 1, 3, '1-тип', 'Гостиная', 18.2),
	(50, 1, 1, 3, '1-тип', 'Балкон', 2.9),
	(51, 1, 1, 3, '1-тип', 'Кухня', 11.2),
	(52, 1, 1, 3, '1-тип', 'Санузел', 2.65),
	(53, 1, 1, 3, '1-тип', 'Спальня', 17.35),
	(54, 1, 1, 3, '1-тип', 'Спальня', 13.85),
	(55, 1, 1, 3, '1-тип', 'Прихожая', 21.1),
	(56, 1, 1, 3, '1-тип', 'Ванная', 4.6),
	(57, 1, 2, 1, '1-тип', 'Гостиная', 16.7),
	(58, 1, 2, 1, '1-тип', 'Прихожая', 8.4),
	(59, 1, 2, 1, '1-тип', 'Ванная', 3.4),
	(60, 1, 2, 1, '1-тип', 'Кухня', 8.3),
	(61, 1, 2, 1, '1-тип', 'Балкон', 2.3),
	(62, 1, 2, 1, '2-тип', 'Гостиная', 16.7),
	(63, 1, 2, 1, '2-тип', 'Прихожая', 8.4),
	(64, 1, 2, 1, '2-тип', 'Ванная ', 3.6),
	(65, 1, 2, 1, '2-тип', 'Кухня', 8.3),
	(66, 1, 2, 1, '2-тип', 'Балкон', 2.3),
	(81, 1, 2, 1, '5-тип', 'Гостиная', 18.4),
	(82, 1, 2, 1, '5-тип', 'Балкон', 2.9),
	(83, 1, 2, 1, '5-тип', 'Кухня', 12.15),
	(84, 1, 2, 1, '5-тип', 'Балкон', 2.5),
	(85, 1, 2, 1, '5-тип', 'Ванная', 3.95),
	(86, 1, 2, 1, '5-тип', 'Прихожая', 10.8),
	(87, 1, 2, 1, '6-тип', 'Гостиная', 26),
	(88, 1, 2, 1, '6-тип', 'Балкон', 3.2),
	(89, 1, 2, 1, '6-тип', 'Кухня', 14.6),
	(90, 1, 2, 1, '6-тип', 'Прихожая', 9.1),
	(91, 1, 2, 1, '6-тип', 'Ванная', 4.6),
	(92, 1, 2, 2, '1-тип', 'Гостиная', 22.1),
	(93, 1, 2, 2, '1-тип', 'Балкон', 2.85),
	(94, 1, 2, 2, '1-тип', 'Кухня', 13.75),
	(95, 1, 2, 2, '1-тип', 'Санузел', 2.2),
	(96, 1, 2, 2, '1-тип', 'Кладовая', 1.3),
	(97, 1, 2, 2, '1-тип', 'Прихожая', 18.15),
	(98, 1, 2, 2, '1-тип', 'Ванная', 3.65),
	(99, 1, 2, 2, '1-тип', 'Спальня', 19.15),
	(100, 1, 2, 2, '2-тип', 'Гостиная', 23.2),
	(101, 1, 2, 2, '2-тип', 'Прихожая', 21.5),
	(102, 1, 2, 2, '2-тип', 'Спальня', 18.3),
	(103, 1, 2, 2, '2-тип', 'Балкон', 3.65),
	(104, 1, 2, 2, '2-тип', 'Ванная', 4.8),
	(105, 1, 2, 2, '2-тип', 'Санузел', 2.05),
	(106, 1, 2, 2, '2-тип', 'Кухня', 17.25),
	(107, 1, 2, 2, '2-тип', 'Балкон', 3.65),
	(108, 1, 2, 3, '1-тип', 'Гостиная', 18.2),
	(109, 1, 2, 3, '1-тип', 'Балкон', 2.9),
	(110, 1, 2, 3, '1-тип', 'Кухня', 11.2),
	(111, 1, 2, 3, '1-тип', 'Санузел', 2.65),
	(112, 1, 2, 3, '1-тип', 'Спальня', 17.35),
	(113, 1, 2, 3, '1-тип', 'Спальня', 13.85),
	(114, 1, 2, 3, '1-тип', 'Прихожая', 21.1),
	(115, 1, 2, 3, '1-тип', 'Ванная', 4.6);
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
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4;

-- Дамп данных таблицы u_system.users: ~4 rows (приблизительно)
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` (`id`, `name`, `rol`, `login`, `parol`, `data_r`, `tel_nom`, `addres`, `an`, `data_p`, `vdan`, `address_p`, `remov`) VALUES
	(15, 'Орунбек', 'admin', 'orunbek', 'AJjHNVA+oxxlnd88V0lp2k4XH2SPmg6FK/eOGOgwcI+dT4T/2LyAw2FwtcQFLf6mxw==', '10.10.1998', '0777 48 08 68', 'ОШ ', 'AN 255 4455', '14.08.2020', 'MKK 55-60', 'Ош шаары ', 0),
	(16, 'Амитов Данияр', 'manager', 'daniyar', 'AFss3V0EysI9/Z4v3wYCSwn8BAteHqmGZAN2eYAISnJth8OMVnimH6c+LS9pNLR3gw==', '25.10.1997', '0554 66 26 62', 'г. Ош село Фуркат', 'ID0001827', '13.05.2017', 'MKK212011', 'г. Ош село Фуркат', 0),
	(17, 'Орозмаматова Нурайым', 'manager', 'nuraiym', 'AJxSywQVdzsTxqp0op1e3/k2CozZdiCWMosdaqzoHyFPJZD0uBDf4+vGx+q9W0gPRQ==', '09.08.1996', '0774 96 90 00', 'г. Ош, ул.Салиева ', 'AN3193702', '28.12.2012', 'МКК 50-02', 'г. Ош, ул.Салиева ', 0),
	(18, 'Эсенкулов манас Бактыбекович', 'director', 'manas', 'AG5vnUaiKjPhpVhUfBdSrBhUfojJs8k2RgYWf+qF2Cy+9X2U4kOvoZuVY3Q+rBDIrA==', '01.03.1987', '0550392973', 'Исанова 22', 'апвап', '06.08.2020', 'Мкк', 'вапв', 0);
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
  `emp` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8;

-- Дамп данных таблицы u_system.zakaz: ~22 rows (приблизительно)
/*!40000 ALTER TABLE `zakaz` DISABLE KEYS */;
INSERT INTO `zakaz` (`id`, `dom_id`, `klient_id`, `number_f`, `cars_id`, `contract`, `price_kvm`, `itog_price`, `vznos`, `cars_summ`, `debu_za`, `typev`, `kurs`, `data_n`, `data_k`, `data`, `kvm`, `remov`, `emp`) VALUES
	(1, 1, 1, 1, '', '№86', 500, 24100, 11000, 0, 13100, '(USD)', 1, '2019-11-01', '2021-11-01', '2020-08-18 11:33:19', 48.2, 0, 15),
	(2, 1, 2, 7, '', '№87', 500, 20900, 7163, 0, 13737, '(USD)', 4, '2019-12-18', '2021-03-01', '2020-08-18 11:41:31', 41.8, 17, 15),
	(3, 1, 3, 6, '', '№90', 450, 17595, 12000, 0, 5595, '(USD)', 5, '2019-11-01', '2021-11-19', '2020-08-18 11:53:10', 39.1, 0, 15),
	(4, 1, 4, 7, '', '№87', 500, 20900, 7163, 0, 13737, '(USD)', 6, '2019-12-01', '2021-03-01', '2020-08-19 10:00:59', 41.8, 0, 17),
	(5, 1, 5, 3, '', '№71/10-2019 ', 530, 30475, 4000, 0, 26475, '(USD)', 7, '2019-11-20', '2022-02-20', '2020-08-19 10:07:00', 57.5, 0, 17),
	(6, 1, 6, 91, '', '№53/09 - 2019', 530, 26871, 7163, 0, 19708, '(USD)', 8, '2019-10-20', '2021-09-20', '2020-08-19 10:12:28', 50.7, 0, 17),
	(7, 1, 7, 86, '', '№90', 480, 18768, 9384, 0, 9384, '(USD)', 9, '2019-12-20', '2021-11-20', '2020-08-19 10:19:08', 39.1, 0, 17),
	(8, 1, 8, 89, '', '№ 55/09-2019', 450, 25875, 25875, 0, 0, '(USD)', 10, '2019-09-23', '2019-09-23', '2020-08-19 10:36:58', 57.5, 0, 17),
	(9, 1, 9, 88, '', '№ 07/29 -2019 ', 460, 38249, 19770, 0, 18479, '(USD)', 13, '2019-04-20', '2021-03-20', '2020-08-19 10:43:25', 83.15, 0, 17),
	(10, 1, 10, 98, '', '№ 43/09 - 2019', 500, 25350, 15064, 0, 10286, '(USD)', 14, '2019-10-20', '2022-03-20', '2020-08-19 10:49:23', 50.7, 0, 17),
	(11, 1, 11, 92, '', '№65/09 - 2019 ', 450, 17685, 11300, 0, 6385, '(USD)', 23, '2019-09-20', '2021-08-20', '2020-08-19 11:04:03', 39.3, 0, 17),
	(12, 1, 12, 93, '', '№ 131', 550, 21505, 21505, 0, 0, '(USD)', 24, '2020-03-13', '2020-03-13', '2020-08-19 11:07:20', 39.1, 0, 17),
	(13, 1, 13, 97, '', '№ 64/09 -2019', 450, 41332.5, 24730, 0, 16602.5, '(USD)', 25, '2019-10-20', '2021-03-20', '2020-08-19 11:11:25', 91.85, 0, 17),
	(14, 1, 14, 11, '', '№ 19/04-2019', 450, 37417.5, 18709, 0, 18708.5, '(USD)', 26, '2019-09-20', '2021-07-20', '2020-08-19 11:16:11', 83.15, 0, 17),
	(15, 1, 15, 10, '', '№35/06 - 2019', 500, 28750, 8500, 0, 20250, '(USD)', 27, '2019-07-20', '2021-06-20', '2020-08-19 11:20:27', 57.5, 0, 17),
	(16, 1, 16, 105, '', '№52/09 - 2019 ', 520, 26364, 5730, 0, 20634, '(USD)', 28, '2019-10-20', '2022-08-20', '2020-08-20 10:28:04', 50.7, 0, 17),
	(17, 1, 17, 20, '', '№59/09 - 2019', 460, 17986, 7951, 0, 10035, '(USD)', 29, '2019-10-20', '2021-09-20', '2020-08-20 10:31:40', 39.1, 0, 17),
	(18, 1, 18, 21, '', '№02', 480.19, 20071.942, 11000, 0, 9071.942, '(USD)', 30, '2019-03-20', '2020-02-20', '2020-08-20 10:40:04', 41.8, 0, 17),
	(19, 1, 19, 15, '', '№57/09 - 2019 ', 435, 20967, 12177, 0, 8790, '(USD)', 31, '2019-10-20', '2021-09-20', '2020-08-20 10:44:45', 48.2, 0, 17),
	(20, 1, 20, 18, '', '№119', 430, 35754.5, 32000, 0, 3754.5, '(USD)', 32, '2020-01-31', '2020-03-31', '2020-08-20 10:54:28', 83.15, 0, 17),
	(21, 1, 21, 107, '', '№90 ', 500, 19550, 7163, 0, 12387, '(USD)', 37, '2019-12-20', '2021-11-20', '2020-08-20 11:20:52', 39.1, 0, 17),
	(22, 1, 22, 27, '', '№ 66/10 - 2019', 500, 19550, 6000, 0, 13550, '(USD)', 38, '2019-11-20', '2021-11-20', '2020-08-20 11:26:18', 39.1, 0, 17),
	(23, 1, 23, 22, '', '№58/09 - 2019 ', 435, 20967, 12177, 0, 8790, '(USD)', 41, '2019-10-20', '2021-09-20', '2020-08-20 11:37:02', 48.2, 0, 17),
	(24, 1, 24, 25, '', '№127', 480, 39912, 39912, 0, 0, '(USD)', 42, '2020-02-20', '2020-02-20', '2020-08-20 11:46:15', 83.15, 0, 17),
	(25, 1, 26, 85, '', '48', 500, 19650, 5730, 0, 13920, '(USD)', 45, '2019-09-22', '2022-03-22', '2020-08-22 10:57:31', 39.3, 0, 15);
/*!40000 ALTER TABLE `zakaz` ENABLE KEYS */;

-- Дамп структуры для представление u_system._analis_cars
-- Создание временной таблицы для обработки ошибок зависимостей представлений
CREATE TABLE `_analis_cars` (
	`id` INT(11) NOT NULL,
	`name` VARCHAR(50) NULL COLLATE 'utf8_general_ci',
	`marka` CHAR(50) NULL COLLATE 'utf8_general_ci',
	`data` CHAR(50) NULL COLLATE 'utf8_general_ci',
	`A1` DOUBLE(22,0) NULL,
	`A2` DOUBLE(22,0) NULL,
	`pokup` VARCHAR(50) NULL COLLATE 'utf8_general_ci',
	`B1` DOUBLE(22,0) NULL,
	`B2` DOUBLE(22,0) NULL,
	`DATA2` CHAR(50) NULL COLLATE 'utf8_general_ci',
	`nomer` CHAR(50) NULL COLLATE 'utf8_general_ci',
	`condition_c` TEXT(65535) NULL COLLATE 'utf8_general_ci',
	`datatim` TIMESTAMP NULL
) ENGINE=MyISAM;

-- Дамп структуры для представление u_system._analis_dohod
-- Создание временной таблицы для обработки ошибок зависимостей представлений
CREATE TABLE `_analis_dohod` (
	`tabl` VARCHAR(10) NOT NULL COLLATE 'utf8mb4_general_ci',
	`class` VARCHAR(19) NOT NULL COLLATE 'utf8mb4_general_ci',
	`dom` MEDIUMTEXT NULL COLLATE 'utf8_general_ci',
	`n_prod` LONGTEXT NULL COLLATE 'utf8_general_ci',
	`client` LONGTEXT NULL COLLATE 'utf8_general_ci',
	`to_usd` DOUBLE(22,0) NULL,
	`Rto_kgs` DOUBLE(22,0) NULL,
	`data` DATETIME NULL,
	`emp` VARCHAR(50) NULL COLLATE 'utf8mb4_general_ci'
) ENGINE=MyISAM;

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

-- Дамп структуры для представление u_system._prihod
-- Создание временной таблицы для обработки ошибок зависимостей представлений
CREATE TABLE `_prihod` (
	`id` INT(11) NOT NULL,
	`operationU` MEDIUMTEXT NULL COLLATE 'utf8_general_ci',
	`organ` MEDIUMTEXT NULL COLLATE 'utf8_general_ci',
	`usd` DOUBLE(22,2) NULL,
	`kgs` DOUBLE(22,2) NULL,
	`data` TIMESTAMP NULL,
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
	`d_kgs` DOUBLE(19,2) NULL,
	`data_n` DATE NULL,
	`data_k` DATE NULL,
	`dom_id` INT(11) NULL,
	`klient_id` INT(11) NULL,
	`cars_id` MEDIUMTEXT NULL COLLATE 'utf8_general_ci',
	`cars1` VARCHAR(5) NOT NULL COLLATE 'utf8mb4_general_ci',
	`emp` VARCHAR(50) NULL COLLATE 'utf8mb4_general_ci'
) ENGINE=MyISAM;

-- Дамп структуры для представление u_system._repayment_flat
-- Создание временной таблицы для обработки ошибок зависимостей представлений
CREATE TABLE `_repayment_flat` (
	`id` INT(11) NOT NULL,
	`name` TEXT(65535) NULL COLLATE 'utf8_general_ci',
	`number_f` INT(11) NOT NULL,
	`client` VARCHAR(50) NULL COLLATE 'utf8_general_ci',
	`summa` DOUBLE(22,0) NULL,
	`usd` DOUBLE(22,0) NULL,
	`data_month` DATE NULL,
	`data` TIMESTAMP NULL,
	`emp` VARCHAR(50) NULL COLLATE 'utf8mb4_general_ci',
	`dom_id` INT(11) NOT NULL
) ENGINE=MyISAM;

-- Дамп структуры для представление u_system._repayment_parking
-- Создание временной таблицы для обработки ошибок зависимостей представлений
CREATE TABLE `_repayment_parking` (
	`id` INT(11) NOT NULL,
	`name` TEXT(65535) NULL COLLATE 'utf8_general_ci',
	`number_f` INT(11) NOT NULL,
	`client` VARCHAR(50) NULL COLLATE 'utf8_general_ci',
	`summa` DOUBLE(22,0) NULL,
	`usd` DOUBLE(22,0) NULL,
	`data_month` DATE NULL,
	`data` TIMESTAMP NULL,
	`emp` VARCHAR(50) NULL COLLATE 'utf8mb4_general_ci',
	`dom_id` INT(11) NOT NULL
) ENGINE=MyISAM;

-- Дамп структуры для представление u_system._search_dahod
-- Создание временной таблицы для обработки ошибок зависимостей представлений
CREATE TABLE `_search_dahod` (
	`tabl` VARCHAR(10) NOT NULL COLLATE 'utf8mb4_general_ci',
	`class` VARCHAR(19) NOT NULL COLLATE 'utf8mb4_general_ci',
	`dom` MEDIUMTEXT NULL COLLATE 'utf8_general_ci',
	`n_prod` LONGTEXT NULL COLLATE 'utf8_general_ci',
	`client` LONGTEXT NULL COLLATE 'utf8_general_ci',
	`to_usd` DOUBLE(22,0) NULL,
	`Rto_kgs` DOUBLE(22,0) NULL,
	`data` DATETIME NULL,
	`emp` VARCHAR(50) NULL COLLATE 'utf8mb4_general_ci'
) ENGINE=MyISAM;

-- Дамп структуры для представление u_system._zakaz_otchot
-- Создание временной таблицы для обработки ошибок зависимостей представлений
CREATE TABLE `_zakaz_otchot` (
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
	`usd` DOUBLE(23,0) NULL,
	`kgs` DOUBLE(23,0) NULL,
	`data_n` DATE NULL,
	`data_k` DATE NULL,
	`klient_id` INT(11) NULL,
	`cars_id` TEXT(65535) NULL COLLATE 'utf8_general_ci',
	`dom_id` INT(11) NULL,
	`name` VARCHAR(50) NULL COLLATE 'utf8mb4_general_ci'
) ENGINE=MyISAM;

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

-- Дамп структуры для представление u_system._analis_cars
-- Удаление временной таблицы и создание окончательной структуры представления
DROP TABLE IF EXISTS `_analis_cars`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `_analis_cars` AS select `c`.`id` AS `id`,`cl`.`name` AS `name`,`c`.`marka` AS `marka`,`c`.`data` AS `data`,if((`c`.`type_v` = '(KGS)'),round((`c`.`prih_summ` / (select `cur`.`usd` from `currency` `cur` where (`cur`.`id` = `c`.`kurs`))),2),`c`.`prih_summ`) AS `A1`,if((`c`.`type_v` = '(USD)'),round((`c`.`prih_summ` * (select `cur`.`usd` from `currency` `cur` where (`cur`.`id` = `c`.`kurs`))),2),`c`.`prih_summ`) AS `A2`,(select `cc`.`name` from `client` `cc` where (`cc`.`id` = `p`.`client_id`)) AS `pokup`,if((`p`.`typev` = '(KGS)'),round((`p`.`price` / (select `cur`.`usd` from `currency` `cur` where (`cur`.`id` = `p`.`curren_id`))),2),`p`.`price`) AS `B1`,if((`p`.`typev` = '(USD)'),round((`p`.`price` * (select `cur`.`usd` from `currency` `cur` where (`cur`.`id` = `p`.`curren_id`))),2),`p`.`price`) AS `B2`,`c`.`data` AS `DATA2`,`c`.`nomer` AS `nomer`,`c`.`condition_c` AS `condition_c`,`c`.`datatim` AS `datatim` from ((`cars` `c` join `client` `cl` on(((`c`.`client_id` = `cl`.`id`) and (`c`.`remov` = '0')))) left join `prod_cars` `p` on((`c`.`id` = `p`.`cars_id`))) order by `c`.`id`;

-- Дамп структуры для представление u_system._analis_dohod
-- Удаление временной таблицы и создание окончательной структуры представления
DROP TABLE IF EXISTS `_analis_dohod`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `_analis_dohod` AS select 'prodbclass' AS `tabl`,'Проджа бизнес класс' AS `class`,`d`.`name` AS `dom`,`b`.`name` AS `n_prod`,`cl`.`name` AS `client`,if((`p`.`typev` = '(KGS)'),round((`p`.`summ` / `cur`.`usd`),2),`p`.`summ`) AS `to_usd`,if((`p`.`typev` = '(USD)'),round((`p`.`summ` * `cur`.`usd`),2),`p`.`summ`) AS `Rto_kgs`,`p`.`data` AS `data`,`u`.`name` AS `emp` from (((((`prodbclass` `p` join `currency` `cur`) join `bisnesclass` `b`) join `dom` `d`) join `client` `cl`) join `users` `u` on(((`p`.`kurs` = `cur`.`id`) and (`p`.`summ` > 0) and (`p`.`emp` = `u`.`id`) and (`p`.`remov` = '0') and (`b`.`id` = `p`.`number_id`) and (`b`.`dom_id` = `d`.`id`) and (`cl`.`id` = `p`.`client_id`) and (month(`p`.`data`) = month(now())) and (year(`p`.`data`) = year(now()))))) union select 'prod_cars' AS `tabl`,'Продажа машина' AS `class`,' ' AS `dom`,`c`.`marka` AS `n_prod`,`cl`.`name` AS `client`,if((`pr`.`typev` = '(KGS)'),round((`pr`.`price` / `cur`.`usd`),2),`pr`.`price`) AS `to_usd`,if((`pr`.`typev` = '(USD)'),round((`pr`.`price` * `cur`.`usd`),2),`pr`.`price`) AS `Rto_kgs`,`pr`.`data` AS `data`,`u`.`name` AS `emp` from ((((`prod_cars` `pr` join `currency` `cur`) join `cars` `c`) join `client` `cl`) join `users` `u` on(((`pr`.`curren_id` = `cur`.`id`) and (`pr`.`price` > 0) and (`pr`.`cars_id` = `c`.`id`) and (`pr`.`client_id` = `cl`.`id`) and (`pr`.`remov` = '0') and (`pr`.`employee_id` = `c`.`id`) and (month(`pr`.`data`) = month(now())) and (year(`pr`.`data`) = year(now()))))) union select 'parking' AS `tabl`,'Парковка' AS `class`,`d`.`name` AS `dom`,`par`.`number` AS `n_prod`,`cl`.`name` AS `client`,if((`par`.`typev` = '(KGS)'),round((`par`.`zadol` / `cur`.`usd`),2),`par`.`zadol`) AS `to_usd`,if((`par`.`typev` = '(USD)'),round((`par`.`zadol` * `cur`.`usd`),2),`par`.`zadol`) AS `Rto_kgs`,`par`.`data` AS `data`,`u`.`name` AS `emp` from ((((`parking` `par` join `currency` `cur`) join `dom` `d`) join `client` `cl`) join `users` `u` on(((`par`.`curr_id` = `cur`.`id`) and (`par`.`zadol` > 0) and (`d`.`id` = `par`.`dom_id`) and (`par`.`client_id` = `cl`.`id`) and (`par`.`emp` = `u`.`id`) and (`par`.`remov` = '0') and (month(`par`.`data`) = month(now())) and (year(`par`.`data`) = year(now()))))) union select 'repayment' AS `tabl`,'Платеж дом' AS `class`,`d`.`name` AS `dom`,`r`.`number_f` AS `n_prod`,`cl`.`name` AS `client`,`r`.`summa` AS `summa`,`r`.`usd` AS `usd`,`r`.`data` AS `data`,`u`.`name` AS `emp` from (((`repayment` `r` join `dom` `d`) join `client` `cl`) join `users` `u` on(((`r`.`dom_id` = `d`.`id`) and (`r`.`client_id` = `cl`.`id`) and (`r`.`emp` = `u`.`id`) and (`r`.`remov` = '0') and (month(`r`.`data`) = month(now())) and (year(`r`.`data`) = year(now()))))) union select 'repayment' AS `tabl`,'Платеж паркинг' AS `class`,`d`.`name` AS `dom`,`r`.`number_f` AS `n_prod`,`cl`.`name` AS `client`,`r`.`summa` AS `summa`,`r`.`usd` AS `usd`,`r`.`data` AS `data`,`u`.`name` AS `emp` from (((`repayment_parking` `r` join `dom` `d`) join `client` `cl`) join `users` `u` on(((`r`.`dom_id` = `d`.`id`) and (`r`.`client_id` = `cl`.`id`) and (`r`.`emp` = `u`.`id`) and (`r`.`remov` = '0') and (month(`r`.`data`) = month(now())) and (year(`r`.`data`) = year(now()))))) union select 'prihod' AS `tabl`,'Наличный' AS `class`,' ' AS `dom`,`pri`.`operationU` AS `n_prod`,`pri`.`organ` AS `client`,if((`pri`.`typev` = '(KGS)'),round((`pri`.`summa` / `cur`.`usd`),2),`pri`.`summa`) AS `to_usd`,if((`pri`.`typev` = '(USD)'),round((`pri`.`summa` * `cur`.`usd`),2),`pri`.`summa`) AS `Rto_kgs`,`pri`.`data` AS `data`,`u`.`name` AS `emp` from ((`prihod` `pri` join `currency` `cur`) join `users` `u` on(((`pri`.`kurs` = `cur`.`id`) and (`pri`.`emp` = `u`.`id`) and (`pri`.`summa` > 0) and (`pri`.`remov` = '0') and (month(`pri`.`data`) = month(now())) and (year(`pri`.`data`) = year(now())))));

-- Дамп структуры для представление u_system._graf_parking
-- Удаление временной таблицы и создание окончательной структуры представления
DROP TABLE IF EXISTS `_graf_parking`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `_graf_parking` AS select `z`.`id` AS `id`,if((`z`.`typev` = '(KGS)'),round((`z`.`price` / `cur`.`usd`),2),`z`.`price`) AS `to_usd`,if((`z`.`typev` = '(USD)'),round((`z`.`price` * `cur`.`usd`),2),`z`.`price`) AS `Rto_kgs`,if((`z`.`typev` = '(KGS)'),round((`z`.`vznos` / `cur`.`usd`),2),`z`.`vznos`) AS `vznosu`,if((`z`.`typev` = '(USD)'),round((`z`.`vznos` * `cur`.`usd`),2),`z`.`vznos`) AS `vznosk`,if((`z`.`typev` = '(KGS)'),round((`z`.`debu_za` / `cur`.`usd`),2),`z`.`debu_za`) AS `debu`,if((`z`.`typev` = '(USD)'),round((`z`.`debu_za` * `cur`.`usd`),2),`z`.`debu_za`) AS `debk`,if((`z`.`typev` = '(KGS)'),round((`z`.`cars_summ` / `cur`.`usd`),2),`z`.`cars_summ`) AS `cars_usd`,if((`z`.`typev` = '(USD)'),round((`z`.`cars_summ` * `cur`.`usd`),2),`z`.`cars_summ`) AS `cars_kgs`,timestampdiff(MONTH,`z`.`data_n`,`z`.`data_k`) AS `CountData`,dayofmonth(`z`.`data_n`) AS `d1`,month(`z`.`data_n`) AS `m1`,year(`z`.`data_n`) AS `y1`,dayofmonth(`z`.`data_k`) AS `d2`,month(`z`.`data_k`) AS `m2`,year(`z`.`data_k`) AS `y2` from (`prod_parking` `z` join `currency` `cur` on((`z`.`kurs` = `cur`.`id`)));

-- Дамп структуры для представление u_system._otchet_bclass
-- Удаление временной таблицы и создание окончательной структуры представления
DROP TABLE IF EXISTS `_otchet_bclass`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `_otchet_bclass` AS select `p`.`id` AS `id`,(select `dom`.`name` from `dom` where (`b`.`dom_id` = `dom`.`id`)) AS `dom`,`b`.`name` AS `name`,(select `client`.`name` from `client` where (`client`.`id` = `p`.`client_id`)) AS `contragent`,if((`p`.`typev` = '(KGS)'),round((`p`.`summ` / `cur`.`usd`),2),`p`.`summ`) AS `usd`,if((`p`.`typev` = '(USD)'),round((`p`.`summ` * `cur`.`usd`),2),`p`.`summ`) AS `kgs`,`p`.`data` AS `data`,(select `users`.`name` from `users` where (`users`.`id` = `p`.`emp`)) AS `emp` from ((`prodbclass` `p` join `currency` `cur`) join `bisnesclass` `b` on(((`p`.`kurs` = `cur`.`id`) and (`p`.`summ` > 0) and (`p`.`remov` = '0') and (`p`.`number_id` = `b`.`id`))));

-- Дамп структуры для представление u_system._prihod
-- Удаление временной таблицы и создание окончательной структуры представления
DROP TABLE IF EXISTS `_prihod`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `_prihod` AS select `p`.`id` AS `id`,`p`.`operationU` AS `operationU`,`p`.`organ` AS `organ`,if((`p`.`typev` = '(KGS)'),round((`p`.`summa` / `cur`.`usd`),2),`p`.`summa`) AS `usd`,if((`p`.`typev` = '(USD)'),round((`p`.`summa` * `cur`.`usd`),2),`p`.`summa`) AS `kgs`,`p`.`data` AS `data`,`u`.`name` AS `emp` from ((`prihod` `p` join `currency` `cur`) join `users` `u` on(((`p`.`kurs` = `cur`.`id`) and (`p`.`emp` = `u`.`id`))));

-- Дамп структуры для представление u_system._prod_parking
-- Удаление временной таблицы и создание окончательной структуры представления
DROP TABLE IF EXISTS `_prod_parking`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `_prod_parking` AS select `p`.`id` AS `id`,`p`.`number_f` AS `number_f`,`c`.`name` AS `name`,if((`p`.`typev` = '(KGS)'),round((`p`.`price` / `cur`.`usd`),2),`p`.`price`) AS `usd`,if((`p`.`typev` = '(USD)'),round((`p`.`price` * `cur`.`usd`),2),`p`.`price`) AS `kgs`,(if((`p`.`typev` = '(KGS)'),round((`p`.`debu_za` / `cur`.`usd`),2),`p`.`debu_za`) - (select if(isnull(sum(`r`.`usd`)),0,sum(`r`.`usd`)) from `repayment_parking` `r` where ((`p`.`dom_id` = `r`.`dom_id`) and (`r`.`number_f` = `p`.`number_f`) and (`r`.`remov` = '0')))) AS `d_usd`,(if((`p`.`typev` = '(USD)'),round((`p`.`debu_za` * `cur`.`usd`),2),`p`.`debu_za`) - (select if(isnull(sum(`r`.`summa`)),0,sum(`r`.`summa`)) from `repayment_parking` `r` where ((`p`.`dom_id` = `r`.`dom_id`) and (`r`.`number_f` = `p`.`number_f`) and (`r`.`remov` = '0')))) AS `d_kgs`,`p`.`data_n` AS `data_n`,`p`.`data_k` AS `data_k`,`p`.`dom_id` AS `dom_id`,`p`.`klient_id` AS `klient_id`,`p`.`cars_id` AS `cars_id`,if((`p`.`cars_id` = ''),' ','Имеит') AS `cars1`,`u`.`name` AS `emp` from (((`prod_parking` `p` join `currency` `cur`) join `client` `c`) join `users` `u` on(((`p`.`kurs` = `cur`.`id`) and (`p`.`klient_id` = `c`.`id`) and (`p`.`emp` = `u`.`id`) and (`p`.`remov` = '0'))));

-- Дамп структуры для представление u_system._repayment_flat
-- Удаление временной таблицы и создание окончательной структуры представления
DROP TABLE IF EXISTS `_repayment_flat`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `_repayment_flat` AS select `p`.`id` AS `id`,`d`.`name` AS `name`,`p`.`number_f` AS `number_f`,`c`.`name` AS `client`,`p`.`summa` AS `summa`,`p`.`usd` AS `usd`,`p`.`data_month` AS `data_month`,`p`.`data` AS `data`,`u`.`name` AS `emp`,`p`.`dom_id` AS `dom_id` from (((`repayment` `p` join `client` `c`) join `dom` `d`) join `users` `u` on(((`p`.`client_id` = `c`.`id`) and (`p`.`dom_id` = `d`.`id`) and (`p`.`remov` = '0') and (`p`.`emp` = `u`.`id`))));

-- Дамп структуры для представление u_system._repayment_parking
-- Удаление временной таблицы и создание окончательной структуры представления
DROP TABLE IF EXISTS `_repayment_parking`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `_repayment_parking` AS select `p`.`id` AS `id`,`d`.`name` AS `name`,`p`.`number_f` AS `number_f`,`c`.`name` AS `client`,`p`.`summa` AS `summa`,`p`.`usd` AS `usd`,`p`.`data_month` AS `data_month`,`p`.`data` AS `data`,`u`.`name` AS `emp`,`p`.`dom_id` AS `dom_id` from (((`repayment_parking` `p` join `client` `c`) join `dom` `d`) join `users` `u` on(((`p`.`client_id` = `c`.`id`) and (`p`.`dom_id` = `d`.`id`) and (`p`.`remov` = '0') and (`p`.`emp` = `u`.`id`))));

-- Дамп структуры для представление u_system._search_dahod
-- Удаление временной таблицы и создание окончательной структуры представления
DROP TABLE IF EXISTS `_search_dahod`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `_search_dahod` AS select 'prodbclass' AS `tabl`,'Проджа бизнес класс' AS `class`,`d`.`name` AS `dom`,`b`.`name` AS `n_prod`,`cl`.`name` AS `client`,if((`p`.`typev` = '(KGS)'),round((`p`.`summ` / `cur`.`usd`),2),`p`.`summ`) AS `to_usd`,if((`p`.`typev` = '(USD)'),round((`p`.`summ` * `cur`.`usd`),2),`p`.`summ`) AS `Rto_kgs`,`p`.`data` AS `data`,`u`.`name` AS `emp` from (((((`prodbclass` `p` join `currency` `cur`) join `bisnesclass` `b`) join `dom` `d`) join `client` `cl`) join `users` `u` on(((`p`.`kurs` = `cur`.`id`) and (`p`.`summ` > 0) and (`p`.`emp` = `u`.`id`) and (`p`.`remov` = '0') and (`b`.`id` = `p`.`number_id`) and (`b`.`dom_id` = `d`.`id`) and (`cl`.`id` = `p`.`client_id`)))) union select 'prod_cars' AS `tabl`,'Продажа машина' AS `class`,' ' AS `dom`,`c`.`marka` AS `n_prod`,`cl`.`name` AS `client`,if((`pr`.`typev` = '(KGS)'),round((`pr`.`price` / `cur`.`usd`),2),`pr`.`price`) AS `to_usd`,if((`pr`.`typev` = '(USD)'),round((`pr`.`price` * `cur`.`usd`),2),`pr`.`price`) AS `Rto_kgs`,`pr`.`data` AS `data`,`u`.`name` AS `emp` from ((((`prod_cars` `pr` join `currency` `cur`) join `cars` `c`) join `client` `cl`) join `users` `u` on(((`pr`.`curren_id` = `cur`.`id`) and (`pr`.`price` > 0) and (`pr`.`cars_id` = `c`.`id`) and (`pr`.`client_id` = `cl`.`id`) and (`pr`.`remov` = '0')))) union select 'parking' AS `tabl`,'Парковка' AS `class`,`d`.`name` AS `dom`,`par`.`number` AS `n_prod`,`cl`.`name` AS `client`,if((`par`.`typev` = '(KGS)'),round((`par`.`zadol` / `cur`.`usd`),2),`par`.`zadol`) AS `to_usd`,if((`par`.`typev` = '(USD)'),round((`par`.`zadol` * `cur`.`usd`),2),`par`.`zadol`) AS `Rto_kgs`,`par`.`data` AS `data`,`u`.`name` AS `emp` from ((((`parking` `par` join `currency` `cur`) join `dom` `d`) join `client` `cl`) join `users` `u` on(((`par`.`curr_id` = `cur`.`id`) and (`par`.`zadol` > 0) and (`d`.`id` = `par`.`dom_id`) and (`par`.`client_id` = `cl`.`id`) and (`par`.`emp` = `u`.`id`) and (`par`.`remov` = '0')))) union select 'repayment' AS `tabl`,'Платеж дом' AS `class`,`d`.`name` AS `dom`,`r`.`number_f` AS `n_prod`,`cl`.`name` AS `client`,`r`.`summa` AS `summa`,`r`.`usd` AS `usd`,`r`.`data` AS `data`,`u`.`name` AS `emp` from (((`repayment` `r` join `dom` `d`) join `client` `cl`) join `users` `u` on(((`r`.`dom_id` = `d`.`id`) and (`r`.`client_id` = `cl`.`id`) and (`r`.`emp` = `u`.`id`) and (`r`.`remov` = '0') and (month(`r`.`data`) = month(now())) and (year(`r`.`data`) = year(now()))))) union select 'repayment' AS `tabl`,'Платеж паркинг' AS `class`,`d`.`name` AS `dom`,`r`.`number_f` AS `n_prod`,`cl`.`name` AS `client`,`r`.`summa` AS `summa`,`r`.`usd` AS `usd`,`r`.`data` AS `data`,`u`.`name` AS `emp` from (((`repayment_parking` `r` join `dom` `d`) join `client` `cl`) join `users` `u` on(((`r`.`dom_id` = `d`.`id`) and (`r`.`client_id` = `cl`.`id`) and (`r`.`emp` = `u`.`id`) and (`r`.`remov` = '0')))) union select 'prihod' AS `tabl`,'Наличный' AS `class`,' ' AS `dom`,`pri`.`operationU` AS `n_prod`,`pri`.`organ` AS `client`,if((`pri`.`typev` = '(KGS)'),round((`pri`.`summa` / `cur`.`usd`),2),`pri`.`summa`) AS `to_usd`,if((`pri`.`typev` = '(USD)'),round((`pri`.`summa` * `cur`.`usd`),2),`pri`.`summa`) AS `Rto_kgs`,`pri`.`data` AS `data`,`u`.`name` AS `emp` from ((`prihod` `pri` join `currency` `cur`) join `users` `u` on(((`pri`.`kurs` = `cur`.`id`) and (`pri`.`emp` = `u`.`id`) and (`pri`.`summa` > 0) and (`pri`.`remov` = '0'))));

-- Дамп структуры для представление u_system._zakaz_otchot
-- Удаление временной таблицы и создание окончательной структуры представления
DROP TABLE IF EXISTS `_zakaz_otchot`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `_zakaz_otchot` AS select `f`.`remov` AS `remov`,`z`.`id` AS `Zid`,`f`.`id` AS `id`,`f`.`number_f` AS `number_f`,`f`.`floor` AS `floor`,`f`.`porch` AS `porch`,(select sum(`type_flat`.`kvm`) from `type_flat` where ((`type_flat`.`dom_id` = `f`.`dom_id`) and (`type_flat`.`porch` = `f`.`porch`) and (`type_flat`.`type` = `f`.`type_flat`) and (`type_flat`.`room` = `f`.`room`))) AS `kvm`,`z`.`contract` AS `contract`,(case when ((select `b`.`id` from `bron` `b` where ((`b`.`dom_id` = `f`.`dom_id`) and (`b`.`number_f` = `f`.`number_f`) and (`b`.`remov` = 0))) > 0) then 'Бронированно' when ((select `e`.`id` from `exchange` `e` where ((`e`.`dom_id` = `f`.`dom_id`) and (`e`.`number_f` = `f`.`number_f`) and (`e`.`remov` = 0))) > 0) then 'Обмен' else (select `c`.`name` from `client` `c` where (`c`.`id` = `z`.`klient_id`)) end) AS `client`,if((`z`.`cars_id` <> ''),'Имеиит','') AS `Cars`,if((`z`.`typev` = '(KGS)'),round((`z`.`itog_price` / `cur`.`usd`),2),`z`.`itog_price`) AS `to_usd`,if((`z`.`typev` = '(USD)'),round((`z`.`itog_price` * `cur`.`usd`),2),`z`.`itog_price`) AS `Rto_kgs`,(if((`z`.`typev` = '(KGS)'),round((`z`.`debu_za` / `cur`.`usd`),2),`z`.`debu_za`) - (select if(isnull(sum(`rep`.`usd`)),0,sum(`rep`.`usd`)) from `repayment` `rep` where ((`rep`.`dom_id` = `z`.`dom_id`) and (`rep`.`number_f` = `z`.`number_f`)))) AS `usd`,(if((`z`.`typev` = '(USD)'),round((`z`.`debu_za` * `cur`.`usd`),2),`z`.`debu_za`) - (select if(isnull(sum(`rep`.`summa`)),0,sum(`rep`.`summa`)) from `repayment` `rep` where ((`rep`.`dom_id` = `z`.`dom_id`) and (`rep`.`number_f` = `z`.`number_f`)))) AS `kgs`,`z`.`data_n` AS `data_n`,`z`.`data_k` AS `data_k`,`z`.`klient_id` AS `klient_id`,`z`.`cars_id` AS `cars_id`,`f`.`dom_id` AS `dom_id`,`u`.`name` AS `name` from (`flat` `f` left join ((`zakaz` `z` join `currency` `cur`) join `users` `u`) on(((`f`.`dom_id` = `z`.`dom_id`) and (`f`.`number_f` = `z`.`number_f`) and (`z`.`kurs` = `cur`.`id`) and (`z`.`remov` = 0) and (`z`.`emp` = `u`.`id`)))) order by `f`.`number_f`;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
