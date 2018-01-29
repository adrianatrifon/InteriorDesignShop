CREATE DATABASE HomeDesignDB
GO
USE HomeDesignDB
GO
--DROP DATABASE HomeDesignDB


CREATE TABLE [Categories](
	[CategoryID] uniqueidentifier NOT NULL,
	[ParentCategoryID] uniqueidentifier,
	[Name] nvarchar(50) NOT NULL,	

	CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryID]),	
	CONSTRAINT [FK_Categories_Categories] FOREIGN KEY ([ParentCategoryID])	
		REFERENCES [Categories]([CategoryID])
	);
GO

CREATE TABLE [Styles](
	[StyleID] uniqueidentifier NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	
	CONSTRAINT [PK_Styles] PRIMARY KEY ([StyleID])	
	);
GO

CREATE TABLE [Photos](
	[PhotoID] uniqueidentifier NOT NULL,
	[Image] nvarchar(500) NOT NULL,	

	CONSTRAINT [PK_Photos] PRIMARY KEY ([PhotoID])		
	);
GO

CREATE TABLE [Designs](
	[DesignID] uniqueidentifier NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	[Description] nvarchar(MAX) NULL,
	[CategoryID] uniqueidentifier NOT NULL,
	[StyleID] uniqueidentifier NOT NULL
	
	CONSTRAINT [PK_Design] PRIMARY KEY ([DesignID]),
	CONSTRAINT [FK_Designs_Categories] FOREIGN KEY ([CategoryID]) 
		REFERENCES Categories([CategoryID]) ON DELETE CASCADE,	
	CONSTRAINT [FK_Designs_Styles] FOREIGN KEY ([StyleID]) 
		REFERENCES Styles([StyleID]) ON DELETE CASCADE,
	);
GO

CREATE TABLE [Designers](
	[DesignerID] uniqueidentifier NOT NULL,
	[FirstName] nvarchar(50) NOT NULL,
	[LastName] nvarchar(50) NOT NULL,
	[Description] nvarchar(MAX) NULL,
	
	CONSTRAINT [PK_Designers] PRIMARY KEY ([DesignerID])	
	);
GO

CREATE TABLE [DesignersDesigns](
	[DesignerID] uniqueidentifier NOT NULL,
	[DesignID] uniqueidentifier NOT NULL
	
	CONSTRAINT [PK_DesignersDesigns] PRIMARY KEY ([DesignerID],[DesignID]),
	CONSTRAINT [FK_DesignersDesigns_Designers] FOREIGN KEY ([DesignerID]) 
		REFERENCES Designers([DesignerID]) ON DELETE CASCADE,
	CONSTRAINT [FK_DesignersDesigns_Designs] FOREIGN KEY ([DesignID]) 
		REFERENCES Designs([DesignID]) ON DELETE CASCADE	
	);
GO

CREATE TABLE [DesignsPhotos](
	[DesignID] uniqueidentifier NOT NULL,
	[PhotoID] uniqueidentifier NOT NULL
	
	CONSTRAINT [PK_DesignsPhotos] PRIMARY KEY ([DesignID],[PhotoID]),	
	CONSTRAINT [FK_DesignsPhotos_Designs] FOREIGN KEY ([DesignID]) 
		REFERENCES Designs([DesignID]) ON DELETE CASCADE,
	CONSTRAINT [FK_DesignsPhotos_Photos] FOREIGN KEY ([PhotoID]) 
		REFERENCES Photos([PhotoID]) ON DELETE CASCADE
	);
GO

CREATE TABLE [DesignersPhotos](
	[DesignerID] uniqueidentifier NOT NULL,
	[PhotoID] uniqueidentifier NOT NULL

	CONSTRAINT [PK_DesignersPhotos] PRIMARY KEY ([DesignerID],[PhotoID]),	
	CONSTRAINT [FK_DesignersPhotos_Designers] FOREIGN KEY ([DesignerID]) 
		REFERENCES Designers([DesignerID]) ON DELETE CASCADE,
	CONSTRAINT [FK_DesignersPhotos_Photos] FOREIGN KEY ([PhotoID]) 
		REFERENCES Photos([PhotoID]) ON DELETE CASCADE		
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

-- CREATE PROCEDURES

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

CREATE PROCEDURE dbo.Designers_Create
(
	@DesignerID  uniqueidentifier,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Description nvarchar(MAX)
)
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.Designers
	(
		DesignerID,
		FirstName,
		LastName,
		Description
	)
	VALUES
	(
		@DesignerID,
		@FirstName,
		@LastName,
		@Description
	)
	
END
GO


CREATE PROCEDURE dbo.DesignersPhotos_Create
(
	@DesignerID uniqueidentifier,
	@PhotoID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.DesignersPhotos
	(
		DesignerID,
		PhotoID
	)
	VALUES
	(
		@DesignerID,
		@PhotoID
	)
		
END
GO

CREATE PROCEDURE dbo.DesignersDesigns_Create
(
	@DesignerID uniqueidentifier,
	@DesignID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	INSERT INTO dbo.DesignersDesigns
	(
		DesignerID,
		DesignID
	)
	VALUES
	(
		@DesignerID,
		@DesignID
	)
		
END
GO


CREATE PROCEDURE dbo.Styles_Create
(
	@StyleID uniqueidentifier,
	@StyleName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.Styles
	(
		StyleID,
		Name
	)
	VALUES
	(
		@StyleID,
		@StyleName
	)
		
END
GO


CREATE PROCEDURE dbo.Photos_Create
(
	@PhotoID uniqueidentifier,
	@Photo nvarchar(500)
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

CREATE PROCEDURE dbo.Roles_Create
(
	@RoleID uniqueidentifier,
	@RoleName nvarchar(50)
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
		@RoleName
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

CREATE PROCEDURE dbo.Designs_Create
(
	@DesignID uniqueidentifier,
	@DesignName nvarchar(50),
	@DesignDescription nvarchar(MAX),
	@CategoryID uniqueidentifier,
	@StyleID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	INSERT INTO dbo.Designs
	(
		DesignID,
		Name,
		Description,
		CategoryID,
		StyleID		
	)
	VALUES
	(
		@DesignID,
		@DesignName,
		@DesignDescription,
		@CategoryID,
		@StyleID
	)
	
END
GO

CREATE PROCEDURE dbo.DesignsPhotos_Create
(
	@DesignID uniqueidentifier,
	@PhotoID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.DesignsPhotos
	(
		DesignID,
		PhotoID
	)
	VALUES
	(
		@DesignID,
		@PhotoID
	)
	
END
GO


-- UPDATE PROCEDURES 

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

CREATE PROCEDURE dbo.Designers_Update
(
	@DesignerID  uniqueidentifier,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Description nvarchar(MAX)
)
AS
BEGIN
	SET NOCOUNT ON
		
	UPDATE dbo.Designers
	SET 
		FirstName=@FirstName,
		LastName=@LastName,
		Description=@Description
	WHERE  DesignerID=@DesignerID

END
GO





CREATE PROCEDURE dbo.Styles_Update
(
	@StyleID uniqueidentifier,
	@StyleName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON

	UPDATE dbo.Styles
	SET	 Name=@StyleName
	WHERE StyleID = @StyleID

END
GO


CREATE PROCEDURE dbo.Photos_Update
(
	@PhotoID uniqueidentifier,
	@Photo nvarchar(500)
)
AS
BEGIN
	SET NOCOUNT ON

	UPDATE dbo.Photos
	SET Image=@Photo
	WHERE PhotoID=@PhotoID

END
GO


CREATE PROCEDURE dbo.Roles_Update
(
	@RoleID uniqueidentifier,
	@RoleName nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON
	
	UPDATE dbo.Roles
	SET Description=@RoleName
	WHERE RoleID=@RoleID
			
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


CREATE PROCEDURE dbo.Designs_Update
(
	@DesignID uniqueidentifier,
	@DesignName nvarchar(50),
	@DesignDescription nvarchar(MAX),
	@CategoryID uniqueidentifier,
	@StyleID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	UPDATE dbo.Designs
	SET 
		Name= @DesignName,
		Description=@DesignDescription,
		CategoryID=@CategoryID,
		StyleID=@StyleID	
	WHERE DesignID=@DesignID
			
END
GO



-- DELETE PROCEDURES

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


CREATE PROCEDURE dbo.Designers_Delete
(
	@DesignerID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	DELETE 
	FROM dbo.Designers	
	WHERE DesignerID=@DesignerID
		
END
GO


CREATE PROCEDURE dbo.DesignersPhotos_Delete
(
	@DesignerID uniqueidentifier,
	@PhotoID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	
	DELETE 
	FROM dbo.DesignersPhotos			
	WHERE DesignerID=@DesignerID AND PhotoID=@PhotoID
	
END
GO

CREATE PROCEDURE dbo.DesignersDesigns_Delete
(
	@DesignerID uniqueidentifier,
	@DesignID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	DELETE 
	FROM dbo.DesignersDesigns			
	WHERE DesignerID=@DesignerID AND DesignID=@DesignID	

END
GO

CREATE PROCEDURE dbo.Styles_Delete
(
	@StyleID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
			
	DELETE 
	FROM dbo.Styles
	WHERE StyleID=@StyleID

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


CREATE PROCEDURE dbo.Designs_Delete
(
	@DesignID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	DELETE
	FROM dbo.Designs
	WHERE DesignID=@DesignID

END
GO


CREATE PROCEDURE dbo.DesignsPhotos_Delete
(
	@DesignID uniqueidentifier,
	@PhotoID uniqueidentifier	
)
AS
BEGIN
	SET NOCOUNT ON

	DELETE
	FROM dbo.DesignsPhotos
	WHERE DesignID=@DesignID AND PhotoID=@PhotoID

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


CREATE PROCEDURE dbo.Designers_GetByIDe
(
	@DesignerID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	SELECT
		DesignerID,
		FirstName,
		LastName,
		Description 
	FROM dbo.Designers	
	WHERE DesignerID=@DesignerID
		
END
GO



CREATE PROCEDURE dbo.Styles_GetByID
(
	@StyleID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
			
	SELECT 
		StyleID,
		Name
	FROM dbo.Styles
	WHERE StyleID=@StyleID

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


CREATE PROCEDURE dbo.Designs_GetByID
(
	@DesignID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON

	SELECT
		DesignID,
		Name,
		Description,
		CategoryID,
		StyleID
	FROM dbo.Designs
	WHERE DesignID=@DesignID

END
GO

-- ReadALL Procedures

CREATE PROCEDURE dbo.Accounts_ReadAll
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
END
GO


CREATE PROCEDURE dbo.Designers_ReadAll
AS
BEGIN
	SET NOCOUNT ON

	SELECT
		DesignerID,
		FirstName,
		LastName,
		Description 
	FROM dbo.Designers	
END
GO



CREATE PROCEDURE dbo.Styles_ReadAll
AS
BEGIN
	SET NOCOUNT ON
			
	SELECT 
		StyleID,
		Name
	FROM dbo.Styles
END
GO


CREATE PROCEDURE dbo.Photos_ReadAll
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
		PhotoID,
		Image
	FROM dbo.Photos
END
GO


CREATE PROCEDURE dbo.Roles_ReadAll
AS
BEGIN
	SET NOCOUNT ON	

	SELECT 
		RoleID,
		Description
	FROM dbo.Roles	
END
GO

CREATE PROCEDURE dbo.Categories_ReadAll
AS
BEGIN
	SET NOCOUNT ON

	SELECT 
		CategoryID,
		ParentCategoryID,
		Name
	FROM dbo.Categories
END
GO


CREATE PROCEDURE dbo.Designs_ReadAll
AS
BEGIN
	SET NOCOUNT ON

	SELECT
		DesignID,
		Name,
		Description,
		CategoryID,
		StyleID
	FROM dbo.Designs
END
GO

CREATE PROCEDURE dbo.DesignersPhotos_ReadAll
AS
BEGIN
	SET NOCOUNT ON

	SELECT
		DesignerID,
		PhotoID
	FROM dbo.DesignersPhotos
END
GO

CREATE PROCEDURE dbo.DesignersDesigns_ReadAll
AS
BEGIN
	SET NOCOUNT ON

	SELECT
		DesignerID,
		DesignID
	FROM dbo.DesignersDesigns
END
GO

CREATE PROCEDURE dbo.DesignsPhotos_ReadAll
AS
BEGIN
	SET NOCOUNT ON

	SELECT
		DesignID,
		PhotoID
	FROM dbo.DesignsPhotos
END
GO

CREATE PROCEDURE dbo.DesignView_ReadAll
AS
BEGIN
	SET NOCOUNT ON	
	
	SELECT 
		d.DesignID,
		d.Name,
		d.Description,
		c.Name AS Category,
		s.Name AS Style,
		p.Image AS Photo
	FROM dbo.Designs d RIGHT JOIN  dbo.DesignsPhotos dp ON d.DesignID=dp.DesignID LEFT JOIN dbo.Photos p ON dp.PhotoID=p.PhotoID
	       INNER JOIN dbo.Categories c ON d.CategoryID=c.CategoryID
			INNER JOIN dbo.Styles s ON d.StyleID=s.StyleID 
	 ORDER BY d.Name
END
GO
--DROP PROCEDURE dbo.DesignView_ReadAll;
--EXECUTE dbo.DesignView_ReadAll;

CREATE PROCEDURE dbo.DesignPhotos_ReadById
(
	@DesignID uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	SELECT p.PhotoID AS PhotoID, p.Image AS Image
	FROM dbo.Photos p LEFT JOIN dbo.DesignsPhotos dp ON p.PhotoID=dp.PhotoID
		RIGHT JOIN dbo.Designs d ON dp.DesignID=d.DesignID
	WHERE d.DesignID=@DesignID
END
GO
--EXECUTE dbo.DesignPhotos_ReadById @DesignID='64410FD6-734C-4A62-A553-20B68DB36773'
--R