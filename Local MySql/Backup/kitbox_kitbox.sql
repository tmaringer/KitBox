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
-- Table structure for table `kitbox`
--

DROP TABLE IF EXISTS `kitbox`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kitbox` (
  `Ref` text,
  `Code` varchar(50) NOT NULL,
  `Dimensions` text,
  `Hauteur` int DEFAULT NULL,
  `Profondeur` int DEFAULT NULL,
  `Largeur` int DEFAULT NULL,
  `Couleur` text,
  `Enstock` int DEFAULT NULL,
  `StockMinimum` int DEFAULT NULL,
  `PrixClient` text,
  `NbPiecesCasier` int DEFAULT NULL,
  PRIMARY KEY (`Code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kitbox`
--

LOCK TABLES `kitbox` WRITE;
/*!40000 ALTER TABLE `kitbox` DISABLE KEYS */;
INSERT INTO `kitbox` VALUES ('Cornieres','COR100BLDEC','100(h)decoupee',100,0,0,'Blanc',32,528,'1,72',4),('Cornieres','COR100BRDEC','100(h)decoupee',100,0,0,'Brun',10,546,'1,38',4),('Cornieres','COR100GLDEC','100(h)decoupee',100,0,0,'Galvanise',84,545,'1,72',4),('Cornieres','COR100NRDEC','100(h)decoupee',100,0,0,'Noir',87,560,'1,2',4),('Cornieres','COR108BL','3x32(h)',108,0,0,'Blanc',84,542,'0,97',4),('Cornieres','COR108BR','3x32(h)',108,0,0,'Brun',87,538,'0,776',4),('Cornieres','COR108GL','3x32(h)',108,0,0,'Galvanise',87,511,'0,97',4),('Cornieres','COR108NR','3x32(h)',108,0,0,'Noir',86,532,'0,679',4),('Cornieres','COR112BL','2x52(h)',112,0,0,'Blanc',82,527,'1,06',4),('Cornieres','COR112BR','2x52(h)',112,0,0,'Brun',82,513,'0,848',4),('Cornieres','COR112GL','2x52(h)',112,0,0,'Galvanise',88,543,'1,06',4),('Cornieres','COR112NR','2x52(h)',112,0,0,'Noir',89,540,'0,742',4),('Cornieres','COR125BLDEC','125(h)decoupee',125,0,0,'Blanc',83,520,'1,94',4),('Cornieres','COR125BRDEC','125(h)decoupee',125,0,0,'Brun',84,525,'1,55',4),('Cornieres','COR125GLDEC','125(h)decoupee',125,0,0,'Galvanise',83,557,'1,94',4),('Cornieres','COR125NRDEC','125(h)decoupee',125,0,0,'Noir',86,518,'1,36',4),('Cornieres','COR138BL','3x42(h)',138,0,0,'Blanc',83,521,'1,27',4),('Cornieres','COR138BR','3x42(h)',138,0,0,'Brun',87,531,'1,016',4),('Cornieres','COR138GL','3x42(h)',138,0,0,'Galvanise',89,539,'1,27',4),('Cornieres','COR138NR','3x42(h)',138,0,0,'Noir',83,520,'0,889',4),('Cornieres','COR144BL','4x32(h)',144,0,0,'Blanc',86,547,'1,28',4),('Cornieres','COR144BR','4x32(h)',144,0,0,'Brun',87,502,'1,024',4),('Cornieres','COR144GL','4x32(h)',144,0,0,'Galvanise',84,514,'1,28',4),('Cornieres','COR144NR','4x32(h)',144,0,0,'Noir',88,546,'0,896',4),('Cornieres','COR150BLDEC','150(h)decoupee',150,0,0,'Blanc',89,556,'2,54',4),('Cornieres','COR150BRDEC','150(h)decoupee',150,0,0,'Brun',87,529,'2,03',4),('Cornieres','COR150GLDEC','150(h)decoupee',150,0,0,'Galvanise',87,535,'2,54',4),('Cornieres','COR150NRDEC','150(h)decoupee',150,0,0,'Noir',87,506,'1,78',4),('Cornieres','COR168BL','3x52(h)',168,0,0,'Blanc',89,524,'1,57',4),('Cornieres','COR168BR','3x52(h)',168,0,0,'Brun',83,516,'1,256',4),('Cornieres','COR168GL','3x52(h)',168,0,0,'Galvanise',88,544,'1,57',4),('Cornieres','COR168NR','3x52(h)',168,0,0,'Noir',80,506,'1,099',4),('Cornieres','COR175BLDEC','175(h)decoupee',175,0,0,'Blanc',81,519,'3,14',4),('Cornieres','COR175BRDEC','175(h)decoupee',175,0,0,'Brun',83,521,'2,51',4),('Cornieres','COR175GLDEC','175(h)decoupee',175,0,0,'Galvanise',86,499,'3,14',4),('Cornieres','COR175NRDEC','175(h)decoupee',175,0,0,'Noir',85,544,'2,2',4),('Cornieres','COR180BL','5x32(h)',180,0,0,'Blanc',89,525,'1,59',4),('Cornieres','COR180BR','5x32(h)',180,0,0,'Brun',89,520,'1,272',4),('Cornieres','COR180GL','5x32(h)',180,0,0,'Galvanise',84,546,'1,59',4),('Cornieres','COR180NR','5x32(h)',180,0,0,'Noir',83,535,'1,113',4),('Cornieres','COR184BL','4x42(h)',184,0,0,'Blanc',89,536,'1,68',4),('Cornieres','COR184BR','4x42(h)',184,0,0,'Brun',84,516,'1,344',4),('Cornieres','COR184GL','4x42(h)',184,0,0,'Galvanise',86,543,'1,68',4),('Cornieres','COR184NR','4x42(h)',184,0,0,'Noir',88,524,'1,176',4),('Cornieres','COR200BLDEC','200(h)decoupee',200,0,0,'Blanc',85,534,'3,36',4),('Cornieres','COR200BRDEC','200(h)decoupee',200,0,0,'Brun',86,534,'2,69',4),('Cornieres','COR200GLDEC','200(h)decoupee',200,0,0,'Galvanise',84,554,'3,36',4),('Cornieres','COR200NRDEC','200(h)decoupee',200,0,0,'Noir',90,525,'2,35',4),('Cornieres','COR216BL','6x32(h)',216,0,0,'Blanc',84,533,'1,9',4),('Cornieres','COR216BR','6x32(h)',216,0,0,'Brun',81,522,'1,52',4),('Cornieres','COR216GL','6x32(h)',216,0,0,'Galvanise',88,523,'1,9',4),('Cornieres','COR216NR','6x32(h)',216,0,0,'Noir',80,524,'1,33',4),('Cornieres','COR224BL','4x52(h)',224,0,0,'Blanc',84,541,'2,08',4),('Cornieres','COR224BR','4x52(h)',224,0,0,'Brun',83,543,'1,664',4),('Cornieres','COR224GL','4x52(h)',224,0,0,'Galvanise',87,540,'2,08',4),('Cornieres','COR224NR','4x52(h)',224,0,0,'Noir',84,543,'1,456',4),('Cornieres','COR225BLDEC','225(h)decoupee',225,0,0,'Blanc',88,544,'3,8',4),('Cornieres','COR225BRDEC','225(h)decoupee',225,0,0,'Brun',86,539,'3,04',4),('Cornieres','COR225GLDEC','225(h)decoupee',225,0,0,'Galvanise',86,543,'3,8',4),('Cornieres','COR225NRDEC','225(h)decoupee',225,0,0,'Noir',88,545,'2,66',4),('Cornieres','COR230BL','5x42(h)',230,0,0,'Blanc',83,556,'2,09',4),('Cornieres','COR230BR','5x42(h)',230,0,0,'Brun',80,522,'1,672',4),('Cornieres','COR230GL','5x42(h)',230,0,0,'Galvanise',88,537,'2,09',4),('Cornieres','COR230NR','5x42(h)',230,0,0,'Noir',83,514,'1,463',4),('Cornieres','COR250BLDEC','250(h)decoupee',250,0,0,'Blanc',87,502,'4,42',4),('Cornieres','COR250BRDEC','250(h)decoupee',250,0,0,'Brun',81,520,'3,54',4),('Cornieres','COR250GLDEC','250(h)decoupee',250,0,0,'Galvanise',82,529,'4,42',4),('Cornieres','COR250NRDEC','250(h)decoupee',250,0,0,'Noir',86,544,'3,09',4),('Cornieres','COR252BL','7x32(h)',252,0,0,'Blanc',80,534,'2,21',4),('Cornieres','COR252BR','7x32(h)',252,0,0,'Brun',89,528,'1,768',4),('Cornieres','COR252GL','7x32(h)',252,0,0,'Galvanise',89,522,'2,21',4),('Cornieres','COR252NR','7x32(h)',252,0,0,'Noir',80,540,'1,547',4),('Cornieres','COR275BLDEC','275(h)decoupee',275,0,0,'Blanc',82,506,'5',4),('Cornieres','COR275BRDEC','275(h)decoupee',275,0,0,'Brun',82,510,'4',4),('Cornieres','COR275GLDEC','275(h)decoupee',275,0,0,'Galvanise',87,529,'5',4),('Cornieres','COR275NRDEC','275(h)decoupee',275,0,0,'Noir',81,533,'3,5',4),('Cornieres','COR276BL','6x42(h)',276,0,0,'Blanc',86,559,'2,5',4),('Cornieres','COR276BR','6x42(h)',276,0,0,'Brun',90,503,'2',4),('Cornieres','COR276GL','6x42(h)',276,0,0,'Galvanise',81,540,'2,5',4),('Cornieres','COR276NR','6x42(h)',276,0,0,'Noir',83,536,'1,75',4),('Cornieres','COR280BL','5x52(h)',280,0,0,'Blanc',84,474,'2,59',4),('Cornieres','COR280BR','5x52(h)',280,0,0,'Brun',86,578,'2,072',4),('Cornieres','COR280GL','5x52(h)',280,0,0,'Galvanise',86,527,'2,59',4),('Cornieres','COR280NR','5x52(h)',280,0,0,'Noir',86,526,'1,813',4),('Cornieres','COR300BLDEC','300(h)decoupee',300,0,0,'Blanc',90,519,'5,18',4),('Cornieres','COR300BRDEC','300(h)decoupee',300,0,0,'Brun',88,535,'4,14',4),('Cornieres','COR300GLDEC','300(h)decoupee',300,0,0,'Galvanise',83,541,'5,18',4),('Cornieres','COR300NRDEC','300(h)decoupee',300,0,0,'Noir',84,573,'3,63',4),('Cornieres','COR325BLDEC','325(h)decoupee',325,0,0,'Blanc',86,531,'5,18',4),('Cornieres','COR325BRDEC','325(h)decoupee',325,0,0,'Brun',88,536,'4,14',4),('Cornieres','COR325GLDEC','325(h)decoupee',325,0,0,'Galvanise',90,504,'5,18',4),('Cornieres','COR325NRDEC','325(h)decoupee',325,0,0,'Noir',87,529,'3,63',4),('Cornieres','COR350BLDEC','350(h)decoupee',350,0,0,'Blanc',84,514,'5,18',4),('Cornieres','COR350BRDEC','350(h)decoupee',350,0,0,'Brun',84,524,'4,14',4),('Cornieres','COR350GLDEC','350(h)decoupee',350,0,0,'Galvanise',83,521,'5,18',4),('Cornieres','COR350NRDEC','350(h)decoupee',350,0,0,'Noir',85,556,'3,63',4),('Cornieres','COR36BL','1x32(h)',36,0,0,'Blanc',48,542,'0,35',4),('Cornieres','COR36BR','1x32(h)',36,0,0,'Brun',82,529,'0,28',4),('Cornieres','COR36GL','1x32(h)',36,0,0,'Galvanise',81,554,'0,35',4),('Cornieres','COR36NR','1x32(h)',36,0,0,'Noir',84,525,'0,245',4),('Cornieres','COR375BLDEC','375(h)decoupee',375,0,0,'Blanc',82,506,'5,18',4),('Cornieres','COR375BRDEC','375(h)decoupee',375,0,0,'Brun',81,523,'4,14',4),('Cornieres','COR375GLDEC','375(h)decoupee',375,0,0,'Galvanise',86,527,'5,18',4),('Cornieres','COR375NRDEC','375(h)decoupee',375,0,0,'Noir',89,532,'3,63',4),('Cornieres','COR46BL','1x42(h)',46,0,0,'Blanc',89,537,'0,45',4),('Cornieres','COR46BR','1x42(h)',46,0,0,'Brun',87,527,'0,36',4),('Cornieres','COR46GL','1x42(h)',46,0,0,'Galvanise',82,521,'0,45',4),('Cornieres','COR46NR','1x42(h)',46,0,0,'Noir',90,527,'0,315',4),('Cornieres','COR50BLDEC','50(h)decoupee',50,0,0,'Blanc',84,528,'1,1',4),('Cornieres','COR50BRDEC','50(h)decoupee',50,0,0,'Brun',86,519,'0,88',4),('Cornieres','COR50GLDEC','50(h)decoupee',50,0,0,'Galvanise',82,555,'1,1',4),('Cornieres','COR50NRDEC','50(h)decoupee',50,0,0,'Noir',82,537,'0,77',4),('Cornieres','COR56BL','1x52(h)',56,0,0,'Blanc',89,532,'0,55',4),('Cornieres','COR56BR','1x52(h)',56,0,0,'Brun',86,520,'0,44',4),('Cornieres','COR56GL','1x52(h)',56,0,0,'Galvanise',82,528,'0,55',4),('Cornieres','COR56NR','1x52(h)',56,0,0,'Noir',89,555,'0,385',4),('Cornieres','COR72BL','2x32(h)',72,0,0,'Blanc',82,534,'0,66',4),('Cornieres','COR72BR','2x32(h)',72,0,0,'Brun',85,549,'0,528',4),('Cornieres','COR72GL','2x32(h)',72,0,0,'Galvanise',83,487,'0,66',4),('Cornieres','COR72NR','2x32(h)',72,0,0,'Noir',81,535,'0,462',4),('Cornieres','COR75BLDEC','75(h)decoupee',75,0,0,'Blanc',89,531,'1,32',4),('Cornieres','COR75BRDEC','75(h)decoupee',75,0,0,'Brun',83,535,'1,06',4),('Cornieres','COR75GLDEC','75(h)decoupee',75,0,0,'Galvanise',84,539,'1,32',4),('Cornieres','COR75NRDEC','75(h)decoupee',75,0,0,'Noir',81,520,'0,92',4),('Cornieres','COR92BL','2x42(h)',92,0,0,'Blanc',85,531,'0,86',4),('Cornieres','COR92BR','2x42(h)',92,0,0,'Brun',83,531,'0,688',4),('Cornieres','COR92GL','2x42(h)',92,0,0,'Galvanise',82,539,'0,86',4),('Cornieres','COR92NR','2x42(h)',92,0,0,'Noir',87,532,'0,602',4),('Coupelles','COUPEL','6cmDiam',0,0,0,'',42,518,'0,005',2),('Panneau GD','PAG3232BL','32(h)x32(p)',32,32,0,'Blanc',45,478,'5,12',2),('Panneau GD','PAG3232BR','32(h)x32(p)',32,32,0,'Brun',44,541,'4,096',2),('Panneau GD','PAG3242BL','32(h)x42(p)',32,42,0,'Blanc',50,516,'6,72',2),('Panneau GD','PAG3242BR','32(h)x42(p)',32,42,0,'Brun',48,511,'5,376',2),('Panneau GD','PAG3252BL','32(h)x52(p)',32,52,0,'Blanc',41,513,'8,32',2),('Panneau GD','PAG3252BR','32(h)x52(p)',32,52,0,'Brun',42,515,'6,656',2),('Panneau GD','PAG3262BL','32(h)x62(p)',32,62,0,'Blanc',49,514,'9,92',2),('Panneau GD','PAG3262BR','32(h)x62(p)',32,62,0,'Brun',41,527,'7,936',2),('Panneau GD','PAG4232BL','42(h)x32(p)',42,32,0,'Blanc',49,527,'6,72',2),('Panneau GD','PAG4232BR','42(h)x32(p)',42,32,0,'Brun',41,540,'5,376',2),('Panneau GD','PAG4242BL','42(h)x42(p)',42,42,0,'Blanc',43,552,'8,82',2),('Panneau GD','PAG4242BR','42(h)x42(p)',42,42,0,'Brun',43,526,'7,056',2),('Panneau GD','PAG4252BL','42(h)x52(p)',42,52,0,'Blanc',45,522,'10,92',2),('Panneau GD','PAG4252BR','42(h)x52(p)',42,52,0,'Brun',47,535,'8,736',2),('Panneau GD','PAG4262BL','42(h)x62(p)',42,62,0,'Blanc',43,551,'13,02',2),('Panneau GD','PAG4262BR','42(h)x62(p)',42,62,0,'Brun',45,528,'10,416',2),('Panneau GD','PAG5232BL','52(h)x32(p)',52,32,0,'Blanc',50,550,'8,32',2),('Panneau GD','PAG5232BR','52(h)x32(p)',52,32,0,'Brun',47,514,'6,656',2),('Panneau GD','PAG5242BL','52(h)x42(p)',52,42,0,'Blanc',47,518,'10,92',2),('Panneau GD','PAG5242BR','52(h)x42(p)',52,42,0,'Brun',49,573,'8,736',2),('Panneau GD','PAG5252BL','52(h)x52(p)',52,52,0,'Blanc',47,519,'13,52',2),('Panneau GD','PAG5252BR','52(h)x52(p)',52,52,0,'Brun',47,530,'10,816',2),('Panneau GD','PAG5262BL','52(h)x62(p)',52,62,0,'Blanc',48,544,'16,12',2),('Panneau GD','PAG5262BR','52(h)x62(p)',52,62,0,'Brun',44,548,'12,896',2),('Panneau HB','PAH32100BL','32(p)x100(L)',0,32,100,'Blanc',49,501,'16',2),('Panneau HB','PAH32100BR','32(p)x100(L)',0,32,100,'Brun',42,500,'12,8',2),('Panneau HB','PAH32120BL','32(p)x120(L)',0,32,120,'Blanc',47,536,'19,2',2),('Panneau HB','PAH32120BR','32(p)x120(L)',0,32,120,'Brun',50,537,'15,36',2),('Panneau HB','PAH3232BL','32(p)x32(L)',0,32,32,'Blanc',50,538,'5,12',2),('Panneau HB','PAH3232BR','32(p)x32(L)',0,32,32,'Brun',41,534,'4,096',2),('Panneau HB','PAH3242BL','32(p)x42(L)',0,32,42,'Blanc',42,548,'6,72',2),('Panneau HB','PAH3242BR','32(p)x42(L)',0,32,42,'Brun',46,524,'5,376',2),('Panneau HB','PAH3252BL','32(p)x52(L)',0,32,52,'Blanc',41,524,'8,32',2),('Panneau HB','PAH3252BR','32(p)x52(L)',0,32,52,'Brun',48,561,'6,656',2),('Panneau HB','PAH3262BL','32(p)x62(L)',0,32,62,'Blanc',44,530,'9,92',2),('Panneau HB','PAH3262BR','32(p)x62(L)',0,32,62,'Brun',44,542,'7,936',2),('Panneau HB','PAH3280BL','32(p)x80(L)',0,32,80,'Blanc',48,535,'12,8',2),('Panneau HB','PAH3280BR','32(p)x80(L)',0,32,80,'Brun',48,534,'10,24',2),('Panneau HB','PAH42100BL','42(p)x100(L)',0,42,100,'Blanc',46,562,'21',2),('Panneau HB','PAH42100BR','42(p)x100(L)',0,42,100,'Brun',43,523,'16,8',2),('Panneau HB','PAH42120BL','42(p)x120(L)',0,42,120,'Blanc',41,533,'25,2',2),('Panneau HB','PAH42120BR','42(p)x120(L)',0,42,120,'Brun',45,524,'20,16',2),('Panneau HB','PAH4232BL','42(p)x32(L)',0,42,32,'Blanc',43,547,'6,72',2),('Panneau HB','PAH4232BR','42(p)x32(L)',0,42,32,'Brun',43,529,'5,376',2),('Panneau HB','PAH4242BL','42(p)x42(L)',0,42,42,'Blanc',40,510,'8,82',2),('Panneau HB','PAH4242BR','42(p)x42(L)',0,42,42,'Brun',44,523,'7,056',2),('Panneau HB','PAH4252BL','42(p)x52(L)',0,42,52,'Blanc',46,509,'10,92',2),('Panneau HB','PAH4252BR','42(p)x52(L)',0,42,52,'Brun',46,524,'8,736',2),('Panneau HB','PAH4262BL','42(p)x62(L)',0,42,62,'Blanc',45,540,'13,02',2),('Panneau HB','PAH4262BR','42(p)x62(L)',0,42,62,'Brun',48,533,'10,416',2),('Panneau HB','PAH4280BL','42(p)x80(L)',0,42,80,'Blanc',50,525,'16,8',2),('Panneau HB','PAH4280BR','42(p)x80(L)',0,42,80,'Brun',45,524,'13,44',2),('Panneau HB','PAH52100BL','52(p)x100(L)',0,52,100,'Blanc',49,518,'26',2),('Panneau HB','PAH52100BR','52(p)x100(L)',0,52,100,'Brun',42,513,'20,8',2),('Panneau HB','PAH52120BL','52(p)x120(L)',0,52,120,'Blanc',49,525,'31,2',2),('Panneau HB','PAH52120BR','52(p)x120(L)',0,52,120,'Brun',49,559,'24,96',2),('Panneau HB','PAH5232BL','52(p)x32(L)',0,52,32,'Blanc',45,512,'8,32',2),('Panneau HB','PAH5232BR','52(p)x32(L)',0,52,32,'Brun',42,535,'6,656',2),('Panneau HB','PAH5242BL','52(p)x42(L)',0,52,42,'Blanc',44,551,'10,92',2),('Panneau HB','PAH5242BR','52(p)x42(L)',0,52,42,'Brun',45,554,'8,736',2),('Panneau HB','PAH5252BL','52(p)x52(L)',0,52,52,'Blanc',42,546,'13,52',2),('Panneau HB','PAH5252BR','52(p)x52(L)',0,52,52,'Brun',43,502,'10,816',2),('Panneau HB','PAH5262BL','52(p)x62(L)',0,52,62,'Blanc',46,529,'16,12',2),('Panneau HB','PAH5262BR','52(p)x62(L)',0,52,62,'Brun',42,538,'12,896',2),('Panneau HB','PAH5280BL','52(p)x80(L)',0,52,80,'Blanc',41,552,'20,8',2),('Panneau HB','PAH5280BR','52(p)x80(L)',0,52,80,'Brun',48,505,'16,64',2),('Panneau HB','PAH62100BL','62(p)x100(L)',0,62,100,'Blanc',44,509,'31',2),('Panneau HB','PAH62100BR','62(p)x100(L)',0,62,100,'Brun',50,538,'24,8',2),('Panneau HB','PAH62120BL','62(p)x120(L)',0,62,120,'Blanc',43,520,'37,2',2),('Panneau HB','PAH62120BR','62(p)x120(L)',0,62,120,'Brun',45,541,'29,76',2),('Panneau HB','PAH6232BL','62(p)x32(L)',0,62,32,'Blanc',44,521,'9,92',2),('Panneau HB','PAH6232BR','62(p)x32(L)',0,62,32,'Brun',48,512,'7,936',2),('Panneau HB','PAH6242BL','62(p)x42(L)',0,62,42,'Blanc',44,538,'13,02',2),('Panneau HB','PAH6242BR','62(p)x42(L)',0,62,42,'Brun',40,524,'10,416',2),('Panneau HB','PAH6252BL','62(p)x52(L)',0,62,52,'Blanc',44,532,'16,12',2),('Panneau HB','PAH6252BR','62(p)x52(L)',0,62,52,'Brun',45,535,'12,896',2),('Panneau HB','PAH6262BL','62(p)x62(L)',0,62,62,'Blanc',46,515,'19,22',2),('Panneau HB','PAH6262BR','62(p)x62(L)',0,62,62,'Brun',45,528,'15,376',2),('Panneau HB','PAH6280BL','62(p)x80(L)',0,62,80,'Blanc',48,526,'24,8',2),('Panneau HB','PAH6280BR','62(p)x80(L)',0,62,80,'Brun',50,570,'19,84',2),('Panneau Ar','PAR32100BL','32(h)x100(L)',32,0,100,'Blanc',21,530,'16',1),('Panneau Ar','PAR32100BR','32(h)x100(L)',32,0,100,'Brun',23,544,'12,8',1),('Panneau Ar','PAR32120BL','32(h)x120(L)',32,0,120,'Blanc',30,508,'19,2',1),('Panneau Ar','PAR32120BR','32(h)x120(L)',32,0,120,'Brun',29,511,'15,36',1),('Panneau Ar','PAR3232BL','32(h)x32(L)',32,0,32,'Blanc',23,538,'5,12',1),('Panneau Ar','PAR3232BR','32(h)x32(L)',32,0,32,'Brun',26,508,'4,096',1),('Panneau Ar','PAR3242BL','32(h)x42(L)',32,0,42,'Blanc',29,543,'6,72',1),('Panneau Ar','PAR3242BR','32(h)x42(L)',32,0,42,'Brun',21,544,'5,376',1),('Panneau Ar','PAR3252BL','32(h)x52(L)',32,0,52,'Blanc',21,508,'8,32',1),('Panneau Ar','PAR3252BR','32(h)x52(L)',32,0,52,'Brun',24,528,'6,656',1),('Panneau Ar','PAR3262BL','32(h)x62(L)',32,0,62,'Blanc',26,555,'9,92',1),('Panneau Ar','PAR3262BR','32(h)x62(L)',32,0,62,'Brun',27,498,'7,936',1),('Panneau Ar','PAR3280BL','32(h)x80(L)',32,0,80,'Blanc',25,502,'12,8',1),('Panneau Ar','PAR3280BR','32(h)x80(L)',32,0,80,'Brun',29,556,'10,24',1),('Panneau Ar','PAR42100BL','42(h)x100(L)',42,0,100,'Blanc',27,536,'26',1),('Panneau Ar','PAR42100BR','42(h)x100(L)',42,0,100,'Brun',24,528,'16,8',1),('Panneau Ar','PAR42120BL','42(h)x120(L)',42,0,120,'Blanc',30,531,'31,2',1),('Panneau Ar','PAR42120BR','42(h)x120(L)',42,0,120,'Brun',21,566,'20,16',1),('Panneau Ar','PAR4232BL','42(h)x32(L)',42,0,32,'Blanc',23,512,'8,32',1),('Panneau Ar','PAR4232BR','42(h)x32(L)',42,0,32,'Brun',25,531,'5,376',1),('Panneau Ar','PAR4242BL','42(h)x42(L)',42,0,42,'Blanc',29,525,'10,92',1),('Panneau Ar','PAR4242BR','42(h)x42(L)',42,0,42,'Brun',25,503,'7,056',1),('Panneau Ar','PAR4252BL','42(h)x52(L)',42,0,52,'Blanc',24,534,'13,52',1),('Panneau Ar','PAR4252BR','42(h)x52(L)',42,0,52,'Brun',26,533,'8,736',1),('Panneau Ar','PAR4262BL','42(h)x62(L)',42,0,62,'Blanc',30,506,'16,12',1),('Panneau Ar','PAR4262BR','42(h)x62(L)',42,0,62,'Brun',27,532,'10,416',1),('Panneau Ar','PAR4280BL','42(h)x80(L)',42,0,80,'Blanc',24,523,'20,8',1),('Panneau Ar','PAR4280BR','42(h)x80(L)',42,0,80,'Brun',26,529,'13,44',1),('Panneau Ar','PAR52100BL','52(h)x100(L)',52,0,100,'Blanc',27,507,'26',1),('Panneau Ar','PAR52100BR','52(h)x100(L)',52,0,100,'Brun',23,538,'20,8',1),('Panneau Ar','PAR52120BL','52(h)x120(L)',52,0,120,'Blanc',30,516,'31,2',1),('Panneau Ar','PAR52120BR','52(h)x120(L)',52,0,120,'Brun',24,521,'24,96',1),('Panneau Ar','PAR5232BL','52(h)x32(L)',52,0,32,'Blanc',28,541,'8,32',1),('Panneau Ar','PAR5232BR','52(h)x32(L)',52,0,32,'Brun',22,541,'6,656',1),('Panneau Ar','PAR5242BL','52(h)x42(L)',52,0,42,'Blanc',20,531,'10,92',1),('Panneau Ar','PAR5242BR','52(h)x42(L)',52,0,42,'Brun',20,529,'8,736',1),('Panneau Ar','PAR5252BL','52(h)x52(L)',52,0,52,'Blanc',22,555,'13,52',1),('Panneau Ar','PAR5252BR','52(h)x52(L)',52,0,52,'Brun',24,546,'10,816',1),('Panneau Ar','PAR5262BL','52(h)x62(L)',52,0,62,'Blanc',28,515,'16,12',1),('Panneau Ar','PAR5262BR','52(h)x62(L)',52,0,62,'Brun',28,525,'12,896',1),('Panneau Ar','PAR5280BL','52(h)x80(L)',52,0,80,'Blanc',28,525,'20,8',1),('Panneau Ar','PAR5280BR','52(h)x80(L)',52,0,80,'Brun',28,498,'16,64',1),('Porte ','POR3232BL','32(h)x32(L)',32,0,32,'Blanc',41,556,'5,12',2),('Porte ','POR3232BR','32(h)x32(L)',32,0,32,'Brun',46,538,'5,12',2),('Porte ','POR3232VE','32(h)x32(L)',32,0,32,'Verre',46,512,'10,24',2),('Porte ','POR3242BL','32(h)x42(L)',32,0,42,'Blanc',42,544,'6,72',2),('Porte ','POR3242BR','32(h)x42(L)',32,0,42,'Brun',42,531,'6,72',2),('Porte ','POR3242VE','32(h)x42(L)',32,0,42,'Verre',50,516,'13,44',2),('Porte ','POR3252BL','32(h)x52(L)',32,0,52,'Blanc',46,536,'8,32',2),('Porte ','POR3252BR','32(h)x52(L)',32,0,52,'Brun',47,528,'8,32',2),('Porte ','POR3252VE','32(h)x52(L)',32,0,52,'Verre',42,544,'16,64',2),('Porte ','POR3262BL','32(h)x62(L)',32,0,62,'Blanc',42,531,'9,92',2),('Porte ','POR3262BR','32(h)x62(L)',32,0,62,'Brun',40,511,'9,92',2),('Porte ','POR3262VE','32(h)x62(L)',32,0,62,'Verre',40,519,'19,84',2),('Porte ','POR4232BL','42(h)x32(L)',42,0,32,'Blanc',47,529,'6,72',2),('Porte ','POR4232BR','42(h)x32(L)',42,0,32,'Brun',46,528,'6,72',2),('Porte ','POR4232VE','42(h)x32(L)',42,0,32,'Verre',43,508,'13,44',2),('Porte ','POR4242BL','42(h)x42(L)',42,0,42,'Blanc',44,502,'8,82',2),('Porte ','POR4242BR','42(h)x42(L)',42,0,42,'Brun',43,528,'8,82',2),('Porte ','POR4242VE','42(h)x42(L)',42,0,42,'Verre',45,522,'17,64',2),('Porte ','POR4252BL','42(h)x52(L)',42,0,52,'Blanc',43,545,'10,92',2),('Porte ','POR4252BR','42(h)x52(L)',42,0,52,'Brun',46,514,'10,92',2),('Porte ','POR4252VE','42(h)x52(L)',42,0,52,'Verre',45,540,'21,84',2),('Porte ','POR4262BL','42(h)x62(L)',42,0,62,'Blanc',49,557,'13,02',2),('Porte ','POR4262BR','42(h)x62(L)',42,0,62,'Brun',49,529,'13,02',2),('Porte ','POR4262VE','42(h)x62(L)',42,0,62,'Verre',48,560,'26,04',2),('Porte ','POR5232BL','52(h)x32(L)',52,0,32,'Blanc',47,515,'8,32',2),('Porte ','POR5232BR','52(h)x32(L)',52,0,32,'Brun',43,533,'8,32',2),('Porte ','POR5232VE','52(h)x32(L)',52,0,32,'Verre',46,523,'16,64',2),('Porte ','POR5242BL','52(h)x42(L)',52,0,42,'Blanc',41,547,'10,92',2),('Porte ','POR5242BR','52(h)x42(L)',52,0,42,'Brun',45,524,'10,92',2),('Porte ','POR5242VE','52(h)x42(L)',52,0,42,'Verre',44,503,'21,84',2),('Porte ','POR5252BL','52(h)x52(L)',52,0,52,'Blanc',49,544,'13,52',2),('Porte ','POR5252BR','52(h)x52(L)',52,0,52,'Brun',42,527,'13,52',2),('Porte ','POR5252VE','52(h)x52(L)',52,0,52,'Verre',47,511,'27,04',2),('Porte ','POR5262BL','52(h)x62(L)',52,0,62,'Blanc',40,540,'16,12',2),('Porte ','POR5262BR','52(h)x62(L)',52,0,62,'Brun',28,525,'32,24',2),('Porte ','POR5262VE','52(h)x62(L)',52,0,62,'Verre',46,524,'32,24',2),('Tasseau','TAS27','27(h32)',32,0,0,'',83,544,'0,2',4),('Tasseau','TAS37','37(h42)',42,0,0,'',84,532,'0,3',4),('Tasseau','TAS47','47(h52)',52,0,0,'',24,510,'0,4',4),('Traverse Av','TRF100','100(L)',0,0,100,'',48,536,'2,2',2),('Traverse Av','TRF120','120(L)',0,0,120,'',42,538,'2,4',2),('Traverse Av','TRF32','32(L)',0,0,32,'',45,505,'1,5',2),('Traverse Av','TRF42','42(L)',0,0,42,'',43,540,'1,7',2),('Traverse Av','TRF52','52(L)',0,0,52,'',44,535,'1,8',2),('Traverse Av','TRF62','62(L)',0,0,62,'',42,540,'1,9',2),('Traverse Av','TRF80','80(L)',0,0,80,'',44,527,'2',2),('Traverse GD','TRG32','32(p)',0,32,0,'',82,537,'1',4),('Traverse GD','TRG42','42(p)',0,42,0,'',83,513,'1,2',4),('Traverse GD','TRG52','52(p)',0,52,0,'',82,525,'1,4',4),('Traverse GD','TRG62','62(p)',0,62,0,'',82,526,'1,6',4),('Traverse Ar','TRR100','100(L)',0,0,100,'',49,553,'2',2),('Traverse Ar','TRR120','120(L)',0,0,120,'',49,518,'2,2',2),('Traverse Ar','TRR32','32(L)',0,0,32,'',41,534,'1',2),('Traverse Ar','TRR42','42(L)',0,0,42,'',44,534,'1,2',2),('Traverse Ar','TRR52','52(L)',0,0,52,'',44,511,'1,4',2),('Traverse Ar','TRR62','62(L)',0,0,62,'',44,515,'1,6',2),('Traverse Ar','TRR80','80(L)',0,0,80,'',45,511,'1,8',2);
/*!40000 ALTER TABLE `kitbox` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-03-24 13:39:25
