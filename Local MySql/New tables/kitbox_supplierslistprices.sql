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
-- Table structure for table `supplierslistprices`
--

DROP TABLE IF EXISTS `supplierslistprices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `supplierslistprices` (
  `SupplierId` int DEFAULT NULL,
  `Code` varchar(500) DEFAULT NULL,
  `SuppPrice` double DEFAULT NULL,
  `SuppDelay` int DEFAULT NULL,
  KEY `SupplierId_idx` (`SupplierId`),
  CONSTRAINT `SupplierId1` FOREIGN KEY (`SupplierId`) REFERENCES `suppliers` (`SupplierId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplierslistprices`
--

LOCK TABLES `supplierslistprices` WRITE;
/*!40000 ALTER TABLE `supplierslistprices` DISABLE KEYS */;
INSERT INTO `supplierslistprices` VALUES (1,'ANB100BLCUT',0.77,10),(1,'ANB100BRCUT',0.87,12),(1,'ANB100GLCUT',1.13,5),(1,'ANB100WHCUT',1.08,6),(1,'ANB108BL',0.55,13),(1,'ANB108BR',0.69,7),(1,'ANB108GL',0.84,6),(1,'ANB108WH',0.85,7),(1,'ANB112BL',0.62,6),(1,'ANB112BR',0.74,5),(1,'ANB112GL',0.94,8),(1,'ANB112WH',0.89,12),(1,'ANB125BLCUT',0.83,13),(1,'ANB125BRCUT',1.04,7),(1,'ANB125GLCUT',1.26,6),(1,'ANB125WHCUT',1.28,7),(1,'ANB138BL',0.75,11),(1,'ANB138BR',0.85,12),(1,'ANB138GL',1.02,6),(1,'ANB138WH',1.08,11),(1,'ANB144BL',0.8,5),(1,'ANB144BR',0.82,11),(1,'ANB144GL',1.13,12),(1,'ANB144WH',1.08,3),(1,'ANB150BLCUT',1.13,11),(1,'ANB150BRCUT',1.28,12),(1,'ANB150GLCUT',1.53,6),(1,'ANB150WHCUT',1.62,11),(1,'ANB168BL',0.99,11),(1,'ANB168BR',1.08,4),(1,'ANB168GL',1.27,11),(1,'ANB168WH',1.3,5),(1,'ANB175BLCUT',1.49,11),(1,'ANB175BRCUT',1.62,4),(1,'ANB175GLCUT',1.91,11),(1,'ANB175WHCUT',1.95,5),(1,'ANB180BL',0.94,9),(1,'ANB180BR',1.11,11),(1,'ANB180GL',1.33,9),(1,'ANB180WH',1.33,7),(1,'ANB184BL',1.04,6),(1,'ANB184BR',1.2,5),(1,'ANB184GL',1.46,11),(1,'ANB184WH',1.36,3),(1,'ANB200BLCUT',1.56,6),(1,'ANB200BRCUT',1.8,5),(1,'ANB200GLCUT',2.19,11),(1,'ANB200WHCUT',2.04,3),(1,'ANB216BL',1.17,9),(1,'ANB216BR',1.24,11),(1,'ANB216GL',1.71,10),(1,'ANB216WH',1.63,10),(1,'ANB224BL',1.25,6),(1,'ANB224BR',1.46,9),(1,'ANB224GL',1.69,4),(1,'ANB224WH',1.71,7),(1,'ANB225BLCUT',1.76,9),(1,'ANB225BRCUT',1.86,11),(1,'ANB225GLCUT',2.57,10),(1,'ANB225WHCUT',2.45,10),(1,'ANB230BL',1.28,11),(1,'ANB230BR',1.44,6),(1,'ANB230GL',1.73,9),(1,'ANB230WH',1.71,4),(1,'ANB250BLCUT',1.91,9),(1,'ANB250BRCUT',2.3,10),(1,'ANB250GLCUT',2.76,3),(1,'ANB250WHCUT',2.72,9),(1,'ANB252BL',1.27,9),(1,'ANB252BR',1.53,10),(1,'ANB252GL',1.84,3),(1,'ANB252WH',1.81,9),(1,'ANB275BLCUT',2.28,7),(1,'ANB275BRCUT',2.4,13),(1,'ANB275GLCUT',3.05,7),(1,'ANB275WHCUT',3.24,7),(1,'ANB276BL',1.52,7),(1,'ANB276BR',1.6,13),(1,'ANB276GL',2.03,7),(1,'ANB276WH',2.16,7),(1,'ANB280BL',1.49,8),(1,'ANB280BR',1.84,10),(1,'ANB280GL',2.26,13),(1,'ANB280WH',2.3,10),(1,'ANB300BLCUT',2.24,8),(1,'ANB300BRCUT',2.76,10),(1,'ANB300GLCUT',3.39,13),(1,'ANB300WHCUT',3.45,10),(1,'ANB325BLCUT',2.24,8),(1,'ANB325BRCUT',2.76,10),(1,'ANB325GLCUT',3.39,13),(1,'ANB325WHCUT',3.45,10),(1,'ANB350BLCUT',2.24,8),(1,'ANB350BRCUT',2.76,10),(1,'ANB350GLCUT',3.39,13),(1,'ANB350WHCUT',3.45,10),(1,'ANB36BL',0.21,7),(1,'ANB36BR',0.24,6),(1,'ANB36GL',0.3,7),(1,'ANB36WH',0.3,3),(1,'ANB375BLCUT',2.24,8),(1,'ANB375BRCUT',2.76,10),(1,'ANB375GLCUT',3.39,13),(1,'ANB375WHCUT',3.45,10),(1,'ANB46BL',0.26,9),(1,'ANB46BR',0.29,4),(1,'ANB46GL',0.37,10),(1,'ANB46WH',0.37,12),(1,'ANB50BLCUT',0.51,6),(1,'ANB50BRCUT',0.57,9),(1,'ANB50GLCUT',0.72,8),(1,'ANB50WHCUT',0.69,3),(1,'ANB56BL',0.34,6),(1,'ANB56BR',0.38,9),(1,'ANB56GL',0.48,8),(1,'ANB56WH',0.46,3),(1,'ANB72BL',0.39,13),(1,'ANB72BR',0.46,12),(1,'ANB72GL',0.58,4),(1,'ANB72WH',0.54,12),(1,'ANB75BLCUT',0.59,13),(1,'ANB75BRCUT',0.69,12),(1,'ANB75GLCUT',0.87,4),(1,'ANB75WHCUT',0.81,12),(1,'ANB92BL',0.51,10),(1,'ANB92BR',0.58,12),(1,'ANB92GL',0.75,5),(1,'ANB92WH',0.72,6),(1,'CBB100',1.67,10),(1,'CBB120',1.88,4),(1,'CBB32',0.89,8),(1,'CBB42',0.98,10),(1,'CBB52',1.2,6),(1,'CBB62',1.35,12),(1,'CBB80',1.52,3),(1,'CBF100',1.93,5),(1,'CBF120',1.98,5),(1,'CBF32',1.32,8),(1,'CBF42',1.49,8),(1,'CBF52',1.53,6),(1,'CBF62',1.63,8),(1,'CBF80',1.61,4),(1,'CBS32',0.9,9),(1,'CBS42',1.01,4),(1,'CBS52',1.21,12),(1,'CBS62',1.43,8),(1,'CLE27',0.17,10),(1,'CLE37',0.25,4),(1,'CLE47',0.34,10),(1,'Cup',0.004,13),(1,'DOO3232BR',4.14,4),(1,'DOO3232GS',8.79,11),(1,'DOO3232WH',4.31,7),(1,'DOO3242BR',5.98,7),(1,'DOO3242GS',11.23,5),(1,'DOO3242WH',5.6,10),(1,'DOO3252BR',7.31,5),(1,'DOO3252GS',13.48,11),(1,'DOO3252WH',6.82,12),(1,'DOO3262BR',8.4,7),(1,'DOO3262GS',17.74,6),(1,'DOO3262WH',7.95,12),(1,'DOO4232BR',5.96,11),(1,'DOO4232GS',11.57,10),(1,'DOO4232WH',5.69,6),(1,'DOO4242BR',7.41,12),(1,'DOO4242GS',15.27,10),(1,'DOO4242WH',7.23,6),(1,'DOO4252BR',9.76,4),(1,'DOO4252GS',19.47,5),(1,'DOO4252WH',9.56,10),(1,'DOO4262BR',11.54,5),(1,'DOO4262GS',20.85,9),(1,'DOO4262WH',11.16,5),(1,'DOO5232BR',7.15,11),(1,'DOO5232GS',13.7,13),(1,'DOO5232WH',7.25,7),(1,'DOO5242BR',8.76,3),(1,'DOO5242GS',18.81,12),(1,'DOO5242WH',9.12,12),(1,'DOO5252BR',11.66,6),(1,'DOO5252GS',23.04,12),(1,'DOO5252WH',11.01,11),(1,'DOO5262BR',25.99,11),(1,'DOO5262GS',27.45,8),(1,'DOO5262WH',13.86,4),(1,'PAB32100BR',11.31,11),(1,'PAB32100WH',12.92,13),(1,'PAB32120BR',13.31,5),(1,'PAB32120WH',15.54,6),(1,'PAB3232BR',3.29,7),(1,'PAB3232WH',4.24,10),(1,'PAB3242BR',4.46,8),(1,'PAB3242WH',6,7),(1,'PAB3252BR',5.65,4),(1,'PAB3252WH',7.36,7),(1,'PAB3262BR',6.43,7),(1,'PAB3262WH',8.88,12),(1,'PAB3280BR',8.44,3),(1,'PAB3280WH',10.43,10),(1,'PAB42100BR',13.61,13),(1,'PAB42100WH',22.63,6),(1,'PAB42120BR',16.16,10),(1,'PAB42120WH',25.98,7),(1,'PAB4232BR',4.66,13),(1,'PAB4232WH',7.1,10),(1,'PAB4242BR',5.73,10),(1,'PAB4242WH',9.82,4),(1,'PAB4252BR',7.24,10),(1,'PAB4252WH',11.72,7),(1,'PAB4262BR',9.09,5),(1,'PAB4262WH',13.69,6),(1,'PAB4280BR',11.33,4),(1,'PAB4280WH',16.86,6),(1,'PAB52100BR',17.2,7),(1,'PAB52100WH',21.89,9),(1,'PAB52120BR',19.98,9),(1,'PAB52120WH',26.99,6),(1,'PAB5232BR',5.99,9),(1,'PAB5232WH',7.32,5),(1,'PAB5242BR',7.48,5),(1,'PAB5242WH',9.11,9),(1,'PAB5252BR',9.26,8),(1,'PAB5252WH',10.98,9),(1,'PAB5262BR',10.67,8),(1,'PAB5262WH',14.09,11),(1,'PAB5280BR',14.23,13),(1,'PAB5280WH',16.91,13),(1,'PHL32100BR',11.29,10),(1,'PHL32100WH',12.97,6),(1,'PHL32120BR',13.3,9),(1,'PHL32120WH',16.99,6),(1,'PHL3232BR',3.34,9),(1,'PHL3232WH',4.31,7),(1,'PHL3242BR',4.3,7),(1,'PHL3242WH',5.41,4),(1,'PHL3252BR',5.67,11),(1,'PHL3252WH',6.66,11),(1,'PHL3262BR',6.92,4),(1,'PHL3262WH',8.49,8),(1,'PHL3280BR',8.6,8),(1,'PHL3280WH',10.73,11),(1,'PHL42100BR',15.01,4),(1,'PHL42100WH',17.7,6),(1,'PHL42120BR',17.65,8),(1,'PHL42120WH',22.21,13),(1,'PHL4232BR',4.41,10),(1,'PHL4232WH',5.71,3),(1,'PHL4242BR',5.92,9),(1,'PHL4242WH',7.33,4),(1,'PHL4252BR',7.07,5),(1,'PHL4252WH',9.72,7),(1,'PHL4262BR',9.28,6),(1,'PHL4262WH',10.91,11),(1,'PHL4280BR',11.02,12),(1,'PHL4280WH',13.6,7),(1,'PHL52100BR',17.94,12),(1,'PHL52100WH',23.33,4),(1,'PHL52120BR',20.67,6),(1,'PHL52120WH',28,6),(1,'PHL5232BR',5.44,8),(1,'PHL5232WH',7.25,5),(1,'PHL5242BR',7.03,7),(1,'PHL5242WH',9.46,12),(1,'PHL5252BR',9.67,12),(1,'PHL5252WH',11.25,8),(1,'PHL5262BR',10.83,6),(1,'PHL5262WH',13.65,12),(1,'PHL5280BR',14.27,7),(1,'PHL5280WH',17.55,7),(1,'PHL62100BR',21.16,12),(1,'PHL62100WH',26.08,4),(1,'PHL62120BR',26.55,12),(1,'PHL62120WH',33.13,6),(1,'PHL6232BR',6.52,5),(1,'PHL6232WH',8.92,11),(1,'PHL6242BR',9.12,11),(1,'PHL6242WH',11.02,6),(1,'PHL6252BR',11.56,10),(1,'PHL6252WH',14.1,6),(1,'PHL6262BR',13.41,7),(1,'PHL6262WH',15.86,12),(1,'PHL6280BR',17.8,7),(1,'PHL6280WH',22.2,5),(1,'PLR3232BR',3.6,9),(1,'PLR3232WH',4.53,13),(1,'PLR3242BR',4.47,6),(1,'PLR3242WH',5.82,10),(1,'PLR3252BR',5.49,7),(1,'PLR3252WH',6.9,7),(1,'PLR3262BR',6.49,13),(1,'PLR3262WH',8.31,5),(1,'PLR4232BR',4.42,9),(1,'PLR4232WH',5.46,11),(1,'PLR4242BR',6.2,9),(1,'PLR4252BR',7.05,8),(1,'PLR4252WH',9.16,5),(1,'PLR4262BR',9.29,4),(1,'PLR4262WH',10.93,7),(1,'PLR5232BR',5.39,5),(1,'PLR5232WH',6.83,9),(1,'PLR5242BR',7.36,3),(1,'PLR5242WH',9.32,9),(1,'PLR5252BR',8.81,11),(1,'PLR5252WH',11.51,6),(1,'PLR5262BR',11,11),(1,'PLR5262WH',14.35,12),(2,'ANB100BLCUT',0.46,14),(2,'ANB100BRCUT',0.52,8),(2,'ANB100GLCUT',0.62,12),(2,'ANB100WHCUT',0.68,18),(2,'ANB108BL',0.44,15),(2,'ANB108BR',0.48,11),(2,'ANB108GL',0.66,14),(2,'ANB108WH',0.65,13),(2,'ANB112BL',0.45,12),(2,'ANB112BR',0.54,11),(2,'ANB112GL',0.68,14),(2,'ANB112WH',0.74,13),(2,'ANB125BLCUT',0.53,15),(2,'ANB125BRCUT',0.58,11),(2,'ANB125GLCUT',0.79,14),(2,'ANB125WHCUT',0.78,13),(2,'ANB138BL',0.55,13),(2,'ANB138BR',0.64,15),(2,'ANB138GL',0.88,11),(2,'ANB138WH',0.8,14),(2,'ANB144BL',0.62,11),(2,'ANB144BR',0.68,13),(2,'ANB144GL',0.84,9),(2,'ANB144WH',0.85,14),(2,'ANB150BLCUT',0.66,13),(2,'ANB150BRCUT',0.77,15),(2,'ANB150GLCUT',1.06,11),(2,'ANB150WHCUT',0.96,14),(2,'ANB168BL',0.73,16),(2,'ANB168BR',0.79,16),(2,'ANB168GL',1.05,15),(2,'ANB168WH',1.06,12),(2,'ANB175BLCUT',0.88,16),(2,'ANB175BRCUT',0.95,16),(2,'ANB175GLCUT',1.26,15),(2,'ANB175WHCUT',1.27,12),(2,'ANB180BL',0.7,11),(2,'ANB180BR',0.8,9),(2,'ANB180GL',1.05,9),(2,'ANB180WH',1.02,9),(2,'ANB184BL',0.75,17),(2,'ANB184BR',0.83,17),(2,'ANB184GL',1.11,17),(2,'ANB184WH',1.11,16),(2,'ANB200BLCUT',0.9,17),(2,'ANB200BRCUT',1,17),(2,'ANB200GLCUT',1.33,17),(2,'ANB200WHCUT',1.33,16),(2,'ANB216BL',0.92,13),(2,'ANB216BR',1.05,8),(2,'ANB216GL',1.21,13),(2,'ANB216WH',1.3,14),(2,'ANB224BL',0.88,13),(2,'ANB224BR',1.14,11),(2,'ANB224GL',1.38,16),(2,'ANB224WH',1.33,10),(2,'ANB225BLCUT',1.1,13),(2,'ANB225BRCUT',1.26,8),(2,'ANB225GLCUT',1.45,13),(2,'ANB225WHCUT',1.56,14),(2,'ANB230BL',0.96,17),(2,'ANB230BR',1.14,13),(2,'ANB230GL',1.39,15),(2,'ANB230WH',1.42,15),(2,'ANB250BLCUT',1.18,16),(2,'ANB250BRCUT',1.45,17),(2,'ANB250GLCUT',1.85,13),(2,'ANB250WHCUT',1.68,17),(2,'ANB252BL',0.98,16),(2,'ANB252BR',1.21,17),(2,'ANB252GL',1.54,13),(2,'ANB252WH',1.4,17),(2,'ANB275BLCUT',1.42,12),(2,'ANB275BRCUT',1.54,13),(2,'ANB275GLCUT',1.84,17),(2,'ANB275WHCUT',1.97,14),(2,'ANB276BL',1.18,12),(2,'ANB276BR',1.28,13),(2,'ANB276GL',1.53,17),(2,'ANB276WH',1.64,14),(2,'ANB280BL',1.24,15),(2,'ANB280BR',1.4,11),(2,'ANB280GL',1.66,15),(2,'ANB280WH',1.75,10),(2,'ANB300BLCUT',1.49,15),(2,'ANB300BRCUT',1.68,11),(2,'ANB300GLCUT',1.99,15),(2,'ANB300WHCUT',2.1,10),(2,'ANB325BLCUT',1.49,15),(2,'ANB325BRCUT',1.68,11),(2,'ANB325GLCUT',1.99,15),(2,'ANB325WHCUT',2.1,10),(2,'ANB350BLCUT',1.49,15),(2,'ANB350BRCUT',1.68,11),(2,'ANB350GLCUT',1.99,15),(2,'ANB350WHCUT',2.1,10),(2,'ANB36BL',0.15,17),(2,'ANB36BR',0.18,16),(2,'ANB36GL',0.24,14),(2,'ANB36WH',0.23,9),(2,'ANB375BLCUT',1.49,15),(2,'ANB375BRCUT',1.68,11),(2,'ANB375GLCUT',1.99,15),(2,'ANB375WHCUT',2.1,10),(2,'ANB46BL',0.2,11),(2,'ANB46BR',0.24,9),(2,'ANB46GL',0.27,14),(2,'ANB46WH',0.3,9),(2,'ANB50BLCUT',0.32,12),(2,'ANB50BRCUT',0.32,13),(2,'ANB50GLCUT',0.44,15),(2,'ANB50WHCUT',0.42,9),(2,'ANB56BL',0.27,12),(2,'ANB56BR',0.27,13),(2,'ANB56GL',0.37,15),(2,'ANB56WH',0.35,9),(2,'ANB72BL',0.31,13),(2,'ANB72BR',0.37,12),(2,'ANB72GL',0.4,13),(2,'ANB72WH',0.45,18),(2,'ANB75BLCUT',0.37,13),(2,'ANB75BRCUT',0.44,12),(2,'ANB75GLCUT',0.48,13),(2,'ANB75WHCUT',0.54,18),(2,'ANB92BL',0.38,14),(2,'ANB92BR',0.43,8),(2,'ANB92GL',0.52,12),(2,'ANB92WH',0.6,18),(2,'CBB100',1.26,10),(2,'CBB120',1.38,10),(2,'CBB32',0.69,10),(2,'CBB42',0.75,10),(2,'CBB52',0.94,10),(2,'CBB62',1.11,10),(2,'CBB80',1.16,11),(2,'CBF100',1.48,12),(2,'CBF120',1.63,8),(2,'CBF32',1.05,16),(2,'CBF42',1.17,14),(2,'CBF52',1.2,9),(2,'CBF62',1.28,16),(2,'CBF80',1.21,12),(2,'CBS32',0.63,11),(2,'CBS42',0.76,17),(2,'CBS52',0.85,14),(2,'CBS62',0.98,12),(2,'CLE27',0.13,14),(2,'CLE37',0.19,8),(2,'CLE47',0.24,10),(2,'Cup',0.0035,13),(2,'DOO3232BR',3.45,8),(2,'DOO3232GS',6.3,16),(2,'DOO3232WH',3.14,8),(2,'DOO3242BR',4.68,13),(2,'DOO3242GS',9,14),(2,'DOO3242WH',4.35,14),(2,'DOO3252BR',5.4,14),(2,'DOO3252GS',11.53,15),(2,'DOO3252WH',5.53,13),(2,'DOO3262BR',5.97,17),(2,'DOO3262GS',13.05,10),(2,'DOO3262WH',6.88,14),(2,'DOO4232BR',4.43,11),(2,'DOO4232GS',8.72,18),(2,'DOO4232WH',4.2,17),(2,'DOO4242BR',5.75,15),(2,'DOO4242GS',10.7,15),(2,'DOO4242WH',5.84,13),(2,'DOO4252BR',7.15,12),(2,'DOO4252GS',14.89,15),(2,'DOO4252WH',6.67,10),(2,'DOO4262BR',7.83,17),(2,'DOO4262GS',18.22,15),(2,'DOO4262WH',8.23,11),(2,'DOO5232BR',5.24,13),(2,'DOO5232GS',11.12,9),(2,'DOO5232WH',5.23,16),(2,'DOO5242BR',6.97,10),(2,'DOO5242GS',14.55,15),(2,'DOO5242WH',6.96,14),(2,'DOO5252BR',8.43,12),(2,'DOO5252GS',17.02,11),(2,'DOO5252WH',8.29,10),(2,'DOO5262BR',21.36,10),(2,'DOO5262GS',20.61,17),(2,'DOO5262WH',10.95,13),(2,'PAB32100BR',8.93,11),(2,'PAB32100WH',9.81,14),(2,'PAB32120BR',10.09,17),(2,'PAB32120WH',12.31,10),(2,'PAB3232BR',2.46,16),(2,'PAB3232WH',3.34,14),(2,'PAB3242BR',3.34,13),(2,'PAB3242WH',4.36,13),(2,'PAB3252BR',4.28,10),(2,'PAB3252WH',5.51,14),(2,'PAB3262BR',5.51,8),(2,'PAB3262WH',6.22,17),(2,'PAB3280BR',6.16,11),(2,'PAB3280WH',8.17,12),(2,'PAB42100BR',10.12,15),(2,'PAB42100WH',16.3,11),(2,'PAB42120BR',13.25,10),(2,'PAB42120WH',21.59,16),(2,'PAB4232BR',3.53,17),(2,'PAB4232WH',5.71,14),(2,'PAB4242BR',4.71,15),(2,'PAB4242WH',7.03,9),(2,'PAB4252BR',5.68,11),(2,'PAB4252WH',8.48,13),(2,'PAB4262BR',6.75,17),(2,'PAB4262WH',10.64,17),(2,'PAB4280BR',9.41,17),(2,'PAB4280WH',13.83,8),(2,'PAB52100BR',14.07,13),(2,'PAB52100WH',17.85,9),(2,'PAB52120BR',16.12,10),(2,'PAB52120WH',20.81,18),(2,'PAB5232BR',4.11,10),(2,'PAB5232WH',5.33,17),(2,'PAB5242BR',5.64,14),(2,'PAB5242WH',7.52,16),(2,'PAB5252BR',6.66,10),(2,'PAB5252WH',8.45,14),(2,'PAB5262BR',8.46,15),(2,'PAB5262WH',10.72,15),(2,'PAB5280BR',10.31,17),(2,'PAB5280WH',13.57,18),(2,'PHL32100BR',7.77,9),(2,'PHL32100WH',11.07,15),(2,'PHL32120BR',10.73,14),(2,'PHL32120WH',12.39,11),(2,'PHL3232BR',2.64,14),(2,'PHL3232WH',3.33,14),(2,'PHL3242BR',3.61,16),(2,'PHL3242WH',4.33,17),(2,'PHL3252BR',4.51,15),(2,'PHL3252WH',5.31,17),(2,'PHL3262BR',4.94,11),(2,'PHL3262WH',6.31,14),(2,'PHL3280BR',6.2,17),(2,'PHL3280WH',8.22,13),(2,'PHL42100BR',10.23,8),(2,'PHL42100WH',14.3,10),(2,'PHL42120BR',12.4,15),(2,'PHL42120WH',16.22,10),(2,'PHL4232BR',3.34,9),(2,'PHL4232WH',4.55,17),(2,'PHL4242BR',4.7,11),(2,'PHL4242WH',5.95,18),(2,'PHL4252BR',5.87,16),(2,'PHL4252WH',6.95,13),(2,'PHL4262BR',7.11,16),(2,'PHL4262WH',8.55,10),(2,'PHL4280BR',8.22,10),(2,'PHL4280WH',11.46,12),(2,'PHL52100BR',14.2,14),(2,'PHL52100WH',18.15,15),(2,'PHL52120BR',16.37,8),(2,'PHL52120WH',20.47,16),(2,'PHL5232BR',4.12,10),(2,'PHL5232WH',5.06,8),(2,'PHL5242BR',5.48,15),(2,'PHL5242WH',7.32,12),(2,'PHL5252BR',6.51,14),(2,'PHL5252WH',8.46,14),(2,'PHL5262BR',8.75,17),(2,'PHL5262WH',11.02,12),(2,'PHL5280BR',10.38,9),(2,'PHL5280WH',12.67,12),(2,'PHL62100BR',15.11,17),(2,'PHL62100WH',20.87,16),(2,'PHL62120BR',18.22,9),(2,'PHL62120WH',25.73,17),(2,'PHL6232BR',5.12,17),(2,'PHL6232WH',6.76,14),(2,'PHL6242BR',6.39,16),(2,'PHL6242WH',8.38,17),(2,'PHL6252BR',8.04,10),(2,'PHL6252WH',9.68,12),(2,'PHL6262BR',10.41,12),(2,'PHL6262WH',12.92,14),(2,'PHL6280BR',12.21,18),(2,'PHL6280WH',15.1,10),(2,'PLR3232BR',2.52,17),(2,'PLR3232WH',3.43,12),(2,'PLR3242BR',3.28,10),(2,'PLR3242WH',4.12,12),(2,'PLR3252BR',4.25,11),(2,'PLR3252WH',5.62,10),(2,'PLR3262BR',4.9,9),(2,'PLR3262WH',6.31,10),(2,'PLR4232BR',3.58,15),(2,'PLR4232WH',4.3,9),(2,'PLR4242BR',4.84,8),(2,'PLR4242WH',5.79,14),(2,'PLR4252BR',5.98,14),(2,'PLR4252WH',7.09,10),(2,'PLR4262BR',6.91,15),(2,'PLR4262WH',9.06,17),(2,'PLR5232BR',4.62,14),(2,'PLR5232WH',5.71,11),(2,'PLR5242BR',5.55,16),(2,'PLR5242WH',7.05,12),(2,'PLR5252BR',7.27,9),(2,'PLR5252WH',9.44,9),(2,'PLR5262BR',8.75,13),(2,'PLR5262WH',10.43,17);
/*!40000 ALTER TABLE `supplierslistprices` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-05-23 13:35:17
