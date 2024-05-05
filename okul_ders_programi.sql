CREATE DATABASE  IF NOT EXISTS `okul` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `okul`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: okul
-- ------------------------------------------------------
-- Server version	8.0.36

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
-- Table structure for table `ders_programi`
--

DROP TABLE IF EXISTS `ders_programi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ders_programi` (
  `ders_programi_id` int NOT NULL AUTO_INCREMENT,
  `ogrenci_TC` varchar(50) DEFAULT NULL,
  `ogretmen_TC` varchar(50) DEFAULT NULL,
  `ders_id` int DEFAULT NULL,
  `tarih` date DEFAULT NULL,
  `saat` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ders_programi_id`),
  KEY `ogrenci_TC` (`ogrenci_TC`),
  KEY `ogretmen_TC` (`ogretmen_TC`),
  KEY `ders_id` (`ders_id`),
  CONSTRAINT `ders_programi_ibfk_1` FOREIGN KEY (`ogrenci_TC`) REFERENCES `ogrenci` (`ogrenci_TC`),
  CONSTRAINT `ders_programi_ibfk_2` FOREIGN KEY (`ogretmen_TC`) REFERENCES `ogretmen` (`ogretmen_TC`),
  CONSTRAINT `ders_programi_ibfk_3` FOREIGN KEY (`ders_id`) REFERENCES `ders` (`ders_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ders_programi`
--

LOCK TABLES `ders_programi` WRITE;
/*!40000 ALTER TABLE `ders_programi` DISABLE KEYS */;
INSERT INTO `ders_programi` VALUES (1,'15217397713','11111111111',2,'2024-05-05','11.50'),(2,'15217397713','11111111111',3,'2024-05-05','11.30'),(5,'15217397713','11111111111',2,'2024-05-28','11.50');
/*!40000 ALTER TABLE `ders_programi` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-05-05 17:05:23
