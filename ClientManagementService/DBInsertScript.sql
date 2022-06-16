alter table [Product] add [Code] varchar(20) not null



SET IDENTITY_INSERT [Branch] ON 
GO
INSERT [Branch] ([Id], [BranchName], [ManagerName], [Contact], [Location], [Email]) VALUES (1, N'Ingware AG
', N'NA', N'NA', N'NA', N'NA')
GO
INSERT [Branch] ([Id], [BranchName], [ManagerName], [Contact], [Location], [Email]) VALUES (2, N'Ingware Romandie SA
', N'NA', N'NA', N'NA', N'NA')
GO
SET IDENTITY_INSERT [Branch] OFF
GO
SET IDENTITY_INSERT [Currency] ON 
GO
INSERT [Currency] ([Id], [Code], [Symbol]) VALUES (1, N'CHF', N'CHF')
GO
INSERT [Currency] ([Id], [Code], [Symbol]) VALUES (2, N'EUR', N'EUR')
GO
SET IDENTITY_INSERT [Currency] OFF
GO
SET IDENTITY_INSERT [ProductCategory] ON 
GO
INSERT [ProductCategory] ([Id], [Name], [Description]) VALUES (1, N'Modules', N'Modules ')
GO
INSERT [ProductCategory] ([Id], [Name], [Description]) VALUES (2, N'Software', N'Software')
GO
INSERT [ProductCategory] ([Id], [Name], [Description]) VALUES (3, N'Course', N'Course')
GO
SET IDENTITY_INSERT [ProductCategory] OFF
GO
SET IDENTITY_INSERT [Product] ON 
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (1, N' Stabstatik Linear', 1, N'0', N' Stabstatik Linear', 100, N'0', 1, N'N', N'N', N'N/A', N'L1')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (2, N' Stabstatik Nichtlinear', 1, N'0', N' Stabstatik Nichtlinear', 100, N'0', 1, N'N', N'N', N'N/A', N'NL1')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (3, N' Stabstatik Plastisch', 1, N'0', N' Stabstatik Plastisch', 100, N'0', 1, N'N', N'N', N'N/A', N'PNL1')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (4, N' Platten, Scheiben, Schalen Linear', 1, N'0', N' Platten, Scheiben, Schalen Linear', 100, N'0', 1, N'N', N'N', N'N/A', N'L2')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (5, N' Platten, Scheiben, Schalen Nichtlinear', 1, N'0', N' Platten, Scheiben, Schalen Nichtlinear', 100, N'0', 1, N'N', N'N', N'N/A', N'NL2')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (6, N' Platten, Scheiben, Schalen Plastisch', 1, N'0', N' Platten, Scheiben, Schalen Plastisch', 100, N'0', 1, N'N', N'N', N'N/A', N'PNL2')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (7, N' Platten, Scheiben, Schalen inkl. Stabstatik Linear', 1, N'0', N' Platten, Scheiben, Schalen inkl. Stabstatik Linear', 100, N'0', 1, N'N', N'N', N'N/A', N'L3')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (8, N' Platten, Scheiben, Schalen inkl. Stabstatik Nichtlinear', 1, N'0', N' Platten, Scheiben, Schalen inkl. Stabstatik Nichtlinear', 100, N'0', 1, N'N', N'N', N'N/A', N'NL3')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (9, N' Platten, Scheiben, Schalen inkl. Stabstatik Plastisch', 1, N'0', N' Platten, Scheiben, Schalen inkl. Stabstatik Plastisch', 100, N'0', 1, N'N', N'N', N'N/A', N'PNL3')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (10, N' Platten / Scheiben Rippen Linear', 1, N'0', N' Platten / Scheiben Rippen Linear', 100, N'0', 1, N'N', N'N', N'N/A', N'L4')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (11, N' Platten / Scheiben Rippen Nichtlinear', 1, N'0', N' Platten / Scheiben Rippen Nichtlinear', 100, N'0', 1, N'N', N'N', N'N/A', N'NL4')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (12, N' Platten, Scheiben, Schalen', 1, N'1', N' Platten, Scheiben, Schalen', 100, N'0', 1, N'N', N'N', N'N/A', N'RC1')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (13, N' Stäbe, Stützen, Unterzüge', 1, N'1', N' Stäbe, Stützen, Unterzüge', 100, N'0', 1, N'N', N'N', N'N/A', N'RC2')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (14, N' Durchstanzen, Schubwiderstand', 1, N'1', N' Durchstanzen, Schubwiderstand', 100, N'0', 1, N'N', N'N', N'N/A', N'RC3')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (15, N' Fundamentsbemessung', 1, N'1', N' Fundamentsbemessung', 100, N'0', 1, N'N', N'N', N'N/A', N'RC4')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (16, N' Bemessung von Stahlbetonwänden', 1, N'1', N' Bemessung von Stahlbetonwänden', 100, N'0', 1, N'N', N'N', N'N/A', N'RC5')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (17, N' Querschnittsanalyse von Stahlbetonwänden', 1, N'1', N' Querschnittsanalyse von Stahlbetonwänden', 100, N'0', 1, N'N', N'N', N'N/A', N'RC6')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (18, N' Mauerwerksbemessung', 1, N'1', N' Mauerwerksbemessung', 100, N'0', 1, N'N', N'N', N'N/A', N'MD1')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (19, N' Stahlbaunachweise', 1, N'1', N' Stahlbaunachweise', 100, N'0', 1, N'N', N'N', N'N/A', N'SD1')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (20, N'AxisVM', 2, N'0', N'AxisVM', 100, N'0', 1, N'N', N'N', N'N/A', N'AXVM')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (21, N'Upkeep Solution', 2, N'0', N'Upkeep Solution', 100, N'0', 1, N'N', N'N', N'N/A', N'UPS')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (22, N'AxisVM | BIM Workflow mit SAF', 3, N'0', N'AxisVM | BIM Workflow mit SAF', 100, N'1.5', 0, N'N', N'N', N'N/A', N'B4')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (23, N'AxisVM | Lasten & Kombinationen', 3, N'0', N'AxisVM | Lasten & Kombinationen', 100, N'2.5', 0, N'N', N'N', N'N/A', N'A1')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (24, N'AxisVM | Direkt BIM mit Tekla', 3, N'0', N'AxisVM | Direkt BIM mit Tekla', 100, N'1.5', 0, N'N', N'N', N'N/A', N'B3')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (25, N'AxisVM | Erdbebenkurs', 3, N'0', N'AxisVM | Erdbebenkurs', 100, N'2.5', 0, N'N', N'N', N'N/A', N'S2')
GO
INSERT [Product] ([Id], [Name], [ProductCategoryId], [Type], [Descripion], [AvailableQuantity], [Duration], [IsLicenseProduct], [LicenseType], [ProtectionType], [Comment], [Code]) VALUES (26, N'Individualschulung', 3, N'2', N'Individualschulung', 100, N'3.5', 0, N'N', N'N', N'N/A', N'I')
GO
SET IDENTITY_INSERT [Product] OFF
GO
SET IDENTITY_INSERT [ProductPrice] ON 
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (1, 1, 1, CAST(1800.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (2, 2, 1, CAST(2250.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (3, 3, 1, CAST(2600.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (4, 4, 1, CAST(2550.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (5, 5, 1, CAST(3400.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (6, 6, 1, CAST(3800.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (7, 7, 1, CAST(4500.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (8, 8, 1, CAST(5250.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (9, 9, 1, CAST(5900.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (10, 10, 1, CAST(1780.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (11, 11, 1, CAST(2380.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (12, 12, 1, CAST(525.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (13, 13, 1, CAST(525.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (14, 14, 1, CAST(525.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (15, 15, 1, CAST(525.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (16, 16, 1, CAST(600.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (17, 17, 1, CAST(675.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (18, 18, 1, CAST(675.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (19, 19, 1, CAST(600.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (20, 1, 2, CAST(1550.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (21, 2, 2, CAST(1750.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (22, 3, 2, CAST(2050.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (23, 4, 2, CAST(2000.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (24, 5, 2, CAST(2550.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (25, 6, 2, CAST(2950.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (26, 7, 2, CAST(3100.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (27, 8, 2, CAST(3700.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (28, 9, 2, CAST(4300.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (29, 10, 2, CAST(1500.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (30, 11, 2, CAST(1750.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (31, 12, 2, CAST(400.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (32, 13, 2, CAST(400.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (33, 14, 2, CAST(400.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (34, 15, 2, CAST(400.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (35, 16, 2, CAST(400.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (36, 17, 2, CAST(500.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (37, 18, 2, CAST(500.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (38, 19, 2, CAST(400.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (39, 20, 1, CAST(0.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (40, 21, 1, CAST(0.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (41, 22, 1, CAST(120.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (42, 23, 1, CAST(190.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (43, 24, 1, CAST(120.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (44, 25, 1, CAST(190.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
INSERT [ProductPrice] ([Id], [ProductId], [CurrencyId], [UnitPrice], [GSTApplicable], [IsActive], [ActivationDate], [StopDate]) VALUES (45, 26, 1, CAST(800.000 AS Decimal(10, 3)), 0, 1, CAST(N'2022-06-10T00:00:00.0000000' AS DateTime2), CAST(N'2030-06-10T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [ProductPrice] OFF
GO
INSERT [__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220610142354_product code', N'3.1.25')
GO
