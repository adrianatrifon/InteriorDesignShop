USE InteriorDesignShopDB

CREATE PROCEDURE dbo.Colors_Create
(
	@ColorName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @ColorID uniqueidentifier
	SET @ColorID=NEWID()

	DECLARE @exists int
	SET @exists=0

	if(NOT EXISTS(select top 1 Name from dbo.Colors where Name = @ColorName))		
		begin

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
		end
END
GO

EXECUTE dbo.Colors_Create @ColorName='Rosu'

CREATE PROCEDURE dbo.Brands_Create
(
	@BrandName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @BrandID uniqueidentifier
	SET @BrandID=NEWID()

	if(NOT EXISTS(SELECT TOP 1 Name FROM dbo.Brands WHERE Name = @BrandName))		
		begin

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
		end
END
GO



EXECUTE dbo.Brands_Create @BrandName='Apolena'

SELECT*
FROM Brands


CREATE PROCEDURE dbo.Materials_Create
(
	@MaterialName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @MaterialID uniqueidentifier
	SET @MaterialID=NEWID()

	if(NOT EXISTS(SELECT TOP 1 Name FROM dbo. Materials WHERE Name = @MaterialName ))		
		begin

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
		end
END
GO


EXECUTE dbo.Materials_Create @MaterialName='cotton'

CREATE PROCEDURE dbo.Countries_Create
(
	@CountryName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @CountryID uniqueidentifier
	SET @CountryID=NEWID()

	if(NOT EXISTS(SELECT TOP 1 Name FROM dbo. Materials WHERE Name = @CountryName ))		
		begin

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
		end
END
GO

EXECUTE dbo.Countries_Create @CountryName='China'

CREATE PROCEDURE dbo.Counties_Create
(
	@CountyName nvarchar(50),
	@CountryID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @CountyID uniqueidentifier
	SET @CountyID=NEWID()

	if(EXISTS(SELECT TOP 1 CountryID FROM dbo. Countries WHERE CountryID=@CountryID ))
		begin
			if(NOT EXISTS(SELECT TOP 1 Name FROM dbo.Counties WHERE Name=@CountyName))
				begin
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
				end
		end
END
GO

EXECUTE dbo.Counties_Create @CountyName='Targoviste',@CountryID='5DBB6539-915A-4F34-B2DE-3CCA5C35DCC0'

CREATE PROCEDURE dbo.Cities_Create
(
	@CityName nvarchar(50),
	@CountyID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @CityID uniqueidentifier
	SET @CityID=NEWID()

	if(EXISTS(SELECT TOP 1 CountyID FROM dbo. Counties WHERE CountyID=@CountyID ))
		begin
			if(NOT EXISTS(SELECT TOP 1 Name FROM dbo.Cities WHERE Name=@CityName))
				begin
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
				end
		end
END
GO

EXECUTE dbo.Cities_Create @CityName='Constanta',@CountyID='301CA482-B41B-4345-9BBA-4A2DC46C6C52'

CREATE PROCEDURE dbo.Currencies_Create
(
	@CurrencyName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @CurrencyID uniqueidentifier
	SET @CurrencyID=NEWID()

	if(NOT EXISTS(SELECT TOP 1 Currency FROM dbo.Currencies WHERE Currency=@CurrencyName))
		begin
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
		end		
END
GO

EXECUTE dbo.Currencies_Create @CurrencyName='USD'

CREATE PROCEDURE dbo.Categories_Create
(
	@ParentCategory uniqueidentifier,
	@CategoryName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @CategoryID uniqueidentifier
	SET @CategoryID=NEWID()
	if(((@ParentCategory =NULL)AND(NOT EXISTS(SELECT TOP 1 Name FROM  dbo.Categories WHERE Name=@CategoryName)))
	OR (EXISTS(SELECT TOP 1 @CategoryID FROM dbo.Categories WHERE CategoryID =@ParentCategory))
	AND(NOT EXISTS(SELECT TOP 1 Name FROM dbo.Categories WHERE Name=@CategoryName)))
		begin
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
		end		
END
GO

EXECUTE dbo.Categories_Create @ParentCategory='DED8ACB1-4DA7-4E57-BFA3-18235C7B15B1',@CategoryName='Furniture'

CREATE PROCEDURE dbo.Roles_Create
(
	@Role nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @RoleID uniqueidentifier
	SET @RoleID=NEWID()
	if(NOT EXISTS(SELECT TOP 1 Description FROM dbo.Roles WHERE Description=@Role))
		begin
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
		end		
END
GO

EXECUTE dbo.Roles_Create @Role='User'

CREATE PROCEDURE dbo.Promotions_Create
(
	@PromotionName nvarchar(50),
	@Valability nvarchar(50),
	@Description nvarchar(max)
)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @PromotionID uniqueidentifier
	SET @PromotionID=NEWID()
	if(NOT EXISTS(SELECT TOP 1 Name FROM dbo.Promotions WHERE Name=@PromotionName))
		begin
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
		end		
END
GO

CREATE PROCEDURE dbo.PaymentOptions_Create
(
	@PaymentOptionName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @PaymentOptionID uniqueidentifier
	SET @PaymentOptionID=NEWID()
	if(NOT EXISTS(SELECT TOP 1 Name FROM dbo.PaymentOptions WHERE Name=@PaymentOptionName))
		begin
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
		end		
END
GO


-- aici nu sunt sigura ca e ok procedura pentru Photos

CREATE PROCEDURE dbo.Photos_Create
(
	@Photo varbinary(max)
)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @PhotoID uniqueidentifier
	SET @PhotoID=NEWID()
	if(NOT EXISTS(SELECT TOP 1 Image FROM dbo.Photos WHERE Image=@Photo))
		begin
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
		end		
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
	if((EXISTS(SELECT TOP 1 PhotoID FROM dbo.Photos WHERE PhotoID=@PhotoID))AND(EXISTS(SELECT TOP 1 ProductID FROM dbo.Products  WHERE ProductID=@ProductID))
		AND(NOT EXISTS(SELECT TOP 1 PhotoID,ProductID FROM dbo.ProductsPhotos WHERE (PhotoID=@PhotoID AND ProductID=@ProductID))))	
		begin
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
		end		
END
GO

EXECUTE dbo.ProductsPhotos_Create @PhotoID='79C82DE9-AAB4-4034-810F-F888FFF55143',@ProductID='F42EEB2E-938C-42A3-AE9F-72F3E43A56FC'

CREATE PROCEDURE dbo.ProductsMaterials_Create
(
	@ProductID uniqueidentifier,
	@MaterialID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	if((EXISTS(SELECT TOP 1 p.ProductID, m.MaterialID FROM dbo.Products AS p, dbo.Materials AS m WHERE(p.ProductID=@ProductID AND m.MaterialID=@MaterialID)))
		AND(NOT EXISTS(SELECT TOP 1 ProductID, MaterialID FROM dbo.ProductsMaterials WHERE (ProductID=@ProductID AND MaterialID=@MaterialID))))
		begin
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
		end		
END
GO

EXECUTE dbo.ProductsMaterials_Create @ProductID='F42EEB2E-938C-42A3-AE9F-72F3E43A56FC',@MaterialID='662DB898-59BA-4E04-8156-B2A6DC2C273B'

CREATE PROCEDURE dbo.ProductsPromotions_Create
(
	@ProductID uniqueidentifier,
	@PromotionID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	if((EXISTS(SELECT TOP 1 p.ProductID, prom.PromotionID FROM dbo.Products AS p, dbo.Promotions AS prom WHERE(p.ProductID=@ProductID AND prom.PromotionID=@PromotionID)))
		AND(NOT EXISTS(SELECT TOP 1 ProductID, PromotionID FROM dbo.ProductsPromotions WHERE (ProductID=@ProductID AND PromotionID=@PromotionID))))
		begin
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
		end		
END
GO

CREATE PROCEDURE dbo.OrderedProducts_Create
(
	@ProductID uniqueidentifier,
	@Quantity  int
)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @OrderedProductID uniqueidentifier
	SET @OrderedProductID=NEWID()
	if(EXISTS(SELECT TOP 1 ProductID FROM dbo.Products WHERE ProductID=@ProductID ))
		begin
			INSERT INTO dbo.OrderedProducts
			(
				OrderedProductID,
				ProductID,
				Quantity
			)
			VALUES
			(
				@OrderedProductID,
				@ProductID,
				@Quantity
			)
		end		
END
GO

CREATE PROCEDURE dbo.Orders_Create
(
	@Date datetime,
	@DeliveryAddress nvarchar(100),
	@OrderedProductID uniqueidentifier,
	@PersonID uniqueidentifier,
	@PaymentOptionID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @OrderID uniqueidentifier
	SET @OrderID=NEWID()
	if(EXISTS((SELECT TOP 1 o.OrderedProductID,p.PersonID, pa.PaymentOptionID FROM dbo.OrderedProducts AS o, dbo.Persons AS p, dbo.PaymentOptions AS pa
		 WHERE (o.OrderedProductID=@OrderedProductID AND p.PersonID=@PersonID AND pa.PaymentOptionID=@PaymentOptionID )))
		 AND(NOT EXISTS(SELECT TOP 1 OrderID FROM dbo.Orders WHERE (Date=@Date AND DeliveryAddress=@DeliveryAddress AND OrderedProductID=@OrderedProductID 
		 AND PersonID=@PersonID AND PaymentOptionID=@PaymentOptionID))))
		begin
			INSERT INTO dbo.Orders
			(
				OrderID,
				Date,
				DeliveryAddress,
				OrderedProductID,
				PersonID,
				PaymentOptionID
			)
			VALUES
			(
				@OrderID,
				@Date,
				@DeliveryAddress,
				@OrderedProductID,
				@PersonID,
				@PaymentOptionID
			)
		end		
END
GO

CREATE PROCEDURE dbo.Persons_Create
(
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
	DECLARE @PersonID uniqueidentifier
	SET @PersonID=NEWID()
	if(EXISTS(SELECT TOP 1 c.CityID, a.AccountID FROM dbo.Cities AS c, dbo.Accounts AS a WHERE (c.CityID=@CityID AND a.AccountID=@AccountID))
		AND(NOT EXISTS(SELECT TOP 1 PersonID FROM dbo.Persons WHERE (FirstName=@FirstName AND LastName=@LastName AND Street=@Street
		AND Number=@Number AND BirthDay=@BirthDay AND PhoneNumber=@PhoneNumber AND CityID=@CityID AND AccountID=@AccountID))))
		begin
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
		end		
END
GO

CREATE PROCEDURE dbo.Products_Create
(
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
	DECLARE @ProductID uniqueidentifier
	SET @ProductID=NEWID()
	if(EXISTS(SELECT TOP 1 c.CurrencyID, co.ColorID, b.BrandID, ca.CategoryID FROM dbo.Currencies AS c, dbo.Colors AS co, dbo.Brands AS b, dbo.Categories AS ca
		 WHERE (c.CurrencyID=@CurrencyID AND co.ColorID=@ColorID AND b.BrandID=@BrandID AND ca.CategoryID=@CategoryID))
		AND(NOT EXISTS(SELECT TOP 1 ProductID FROM dbo.Products WHERE (Name=@ProductName AND Price=@Price AND CurrencyID=@CurrencyID
		AND Stock=@Stock AND Dimensions=@Dimensions AND Weight=@Weight AND Guarantee=@Guarantee AND Description=@Description
		AND ColorID=@ColorID AND BrandID=@BrandID AND CategoryID=@CategoryID))))
		begin
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
				ColorID,
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
				@ColorID,
				@BrandID,
				@CategoryID
			)
		end		
END
GO


CREATE PROCEDURE dbo.Accounts_Create
(
	@EmailAddress nvarchar(50),
	@Password nvarchar(50),
	@RoleID uniqueidentifier,
	@PhotoID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @AccountID uniqueidentifier
	SET @AccountID=NEWID()
	if(EXISTS(SELECT TOP 1 r.RoleID, p.PhotoID FROM dbo.Roles AS r, dbo.Photos AS p WHERE (r.RoleID=@RoleID AND p.PhotoID=@PhotoID))
		AND(NOT EXISTS(SELECT TOP 1 AccountID FROM dbo.Accounts WHERE (EmailAddress=@EmailAddress AND Password=@Password 
		AND RoleID=@RoleID AND PhotoID=@PhotoID))))
		begin
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
		end		
END
GO