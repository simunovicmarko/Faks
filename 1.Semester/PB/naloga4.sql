-- create database if not exists Olimpijada;
-- use Olimpijada;
use baza1002427657;

DROP TABLE IF EXISTS sportnik_trener;
DROP TABLE IF EXISTS sodnik_dogodek;
DROP TABLE IF EXISTS delavec_dogodek;
DROP TABLE IF EXISTS nastop;
DROP TABLE IF EXISTS dogodek;
DROP TABLE IF EXISTS prrizorisce;
DROP TABLE IF EXISTS naslov;
DROP TABLE IF EXISTS kraj;
DROP TABLE IF EXISTS sodnik;
DROP TABLE IF EXISTS delavec;
DROP TABLE IF EXISTS trener;
DROP TABLE IF EXISTS sportnik;
DROP TABLE IF EXISTS reprezentanca;
DROP TABLE IF EXISTS drzava;
DROP TABLE IF EXISTS medalja;
DROP TABLE IF EXISTS disciplina;
DROP TABLE IF EXISTS sport;

/*
Created: 20/10/2020
Modified: 10/11/2020
Project: Olimpijada2
Model: Olimpijada2
Database: MySQL 8.0
*/

-- Create tables section -------------------------------------------------

-- Table Medalja

CREATE TABLE `Medalja`
(
  `ID_Medalja` Int NOT NULL AUTO_INCREMENT,
  `Barva` Varchar(45) NOT NULL,
  PRIMARY KEY (`ID_Medalja`)
)
;

-- Table Reprezentanca

CREATE TABLE `Reprezentanca`
(
  `ID_Reprezentanca` Int NOT NULL AUTO_INCREMENT,
  `ID_drzava` Int,
  PRIMARY KEY (`ID_Reprezentanca`)
)
;

-- Table Delavec

CREATE TABLE `Delavec`
(
  `ID_Delavec` Int NOT NULL AUTO_INCREMENT,
  `Ime` Varchar(45) NOT NULL,
  `Priimek` Varchar(45) NOT NULL,
  `Datum_Rojstva` Date NOT NULL,
  `ID_drzava` Int,
  PRIMARY KEY (`ID_Delavec`)
)
;

-- Table Sodnik

CREATE TABLE `Sodnik`
(
  `ID_Sodnik` Int NOT NULL AUTO_INCREMENT,
  `Ime` Varchar(45) NOT NULL,
  `Priimek` Varchar(45) NOT NULL,
  `Datum_Rojstva` Date NOT NULL,
  `ID_drzava` Int,
  PRIMARY KEY (`ID_Sodnik`)
)
;

-- Table prrizorisce

CREATE TABLE `prrizorisce`
(
  `ID_prrizorisce` Int NOT NULL AUTO_INCREMENT,
  `Naziv` Varchar(45) NOT NULL,
  `ID_Naslov` Int,
  PRIMARY KEY (`ID_prrizorisce`)
)
;

-- Table Sport

CREATE TABLE `Sport`
(
  `ID_sport` Int NOT NULL AUTO_INCREMENT,
  `Naziv` Varchar(45) NOT NULL,
  PRIMARY KEY (`ID_sport`)
)
;

-- Table Drzava

CREATE TABLE `Drzava`
(
  `ID_drzava` Int NOT NULL AUTO_INCREMENT,
  `Naziv` Varchar(45) NOT NULL,
  PRIMARY KEY (`ID_drzava`)
)
;

-- Table Kraj

CREATE TABLE `Kraj`
(
  `ID_Kraj` Int NOT NULL AUTO_INCREMENT,
  `Naziv` Varchar(45) NOT NULL,
  `ID_drzava` Int,
  PRIMARY KEY (`ID_Kraj`)
)
;

-- Table Nastop

CREATE TABLE `Nastop`
(
  `ID_Nastopa` Int NOT NULL AUTO_INCREMENT,
  `Rezultat_tek` Time,
  `ID_Dogodka` Int,
  `ID_Sportnik` Int,
  `ID_Disciplina` Int,
  `ID_Medalja` Int,
  `Mesto` Int,
  `Rezultat_meti` Float,
  PRIMARY KEY (`ID_Nastopa`)
)
;

-- Table Dogodek

CREATE TABLE `Dogodek`
(
  `ID_Dogodka` Int NOT NULL AUTO_INCREMENT,
  `ID_sport` Int,
  `Datum_Dogodka` Datetime NOT NULL,
  `ID_Prrizorisce` Int,
  PRIMARY KEY (`ID_Dogodka`)
)
;

-- Table Sportnik

CREATE TABLE `Sportnik`
(
  `ID_Sportnik` Int NOT NULL AUTO_INCREMENT,
  `Ime` Varchar(45) NOT NULL,
  `Priimek` Varchar(45) NOT NULL,
  `Datum_Rojstva` Date NOT NULL,
  `ID_Reprezentanca` Int,
  PRIMARY KEY (`ID_Sportnik`)
)
;

-- Table Disciplina

CREATE TABLE `Disciplina`
(
  `ID_Disciplina` Int NOT NULL AUTO_INCREMENT,
  `Naziv` Varchar(45) NOT NULL,
  `ID_sport` Int,
  PRIMARY KEY (`ID_Disciplina`)
)
;

-- Table Trener

CREATE TABLE `Trener`
(
  `ID_Trener` Int NOT NULL AUTO_INCREMENT,
  `Ime` Varchar(45) NOT NULL,
  `Priimek` Varchar(45) NOT NULL,
  `Datum_Rojstva` Date NOT NULL,
  `ID_Reprezentanca` Int,
  PRIMARY KEY (`ID_Trener`)
)
;

-- Table sportnik_trener

CREATE TABLE `sportnik_trener`
(
  `ID_sportnik-trener` Int NOT NULL AUTO_INCREMENT,
  `ID_Sportnik` Int,
  `ID_Trener` Int,
  `Datum_od` Date,
  PRIMARY KEY (`ID_sportnik-trener`)
)
;

-- Table Naslov

CREATE TABLE `Naslov`
(
  `ID_Naslov` Int NOT NULL AUTO_INCREMENT,
  `Ulica` Varchar(45) NOT NULL,
  `Hisna_Stevilka` Int NOT NULL,
  `ID_Kraj` Int NOT NULL,
  PRIMARY KEY (`ID_Naslov`)
)
;

-- Table Sodnik_dogodek

CREATE TABLE `Sodnik_dogodek`
(
  `id_Sodnik_dogodek` Int NOT NULL AUTO_INCREMENT,
  `ID_Sodnik` Int,
  `ID_Dogodka` Int,
  PRIMARY KEY (`id_Sodnik_dogodek`)
)
;

-- Table Delavec_dogodek

CREATE TABLE `Delavec_dogodek`
(
  `ID_Delavec_dogodek` Int NOT NULL AUTO_INCREMENT,
  `ID_Delavec` Int,
  `ID_Dogodka` Int,
  `Delo` Varchar(45) NOT NULL,
  `Ure` Int NOT NULL,
  PRIMARY KEY (`ID_Delavec_dogodek`)
)
;

-- Create foreign keys (relationships) section -------------------------------------------------

ALTER TABLE `sportnik_trener` ADD CONSTRAINT `Relationship59` FOREIGN KEY (`ID_Sportnik`) REFERENCES `Sportnik` (`ID_Sportnik`) ON DELETE CASCADE ON UPDATE CASCADE 
;

ALTER TABLE `Dogodek` ADD CONSTRAINT `Relationship21` FOREIGN KEY (`ID_sport`) REFERENCES `Sport` (`ID_sport`) ON DELETE CASCADE ON UPDATE CASCADE 
;

ALTER TABLE `Nastop` ADD CONSTRAINT `Relationship28` FOREIGN KEY (`ID_Dogodka`) REFERENCES `Dogodek` (`ID_Dogodka`) ON DELETE CASCADE ON UPDATE CASCADE 
;

ALTER TABLE `Nastop` ADD CONSTRAINT `Relationship29` FOREIGN KEY (`ID_Sportnik`) REFERENCES `Sportnik` (`ID_Sportnik`) ON DELETE CASCADE ON UPDATE CASCADE 
;

ALTER TABLE `Nastop` ADD CONSTRAINT `Relationship30` FOREIGN KEY (`ID_Disciplina`) REFERENCES `Disciplina` (`ID_Disciplina`) ON DELETE CASCADE ON UPDATE CASCADE 
;

ALTER TABLE `Kraj` ADD CONSTRAINT `Relationship31` FOREIGN KEY (`ID_drzava`) REFERENCES `Drzava` (`ID_drzava`) ON DELETE CASCADE ON UPDATE CASCADE 
;

ALTER TABLE `prrizorisce` ADD CONSTRAINT `Relationship47` FOREIGN KEY (`ID_Naslov`) REFERENCES `Naslov` (`ID_Naslov`) ON DELETE CASCADE ON UPDATE CASCADE 
;

ALTER TABLE `Sodnik` ADD CONSTRAINT `Relationship49` FOREIGN KEY (`ID_drzava`) REFERENCES `Drzava` (`ID_drzava`) ON DELETE CASCADE ON UPDATE CASCADE 
;

ALTER TABLE `Delavec` ADD CONSTRAINT `Relationship53` FOREIGN KEY (`ID_drzava`) REFERENCES `Drzava` (`ID_drzava`) ON DELETE CASCADE ON UPDATE CASCADE 
;

ALTER TABLE `Reprezentanca` ADD CONSTRAINT `Relationship55` FOREIGN KEY (`ID_drzava`) REFERENCES `Drzava` (`ID_drzava`) ON DELETE CASCADE ON UPDATE CASCADE 
;

ALTER TABLE `Naslov` ADD CONSTRAINT `Relationship48` FOREIGN KEY (`ID_Kraj`) REFERENCES `Kraj` (`ID_Kraj`) ON DELETE CASCADE ON UPDATE CASCADE 
;

ALTER TABLE `sportnik_trener` ADD CONSTRAINT `Relationship60` FOREIGN KEY (`ID_Trener`) REFERENCES `Trener` (`ID_Trener`) ON DELETE CASCADE ON UPDATE CASCADE 
;

ALTER TABLE `Sodnik_dogodek` ADD CONSTRAINT `Relationship61` FOREIGN KEY (`ID_Sodnik`) REFERENCES `Sodnik` (`ID_Sodnik`) ON DELETE CASCADE ON UPDATE CASCADE 
;

ALTER TABLE `Delavec_dogodek` ADD CONSTRAINT `Relationship63` FOREIGN KEY (`ID_Delavec`) REFERENCES `Delavec` (`ID_Delavec`) ON DELETE CASCADE ON UPDATE CASCADE 
;

ALTER TABLE `Dogodek` ADD CONSTRAINT `Relationship65` FOREIGN KEY (`ID_Prrizorisce`) REFERENCES `prrizorisce` (`ID_prrizorisce`) ON DELETE CASCADE ON UPDATE CASCADE 
;

ALTER TABLE `Sodnik_dogodek` ADD CONSTRAINT `Relationship66` FOREIGN KEY (`ID_Dogodka`) REFERENCES `Dogodek` (`ID_Dogodka`) ON DELETE CASCADE ON UPDATE CASCADE 
;

ALTER TABLE `Delavec_dogodek` ADD CONSTRAINT `Relationship67` FOREIGN KEY (`ID_Dogodka`) REFERENCES `Dogodek` (`ID_Dogodka`) ON DELETE CASCADE ON UPDATE CASCADE 
;

ALTER TABLE `Nastop` ADD CONSTRAINT `Relationship69` FOREIGN KEY (`ID_Medalja`) REFERENCES `Medalja` (`ID_Medalja`) ON DELETE CASCADE ON UPDATE CASCADE 
;

ALTER TABLE `Sportnik` ADD CONSTRAINT `Relationship70` FOREIGN KEY (`ID_Reprezentanca`) REFERENCES `Reprezentanca` (`ID_Reprezentanca`) ON DELETE CASCADE ON UPDATE CASCADE 
;

ALTER TABLE `Trener` ADD CONSTRAINT `Relationship71` FOREIGN KEY (`ID_Reprezentanca`) REFERENCES `Reprezentanca` (`ID_Reprezentanca`) ON DELETE CASCADE ON UPDATE CASCADE 
;

ALTER TABLE `Disciplina` ADD CONSTRAINT `Relationship72` FOREIGN KEY (`ID_sport`) REFERENCES `Sport` (`ID_sport`) ON DELETE CASCADE ON UPDATE CASCADE 
;








insert into drzava (naziv) values ('Syria');
insert into drzava (naziv) values ('Bangladesh');
insert into drzava (naziv) values ('Macedonia');
insert into drzava (naziv) values ('Sweden');
insert into drzava (naziv) values ('China');
insert into drzava (naziv) values ('Poland');
insert into drzava (naziv) values ('Indonesia');
insert into drzava (naziv) values ('Russia');
insert into drzava (naziv) values ('Indonesia');
insert into drzava (naziv) values ('Saudi Arabia');
insert into drzava (naziv) values ('Indonesia');
insert into drzava (naziv) values ('China');
insert into drzava (naziv) values ('Colombia');
insert into drzava (naziv) values ('Russia');
insert into drzava (naziv) values ('Sri Lanka');
insert into drzava (naziv) values ('Indonesia');
insert into drzava (naziv) values ('China');
insert into drzava (naziv) values ('China');
insert into drzava (naziv) values ('Philippines');
insert into drzava (naziv) values ('China');
insert into drzava (naziv) values ('France');
insert into drzava (naziv) values ('China');
insert into drzava (naziv) values ('Portugal');
insert into drzava (naziv) values ('Portugal');
insert into drzava (naziv) values ('Russia');
insert into drzava (naziv) values ('Indonesia');
insert into drzava (naziv) values ('Russia');
insert into drzava (naziv) values ('Ivory Coast');
insert into drzava (naziv) values ('Colombia');
insert into drzava (naziv) values ('Indonesia');
insert into drzava (naziv) values ('Madagascar');
insert into drzava (naziv) values ('China');
insert into drzava (naziv) values ('Croatia');
insert into drzava (naziv) values ('Russia');
insert into drzava (naziv) values ('Bulgaria');
insert into drzava (naziv) values ('Portugal');
insert into drzava (naziv) values ('Lithuania');
insert into drzava (naziv) values ('Macedonia');
insert into drzava (naziv) values ('United States');
insert into drzava (naziv) values ('Belarus');
insert into drzava (naziv) values ('Bulgaria');
insert into drzava (naziv) values ('Lithuania');
insert into drzava (naziv) values ('Tunisia');
insert into drzava (naziv) values ('Philippines');
insert into drzava (naziv) values ('Saudi Arabia');
insert into drzava (naziv) values ('Russia');
insert into drzava (naziv) values ('China');
insert into drzava (naziv) values ('China');
insert into drzava (naziv) values ('China');
insert into drzava (naziv) values ('Colombia');
insert into drzava (naziv) values ('Japan');
insert into drzava (naziv) values ('Portugal');
insert into drzava (naziv) values ('China');
insert into drzava (naziv) values ('Poland');
insert into drzava (naziv) values ('Ukraine');
insert into drzava (naziv) values ('China');
insert into drzava (naziv) values ('Russia');
insert into drzava (naziv) values ('Costa Rica');
insert into drzava (naziv) values ('China');
insert into drzava (naziv) values ('Philippines');
insert into drzava (naziv) values ('Indonesia');
insert into drzava (naziv) values ('Indonesia');
insert into drzava (naziv) values ('Philippines');
insert into drzava (naziv) values ('Philippines');
insert into drzava (naziv) values ('France');
insert into drzava (naziv) values ('China');
insert into drzava (naziv) values ('Netherlands');
insert into drzava (naziv) values ('Portugal');
insert into drzava (naziv) values ('Ireland');
insert into drzava (naziv) values ('Belarus');
insert into drzava (naziv) values ('Portugal');
insert into drzava (naziv) values ('China');
insert into drzava (naziv) values ('Poland');
insert into drzava (naziv) values ('China');
insert into drzava (naziv) values ('Serbia');
insert into drzava (naziv) values ('Indonesia');
insert into drzava (naziv) values ('Indonesia');
insert into drzava (naziv) values ('Japan');
insert into drzava (naziv) values ('United Arab Emirates');
insert into drzava (naziv) values ('Cyprus');
insert into drzava (naziv) values ('Philippines');
insert into drzava (naziv) values ('Honduras');
insert into drzava (naziv) values ('China');
insert into drzava (naziv) values ('Ukraine');
insert into drzava (naziv) values ('Mongolia');
insert into drzava (naziv) values ('Philippines');
insert into drzava (naziv) values ('Norway');
insert into drzava (naziv) values ('Ukraine');
insert into drzava (naziv) values ('Tunisia');
insert into drzava (naziv) values ('Philippines');
insert into drzava (naziv) values ('Thailand');
insert into drzava (naziv) values ('China');
insert into drzava (naziv) values ('Poland');
insert into drzava (naziv) values ('Estonia');
insert into drzava (naziv) values ('Micronesia');
insert into drzava (naziv) values ('Slovenia');
insert into drzava (naziv) values ('Colombia');
insert into drzava (naziv) values ('China');
insert into drzava (naziv) values ('France');
insert into drzava (naziv) values ('Germany');


insert into kraj (naziv, id_drzava) values ('Utrecht (stad)', 1);
insert into kraj (naziv, id_drzava) values ('Romba', 9);
insert into kraj (naziv, id_drzava) values ('Wysokie Mazowieckie', 79);
insert into kraj (naziv, id_drzava) values ('San Miguel de Cauri', 48);
insert into kraj (naziv, id_drzava) values ('Amvrosiyivka', 60);
insert into kraj (naziv, id_drzava) values ('Villaba', 100);
insert into kraj (naziv, id_drzava) values ('Pingdu', 34);
insert into kraj (naziv, id_drzava) values ('Heku', 100);
insert into kraj (naziv, id_drzava) values ('Jinhe', 84);
insert into kraj (naziv, id_drzava) values ('Knjazevac', 62);
insert into kraj (naziv, id_drzava) values ('Borås', 61);
insert into kraj (naziv, id_drzava) values ('Lingyang', 61);
insert into kraj (naziv, id_drzava) values ('Cibeureum Satu', 62);
insert into kraj (naziv, id_drzava) values ('Tubli', 30);
insert into kraj (naziv, id_drzava) values ('Villa Gesell', 50);
insert into kraj (naziv, id_drzava) values ('Ivyanyets', 74);
insert into kraj (naziv, id_drzava) values ('Platagata', 39);
insert into kraj (naziv, id_drzava) values ('Dongying', 48);
insert into kraj (naziv, id_drzava) values ('Bairro do Margaça', 9);
insert into kraj (naziv, id_drzava) values ('Depok', 23);
insert into kraj (naziv, id_drzava) values ('Skänninge', 25);
insert into kraj (naziv, id_drzava) values ('Zainsk', 68);
insert into kraj (naziv, id_drzava) values ('Värnamo', 13);
insert into kraj (naziv, id_drzava) values ('Yanaul', 69);
insert into kraj (naziv, id_drzava) values ('Jiaoshi', 9);
insert into kraj (naziv, id_drzava) values ('Jiangwan', 9);
insert into kraj (naziv, id_drzava) values ('Qaţanah', 8);
insert into kraj (naziv, id_drzava) values ('Mao’er', 9);
insert into kraj (naziv, id_drzava) values ('Kaeng Khro', 61);
insert into kraj (naziv, id_drzava) values ('Izborsk', 81);
insert into kraj (naziv, id_drzava) values ('Ráječko', 52);
insert into kraj (naziv, id_drzava) values ('Yunji', 48);
insert into kraj (naziv, id_drzava) values ('Pivovarikha', 70);
insert into kraj (naziv, id_drzava) values ('Bronx', 62);
insert into kraj (naziv, id_drzava) values ('Wuqu', 41);
insert into kraj (naziv, id_drzava) values ('Oebai', 79);
insert into kraj (naziv, id_drzava) values ('Samdrup Jongkhar', 31);
insert into kraj (naziv, id_drzava) values ('Barbudo', 55);
insert into kraj (naziv, id_drzava) values ('Malesína', 25);
insert into kraj (naziv, id_drzava) values ('Nogueira do Cravo', 96);
insert into kraj (naziv, id_drzava) values ('Lubuagan', 62);
insert into kraj (naziv, id_drzava) values ('Yarmolyntsi', 7);
insert into kraj (naziv, id_drzava) values ('Longxi', 59);
insert into kraj (naziv, id_drzava) values ('Saint-Joseph-de-Coleraine', 44);
insert into kraj (naziv, id_drzava) values ('Saḩāb', 28);
insert into kraj (naziv, id_drzava) values ('Hayang', 8);
insert into kraj (naziv, id_drzava) values ('Feondari', 93);
insert into kraj (naziv, id_drzava) values ('Höganäs', 81);
insert into kraj (naziv, id_drzava) values ('Picos', 29);
insert into kraj (naziv, id_drzava) values ('Limoges', 12);
insert into kraj (naziv, id_drzava) values ('Xihanling', 55);
insert into kraj (naziv, id_drzava) values ('Gorang', 19);
insert into kraj (naziv, id_drzava) values ('Kloulklubed', 94);
insert into kraj (naziv, id_drzava) values ('Norrköping', 10);
insert into kraj (naziv, id_drzava) values ('Jeziorany', 21);
insert into kraj (naziv, id_drzava) values ('Asamankese', 44);
insert into kraj (naziv, id_drzava) values ('Tazhuang', 13);
insert into kraj (naziv, id_drzava) values ('Culianin', 30);
insert into kraj (naziv, id_drzava) values ('Tapan', 67);
insert into kraj (naziv, id_drzava) values ('Basa', 61);
insert into kraj (naziv, id_drzava) values ('Kaloyanovo', 25);
insert into kraj (naziv, id_drzava) values ('Datian', 88);
insert into kraj (naziv, id_drzava) values ('Feondari', 42);
insert into kraj (naziv, id_drzava) values ('Mixco', 92);
insert into kraj (naziv, id_drzava) values ('El Pao', 17);
insert into kraj (naziv, id_drzava) values ('Bagong Pagasa', 77);
insert into kraj (naziv, id_drzava) values ('Kujang', 79);
insert into kraj (naziv, id_drzava) values ('Liugou', 96);
insert into kraj (naziv, id_drzava) values ('Taquarituba', 37);
insert into kraj (naziv, id_drzava) values ('Belém', 53);
insert into kraj (naziv, id_drzava) values ('Wanghu', 2);
insert into kraj (naziv, id_drzava) values ('Nugas', 5);
insert into kraj (naziv, id_drzava) values ('Sandia', 22);
insert into kraj (naziv, id_drzava) values ('Cachoeirinha', 4);
insert into kraj (naziv, id_drzava) values ('Rokem Barat', 88);
insert into kraj (naziv, id_drzava) values ('Horodnya', 17);
insert into kraj (naziv, id_drzava) values ('Novorossiysk', 89);
insert into kraj (naziv, id_drzava) values ('Arias', 84);
insert into kraj (naziv, id_drzava) values ('Puyuan', 36);
insert into kraj (naziv, id_drzava) values ('Kambaxoi', 92);
insert into kraj (naziv, id_drzava) values ('Sapu Padidu', 51);
insert into kraj (naziv, id_drzava) values ('Malindi', 24);
insert into kraj (naziv, id_drzava) values ('Wuduhe', 61);
insert into kraj (naziv, id_drzava) values ('Pendawanbaru', 43);
insert into kraj (naziv, id_drzava) values ('Tolomango', 99);
insert into kraj (naziv, id_drzava) values ('Kotakan Selatan', 31);
insert into kraj (naziv, id_drzava) values ('Obando', 45);
insert into kraj (naziv, id_drzava) values ('Calachuchi', 5);
insert into kraj (naziv, id_drzava) values ('Divnomorskoye', 11);
insert into kraj (naziv, id_drzava) values ('Sangalhos', 13);
insert into kraj (naziv, id_drzava) values ('Munsan', 97);
insert into kraj (naziv, id_drzava) values ('Jilin', 58);
insert into kraj (naziv, id_drzava) values ('Susanino', 1);
insert into kraj (naziv, id_drzava) values ('Gaoyi', 98);
insert into kraj (naziv, id_drzava) values ('18 de Marzo', 29);
insert into kraj (naziv, id_drzava) values ('Otacílio Costa', 45);
insert into kraj (naziv, id_drzava) values ('Polykárpi', 53);
insert into kraj (naziv, id_drzava) values ('Liangnong', 25);
insert into kraj (naziv, id_drzava) values ('Kaliterus', 59);
insert into kraj (naziv, id_drzava) values ('Luleå', 30);

insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Street', 25, 69);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Way', 37, 44);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Street', 54, 47);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Point', 67, 22);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Road', 47, 26);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Circle', 62, 90);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Hill', 74, 69);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Circle', 4, 6);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Road', 54, 81);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Center', 61, 40);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Drive', 75, 82);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Pass', 62, 84);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Trail', 98, 24);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Place', 9, 49);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Plaza', 40, 42);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Terrace', 59, 1);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Hill', 47, 86);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Drive', 97, 23);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Parkway', 21, 60);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Circle', 83, 57);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Lane', 47, 47);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Park', 44, 52);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Pass', 74, 83);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Lane', 49, 36);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Road', 46, 66);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Road', 63, 12);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Trail', 78, 26);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Terrace', 16, 56);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Park', 98, 24);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Crossing', 52, 97);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Drive', 77, 14);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Center', 83, 66);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Crossing', 6, 92);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Hill', 95, 90);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Trail', 34, 72);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Hill', 61, 53);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Drive', 12, 16);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Road', 29, 35);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Drive', 41, 88);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Road', 6, 57);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Alley', 99, 64);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Plaza', 49, 5);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Pass', 36, 24);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Trail', 60, 85);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Way', 80, 26);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Lane', 23, 99);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Place', 43, 94);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Center', 81, 80);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Terrace', 99, 66);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Street', 77, 17);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Street', 77, 80);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Crossing', 97, 2);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Alley', 94, 92);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Alley', 36, 10);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Drive', 54, 41);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Alley', 92, 74);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Alley', 84, 44);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Junction', 25, 23);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Court', 33, 4);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Way', 76, 67);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Parkway', 15, 73);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Street', 87, 41);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Drive', 49, 71);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Place', 26, 68);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Plaza', 2, 45);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Street', 2, 57);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Lane', 2, 2);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Point', 31, 63);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Court', 83, 38);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Court', 82, 47);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Drive', 93, 70);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Street', 16, 31);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Alley', 13, 3);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Place', 22, 30);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Lane', 52, 21);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Circle', 54, 84);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Way', 52, 40);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Center', 70, 23);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Road', 47, 32);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Drive', 46, 72);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Parkway', 81, 93);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Way', 24, 94);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Way', 25, 62);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Way', 65, 70);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Drive', 7, 74);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Hill', 88, 11);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Circle', 97, 56);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Terrace', 15, 81);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Point', 81, 20);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Center', 12, 48);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Lane', 31, 55);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Trail', 38, 63);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Avenue', 77, 25);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Trail', 34, 26);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Plaza', 26, 81);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Circle', 46, 84);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Lane', 50, 21);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Avenue', 6, 99);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Hill', 4, 98);
insert into Naslov (ulica, id_kraj, hisna_stevilka) values ('Way', 100, 62);


insert into prrizorisce (naziv, id_naslov) values ('Parkway', 36);
insert into prrizorisce (naziv, id_naslov) values ('Junction', 15);
insert into prrizorisce (naziv, id_naslov) values ('Parkway', 65);
insert into prrizorisce (naziv, id_naslov) values ('Drive', 98);
insert into prrizorisce (naziv, id_naslov) values ('Crossing', 45);
insert into prrizorisce (naziv, id_naslov) values ('Hill', 60);
insert into prrizorisce (naziv, id_naslov) values ('Road', 65);
insert into prrizorisce (naziv, id_naslov) values ('Road', 53);
insert into prrizorisce (naziv, id_naslov) values ('Alley', 5);
insert into prrizorisce (naziv, id_naslov) values ('Avenue', 71);
insert into prrizorisce (naziv, id_naslov) values ('Drive', 88);
insert into prrizorisce (naziv, id_naslov) values ('Plaza', 72);
insert into prrizorisce (naziv, id_naslov) values ('Place', 26);
insert into prrizorisce (naziv, id_naslov) values ('Parkway', 45);
insert into prrizorisce (naziv, id_naslov) values ('Hill', 69);
insert into prrizorisce (naziv, id_naslov) values ('Hill', 13);
insert into prrizorisce (naziv, id_naslov) values ('Park', 41);
insert into prrizorisce (naziv, id_naslov) values ('Parkway', 32);
insert into prrizorisce (naziv, id_naslov) values ('Plaza', 16);
insert into prrizorisce (naziv, id_naslov) values ('Point', 84);
insert into prrizorisce (naziv, id_naslov) values ('Drive', 87);
insert into prrizorisce (naziv, id_naslov) values ('Street', 9);
insert into prrizorisce (naziv, id_naslov) values ('Park', 64);
insert into prrizorisce (naziv, id_naslov) values ('Lane', 69);
insert into prrizorisce (naziv, id_naslov) values ('Park', 65);
insert into prrizorisce (naziv, id_naslov) values ('Alley', 63);
insert into prrizorisce (naziv, id_naslov) values ('Drive', 83);
insert into prrizorisce (naziv, id_naslov) values ('Way', 77);
insert into prrizorisce (naziv, id_naslov) values ('Trail', 26);
insert into prrizorisce (naziv, id_naslov) values ('Junction', 89);
insert into prrizorisce (naziv, id_naslov) values ('Avenue', 75);
insert into prrizorisce (naziv, id_naslov) values ('Crossing', 65);
insert into prrizorisce (naziv, id_naslov) values ('Park', 69);
insert into prrizorisce (naziv, id_naslov) values ('Avenue', 40);
insert into prrizorisce (naziv, id_naslov) values ('Parkway', 7);
insert into prrizorisce (naziv, id_naslov) values ('Hill', 44);
insert into prrizorisce (naziv, id_naslov) values ('Avenue', 33);
insert into prrizorisce (naziv, id_naslov) values ('Court', 59);
insert into prrizorisce (naziv, id_naslov) values ('Center', 37);
insert into prrizorisce (naziv, id_naslov) values ('Center', 84);
insert into prrizorisce (naziv, id_naslov) values ('Circle', 21);
insert into prrizorisce (naziv, id_naslov) values ('Hill', 27);
insert into prrizorisce (naziv, id_naslov) values ('Trail', 65);
insert into prrizorisce (naziv, id_naslov) values ('Circle', 12);
insert into prrizorisce (naziv, id_naslov) values ('Terrace', 43);
insert into prrizorisce (naziv, id_naslov) values ('Court', 10);
insert into prrizorisce (naziv, id_naslov) values ('Place', 61);
insert into prrizorisce (naziv, id_naslov) values ('Center', 42);
insert into prrizorisce (naziv, id_naslov) values ('Road', 98);
insert into prrizorisce (naziv, id_naslov) values ('Alley', 28);
insert into prrizorisce (naziv, id_naslov) values ('Court', 76);
insert into prrizorisce (naziv, id_naslov) values ('Park', 39);
insert into prrizorisce (naziv, id_naslov) values ('Alley', 83);
insert into prrizorisce (naziv, id_naslov) values ('Alley', 66);
insert into prrizorisce (naziv, id_naslov) values ('Court', 65);
insert into prrizorisce (naziv, id_naslov) values ('Center', 50);
insert into prrizorisce (naziv, id_naslov) values ('Circle', 57);
insert into prrizorisce (naziv, id_naslov) values ('Pass', 77);
insert into prrizorisce (naziv, id_naslov) values ('Road', 64);
insert into prrizorisce (naziv, id_naslov) values ('Court', 61);
insert into prrizorisce (naziv, id_naslov) values ('Crossing', 73);
insert into prrizorisce (naziv, id_naslov) values ('Avenue', 18);
insert into prrizorisce (naziv, id_naslov) values ('Road', 42);
insert into prrizorisce (naziv, id_naslov) values ('Road', 89);
insert into prrizorisce (naziv, id_naslov) values ('Pass', 94);
insert into prrizorisce (naziv, id_naslov) values ('Court', 82);
insert into prrizorisce (naziv, id_naslov) values ('Trail', 57);
insert into prrizorisce (naziv, id_naslov) values ('Way', 72);
insert into prrizorisce (naziv, id_naslov) values ('Parkway', 39);
insert into prrizorisce (naziv, id_naslov) values ('Plaza', 67);
insert into prrizorisce (naziv, id_naslov) values ('Center', 39);
insert into prrizorisce (naziv, id_naslov) values ('Parkway', 93);
insert into prrizorisce (naziv, id_naslov) values ('Junction', 81);
insert into prrizorisce (naziv, id_naslov) values ('Junction', 26);
insert into prrizorisce (naziv, id_naslov) values ('Pass', 2);
insert into prrizorisce (naziv, id_naslov) values ('Road', 34);
insert into prrizorisce (naziv, id_naslov) values ('Junction', 93);
insert into prrizorisce (naziv, id_naslov) values ('Junction', 35);
insert into prrizorisce (naziv, id_naslov) values ('Terrace', 100);
insert into prrizorisce (naziv, id_naslov) values ('Lane', 95);
insert into prrizorisce (naziv, id_naslov) values ('Lane', 1);
insert into prrizorisce (naziv, id_naslov) values ('Avenue', 34);
insert into prrizorisce (naziv, id_naslov) values ('Junction', 62);
insert into prrizorisce (naziv, id_naslov) values ('Trail', 11);
insert into prrizorisce (naziv, id_naslov) values ('Parkway', 69);
insert into prrizorisce (naziv, id_naslov) values ('Park', 32);
insert into prrizorisce (naziv, id_naslov) values ('Street', 87);
insert into prrizorisce (naziv, id_naslov) values ('Parkway', 32);
insert into prrizorisce (naziv, id_naslov) values ('Crossing', 58);
insert into prrizorisce (naziv, id_naslov) values ('Terrace', 39);
insert into prrizorisce (naziv, id_naslov) values ('Drive', 74);
insert into prrizorisce (naziv, id_naslov) values ('Parkway', 55);
insert into prrizorisce (naziv, id_naslov) values ('Parkway', 15);
insert into prrizorisce (naziv, id_naslov) values ('Plaza', 42);
insert into prrizorisce (naziv, id_naslov) values ('Parkway', 54);
insert into prrizorisce (naziv, id_naslov) values ('Park', 29);
insert into prrizorisce (naziv, id_naslov) values ('Junction', 95);
insert into prrizorisce (naziv, id_naslov) values ('Parkway', 77);
insert into prrizorisce (naziv, id_naslov) values ('Street', 99);
insert into prrizorisce (naziv, id_naslov) values ('Junction', 24);


insert into Reprezentanca (id_drzava) values (75);
insert into Reprezentanca (id_drzava) values (18);
insert into Reprezentanca (id_drzava) values (50);
insert into Reprezentanca (id_drzava) values (20);
insert into Reprezentanca (id_drzava) values (89);
insert into Reprezentanca (id_drzava) values (43);
insert into Reprezentanca (id_drzava) values (61);
insert into Reprezentanca (id_drzava) values (69);
insert into Reprezentanca (id_drzava) values (64);
insert into Reprezentanca (id_drzava) values (73);
insert into Reprezentanca (id_drzava) values (74);
insert into Reprezentanca (id_drzava) values (44);
insert into Reprezentanca (id_drzava) values (80);
insert into Reprezentanca (id_drzava) values (12);
insert into Reprezentanca (id_drzava) values (3);
insert into Reprezentanca (id_drzava) values (63);
insert into Reprezentanca (id_drzava) values (32);
insert into Reprezentanca (id_drzava) values (80);
insert into Reprezentanca (id_drzava) values (50);
insert into Reprezentanca (id_drzava) values (18);
insert into Reprezentanca (id_drzava) values (21);
insert into Reprezentanca (id_drzava) values (96);
insert into Reprezentanca (id_drzava) values (96);
insert into Reprezentanca (id_drzava) values (32);
insert into Reprezentanca (id_drzava) values (47);
insert into Reprezentanca (id_drzava) values (91);
insert into Reprezentanca (id_drzava) values (69);
insert into Reprezentanca (id_drzava) values (6);
insert into Reprezentanca (id_drzava) values (8);
insert into Reprezentanca (id_drzava) values (69);
insert into Reprezentanca (id_drzava) values (67);
insert into Reprezentanca (id_drzava) values (74);
insert into Reprezentanca (id_drzava) values (29);
insert into Reprezentanca (id_drzava) values (42);
insert into Reprezentanca (id_drzava) values (74);
insert into Reprezentanca (id_drzava) values (64);
insert into Reprezentanca (id_drzava) values (47);
insert into Reprezentanca (id_drzava) values (92);
insert into Reprezentanca (id_drzava) values (69);
insert into Reprezentanca (id_drzava) values (68);
insert into Reprezentanca (id_drzava) values (8);
insert into Reprezentanca (id_drzava) values (81);
insert into Reprezentanca (id_drzava) values (11);
insert into Reprezentanca (id_drzava) values (10);
insert into Reprezentanca (id_drzava) values (94);
insert into Reprezentanca (id_drzava) values (18);
insert into Reprezentanca (id_drzava) values (86);
insert into Reprezentanca (id_drzava) values (23);
insert into Reprezentanca (id_drzava) values (52);
insert into Reprezentanca (id_drzava) values (7);
insert into Reprezentanca (id_drzava) values (32);
insert into Reprezentanca (id_drzava) values (8);
insert into Reprezentanca (id_drzava) values (45);
insert into Reprezentanca (id_drzava) values (29);
insert into Reprezentanca (id_drzava) values (43);
insert into Reprezentanca (id_drzava) values (1);
insert into Reprezentanca (id_drzava) values (12);
insert into Reprezentanca (id_drzava) values (18);
insert into Reprezentanca (id_drzava) values (43);
insert into Reprezentanca (id_drzava) values (85);
insert into Reprezentanca (id_drzava) values (71);
insert into Reprezentanca (id_drzava) values (28);
insert into Reprezentanca (id_drzava) values (1);
insert into Reprezentanca (id_drzava) values (17);
insert into Reprezentanca (id_drzava) values (78);
insert into Reprezentanca (id_drzava) values (8);
insert into Reprezentanca (id_drzava) values (40);
insert into Reprezentanca (id_drzava) values (89);
insert into Reprezentanca (id_drzava) values (26);
insert into Reprezentanca (id_drzava) values (52);
insert into Reprezentanca (id_drzava) values (28);
insert into Reprezentanca (id_drzava) values (54);
insert into Reprezentanca (id_drzava) values (33);
insert into Reprezentanca (id_drzava) values (66);
insert into Reprezentanca (id_drzava) values (83);
insert into Reprezentanca (id_drzava) values (100);
insert into Reprezentanca (id_drzava) values (1);
insert into Reprezentanca (id_drzava) values (91);
insert into Reprezentanca (id_drzava) values (63);
insert into Reprezentanca (id_drzava) values (85);
insert into Reprezentanca (id_drzava) values (29);
insert into Reprezentanca (id_drzava) values (99);
insert into Reprezentanca (id_drzava) values (95);
insert into Reprezentanca (id_drzava) values (87);
insert into Reprezentanca (id_drzava) values (66);
insert into Reprezentanca (id_drzava) values (44);
insert into Reprezentanca (id_drzava) values (46);
insert into Reprezentanca (id_drzava) values (35);
insert into Reprezentanca (id_drzava) values (92);
insert into Reprezentanca (id_drzava) values (79);
insert into Reprezentanca (id_drzava) values (75);
insert into Reprezentanca (id_drzava) values (45);
insert into Reprezentanca (id_drzava) values (10);
insert into Reprezentanca (id_drzava) values (8);
insert into Reprezentanca (id_drzava) values (70);
insert into Reprezentanca (id_drzava) values (8);
insert into Reprezentanca (id_drzava) values (26);
insert into Reprezentanca (id_drzava) values (48);
insert into Reprezentanca (id_drzava) values (36);
insert into Reprezentanca (id_drzava) values (21);

insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Abner', 'Clail', '1951-07-11', 2);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Atlante', 'Waud', '1952-02-05', 14);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Alleen', 'Huard', '1983-10-10', 95);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Latia', 'Girardy', '1958-11-12', 1);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Kandace', 'Dreigher', '1994-09-25', 63);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Wilhelmina', 'Hinkley', '1953-08-22', 46);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Alwyn', 'Ginger', '1973-10-04', 2);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Maurine', 'Kernermann', '1991-03-24', 9);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Guss', 'Binch', '1979-09-20', 16);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Adham', 'Bouldon', '1977-05-04', 82);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Claribel', 'Wickins', '1965-02-09', 69);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Suzy', 'McLafferty', '1998-05-05', 11);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Consolata', 'Bolingbroke', '1972-11-10', 38);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Sukey', 'Tatum', '1980-10-23', 75);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Elwin', 'Gyver', '1964-05-18', 68);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Barret', 'Ivanyushin', '1984-09-30', 51);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Lewiss', 'Chmiel', '1991-08-21', 19);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Garrek', 'Bewshire', '1983-06-22', 10);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Sisely', 'Thomlinson', '1997-05-14', 30);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Anthiathia', 'Bescoby', '1966-11-20', 16);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Madonna', 'Gavagan', '1999-11-18', 2);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Corry', 'Henke', '1977-01-14', 21);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Zacharias', 'Hoyland', '1996-04-28', 98);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Iorgo', 'Rive', '1975-03-14', 79);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Abner', 'Streeting', '1979-07-29', 76);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Dee dee', 'Doubleday', '1965-11-06', 31);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Thornton', 'Kubczak', '1979-08-30', 23);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Happy', 'Gerriessen', '1960-09-27', 48);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Jill', 'Demsey', '1982-02-21', 27);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Silvie', 'Golthorpp', '1970-05-02', 64);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Philippine', 'Yeoman', '1996-10-04', 56);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Noble', 'Cudby', '2000-07-26', 17);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Gustavus', 'Fourcade', '1975-12-02', 33);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Sorcha', 'Kemmons', '1974-12-11', 61);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Helenelizabeth', 'McClifferty', '1984-04-01', 19);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Jaquelin', 'Clipston', '1998-10-11', 14);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Bartholemy', 'Ogdahl', '1980-06-14', 16);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Annabelle', 'Bragg', '1978-01-25', 31);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Augustine', 'Scrase', '1970-02-06', 8);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Beaufort', 'Curling', '1998-05-17', 24);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Anette', 'Tottem', '1959-04-28', 2);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Northrup', 'Aven', '1987-11-29', 16);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Ivory', 'Battany', '2000-01-05', 77);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Del', 'Forryan', '2001-11-15', 45);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Chiarra', 'Hammond', '1975-09-24', 6);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Modesta', 'Broomhead', '1962-04-29', 92);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Nessy', 'Bewsey', '1958-04-07', 50);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Noreen', 'Conklin', '1995-03-31', 14);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Hewitt', 'Janata', '1957-04-17', 51);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Floyd', 'Waterhouse', '1964-12-16', 42);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Sharleen', 'Linneman', '1968-01-23', 45);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Romola', 'Shelton', '1975-03-03', 7);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Shelton', 'Blueman', '1960-03-13', 97);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Brynn', 'Dorro', '1964-04-07', 93);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Devi', 'Yetts', '1983-05-22', 10);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Conan', 'O''Devey', '1964-09-26', 53);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Ginnie', 'Buckbee', '1996-11-29', 97);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Trixie', 'Twitching', '1990-06-13', 69);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Schuyler', 'Tunaclift', '1955-01-02', 94);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Grazia', 'Isaacson', '1998-06-06', 53);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Mamie', 'Denham', '1982-10-11', 37);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Marven', 'Pepper', '1995-06-27', 4);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Inesita', 'Casiroli', '1961-01-27', 35);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Annamaria', 'Tivers', '1994-03-08', 38);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Rriocard', 'Peirpoint', '1953-04-20', 92);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Kial', 'Oxteby', '1973-06-12', 57);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Giana', 'Butrimovich', '1969-09-15', 52);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Iona', 'Hulmes', '1986-05-17', 47);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Lari', 'Cough', '1990-10-31', 58);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Vanni', 'Lody', '1959-05-25', 83);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Melanie', 'Stronge', '1965-12-21', 95);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Cullen', 'Van Weedenburg', '1960-02-10', 32);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Peggie', 'Baynham', '1988-10-17', 98);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Prescott', 'Corton', '1986-06-16', 11);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Khalil', 'Pizzey', '1998-05-08', 55);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Gannie', 'Jobbins', '1985-09-30', 48);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Sibyl', 'Reddoch', '1981-10-22', 80);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Zane', 'Tresler', '1986-10-04', 26);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Shelley', 'Leader', '1954-02-04', 57);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Darla', 'Portal', '2000-12-07', 76);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Rolph', 'Hulatt', '1964-06-28', 58);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Ossie', 'Baldacchi', '2000-05-02', 96);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Jorry', 'Lainton', '1979-12-21', 4);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Igor', 'Aspin', '1961-12-03', 97);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Aimee', 'Braizier', '1959-08-15', 21);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Tanhya', 'Mathou', '1986-11-07', 7);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Harmonie', 'Duker', '1976-02-17', 64);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Freddi', 'Roxburgh', '1996-06-25', 33);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Candra', 'Quantick', '1990-09-06', 23);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Dorry', 'Froom', '1970-03-04', 7);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Claudine', 'Dew', '1993-12-27', 15);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Kit', 'Calvey', '1965-07-20', 49);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Michale', 'Hudspith', '2000-02-03', 14);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Brana', 'Paxforde', '1959-06-05', 78);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Rodge', 'Rosenbaum', '1994-10-10', 83);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Nikkie', 'Crouse', '1965-03-14', 68);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Annalise', 'Breitling', '1969-01-24', 51);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Anica', 'Prendergrast', '1963-03-14', 86);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Ardath', 'Skillicorn', '1989-07-12', 92);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Leone', 'Whapple', '1954-09-11', 39);
insert into Sportnik (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Miha', 'Kos', '1954-09-11', 39);


insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Kalil', 'Lenaghen', '1962-03-28', 41);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Esdras', 'Pasek', '2001-11-17', 6);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Basilio', 'Hullbrook', '1956-06-18', 65);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Anabel', 'MacMurray', '1986-09-03', 80);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Hallsy', 'Barry', '2001-09-26', 29);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Veradis', 'Tilney', '1988-05-06', 37);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Chelsae', 'Hurry', '1989-06-18', 67);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Karlen', 'Refford', '1973-07-23', 62);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Pammy', 'M''Quharg', '1968-02-23', 64);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Jessica', 'Liptrot', '1995-05-12', 42);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Naoma', 'Lohan', '1951-11-30', 82);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Michail', 'Yuryaev', '1982-01-18', 33);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Rosie', 'Castelli', '1991-07-23', 8);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Zared', 'Pevsner', '1987-01-07', 30);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Will', 'Forty', '1999-12-12', 65);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Ethelin', 'Pickburn', '2000-08-27', 7);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Bev', 'Larchiere', '1958-04-16', 75);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Lev', 'Hollows', '1958-02-19', 78);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Tiena', 'Scadding', '1978-12-01', 33);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Lonni', 'Craigg', '1979-12-31', 99);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Pall', 'Ginnety', '1962-04-05', 44);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Tabbie', 'Vaughten', '1987-12-12', 42);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Wendye', 'Simcox', '1996-05-23', 32);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Jobi', 'Jiggens', '1975-12-18', 32);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Godard', 'Gimson', '1995-05-16', 60);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Sherill', 'Vials', '1954-05-19', 50);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Bourke', 'Corsham', '1978-07-09', 13);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Jolyn', 'Aronow', '1977-01-20', 94);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Justina', 'Sharpe', '1993-05-22', 9);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Jackie', 'Comberbeach', '1962-11-09', 66);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Hussein', 'Goodbanne', '1994-02-08', 77);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Bax', 'Viger', '1974-02-24', 45);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Mart', 'Martinson', '1951-06-07', 11);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Blair', 'Eskell', '1980-05-20', 58);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Anabel', 'Ward', '1962-01-31', 71);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Shelby', 'Carefull', '1992-11-23', 24);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Mikey', 'Coweuppe', '1994-08-21', 24);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Allina', 'Dahlman', '1956-08-09', 35);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Rosalinda', 'Franceschino', '1989-12-15', 51);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Rhonda', 'Cowlard', '1961-06-24', 51);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Brook', 'Kupker', '1976-12-31', 51);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Francklyn', 'Togher', '1984-11-13', 61);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Judon', 'Flahy', '1981-01-07', 100);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Ealasaid', 'Bulford', '2001-06-08', 73);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Rivalee', 'Cloute', '1955-03-28', 36);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Concordia', 'Bealing', '1964-02-07', 43);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Dorelia', 'Muttitt', '1995-07-22', 87);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Kandace', 'Hassett', '1951-06-10', 17);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Rory', 'Valintine', '1968-12-31', 6);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Dix', 'Mahy', '1984-10-12', 64);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Walden', 'Fosken', '1965-12-23', 54);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Edeline', 'Le Count', '1993-11-01', 98);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Parsifal', 'Addis', '1961-07-12', 86);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Kari', 'Farleigh', '1960-10-07', 24);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Giustina', 'Tatershall', '1973-09-27', 75);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Jarrad', 'Paszek', '1958-03-28', 76);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Selle', 'Germon', '1960-06-30', 27);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Aluin', 'Lean', '1989-05-18', 1);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Marketa', 'Addington', '1960-01-08', 65);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Elyse', 'Blondelle', '1989-02-09', 94);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Kerri', 'Gianilli', '1955-03-23', 75);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Franchot', 'Antcliffe', '1970-01-31', 8);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Arlana', 'Seeking', '1977-01-04', 7);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Felice', 'Sherwell', '1971-05-04', 34);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Charlene', 'Cordoba', '1957-07-10', 77);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Kariotta', 'Whitchurch', '1983-05-21', 15);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Riva', 'Winfield', '1960-02-22', 97);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Rubetta', 'Ackwood', '2001-05-26', 1);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Salomo', 'Lecount', '1990-05-14', 46);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Lissi', 'Scyone', '1969-04-24', 34);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Ethel', 'Pena', '1956-02-12', 54);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Bryanty', 'Kruschev', '1964-11-23', 14);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Jenica', 'Ballingal', '1954-06-09', 86);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Cristie', 'Simonou', '1966-10-02', 45);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Redford', 'Doughty', '1988-11-30', 53);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Clarita', 'Boater', '1951-12-04', 70);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Bink', 'Gerrans', '1998-08-14', 22);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Sonya', 'Sketchley', '1964-07-11', 50);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Jarvis', 'Pensom', '1989-05-23', 38);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Brander', 'Garr', '2000-06-30', 55);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Hollyanne', 'Pouck', '1963-02-27', 56);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Ernestus', 'Canland', '1961-10-12', 35);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Mitchel', 'Lisciardelli', '1998-02-10', 60);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Armin', 'Flecknoe', '1954-12-03', 54);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Floyd', 'Kits', '1994-08-03', 71);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Lanni', 'Sheavills', '1967-08-14', 9);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Peyter', 'Tincknell', '1958-09-17', 77);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Octavia', 'Polkinghorne', '2002-09-14', 48);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Abby', 'Westman', '1971-09-25', 63);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Mendie', 'Kyffin', '1988-01-23', 24);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Filia', 'Jakubowsky', '1979-07-18', 13);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Kenny', 'Janks', '1954-03-11', 75);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Brewster', 'Huncoot', '1964-02-09', 64);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Maggee', 'Charter', '1986-10-19', 51);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Tommy', 'Cartmill', '2002-01-18', 65);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Karlik', 'Korous', '1975-07-09', 13);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Miguela', 'Southerden', '1979-02-12', 99);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Wylie', 'Moline', '1951-07-19', 99);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Saree', 'Agent', '1976-10-20', 81);
insert into trener (Ime, Priimek, Datum_Rojstva, id_reprezentanca) values ('Shawn', 'Beaconsall', '1965-09-10', 80);

insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Tamar', 'Viall', '1998-02-28', 62);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Ainsley', 'Bacher', '1952-04-29', 52);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Adora', 'Petegree', '1989-09-21', 80);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Gretta', 'Benton', '1998-08-06', 71);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Reinhold', 'Greatbatch', '1977-12-24', 44);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Allyce', 'Vinnick', '1967-06-08', 41);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Lula', 'Kingsworth', '1968-05-16', 60);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Letisha', 'Huff', '1952-05-03', 43);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Skipp', 'Blaase', '1992-07-03', 80);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Brit', 'Pentony', '1968-06-08', 52);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Bonni', 'Sebyer', '1969-12-22', 82);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Rodolphe', 'Corgenvin', '1989-12-01', 67);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Antony', 'Jagielski', '1964-05-22', 87);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Benson', 'Theaker', '1987-07-23', 84);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Evan', 'Blythe', '1972-02-10', 66);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Alford', 'Arch', '1998-03-05', 75);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Farah', 'Maletratt', '1960-07-08', 5);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Marsha', 'Wardell', '1961-05-02', 52);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Jerri', 'Wardell', '1973-10-19', 49);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Charlotte', 'Tille', '1966-09-01', 23);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Robinette', 'Shadwick', '1961-03-05', 67);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Rabbi', 'Barwick', '1996-03-14', 39);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Carmencita', 'Edwardes', '1989-02-23', 88);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Pearle', 'Leaning', '1954-09-06', 21);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Goldi', 'Paolicchi', '2000-01-20', 19);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Maison', 'Silliman', '1981-11-22', 65);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Dilan', 'Andino', '1982-10-20', 59);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Wanda', 'Portlock', '1963-05-31', 18);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Calv', 'Ayris', '1957-03-09', 22);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Walt', 'Klug', '1998-11-11', 88);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Raina', 'Leban', '1959-06-01', 40);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Mabel', 'Vasilevich', '1971-07-11', 66);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Karlens', 'Langsbury', '1965-03-21', 3);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Webb', 'Orpen', '1978-05-05', 56);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Angus', 'Jeal', '1976-02-15', 23);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Carita', 'Melland', '1987-02-01', 7);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Tallie', 'Laurenty', '1969-01-21', 100);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Morrie', 'Jain', '1959-01-10', 27);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Brnaby', 'Simonian', '1978-04-12', 19);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Jo', 'De Roberto', '1966-10-29', 21);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Vivyan', 'Woltman', '1966-05-23', 50);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Waldo', 'Antognetti', '1964-03-13', 69);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Darby', 'Hassey', '2002-03-21', 48);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Marylynne', 'Wantling', '1954-09-13', 29);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Elwira', 'Wardel', '1953-09-20', 58);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Wakefield', 'Calafate', '1977-03-01', 88);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Cortie', 'Loughan', '1986-12-12', 68);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Sunny', 'Villiers', '1955-09-19', 74);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Dela', 'Caruth', '1962-05-04', 71);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Joceline', 'Zanardii', '1986-07-30', 84);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Coraline', 'Rundle', '1993-08-01', 100);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Julie', 'Clymer', '1984-09-19', 83);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Linnell', 'Pawfoot', '1996-06-21', 83);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Genny', 'Noice', '1966-08-01', 47);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Halsey', 'Bonicelli', '1981-01-06', 37);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Howard', 'Mathwin', '1984-11-27', 42);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Sayers', 'Herrema', '1974-04-15', 100);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Tallulah', 'Marcham', '1955-12-24', 61);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Cello', 'Gallaway', '1951-04-01', 8);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Lancelot', 'Sparrowe', '1975-11-21', 98);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Cicely', 'Hughs', '1981-08-05', 65);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Margarette', 'Ludgrove', '1971-02-19', 52);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Galven', 'Stag', '1969-04-20', 37);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Annora', 'Dorkens', '1960-05-06', 4);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Mallorie', 'Weaver', '1967-03-09', 95);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Cacilie', 'Horick', '1998-08-07', 54);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Angelina', 'Jezzard', '1982-12-05', 94);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Pietro', 'Bull', '1987-11-07', 95);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Mose', 'Sturton', '1979-07-12', 47);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Lucky', 'Font', '1961-01-22', 3);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Ambros', 'Flott', '1995-08-30', 77);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Sadella', 'Gallelli', '1975-06-27', 23);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Taddeo', 'Aizikov', '1964-09-03', 20);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Hersh', 'Allmen', '1978-05-06', 74);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Jacintha', 'Grayston', '1980-06-03', 2);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Gabbie', 'MacChaell', '1980-07-31', 20);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Mickie', 'O''Skehan', '1979-05-22', 8);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Dalli', 'Leatherbarrow', '1961-07-19', 7);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Briant', 'Woodard', '1960-02-06', 92);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Ranee', 'Garretts', '1975-07-30', 2);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Griselda', 'Rickardes', '1959-01-27', 24);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Homer', 'Bigg', '1962-10-23', 73);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Eddy', 'McVey', '1975-08-11', 48);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Ileana', 'Scranedge', '2001-05-03', 78);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Shell', 'Stoaks', '1990-10-28', 51);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Gale', 'Rutherford', '1955-04-19', 41);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Adrea', 'Hercock', '1973-06-26', 18);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Marthe', 'Gainfort', '1984-05-17', 52);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Aprilette', 'Macbeth', '1996-08-13', 72);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Emmi', 'Tremoille', '1958-05-28', 8);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Queenie', 'Costen', '1956-05-15', 5);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Papagena', 'Bebbington', '1987-07-19', 45);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Valentino', 'Danilenko', '1976-05-08', 27);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Evangeline', 'Apfelmann', '1976-05-27', 76);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Garek', 'Weippert', '1958-09-11', 83);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Ignazio', 'Duckham', '1964-04-06', 93);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Elia', 'Margrett', '1978-10-31', 49);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Moishe', 'Pattini', '1991-12-25', 27);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Harry', 'Rozier', '1964-03-10', 53);
insert into delavec (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Kandace', 'Whithalgh', '1990-11-13', 67);


insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Cobb', 'Aurelius', '1960-03-11', 6);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Sullivan', 'Goodredge', '1958-07-28', 57);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Sandye', 'Kuhwald', '1972-12-21', 61);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Dody', 'Shotton', '1992-04-11', 52);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Lynnelle', 'Balderstone', '1978-10-09', 12);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Bibbie', 'Ikins', '1989-12-01', 67);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Caryl', 'Landeg', '1995-11-01', 14);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Ettie', 'Giggie', '2002-05-18', 65);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Leah', 'Egleton', '1996-09-01', 86);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Hunt', 'Point', '1992-09-29', 63);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Tyler', 'Plunkett', '1957-03-31', 71);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Isabeau', 'Whitelaw', '1978-09-12', 25);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Dorisa', 'Lanegran', '1997-11-24', 23);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Annecorinne', 'Pegden', '1953-03-30', 39);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Cammy', 'Ashford', '1955-10-10', 21);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Emmett', 'Birts', '1960-05-02', 48);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Adoree', 'Gillies', '1999-08-12', 45);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Dickie', 'Mantha', '1987-05-14', 6);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Lethia', 'Shortall', '1962-03-22', 65);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Robbie', 'Brigstock', '2000-02-03', 70);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Sydney', 'Itskovitz', '1953-09-11', 36);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Niki', 'Silvester', '1964-05-01', 86);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Erek', 'Coling', '1972-04-11', 12);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Malva', 'Gianolini', '1994-06-26', 5);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Milka', 'Wasielewicz', '1965-12-17', 97);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Di', 'Swayton', '1967-11-01', 30);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Ilyse', 'Bachs', '1967-06-09', 98);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Simone', 'Antonacci', '1992-12-14', 16);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Heloise', 'Wadley', '1987-12-14', 83);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Valry', 'Gunther', '1971-01-18', 55);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Tadeo', 'Hellwing', '1994-06-20', 59);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Frederique', 'Davidwitz', '1970-02-05', 25);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Georgia', 'Belhome', '2000-06-04', 50);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Merwin', 'Double', '1987-12-31', 78);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Alasdair', 'Dominighi', '1961-02-17', 36);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Gabbey', 'd'' Eye', '1989-10-09', 48);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Elfrida', 'McBrearty', '1966-03-13', 70);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Dyanna', 'Goodee', '1966-08-20', 93);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Rochell', 'Hawford', '1954-11-19', 29);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Wake', 'Sumpton', '2002-07-05', 68);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Colman', 'Brunon', '1981-11-21', 85);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Alejoa', 'Wynne', '1991-07-14', 43);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Tierney', 'Cutmare', '1976-07-05', 13);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Elle', 'Scarlon', '1960-04-16', 49);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Allie', 'Samsin', '1989-04-24', 96);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Alyda', 'Eves', '1976-05-19', 81);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Caterina', 'Sworder', '1958-03-03', 46);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Patin', 'Delacourt', '1965-05-21', 44);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Urban', 'Temprell', '1952-06-16', 73);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Lorne', 'Darnody', '1998-07-29', 87);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Andriana', 'Breed', '1958-01-13', 97);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Klarrisa', 'Vokins', '1965-09-13', 100);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Calla', 'Lejeune', '1980-05-08', 39);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Schuyler', 'Sterre', '1972-01-20', 78);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Hana', 'Verne', '1966-04-05', 46);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Clywd', 'Crackett', '1965-03-16', 95);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Eudora', 'Binford', '1964-05-16', 67);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Ethe', 'Linkin', '1960-01-04', 48);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Cecelia', 'MacKerley', '1964-09-09', 93);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Mohammed', 'Spurdon', '1965-02-05', 45);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Sumner', 'Owtram', '1952-03-20', 67);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Terencio', 'Hales', '1955-02-06', 33);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Matteo', 'Bodocs', '1953-10-16', 88);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Tildi', 'Prichet', '1991-01-07', 83);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Nicolette', 'Reaney', '1974-03-07', 35);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Wainwright', 'Clay', '1974-04-06', 60);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Janine', 'Apted', '1992-04-02', 41);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Alphonso', 'Vella', '1991-06-12', 37);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Amitie', 'Eslinger', '1972-05-24', 19);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Martina', 'Fasson', '1954-05-21', 62);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Jule', 'Dowling', '1963-12-28', 66);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Shandra', 'Lyosik', '1964-04-16', 44);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Dalt', 'Pionter', '1998-08-25', 43);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Lyell', 'Hamil', '1956-10-25', 28);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Iggy', 'Loughan', '1961-06-17', 37);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Florie', 'Catterill', '1973-07-13', 68);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Ansel', 'Andrelli', '1956-07-27', 42);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Mag', 'Melly', '1991-11-25', 48);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Lois', 'Trayton', '1957-03-24', 19);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Adora', 'Kennermann', '1965-08-14', 72);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('North', 'Pirelli', '1985-02-15', 98);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Diena', 'Gallety', '1994-07-14', 33);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Ulberto', 'Scholz', '1984-08-08', 7);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Etan', 'Whittock', '1980-06-30', 48);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Ag', 'Brayne', '1968-07-19', 49);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Adriane', 'Malmar', '1967-11-20', 64);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Fiann', 'Corstan', '1984-08-31', 86);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Thom', 'Cunniam', '1952-05-27', 62);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Gerardo', 'Tupper', '1968-08-07', 96);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Baxter', 'Lineen', '1993-08-22', 47);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Annadiana', 'McKimmey', '1967-06-30', 52);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Maryrose', 'Tinman', '1981-09-06', 42);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Prescott', 'Yurukhin', '1972-06-26', 5);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Lind', 'Veltmann', '1992-08-15', 51);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Jeannette', 'Denekamp', '1965-01-15', 28);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Neal', 'Mingame', '1991-07-06', 3);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Cookie', 'McGuinley', '1970-05-17', 49);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Andria', 'Lanfer', '1980-10-20', 96);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Yoshi', 'Emblem', '1979-04-23', 4);
insert into sodnik (Ime, Priimek, Datum_Rojstva, id_drzava) values ('Barbara', 'Lawther', '1955-08-31', 95);


insert into sport(naziv) values('Nogomet');
insert into sport(naziv) values('Košarka');
insert into sport(naziv) values('Tenis');
insert into sport(naziv) values('Atletika');
insert into sport(naziv) values('Rokomet');
insert into sport(naziv) values('Golf');
insert into sport(naziv) values('Gimnastika');
insert into sport(naziv) values('Judo');
insert into sport(naziv) values('Plavanje');


insert into Disciplina(naziv, id_sport) values ('Suvanje krogle', 4);
insert into Disciplina(naziv, id_sport) values ('400m', 4);
insert into Disciplina(naziv, id_sport) values ('100m', 4);
insert into Disciplina(naziv, id_sport) values ('Met diska', 4);
insert into Disciplina(naziv, id_sport) values ('Met kladiva', 4);
insert into Disciplina(naziv, id_sport) values ('100m prosto', 9);
insert into Disciplina(naziv, id_sport) values ('100m hrbtno', 9);
insert into Disciplina(naziv, id_sport) values ('Kajak', 9);



insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-16', 5, 60);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-25', 2, 43);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-17', 3, 18);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-15', 5, 11);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-08', 3, 100);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-11', 3, 87);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-04', 6, 100);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-18', 1, 40);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-16', 5, 58);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-13', 1, 51);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-22', 2, 65);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-08', 9, 1);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-27', 4, 67);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-23', 5, 68);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-04', 5, 92);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-13', 3, 15);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-08', 6, 2);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-14', 3, 84);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-12', 4, 49);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-08', 8, 36);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-06', 1, 22);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-12', 9, 38);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-04', 7, 40);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-29', 5, 3);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-01', 6, 17);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-11', 8, 86);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-04', 6, 50);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-19', 9, 17);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-21', 4, 16);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-19', 8, 36);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-20', 5, 63);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-04', 4, 38);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-20', 7, 75);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-21', 2, 42);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-25', 7, 56);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-25', 3, 39);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-08', 4, 87);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-05', 5, 11);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-11', 3, 58);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-10', 1, 88);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-22', 2, 68);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-23', 2, 5);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-16', 7, 82);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-05', 2, 84);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-10', 2, 22);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-08', 4, 91);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-11', 4, 18);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-14', 7, 49);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-03', 8, 86);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-27', 8, 16);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-03', 3, 15);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-27', 7, 90);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-26', 2, 28);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-01', 1, 90);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-05', 3, 79);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-10', 9, 18);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-19', 4, 64);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-08', 4, 84);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-27', 7, 96);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-26', 4, 64);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-04', 4, 17);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-07', 4, 79);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-24', 1, 30);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-01', 5, 53);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-16', 1, 58);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-25', 5, 17);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-27', 3, 48);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-30', 1, 18);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-16', 6, 56);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-05', 3, 6);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-29', 9, 13);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-30', 4, 97);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-22', 6, 75);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-21', 5, 2);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-13', 1, 11);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-22', 5, 17);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-25', 8, 67);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-09', 6, 38);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-09', 9, 2);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-01', 5, 47);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-26', 1, 81);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-22', 4, 67);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-14', 3, 81);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-22', 7, 83);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-30', 6, 58);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-01', 1, 77);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-22', 7, 49);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-01', 9, 80);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-21', 7, 27);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-24', 1, 55);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-08', 4, 10);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-21', 2, 35);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-10', 4, 84);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-02', 6, 11);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-19', 8, 63);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-23', 3, 48);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-06', 9, 68);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-17', 8, 11);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-23', 4, 45);
insert into Dogodek (datum_dogodka, id_sport, id_prrizorisce) values ('2020-06-25', 7, 53);


insert into medalja(barva) values('Zlata');
insert into medalja(barva) values('Srebrna');
insert into medalja(barva) values('Bronasta');


insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (4, 72, 38, 16.9, 24);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (5, 35, 39, 17.9, 22);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 40, 35, 19.4, 16);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (2, 43, 63, 25.8, 11);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 34, 18, 26.8, 20);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 21, 4, 24.8, 14);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (7, 40, 23, 26.9, 11);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 24, 98, 25.3, 14);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (2, 68, 6, 22.4, 22);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (6, 62, 88, 17.6, 25);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (7, 59, 76, 14.0, 11);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (1, 51, 87, 14.6, 21);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (3, 39, 60, 13.8, 30);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (1, 64, 53, 11.9, 11);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (6, 86, 43, 11.0, 21);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 97, 70, 21.8, 26);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (4, 17, 61, 27.6, 28);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (7, 4, 96, 27.7, 30);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (7, 24, 35, 14.5, 12);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (3, 61, 6, 29.3, 24);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (4, 67, 2, 28.9, 28);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (7, 37, 21, 18.9, 24);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (4, 69, 1, 11.0, 16);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (1, 31, 36, 20.9, 12);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 10, 16, 29.2, 20);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 63, 62, 24.7, 12);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (4, 85, 18, 16.2, 15);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 77, 80, 28.9, 28);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (2, 26, 52, 14.4, 30);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (3, 34, 4, 25.6, 20);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 29, 17, 28.3, 30);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 79, 74, 23.5, 12);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (1, 75, 8, 18.7, 27);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (3, 37, 75, 29.7, 16);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (4, 21, 33, 22.3, 17);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 12, 2, 16.1, 29);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (7, 82, 7, 20.7, 26);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (7, 5, 12, 18.0, 16);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (3, 24, 82, 25.9, 24);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (6, 34, 96, 24.2, 15);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (6, 93, 92, 23.2, 14);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (1, 55, 100, 26.0, 30);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (1, 62, 55, 14.3, 28);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (1, 75, 91, 29.9, 19);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (2, 53, 52, 16.6, 25);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 91, 44, 18.9, 23);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (3, 94, 96, 26.4, 14);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 63, 76, 20.2, 25);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (4, 17, 31, 26.0, 16);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (1, 55, 99, 18.8, 29);

insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (4, 72, 38, 16.9, 24);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (5, 35, 39, 17.9, 22);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 40, 35, 19.4, 16);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (2, 43, 63, 25.8, 11);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 34, 18, 26.8, 20);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 21, 4, 24.8, 14);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (7, 40, 23, 26.9, 11);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 24, 98, 25.3, 14);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (2, 68, 6, 22.4, 22);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (6, 62, 88, 17.6, 25);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (7, 59, 76, 14.0, 11);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (1, 51, 87, 14.6, 21);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (3, 39, 60, 13.8, 30);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (1, 64, 53, 11.9, 11);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (6, 86, 43, 11.0, 21);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 97, 70, 21.8, 26);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (4, 17, 61, 27.6, 28);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (7, 4, 96, 27.7, 30);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (7, 24, 35, 14.5, 12);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (3, 61, 6, 29.3, 24);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (4, 67, 2, 28.9, 28);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (7, 37, 21, 18.9, 24);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (4, 69, 1, 11.0, 16);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (1, 31, 36, 20.9, 12);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 10, 16, 29.2, 20);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 63, 62, 24.7, 12);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (4, 85, 18, 16.2, 15);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 77, 80, 28.9, 28);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (2, 26, 52, 14.4, 30);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (3, 34, 4, 25.6, 20);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 29, 17, 28.3, 30);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 79, 74, 23.5, 12);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (1, 75, 8, 18.7, 27);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (3, 37, 75, 29.7, 16);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (4, 21, 33, 22.3, 17);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 12, 2, 16.1, 29);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (7, 82, 7, 20.7, 26);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (7, 5, 12, 18.0, 16);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (3, 24, 82, 25.9, 24);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (6, 34, 96, 24.2, 15);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (6, 93, 92, 23.2, 14);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (1, 55, 100, 26.0, 30);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (1, 62, 55, 14.3, 28);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (1, 75, 91, 29.9, 19);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (2, 53, 52, 16.6, 25);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 91, 44, 18.9, 23);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (3, 94, 96, 26.4, 14);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (8, 63, 76, 20.2, 25);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (4, 17, 31, 26.0, 16);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (1, 55, 99, 18.8, 29);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (1, 17, 101, 19.9, 3);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (1, 17, 101, 19.9, 1);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (1, 17, 101, 19.9, 1);
insert into nastop (id_disciplina, id_dogodka, id_sportnik, rezultat_meti, mesto) values (1, 17, 101, 19.9, 8);

select * from sportnik where ime = "Miha";






insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (29, 3, '2016-07-20');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (100, 52, '2013-12-07');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (12, 92, '2017-09-27');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (87, 16, '2011-12-29');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (63, 78, '2009-03-13');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (29, 45, '2015-11-03');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (23, 55, '2005-10-28');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (58, 47, '2005-05-17');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (28, 36, '2007-08-31');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (45, 62, '2008-07-12');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (19, 3, '2002-01-26');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (48, 55, '2008-05-17');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (100, 72, '2014-01-24');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (45, 14, '2008-07-19');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (6, 61, '2006-08-05');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (61, 38, '2002-08-04');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (68, 68, '2009-04-19');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (47, 8, '2015-07-26');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (47, 86, '2000-09-05');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (58, 15, '2012-10-18');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (21, 72, '2012-07-08');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (79, 44, '2014-09-29');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (50, 63, '2011-06-09');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (68, 100, '2005-06-12');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (72, 6, '2015-06-15');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (47, 21, '2016-01-26');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (92, 93, '2002-10-05');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (30, 61, '2010-08-23');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (8, 60, '2017-05-07');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (34, 97, '2012-05-19');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (75, 64, '2015-10-06');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (58, 2, '2012-09-23');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (64, 44, '2002-01-08');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (80, 53, '2011-01-23');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (47, 81, '2016-04-24');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (10, 14, '2008-10-01');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (90, 24, '2014-05-11');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (71, 32, '2005-03-12');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (44, 36, '2018-07-19');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (19, 20, '2013-06-07');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (99, 66, '2002-03-11');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (33, 49, '2006-04-23');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (87, 27, '2019-11-23');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (27, 47, '2016-12-26');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (41, 82, '2006-05-03');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (87, 43, '2003-09-24');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (68, 22, '2001-08-03');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (51, 79, '2002-03-24');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (45, 33, '2012-03-28');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (31, 49, '2004-12-21');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (77, 64, '2018-04-23');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (80, 47, '2014-11-15');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (72, 4, '2005-02-25');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (37, 29, '2019-12-27');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (10, 46, '2006-05-16');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (97, 7, '2014-06-07');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (91, 64, '2003-08-26');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (91, 77, '2007-06-11');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (41, 48, '2006-01-19');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (87, 57, '2015-11-18');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (100, 46, '2002-11-07');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (99, 20, '2006-04-12');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (28, 64, '2003-03-03');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (24, 10, '2010-10-07');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (53, 2, '2005-08-02');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (83, 92, '2013-07-02');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (59, 61, '2013-03-22');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (50, 50, '2010-10-21');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (15, 91, '2009-04-13');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (51, 23, '2011-01-17');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (43, 35, '2007-08-08');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (20, 93, '2010-01-14');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (35, 91, '2015-10-15');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (70, 53, '2005-01-23');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (21, 55, '2014-03-15');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (67, 80, '2006-05-06');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (46, 8, '2002-09-17');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (80, 96, '2000-11-15');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (85, 83, '2004-12-26');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (98, 58, '2017-12-08');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (86, 47, '2009-12-18');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (15, 86, '2019-09-08');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (63, 7, '2005-07-02');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (6, 6, '2012-07-02');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (36, 2, '2014-09-01');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (30, 11, '2004-01-29');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (43, 16, '2019-06-20');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (76, 32, '2016-02-17');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (57, 30, '2001-06-27');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (20, 51, '2007-11-29');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (27, 32, '2003-11-27');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (95, 31, '2006-08-02');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (51, 30, '2011-07-26');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (79, 42, '2018-09-22');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (83, 2, '2009-06-17');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (76, 61, '2017-10-02');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (36, 27, '2011-07-11');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (52, 98, '2013-12-22');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (50, 60, '2015-05-26');
insert into sportnik_trener (id_trener, id_sportnik, datum_od) values (33, 50, '2016-04-08');

insert into sodnik_dogodek (id_sodnik, id_dogodka) values (46, 73);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (24, 43);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (91, 8);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (84, 56);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (25, 1);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (69, 30);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (53, 27);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (31, 82);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (40, 19);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (99, 8);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (42, 66);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (98, 84);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (100, 92);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (100, 28);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (44, 51);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (4, 77);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (95, 87);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (54, 28);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (75, 100);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (10, 5);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (95, 80);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (85, 30);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (9, 93);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (83, 87);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (81, 74);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (8, 15);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (44, 27);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (72, 2);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (67, 42);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (37, 28);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (91, 33);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (25, 18);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (78, 5);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (77, 34);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (62, 25);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (57, 71);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (25, 75);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (96, 65);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (49, 93);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (77, 50);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (95, 22);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (17, 31);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (57, 70);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (66, 44);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (97, 65);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (35, 96);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (30, 26);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (25, 36);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (85, 23);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (85, 59);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (34, 88);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (50, 34);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (44, 18);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (8, 50);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (6, 8);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (16, 45);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (25, 56);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (95, 2);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (67, 7);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (8, 5);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (17, 19);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (37, 45);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (92, 35);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (39, 44);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (66, 55);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (1, 26);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (5, 37);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (10, 68);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (20, 93);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (12, 67);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (58, 57);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (30, 24);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (53, 31);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (57, 37);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (34, 22);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (87, 62);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (74, 10);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (5, 89);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (70, 82);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (11, 41);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (43, 21);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (75, 96);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (12, 44);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (54, 40);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (40, 84);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (90, 74);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (23, 92);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (88, 76);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (99, 85);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (53, 67);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (81, 20);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (81, 98);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (89, 74);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (89, 31);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (4, 5);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (70, 36);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (19, 60);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (31, 6);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (21, 62);
insert into sodnik_dogodek (id_sodnik, id_dogodka) values (46, 39);


insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (73, 55, 'Programmer III', 68);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (33, 90, 'Computer Systems Analyst IV', 56);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (85, 81, 'Nuclear Power Engineer', 83);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (91, 64, 'Chief Design Engineer', 67);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (89, 94, 'Automation Specialist IV', 51);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (94, 64, 'Office Assistant IV', 24);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (47, 33, 'Clinical Specialist', 72);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (1, 21, 'Recruiter', 99);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (2, 1, 'Graphic Designer', 64);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (69, 99, 'Desktop Support Technician', 94);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (20, 87, 'Nuclear Power Engineer', 40);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (16, 35, 'Tax Accountant', 13);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (29, 62, 'Pharmacist', 98);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (42, 5, 'Librarian', 81);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (84, 52, 'Dental Hygienist', 79);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (75, 72, 'Research Assistant III', 3);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (27, 69, 'Account Executive', 43);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (37, 57, 'Dental Hygienist', 83);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (11, 24, 'Payment Adjustment Coordinator', 45);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (68, 58, 'Data Coordiator', 25);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (45, 21, 'Sales Associate', 24);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (72, 71, 'Structural Engineer', 95);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (48, 79, 'Electrical Engineer', 82);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (12, 65, 'Social Worker', 15);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (52, 33, 'Graphic Designer', 19);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (76, 45, 'Mechanical Systems Engineer', 57);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (17, 63, 'Quality Engineer', 19);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (65, 43, 'Research Assistant III', 29);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (4, 100, 'Pharmacist', 38);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (67, 25, 'Senior Developer', 74);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (89, 83, 'Product Engineer', 17);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (64, 6, 'VP Product Management', 61);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (79, 40, 'Database Administrator III', 21);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (6, 24, 'Social Worker', 19);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (67, 29, 'Community Outreach Specialist', 70);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (35, 57, 'Software Test Engineer IV', 72);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (90, 49, 'Senior Sales Associate', 1);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (30, 56, 'Chemical Engineer', 28);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (38, 44, 'Nuclear Power Engineer', 26);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (53, 95, 'Senior Cost Accountant', 77);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (28, 88, 'Business Systems Development Analyst', 49);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (44, 90, 'Biostatistician II', 76);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (97, 92, 'Automation Specialist I', 70);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (15, 7, 'Data Coordiator', 68);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (79, 30, 'Account Representative III', 93);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (2, 80, 'Account Representative II', 70);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (62, 90, 'Project Manager', 56);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (33, 15, 'Clinical Specialist', 32);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (28, 68, 'Accountant II', 26);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (51, 18, 'Quality Control Specialist', 85);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (56, 5, 'Librarian', 32);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (46, 42, 'Office Assistant II', 18);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (54, 55, 'Editor', 33);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (18, 30, 'VP Product Management', 68);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (85, 11, 'Occupational Therapist', 76);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (85, 13, 'Senior Financial Analyst', 41);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (53, 69, 'Nurse', 29);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (83, 63, 'Environmental Specialist', 43);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (98, 43, 'Speech Pathologist', 33);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (87, 99, 'Systems Administrator III', 83);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (35, 59, 'General Manager', 32);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (18, 20, 'Account Coordinator', 9);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (13, 84, 'VP Product Management', 21);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (80, 75, 'Occupational Therapist', 46);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (12, 66, 'Media Manager III', 45);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (3, 9, 'Environmental Tech', 23);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (68, 99, 'Quality Control Specialist', 8);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (67, 66, 'Senior Developer', 18);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (71, 47, 'VP Accounting', 67);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (71, 80, 'Speech Pathologist', 14);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (44, 15, 'Financial Advisor', 73);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (92, 5, 'Marketing Manager', 53);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (95, 97, 'Compensation Analyst', 90);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (54, 3, 'Budget/Accounting Analyst IV', 77);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (21, 60, 'Staff Scientist', 100);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (2, 32, 'Quality Control Specialist', 49);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (23, 7, 'Assistant Manager', 60);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (62, 8, 'Recruiter', 61);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (89, 69, 'Information Systems Manager', 28);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (95, 10, 'Payment Adjustment Coordinator', 27);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (72, 83, 'Account Coordinator', 79);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (96, 46, 'Software Test Engineer II', 27);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (55, 35, 'Editor', 59);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (71, 22, 'Cost Accountant', 4);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (2, 40, 'Professor', 87);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (6, 68, 'GIS Technical Architect', 51);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (20, 1, 'Actuary', 46);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (25, 98, 'Geological Engineer', 82);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (49, 7, 'Registered Nurse', 55);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (76, 62, 'Staff Accountant I', 45);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (25, 50, 'Structural Analysis Engineer', 68);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (8, 15, 'Executive Secretary', 49);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (78, 8, 'Cost Accountant', 33);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (22, 36, 'Senior Editor', 75);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (14, 30, 'Nurse', 98);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (76, 89, 'Administrative Officer', 53);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (46, 67, 'Librarian', 61);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (43, 19, 'Nurse', 67);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (71, 51, 'Account Representative III', 49);
insert into delavec_dogodek (id_delavec, id_dogodka, Delo, ure) values (40, 98, 'Chief Design Engineer', 19);


select * from  sportnik_trener;
select * from  sodnik_dogodek;
select * from  delavec_dogodek;
select * from  nastop;
select * from  dogodek;
select * from  prrizorisce;
select * from  naslov;
select * from  kraj;
select * from  sodnik;
select * from  delavec;
select * from  trener;
select * from  sportnik;
select * from  reprezentanca;
select * from  drzava;
select * from  medalja;
select * from  disciplina;
select * from  sport;



-- Naloga 3
-- Kateri športniki tekmujejo v "metu krogle"? 
select s.*
from sportnik s join nastop n on s.id_sportnik = n.id_sportnik join disciplina d on n.id_disciplina = d.id_disciplina
where d.naziv = 'Suvanje krogle';

-- Katero najboljšo uvrstitev je dosegel "Miha Kos" v atletiki? 
select min(n.mesto)
from nastop n join  sportnik s on s.id_sportnik = n.id_sportnik
where s.ime = 'Miha' AND s.priimek = 'Kos';


-- Kakšen je bil povprečen rezultat "Mihe Kosa" v atletiki leta 2019?
select avg(n.rezultat_meti)
from nastop n join  sportnik s on s.id_sportnik = n.id_sportnik
where s.ime = 'Miha' AND s.priimek = 'Kos';

-- Katera država ima največ športnikov v atletiki? 
select Drzava, max(stNastopov)
from (select d.naziv as Drzava, count(id_nastopa) as stNastopov
from drzava d join reprezentanca r on d.id_drzava = r.id_drzava 
			  join sportnik s on s.id_reprezentanca = r.id_reprezentanca
              join nastop n on n.id_sportnik = s.id_sportnik
              join disciplina dp on dp.id_disciplina = n.id_disciplina
              join sport sp on sp.id_sport = dp.id_sport
where sp.naziv = 'Atletika'
group by d.naziv) as maxDrzava;

-- Spremeni priimek igralca Miha Kos v Horvat
update sportnik
set priimek = 'koss'
where ime ='Miha' and priimek = 'Kos' and id_sportnik <> -1;



-- . Izbriši disciplino "kajak"     
delete from disciplina where naziv = 'Kajak' and id_disciplina <> -1;       


create table izbrisani(
	id_disciplina int,
    id_sport int,
    naziv varchar(45)    
);

select * from izbrisani;


-- triger naloga 4
create trigger obIzbrisu 
before delete on disciplina
for each row
	insert into izbrisani(id_disciplina, id_sport, naziv) values (old.id_disciplina, old.id_sport, old.naziv);
            
