USE [master]
GO

IF EXISTS(SELECT * FROM Sysdatabases WHERE NAME LIKE 'nothinbutdotnetprep')
  DROP DATABASE [nothinbutdotnetprep]
  GO

CREATE DATABASE [nothinbutdotnetprep] ON  PRIMARY 
( NAME = N'nothinbutdotnetprep', FILENAME = N'C:\databases\nothinbutdotnetprep.mdf' , SIZE = 2240KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'nothinbutdotnetprep_log', FILENAME = N'C:\databases\nothinbutdotnetprep.ldf' , SIZE = 768KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
