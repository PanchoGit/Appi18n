USE master
GO

IF (NOT EXISTS (SELECT 1 FROM master.dbo.sysdatabases WHERE name = 'Appi18n' ))
BEGIN
     CREATE DATABASE Appi18n
END
GO
