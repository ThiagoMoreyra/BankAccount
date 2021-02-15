CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210215052205_InitialCreate') THEN

    CREATE TABLE `tbBank` (
        `Id` char(36) NOT NULL,
        `BankCode` int NOT NULL,
        `CompanyName` varchar(50) NOT NULL,
        `AuthenticatedUser` tinyint(1) NOT NULL,
        CONSTRAINT `PK_tbBank` PRIMARY KEY (`Id`)
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210215052205_InitialCreate') THEN

    CREATE TABLE `tbOwner` (
        `Id` char(36) NOT NULL,
        `FirstName` VARCHAR(100) NULL,
        `LastName` VARCHAR(100) NULL,
        `BirthDay` datetime NOT NULL,
        `Cpf` VARCHAR(100) NULL,
        `Address_Street` longtext CHARACTER SET utf8mb4 NULL,
        `Number` VARCHAR(100) NULL,
        `Neighborhood` VARCHAR(100) NULL,
        `City` VARCHAR(100) NULL,
        `State` VARCHAR(100) NULL,
        `Country` VARCHAR(100) NULL,
        `ZipCode` VARCHAR(100) NULL,
        CONSTRAINT `PK_tbOwner` PRIMARY KEY (`Id`)
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210215052205_InitialCreate') THEN

    CREATE TABLE `tbAccount` (
        `Id` char(36) NOT NULL,
        `IdBank` char(36) NOT NULL,
        `IdOwner` char(36) NOT NULL,
        `Number` varchar(200) NOT NULL,
        `BankCode` int NOT NULL,
        `Balance` decimal NOT NULL,
        `CreationDate` datetime NOT NULL,
        CONSTRAINT `PK_tbAccount` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_tbAccount_tbBank_IdBank` FOREIGN KEY (`IdBank`) REFERENCES `tbBank` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_tbAccount_tbOwner_IdOwner` FOREIGN KEY (`IdOwner`) REFERENCES `tbOwner` (`Id`) ON DELETE CASCADE
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210215052205_InitialCreate') THEN

    CREATE TABLE `tbBankStatement` (
        `Id` char(36) NOT NULL,
        `IdAccount` char(36) NOT NULL,
        `IdOwner` char(36) NOT NULL,
        `TransactionType` varchar(20) NOT NULL,
        `TransactionDate` datetime NOT NULL,
        `Amount` decimal NOT NULL,
        `AvaliableBalance` decimal NOT NULL,
        `AccountId` char(36) NULL,
        `OwnerId` char(36) NULL,
        CONSTRAINT `PK_tbBankStatement` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_tbBankStatement_tbAccount_AccountId` FOREIGN KEY (`AccountId`) REFERENCES `tbAccount` (`Id`) ON DELETE RESTRICT,
        CONSTRAINT `FK_tbBankStatement_tbOwner_OwnerId` FOREIGN KEY (`OwnerId`) REFERENCES `tbOwner` (`Id`) ON DELETE RESTRICT
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210215052205_InitialCreate') THEN

    CREATE TABLE `tbTransaction` (
        `Id` char(36) NOT NULL,
        `IdAccount` binary(32) NOT NULL,
        `IdBank` binary(32) NOT NULL,
        `Amount` decimal NOT NULL,
        `MovDate` datetime NOT NULL,
        `BankId` char(36) NULL,
        CONSTRAINT `PK_tbTransaction` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_tbTransaction_tbBank_BankId` FOREIGN KEY (`BankId`) REFERENCES `tbBank` (`Id`) ON DELETE RESTRICT,
        CONSTRAINT `FK_tbTransaction_tbAccount_Id` FOREIGN KEY (`Id`) REFERENCES `tbAccount` (`Id`) ON DELETE CASCADE
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210215052205_InitialCreate') THEN

    CREATE INDEX `IX_tbAccount_IdBank` ON `tbAccount` (`IdBank`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210215052205_InitialCreate') THEN

    CREATE UNIQUE INDEX `IX_tbAccount_IdOwner` ON `tbAccount` (`IdOwner`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210215052205_InitialCreate') THEN

    CREATE INDEX `IX_tbBankStatement_AccountId` ON `tbBankStatement` (`AccountId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210215052205_InitialCreate') THEN

    CREATE INDEX `IX_tbBankStatement_OwnerId` ON `tbBankStatement` (`OwnerId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210215052205_InitialCreate') THEN

    CREATE INDEX `IX_tbTransaction_BankId` ON `tbTransaction` (`BankId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210215052205_InitialCreate') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20210215052205_InitialCreate', '3.1.11');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

