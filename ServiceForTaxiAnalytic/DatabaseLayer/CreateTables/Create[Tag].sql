CREATE TABLE [Tag] (
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(100),
[Category] INT
)

ALTER TABLE [dbo].[Tag]
ADD CONSTRAINT FK_Category 
FOREIGN KEY (Category)
REFERENCES [dbo].[Category]([Id])