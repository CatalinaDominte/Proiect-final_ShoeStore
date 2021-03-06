USE [RoleBaseAccessibility]
GO
/****** Object:  Table [dbo].[ArchiveProducts]    Script Date: 2/27/2020 3:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArchiveProducts](
	[ArchiveId] [int] IDENTITY(1,1) NOT NULL,
	[ProductsId] [int] NOT NULL,
	[ProductsName] [varchar](50) NOT NULL,
	[UnitsInStock] [int] NOT NULL,
	[UnitPrice] [smallmoney] NOT NULL,
	[EntryDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ArchiveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 2/27/2020 3:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
	[CategoryDescription] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 2/27/2020 3:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[InventoryId] [int] IDENTITY(1,1) NOT NULL,
	[ProductsId] [int] NOT NULL,
	[ProductsName] [varchar](50) NOT NULL,
	[StoreLocation] [int] NOT NULL,
	[SoldDate] [date] NOT NULL,
	[UnitPrice] [int] NOT NULL,
	[Discount] [int] NULL,
	[FinalPrice] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[InventoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 2/27/2020 3:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2/27/2020 3:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductsId] [int] IDENTITY(1,1) NOT NULL,
	[ModelId] [varchar](50) NULL,
	[ProductsName] [varchar](50) NOT NULL,
	[Suppliers] [int] NOT NULL,
	[Category] [int] NOT NULL,
	[StoreLocation] [int] NOT NULL,
	[ProductsDescription] [varchar](50) NULL,
	[UnitsInStock] [int] NOT NULL,
	[UnitPrice] [decimal](6, 2) NULL,
	[Discount] [decimal](6, 2) NULL,
	[FinalPrice] [decimal](6, 2) NULL,
	[Size] [varchar](50) NOT NULL,
	[AvaibleColours] [varchar](100) NOT NULL,
	[EntryDate] [date] NOT NULL,
	[Picture] [image] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 2/27/2020 3:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role] [nvarchar](max) NOT NULL,
	[Notes] [nvarchar](255) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StoreLocation]    Script Date: 2/27/2020 3:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoreLocation](
	[StoreId] [int] IDENTITY(1,1) NOT NULL,
	[StoreName] [varchar](50) NOT NULL,
	[StoreAddress] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 2/27/2020 3:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[SuppliersId] [int] IDENTITY(1,1) NOT NULL,
	[SuppliersName] [varchar](50) NOT NULL,
	[SuppliersAddress] [varchar](100) NULL,
	[SuppliersContactInformations] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[SuppliersId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ArchiveProducts]  WITH CHECK ADD FOREIGN KEY([ProductsId])
REFERENCES [dbo].[Products] ([ProductsId])
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD FOREIGN KEY([ProductsId])
REFERENCES [dbo].[Products] ([ProductsId])
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD FOREIGN KEY([StoreLocation])
REFERENCES [dbo].[StoreLocation] ([StoreId])
GO
ALTER TABLE [dbo].[Login]  WITH CHECK ADD  CONSTRAINT [R_10] FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([role_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Login] CHECK CONSTRAINT [R_10]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([Category])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([StoreLocation])
REFERENCES [dbo].[StoreLocation] ([StoreId])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([Suppliers])
REFERENCES [dbo].[Suppliers] ([SuppliersId])
GO
/****** Object:  StoredProcedure [dbo].[CreateAccounts]    Script Date: 2/27/2020 3:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[CreateAccounts]  
	(
	@1 varchar(50),
	@2 varchar(50),
	@3 int
	)
  as   
    begin
	INSERT INTO [Login] ([username], [password], [role_id]) VALUES (@1,@2,@3)
	End
GO
/****** Object:  StoredProcedure [dbo].[CreateCategory]    Script Date: 2/27/2020 3:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateCategory]  
	(
	
	@1 varchar(50),
	@2 varchar(50)
	)
  as   
    begin
	INSERT INTO [Category] ( [Category].CategoryName, [Category].CategoryDescription) VALUES (@1,@2)
	End
GO
/****** Object:  StoredProcedure [dbo].[CreateProducts]    Script Date: 2/27/2020 3:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[CreateProducts]  
	(
	@1 varchar(50),
	@2 varchar(50),
	@3 int,
	@4 int,
	@5 int,
	@6 varchar(50),
	@7 int,
	@8 int,
	@9 int,
	@10 int,
	@11 varchar,
	@12 varchar,
	@13 Date
	)
  as   
    begin
	INSERT INTO [Products] ([ModelId], [ProductsName], [Suppliers], [Category],[StoreLocation],[ProductsDescription], [UnitsInStock], [UnitPrice], [Discount], [FinalPrice], [Size],[AvaibleColours], [EntryDate]) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13)
	End
GO
/****** Object:  StoredProcedure [dbo].[DeleteAccounts]    Script Date: 2/27/2020 3:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[DeleteAccounts]  
  (
  @Id int
  )
    as   
    begin  
       DELETE FROM [Login] WHERE [id]= @Id
    End
GO
/****** Object:  StoredProcedure [dbo].[DeleteCategory]    Script Date: 2/27/2020 3:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DeleteCategory]  
  (
  @Id int
  )
    as   
    begin  
       DELETE FROM [Category] WHERE CategoryId= @Id
    End
GO
/****** Object:  StoredProcedure [dbo].[DeleteProduct]    Script Date: 2/27/2020 3:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DeleteProduct]  
  (
  @Id int
  )
    as   
    begin  
       DELETE FROM [Products] WHERE ProductsId= @Id
    End
GO
/****** Object:  StoredProcedure [dbo].[GetAll]    Script Date: 2/27/2020 3:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAll]     
        
 AS    
 BEGIN    
      SELECT*   
      FROM [Products]    
 END    
GO
/****** Object:  StoredProcedure [dbo].[GetAllCategory]    Script Date: 2/27/2020 3:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllCategory]     
        
 AS    
 BEGIN    
      SELECT*   
      FROM [Category]    
 END    
GO
/****** Object:  StoredProcedure [dbo].[GetAllProducts]    Script Date: 2/27/2020 3:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GetAllProducts]  
  as   
    begin  
       Select Products.ProductsId, Products.ModelId, Products.ProductsName, Suppliers.SuppliersName as Supplier , 
            Category.CategoryName as Category , StoreLocation.StoreName as StoreLocation , Products.ProductsDescription,
            Products.UnitsInStock, Products.Discount, Products.FinalPrice, Products.Size, Products.AvaibleColours
            From[Products] JOIN Suppliers On  Suppliers.SuppliersId = Products.Suppliers 
            JOIN Category On Category.CategoryId = Products.Category 
            JOIN StoreLocation on StoreLocation.StoreId = Products.StoreLocation
    End
GO
/****** Object:  StoredProcedure [dbo].[GetDetailAccounts]    Script Date: 2/27/2020 3:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GetDetailAccounts]  
  as   
    begin
	Select * From Login
	End
GO
/****** Object:  StoredProcedure [dbo].[GetDetails]    Script Date: 2/27/2020 3:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetDetails]
(
  @Id int
  )
  as   
    begin
	Select * From Products WHERE ProductsId= @Id
	End
GO
/****** Object:  StoredProcedure [dbo].[GetDetailsCategory]    Script Date: 2/27/2020 3:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetDetailsCategory]     
 (
  @Id int
  )
  as   
    begin
	Select * From [Category] WHERE CategoryId= @Id
	End
GO
/****** Object:  StoredProcedure [dbo].[LoginByUsernamePassword]    Script Date: 2/27/2020 3:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
   


CREATE PROCEDURE [dbo].[LoginByUsernamePassword]     
      @username varchar(50),    
      @password varchar(50)    
 AS    
 BEGIN    
      SELECT id, username, password, role_id    
      FROM Login    
      WHERE username = @username    
      AND password = @password    
 END    
GO
/****** Object:  StoredProcedure [dbo].[UpdateAccounts]    Script Date: 2/27/2020 3:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[UpdateAccounts]  
	(
	@1 varchar(50),
	@2 varchar(50),
	@3 int,
	@Id int
	)
  as   
    begin
	Update [Login] SET [username]=@1, [password]=@2, [role_id]=@3 Where [id] = @Id
	End
GO
/****** Object:  StoredProcedure [dbo].[UpdateCategory]    Script Date: 2/27/2020 3:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[UpdateCategory]  
	(
	
	@1 varchar(50),
	@2 varchar(50),
	@Id int
	)
  as   
    begin
	Update [Category] SET  [CategoryName]=@1, [CategoryDescription]=@2 Where [CategoryId] = @Id
	End
GO
/****** Object:  StoredProcedure [dbo].[UpdateProducts]    Script Date: 2/27/2020 3:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateProducts]  
	(
	@1 varchar(50),
	@2 varchar(50),
	@3 int,
	@4 int,
	@5 int,
	@6 varchar(50),
	@7 int,
	@8 int,
	@9 int,
	@10 int,
	@11 varchar(50),
	@12 varchar(50),
	@13 Date,
	@Id int
	)
  as   
    begin
	Update [Products] SET [ModelId]=@1, [ProductsName]=@2, [Suppliers]=@3, [Category]=@4,
                        [StoreLocation]=@5,[ProductsDescription]=@6, [UnitsInStock]=@7, [UnitPrice]=@8, [Discount]=@9, 
                        [FinalPrice]=@10, [Size]=@11,[AvaibleColours]=@12, [EntryDate]=@13 Where [ProductsId] = @Id
	End
GO

INSERT INTO [Category] ([CategoryName],[CategoryDescription])
VALUES
 ('Pantofi Ocazie','Produs destinat oricarui anotimp'),
 ('Sandale','Produs pentru vara'),
  ('Ghete','Produs toamna-iarna'),
  ('Pantofi Sport','Produs primavara-toamna'),
  ('Pantofi casual dama','Produs destinat oricarui anotimp'),
  ('Pantofi casual barbati','Produs destinat oricarui anotimp');
 select * from[Category]

 




	
INSERT INTO [Suppliers]( [SuppliersName], [SuppliersAddress], [SuppliersContactInformations])
VALUES
('Adidas', 'strada Florilor', 'email@g.com'),
('Mika Soes', 'strada Narciselor', 'email@g.com'),
('Foot Locker', 'strada Canta', 'email@g.com'),
('Marelbo', 'strada Nicolina', 'email@g.com');


INSERT INTO [StoreLocation]([StoreName], [StoreAddress])
Values
('Piata Unirii', 'adresa'),
('Stefan cel Mare', 'adresa2'),
('Odeon', 'adresa2'),
('Magazin Central', 'adresa2');

INSERT INTO [Products]([ModelId], [ProductsName], [Suppliers], [Category], [StoreLocation],[ProductsDescription], [UnitsInStock], [UnitPrice], [Discount], [FinalPrice], [Size], [AvaibleColours], [EntryDate])
VALUES
('P37ad','Pantofi Sept', 3, 4, 4,'test', 10, 150, 0, 150, '37', 'negru', '2020-01-01'),
('P38ab','Pantofi Les', 4, 5, 5,'test', 10, 100, 0, 100, '38', 'rosu', '2020-01-01'),
('P40ab','Pantofi Les', 5, 6, 5,'test', 10, 100, 0, 100, '40', 'rosu', '2020-01-01'),
('P41ab','Pantofi Les', 3, 6, 5,'test', 10, 100, 0, 100, '41', 'rosu', '2020-01-01');