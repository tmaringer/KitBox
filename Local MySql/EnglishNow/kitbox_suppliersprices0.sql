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
-- Table structure for table `suppliersprices`
--

DROP TABLE IF EXISTS `suppliersprices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `suppliersprices` (
  `SupplierId` int DEFAULT NULL,
  `Code` text,
  `SuppPrice` double DEFAULT NULL,
  `SuppDelay` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suppliersprices`
--

LOCK TABLES `suppliersprices` WRITE;
/*!40000 ALTER TABLE `suppliersprices` DISABLE KEYS */;
INSERT INTO `suppliersprices` VALUES (2,'ANB100BLCUT',0.23,9),(2,'ANB100BRCUT',0.3,9),(2,'ANB100GLCUT',0.35,9),(2,'ANB100WHCUT',0.45,18),(2,'ANB108BL',0.6,18),(2,'ANB108BR',0.65,13),(2,'ANB108GL',0.74,13),(2,'ANB108WH',0.8,14),(2,'ANB112BL',0.85,14),(2,'ANB112BR',1.06,12),(2,'ANB112GL',1.02,9),(2,'ANB112WH',1.11,16),(2,'ANB125BLCUT',1.3,14),(2,'ANB125BRCUT',1.33,10),(2,'ANB125GLDEC',1.42,15),(2,'ANB125WHCUT',1.4,17),(2,'ANB138BL',1.64,14),(2,'ANB138BR',1.75,10),(2,'ANB138GL',0.18,16),(2,'ANB138WH',0.24,9),(2,'ANB144BL',0.27,13),(2,'ANB144BR',0.37,12),(2,'ANB144GL',0.43,8),(2,'ANB144WH',0.48,11),(2,'ANB150BLCUT',0.54,11),(2,'ANB150BRCUT',0.64,15),(2,'ANB150GLCUT',0.68,13),(2,'ANB150WHCUT',0.79,16),(2,'ANB168BL',0.8,9),(2,'ANB168BR',0.83,17),(2,'ANB168GL',1.05,8),(2,'ANB168WH',1.14,11),(2,'ANB175BLCUT',1.14,13),(2,'ANB175BRCUT',1.21,17),(2,'ANB175GLCUT',1.28,13),(2,'ANB175WHCUT',1.4,11),(2,'ANB180BL',0.24,14),(2,'ANB180BR',0.27,14),(2,'ANB180GL',0.37,15),(2,'ANB180WH',0.4,13),(2,'ANB184BL',0.52,12),(2,'ANB184BR',0.66,14),(2,'ANB184GL',0.68,14),(2,'ANB184WH',0.88,11),(2,'ANB200BLCUT',0.84,9),(2,'ANB200BRCUT',1.05,15),(2,'ANB200GLCUT',1.05,9),(2,'ANB200WHCUT',1.11,17),(2,'ANB216BL',1.21,13),(2,'ANB216BR',1.38,16),(2,'ANB216GL',1.39,15),(2,'ANB216WH',1.54,13),(2,'ANB224BL',1.53,17),(2,'ANB224BR',1.66,15),(2,'ANB224GL',0.15,17),(2,'ANB224WH',0.2,11),(2,'ANB225BLCUT',0.27,12),(2,'ANB225BRCUT',0.31,13),(2,'ANB225GLCUT',0.38,14),(2,'ANB225WHCUT',0.44,15),(2,'ANB230BL',0.45,12),(2,'ANB230BR',0.55,13),(2,'ANB230GL',0.62,11),(2,'ANB230WH',0.73,16),(2,'ANB250BLCUT',0.7,11),(2,'ANB250BRCUT',0.75,17),(2,'ANB250GLCUT',0.92,13),(2,'ANB250WHCUT',0.88,13),(2,'ANB252BL',0.96,17),(2,'ANB252BR',0.98,16),(2,'ANB252GL',1.18,12),(2,'ANB252WH',1.24,15),(2,'ANB275BLCUT',0.0035,13),(2,'ANB275BRCUT',0.42,9),(2,'ANB275GLCUT',0.32,13),(2,'ANB275WHCUT',0.44,15),(2,'ANB276BL',0.32,12),(2,'ANB276BR',0.54,18),(2,'ANB276GL',0.44,12),(2,'ANB276WH',0.48,13),(2,'ANB280BL',0.37,13),(2,'ANB280BR',0.72,18),(2,'ANB280GL',0.52,8),(2,'ANB280WH',0.62,12),(2,'ANB300BLCUT',0.46,14),(2,'ANB300BRCUT',0.78,13),(2,'ANB300GLCUT',0.58,11),(2,'ANB300WHCUT',0.79,14),(2,'ANB325BLCUT',0.53,15),(2,'ANB325BRCUT',0.96,14),(2,'ANB325GLCUT',0.77,15),(2,'ANB325WHCUT',1.06,11),(2,'ANB350BLCUT',0.66,13),(2,'ANB350BRCUT',1.27,12),(2,'ANB350GLCUT',0.95,16),(2,'ANB350WHCUT',1.26,15),(2,'ANB36BL',0.88,16),(2,'ANB36BR',1.33,16),(2,'ANB36GL',1,17),(2,'ANB36WH',1.33,17),(2,'ANB375BLCUT',0.9,17),(2,'ANB375BRCUT',1.56,14),(2,'ANB375GLCUT',1.26,8),(2,'ANB375WHCUT',1.45,13),(2,'ANB46BL',1.1,13),(2,'ANB46BR',1.68,17),(2,'ANB46GL',1.45,17),(2,'ANB46WH',1.85,13),(2,'ANB50BLCUT',1.18,16),(2,'ANB50BRCUT',1.97,14),(2,'ANB50GLCUT',1.54,13),(2,'ANB50WHCUT',1.84,17),(2,'ANB56BL',1.42,12),(2,'ANB56BR',2.1,10),(2,'ANB56GL',1.68,11),(2,'ANB56WH',1.99,15),(2,'ANB72BL',1.49,15),(2,'ANB72BR',2.1,10),(2,'ANB72GL',1.68,11),(2,'ANB72WH',1.99,15),(2,'ANB75BLCUT',1.49,15),(2,'ANB75BRCUT',2.1,10),(2,'ANB75GLCUT',1.68,11),(2,'ANB75WHCUT',1.99,15),(2,'ANB92BL',1.49,15),(2,'ANB92BR',2.1,10),(2,'ANB92GL',1.68,11),(2,'ANB92WH',1.99,15),(2,'CBB100',1.49,15),(2,'CBB120',9.81,14),(2,'CBB32',12.31,10),(2,'CBB42',3.34,14),(2,'CBB52',4.36,13),(2,'CBB62',5.51,14),(2,'CBB80',6.22,17),(2,'CBF100',8.17,12),(2,'CBF120',16.3,11),(2,'CBF32',21.59,16),(2,'CBF42',5.71,14),(2,'CBF52',7.03,9),(2,'CBF62',8.48,13),(2,'CBF80',10.64,17),(2,'CBS32',13.83,8),(2,'CBS42',17.85,9),(2,'CBS52',20.81,18),(2,'CBS62',5.33,17),(2,'CLE27',7.52,16),(2,'CLE37',8.45,14),(2,'CLE47',10.72,15),(2,'Cup',13.57,18),(2,'DOO3232BR',8.93,11),(2,'DOO3232GS',10.09,17),(2,'DOO3232WH',2.46,16),(2,'DOO3242BR',3.34,13),(2,'DOO3242GS',4.28,10),(2,'DOO3242WH',5.51,8),(2,'DOO3252BR',6.16,11),(2,'DOO3252GS',10.12,15),(2,'DOO3252WH',13.25,10),(2,'DOO3262BR',3.53,17),(2,'DOO3262GS',4.71,15),(2,'DOO3262WH',5.68,11),(2,'DOO4232BR',6.75,17),(2,'DOO4232GS',9.41,17),(2,'DOO4232WH',14.07,13),(2,'DOO4242BR',16.12,10),(2,'DOO4242GS',4.11,10),(2,'DOO4242WH',5.64,14),(2,'DOO4252BR',6.66,10),(2,'DOO4252GS',8.46,15),(2,'DOO4252WH',10.31,17),(2,'DOO4262BR',3.43,12),(2,'DOO4262GS',4.12,12),(2,'DOO4262WH',5.62,10),(2,'DOO5232BR',6.31,10),(2,'DOO5232GS',4.3,9),(2,'DOO5232WH',5.79,14),(2,'DOO5242BR',7.09,10),(2,'DOO5242GS',9.06,17),(2,'DOO5242WH',5.71,11),(2,'DOO5252BR',7.05,12),(2,'DOO5252GS',9.44,9),(2,'DOO5252WH',10.43,17),(2,'DOO5262BR',2.52,17),(2,'DOO5262GS',3.28,10),(2,'DOO5262WH',4.25,11),(2,'PAB32100BR',4.9,9),(2,'PAB32100WH',3.58,15),(2,'PAB32120BR',4.84,8),(2,'PAB32120WH',5.98,14),(2,'PAB3232BR',6.91,15),(2,'PAB3232WH',4.62,14),(2,'PAB3242BR',5.55,16),(2,'PAB3242WH',7.27,9),(2,'PAB3252BR',8.75,13),(2,'PAB3252WH',11.07,15),(2,'PAB3262BR',12.39,11),(2,'PAB3262WH',3.33,14),(2,'PAB3280BR',4.33,17),(2,'PAB3280WH',5.31,17),(2,'PAB42100BR',6.31,14),(2,'PAB42100WH',8.22,13),(2,'PAB42120BR',14.3,10),(2,'PAB42120WH',16.22,10),(2,'PAB4232BR',4.55,17),(2,'PAB4232WH',5.95,18),(2,'PAB4242BR',6.95,13),(2,'PAB4242WH',8.55,10),(2,'PAB4252BR',11.46,12),(2,'PAB4252WH',18.15,15),(2,'PAB4262BR',20.47,16),(2,'PAB4262WH',5.06,8),(2,'PAB4280BR',7.32,12),(2,'PAB4280WH',8.46,14),(2,'PAB52100BR',11.02,12),(2,'PAB52100WH',12.67,12),(2,'PAB52120BR',20.87,16),(2,'PAB52120WH',25.73,17),(2,'PAB5232BR',6.76,14),(2,'PAB5232WH',8.38,17),(2,'PAB5242BR',9.68,12),(2,'PAB5242WH',12.92,14),(2,'PAB5252BR',15.1,10),(2,'PAB5252WH',7.77,9),(2,'PAB5262BR',10.73,14),(2,'PAB5262WH',2.64,14),(2,'PAB5280BR',3.61,16),(2,'PAB5280WH',4.51,15),(2,'PHL32100BR',4.94,11),(2,'PHL32100WH',6.2,17),(2,'PHL32120BR',10.23,8),(2,'PHL32120WH',12.4,15),(2,'PHL3232BR',3.34,9),(2,'PHL3232WH',4.7,11),(2,'PHL3242BR',5.87,16),(2,'PHL3242WH',7.11,16),(2,'PHL3252BR',8.22,10),(2,'PHL3252WH',14.2,14),(2,'PHL3262BR',16.37,8),(2,'PHL3262WH',4.12,10),(2,'PHL3280BR',5.48,15),(2,'PHL3280WH',6.51,14),(2,'PHL42100BR',8.75,17),(2,'PHL42100WH',10.38,9),(2,'PHL42120BR',15.11,17),(2,'PHL42120WH',18.22,9),(2,'PHL4232BR',5.12,17),(2,'PHL4232WH',6.39,16),(2,'PHL4242BR',8.04,10),(2,'PHL4242WH',10.41,12),(2,'PHL4252BR',12.21,18),(2,'PHL4252WH',3.14,8),(2,'PHL4262BR',4.35,14),(2,'PHL4262WH',5.53,13),(2,'PHL4280BR',6.88,14),(2,'PHL4280WH',4.2,17),(2,'PHL52100BR',5.84,13),(2,'PHL52100WH',6.67,10),(2,'PHL52120BR',8.23,11),(2,'PHL52120WH',5.23,16),(2,'PHL5232BR',6.96,14),(2,'PHL5232WH',8.29,10),(2,'PHL5242BR',10.95,13),(2,'PHL5242WH',3.45,8),(2,'PHL5252BR',4.68,13),(2,'PHL5252WH',5.4,14),(2,'PHL5262BR',5.97,17),(2,'PHL5262WH',4.43,11),(2,'PHL5280BR',5.75,15),(2,'PHL5280WH',7.15,12),(2,'PHL62100BR',7.83,17),(2,'PHL62100WH',5.24,13),(2,'PHL62120BR',6.97,10),(2,'PHL62120WH',8.43,12),(2,'PHL6232BR',21.36,10),(2,'PHL6232WH',6.3,16),(2,'PHL6242BR',9,14),(2,'PHL6242WH',11.53,15),(2,'PHL6252BR',13.05,10),(2,'PHL6252WH',8.72,18),(2,'PHL6262BR',10.7,15),(2,'PHL6262WH',14.89,15),(2,'PHL6280BR',18.22,15),(2,'PHL6280WH',11.12,9),(2,'PLR3232BR',14.55,15),(2,'PLR3232WH',17.02,11),(2,'PLR3242BR',20.61,17),(2,'PLR3242WH',0.13,14),(2,'PLR3252BR',0.19,8),(2,'PLR3252WH',0.24,10),(2,'PLR3262BR',1.26,10),(2,'PLR3262WH',1.38,10),(2,'PLR4232BR',0.69,10),(2,'PLR4232WH',0.75,10),(2,'PLR4242BR',0.94,10),(2,'PLR4242WH',1.11,10),(2,'PLR4252BR',1.16,11),(2,'PLR4252WH',1.48,12),(2,'PLR4262BR',1.63,8),(2,'PLR4262WH',1.05,16),(2,'PLR5232BR',1.17,14),(2,'PLR5232WH',1.2,9),(2,'PLR5242BR',1.28,16),(2,'PLR5242WH',1.21,12),(2,'PLR5252BR',0.63,11),(2,'PLR5252WH',0.76,17),(2,'PLR5262BR',0.85,14),(2,'PLR5262WH',0.98,12);
/*!40000 ALTER TABLE `suppliersprices` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-03-25 17:26:54
