IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Branch] (
    [Id] int NOT NULL IDENTITY,
    [BranchName] varchar(200) NULL,
    [ManagerName] varchar(200) NULL,
    [Contact] varchar(100) NULL,
    [Location] varchar(200) NULL,
    [Email] varchar(70) NULL,
    CONSTRAINT [PK_Branch] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Currency] (
    [Id] int NOT NULL IDENTITY,
    [Code] varchar(3) NULL,
    [Symbol] nvarchar(20) NULL,
    CONSTRAINT [PK_Currency] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [BranchStaff] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] varchar(150) NULL,
    [LastName] varchar(150) NULL,
    [Gender] varchar(10) NULL,
    [UserId] varchar(50) NULL,
    [Password] varchar(200) NULL,
    [Contact] varchar(200) NULL,
    [Email] varchar(70) NULL,
    [Location] varchar(200) NULL,
    [BranchId] int NOT NULL,
    CONSTRAINT [PK_BranchStaff] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_BranchStaff_Branch_BranchId] FOREIGN KEY ([BranchId]) REFERENCES [Branch] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Client] (
    [Id] int NOT NULL IDENTITY,
    [CompanyName] varchar(150) NULL,
    [ContactPerson] varchar(150) NULL,
    [Contact] varchar(100) NULL,
    [Email] varchar(70) NULL,
    [Location] varchar(200) NULL,
    [BranchId] int NOT NULL,
    [CurrencyId] int NOT NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Client_Branch_BranchId] FOREIGN KEY ([BranchId]) REFERENCES [Branch] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Client_Currency_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [Currency] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_BranchStaff_BranchId] ON [BranchStaff] ([BranchId]);

GO

CREATE INDEX [IX_Client_BranchId] ON [Client] ([BranchId]);

GO

CREATE INDEX [IX_Client_CurrencyId] ON [Client] ([CurrencyId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220527033320_Inital Migrations', N'3.1.25');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Currency]') AND [c].[name] = N'Code');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Currency] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Currency] ALTER COLUMN [Code] varchar(3) NOT NULL;

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Client]') AND [c].[name] = N'CompanyName');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Client] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Client] ALTER COLUMN [CompanyName] varchar(150) NOT NULL;

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BranchStaff]') AND [c].[name] = N'UserId');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [BranchStaff] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [BranchStaff] ALTER COLUMN [UserId] varchar(50) NOT NULL;

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BranchStaff]') AND [c].[name] = N'Password');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [BranchStaff] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [BranchStaff] ALTER COLUMN [Password] varchar(200) NOT NULL;

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BranchStaff]') AND [c].[name] = N'Gender');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [BranchStaff] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [BranchStaff] ALTER COLUMN [Gender] varchar(10) NOT NULL;

GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BranchStaff]') AND [c].[name] = N'FirstName');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [BranchStaff] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [BranchStaff] ALTER COLUMN [FirstName] varchar(150) NOT NULL;

GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Branch]') AND [c].[name] = N'BranchName');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Branch] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Branch] ALTER COLUMN [BranchName] varchar(200) NOT NULL;

GO

CREATE TABLE [Offer] (
    [Id] int NOT NULL IDENTITY,
    [ClientID] int NOT NULL,
    [BranchId] int NOT NULL,
    [OfferDate] datetime2 NOT NULL,
    [Description] varchar(500) NULL,
    [CustomerCurrency] varchar(3) NOT NULL,
    [OfferTotal] decimal(10,3) NOT NULL,
    [OfferTax] decimal(10,3) NOT NULL,
    [OfferDiscount] decimal(10,3) NOT NULL,
    [CreatedBy] varchar(100) NULL,
    CONSTRAINT [PK_Offer] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Order] (
    [Id] int NOT NULL IDENTITY,
    [IsFromOffer] bit NOT NULL,
    [OfferId] int NOT NULL,
    [ClientID] int NOT NULL,
    [BranchId] int NOT NULL,
    [OrderDate] datetime2 NOT NULL,
    [Description] varchar(500) NULL,
    [CustomerCurrency] varchar(3) NOT NULL,
    [OrderTotal] decimal(10,3) NOT NULL,
    [OrderTax] decimal(10,3) NOT NULL,
    [OrderDiscount] decimal(10,3) NOT NULL,
    [CreatedBy] varchar(100) NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ProductCategory] (
    [Id] int NOT NULL IDENTITY,
    [Name] varchar(200) NOT NULL,
    [Description] nvarchar(500) NULL,
    CONSTRAINT [PK_ProductCategory] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Product] (
    [Id] int NOT NULL IDENTITY,
    [Name] varchar(200) NOT NULL,
    [ProductCategoryId] int NOT NULL,
    [Type] varchar(200) NULL,
    [Descripion] varchar(500) NULL,
    [AvailableQuantity] int NOT NULL,
    [Duration] varchar(20) NULL,
    [IsLicenseProduct] bit NOT NULL,
    [LicenseType] varchar(50) NULL,
    [ProtectionType] varchar(50) NULL,
    [Comment] varchar(500) NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Product_ProductCategory_ProductCategoryId] FOREIGN KEY ([ProductCategoryId]) REFERENCES [ProductCategory] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [OfferItem] (
    [Id] int NOT NULL IDENTITY,
    [OfferId] int NOT NULL,
    [ProductId] int NOT NULL,
    [Quantity] int NOT NULL,
    [UnitPrice] decimal(10,3) NOT NULL,
    [IsTaxApplied] bit NOT NULL,
    [TaxAmount] decimal(10,3) NOT NULL,
    [IsDiscountApplied] bit NOT NULL,
    [DiscountAmount] decimal(10,3) NOT NULL,
    [OriginalProductCost] decimal(10,3) NOT NULL,
    [ItemWeight] varchar(max) NULL,
    [Comment] varchar(500) NULL,
    CONSTRAINT [PK_OfferItem] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OfferItem_Offer_OfferId] FOREIGN KEY ([OfferId]) REFERENCES [Offer] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OfferItem_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [OrderItem] (
    [Id] int NOT NULL IDENTITY,
    [OrderId] int NOT NULL,
    [ProductId] int NOT NULL,
    [Quantity] int NOT NULL,
    [UnitPrice] decimal(10,3) NOT NULL,
    [IsTaxApplied] bit NOT NULL,
    [TaxAmount] decimal(10,3) NOT NULL,
    [IsDiscountApplied] bit NOT NULL,
    [DiscountAmount] decimal(10,3) NOT NULL,
    [OriginalProductCost] decimal(10,3) NOT NULL,
    [ItemWeight] varchar(max) NULL,
    [Comment] varchar(500) NULL,
    CONSTRAINT [PK_OrderItem] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OrderItem_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Order] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderItem_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ProductPrice] (
    [Id] int NOT NULL IDENTITY,
    [ProductId] int NOT NULL,
    [CurrencyId] int NOT NULL,
    [UnitPrice] decimal(10,3) NOT NULL,
    [GSTApplicable] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [ActivationDate] datetime2 NOT NULL,
    [StopDate] datetime2 NULL,
    CONSTRAINT [PK_ProductPrice] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductPrice_Currency_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [Currency] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductPrice_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_OfferItem_OfferId] ON [OfferItem] ([OfferId]);

GO

CREATE INDEX [IX_OfferItem_ProductId] ON [OfferItem] ([ProductId]);

GO

CREATE INDEX [IX_OrderItem_OrderId] ON [OrderItem] ([OrderId]);

GO

CREATE INDEX [IX_OrderItem_ProductId] ON [OrderItem] ([ProductId]);

GO

CREATE INDEX [IX_Product_ProductCategoryId] ON [Product] ([ProductCategoryId]);

GO

CREATE INDEX [IX_ProductPrice_CurrencyId] ON [ProductPrice] ([CurrencyId]);

GO

CREATE INDEX [IX_ProductPrice_ProductId] ON [ProductPrice] ([ProductId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220604102130_All Tables Add', N'3.1.25');

GO

