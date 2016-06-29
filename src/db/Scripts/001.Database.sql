USE master
GO

IF (NOT EXISTS (SELECT 1 FROM master.dbo.sysdatabases WHERE name = 'Appi18n' ))
BEGIN
     CREATE DATABASE Appi18n
END
GO

USE Appi18n
GO

IF (NOT EXISTS (SELECT 1 FROM sys.syslogins where name = 'Appi18nU'))
BEGIN
     CREATE LOGIN Appi18nU WITH
            PASSWORD = 'hellspawn',
            DEFAULT_DATABASE = Appi18n ,
            CHECK_EXPIRATION = OFF ,
            CHECK_POLICY = OFF;
END

IF (NOT EXISTS (SELECT 1 FROM Appi18n.sys.database_principals where name = 'Appi18nU' ))
BEGIN
     CREATE USER Appi18nU FOR LOGIN Appi18nU;
END

GRANT SELECT TO Appi18nU
GRANT INSERT TO Appi18nU
GRANT UPDATE TO Appi18nU
GRANT DELETE TO Appi18nU
