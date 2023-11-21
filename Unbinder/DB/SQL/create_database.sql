IF NOT EXISTS(SELECT name FROM sys.databases WHERE name = 'Unbinder')
BEGIN
	CREATE DATABASE Unbinder;

	USE Unbinder;

	CREATE TABLE [dbo].Recipes (
		[Id] INT IDENTITY(1,1) NOT NULL,
		[Name] NVARCHAR(50) NOT NULL,
		[ShortDescription] NVARCHAR(1000) NULL,
		[Author] NVARCHAR(100) NULL,
		[RecipeText] NVARCHAR(8000) NULL,
		[ImageUrl] NVARCHAR(1000) NULL,
		[Created] DATETIME NOT NULL,
		[Updated] DATETIME NOT NULL,
		CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED ([Id] ASC)
	);

	CREATE TABLE [dbo].Ingredients (
		[Id] INT IDENTITY(1,1) NOT NULL,
		[Name] NVARCHAR(50) NOT NULL,
		[Description] NVARCHAR(1000) NULL,
		CONSTRAINT [PK_Ingredients] PRIMARY KEY CLUSTERED ([Id] ASC)
	);
END