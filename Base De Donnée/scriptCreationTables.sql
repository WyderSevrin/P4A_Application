-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- use mydb;
-- drop schema mydb;
-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`Utilisateur`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Utilisateur` (
  `idUtilisateur` INT NOT NULL AUTO_INCREMENT,
  `Nom` VARCHAR(45) NULL,
  `Nb_Signalement` INT NULL,
  PRIMARY KEY (`idUtilisateur`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Livre`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Livre` (
  `idLivre` INT NOT NULL AUTO_INCREMENT,
  `Nom` VARCHAR(45) NULL,
  `Genre` VARCHAR(45) NULL,
  `Text` VARCHAR(100) NULL,
  `Resumer` VARCHAR(5000) NULL,
  `Nb_Pages` INT NULL,
  `Mouvement` VARCHAR(100) NULL,
  `Auteur` VARCHAR(45) NULL,
  PRIMARY KEY (`idLivre`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Favoris`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Favoris` (
  `Utilisateur_idUtilisateur` INT NOT NULL,
  `Livre_idLivre` INT NOT NULL,
  PRIMARY KEY (`Utilisateur_idUtilisateur`, `Livre_idLivre`),
  INDEX `fk_Utilisateur_has_Livre_Livre1_idx` (`Livre_idLivre` ASC),
  INDEX `fk_Utilisateur_has_Livre_Utilisateur_idx` (`Utilisateur_idUtilisateur` ASC),
  CONSTRAINT `fk_Utilisateur_has_Livre_Utilisateur`
    FOREIGN KEY (`Utilisateur_idUtilisateur`)
    REFERENCES `mydb`.`Utilisateur` (`idUtilisateur`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Utilisateur_has_Livre_Livre1`
    FOREIGN KEY (`Livre_idLivre`)
    REFERENCES `mydb`.`Livre` (`idLivre`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Lire`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Lire` (
  `Utilisateur_idUtilisateur` INT NOT NULL,
  `Livre_idLivre` INT NOT NULL,
  PRIMARY KEY (`Utilisateur_idUtilisateur`, `Livre_idLivre`),
  INDEX `fk_Utilisateur_has_Livre_Livre2_idx` (`Livre_idLivre` ASC),
  INDEX `fk_Utilisateur_has_Livre_Utilisateur1_idx` (`Utilisateur_idUtilisateur` ASC),
  CONSTRAINT `fk_Utilisateur_has_Livre_Utilisateur1`
    FOREIGN KEY (`Utilisateur_idUtilisateur`)
    REFERENCES `mydb`.`Utilisateur` (`idUtilisateur`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Utilisateur_has_Livre_Livre2`
    FOREIGN KEY (`Livre_idLivre`)
    REFERENCES `mydb`.`Livre` (`idLivre`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Recommandation`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Recommandation` (
  `idRecommandation` INT NOT NULL AUTO_INCREMENT,
  `Titre` VARCHAR(45) NULL,
  `Message` VARCHAR(200) NULL,
  `Utilisateur_idUtilisateur` INT NOT NULL,
  PRIMARY KEY (`idRecommandation`),
  INDEX `fk_Recommandation_Utilisateur1_idx` (`Utilisateur_idUtilisateur` ASC),
  CONSTRAINT `fk_Recommandation_Utilisateur1`
    FOREIGN KEY (`Utilisateur_idUtilisateur`)
    REFERENCES `mydb`.`Utilisateur` (`idUtilisateur`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Commentaire`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Commentaire` (
  `idCommentaire` INT NOT NULL AUTO_INCREMENT,
  `Titre` VARCHAR(45) NULL,
  `Contenu` VARCHAR(300) NULL,
  `Notation` INT NULL,
  `Nb_Signalement` INT NULL,
  `Utilisateur_idUtilisateur` INT NOT NULL,
  `Livre_idLivre` INT NOT NULL,
  PRIMARY KEY (`idCommentaire`),
  INDEX `fk_Commentaire_Utilisateur1_idx` (`Utilisateur_idUtilisateur` ASC),
  INDEX `fk_Commentaire_Livre1_idx` (`Livre_idLivre` ASC),
  CONSTRAINT `fk_Commentaire_Utilisateur1`
    FOREIGN KEY (`Utilisateur_idUtilisateur`)
    REFERENCES `mydb`.`Utilisateur` (`idUtilisateur`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Commentaire_Livre1`
    FOREIGN KEY (`Livre_idLivre`)
    REFERENCES `mydb`.`Livre` (`idLivre`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;