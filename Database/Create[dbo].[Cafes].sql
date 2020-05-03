CREATE TABLE [dbo].[Cafes]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR,
	[Address] NVARCHAR
)

INSERT INTO [dbo].[Cafes] ([Name],[Address]) values ('Пан Запекан','ул.Якиманка,д.2'), ('Пан Запекан','Дербенёвская наб.,д.11'), ('Братья Караваевы','ул.Шаболовка, д.14')