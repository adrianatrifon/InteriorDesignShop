CREATE DATABASE InteriorDesignShopDB
GO
USE InteriorDesignShopDB
GO

CREATE TABLE [Colors](
	[ColorID] uniqueidentifier NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	
	CONSTRAINT [PK_Colors] PRIMARY KEY ([ColorID])	
	);
GO

CREATE TABLE [Materials](
	[MaterialID] uniqueidentifier NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	
	CONSTRAINT [PK_Materials] PRIMARY KEY ([MaterialID])	
	)
GO

CREATE TABLE [Brands](
	[BrandID] uniqueidentifier NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	
	CONSTRAINT [PK_Brands] PRIMARY KEY ([BrandID])	
	);
GO

CREATE TABLE [Countries](
	[CountryID] uniqueidentifier NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	
	CONSTRAINT [PK_Countries] PRIMARY KEY ([CountryID])	
	);
GO

CREATE TABLE [Counties](
	[CountyID] uniqueidentifier NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	[CountryID] uniqueidentifier NOT NULL
	
	CONSTRAINT [PK_Counties] PRIMARY KEY ([CountyID])
	CONSTRAINT [FK_Counties_Countries] FOREIGN KEY ([CountryID]) 
		REFERENCES Countries([CountryID]) ON DELETE CASCADE	
	);
GO

CREATE TABLE [Cities](
	[CityID] uniqueidentifier NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	[CountyID] uniqueidentifier NOT NULL
	
	CONSTRAINT [PK_Cities] PRIMARY KEY ([CityID]),	
	CONSTRAINT [FK_Cities_Counties] FOREIGN KEY ([CountyID]) 
		REFERENCES Counties([CountyID]) ON DELETE CASCADE	
	);
GO

CREATE TABLE [Categories](
	[CategoryID] uniqueidentifier NOT NULL,
	[ParentCategoryID] uniqueidentifier,
	[Name] nvarchar(50) NOT NULL,	

	CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryID]),	
	CONSTRAINT [FK_Categories_Categories] FOREIGN KEY ([ParentCategoryID])	
		REFERENCES [Categories]([CategoryID])
	);

CREATE TABLE [Promotions](
	[PromotionID] uniqueidentifier NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	[Valability] nvarchar(50) NOT NULL,
	[Description] nvarchar(MAX),

	CONSTRAINT [PK_Promotions] PRIMARY KEY ([PromotionID])		
	);
GO

CREATE TABLE [Photos](
	[PhotoID] uniqueidentifier NOT NULL,
	[Image] varbinary(MAX) NOT NULL,	

	CONSTRAINT [PK_Photos] PRIMARY KEY ([PhotoID])		
	);
GO

CREATE TABLE [Currencies](
	[CurrencyID] uniqueidentifier NOT NULL,
	[Currency] nvarchar(30) NOT NULL

	CONSTRAINT [PK_Currencies] PRIMARY KEY ([CurrencyID])
);
GO

CREATE TABLE [Products](
	[ProductID] uniqueidentifier NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	[Price] decimal(19,6) NOT NULL,
	[CurrencyID] uniqueidentifier NOT NULL,
	[Stock] int,
	[Dimensions] nvarchar(50) NOT NULL,
	[Weight] nvarchar(50) NOT NULL,
	[Guarantee] nvarchar(50) NOT NULL,	
	[Description] nvarchar(max),	
	[BrandID] uniqueidentifier NOT NULL,
	[CategoryID] uniqueidentifier NOT NULL,
	
	CONSTRAINT [PK_Products] PRIMARY KEY ([ProductID]),			
	CONSTRAINT [FK_Products_Brands] FOREIGN KEY ([BrandID])
		REFERENCES [Brands]([BrandID]) ON DELETE CASCADE	,		
	CONSTRAINT [FK_Products_Categories] FOREIGN KEY ([CategoryID])
		REFERENCES [Categories]([CategoryID]) ON DELETE CASCADE	,
	CONSTRAINT [FK_Products_Currencies] FOREIGN KEY ([CurrencyID])
		REFERENCES [Currencies]([CurrencyID]) ON DELETE CASCADE	
	);
GO

CREATE TABLE [ProductsColors] (
	[ProductID] uniqueidentifier NOT NULL,
	[ColorID] uniqueidentifier NOT NULL

	CONSTRAINT [PK_ProductsColors] PRIMARY KEY ([ProductID],[ColorID])
	CONSTRAINT [FK_ProductsColors_Products] FOREIGN KEY ([ProductID])
		REFERENCES [Products]([ProductID]) ON DELETE CASCADE,
	CONSTRAINT [FK_ProductsColors_Colors] FOREIGN KEY ([ColorID])
		REFERENCES [Colors]([ColorID]) ON DELETE CASCADE
	);
GO

CREATE TABLE [ProductsMaterials](
	[ProductID] uniqueidentifier NOT NULL,
	[MaterialID] uniqueidentifier NOT NULL

	
	CONSTRAINT [PK_ProductsMaterials] PRIMARY KEY ([ProductID],[MaterialID]),	
	CONSTRAINT [FK_ProductsMaterials_Products] FOREIGN KEY ([ProductID])
		REFERENCES [Products]([ProductID]) ON DELETE CASCADE	,
	CONSTRAINT [FK_ProductsMaterials_Materials] FOREIGN KEY ([MaterialID])
		REFERENCES [Materials]([MaterialID]) ON DELETE CASCADE	
);
GO

CREATE TABLE [ProductsPhotos](
	[PhotoID] uniqueidentifier NOT NULL,
	[ProductID] uniqueidentifier NOT NULL,

	CONSTRAINT [PK_ProductsPhotos] PRIMARY KEY ([PhotoID],[ProductID]),
	CONSTRAINT [FK_ProductsPhotos_Photos] FOREIGN KEY ([PhotoID])
		REFERENCES [Photos]([PhotoID]) ON DELETE CASCADE	,
	CONSTRAINT [FK_ProductsPhotos_Products] FOREIGN KEY ([ProductID])
		REFERENCES [Products]([ProductID]) ON DELETE CASCADE	
);
GO

CREATE TABLE [ProductsPromotions](
	[ProductID] uniqueidentifier NOT NULL,
	[PromotionID] uniqueidentifier NOT NULL

	CONSTRAINT [Pk_ProductsPromotions] PRIMARY KEY([ProductID],[PromotionID]),
	CONSTRAINT [FK_ProductsPromotions_Products] FOREIGN KEY([ProductID])
		REFERENCES [Products]([ProductID]) ON DELETE CASCADE	,
	CONSTRAINT [FK_ProductsPromotions_Promotions] FOREIGN KEY([PromotionID])
		REFERENCES [Promotions]([PromotionID]) ON DELETE CASCADE	

	);
GO

CREATE TABLE [PaymentOptions](
	[PaymentOptionID] uniqueidentifier NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	
	CONSTRAINT [PK_PaymentOptions] PRIMARY KEY ([PaymentOptionID])	
	);
GO

CREATE TABLE [Roles](
	[RoleID] uniqueidentifier NOT NULL,
	[Description] nvarchar(50) NOT NULL,
	 
	CONSTRAINT [PK_Roles] PRIMARY KEY ([RoleID])	
	);
GO

CREATE TABLE [Accounts](
	[AccountID] uniqueidentifier NOT NULL,
	[EmailAddress] nvarchar(50) NOT NULL,
	[Password] nvarchar(50) NOT NULL,
	[RoleID] uniqueidentifier NOT NULL,
	[PhotoID] uniqueidentifier
	 
	CONSTRAINT [PK_Accounts] PRIMARY KEY ([AccountID]),
	CONSTRAINT [FK_Accounts_Roles] FOREIGN KEY ([RoleID])
		REFERENCES [Roles]([RoleID]) ON DELETE CASCADE	,
	CONSTRAINT [FK_Accounts_Photos] FOREIGN KEY ([PhotoID])
		REFERENCES [Photos]([PhotoID]) ON DELETE CASCADE	
	);
GO

CREATE TABLE [Persons](
	[PersonID] uniqueidentifier NOT NULL,
	[FirstName] nvarchar(50) NOT NULL,
	[LastName] nvarchar(50) NOT NULL,
	[Street] nvarchar(150) NOT NULL,
	[Number] nvarchar(30) NOT NULL,	
	[BirthDay] date,	
	[PhoneNumber] nvarchar(50) NOT NULL,
	[CityID] uniqueidentifier NOT NULL,	
	[AccountID] uniqueidentifier NOT NULL,
	
	CONSTRAINT [PK_Persons] PRIMARY KEY ([PersonID]),
	CONSTRAINT [FK_Persons_Cities] FOREIGN KEY ([CityID])
		REFERENCES [Cities]([CityID]) ON DELETE CASCADE	,	
	CONSTRAINT [FK_Persons_Accounts] FOREIGN KEY ([AccountID])
		REFERENCES [Accounts]([AccountID]) ON DELETE CASCADE	
	);
GO
CREATE TABLE [Orders](
	[OrderID] uniqueidentifier NOT NULL,
	[Date] datetime NOT NULL,
	[DeliveryAddress] nvarchar(100)  NOT NULL,
	[PersonID] uniqueidentifier NOT NULL,
	[PaymentOptionID] uniqueidentifier NOT NULL,
	 
	CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderID]),	
	CONSTRAINT [FK_Orders_Persons] FOREIGN KEY ([PersonID])
		REFERENCES [Persons]([PersonID]) ON DELETE CASCADE	,	
	CONSTRAINT [FK_Orders_PaymentOptions] FOREIGN KEY ([PaymentOptionID])
		REFERENCES [PaymentOptions]([PaymentOptionID]) ON DELETE CASCADE		
	);
GO

CREATE TABLE [OrdersProducts](
	[OrderID] uniqueidentifier NOT NULL,	
	[ProductID] uniqueidentifier NOT NULL,
	[Quantity] int NOT NULL
	 
	CONSTRAINT [PK_OrderedProducts] PRIMARY KEY ([OrderID],[ProductID]),
	CONSTRAINT [FK_OrdersProducts_Products] FOREIGN KEY ([ProductID])
		REFERENCES [Products]([ProductID]) ON DELETE CASCADE,
	CONSTRAINT [FK_OrdersProducts_Orders] FOREIGN KEY ([OrderID])
		REFERENCES [Orders]([OrderID]) ON DELETE CASCADE		
	);
GO	



-- CREATE PROCEDURES

CREATE PROCEDURE dbo.Colors_Create
(
	@ColorID uniqueidentifier,
	@ColorName nvarchar(50)
)
AS
BEGIN

	INSERT INTO dbo.Colors
	(
		ColorID,
		Name
	)
	VALUES
	(
		@ColorID,
		@ColorName
	)
		
END
GO

CREATE PROCEDURE dbo.Brands_Create
(
	@BrandID  uniqueidentifier,
	@BrandName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.Brands
	(
		BrandID,
		Name
	)
	VALUES
	(
		@BrandID,
		@BrandName
	)
	
END
GO


CREATE PROCEDURE dbo.Materials_Create
(
	@MaterialID uniqueidentifier,
	@MaterialName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.Materials
	(
		MaterialID,
		Name
	)
	VALUES
	(
		@MaterialID,
		@MaterialName
	)
		
END
GO

CREATE PROCEDURE dbo.Countries_Create
(
	@CountryID uniqueidentifier,
	@CountryName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON
	
	INSERT INTO dbo.Countries
	(
		CountryID,
		Name
	)
	VALUES
	(
		@CountryID,
		@CountryName
	)
		
END
GO


CREATE PROCEDURE dbo.Counties_Create
(
	@CountyID uniqueidentifier,
	@CountyName nvarchar(50),
	@CountryID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.Counties
	(
		CountyID,
		Name,
		CountryID
	)
	VALUES
	(
		@CountyID,
		@CountyName,
		@CountryID
	)
		
END
GO


CREATE PROCEDURE dbo.Cities_Create
(
	@CityID uniqueidentifier,
	@CityName nvarchar(50),
	@CountyID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.Cities
	(
		CityID,
		Name,
		CountyID
	)
	VALUES
	(
		@CityID,
		@CityName,
		@CountyID
	)
	
END
GO

CREATE PROCEDURE dbo.Currencies_Create
(
	@CurrencyID uniqueidentifier,
	@CurrencyName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON
	
	INSERT INTO dbo.Currencies
	(
		CurrencyID,
		Currency			
	)
	VALUES
	(
		@CurrencyID,
		@CurrencyName
	)
		
END
GO

CREATE PROCEDURE dbo.Categories_Create
(
	@CategoryID uniqueidentifier,
	@ParentCategory uniqueidentifier,
	@CategoryName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON
	
	INSERT INTO dbo.Categories
	(
		CategoryID,
		ParentCategoryID,
		Name			
	)
	VALUES
	(
		@CategoryID,
		@ParentCategory,
		@CategoryName
	)		
END
GO

CREATE PROCEDURE dbo.Roles_Create
(
	@RoleID uniqueidentifier,
	@Role nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON
	
	INSERT INTO dbo.Roles
	(
		RoleID,
		Description		
	)
	VALUES
	(
		@RoleID,
		@Role
	)
	
END
GO

CREATE PROCEDURE dbo.Promotions_Create
(
	@PromotionID uniqueidentifier,
	@PromotionName nvarchar(50),
	@Valability nvarchar(50),
	@Description nvarchar(max)
)
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.Promotions
	(
		PromotionID,
		Name,
		Valability,
		Description	
	)
	VALUES
	(
		@PromotionID,
		@PromotionName,
		@Valability,
		@Description
	)
	
END
GO

CREATE PROCEDURE dbo.PaymentOptions_Create
(
	@PaymentOptionID uniqueidentifier,
	@PaymentOptionName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON
		
	INSERT INTO dbo.PaymentOptions
	(
		PaymentOptionID,
		Name
	)
	VALUES
	(
		@PaymentOptionID,
		@PaymentOptionName
	)				
END
GO


CREATE PROCEDURE dbo.Photos_Create
(
	@PhotoID uniqueidentifier,
	@Photo varbinary(max)
)
AS
BEGIN
	SET NOCOUNT ON
	
	INSERT INTO dbo.Photos
	(
		PhotoID,
		Image
	)
	VALUES
	(
		@PhotoID,
		@Photo
	)
END
GO

CREATE PROCEDURE dbo.ProductsColors_Create
(
	@ProductID uniqueidentifier,
	@ColorID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	INSERT INTO dbo.ProductsColors
	(				
		ProductID,
		ColorID
	)
	VALUES
	(
		@ProductID,
		@ColorID
	)	
END
GO


CREATE PROCEDURE dbo.ProductsPhotos_Create
(
	@PhotoID uniqueidentifier,
	@ProductID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	INSERT INTO dbo.ProductsPhotos
	(
		PhotoID,
		ProductID
	)
	VALUES
	(
		@PhotoID,
		@ProductID
	)		
END
GO


CREATE PROCEDURE dbo.ProductsMaterials_Create
(
	@ProductID uniqueidentifier,
	@MaterialID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	INSERT INTO dbo.ProductsMaterials
	(				
		ProductID,
		MaterialID
	)
	VALUES
	(
		@ProductID,
		@MaterialID
	)	
END
GO


CREATE PROCEDURE dbo.ProductsPromotions_Create
(
	@ProductID uniqueidentifier,
	@PromotionID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON	

	INSERT INTO dbo.ProductsPromotions
	(				
		ProductID,
		PromotionID
	)
	VALUES
	(
		@ProductID,
		@PromotionID
	)
END
GO

CREATE PROCEDURE dbo.OrdersProducts_Create
(
	@OrderID uniqueidentifier,
	@ProductID uniqueidentifier,
	@Quantity  int
)
AS
BEGIN
	SET NOCOUNT ON
	
	INSERT INTO dbo.OrdersProducts
	(
		OrderID,
		ProductID,
		Quantity
	)
	VALUES
	(
		@OrderID,
		@ProductID,
		@Quantity
	)
END
GO

CREATE PROCEDURE dbo.Orders_Create
(
	@OrderID uniqueidentifier,
	@Date datetime,
	@DeliveryAddress nvarchar(100),
	@PersonID uniqueidentifier,
	@PaymentOptionID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	INSERT INTO dbo.Orders
	(
		OrderID,
		Date,
		DeliveryAddress,
		PersonID,
		PaymentOptionID
	)
	VALUES
	(
		@OrderID,
		@Date,
		@DeliveryAddress,
		@PersonID,
		@PaymentOptionID
	)
END
GO

CREATE PROCEDURE dbo.Persons_Create
(
	@PersonID uniqueidentifier,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Street nvarchar(150),
	@Number nvarchar(30),
	@BirthDay date,
	@PhoneNumber nvarchar(50),
	@CityID uniqueidentifier,
	@AccountID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	INSERT INTO dbo.Persons
	(				
		PersonID,
		FirstName,
		LastName,
		Street,
		Number,
		BirthDay,
		PhoneNumber,
		CityID,
		AccountID
	)
	VALUES
	(
		@PersonID,
		@FirstName,
		@LastName,
		@Street,
		@Number,
		@BirthDay,
		@PhoneNumber,
		@CityID,
		@AccountID
	)
END
GO

CREATE PROCEDURE dbo.Products_Create
(
	@ProductID uniqueidentifier,
	@ProductName nvarchar(50),
	@Price decimal(19,6),
	@CurrencyID uniqueidentifier,
	@Stock int,
	@Dimensions nvarchar(50),
	@Weight nvarchar(50),
	@Guarantee nvarchar(50),
	@Description nvarchar(max),
	@ColorID uniqueidentifier,
	@BrandID uniqueidentifier,
	@CategoryID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	INSERT INTO dbo.Products
	(				
		ProductID,
		Name,
		Price,
		CurrencyID,
		Stock,
		Dimensions,
		Weight,
		Guarantee,
		Description,	
		BrandID,
		CategoryID
	)
	VALUES
	(
		@ProductID,
		@ProductName,
		@Price,
		@CurrencyID,
		@Stock,
		@Dimensions,
		@Weight,
		@Guarantee,
		@Description,	
		@BrandID,
		@CategoryID
	)	
END
GO


CREATE PROCEDURE dbo.Accounts_Create
(
	@AccountID uniqueidentifier,
	@EmailAddress nvarchar(50),
	@Password nvarchar(50),
	@RoleID uniqueidentifier,
	@PhotoID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	INSERT INTO dbo.Accounts
	(
		AccountID,
		EmailAddress,
		Password,
		RoleID,
		PhotoID
	)
	VALUES
	(
		@AccountID,
		@EmailAddress,
		@Password,
		@RoleID,
		@PhotoID
	)
END
GO

-- UPDATE PROCEDURES 

CREATE PROCEDURE dbo.Colors_Update
(
	@ColorID uniqueidentifier,
	@ColorName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON	
	
	UPDATE dbo.Colors
	SET Name=@ColorName
	WHERE ColorID=@ColorID
			
END
GO

CREATE PROCEDURE dbo.Brands_Update
(
	@BrandID uniqueidentifier,
	@BrandName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON
		
	UPDATE dbo.Brands
	SET Name=@BrandName
	WHERE BrandID=@BrandID

END
GO


CREATE PROCEDURE dbo.Materials_Update
(
	@MaterialID uniqueidentifier,
	@MaterialName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON
	
	UPDATE dbo.Materials
	SET	Name=@MaterialName
	WHERE MaterialID=@MaterialID		
	
END
GO


CREATE PROCEDURE dbo.Countries_Update
(
	@CountryID uniqueidentifier,
	@CountryName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON

	UPDATE dbo.Countries
	SET	 Name=@CountryName
	WHERE CountryID = @CountryID

END
GO


CREATE PROCEDURE dbo.Counties_Update
(
	@CountyID uniqueidentifier,
	@CountyName nvarchar(50),
	@CountryID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	UPDATE dbo.Counties
	SET 
		Name=@CountyName,
		CountryID=@CountryID
	WHERE CountyID=@CountyID

END
GO


CREATE PROCEDURE dbo.Cities_Update
(
	@CityID uniqueidentifier,
	@CityName nvarchar(50),
	@CountyID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	UPDATE dbo.Cities
	SET
		Name=@CityName,
		CountyID=@CountyID
	WHERE CityID=@CityID
			
END
GO


CREATE PROCEDURE dbo.Currencies_Update
(
	@CurrencyID uniqueidentifier,
	@CurrencyName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON	
		
	UPDATE dbo.Currencies
	SET 	Currency=@CurrencyName			
	WHERE CurrencyID=@CurrencyID
	
END
GO


CREATE PROCEDURE dbo.Categories_Update
(
	@CategoryID uniqueidentifier,
	@ParentCategory uniqueidentifier,
	@CategoryName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON
	
	UPDATE dbo.Categories
	SET
		ParentCategoryID=@ParentCategory,
		Name=@CategoryName			
	WHERE CategoryID=@CategoryID
				
END
GO


CREATE PROCEDURE dbo.Roles_Update
(
	@RoleID uniqueidentifier,
	@Role nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON
	
	UPDATE dbo.Roles
	SET Description=@Role		
	WHERE RoleID=@RoleID
			
END
GO


CREATE PROCEDURE dbo.Promotions_Update
(
	@PromotionID uniqueidentifier,
	@PromotionName nvarchar(50),
	@Valability nvarchar(50),
	@Description nvarchar(max)
)
AS
BEGIN
	SET NOCOUNT ON
	
	UPDATE dbo.Promotions
	SET
		Name=@PromotionName,
		Valability=@Valability,
		Description	=@Description
	WHERE PromotionID=@PromotionID
		
END
GO

CREATE PROCEDURE dbo.PaymentOptions_Update
(
	@PaymentOptionID uniqueidentifier,
	@PaymentOptionName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON

	UPDATE dbo.PaymentOptions
	SET 	Name=@PaymentOptionName
	WHERE PaymentOptionID=@PaymentOptionID
		
END
GO

CREATE PROCEDURE dbo.Photos_Update
(
	@PhotoID uniqueidentifier,
	@Photo varbinary(max)
)
AS
BEGIN
	SET NOCOUNT ON
	
	UPDATE dbo.Photos
	SET	Image=@Photo
	WHERE PhotoID=@PhotoID
		
END
GO

CREATE PROCEDURE dbo.OrdersProducts_Update
(
	@OrderID uniqueidentifier,
	@ProductID uniqueidentifier,
	@Quantity  int
)
AS
BEGIN
	SET NOCOUNT ON

	UPDATE dbo.OrdersProducts
	SET		
		Quantity=@Quantity
	WHERE OrderID=@OrderID AND ProductID=@ProductID
		
END
GO

CREATE PROCEDURE dbo.Orders_Update
(
	@OrderID uniqueidentifier,
	@Date datetime,
	@DeliveryAddress nvarchar(100),
	@PersonID uniqueidentifier,
	@PaymentOptionID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	UPDATE dbo.Orders
	SET
		Date=@Date,
		DeliveryAddress=@DeliveryAddress,
		PersonID=@PersonID,
		PaymentOptionID=@PaymentOptionID
	WHERE OrderID=@OrderID
			
END
GO

CREATE PROCEDURE dbo.Persons_Update
(
	@PersonID uniqueidentifier,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Street nvarchar(150),
	@Number nvarchar(30),
	@BirthDay date,
	@PhoneNumber nvarchar(50),
	@CityID uniqueidentifier,
	@AccountID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	UPDATE dbo.Persons
	SET
		FirstName=@FirstName,
		LastName=@LastName,
		Street=@Street,
		Number=@Number,
		BirthDay=@BirthDay,
		PhoneNumber=@PhoneNumber,
		CityID=@CityID,
		AccountID=@AccountID
	WHERE PersonID=@PersonID
				
END
GO

CREATE PROCEDURE dbo.Products_Update
(
	@ProductID uniqueidentifier,
	@ProductName nvarchar(50),
	@Price decimal(19,6),
	@CurrencyID uniqueidentifier,
	@Stock int,
	@Dimensions nvarchar(50),
	@Weight nvarchar(50),
	@Guarantee nvarchar(50),
	@Description nvarchar(max),
	@BrandID uniqueidentifier,
	@CategoryID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	UPDATE dbo.Products
	SET
		Name=@ProductName,
		Price=@Price,
		CurrencyID=@CurrencyID,
		Stock=@Stock,
		Dimensions=@Dimensions,
		Weight=@Weight,
		Guarantee=@Guarantee,
		Description=@Description,
		BrandID=@BrandID,
		CategoryID=@CategoryID
	WHERE ProductID=@ProductID
		
END
GO


CREATE PROCEDURE dbo.Accounts_Update
(
	@AccountID uniqueidentifier,
	@EmailAddress nvarchar(50),
	@Password nvarchar(50),
	@RoleID uniqueidentifier,
	@PhotoID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	UPDATE dbo.Accounts
	SET
		EmailAddress=@EmailAddress,
		Password=@Password,
		RoleID=@RoleID,
		PhotoID=@PhotoID
	WHERE AccountID=@AccountID
			
END
GO

-- DELETE PROCEDURES

CREATE PROCEDURE dbo.Colors_Delete
(
	@ColorID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON	
	
	DELETE 
	FROM dbo.Colors			
	WHERE ColorID=@ColorID			
	
END
GO


CREATE PROCEDURE dbo.Brands_Delete
(
	@BrandID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	DELETE 
	FROM dbo.Brands		
	WHERE BrandID=@BrandID	
		
END
GO


CREATE PROCEDURE dbo.Materials_Delete
(
	@MaterialID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	DELETE 
	FROM dbo.Materials			
	WHERE MaterialID=@MaterialID
	
END
GO

CREATE PROCEDURE dbo.Countries_Delete
(
	@CountryID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	DELETE 
	FROM dbo.Countries			
	WHERE CountryID=@CountryID	

END
GO

CREATE PROCEDURE dbo.Counties_Delete
(
	@CountyID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
			
	DELETE 
	FROM dbo.Counties
	WHERE CountyID=@CountyID

END
GO


CREATE PROCEDURE dbo.Cities_Delete
(
	@CityID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	DELETE
	FROM dbo.Cities
	WHERE CityID=@CityID
		
END
GO


CREATE PROCEDURE dbo.Currencies_Delete
(
	@CurrencyID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON	

	DELETE 
	FROM dbo.Currencies		
	WHERE CurrencyID=@CurrencyID	

END
GO

CREATE PROCEDURE dbo.Categories_Delete
(
	@CategoryID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	DELETE 
	FROM dbo.Categories
	WHERE CategoryID=@CategoryID

END
GO


CREATE PROCEDURE dbo.Roles_Delete
(
	@RoleID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	DELETE
	FROM dbo.Roles
	WHERE RoleID=@RoleID

END
GO


CREATE PROCEDURE dbo.Promotions_Delete
(
	@PromotionID uniqueidentifier	
)
AS
BEGIN
	SET NOCOUNT ON

	DELETE
	FROM dbo.Promotions
	WHERE PromotionID=@PromotionID

END
GO

CREATE PROCEDURE dbo.PaymentOptions_Delete
(
	@PaymentOptionID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	DELETE
	FROM dbo.PaymentOptions
	WHERE PaymentOptionID=@PaymentOptionID

END
GO


CREATE PROCEDURE dbo.Photos_Delete
(
	@PhotoID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	DELETE
	FROM dbo.Photos
	WHERE PhotoID=@PhotoID

END
GO

CREATE PROCEDURE dbo.OrdersProducts_Delete
(
	@OrderID uniqueidentifier,
	@ProductID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	DELETE
	FROM dbo.OrdersProducts
	WHERE OrderID=@OrderID AND ProductID=@ProductID

END
GO

CREATE PROCEDURE dbo.Orders_Delete
(
	@OrderID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	DELETE
	FROM dbo.Orders
	WHERE OrderID=@OrderID

END
GO

CREATE PROCEDURE dbo.Persons_Delete
(
	@PersonID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	DELETE 
	FROM dbo.Persons
	WHERE PersonID=@PersonID

END
GO

CREATE PROCEDURE dbo.Products_Delete
(
	@ProductID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	DELETE
	FROM dbo.Products
	WHERE ProductID=@ProductID

END
GO


CREATE PROCEDURE dbo.Accounts_Delete
(
	@AccountID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	DELETE 
	FROM dbo.Accounts
	WHERE AccountID=@AccountID

END
GO

CREATE PROCEDURE dbo.ProductsColors_Delete
(
	@ProductID uniqueidentifier,
	@ColorID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	DELETE
	FROM dbo.ProductsColors
	WHERE ColorID=@ColorID AND ProductID=@ProductID

END
GO

CREATE PROCEDURE dbo.ProductsPhotos_Delete
(
	@PhotoID uniqueidentifier,
	@ProductID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	DELETE
	FROM dbo.ProductsPhotos
	WHERE PhotoID=@PhotoID AND ProductID=@ProductID

END
GO


CREATE PROCEDURE dbo.ProductsMaterials_Delete
(
	@ProductID uniqueidentifier,
	@MaterialID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	DELETE
	FROM dbo.ProductsMaterials
	WHERE MaterialID=@MaterialID AND ProductID=@ProductID

END
GO



CREATE PROCEDURE dbo.ProductsPromotions_Delete
(
	@ProductID uniqueidentifier,
	@PromotionID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	DELETE
	FROM dbo.ProductsPromotions
	WHERE PromotionID=@PromotionID AND ProductID=@ProductID

END
GO

--  GetByID PROCEDURES

CREATE PROCEDURE dbo.Accounts_GetByID
(
	@AccountID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON 

	SELECT 
		AccountID,
		EmailAddress,
		Password,
		RoleID,
		PhotoID
	FROM dbo.Accounts
	WHERE AccountID=@AccountID
END
GO

CREATE PROCEDURE dbo.Brands_GetByID
(
	@BrandID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	SELECT	
		BrandID,
		Name
	FROM dbo.Brands
	WHERE BrandID=@BrandID	
		
END
GO

CREATE PROCEDURE dbo.Colors_GetByID
(
	@ColorID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	SELECT	
		ColorID,
		Name
	FROM dbo.Colors
	WHERE ColorID=@ColorID
		
END
GO


CREATE PROCEDURE dbo.Materials_GetByID
(
	@MaterialID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT	
		MaterialID,
		Name
	FROM dbo.Materials			
	WHERE MaterialID=@MaterialID
	
END
GO

CREATE PROCEDURE dbo.Countries_GetByID
(
	@CountryID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	SELECT	
		CountryID,
		Name
	FROM dbo.Countries			
	WHERE CountryID=@CountryID	

END
GO

CREATE PROCEDURE dbo.Counties_GetByID
(
	@CountyID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	SELECT	
		CountyID,
		Name,
		CountryID
	FROM dbo.Counties			
	WHERE CountyID=@CountyID	

END
GO

CREATE PROCEDURE dbo.CountryCounties_GetByID
(
	@CountryID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
		c.CountyID,
		c.Name,
		c.CountryID	 
	FROM dbo.Counties c
		LEFT JOIN dbo.Countries co ON c.CountryID=co.CountryID
	WHERE co.CountryID=@CountryID
END
GO

CREATE PROCEDURE dbo.Cities_GetByID
(
	@CityID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
		CityID,
		Name
	FROM dbo.Cities
	WHERE CityID=@CityID
		
END
GO

CREATE PROCEDURE dbo.CountyCities_GetByID
(
	@CountyID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
		c.CityID,
		c.Name,
		c.CountyID	 
	FROM dbo.Cities c
		LEFT JOIN dbo.Counties co ON c.CountyID=co.CountyID
	WHERE co.CountyID=@CountyID
END
GO

CREATE PROCEDURE dbo.Currencies_GetByID
(
	@CurrencyID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON	

	SELECT
		CurrencyID,
		Currency
	FROM dbo.Currencies		
	WHERE CurrencyID=@CurrencyID	

END
GO

CREATE PROCEDURE dbo.Categories_GetByID
(
	@CategoryID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	SELECT
		CategoryID,
		ParentCategoryID,
		Name
	FROM dbo.Categories
	WHERE CategoryID=@CategoryID

END
GO

CREATE PROCEDURE dbo.CategorySubCategories_GetByID
(
	@CategoryID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	SELECT 
		c1.CategoryID,
		c1.Name,
		c1.ParentCategoryID
	FROM dbo.Categories c
		LEFT JOIN dbo.Categories c1 ON c.CategoryID=c1.ParentCategoryID
		INNER JOIN dbo.Categories c2 ON c1.ParentCategoryID=c2.CategoryID
	WHERE c.CategoryID=@CategoryID

END
GO


CREATE PROCEDURE dbo.Roles_GetByID

(
	@RoleID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	SELECT
		RoleID,
		Description
	FROM dbo.Roles
	WHERE RoleID=@RoleID

END
GO


CREATE PROCEDURE dbo.Promotions_GetByID
(
	@PromotionID uniqueidentifier	
)
AS
BEGIN
	SET NOCOUNT ON

	SELECT
		PromotionID,
		Name,
		Valability,
		Description
	FROM dbo.Promotions
	WHERE PromotionID=@PromotionID

END
GO

CREATE PROCEDURE dbo.PaymentOptions_GetByID
(
	@PaymentOptionID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	SELECT
		PaymentOptionID,
		Name
	FROM dbo.PaymentOptions
	WHERE PaymentOptionID=@PaymentOptionID

END
GO


CREATE PROCEDURE dbo.Photos_GetByID
(
	@PhotoID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
		PhotoID,
		Image
	FROM dbo.Photos
	WHERE PhotoID=@PhotoID

END
GO

CREATE PROCEDURE dbo.OrderProducts_GetByID
(
	@OrderID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	SELECT 
		p.ProductID,
		p.Name,		
		p.Price,
		p.CurrencyID,
		p.Stock,
		p.Dimensions,
		p.Weight,
		p.Guarantee,
		p.Description,
		p.BrandID,
		p.CategoryID
	FROM dbo.Products p
		INNER JOIN dbo.OrdersProducts op ON p.ProductID=op.ProductID
		INNER JOIN dbo.Orders o ON op.OrderID=o.OrderID
	WHERE op.OrderID=@OrderID
END
GO

CREATE PROCEDURE dbo.ProductColors_GetByID
(
	@ProductID uniqueidentifier
)
AS
BEGIN
	SELECT
		c.ColorID,
		c.Name
	FROM dbo. Colors c
		INNER JOIN dbo.ProductsColors pc ON c.ColorID=pc.ColorID
		INNER JOIN dbo.Products p ON pc.ProductID=p.ProductID
	WHERE p.ProductID=@ProductID
END
GO

CREATE PROCEDURE dbo.ProductMaterials_GetByID
(
	@ProductID uniqueidentifier
)
AS
BEGIN
	SELECT
		m.MaterialID,
		m.Name
	FROM dbo. Materials m
		INNER JOIN dbo.ProductsMaterials pm ON m.MaterialID=pm.MaterialID
		INNER JOIN dbo.Products p ON pm.ProductID=p.ProductID
	WHERE p.ProductID=@ProductID
END
GO

CREATE PROCEDURE dbo.Orders_GetByID
(
	@OrderID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	SELECT 
		OrderID,
		Date,
		DeliveryAddress,
		PersonID,
		PaymentOptionID
	FROM dbo.Orders
	WHERE OrderID=@OrderID

END
GO

CREATE PROCEDURE dbo.Persons_GetByID
(
	@PersonID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
		PersonID,
		FirstName,
		LastName,
		Street,
		Number,
		BirthDay,
		PhoneNumber,
		CityID,
		AccountID
	FROM dbo.Persons
	WHERE PersonID=@PersonID	

END
GO

CREATE PROCEDURE dbo.Products_GetByID
(
	@ProductID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
		ProductID,
		Name,
		Price,
		CurrencyID,
		Stock,
		Dimensions,
		Weight,
		Guarantee,
		Description,	
		BrandID,
		CategoryID
	FROM dbo.Products
	WHERE ProductID=@ProductID

END
GO

CREATE VIEW [dbo.GetUsers]
AS 
	SELECT 
		p.PersonID,	
		p.FirstName,
		p.LastName,	
		p.Street,
		p.Number,
		p.BirthDay,
		p.PhoneNumber,
		p.CityID,
		p.AccountID		
	FROM dbo.Persons p
		RIGHT JOIN dbo.Accounts a ON p.AccountID=a.AccountID
		RIGHT JOIN dbo.Roles r ON a.RoleID=r.RoleID
	WHERE r.Description='User'
GO

-- ReadALL VIEWS

CREATE VIEW [dbo.Accounts_ReadAll]
AS
	SELECT
		AccountID,
		EmailAddress,
		Password,
		RoleID,
		PhotoID
	FROM dbo.Accounts		
GO

CREATE VIEW [dbo.Brands_ReadAll]
AS
	SELECT
		BrandID,
		Name
	FROM dbo.Brands		
GO

CREATE VIEW [dbo.Categories_ReadAll]
AS
	SELECT
		CategoryID,
		ParentCategoryID,
		Name
	FROM dbo.Categories		
GO

CREATE VIEW [dbo.Cities_ReadAll]
AS
	SELECT
		CityID,
		Name,
		CountyID
	FROM dbo.Cities		
GO

CREATE VIEW [dbo.Counties_ReadAll]
AS
	SELECT
		CountyID,
		Name,
		CountryID
	FROM dbo.Counties		
GO

CREATE VIEW [dbo.Countries_ReadAll]
AS
	SELECT
		CountryID,
		Name
	FROM dbo.Countries		
GO

CREATE VIEW [dbo.Colors_ReadAll]
AS
	SELECT
		ColorID,
		Name
	FROM dbo.Colors		
GO

CREATE VIEW [dbo.Currencies_ReadAll]
AS
	SELECT
		CurrencyID,
		Currency
	FROM dbo.Currencies	
GO

CREATE VIEW [dbo.Materials_ReadAll]
AS
	SELECT
		MaterialID,
		Name
	FROM dbo.Materials	
GO

CREATE VIEW [dbo.Orders_ReadAll]
AS
	SELECT
		OrderID,
		Date,
		DeliveryAddress,
		PersonID,
		PaymentOptionID
	FROM dbo.Orders		
GO

CREATE VIEW [dbo.OrdersProducts_ReadAll]
AS
	SELECT
		OrderID,
		ProductID
	FROM dbo.OrdersProducts		
GO

CREATE VIEW [dbo.PaymentOptions_ReadAll]
AS
	SELECT
		PaymentOptionID,
		Name
	FROM dbo.PaymentOptions	
GO

CREATE VIEW [dbo.Persons_ReadAll]
AS
	SELECT
		PersonID,
		FirstName,
		LastName,
		Street,
		Number,
		BirthDay,
		PhoneNumber,
		CityID,
		AccountID
	FROM dbo.Persons	
GO

CREATE VIEW [dbo.Photos_ReadAll]
AS
	SELECT
		PhotoID,
		Image
	FROM dbo.Photos	
GO

CREATE VIEW [dbo.Products_ReadAll]
AS
	SELECT
		ProductID,
		Name,
		Price,
		CurrencyID,
		Stock,
		Dimensions,
		Weight,
		Guarantee,
		Description,	
		BrandID,
		CategoryID
	FROM dbo.Products	
GO

CREATE VIEW [dbo.ProductsColors_ReadAll]
AS
	SELECT
		ProductID,
		ColorID
	FROM dbo.ProductsColors	
GO

CREATE VIEW [dbo.ProductsMaterials_ReadAll]
AS
	SELECT
		ProductID,
		MaterialID
	FROM dbo.ProductsMaterials
GO

CREATE VIEW [dbo.ProductsPhotos_ReadAll]
AS
	SELECT
		ProductID,
		PhotoID
	FROM dbo.ProductsPhotos	
GO

CREATE VIEW [dbo.ProductsPromotions_ReadAll]
AS
	SELECT
		ProductID,
		PromotionID
	FROM dbo.ProductsPromotions	
GO

CREATE VIEW [dbo.Promotions_ReadAll]
AS
	SELECT
		PromotionID,
		Name,
		Valability,
		Description
	FROM dbo.Promotions	
GO

CREATE VIEW [dbo.Roles_ReadAll]
AS
	SELECT
		RoleID,
		Description
	FROM dbo.Roles
GO