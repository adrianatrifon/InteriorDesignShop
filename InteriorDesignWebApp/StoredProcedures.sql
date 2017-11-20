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



--EXECUTE dbo.Brands_Create @BrandName='Apolena'




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


--EXECUTE dbo.Materials_Create @MaterialName='cotton'

CREATE PROCEDURE dbo.Countries_Create
(
	@CountryName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @CountryID uniqueidentifier
	SET @CountryID=NEWID()

	if(NOT EXISTS(SELECT TOP 1 Name FROM dbo. Countries WHERE Name = @CountryName ))		
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


--EXECUTE dbo.Countries_Create @CountryName='China'

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

--EXECUTE dbo.Counties_Create @CountyName='Targoviste',@CountryID='5DBB6539-915A-4F34-B2DE-3CCA5C35DCC0'

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

--EXECUTE dbo.Cities_Create @CityName='Constanta',@CountyID='301CA482-B41B-4345-9BBA-4A2DC46C6C52'

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

--EXECUTE dbo.Currencies_Create @CurrencyName='USD'

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
	if((EXISTS(SELECT TOP 1 CategoryID FROM dbo.Categories WHERE CategoryID =@ParentCategory))
		AND(NOT EXISTS(SELECT TOP 1 Name FROM dbo.Categories WHERE (Name=@CategoryName AND ParentCategoryID=@ParentCategory))))
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
	else if (NOT EXISTS(SELECT TOP 1 Name FROM dbo.Categories WHERE (Name=@CategoryName AND ParentCategoryID=@ParentCategory)))
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
--EXECUTE dbo.Categories_Create @ParentCategory=NULL,@CategoryName='asfhgdfjke'

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

--EXECUTE dbo.Roles_Create @Role='User'

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

--EXECUTE dbo.ProductsPhotos_Create @PhotoID='79C82DE9-AAB4-4034-810F-F888FFF55143',@ProductID='F42EEB2E-938C-42A3-AE9F-72F3E43A56FC'

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

--EXECUTE dbo.ProductsMaterials_Create @ProductID='F42EEB2E-938C-42A3-AE9F-72F3E43A56FC',@MaterialID='662DB898-59BA-4E04-8156-B2A6DC2C273B'

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

------UPDATE PROCEDURES

CREATE PROCEDURE dbo.Colors_Update
(
	@ColorID uniqueidentifier,
	@ColorName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON	
	if((EXISTS(SELECT TOP 1 ColorID FROM dbo.Colors WHERE ColorID=@ColorID))
		AND(NOT EXISTS(select top 1 Name from dbo.Colors where Name = @ColorName)))		
		begin
			UPDATE dbo.Colors
			SET
				Name=@ColorName
			WHERE ColorID=@ColorID
			
		end
END
GO

--EXECUTE dbo.Colors_Update @ColorID='8A0B0685-93A0-479A-8F69-1F9E2E53C3FD',@ColorName='Alb'

CREATE PROCEDURE dbo.Brands_Update
(
	@BrandID uniqueidentifier,
	@BrandName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON

	if((EXISTS(SELECT TOP 1 BrandID FROM dbo.Brands WHERE BrandID=@BrandID))
		AND(NOT EXISTS(SELECT TOP 1 Name FROM dbo.Brands WHERE Name = @BrandName)))	
		begin
			UPDATE dbo.Brands
			SET
				Name=@BrandName
			WHERE BrandID=@BrandID
		end
END
GO



--EXECUTE dbo.Brands_Update @BrandID='40C85AFD-18B1-4338-B52C-0C0771C7CF47',@BrandName='Apolena'


CREATE PROCEDURE dbo.Materials_Update
(
	@MaterialID uniqueidentifier,
	@MaterialName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON
	if((EXISTS(SELECT TOP 1 MaterialID FROM dbo.Materials WHERE MaterialID=@MaterialID))
		AND(NOT EXISTS(SELECT TOP 1 Name FROM dbo. Materials WHERE Name = @MaterialName )))		
		begin
			UPDATE dbo.Materials
			SET
				Name=@MaterialName
			WHERE MaterialID=@MaterialID		
		end
END
GO


--EXECUTE dbo.Materials_Create @MaterialName='cotton'

CREATE PROCEDURE dbo.Countries_Update
(
	@CountryID uniqueidentifier,
	@CountryName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON

	if((EXISTS(SELECT TOP 1 Name FROM dbo. Countries WHERE CountryID = @CountryID ))
		AND(NOT EXISTS(SELECT TOP 1 Name FROM dbo. Countries WHERE Name = @CountryName )))		
		begin
			UPDATE dbo.Countries
			SET			
				Name=@CountryName
			WHERE CountryID = @CountryID
		end
END
GO


--EXECUTE dbo.Countries_Update @CountryID='8D4984A2-68E9-43DE-A767-13D503169B5A',@CountryName='Japan'

CREATE PROCEDURE dbo.Counties_Update
(
	@CountyID uniqueidentifier,
	@CountyName nvarchar(50),
	@CountryID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	if((EXISTS(SELECT TOP 1 CountyID FROM dbo.Counties WHERE CountyID=@CountyID))
		AND(EXISTS(SELECT TOP 1 CountryID FROM dbo. Countries WHERE CountryID=@CountryID ))
		AND(NOT EXISTS(SELECT TOP 1 Name FROM dbo.Counties WHERE (Name=@CountyName AND CountryID=@CountryID))))
				begin
					UPDATE dbo.Counties
					SET
						Name=@CountyName,
						CountryID=@CountryID
					WHERE CountyID=@CountyID
				end		
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
	if((EXISTS(SELECT TOP 1 CityID FROM dbo.Cities WHERE CityID=@CityID))
		AND(EXISTS(SELECT TOP 1 CountyID FROM dbo. Counties WHERE CountyID=@CountyID ))
		AND(NOT EXISTS(SELECT TOP 1 Name FROM dbo.Cities WHERE( Name=@CityName AND CountyID=@CountyID))))
				begin
					UPDATE dbo.Cities
					SET
						Name=@CityName,
						CountyID=@CountyID
					 WHERE CityID=@CityID
				end
END
GO

--EXECUTE dbo.Cities_Update @CityID='7818377A-D1AA-4EBD-849E-17516461640A',@CityName='Constanta',@CountyID='301CA482-B41B-4345-9BBA-4A2DC46C6C52'

CREATE PROCEDURE dbo.Currencies_Update
(
	@CurrencyID uniqueidentifier,
	@CurrencyName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON	

	if((EXISTS(SELECT TOP 1 CurrencyID FROM dbo.Currencies WHERE CurrencyID=@CurrencyID))
		AND(NOT EXISTS(SELECT TOP 1 Currency FROM dbo.Currencies WHERE Currency=@CurrencyName)))
		begin
			UPDATE dbo.Currencies
			SET
				Currency=@CurrencyName			
			WHERE CurrencyID=@CurrencyID
		end		
END
GO

--EXECUTE dbo.Currencies_Update @CurrencyID='270FEF53-DC3B-4FC5-B742-FDADAF7D51E4', @CurrencyName='USD'

CREATE PROCEDURE dbo.Categories_Update
(
	@CategoryID uniqueidentifier,
	@ParentCategory uniqueidentifier,
	@CategoryName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON

	if(EXISTS(SELECT TOP 1 CategoryID FROM dbo.Categories WHERE CategoryID=@CategoryID))
		begin		
			if ((EXISTS(SELECT TOP 1 CategoryID FROM dbo.Categories WHERE CategoryID =@ParentCategory))
				AND(NOT EXISTS(SELECT TOP 1 Name FROM dbo.Categories WHERE (Name=@CategoryName AND ParentCategoryID=@ParentCategory))))
				begin
	
					UPDATE dbo.Categories
					SET
						ParentCategoryID=@ParentCategory,
						Name=@CategoryName			
					WHERE CategoryID=@CategoryID
				end
			else if (NOT EXISTS(SELECT TOP 1 Name FROM dbo.Categories WHERE (Name=@CategoryName AND ParentCategoryID=@ParentCategory)))
				begin
	
					UPDATE dbo.Categories
					SET
						ParentCategoryID=@ParentCategory,
						Name=@CategoryName			
					WHERE CategoryID=@CategoryID
				end
		end	
END
GO

--EXECUTE dbo.Categories_Update @CategoryID='5E074690-98B8-4145-B469-91E2B33CA022', @ParentCategory='33667C99-D8E5-4BE8-978F-0F254506C085',@CategoryName='Furniture'

CREATE PROCEDURE dbo.Roles_Update
(
	@RoleID uniqueidentifier,
	@Role nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON
	if((EXISTS(SELECT TOP 1 RoleID FROM dbo.Roles WHERE RoleID=@RoleID))
		AND(NOT EXISTS(SELECT TOP 1 Description FROM dbo.Roles WHERE Description=@Role)))
		begin
			UPDATE dbo.Roles
			SET
				Description=@Role		
			WHERE RoleID=@RoleID
		end		
END
GO

--EXECUTE dbo.Roles_Update @RoleID='C6DDF734-F2F1-4FC1-BE41-152FF95BB34D',@Role='Administrator'

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
	if((EXISTS(SELECT TOP 1 PromotionID FROM dbo.Promotions WHERE PromotionID=@PromotionID))
		AND(NOT EXISTS(SELECT TOP 1 Name FROM dbo.Promotions WHERE Name=@PromotionName)))
		begin
			UPDATE dbo.Promotions
			SET
				Name=@PromotionName,
				Valability=@Valability,
				Description	=@Description
			WHERE PromotionID=@PromotionID
		end		
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

	if((EXISTS(SELECT TOP 1 PaymentOptionID FROM dbo.PaymentOptions WHERE PaymentOptionID=@PaymentOptionID))
		AND(NOT EXISTS(SELECT TOP 1 Name FROM dbo.PaymentOptions WHERE Name=@PaymentOptionName)))
		begin
			UPDATE dbo.PaymentOptions
			SET
				Name=@PaymentOptionName
			WHERE PaymentOptionID=@PaymentOptionID
		end		
END
GO


-- aici nu sunt sigura ca e ok procedura pentru Photos

CREATE PROCEDURE dbo.Photos_Update
(
	@PhotoID uniqueidentifier,
	@Photo varbinary(max)
)
AS
BEGIN
	SET NOCOUNT ON
	
	if((EXISTS(SELECT TOP 1 PhotoID FROM dbo.Photos WHERE PhotoID=@PhotoID))
		AND(NOT EXISTS(SELECT TOP 1 Image FROM dbo.Photos WHERE Image=@Photo)))
		begin
			UPDATE dbo.Photos
			SET
				Image=@Photo
			WHERE PhotoID=@PhotoID
		end		
END
GO

CREATE PROCEDURE dbo.OrderedProducts_Update
(
	@OrderedProductID uniqueidentifier,
	@ProductID uniqueidentifier,
	@Quantity  int
)
AS
BEGIN
	SET NOCOUNT ON

	if((EXISTS(SELECT TOP 1 OrderedProductID FROM dbo.OrderedProducts WHERE OrderedProductID=@OrderedProductID))
		AND(EXISTS(SELECT TOP 1 ProductID FROM dbo.Products WHERE ProductID=@ProductID )))
		begin
			UPDATE dbo.OrderedProducts
			SET
				ProductID=@ProductID,
				Quantity=@Quantity
			WHERE OrderedProductID=@OrderedProductID
		end		
END
GO

CREATE PROCEDURE dbo.Orders_Update
(
	@OrderID uniqueidentifier,
	@Date datetime,
	@DeliveryAddress nvarchar(100),
	@OrderedProductID uniqueidentifier,
	@PersonID uniqueidentifier,
	@PaymentOptionID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	if((EXISTS(SELECT TOP 1 OrderID FROM dbo.Orders WHERE OrderID=@OrderID))
		AND(EXISTS((SELECT TOP 1 o.OrderedProductID,p.PersonID, pa.PaymentOptionID FROM dbo.OrderedProducts AS o, dbo.Persons AS p, dbo.PaymentOptions AS pa
		 WHERE (o.OrderedProductID=@OrderedProductID AND p.PersonID=@PersonID AND pa.PaymentOptionID=@PaymentOptionID )))
		 AND(NOT EXISTS(SELECT TOP 1 OrderID FROM dbo.Orders WHERE (Date=@Date AND DeliveryAddress=@DeliveryAddress AND OrderedProductID=@OrderedProductID 
		 AND PersonID=@PersonID AND PaymentOptionID=@PaymentOptionID)))))
		begin
			UPDATE dbo.Orders
			SET
				Date=@Date,
				DeliveryAddress=@DeliveryAddress,
				OrderedProductID=@OrderedProductID,
				PersonID=@PersonID,
				PaymentOptionID=@PaymentOptionID
			WHERE OrderID=@OrderID
		end		
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
	
	if((EXISTS(SELECT TOP 1 PersonID FROM dbo.Persons WHERE PersonID=@PersonID))
		AND(EXISTS(SELECT TOP 1 c.CityID, a.AccountID FROM dbo.Cities AS c, dbo.Accounts AS a WHERE (c.CityID=@CityID AND a.AccountID=@AccountID))
		AND(NOT EXISTS(SELECT TOP 1 PersonID FROM dbo.Persons WHERE (FirstName=@FirstName AND LastName=@LastName AND Street=@Street
		AND Number=@Number AND BirthDay=@BirthDay AND PhoneNumber=@PhoneNumber AND CityID=@CityID AND AccountID=@AccountID)))))
		begin
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
		end		
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
	@ColorID uniqueidentifier,
	@BrandID uniqueidentifier,
	@CategoryID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	if((EXISTS(SELECT TOP 1 ProductID FROM dbo.Products WHERE ProductID=@ProductID))
		AND(EXISTS(SELECT TOP 1 c.CurrencyID, co.ColorID, b.BrandID, ca.CategoryID FROM dbo.Currencies AS c, dbo.Colors AS co, dbo.Brands AS b, dbo.Categories AS ca
		 WHERE (c.CurrencyID=@CurrencyID AND co.ColorID=@ColorID AND b.BrandID=@BrandID AND ca.CategoryID=@CategoryID))
		AND(NOT EXISTS(SELECT TOP 1 ProductID FROM dbo.Products WHERE (Name=@ProductName AND Price=@Price AND CurrencyID=@CurrencyID
		AND Stock=@Stock AND Dimensions=@Dimensions AND Weight=@Weight AND Guarantee=@Guarantee AND Description=@Description
		AND ColorID=@ColorID AND BrandID=@BrandID AND CategoryID=@CategoryID)))))
		begin
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
				ColorID=@ColorID,
				BrandID=@BrandID,
				CategoryID=@CategoryID
			WHERE ProductID=@ProductID
		end		
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
	if((EXISTS(SELECT TOP 1 AccountID FROM dbo.Accounts WHERE AccountID=@AccountID))
		AND(EXISTS(SELECT TOP 1 r.RoleID, p.PhotoID FROM dbo.Roles AS r, dbo.Photos AS p WHERE (r.RoleID=@RoleID AND p.PhotoID=@PhotoID))
		AND(NOT EXISTS(SELECT TOP 1 AccountID FROM dbo.Accounts WHERE (EmailAddress=@EmailAddress AND Password=@Password 
		AND RoleID=@RoleID AND PhotoID=@PhotoID)))))
		begin
			UPDATE dbo.Accounts
			SET
				EmailAddress=@EmailAddress,
				Password=@Password,
				RoleID=@RoleID,
				PhotoID=@PhotoID
			WHERE AccountID=@AccountID
		end		
END
GO

--STORED PROCEDURES FOR DELETING ROWS IN TABLES

CREATE PROCEDURE dbo.Colors_Delete
(
	@ColorID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON	
	if(EXISTS(SELECT TOP 1 ColorID FROM dbo.Colors WHERE ColorID=@ColorID))			
		begin
			DELETE 
			FROM dbo.Colors			
			WHERE ColorID=@ColorID			
		end
END
GO


CREATE PROCEDURE dbo.Brands_Delete
(
	@BrandID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	if(EXISTS(SELECT TOP 1 BrandID FROM dbo.Brands WHERE BrandID=@BrandID))	
		begin
			DELETE 
			FROM dbo.Brands		
			WHERE BrandID=@BrandID	
		end
END
GO


CREATE PROCEDURE dbo.Materials_Delete
(
	@MaterialID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	if(EXISTS(SELECT TOP 1 MaterialID FROM dbo.Materials WHERE MaterialID=@MaterialID))		
		begin
			DELETE 
			FROM dbo.Materials			
			WHERE MaterialID=@MaterialID
		end
END
GO

CREATE PROCEDURE dbo.Countries_Delete
(
	@CountryID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	if(EXISTS(SELECT TOP 1 Name FROM dbo. Countries WHERE CountryID = @CountryID ))
			
		begin
			DELETE 
			FROM dbo.Countries			
			WHERE CountryID=@CountryID	
		end
END
GO

ALTER TABLE dbo.Counties  
DROP CONSTRAINT FK_Counties_Countries

ALTER TABLE dbo.Counties
ADD CONSTRAINT FK_Counties_Countries 
FOREIGN KEY (CountryID) references dbo.Countries (CountryID) ON DELETE CASCADE


CREATE PROCEDURE dbo.Counties_Delete
(
	@CountyID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	if(EXISTS(SELECT TOP 1 CountyID FROM dbo.Counties WHERE CountyID=@CountyID))		
				begin				
					DELETE 
					FROM dbo.Counties
					WHERE CountyID=@CountyID
				end		
END
GO


CREATE PROCEDURE dbo.Cities_Delete
(
	@CityID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	if(EXISTS(SELECT TOP 1 CityID FROM dbo.Cities WHERE CityID=@CityID))		
				begin
					ALTER TABLE dbo.Cities
					DROP CONSTRAINT FK_Cities_Counties
					ALTER TABLE dbo.Cities
					ADD CONSTRAINT FK_Cities_Counties
					FOREIGN KEY (CountyID) references dbo.Counties (CountyID) ON DELETE CASCADE
					DELETE
					FROM dbo.Cities
					WHERE CityID=@CityID
				end
END
GO


CREATE PROCEDURE dbo.Currencies_Delete
(
	@CurrencyID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON	

	if(EXISTS(SELECT TOP 1 CurrencyID FROM dbo.Currencies WHERE CurrencyID=@CurrencyID))	
		begin
			DELETE 
			FROM dbo.Currencies		
			WHERE CurrencyID=@CurrencyID	
		end		
END
GO



-- aici nu cred ca e ok
CREATE PROCEDURE dbo.Categories_Delete
(
	@CategoryID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	if(EXISTS(SELECT TOP 1 CategoryID FROM dbo.Categories WHERE CategoryID=@CategoryID))		
				begin
					DELETE 
					FROM dbo.Categories
					WHERE CategoryID=@CategoryID
				end	
END
GO


CREATE PROCEDURE dbo.Roles_Delete
(
	@RoleID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	if(EXISTS(SELECT TOP 1 RoleID FROM dbo.Roles WHERE RoleID=@RoleID))
		
		begin
			DELETE
			FROM dbo.Roles
			WHERE RoleID=@RoleID
		end		
END
GO


CREATE PROCEDURE dbo.Promotions_Delete
(
	@PromotionID uniqueidentifier	
)
AS
BEGIN
	SET NOCOUNT ON
	if(EXISTS(SELECT TOP 1 PromotionID FROM dbo.Promotions WHERE PromotionID=@PromotionID))		
		begin
			DELETE
			FROM dbo.Promotions
			WHERE PromotionID=@PromotionID
		end		
END
GO

CREATE PROCEDURE dbo.PaymentOptions_Delete
(
	@PaymentOptionID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	if(EXISTS(SELECT TOP 1 PaymentOptionID FROM dbo.PaymentOptions WHERE PaymentOptionID=@PaymentOptionID))		
		begin
			DELETE
			FROM dbo.PaymentOptions
			WHERE PaymentOptionID=@PaymentOptionID
		end		
END
GO


CREATE PROCEDURE dbo.Photos_Delete
(
	@PhotoID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	if(EXISTS(SELECT TOP 1 PhotoID FROM dbo.Photos WHERE PhotoID=@PhotoID))		
		begin
			DELETE
			FROM dbo.Photos
			WHERE PhotoID=@PhotoID
		end		
END
GO

CREATE PROCEDURE dbo.OrderedProducts_Delete
(
	@OrderedProductID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	if(EXISTS(SELECT TOP 1 OrderedProductID FROM dbo.OrderedProducts WHERE OrderedProductID=@OrderedProductID))		
		begin
			DELETE
			FROM dbo.OrderedProducts
			WHERE OrderedProductID=@OrderedProductID
		end		
END
GO

CREATE PROCEDURE dbo.Orders_Delete
(
	@OrderID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	if(EXISTS(SELECT TOP 1 OrderID FROM dbo.Orders WHERE OrderID=@OrderID))		
		begin
			DELETE
			FROM dbo.Orders
			WHERE OrderID=@OrderID
		end		
END
GO

CREATE PROCEDURE dbo.Persons_Delete
(
	@PersonID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	if(EXISTS(SELECT TOP 1 PersonID FROM dbo.Persons WHERE PersonID=@PersonID))		
		begin
			DELETE 
			FROM dbo.Persons
			WHERE PersonID=@PersonID
		end		
END
GO

CREATE PROCEDURE dbo.Products_Delete
(
	@ProductID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	if(EXISTS(SELECT TOP 1 ProductID FROM dbo.Products WHERE ProductID=@ProductID))		
		begin
			DELETE
			FROM dbo.Products
			WHERE ProductID=@ProductID
		end		
END
GO


CREATE PROCEDURE dbo.Accounts_Delete
(
	@AccountID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	if(EXISTS(SELECT TOP 1 AccountID FROM dbo.Accounts WHERE AccountID=@AccountID))		
		begin
			DELETE 
			FROM dbo.Accounts
			WHERE AccountID=@AccountID
		end		
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
	if(EXISTS(SELECT TOP 1 PhotoID,ProductID FROM dbo.ProductsPhotos WHERE (PhotoID=@PhotoID AND ProductID=@ProductID)))
		begin
			DELETE
			FROM dbo.ProductsPhotos
			WHERE (PhotoID=@PhotoID AND ProductID=@ProductID)
		end		
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
	if(EXISTS(SELECT TOP 1 ProductID, MaterialID FROM dbo.ProductsMaterials WHERE (MaterialID=@MaterialID AND ProductID=@ProductID)))
		begin
			DELETE
			FROM dbo.ProductsMaterials
			WHERE (MaterialID=@MaterialID AND ProductID=@ProductID)
		end		
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
	if(EXISTS(SELECT TOP 1 ProductID, PromotionID FROM dbo.ProductsPromotions WHERE (PromotionID=@PromotionID AND ProductID=@ProductID)))
		begin
			DELETE
			FROM dbo.ProductsPromotions
			WHERE (PromotionID=@PromotionID AND ProductID=@ProductID)

		end		
END
GO

CREATE FUNCTION dbo.Categories_GetNoOfProducts
(
	@CategoryID uniqueidentifier
)
RETURNS INT
AS
BEGIN
	DECLARE @result int
	SELECT @result=COUNT(p.ProductID)
	FROM Categories c
		LEFT JOIN Products p ON c.CategoryID = p.CategoryID
	WHERE c.CategoryID = @CategoryID
	GROUP BY c.CategoryID, c.Name
	RETURN @result
END
GO


CREATE PROCEDURE dbo.CategoriesProducts_ReadById 
(
	@CategoryID uniqueidentifier
)
AS
BEGIN
	SELECT DISTINCT c.CategoryID,
			c.Name,	
			dbo.Categories_GetNoOfProducts(c.CategoryID) AS NoOfProducts
	FROM Categories c
		LEFT JOIN Products p ON c.CategoryID = p.CategoryID
	WHERE c.CategoryID = @CategoryID	
END
GO
DROP PROCEDURE dbo.CategoriesProducts_ReadById

--DECLARE @CategoryID uniqueidentifier = '0A813318-B9E8-4946-A6D5-E01FB186C8BB'
--EXECUTE dbo.CategoriesProducts_ReadById  @CategoryID

--NON Clustered index with execution plan
--SELECT * 
--FROM Products p
     --LEFT JOIN Colors c ON c.ColorID=p.ColorID
--WHERE c.Name='Maro'
		