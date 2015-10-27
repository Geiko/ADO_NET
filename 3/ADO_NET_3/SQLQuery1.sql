
--IF EXISTS(SELECT * FROM sys.databases WHERE name='geikoDB')
DROP DATABASE [geikoDbUsers]
--GO

CREATE DATABASE geikoDbWorksheet
--GO



USE geikoDbWorksheet
GO
DROP TABLE [Person]; 
DROP TABLE [Address]; 




DROP TABLE [User]; 
DROP TABLE [Contact]; 
--GO

CREATE TABLE [Contact] 
( 
	[id] INT PRIMARY KEY IDENTITY,
	[Address] NVARCHAR(64),
	[Phone] NVARCHAR(64),
);

INSERT INTO [Contact] 
([Address], [Phone]) 
VALUES 
('Office #315', '777-77-77'),
('Office #316', '888-77-77'),
('Office #317', '999-77-77')

CREATE TABLE [User] 
( 
	[id] INT PRIMARY KEY IDENTITY,
	[ContactId] INT FOREIGN KEY REFERENCES [Contact]([id]),
	[Login] NVARCHAR(64),
	[Password] NVARCHAR(64),
	[Admin] BIT
); 

INSERT INTO [User] 
([ContactId], [Login], [Password], [Admin]) 
VALUES 
(1, 'Vasya', '00', 1),
(1, 'Sveta', '8765', 0),
(2, 'Kolya', 'sdffer', 1),
(3, 'Vasya', '45fg', 0),
(2, 'Fedya', 'g11g', 0)

SELECT [TABLE_NAME] FROM information_schema.tables;

SELECT * FROM [Contact];
SELECT * FROM [User];