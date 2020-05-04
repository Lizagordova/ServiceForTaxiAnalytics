﻿CREATE TABLE [dbo].[Cafe_Tag] 
([CafeId] INT NOT NULL,
[TagId] INT NOT NULL,
CONSTRAINT Cafe_Id FOREIGN KEY ([CafeId]) REFERENCES [dbo].[Cafes] ([Id]) ON DELETE CASCADE,
CONSTRAINT Tag_Id FOREIGN KEY ([TagId]) REFERENCES [dbo].[Tag] ([Id]))