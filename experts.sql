CREATE DATABASE  IF NOT EXISTS `experts` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `experts`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: experts
-- ------------------------------------------------------
-- Server version	5.5.59

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `calculations_description`
--

DROP TABLE IF EXISTS `calculations_description`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `calculations_description` (
  `calculation_number` int(11) NOT NULL,
  `calculation_name` varchar(250) DEFAULT NULL,
  `description_of_calculation` varchar(500) DEFAULT NULL,
  `issue_id` int(11) DEFAULT NULL,
  `id_of_expert` int(11) NOT NULL,
  PRIMARY KEY (`calculation_number`,`id_of_expert`),
  UNIQUE KEY `calculation_name_UNIQUE` (`calculation_name`),
  KEY `fk_issue_id_idx` (`issue_id`),
  KEY `fk_id_of_exp_calc_desc_idx` (`id_of_expert`),
  CONSTRAINT `fk_id_of_exp_calc_desc` FOREIGN KEY (`id_of_expert`) REFERENCES `expert` (`id_of_expert`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_issue_id` FOREIGN KEY (`issue_id`) REFERENCES `issues` (`issue_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `calculations_description`
--

LOCK TABLES `calculations_description` WRITE;
/*!40000 ALTER TABLE `calculations_description` DISABLE KEYS */;
INSERT INTO `calculations_description` VALUES (1,'a1','b1',12,1),(1,'Княжичі (медик)','b3',12,3),(2,'Княжичі (економіст)','тестетс',12,1),(2,'a31','b31',12,3);
/*!40000 ALTER TABLE `calculations_description` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `calculations_result`
--

DROP TABLE IF EXISTS `calculations_result`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `calculations_result` (
  `calculation_number` int(11) NOT NULL,
  `date_of_calculation` datetime DEFAULT NULL,
  `id_of_formula` int(11) NOT NULL,
  `result` double DEFAULT NULL,
  `id_of_expert` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`calculation_number`,`id_of_formula`,`id_of_expert`),
  KEY `fk_formula2_id_idx` (`id_of_formula`),
  KEY `fk_id_of_exp_calc_res_idx` (`id_of_expert`),
  CONSTRAINT `fk_calc_numb_desc` FOREIGN KEY (`calculation_number`) REFERENCES `calculations_description` (`calculation_number`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_id_of_exp_calc_res` FOREIGN KEY (`id_of_expert`) REFERENCES `expert` (`id_of_expert`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_id_of_formula` FOREIGN KEY (`id_of_formula`) REFERENCES `formulas` (`id_of_formula`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `calculations_result`
--

LOCK TABLES `calculations_result` WRITE;
/*!40000 ALTER TABLE `calculations_result` DISABLE KEYS */;
INSERT INTO `calculations_result` VALUES (1,'2018-05-09 17:09:29',1,0,1),(1,'2018-05-09 17:04:51',6,12,3),(2,'2018-05-10 16:22:03',7,1189760.4,1),(2,'2018-05-04 13:32:54',15,9,1),(2,'2018-05-09 17:04:51',16,0,1);
/*!40000 ALTER TABLE `calculations_result` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `event`
--

DROP TABLE IF EXISTS `event`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `event` (
  `event_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `description` varchar(100) DEFAULT NULL,
  `lawyer_vefirication` tinyint(4) DEFAULT NULL,
  `dm_verification` tinyint(4) DEFAULT NULL,
  `id_of_user` int(11) DEFAULT NULL,
  `issue_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`event_id`),
  KEY `userid_fk_idx` (`id_of_user`),
  KEY `issue_id_fk_idx` (`issue_id`),
  CONSTRAINT `issue_id_fk` FOREIGN KEY (`issue_id`) REFERENCES `issues` (`issue_id`) ON DELETE SET NULL ON UPDATE SET NULL,
  CONSTRAINT `userid_fk` FOREIGN KEY (`id_of_user`) REFERENCES `user` (`id_of_user`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event`
--

LOCK TABLES `event` WRITE;
/*!40000 ALTER TABLE `event` DISABLE KEYS */;
INSERT INTO `event` VALUES (1,'Zahid','zag',NULL,NULL,5,12);
/*!40000 ALTER TABLE `event` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `event_documents`
--

DROP TABLE IF EXISTS `event_documents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `event_documents` (
  `event_id` int(11) NOT NULL,
  `document_code` varchar(100) NOT NULL,
  `description` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`event_id`,`document_code`),
  CONSTRAINT `eventid_fk` FOREIGN KEY (`event_id`) REFERENCES `event` (`event_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event_documents`
--

LOCK TABLES `event_documents` WRITE;
/*!40000 ALTER TABLE `event_documents` DISABLE KEYS */;
/*!40000 ALTER TABLE `event_documents` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `event_resource`
--

DROP TABLE IF EXISTS `event_resource`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `event_resource` (
  `resource_id` int(11) NOT NULL,
  `event_id` int(11) NOT NULL,
  `value` int(11) DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`resource_id`,`event_id`),
  KEY `event_id` (`event_id`),
  CONSTRAINT `event_resource_ibfk_1` FOREIGN KEY (`resource_id`) REFERENCES `resource` (`resource_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `event_resource_ibfk_2` FOREIGN KEY (`event_id`) REFERENCES `event` (`event_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event_resource`
--

LOCK TABLES `event_resource` WRITE;
/*!40000 ALTER TABLE `event_resource` DISABLE KEYS */;
INSERT INTO `event_resource` VALUES (4,1,200,'na lechenie');
/*!40000 ALTER TABLE `event_resource` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `event_template`
--

DROP TABLE IF EXISTS `event_template`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `event_template` (
  `template_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `description` varchar(100) DEFAULT NULL,
  `expert_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`template_id`),
  KEY `expert_id_fk_idx` (`expert_id`),
  CONSTRAINT `expert_id_fk` FOREIGN KEY (`expert_id`) REFERENCES `expert` (`id_of_expert`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event_template`
--

LOCK TABLES `event_template` WRITE;
/*!40000 ALTER TABLE `event_template` DISABLE KEYS */;
/*!40000 ALTER TABLE `event_template` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `expert`
--

DROP TABLE IF EXISTS `expert`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `expert` (
  `id_of_expert` int(11) NOT NULL,
  `expert_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_of_expert`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `expert`
--

LOCK TABLES `expert` WRITE;
/*!40000 ALTER TABLE `expert` DISABLE KEYS */;
INSERT INTO `expert` VALUES (0,'Адміністратор'),(1,'Економіст'),(2,'Еколог'),(3,'Медик'),(4,'Юрист'),(5,'Аналітик');
/*!40000 ALTER TABLE `expert` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `formula_compound`
--

DROP TABLE IF EXISTS `formula_compound`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `formula_compound` (
  `id_of_formula` int(11) NOT NULL,
  `id_of_parameter` int(11) NOT NULL,
  `id_of_expert` int(11) NOT NULL,
  PRIMARY KEY (`id_of_formula`,`id_of_parameter`,`id_of_expert`),
  KEY `fk_parameter_id_idx` (`id_of_parameter`),
  KEY `formula_compound_expert_id_of_expert_fk` (`id_of_expert`),
  CONSTRAINT `formula_compound_expert_id_of_expert_fk` FOREIGN KEY (`id_of_expert`) REFERENCES `expert` (`id_of_expert`),
  CONSTRAINT `formula_compound_formulas_id_of_formula_fk` FOREIGN KEY (`id_of_formula`) REFERENCES `formulas` (`id_of_formula`),
  CONSTRAINT `formula_compound_formula_parameters_id_of_parameter_fk` FOREIGN KEY (`id_of_parameter`) REFERENCES `formula_parameters` (`id_of_parameter`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `formula_compound`
--

LOCK TABLES `formula_compound` WRITE;
/*!40000 ALTER TABLE `formula_compound` DISABLE KEYS */;
INSERT INTO `formula_compound` VALUES (4,0,1),(5,0,1),(6,0,1),(11,0,1),(12,0,1),(13,0,1),(15,0,1),(16,0,1),(18,0,1),(19,0,1),(20,0,1),(21,0,1),(23,0,1),(24,0,1),(44,0,1),(1,1,1),(1,1,3),(1,2,1),(1,2,3),(1,3,1),(2,3,3),(2,4,1),(2,4,3),(2,5,1),(2,5,3),(2,6,1),(3,6,3),(2,7,1),(3,7,3),(3,8,1),(3,8,3),(3,9,1),(3,9,3),(3,10,1),(4,10,3),(5,10,3),(4,11,1),(4,11,3),(5,11,1),(5,11,3),(6,11,1),(4,12,1),(5,12,1),(6,12,1),(6,12,3),(6,13,3),(6,14,3),(7,14,3),(6,15,3),(7,15,3),(7,16,3),(7,17,3),(14,17,1),(8,18,3),(9,18,3),(14,18,1),(10,19,3),(11,19,3),(14,19,1),(10,20,3),(11,20,3),(14,20,1),(10,21,3),(14,21,1),(10,22,3),(14,22,1),(15,23,1),(16,23,1),(15,25,1),(16,25,1),(15,28,1),(16,28,1),(17,30,1),(17,31,1),(18,32,1),(18,33,1),(19,33,1),(21,33,1),(19,35,1),(20,35,1),(20,36,1),(20,37,1),(20,38,1),(20,40,1),(21,41,1),(25,49,1),(25,50,1),(26,51,1),(26,52,1),(27,54,1),(27,55,1),(27,56,1),(28,57,1),(28,58,1),(8,59,1),(8,60,1),(8,61,1),(9,63,1),(9,64,1),(9,65,1),(9,66,1),(9,67,1),(9,68,1),(9,69,1),(10,70,1),(10,71,1),(10,72,1),(11,73,1),(11,74,1),(11,75,1),(11,76,1),(11,77,1),(11,78,1),(11,79,1),(11,80,1),(12,81,1),(12,82,1),(13,83,1),(13,84,1),(7,85,1),(7,86,1),(7,87,1),(7,88,1),(7,89,1),(22,90,1),(22,91,1),(24,92,1),(24,93,1),(24,94,1),(24,95,1),(23,96,1),(23,97,1),(29,99,1),(29,100,1),(29,101,1),(30,102,1),(30,103,1),(30,104,1),(31,105,1),(31,106,1),(31,107,1),(32,108,1),(32,109,1),(32,110,1),(32,111,1),(33,112,1),(33,113,1),(33,114,1),(33,115,1),(33,116,1),(33,117,1),(34,118,1),(34,119,1),(34,120,1),(34,121,1),(34,122,1),(34,123,1),(34,124,1),(35,125,1),(35,126,1),(39,126,1),(35,127,1),(35,128,1),(35,129,1),(35,130,1),(36,131,1),(36,133,1),(36,134,1),(36,135,1),(36,136,1),(36,137,1),(37,138,1),(37,139,1),(37,140,1),(37,141,1),(37,142,1),(38,143,1),(38,144,1),(39,145,1),(39,146,1),(39,148,1),(39,149,1),(39,150,1),(39,151,1),(40,152,1),(40,153,1),(41,154,1),(41,155,1),(41,156,1),(42,157,1),(42,158,1),(43,159,1),(43,160,1),(43,161,1),(44,162,1),(44,163,1);
/*!40000 ALTER TABLE `formula_compound` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `formula_parameters`
--

DROP TABLE IF EXISTS `formula_parameters`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `formula_parameters` (
  `id_of_parameter` int(11) NOT NULL AUTO_INCREMENT,
  `name_of_parameter` varchar(45) DEFAULT NULL,
  `measurement_of_parameter` varchar(45) DEFAULT NULL,
  `description_of_parameter` varchar(200) DEFAULT NULL,
  `id_of_expert` int(11) NOT NULL,
  PRIMARY KEY (`id_of_parameter`,`id_of_expert`),
  UNIQUE KEY `id_of_parameter_UNIQUE` (`id_of_parameter`,`id_of_expert`),
  KEY `fk_formula_compound_expert_id_idx` (`id_of_expert`),
  CONSTRAINT `fk_formula_compound_expert_id` FOREIGN KEY (`id_of_expert`) REFERENCES `expert` (`id_of_expert`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=164 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `formula_parameters`
--

LOCK TABLES `formula_parameters` WRITE;
/*!40000 ALTER TABLE `formula_parameters` DISABLE KEYS */;
INSERT INTO `formula_parameters` VALUES (0,'i',NULL,'Індекс для рівнянь з сумою',1),(1,'U(t)','грн','Об`єм накопичення',1),(1,'X1','млн. м^3','об\'єм скидання неочиищенних стічних вод\r\n',3),(2,'C(t)','грн','Об`єм споживання',1),(2,'X2','млн. м^3','викиди в атмосферу повітря оксидів азоту',3),(3,'Z(t)','грн','Витрати на забеспечення безпеки населення',1),(3,'X3','тис. т.','об\'єм скидання забрудненних стічних вод',3),(4,'ЗВ','грн','Запаси та витрати підприємства',1),(4,'X4','тис. т.','об\'єм викидів хімчних речовин',3),(5,'ГКР','грн','Грошові кошти, розрахунки та інші активи підприємства',1),(5,'X5','млн. м^3','об\'єм викидів хімчних речовин',3),(6,'ВМП','грн','Витрати майбутніх періодів підприємства',1),(6,'X1','млн. м^3','об\'єм викидів неочищенних стічних вод',3),(7,'РКП','грн','Розрахунки й інші короткострокові пасиви підприємства',1),(7,'X3','тис. т.','викиди хім. речовин пересувними установками',3),(8,'ЧГПо','грн','Сума чистого грошового потоку підприємства по операційній діяльності',1),(8,'X4','тис. т.','викиди хім. речовин стаціонарними установками',3),(9,'ЧГПі','грн','Сума чистого грошового потоку підприємства по інвестиційній діяльності',1),(9,'X5','тис. т.','викиди хім. речовин стаціонарними установками',3),(10,'ЧГПф','грн','Сума чистого грошового потоку підприємства по фінансовій  діяльності',1),(10,'X1','тис. т.','викиди хім. речовин стаціонарними установками',3),(11,'Mi','т','Обсяг викинутої речовини',1),(11,'X2','тис. т.','викиди хім. речовин пересувними установками',3),(12,'Npi','грн','Ставка податку за тонну викинутої речовини',1),(12,'АДС','мм. рт. ст.','систолічний арт. тиск',3),(13,'ЗДВ','сек.','затримка дихання після гибокого вдиху',3),(14,'СОЗ','','індекс самооцінки здоров\'я',3),(15,'СБ','сек.','статичне балансування',3),(16,'АДП','мм рт.ст','пульсовий тиск',3),(17,'Фв','грн','Збитки від руйнування та пошкодження основних фондів виробничого призначення',1),(17,'МТ','кг','маса тіла',3),(18,'Фг','грн','Збитки від руйнування та пошкодження основних фондів невиробничого призначення',1),(18,'КВ','рік','календарний вік',3),(19,'Пр','грн','Збитки від втрат готової промислової та\nсільськогосподарської продукції',1),(19,'X1','мл. кг^-1 хв^-1','споживання кисню на висоті навантаження',3),(20,'Прс','грн','Збитки від втрат незібраної\nсільськогосподарської продукції',1),(20,'X2','хв^-1','макс. значення частоти серцевих скорочень',3),(21,'Сн','грн','Збитки від втрат запасів сировини,\nнапівфабрикатів та проміжної продукції',1),(21,'X3','Вт','потужність порогового фіз. навантаження',3),(22,'Мдг','грн','Збитки від втрат майна громадян та організацій',1),(22,'X4','ум. од.','мін. значення вентиляційного еквіваленту',3),(23,'ΔP','грн','Зменшення балансової вартості i-го виду основних фондів виробничого призначення внаслідок повного або часткового руйнування з\nурахуванням відповідних коефіцієнтів індексації',1),(25,'Ka','','Kоефіцієнт амортизації i-го виду основних фондів виробничого призначення',1),(28,'Лв','грн','Ліквідаційна вартість одержаних матеріалів і устаткування',1),(30,'Пр(п)','грн','Збитки від втрат готової промислової продукції',1),(31,'Пр(с)','грн','Збитки від втрат готової сільськогосподарської продукції',1),(32,'Сi','грн','Собівартість одиниці i-го виду промислової продукції',1),(33,'qi','од','Кількість втраченої продукції i-го виду',1),(35,'Ці','од','Середня оптова ціна i-го виду сільськогосподарської продукції',1),(36,'Si','м^2','Площа пошкодження i-ї сільськогосподарської культури',1),(37,'кі','','Середній коефіцієнт пошкодження посівів i-ї сільськогосподарської культури',1),(38,'Уі','','Середня очікувана прогностична урожайність i-ї сільськогосподарської\nкультури регіоні',1),(40,'Зі(дод)','грн','Витрати, необхідні для доведення всього обсягу втраченої i-ї сільськогосподарської продукції до товарного вигляду',1),(41,'Цi(сер)','грн','Середня оптова ціна одиниці i-ї сировини, матеріалів та напівфабрикатів на момент виникнення втрат',1),(49,'Р(с/г)1','грн','Збитки від вилучення сільськогосподарських угідь з користування',1),(50,'Р(с/г)2','грн','Збитки від порушення сільськогосподарських угідь',1),(51,'Н','грн/га','норматив збитків для різних видів сільськогосподарських\nугідь по областях',1),(52,'П','га','Площа сільськогосподарських угідь відповідного виду, які вилучаються з користування',1),(54,'k','','Коефіцієнт зниження продуктивності угіддя',1),(55,'Н','грн/га','Норматив збитків для різних видів сільськогосподарських угідь по областях',1),(56,'П','га','Площа сільськогосподарських угідь відповідного виду, які вилучаються з користування',1),(57,'В','грн','Вартість 1 тонни живої ваги постраждалої тварини за середніми цінами, які склалися на підприємстві, що зазнало втрат',1),(58,'N','т','Загальна вага постраждалих тварин',1),(59,'Аф','грн','Збиток від забруднення атмосфери',1),(60,'Вф','грн','Збиток від забруднення поверхневих і\nпідземних вод',1),(61,'Зф','грн','Збиток від забруднення землі і ґрунту ',1),(63,'Нр','грн','Збиток від втрати і життя і здоров`я населення',1),(64,'Мр','грн','Збиток від ушкодження і руйнування ОВФ, майна і споруджень',1),(65,'Ррг','грн','Збиток від втрат у рибному господарстві',1),(66,'Рлг','грн','Збиток від втрати продукції й об`єктів лісового\nгосподарства',1),(67,'Ррек','грн','Збиток від знищення і погіршення якості рекреаційних ресурсів',1),(68,'Рпзф','грн','Збиток, заподіяний природно-заповідному фондові',1),(69,'Рсг','грн','Збиток від відторгнення сільськогосподарських угідь',1),(70,'Втрр','грн','Втрати від вибуття трудових ресурсів з виробництва',1),(71,'Вдп','грн','Витрати на виплату допомоги на поховання',1),(72,'Втг','грн','Витрати на виплату пенсій у разі втрати годувальника',1),(73,'Мл','грн','Втрати від легкого нещасного випадку',1),(74,'Nл','чол','Кількість постраждалих від легкого нещасного випадку',1),(75,'Мт','грн','Втрати від тяжкого нещасного випадку',1),(76,'Nт','чол','Кількість постраждалих від тяжкого нещасного випадку',1),(77,'Мз','грн','Втрати від загибелі людини',1),(78,'Nз','чол','Кількість загиблих людей',1),(79,'Мі','грн','Втрати від отримання людиною інвалідності',1),(80,'Nі','чол','Кількість людей що отримали інвалідність',1),(81,'Мдп','0,15* тис. грн/чол','Допомога на поховання (за даними органів соціального забезпечення)',1),(82,'Nз','чол','Кількість загиблих',1),(83,'Мвтг','грн','Розмір щомісячної пенсії на дитину до досягнення нею повноліття',1),(84,'Вд','рік','Вік дитини',1),(85,'ВВП','грн','Питомий валовий внутрішній продукт',1),(86,'В0','грн/люд*рік','Питомий приріст ВВП',1),(87,'Тт','рік','Початок трудового віку',1),(88,'Тр','рік','Початок пенсійного віку',1),(89,'Еф','1/рік','Норматив дисконтування',1),(90,'Мдг(г)','грн','Збитки від втрат майна громадян',1),(91,'Мдг(о)','грн','Збитки від втрат майна організацій',1),(92,'Pi','грн','Балансова вартість i-го виду втраченого майна організацій',1),(93,'Кі(а)','','Коефіцієнт амортизації i-го виду втраченого майна організацій',1),(94,'кі','','Індекс зміни цін стосовно часу придбання i-го виду майна',1),(95,'qі(орг)','од.','Кількість втраченого майна організацій i-го виду',1),(96,'Ці(с.р)','грн','Середня ринкова ціна і-го виду втраченого майна громадян',1),(97,'qі(гр)','од.','Кількість втраченого майна громадян і-го виду',1),(99,'Р(л/г)1','грн','Збитки від знищення лісу та вилучення земельних ділянок лісового фонду для цілей, не пов`язаних з веденням лісового господарства',1),(100,'Р(л/г)2','грн','Збитки від пошкодження лісів',1),(101,'Р(л/г)3','грн','Збитки від пошкодження лісів у разі переведення лісів у менш цінну групу ',1),(102,'Н','грн/га','Норматив збитків для груп лісів по областях',1),(103,'К','','Коефіцієнт продуктивності лісів за типами лісогосподарських умов областей',1),(104,'П','га','Площа лісової ділянки, що вилучається або знищується',1),(105,'k','','Коефіцієнт зниження продуктивності угіддя',1),(106,'Н','грн/га','Норматив збитків для груп лісів за регіонами України',1),(107,'П','га','Площа лісової ділянки, що зазнала шкідливого впливу',1),(108,'Н1','грн/га','Норматив збитків до шкідливого впливу',1),(109,'Н2','грн/га','Норматив збитків після шкідливого впливу',1),(110,'К','','Коефіцієнт продуктивності лісів за типами лісорослинних умов',1),(111,'П','га','Площа лісової ділянки, що зазнала шкідливого впливу',1),(112,'N','кг','Прямі збитки рибного господарства\n',1),(113,'N1','кг','Збитки від втрати потомства у рибному господарстві',1),(114,'N2','кг','Збитки від загибелі кормових організмів(планктон)',1),(115,'N3','кг','Збитки від загибелі кормових організмів(бентос)',1),(116,'N4','кг','Збитки від втрат нерестовищ',1),(117,'N5','кг','Збитки від втрати потомства',1),(118,'П','од/м^2','Середня кількість загиблої риби',1),(119,'S','м^2','Площа негативного впливу пошкодження, кв. метрів',1),(120,'М','кг','Середня маса дорослої особини',1),(121,'П1','од/м^2','Середня кількість загиблих личинок',1),(122,'К1','%','Коефіцієнт промислового повернення від личинок',1),(123,'П2','од/м^2','Середня кількість загиблої ікри',1),(124,'К2','%','Коефіцієнт промислового повернення від ікри',1),(125,'П','од','Кількість загиблої риби',1),(126,'Z','%','Частка самок',1),(127,'Q','тис. од ікринок','Cередня плодючість самки',1),(128,'С','разів','Кратність нересту',1),(129,'К','%','Коефіцієнт промислового повернення від ікри',1),(130,'М','кг','Середня маса дорослої особини',1),(131,'S','м^2','Площа пошкодження',1),(133,'Н','м','Глибина водойми',1),(134,'П','гр/м^3','Середня концентрація кормових організмів',1),(135,'Р/В','','Коефіцієнт переведення біомаси кормових організмів у продукцію',1),(136,'К1','%','Показник гранично можливого використання\nкормової бази риб',1),(137,'К2','%','Кормовий коефіцієнт для переведення продукції кормових організмів у рибопродукцію',1),(138,'S','м^2','Площа пошкодження',1),(139,'П','гр/м^2','Середня концентрація кормових організмів',1),(140,'Р/В','','Коефіцієнт переведення біомаси кормових організмів у продукцію',1),(141,'К1','%','Показник гранично можливого використання\nкормової бази риб',1),(142,'К2','%','Кормовий коефіцієнт для переведення продукції кормових організмів у рибопродукцію',1),(143,'S','га','Площа пошкодження',1),(144,'Р','кг/га','Середня рибопродуктивність нерестовищ за промисловим поверненням',1),(145,'S','га','Площа пошкодження',1),(146,'П','од/га','Кількість плідників на нерестовищах',1),(148,'Q','тис. од','Середня плодючість самки',1),(149,'С','разів','Кратність нересту',1),(150,'К','%','Коефіцієнт промислового повернення від ікри',1),(151,'М','кг','Середня маса дорослої особини',1),(152,'Т','','Термін, необхідний для відновлення рекреаційної зони',1),(153,'П','','Прибуток у цілому від діяльності установи за одиницю розрахункового терміну на одному об`єкті рекреаційної зони',1),(154,'Зр','грн','Сума збитків об`єктів рекреаційної зони антропогенного впливу',1),(155,'Рп','грн','Витрати на відновлення ресурсів природного\nпоходження',1),(156,'Рс','грн','Витрати на відновлення ресурсів антропогенного\nпоходження',1),(157,'Пз','грн','Сума витрат на відновлення природного стану об`єкта природно-заповідного фонду',1),(158,'Рз','грн','Недоотримані надходження від рекреаційної, наукової, природоохоронної, туристсько-\nекскурсійної та іншої діяльності установи природно-заповідного фонду',1),(159,'Ап','грн','Витрати на експертизу екологічної та ландшафтної структури об`єкта природно-заповідного фонду',1),(160,'Анс','грн','Витрати на експертизу змін стану біогеоценозів об`єкта природно-заповідного фонду, що постраждав внаслідок антропогенного впливу',1),(161,'І','грн','Сума збитків, заподіяних біогеоценозам за\nокремими складовими збитків ',1),(162,'Qi','грн','Прибуток i-ї установи природно-заповідного фонду до антропогенного впливу',1),(163,'Qi(п)','грн','Прибуток i-ї установи природно-заповідного фонду після антропогенного впливу',1);
/*!40000 ALTER TABLE `formula_parameters` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `formulas`
--

DROP TABLE IF EXISTS `formulas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `formulas` (
  `id_of_formula` int(11) NOT NULL AUTO_INCREMENT,
  `name_of_formula` varchar(100) DEFAULT NULL,
  `description_of_formula` varchar(200) DEFAULT NULL,
  `id_of_expert` int(11) NOT NULL,
  `measurement_of_formula` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_of_formula`,`id_of_expert`),
  UNIQUE KEY `id_of_formula_UNIQUE` (`id_of_formula`,`id_of_expert`),
  KEY `fk_formulas_expert_id_idx` (`id_of_expert`),
  CONSTRAINT `fk_formulas_expert_id` FOREIGN KEY (`id_of_expert`) REFERENCES `expert` (`id_of_expert`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=45 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `formulas`
--

LOCK TABLES `formulas` WRITE;
/*!40000 ALTER TABLE `formulas` DISABLE KEYS */;
INSERT INTO `formulas` VALUES (1,'Q(t)','Розрахунок національного доходу',1,'грн'),(1,'ОСТЖ','Оцінка середньої тривалості життя',3,'ум. од.'),(2,'Кп','Баланс підприємства',1,'грн'),(2,'ОСТЖ(2)','Оцінка середньої тривалості життя(2)',3,'ум. од.'),(3,'ЧГПп','Чистий грошовий потік',1,'грн'),(3,'ГІМ','ПМ гострий інфаркт міокарда',3,'ум. од.'),(4,'Пвс','Податок за викид відходів у атмосферу',1,'грн'),(4,'ХЦВП','ПМ хронічна цереброваскулярна патологія',3,'ум. од.'),(5,'Пс','Податок за скид відходів у водні об\'єкти',1,'грн'),(5,'МІ','ПМ мозковий інсульт',3,'ум. од.'),(6,'Прв','Податок за скид відходів у грунти',1,'грн'),(6,'БВ(ч)','Біологічний вік людини(ч)',3,'роки'),(7,'E','Економічна ефективність людського життя',1,'грн'),(7,'БВ(ж)','Біологічний вік людини(ж)',3,'роки'),(8,'Сіф','Сума пофакторних збитків',1,'грн'),(8,'НБВ(ч)','Належний біологічний вік(ч)',3,'роки'),(9,'Сіп','Сума пореципієнтних збитків',1,'грн'),(9,'НБВ(ж)','Належний біологічний вік(ж)',3,'роки'),(10,'Нр','Збиток від втрати і життя і здоров`я населення',1,'грн'),(10,'ФВ ССС(ж)','Функціональний вік серцево-судинної с-ми(ж)',3,'роки'),(11,'Втрр','Втрати від вибуття трудових ресурсів з виробництва',1,'грн'),(11,'ФВ ССС(ч)','Функціональний вік серцево-судинної с-ми(ч)',3,'роки'),(12,'Вдп','Витрати на виплату допомоги на поховання',1,'грн'),(13,'Втг','Витрати на виплату пенсій у разі втрати годувальника',1,'грн'),(14,'Мр','Збитки від руйнування та пошкодження основних фондів, знищення майна та продукції',1,'грн'),(15,'Фг','Збитки від руйнування та пошкодження основних фондів невиробничого призначення',1,'грн'),(16,'Фв','Збитки від руйнування та пошкодження основних фондів виробничого призначення',1,'грн'),(17,'Пр','Збитки від втрат готової промислової та\nсільськогосподарської продукції',1,'грн'),(18,'Пр(п)','Збитки від втрат готової промислової продукції',1,'грн'),(19,'Пр(с)','Збитки від втрат готовоїсільськогосподарськоїї продукції',1,'грн'),(20,'Прс','Збитки від втрат незібраної\nсільськогосподарської продукції',1,'грн'),(21,'Сн','Збитки від втрат запасів сировини, напівфабрикатів та проміжної продукції',1,'грн'),(22,'Мдг','Збитки від втрат майна громадян та організацій',1,'грн'),(23,'Мдг(г)','Збитки від втрат майна громадян',1,'грн'),(24,'Мдг(о)','Збитки від втрат майна організацій',1,'грн'),(25,'Р(с/г)','Збитки від вилучення або\nпорушення сільськогосподарських\nугідь та втрат тваринництва',1,'грн'),(26,'Р(с/г)1','Збитки від вилучення сільськогосподарських угідь з користування',1,'грн'),(27,'Р(с/г)2','Збитки від порушення сільськогосподарських угідь',1,'грн'),(28,'Мтв','Розмір збитків по худобі що зазнала пошкодження внаслідок антропогенного\nвпливу',1,'грн'),(29,'Р(л/г)','Збитки від втрати деревини та інших лісових ресурсів',1,'грн'),(30,'Р(л/г)1','Збитки від знищення лісу та вилучення земельних ділянок лісового фонду для цілей, не пов`язаних з веденням лісового господарства',1,'грн'),(31,'Р(л/г)2','Збитки від пошкодження лісів',1,'грн'),(32,'Р(л/г)3','Збитки від пошкодження лісів у разі переведення лісів у менш цінну групу ',1,'грн'),(33,'Р(р/г)','Збитки рибного господарства',1,'кг'),(34,'N','Прямі збитки рибного господарства\n',1,'кг'),(35,'N1','Збитки від втрати потомства у рибному господарстві\n',1,'кг'),(36,'N2','Збитки від загибелі кормових організмів(планктон)',1,'кг'),(37,'N3','Збитки від загибелі кормових організмів(бентос)',1,'кг'),(38,'N4','Збитки від втрат нерестовищ',1,'кг'),(39,'N5','Збитки від втрати потомства',1,'кг'),(40,'Ррек','Розрахунок збитків від наслідків негативного впливу для одного об\'єкта',1,'грн'),(41,'Ррек','Загальні збитки у рекреаційному центрі, що включає декілька об`єктів та використовує певний обсяг природних ресурсів і ресурсів антропогенного походження рекреаційної зони',1,'грн'),(42,'Рпзф','Загальні економічні втрати об`єкта природно-заповідного фонду від наслідків антропогенного впливу',1,'грн'),(43,'Пз','Сума витрат на відновлення природного стану об`єкта природно-заповідного фонду',1,'грн'),(44,'Рз','Недоотримані надходження від рекреаційної, наукової, природоохоронної, туристсько-\nекскурсійної та іншої діяльності установи природно-заповідного фонду',1,'грн');
/*!40000 ALTER TABLE `formulas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `issues`
--

DROP TABLE IF EXISTS `issues`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `issues` (
  `issue_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) DEFAULT NULL,
  `description` varchar(500) DEFAULT NULL,
  `creation_date` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`issue_id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `issues`
--

LOCK TABLES `issues` WRITE;
/*!40000 ALTER TABLE `issues` DISABLE KEYS */;
INSERT INTO `issues` VALUES (12,'Княжичі','Забруднення водоймища у с. Княжичі','2018-04-19 08:42:12');
/*!40000 ALTER TABLE `issues` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `parameters_value`
--

DROP TABLE IF EXISTS `parameters_value`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `parameters_value` (
  `calculation_number` int(11) NOT NULL,
  `id_of_parameter` int(11) NOT NULL,
  `parameter_value` double DEFAULT NULL,
  `index_of_parameter` int(11) NOT NULL,
  `id_of_expert` int(11) NOT NULL,
  `id_of_formula` int(11) NOT NULL,
  PRIMARY KEY (`calculation_number`,`id_of_parameter`,`id_of_expert`,`id_of_formula`,`index_of_parameter`),
  KEY `fk_parameter_id_idx` (`id_of_parameter`),
  KEY `fk_paramater2_id_idx` (`id_of_parameter`),
  KEY `fk_id_of_exp_par_val_idx` (`id_of_expert`),
  KEY `fk_id_of_formula_formulas_idx` (`id_of_formula`),
  CONSTRAINT `fk_id_of_exp_par_val` FOREIGN KEY (`id_of_expert`) REFERENCES `expert` (`id_of_expert`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_id_of_form_formulas_parameter_value` FOREIGN KEY (`id_of_formula`) REFERENCES `formulas` (`id_of_formula`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_paramater2_id` FOREIGN KEY (`id_of_parameter`) REFERENCES `formula_parameters` (`id_of_parameter`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `parameters_value`
--

LOCK TABLES `parameters_value` WRITE;
/*!40000 ALTER TABLE `parameters_value` DISABLE KEYS */;
INSERT INTO `parameters_value` VALUES (1,1,0,0,1,1),(1,2,0,0,1,1),(1,3,0,0,1,1),(1,12,4,0,3,6),(1,13,4,0,3,6),(1,14,3,0,3,6),(1,15,3,0,3,6),(2,0,2,0,1,15),(2,0,2,0,1,16),(2,23,1,1,1,15),(2,23,3,2,1,15),(2,23,0,1,1,16),(2,23,0,2,1,16),(2,25,2,1,1,15),(2,25,4,2,1,15),(2,25,0,1,1,16),(2,25,0,2,1,16),(2,28,5,0,1,15),(2,28,0,0,1,16),(2,85,2920920,0,1,7),(2,86,0.02,0,1,7),(2,87,18,0,1,7),(2,88,65,0,1,7),(2,89,0.17,0,1,7);
/*!40000 ALTER TABLE `parameters_value` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `point_poligon`
--

DROP TABLE IF EXISTS `point_poligon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `point_poligon` (
  `longitude` double NOT NULL,
  `latitude` double NOT NULL,
  `Id_of_poligon` int(11) NOT NULL,
  `order` int(11) NOT NULL,
  PRIMARY KEY (`longitude`,`latitude`,`Id_of_poligon`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `point_poligon`
--

LOCK TABLES `point_poligon` WRITE;
/*!40000 ALTER TABLE `point_poligon` DISABLE KEYS */;
INSERT INTO `point_poligon` VALUES (48.0633965377621,34.12353515625,5,3),(48.2539411446343,33.310546875,5,1),(48.5747899109288,34.365234375,5,2),(48.86101531982422,2.3300299644470215,1,2),(48.86372756958008,2.3319180011749268,1,3),(48.863868713378906,2.321553945541382,1,1),(48.86638259887695,2.323575019836426,1,0),(49.1242192485914,35.859375,7,2),(49.6320619412871,32.1240234375,4,6),(49.7031677201799,31.376953125,3,3),(49.7031677201799,31.376953125,4,3),(49.9441503516455,30.838623046875,3,2),(49.9441503516455,30.838623046875,4,2),(50.0006777572363,30.574951171875,2,3),(50.0077390146369,33.5302734375,7,3),(50.2261237443714,32.54150390625,4,5),(50.2612538275847,30.157470703125,2,4),(50.3594803462987,31.871337890625,3,4),(50.3594803462987,31.871337890625,4,4),(50.3664887627383,31.26708984375,3,1),(50.3664887627383,31.26708984375,4,1),(50.3857565720208,30.8866882324219,6,3),(50.3896967507881,30.9574127197266,6,1),(50.40895513434,30.8853149414063,6,2),(50.6111317133236,31.17919921875,2,2),(50.6250730634143,34.2333984375,7,1),(50.6390102812587,30.16845703125,2,1);
/*!40000 ALTER TABLE `point_poligon` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `poligon`
--

DROP TABLE IF EXISTS `poligon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `poligon` (
  `Id_of_poligon` int(11) NOT NULL,
  `brush_color_r` smallint(3) DEFAULT '200',
  `bruch_color_g` smallint(3) DEFAULT '200',
  `brush_color_b` smallint(3) DEFAULT '200',
  `brush_alfa` smallint(3) DEFAULT '50',
  `line_collor_r` smallint(3) DEFAULT '255',
  `line_color_g` smallint(3) DEFAULT '255',
  `line_color_b` smallint(3) DEFAULT '255',
  `line_alfa` smallint(3) DEFAULT '100',
  `line_thickness` smallint(3) DEFAULT '1',
  `name` varchar(45) DEFAULT NULL,
  `id_of_expert` int(11) NOT NULL,
  PRIMARY KEY (`Id_of_poligon`,`id_of_expert`),
  KEY `fk_id_of_exp_poligon_idx` (`id_of_expert`),
  CONSTRAINT `fk_id_of_exp_poligon` FOREIGN KEY (`id_of_expert`) REFERENCES `expert` (`id_of_expert`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `poligon`
--

LOCK TABLES `poligon` WRITE;
/*!40000 ALTER TABLE `poligon` DISABLE KEYS */;
INSERT INTO `poligon` VALUES (1,255,10,10,100,255,255,255,255,1,'one',0),(2,250,250,250,250,0,250,2,21,2,'Test1',1),(3,250,250,250,250,0,250,2,21,2,'Test1',1),(4,250,250,250,250,0,250,2,21,2,'Test1',1),(5,250,250,250,250,0,250,2,21,2,'Test1',1),(6,250,250,250,250,0,250,2,21,2,'Test1',3),(7,250,250,250,250,0,250,2,21,2,'Test1',3);
/*!40000 ALTER TABLE `poligon` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `poligon_calculations_description`
--

DROP TABLE IF EXISTS `poligon_calculations_description`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `poligon_calculations_description` (
  `id_poligon` int(11) NOT NULL,
  `calculations_description_number` int(11) NOT NULL,
  `id_of_formula` int(11) DEFAULT '0',
  PRIMARY KEY (`id_poligon`,`calculations_description_number`),
  KEY `FK_p_to_calculations_idx` (`calculations_description_number`),
  CONSTRAINT `FK_c_to_poligon` FOREIGN KEY (`calculations_description_number`) REFERENCES `calculations_description` (`calculation_number`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_p_to_calculation` FOREIGN KEY (`id_poligon`) REFERENCES `poligon` (`Id_of_poligon`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `poligon_calculations_description`
--

LOCK TABLES `poligon_calculations_description` WRITE;
/*!40000 ALTER TABLE `poligon_calculations_description` DISABLE KEYS */;
INSERT INTO `poligon_calculations_description` VALUES (2,2,15),(3,2,16),(4,2,15),(5,1,1),(6,2,0),(7,1,6);
/*!40000 ALTER TABLE `poligon_calculations_description` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `resource`
--

DROP TABLE IF EXISTS `resource`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `resource` (
  `resource_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `units` varchar(100) DEFAULT NULL,
  `price` double DEFAULT NULL,
  PRIMARY KEY (`resource_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `resource`
--

LOCK TABLES `resource` WRITE;
/*!40000 ALTER TABLE `resource` DISABLE KEYS */;
INSERT INTO `resource` VALUES (4,'Гроші','Гривні','грн',1);
/*!40000 ALTER TABLE `resource` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `template_resource`
--

DROP TABLE IF EXISTS `template_resource`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `template_resource` (
  `resource_id` int(11) NOT NULL,
  `template_id` int(11) NOT NULL,
  PRIMARY KEY (`resource_id`,`template_id`),
  KEY `template_resource_ibfk_2_idx` (`template_id`),
  CONSTRAINT `template_resource_ibfk_1` FOREIGN KEY (`resource_id`) REFERENCES `resource` (`resource_id`),
  CONSTRAINT `template_resource_ibfk_2` FOREIGN KEY (`template_id`) REFERENCES `event_template` (`template_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `template_resource`
--

LOCK TABLES `template_resource` WRITE;
/*!40000 ALTER TABLE `template_resource` DISABLE KEYS */;
/*!40000 ALTER TABLE `template_resource` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `user_name` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `id_of_expert` int(11) DEFAULT NULL,
  `id_of_user` int(11) NOT NULL,
  PRIMARY KEY (`id_of_user`),
  KEY `fk_user_expert_id_idx` (`id_of_expert`),
  CONSTRAINT `fk_user_expert_id` FOREIGN KEY (`id_of_expert`) REFERENCES `expert` (`id_of_expert`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES ('3','3',3,1),('0','0',0,2),('1','1',1,3),('2','2',2,4),('5','5',5,5),('4','4',4,6);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-05-18 14:18:58
