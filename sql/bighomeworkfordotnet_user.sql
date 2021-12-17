-- MySQL dump 10.13  Distrib 8.0.23, for Win64 (x86_64)
--
-- Host: localhost    Database: bighomeworkfordotnet
-- ------------------------------------------------------
-- Server version	8.0.23

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
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `user_name` varchar(32) DEFAULT NULL,
  `password` varchar(128) DEFAULT NULL,
  `state` tinyint DEFAULT '0',
  `type` tinyint DEFAULT '0',
  `real_name` varchar(32) DEFAULT NULL,
  `gender` tinyint DEFAULT NULL,
  `birthday` date DEFAULT NULL,
  `hometown` varchar(128) DEFAULT NULL,
  `email` varchar(128) DEFAULT NULL,
  `mobile` varchar(128) DEFAULT NULL,
  `university` varchar(128) DEFAULT NULL,
  `high_school` varchar(128) DEFAULT NULL,
  `junior_high_school` varchar(128) DEFAULT NULL,
  `primary_school` varchar(128) DEFAULT NULL,
  `hobby_music` varchar(64) DEFAULT NULL,
  `hobby_book` varchar(64) DEFAULT NULL,
  `hobby_movie` varchar(64) DEFAULT NULL,
  `hobby_game` varchar(64) DEFAULT NULL,
  `hobby_anime` varchar(64) DEFAULT NULL,
  `hobby_sport` varchar(64) DEFAULT NULL,
  `hobby_other` varchar(64) DEFAULT NULL,
  `student_no` varchar(32) DEFAULT NULL,
  `college` varchar(32) DEFAULT NULL,
  `department` varchar(32) DEFAULT NULL,
  `major` varchar(32) DEFAULT NULL,
  `avatar` varchar(32) DEFAULT NULL,
  `home_page_description` varchar(128) DEFAULT NULL,
  `md5_password` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (0,'admin','123456',1,0,'管理员',1,'2000-01-01','厦门','admin@admin.com','123456','厦门大学','厦门一中','厦门附中','厦大附小','音乐','书','电影','游戏','动画','体育','其他','110','信息学院','软件工程系','软件工程','../images/avatar1.png',NULL,'49BA59ABBE56E057'),(1,'test','1234',0,1,NULL,1,'2000-01-01',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'52D04DC20036DBD8'),(2,'test1','12345Ab',0,1,NULL,1,'2000-01-01',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'A32B9564BB84C412'),(4,'yuanjiazhe','123456',1,1,'袁佳哲',1,'2001-08-11','河南省济源市','529106896@qq.com','18603899634','厦门大学','济源一中','北海中学','下街小学','Wake','Java How to Program','肖申克的救赎','Minecraft','JOJO的奇妙冒险','跑步','暂无','11920192203642','信息学院','软件工程系','软件工程','../images/avatar5.jpg','这喝汤，多是一件美事啊','49BA59ABBE56E057'),(5,'testtest','123456',1,1,'李云龙',1,'2001-02-16','','','','华中科技大学','武大附属中学','人民初中','人民小学',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2356453','信息学院','计算机技术与科学系','计算机','../images/avatar7.png','二营长，你他娘的意大利炮呢','49BA59ABBE56E057'),(6,'testmd5','qq6666774',1,1,NULL,0,'2001-01-01',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'../images/defaultAvatar.png',NULL,'38DFA0AC509CC803');
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

-- Dump completed on 2021-12-18  2:14:32
