INSERT INTO [dbo].[Cafes] 
([Name],[Address])
 VALUES ('Makdonalds','Shabolovka 13'),
('Starhit','Shabolovka 20'),('Farsh','Vavilova 3')

INSERT INTO [dbo].[Category] 
([Name]) VALUES ('Time'), 
('Price'), ('Type')

INSERT INTO [dbo].[Tag] 
([Name],[Category]) VALUES ('24 hours',1),
('12 hours',1),('from 10 to 22',1),
('100-200',2),('200-300',2),
('300-500',2),('Vegetarian',3),
('Fast food',3),('Healthy food',3)

INSERT INTO [dbo].[Cafe_Tag]
 VALUES (4,1),(4,4),
 (4,7),(5,1),
 (5,5),(5,8)
 
 INSERT INTO [dbo].[Location] 
([Name], [Type])
 VALUES
('Ivanovo','1'),
('Moscow','1'),
('Vladimir','1'),
('Gercen','2'),
('Tabochaya','2'),
('Novaya ilinka','2'),
('1','3'),
('2','3'),
('3','3')