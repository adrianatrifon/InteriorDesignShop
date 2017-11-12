USE InteriorDesignShopDB

DECLARE @Photo uniqueidentifier  
SET @Photo= NEWID()
INSERT INTO Photos ([PhotoID],[Image]) 
SELECT @Photo,BulkColumn 
FROM Openrowset( Bulk 'C:\Users\Adriana\source\repos\imagini\Pat-Viena-800x600.jpg', Single_Blob) AS ProductImage

DECLARE @Color uniqueidentifier  
SET @Color = NEWID()
INSERT INTO Colors ([ColorID],[Name]) VALUES (@Color,'Maro');

DECLARE @Material uniqueidentifier  
SET @Material = NEWID()
INSERT INTO Materials([MaterialID],[Name]) VALUES (@Material,'wood');

DECLARE @Brand uniqueidentifier  
SET @Brand = NEWID()
INSERT INTO Brands ([BrandID],[Name]) VALUES (@Brand,'Kalatzerka');

DECLARE @Category uniqueidentifier  
SET @Category= NEWID()
INSERT INTO Categories ([CategoryID],[Name]) VALUES (@Category,'Bedroom');

DECLARE @SubCategory uniqueidentifier  
SET @SubCategory= NEWID()

INSERT INTO SubCategories([SubCategoryID],[Name]) VALUES (@SubCategory,'Beds');
INSERT INTO CategorSubCategor([CategoryID],[SubCategoryID]) VALUES (@Category,@SubCategory);

DECLARE @Product uniqueidentifier  
SET @Product = NEWID()
INSERT INTO Products([ProductID],[Name],[Price],[Stock],[Dimensions],[Weight],[Description],[Guarantee],[ColorID],[BrandID],[PromotionID],[CategoryID]) 
VALUES (@Product,'Pat Piele Grandiose','500RON',25,'lungime 200 cm/latime 180 cm','20 Kg',NULL,'5 ani',@Color,@Brand,NULL,@Category);

INSERT INTO ProductsPhotos([ProductID],[PhotoID]) VALUES(@Product,@Photo);
INSERT INTO ProductsMaterials([ProductID],[MaterialID]) VALUES(@Product,@Material);

SET @Photo= NEWID()
INSERT INTO Photos ([PhotoID],[Image]) 
SELECT @Photo,BulkColumn 
FROM Openrowset( Bulk 'C:\Users\Adriana\source\repos\imagini\pat.jpg', Single_Blob) AS ProductImage

SET @Color = NEWID()
INSERT INTO Colors ([ColorID],[Name]) VALUES (@Color,'Gri'); 
SET @Material = NEWID()
INSERT INTO Materials([MaterialID],[Name]) VALUES (@Material,'lether');
SET @Brand = NEWID()
INSERT INTO Brands ([BrandID],[Name]) VALUES (@Brand,'Karup');
SET @Product = NEWID()
INSERT INTO Products([ProductID],[Name],[Price],[Stock],[Dimensions],[Weight],[Description],[Guarantee],[ColorID],[BrandID],[PromotionID],[CategoryID]) 
VALUES (@Product,'Pat Piele Inspiration','450RON',30,'lungime 209 cm/latime 98 cm/inaltime 78 cm','22.6 Kg',NULL,'5 ani',@Color,@Brand,NULL,@Category);

INSERT INTO ProductsPhotos([ProductID],[PhotoID]) VALUES(@Product,@Photo);
INSERT INTO ProductsMaterials([ProductID],[MaterialID]) VALUES(@Product,@Material);





INSERT INTO Colors ([ColorID],[Name]) VALUES (NEWID(),'Verde');
INSERT INTO Colors ([ColorID],[Name]) VALUES (NEWID(),'Albastru');
INSERT INTO Colors ([ColorID],[Name]) VALUES (NEWID(),'Galben');
INSERT INTO Colors ([ColorID],[Name]) VALUES (NEWID(),'Maro');
INSERT INTO Colors ([ColorID],[Name]) VALUES (NEWID(),'Portocaliu');
INSERT INTO Colors ([ColorID],[Name]) VALUES (NEWID(),'Crem');
INSERT INTO Colors ([ColorID],[Name]) VALUES (NEWID(),'Visiniu');
INSERT INTO Colors ([ColorID],[Name]) VALUES (NEWID(),'Alb');




INSERT INTO Materials([MaterialID],[Name]) VALUES (NEWID(),'glass');
INSERT INTO Materials([MaterialID],[Name]) VALUES (NEWID(),'plywood');
INSERT INTO Materials([MaterialID],[Name]) VALUES (NEWID(),'plastic');
INSERT INTO Materials([MaterialID],[Name]) VALUES (NEWID(),'papier mache');
INSERT INTO Materials([MaterialID],[Name]) VALUES (NEWID(),'painted steel');
INSERT INTO Materials([MaterialID],[Name]) VALUES (NEWID(),'polyester');


INSERT INTO SubCategories([SubCategoryID],[Name]) VALUES (NEWID(),'Furniture');
INSERT INTO SubCategories([SubCategoryID],[Name]) VALUES (NEWID(),'Mirrors');
INSERT INTO SubCategories([SubCategoryID],[Name]) VALUES (NEWID(),'Tables');
INSERT INTO SubCategories([SubCategoryID],[Name]) VALUES (NEWID(),'Seats');
INSERT INTO SubCategories([SubCategoryID],[Name]) VALUES (NEWID(),'Paintings');
INSERT INTO SubCategories([SubCategoryID],[Name]) VALUES (NEWID(),'Rugs');
INSERT INTO SubCategories([SubCategoryID],[Name]) VALUES (NEWID(),'Curtains');
INSERT INTO SubCategories([SubCategoryID],[Name]) VALUES (NEWID(),'Closets');
INSERT INTO SubCategories([SubCategoryID],[Name]) VALUES (NEWID(),'Lamps');
INSERT INTO SubCategories([SubCategoryID],[Name]) VALUES (NEWID(),'Spots');
INSERT INTO SubCategories([SubCategoryID],[Name]) VALUES (NEWID(),'Floor lamps');


INSERT INTO Brands ([BrandID],[Name]) VALUES (NEWID(),'Ixia');
INSERT INTO Brands ([BrandID],[Name]) VALUES (NEWID(),'CIMC');
INSERT INTO Brands ([BrandID],[Name]) VALUES (NEWID(),'Pierre Cardin');
INSERT INTO Brands ([BrandID],[Name]) VALUES (NEWID(),'Victoria');
INSERT INTO Brands ([BrandID],[Name]) VALUES (NEWID(),'Santiago');
INSERT INTO Brands ([BrandID],[Name]) VALUES (NEWID(),'Tomasucci');
INSERT INTO Brands ([BrandID],[Name]) VALUES (NEWID(),'Axentia');
INSERT INTO Brands ([BrandID],[Name]) VALUES (NEWID(),' B Home');



INSERT INTO Categories ([CategoryID],[Name]) VALUES (NEWID(),'Library');
INSERT INTO Categories ([CategoryID],[Name]) VALUES (NEWID(),'Livingroom');
INSERT INTO Categories ([CategoryID],[Name]) VALUES (NEWID(),'Bathroom');
INSERT INTO Categories ([CategoryID],[Name]) VALUES (NEWID(),'Kitchen');
INSERT INTO Categories ([CategoryID],[Name]) VALUES (NEWID(),'Office');
INSERT INTO Categories ([CategoryID],[Name]) VALUES (NEWID(),'Dressing');






DECLARE @Country uniqueidentifier  
SET @Country = NEWID()
INSERT INTO Countries([CountryID],[Name]) VALUES (@Country,'Romania');

DECLARE @County uniqueidentifier  
SET @County = NEWID()
INSERT INTO Counties ([CountyID],[Name],[CountryID]) VALUES (@County,'Cluj',@Country);

DECLARE @City uniqueidentifier  
SET @City = NEWID()
INSERT INTO Cities([CityID],[Name],[CountyID]) VALUES (@City,'Cluj Napoca',@County);

DECLARE @Role uniqueidentifier  
SET @Role = NEWID()
INSERT INTO Roles([RoleID],[Description]) VALUES (@Role,'Administrator');

DECLARE @Account uniqueidentifier  
SET @Account= NEWID()
INSERT INTO Accounts([AccountID],[EmailAddress],[Password],[Photo],[RoleID]) 
	VALUES (@Account,'adrianatrifon@yahoo.com','test1',NULL,@Role);

DECLARE @Person uniqueidentifier  
SET @Person= NEWID()
INSERT INTO Persons([PersonID],[FirstName],[LastName],[Street],[Home/BlockNumber],[BirthDay],[CNP],[PhoneNumber],[CityID],[AccountID]) 
VALUES (@Person,'Adriana','Trifon','Str. Izvorului', 'Nr.49','1995-08-28','2950828011150','0747060741',@City,@Account);


SET @County = NEWID()
INSERT INTO Counties ([CountyID],[Name],[CountryID]) VALUES (@County,'Alba',@Country);
SET @City = NEWID()
INSERT INTO Cities([CityID],[Name],[CountyID]) VALUES (@City,'Alba Iulia',@County);
DECLARE @Role1 uniqueidentifier
SET @Role1 = NEWID()
INSERT INTO Roles([RoleID],[Description]) VALUES (@Role1,'User');
SET @Account= NEWID()
INSERT INTO Accounts([AccountID],[EmailAddress],[Password],[Photo],[RoleID]) 
	VALUES (@Account,'alexserban@yahoo.com','test2',NULL,@Role1);
SET @Person= NEWID()
INSERT INTO Persons([PersonID],[FirstName],[LastName],[Street],[Home/BlockNumber],[BirthDay],[CNP],[PhoneNumber],[CityID],[AccountID]) 
VALUES (@Person,'Alexandru','Serban','Str. Bucium', 'Nr.28','1992-01-26','1930126011151','0728883043',@City,@Account);

SET @Person=NEWID();
SET @Account= NEWID()
INSERT INTO Accounts([AccountID],[EmailAddress],[Password],[Photo],[RoleID]) 
	VALUES (@Account,'ana1234n@yahoo.com','test3',NULL,@Role1);
INSERT INTO Persons([PersonID],[FirstName],[LastName],[Street],[Home/BlockNumber],[BirthDay],[CNP],[PhoneNumber],[CityID],[AccountID]) 
VALUES (@Person,'Ana Maria','Lazar','Str. Lalelelor', 'Bl. P1A','1994-04-14','2940414011152','0745591021',@City,@Account);

SET @Person=NEWID();
SET @Account= NEWID()
INSERT INTO Accounts([AccountID],[EmailAddress],[Password],[Photo],[RoleID]) 
	VALUES (@Account,'miha_28@yahoo.com','test4',NULL,@Role1);
INSERT INTO Persons([PersonID],[FirstName],[LastName],[Street],[Home/BlockNumber],[BirthDay],[CNP],[PhoneNumber],[CityID],[AccountID]) 
VALUES (@Person,'Mihaela','Varga','Str. Macesului', 'Bl. 3B','1994-07-14','2940714001150','0745391021',@City,@Account);

DECLARE @Pay uniqueidentifier  
SET @Pay= NEWID()
INSERT INTO PaymentOptions([PaymentOptionID],[Name]) VALUES (@Pay,'On delivery');

DECLARE @Pay1 uniqueidentifier  
SET @Pay1= NEWID()
INSERT INTO PaymentOptions([PaymentOptionID],[Name]) VALUES (@Pay1,'Credit Card');

DECLARE @OrderedProduct uniqueidentifier  
SET @OrderedProduct= NEWID()
INSERT INTO OrderedProducts([OrderedProductID],[ProductID],[Quantity]) 
	VALUES (@OrderedProduct,@Product,1);
DECLARE @Order uniqueidentifier  
SET @Order= NEWID()
INSERT INTO Orders([OrderID],[Date],[OrderedProductID],[PersonID],[PaymentOptionID]) 
	VALUES (@Order,'2017-11-05',@OrderedProduct,@Person,@Pay);

INSERT INTO Counties ([CountyID],[Name],[CountryID]) VALUES (NEWID(),'Constanta',@Country);
INSERT INTO Counties ([CountyID],[Name],[CountryID]) VALUES (NEWID(),'Satu Mare',@Country);
INSERT INTO Counties ([CountyID],[Name],[CountryID]) VALUES (NEWID(),'Maramures',@Country);
INSERT INTO Counties ([CountyID],[Name],[CountryID]) VALUES (NEWID(),'Calarasi',@Country);
INSERT INTO Counties ([CountyID],[Name],[CountryID]) VALUES (NEWID(),'Arad',@Country);
INSERT INTO Counties ([CountyID],[Name],[CountryID]) VALUES (NEWID(),'Bacau',@Country);
INSERT INTO Counties ([CountyID],[Name],[CountryID]) VALUES (NEWID(),'Bihor',@Country);

INSERT INTO Countries([CountryID],[Name]) VALUES (NEWID(),'Italy');
INSERT INTO Countries([CountryID],[Name]) VALUES (NEWID(),'Spain');
INSERT INTO Countries([CountryID],[Name]) VALUES (NEWID(),'Hungary');
INSERT INTO Countries([CountryID],[Name]) VALUES (NEWID(),'Bulgaria');
INSERT INTO Countries([CountryID],[Name]) VALUES (NEWID(),'Denmark');
INSERT INTO Countries([CountryID],[Name]) VALUES (NEWID(),'Germany');

INSERT INTO Promotions([PromotionID],[Name],[Valability],[Description]) 
	VALUES (NEWID(),'Home Decorations for Christmas','48 hours','xghcfhjkfhgf');


SELECT 
	[AccountID],
	[EmailAddress],
	[Password],
	[Photo],
	[RoleID]
FROM Accounts	

SELECT 
	[RoleID],
	[Description]
FROM Roles	

SELECT 
	[ProductID],
	[Name],
	[Price],
	[Stock],
	[Dimensions],
	[Weight],
	[Guarantee]	
FROM Products	

SELECT 
	[PersonID],
	[FirstName],
	[LastName],
	[Street],
	[Home/BlockNumber],
	[CNP],
	[BirthDay],
	[PhoneNumber]
FROM Persons	