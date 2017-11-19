CREATE DATABASE InteriorDesignShopDB
GO
USE InteriorDesignShopDB

CREATE TABLE [Colors](
	[ColorID] uniqueidentifier NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	
	CONSTRAINT [PK_Colors] PRIMARY KEY ([ColorID])	
	);

CREATE TABLE [Materials](
	[MaterialID] uniqueidentifier NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	
	CONSTRAINT [PK_Materials] PRIMARY KEY ([MaterialID])	
	)

CREATE TABLE [Brands](
	[BrandID] uniqueidentifier NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	
	CONSTRAINT [PK_Brands] PRIMARY KEY ([BrandID])	
	);

CREATE TABLE [Countries](
	[CountryID] uniqueidentifier NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	
	CONSTRAINT [PK_Countries] PRIMARY KEY ([CountryID])	
	);

CREATE TABLE [Counties](
	[CountyID] uniqueidentifier NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	[CountryID] uniqueidentifier NOT NULL
	
	CONSTRAINT [PK_Counties] PRIMARY KEY ([CountyID])
	CONSTRAINT [FK_Counties_Countries] FOREIGN KEY ([CountryID]) 
		REFERENCES Countries([CountryID])	
	);

CREATE TABLE [Cities](
	[CityID] uniqueidentifier NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	[CountyID] uniqueidentifier NOT NULL
	
	CONSTRAINT [PK_Cities] PRIMARY KEY ([CityID]),	
	CONSTRAINT [FK_Cities_Counties] FOREIGN KEY ([CountyID]) 
		REFERENCES Counties([CountyID])
	);


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

CREATE TABLE [Photos](
	[PhotoID] uniqueidentifier NOT NULL,
	[Image] varbinary(MAX) NOT NULL,	

	CONSTRAINT [PK_Photos] PRIMARY KEY ([PhotoID])		
	);

CREATE TABLE [Currencies](
	[CurrencyID] uniqueidentifier NOT NULL,
	[Currency] nvarchar(30) NOT NULL

	CONSTRAINT [PK_Currencies] PRIMARY KEY ([CurrencyID])
);

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
	[ColorID] uniqueidentifier NOT NULL,	
	[BrandID] uniqueidentifier NOT NULL,
	[CategoryID] uniqueidentifier NOT NULL,
	
	CONSTRAINT [PK_Products] PRIMARY KEY ([ProductID]),	
	CONSTRAINT [FK_Products_Colors] FOREIGN KEY ([ColorID])
		REFERENCES [Colors]([ColorID]),	
	CONSTRAINT [FK_Products_Brands] FOREIGN KEY ([BrandID])
		REFERENCES [Brands]([BrandID]),		
	CONSTRAINT [FK_Products_Categories] FOREIGN KEY ([CategoryID])
		REFERENCES [Categories]([CategoryID]),
	CONSTRAINT [FK_Products_Currencies] FOREIGN KEY ([CurrencyID])
		REFERENCES [Currencies]([CurrencyID])
	);

CREATE TABLE [ProductsMaterials](
	[ProductID] uniqueidentifier NOT NULL,
	[MaterialID] uniqueidentifier NOT NULL

	
	CONSTRAINT [PK_ProductsMaterials] PRIMARY KEY ([ProductID],[MaterialID]),	
	CONSTRAINT [FK_ProductsMaterials_Products] FOREIGN KEY ([ProductID])
		REFERENCES [Products]([ProductID]),
	CONSTRAINT [FK_ProductsMaterials_Materials] FOREIGN KEY ([MaterialID])
		REFERENCES [Materials]([MaterialID])
);
CREATE TABLE [ProductsPhotos](
	[PhotoID] uniqueidentifier NOT NULL,
	[ProductID] uniqueidentifier NOT NULL,

	CONSTRAINT [PK_ProductsPhotos] PRIMARY KEY ([PhotoID],[ProductID]),
	CONSTRAINT [FK_ProductsPhotos_Photos] FOREIGN KEY ([PhotoID])
		REFERENCES [Photos]([PhotoID]),
	CONSTRAINT [FK_ProductsPhotos_Products] FOREIGN KEY ([ProductID])
		REFERENCES [Products]([ProductID])
);

CREATE TABLE [ProductsPromotions](
	[ProductID] uniqueidentifier NOT NULL,
	[PromotionID] uniqueidentifier NOT NULL

	CONSTRAINT [Pk_ProductsPromotions] PRIMARY KEY([ProductID],[PromotionID]),
	CONSTRAINT [FK_ProductsPromotions_Products] FOREIGN KEY([ProductID])
		REFERENCES [Products]([ProductID]),
	CONSTRAINT [FK_ProductsPromotions_Promotions] FOREIGN KEY([PromotionID])
		REFERENCES [Promotions]([PromotionID])

	);

CREATE TABLE [PaymentOptions](
	[PaymentOptionID] uniqueidentifier NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	
	CONSTRAINT [PK_PaymentOptions] PRIMARY KEY ([PaymentOptionID])	
	);


CREATE TABLE [Roles](
	[RoleID] uniqueidentifier NOT NULL,
	[Description] nvarchar(50) NOT NULL,
	 
	CONSTRAINT [PK_Roles] PRIMARY KEY ([RoleID])	
	);

CREATE TABLE [Accounts](
	[AccountID] uniqueidentifier NOT NULL,
	[EmailAddress] nvarchar(50) NOT NULL,
	[Password] nvarchar(50) NOT NULL,
	[RoleID] uniqueidentifier NOT NULL,
	[PhotoID] uniqueidentifier
	 
	CONSTRAINT [PK_Accounts] PRIMARY KEY ([AccountID]),
	CONSTRAINT [FK_Accounts_Roles] FOREIGN KEY ([RoleID])
		REFERENCES [Roles]([RoleID]),
	CONSTRAINT [FK_Accounts_Photos] FOREIGN KEY ([PhotoID])
		REFERENCES [Photos]([PhotoID])
	);


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
		REFERENCES [Cities]([CityID]),	
	CONSTRAINT [FK_Persons_Accounts] FOREIGN KEY ([AccountID])
		REFERENCES [Accounts]([AccountID]),
	);

CREATE TABLE [OrderedProducts](
	[OrderedProductID] uniqueidentifier NOT NULL,	
	[ProductID] uniqueidentifier NOT NULL,
	[Quantity] int NOT NULL
	 
	CONSTRAINT [PK_OrderedProducts] PRIMARY KEY ([OrderedProductID]),
	CONSTRAINT [FK_OrderedProducts_Products] FOREIGN KEY ([ProductID])
		REFERENCES [Products]([ProductID]),	
	);
	 
CREATE TABLE [Orders](
	[OrderID] uniqueidentifier NOT NULL,
	[Date] datetime NOT NULL,
	[DeliveryAddress] nvarchar(100)  NOT NULL,
	[OrderedProductID] uniqueidentifier NOT NULL,
	[PersonID] uniqueidentifier NOT NULL,
	[PaymentOptionID] uniqueidentifier NOT NULL,
	 
	CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderID]),
	CONSTRAINT [FK_Orders_OrderedProducts] FOREIGN KEY ([OrderedProductID])
		REFERENCES [OrderedProducts]([OrderedProductID]),	
	CONSTRAINT [FK_Orders_Persons] FOREIGN KEY ([PersonID])
		REFERENCES [Persons]([PersonID]),	
	CONSTRAINT [FK_Orders_PaymentOptions] FOREIGN KEY ([PaymentOptionID])
		REFERENCES [PaymentOptions]([PaymentOptionID])	
	);











