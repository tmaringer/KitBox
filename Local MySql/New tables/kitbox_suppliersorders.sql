-- MySQL dump 10.13  Distrib 8.0.20, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: kitbox
-- ------------------------------------------------------
-- Server version	8.0.20

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
-- Table structure for table `suppliersorders`
--

DROP TABLE IF EXISTS `suppliersorders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `suppliersorders` (
  `SupplierOrderId` int NOT NULL AUTO_INCREMENT,
  `SupplierId` int DEFAULT NULL,
  `Amount` double DEFAULT NULL,
  `Date` varchar(10) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`SupplierOrderId`),
  KEY `SupplierId_idx` (`SupplierId`),
  CONSTRAINT `qwert` FOREIGN KEY (`SupplierId`) REFERENCES `suppliers` (`SupplierId`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suppliersorders`
--

LOCK TABLES `suppliersorders` WRITE;
/*!40000 ALTER TABLE `suppliersorders` DISABLE KEYS */;
INSERT INTO `suppliersorders` VALUES (1,2,41.6,'2020-03-26','received'),(5,2,800,'2020-03-26','received'),(6,2,42.88,'2020-03-26','received'),(7,2,2.4,'2020-03-26','received'),(8,2,1270,'2020-04-11','received'),(9,2,27000,'2020-04-14','received'),(10,2,1.92,'2020-04-17','received'),(11,2,1507743.5,'2020-04-24','received'),(12,2,108000,'2020-05-02','received'),(13,2,8700,'2020-05-16','sent'),(14,2,457.01,'2020-05-22','sent');
/*!40000 ALTER TABLE `suppliersorders` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-05-23 13:35:18
