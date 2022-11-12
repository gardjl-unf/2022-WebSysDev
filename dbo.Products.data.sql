SET IDENTITY_INSERT [dbo].[Products] ON
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (1, N'Model 3 Standard', N'Model 3 Base $46,000', CAST(46000.00 AS Decimal(18, 2)), N'Car')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (2, N'Model 3 Plaid', N'Model 3 Dual Motor $61,000', CAST(61000.00 AS Decimal(18, 2)), N'Car')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (3, N'Model Y Standard', N'Model Y Long Range $67,900', CAST(67900.00 AS Decimal(18, 2)), N'Car')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (4, N'Model Y Plaid', N'Model Y Performance $69,990', CAST(69990.00 AS Decimal(18, 2)), N'Car')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (5, N'Model X Standard', N'Model X Dual Motor $126490', CAST(126490.00 AS Decimal(18, 2)), N'Car')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (6, N'Model X Plaid', N'Model X Plaid Tri Motor $144,490', CAST(144490.00 AS Decimal(18, 2)), N'Car')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (7, N'Model S Standard', N'Model S Dual Motor $109,490', CAST(109490.00 AS Decimal(18, 2)), N'Car')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (8, N'Model S Plaid', N'Model S Plaid Tri Motor $140,490', CAST(140490.00 AS Decimal(18, 2)), N'Car')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (9, N'Paint', N'Pearl White +$0', CAST(0.00 AS Decimal(18, 2)), N'Car')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (10, N'Paint', N'Midnight Silver Metallic +$0', CAST(0.00 AS Decimal(18, 2)), N'Car')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (11, N'Paint', N'Deep Blue Metallic +$1,000', CAST(1000.00 AS Decimal(18, 2)), N'Car')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (12, N'Paint', N'Solid Black +$1,500', CAST(1500.00 AS Decimal(18, 2)), N'Car')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (13, N'Paint', N'Red Multi-Coat +2,000', CAST(2000.00 AS Decimal(18, 2)), N'Car')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (14, N'Interior', N'Black + $0', CAST(0.00 AS Decimal(18, 2)), N'Car') 
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (15, N'Interior', N'White-Black +$1,500', CAST(1500.00 AS Decimal(18, 2)), N'Car')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (16, N'Rims', N'18 Inch + $0', CAST(0.00 AS Decimal(18, 2)), N'Car')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (17, N'Rims', N'19 Inch + $2,000', CAST(2000.00 AS Decimal(18, 2)), N'Car')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (18, N'AutoPilot', N'Standard AutoPilot +$0', CAST(0.00 AS Decimal(18, 2)), N'Car')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (19, N'AutoPilot', N'Enhanced AutoPilot + $6,000', CAST(6000.00 AS Decimal(18, 2)), N'Car')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (20, N'FullSelfDriving', N'Full Self Driving none +$0', CAST(0.00 AS Decimal(18, 2)), N'Car')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (21, N'FullSelfDriving', N'Full Self Driving included +$0', CAST(15000.00 AS Decimal(18, 2)), N'Car')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (22, N'FloorMats', N'Luxury Floor Mats', CAST(95.00 AS Decimal(18, 2)), N'Interior')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (23, N'DashCover', N'Luxury Dash Cover', CAST(65.00 AS Decimal(18, 2)), N'Interior')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (24, N'BabySeat', N'Baby Seat', CAST(100.00 AS Decimal(18, 2)), N'Interior')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (25, N'RoofRack', N'Roof Rack', CAST(750.00 AS Decimal(18, 2)), N'Exterior')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (26, N'FrontLicensePlate', N'Front License Plate', CAST(85.00 AS Decimal(18, 2)), N'Exterior')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (27, N'CarSoap', N'Premium Car Soap', CAST(22.00 AS Decimal(18, 2)), N'Maintenance')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category]) VALUES (28, N'CarWax', N'Premium Car WAx', CAST(35.00 AS Decimal(18, 2)), N'Maintenance')
SET IDENTITY_INSERT [dbo].[Products] OFF
