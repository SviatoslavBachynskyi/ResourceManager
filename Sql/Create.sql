CREATE DATABASE ResourceManager3;
GO

USE ResourceManager3;

CREATE TABLE Countries
	(
	CountryId INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL
	);
GO

CREATE TABLE Districts
	(
	DistrictId INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL,
	Countries_CountryId INTEGER NOT NULL
	);
GO

CREATE TABLE Cities
	(
	CityId INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL,
	Districts_DistrictId INTEGER NOT NULL
	);
GO

CREATE TABLE MeasuringUnits 
    (
    MeasuringUnitId   INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
    Name              NVARCHAR(50) NOT NULL
	); 
GO

CREATE TABLE SafetyClasses
    (
    SafetyClassId   INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
    CodeName              NVARCHAR(50) NOT NULL
	); 
GO

CREATE TABLE EcologyClasses
    (
    EcologyClassId   INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
    CodeName              NVARCHAR(50) NOT NULL
	); 
GO

CREATE TABLE ResourceCategories
	(
	ResourceCategoryId INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL
	);
GO

CREATE TABLE ResourceSubCategories
	(
	ResourceSubCategoryId INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL,
	ResourceCategories_ResourceCategoryId INTEGER NOT NULL
	);
GO

CREATE TABLE Resources 
    (
    ResourceId        INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(100) NOT NULL,
    ResourceSubCategories_ResourceSubCategoryId INTEGER NULL,
	MeasuringUnits_MeasuringUnitId INTEGER NOT NULL,
	Description NVARCHAR(MAX) NULL,
	SafetyClasses_SafetyClassId INTEGER NULL,
	EcologyClasses_EcologyClassId INTEGER NULL,
	ShelfLife DATETIME NULL,
	NeedLicense BIT NULL,
	);
GO

CREATE TABLE Posts 
    (
    PostId   INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
    Name     nvarchar (50) NOT NULL );
GO

CREATE TABLE Workers 
    (
    WorkerId    INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL, 
    FatherName NVARCHAR(50), 
    LastName NVARCHAR(50) NOT NULL,
	Cities_CityId INTEGER NOT NULL,
	Address NVARCHAR(200) NULL,
    Posts_PostId INTEGER NOT NULL );
GO

CREATE TABLE Warehouses
	(
	WarehouseId INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	WarehouseNumber INTEGER NOT NULL,
	Volume NUMERIC(18,3) NULL,
	Cities_CityId INTEGER NOT NULL,
	Address NVARCHAR(200) NULL,
	CONSTRAINT CityNumber UNIQUE(WarehouseNumber, Cities_CityId)
	);
GO

CREATE TABLE Suppliers 
    (
    SupplierId   INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
    Name         NVARCHAR(100) NOT NULL , 
    Address NVARCHAR(200) NOT NULL,
	Contact NVARCHAR(200) NOT NULL,
	Cities_CityId INTEGER NOT NULL);
GO

CREATE TABLE OrderStatuses
	(
	OrderStatusId   INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50)
	);
GO

CREATE TABLE Orders
    (
    OrderId   INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	WayBillNumber VARCHAR(30) NULL UNIQUE,
	OrderPrice NUMERIC (18,2) NULL,
	OrderDate DATETIME NOT NULL,
	ShipmentPrice NUMERIC (18,2) NULL,
	TotalPrice NUMERIC (18,2) NULL,
	CompleteDate DATETIME NULL,
	OrderStatuses_OrderStatusId INTEGER NOT NULL,
	Workers_OrderedBy INTEGER NOT NULL,
	Suppliers_SupplierId INTEGER NOT NULL);
GO

CREATE TABLE OrderItems
    (
    OrderItemId   INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	Resources_ResourceId INTEGER NOT NULL,
	UnitPrice NUMERIC (18,2) NOT NULL,
	Quantity INTEGER NOT NULL,
	Orders_OrderId INTEGER NOT NULL);
GO

CREATE TABLE SupplyItems
	(
	SupplyItemId INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	OrderItems_OrderItemId INTEGER NOT NULL,
	Inventory_InventoryId INTEGER NOT NULL,
	Quantity INTEGER NOT NULL,
	ArrivalDate   DATE NOT NULL,
	Workers_AcceptedBy INTEGER NOT NULL
	);
GO

CREATE TABLE Inventory
	(
	InventoryId INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	InventoryNum VARCHAR(30) NOT NULL UNIQUE,
	Warehouses_WareHouseId INTEGER NOT NULL,
	Resources_ResourceId INTEGER NOT NULL,
	Quantity INTEGER NOT NULL,
	);
GO

CREATE TABLE InventoryGivings
	(
	InventoryGivingId INTEGER NOT NULL PRIMARY KEY IDENTITY (1,1),
	DateTime DATETIME NOT NULL,
	Workers_ToWhom INTEGER NOT NULL,
	Workers_ApprovedBy INTEGER NOT NULL,
	Inventory_InventoryId INTEGER NOT NULL,
	Quantity INTEGER NOT NULL,
	Description NVARCHAR(1000) NULL
	);
GO

ALTER TABLE Warehouses
    ADD CONSTRAINT Warehouses_Cites_FK FOREIGN KEY (Cities_CityId )
        REFERENCES Cities ( CityId )
ON DELETE NO ACTION;
GO

ALTER TABLE Suppliers
    ADD CONSTRAINT Suppliers_Cites_FK FOREIGN KEY (Cities_CityId )
        REFERENCES Cities ( CityId )
ON DELETE NO ACTION;
GO

ALTER TABLE Workers
    ADD CONSTRAINT Workers_Cities_FK FOREIGN KEY ( Cities_CityId )
        REFERENCES Cities ( CityId )
ON DELETE NO ACTION;
GO

ALTER TABLE Workers
    ADD CONSTRAINT Workers_Posts_FK FOREIGN KEY ( Posts_PostId )
        REFERENCES Posts ( PostId )
ON DELETE NO ACTION;
GO

ALTER TABLE Districts
	ADD CONSTRAINT Districts_Countries_FK FOREIGN KEY (Countries_CountryId)
		REFERENCES Countries (CountryId)
ON DELETE NO ACTION;
GO

ALTER TABLE Cities
	ADD CONSTRAINT Cities_Districts_FK FOREIGN KEY (Districts_DistrictId)
		REFERENCES Districts (DistrictId)
ON DELETE NO ACTION;
GO


ALTER TABLE ResourceSubCategories
    ADD CONSTRAINT ResourceSubCategories_ResourceCategories_FK FOREIGN KEY ( ResourceCategories_ResourceCategoryId )
        REFERENCES ResourceCategories ( ResourceCategoryId )
ON DELETE NO ACTION;
GO

ALTER TABLE Resources
    ADD CONSTRAINT Resource_ResourceSubCategories_FK FOREIGN KEY ( ResourceSubCategories_ResourceSubCategoryId )
        REFERENCES ResourceSubCategories ( ResourceSubCategoryId )
ON DELETE NO ACTION;
GO

ALTER TABLE Resources
    ADD CONSTRAINT Resources_MeasuringUnits_FK FOREIGN KEY ( MeasuringUnits_MeasuringUnitId )
        REFERENCES MeasuringUnits ( MeasuringUnitId )
ON DELETE NO ACTION;
GO

ALTER TABLE Resources
    ADD CONSTRAINT Resources_SafetyClasses_FK FOREIGN KEY ( SafetyClasses_SafetyClassId )
        REFERENCES SafetyClasses ( SafetyClassId )
ON DELETE NO ACTION;
GO
 
ALTER TABLE Resources
    ADD CONSTRAINT Resources_EcologyClasses_FK FOREIGN KEY ( EcologyClasses_EcologyClassId )
        REFERENCES EcologyClasses ( EcologyClassId )
ON DELETE NO ACTION;
GO

ALTER TABLE Orders
    ADD CONSTRAINT Workers_OrderedBy_FK FOREIGN KEY ( Workers_OrderedBy )
        REFERENCES Workers ( WorkerId )
ON DELETE NO ACTION;
GO

ALTER TABLE Orders
    ADD CONSTRAINT Orders_OrderStatuses_FK FOREIGN KEY ( OrderStatuses_OrderStatusId)
        REFERENCES OrderStatuses ( OrderStatusId )
ON DELETE NO ACTION;
GO

ALTER TABLE Orders
    ADD CONSTRAINT Orders_Suppliers_FK FOREIGN KEY ( Suppliers_SupplierId)
        REFERENCES Suppliers ( SupplierId )
ON DELETE NO ACTION;
GO

ALTER TABLE OrderItems
    ADD CONSTRAINT OrderItems_Orders_FK FOREIGN KEY ( Orders_OrderId)
        REFERENCES Orders ( OrderId )
ON DELETE NO ACTION;
GO

ALTER TABLE OrderItems
    ADD CONSTRAINT OrderItems_Resources_FK FOREIGN KEY ( Resources_ResourceId)
        REFERENCES Resources ( ResourceId )
ON DELETE NO ACTION;
GO

ALTER TABLE SupplyItems
    ADD CONSTRAINT SupplyItems_OrderItems_FK FOREIGN KEY ( OrderItems_OrderItemId )
        REFERENCES OrderItems ( OrderItemId )
ON DELETE NO ACTION;
GO


ALTER TABLE SupplyItems
    ADD CONSTRAINT SupplyItems_Workers_FK FOREIGN KEY ( Workers_AcceptedBy )
        REFERENCES Workers ( WorkerId )
ON DELETE NO ACTION;
GO

ALTER TABLE Inventory
    ADD CONSTRAINT Inventory_Warehouses_FK FOREIGN KEY ( Warehouses_WarehouseId )
        REFERENCES Warehouses ( WarehouseId )
ON DELETE NO ACTION;
GO

ALTER TABLE Inventory
    ADD CONSTRAINT Inventory_Resources_FK FOREIGN KEY ( Resources_ResourceId )
        REFERENCES Resources ( ResourceId )
ON DELETE NO ACTION;
GO

ALTER TABLE SupplyItems
    ADD CONSTRAINT SupplyItems_Inventory_FK FOREIGN KEY ( Inventory_InventoryId )
        REFERENCES Inventory ( InventoryId )
ON DELETE NO ACTION;
GO

ALTER TABLE InventoryGivings
    ADD CONSTRAINT InventoryGivings_Inventory_FK FOREIGN KEY ( Inventory_InventoryId )
        REFERENCES Inventory ( InventoryId )
ON DELETE NO ACTION;
GO

ALTER TABLE InventoryGivings
    ADD CONSTRAINT InventoryGivings_ToWhom_FK FOREIGN KEY ( Workers_ToWhom )
        REFERENCES Workers ( WorkerId )
ON DELETE NO ACTION;
GO

ALTER TABLE InventoryGivings
    ADD CONSTRAINT InventoryGivings_ApprovedBy_FK FOREIGN KEY ( Workers_ApprovedBy )
        REFERENCES Workers ( WorkerId )
ON DELETE NO ACTION;
GO