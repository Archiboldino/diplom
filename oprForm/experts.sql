CREATE DATABASE  IF NOT EXISTS `experts` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `experts`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: experts
-- ------------------------------------------------------
-- Server version	5.5.58

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
-- Table structure for table `action_list`
--

DROP TABLE IF EXISTS `action_list`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `action_list` (
  `id_of_action` int(11) NOT NULL,
  `date_of_action` date DEFAULT NULL,
  `value` double DEFAULT NULL,
  `user_name` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_of_action`),
  CONSTRAINT `fk4` FOREIGN KEY (`id_of_action`) REFERENCES `actions` (`id_of_action`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `action_list`
--

LOCK TABLES `action_list` WRITE;
/*!40000 ALTER TABLE `action_list` DISABLE KEYS */;
/*!40000 ALTER TABLE `action_list` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `actions`
--

DROP TABLE IF EXISTS `actions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `actions` (
  `id_of_action` int(11) NOT NULL,
  `name_of_action` varchar(45) DEFAULT NULL,
  `description_of_action` varchar(45) DEFAULT NULL,
  `actionscol` varchar(45) DEFAULT NULL,
  `id_of_expert` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_of_action`),
  KEY `fk3_idx` (`id_of_expert`),
  CONSTRAINT `fk3` FOREIGN KEY (`id_of_expert`) REFERENCES `expert` (`id_of_expert`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `actions`
--

LOCK TABLES `actions` WRITE;
/*!40000 ALTER TABLE `actions` DISABLE KEYS */;
/*!40000 ALTER TABLE `actions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `calculations_description`
--

DROP TABLE IF EXISTS `calculations_description`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `calculations_description` (
  `calculation_number` int(11) NOT NULL,
  `calculation_name` varchar(45) DEFAULT NULL,
  `description_of_calculation` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`calculation_number`),
  CONSTRAINT `fk_calc_desc_calc_result` FOREIGN KEY (`calculation_number`) REFERENCES `calculations_result` (`calculation_number`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `calculations_description`
--

LOCK TABLES `calculations_description` WRITE;
/*!40000 ALTER TABLE `calculations_description` DISABLE KEYS */;
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
  PRIMARY KEY (`calculation_number`,`id_of_formula`),
  KEY `fk_formula2_id_idx` (`id_of_formula`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `calculations_result`
--

LOCK TABLES `calculations_result` WRITE;
/*!40000 ALTER TABLE `calculations_result` DISABLE KEYS */;
/*!40000 ALTER TABLE `calculations_result` ENABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `expert`
--

LOCK TABLES `expert` WRITE;
/*!40000 ALTER TABLE `expert` DISABLE KEYS */;
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
  PRIMARY KEY (`id_of_formula`,`id_of_parameter`),
  KEY `fk_parameter_id_idx` (`id_of_parameter`),
  CONSTRAINT `fk_formula_id` FOREIGN KEY (`id_of_formula`) REFERENCES `formulas` (`id_of_formula`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_parameter_id` FOREIGN KEY (`id_of_parameter`) REFERENCES `formula_parameters` (`id_of_parameter`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `formula_compound`
--

LOCK TABLES `formula_compound` WRITE;
/*!40000 ALTER TABLE `formula_compound` DISABLE KEYS */;
/*!40000 ALTER TABLE `formula_compound` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `formula_parameters`
--

DROP TABLE IF EXISTS `formula_parameters`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `formula_parameters` (
  `id_of_parameter` int(11) NOT NULL,
  `name_of_parameter` varchar(45) DEFAULT NULL,
  `measurement_of_parameter` varchar(45) DEFAULT NULL,
  `description_of_parameter` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_of_parameter`),
  UNIQUE KEY `id_of_parameter_UNIQUE` (`id_of_parameter`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `formula_parameters`
--

LOCK TABLES `formula_parameters` WRITE;
/*!40000 ALTER TABLE `formula_parameters` DISABLE KEYS */;
/*!40000 ALTER TABLE `formula_parameters` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `formulas`
--

DROP TABLE IF EXISTS `formulas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `formulas` (
  `id_of_formula` int(11) NOT NULL,
  `name_of_formula` varchar(45) DEFAULT NULL,
  `description_of_formula` varchar(45) DEFAULT NULL,
  `id_of_expert` int(11) NOT NULL,
  PRIMARY KEY (`id_of_formula`),
  UNIQUE KEY `id_of_formula_UNIQUE` (`id_of_formula`),
  KEY `fk_formulas_expert_id_idx` (`id_of_expert`),
  CONSTRAINT `fk_formulas_expert_id` FOREIGN KEY (`id_of_expert`) REFERENCES `expert` (`id_of_expert`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `formulas`
--

LOCK TABLES `formulas` WRITE;
/*!40000 ALTER TABLE `formulas` DISABLE KEYS */;
/*!40000 ALTER TABLE `formulas` ENABLE KEYS */;
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
  PRIMARY KEY (`calculation_number`,`id_of_parameter`),
  KEY `fk_parameter_id_idx` (`id_of_parameter`),
  KEY `fk_paramater2_id_idx` (`id_of_parameter`),
  CONSTRAINT `fk_calculation_number` FOREIGN KEY (`calculation_number`) REFERENCES `calculations_result` (`calculation_number`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_paramater2_id` FOREIGN KEY (`id_of_parameter`) REFERENCES `formula_parameters` (`id_of_parameter`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `parameters_value`
--

LOCK TABLES `parameters_value` WRITE;
/*!40000 ALTER TABLE `parameters_value` DISABLE KEYS */;
/*!40000 ALTER TABLE `parameters_value` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `resources`
--

DROP TABLE IF EXISTS `resources`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `resources` (
  `id_of_resource` int(11) NOT NULL,
  `name_of_resource` varchar(45) DEFAULT NULL,
  `description_of_resource` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_of_resource`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `resources`
--

LOCK TABLES `resources` WRITE;
/*!40000 ALTER TABLE `resources` DISABLE KEYS */;
/*!40000 ALTER TABLE `resources` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `resources_of_action`
--

DROP TABLE IF EXISTS `resources_of_action`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `resources_of_action` (
  `id_of_action` int(11) NOT NULL,
  `id_of_resource` int(11) NOT NULL,
  PRIMARY KEY (`id_of_action`,`id_of_resource`),
  KEY `fk2_idx` (`id_of_resource`),
  CONSTRAINT `fk1` FOREIGN KEY (`id_of_action`) REFERENCES `actions` (`id_of_action`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk2` FOREIGN KEY (`id_of_resource`) REFERENCES `resources` (`id_of_resource`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `resources_of_action`
--

LOCK TABLES `resources_of_action` WRITE;
/*!40000 ALTER TABLE `resources_of_action` DISABLE KEYS */;
/*!40000 ALTER TABLE `resources_of_action` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `user_name` varchar(50) NOT NULL,
  `password` varchar(50) DEFAULT NULL,
  `id_of_expert` int(11) DEFAULT NULL,
  PRIMARY KEY (`user_name`),
  KEY `fk_user_expert_id_idx` (`id_of_expert`),
  CONSTRAINT `fk_user_expert_id` FOREIGN KEY (`id_of_expert`) REFERENCES `expert` (`id_of_expert`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
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

-- Dump completed on 2017-12-12 11:16:56
