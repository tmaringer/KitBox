CREATE DATABASE  IF NOT EXISTS `kitbox` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `kitbox`;
-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: kitbox
-- ------------------------------------------------------
-- Server version	8.0.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `listsitems`
--

DROP TABLE IF EXISTS `listsitems`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `listsitems` (
  `OrderId` int NOT NULL,
  `Code` varchar(50) NOT NULL,
  `Quantity` int DEFAULT NULL,
  `Disponibility` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`OrderId`,`Code`),
  KEY `listsitems_ibfk_1` (`OrderId`),
  KEY `Code_idx` (`Code`),
  CONSTRAINT `Code` FOREIGN KEY (`Code`) REFERENCES `kitbox` (`Code`),
  CONSTRAINT `OrderId` FOREIGN KEY (`OrderId`) REFERENCES `orders` (`OrderId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `listsitems`
--

LOCK TABLES `listsitems` WRITE;
/*!40000 ALTER TABLE `listsitems` DISABLE KEYS */;
INSERT INTO `listsitems` VALUES (1,'COR112GL',4,'true'),(1,'COUPEL',2,'true'),(1,'PAG5252BL',4,'true'),(1,'PAH52100BL',4,'true'),(1,'PAR52100BL',2,'true'),(1,'POR5252VE',2,'true'),(1,'TAS47',8,'true'),(1,'TRF100',4,'true'),(1,'TRG52',8,'true'),(1,'TRR100',4,'true');
/*!40000 ALTER TABLE `listsitems` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-03-24 17:54:20
