CREATE DATABASE ResourceManager3;
GO

USE ResourceManager3;

CREATE TABLE Countries
	(
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL UNIQUE
	);
GO

CREATE TABLE Districts
	(
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL,
	CountryId INTEGER NOT NULL,
	CONSTRAINT DistrictInCountry_UC UNIQUE(Name, CountryId)
);
GO

CREATE TABLE Cities
	(
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL,
	DistrictId INTEGER NOT NULL,
	CONSTRAINT CityInDistrict_UC UNIQUE(Name, DistrictId)
	);
GO

CREATE TABLE MeasuringUnits 
    (
    Id   INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL UNIQUE
	); 
GO

CREATE TABLE SafetyClasses
    (
    Id   INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
    CodeName NVARCHAR(50) NOT NULL UNIQUE
	); 
GO

CREATE TABLE EcologyClasses
    (
    Id   INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
    CodeName NVARCHAR(50) NOT NULL UNIQUE
	); 
GO

CREATE TABLE ResourceCategories
	(
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL UNIQUE
	);
GO

CREATE TABLE ResourceSubCategories
	(
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL,
	ResourceCategoryId INTEGER NOT NULL,
	CONSTRAINT SubCategoryInCategory_UC UNIQUE(Name, ResourceCategoryId)
	);
GO

CREATE TABLE Resources 
    (
    Id        INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(100) NOT NULL UNIQUE,
    ResourceSubCategoryId INTEGER NULL,
	MeasuringUnitId INTEGER NOT NULL,
	Description NVARCHAR(MAX) NULL,
	SafetyClassId INTEGER NULL,
	EcologyClassId INTEGER NULL,
	ShelfLife DATETIME NULL,
	NeedLicense BIT NULL,
	);
GO

CREATE TABLE Posts 
    (
    Id   INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR (50) NOT NULL UNIQUE
	);
GO

CREATE TABLE Workers 
    (
    Id    INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL, 
    FatherName NVARCHAR(50) NULL, 
    LastName NVARCHAR(50) NOT NULL,
	CityId INTEGER NOT NULL,
	Address NVARCHAR(200) NULL,
    PostId INTEGER NOT NULL
	);
GO

CREATE TABLE Warehouses
	(
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	WarehouseNumber INTEGER NOT NULL,
	Volume NUMERIC(18,3) NULL,
	CityId INTEGER NOT NULL,
	Address NVARCHAR(200) NULL,
	CONSTRAINT CityNumber_UC UNIQUE(WarehouseNumber, CityId)
	);
GO

CREATE TABLE Suppliers 
    (
    Id   INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL UNIQUE, 
    Address NVARCHAR(200) NOT NULL,
	Contact NVARCHAR(200) NOT NULL,
	CityId INTEGER NOT NULL);
GO

CREATE TABLE Supplies
	(
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	WayBillNumber VARCHAR(30) NULL UNIQUE,
	ArrivalDate   DATE NOT NULL,
	AcceptedById INTEGER NOT NULL
	);
GO

CREATE TABLE OrderStatuses
	(
	Id   INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50) UNIQUE
	);
GO

CREATE TABLE Orders
    (
    Id   INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	OrderNum NVARCHAR(20) NOT NULL UNIQUE,
	SupplyId INTEGER NULL,
	OrderPrice NUMERIC (18,2) NOT NULL,
	OrderDate DATETIME NOT NULL,
	ShipmentPrice NUMERIC (18,2) NOT NULL,
	TotalPrice NUMERIC (18,2) NOT NULL,
	CompleteDate DATETIME NULL,
	OrderStatusId INTEGER NOT NULL,
	OrderedById INTEGER NOT NULL,
	ApprovedById INTEGER NULL,
	SupplierId INTEGER NOT NULL);
GO

CREATE TABLE OrderItems
    (
    Id   INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	ResourceId INTEGER NOT NULL,
	UnitPrice NUMERIC (18,2) NOT NULL,
	Quantity INTEGER NOT NULL,
	OrderId INTEGER NOT NULL,
	CONSTRAINT ResourceInOrder_UC UNIQUE(ResourceId, OrderId)
	);
GO

CREATE TABLE Inventory
	(
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	InventoryNum VARCHAR(30) NOT NULL UNIQUE,
	WareHouseId INTEGER NOT NULL,
	ResourceId INTEGER NOT NULL,
	OrderItemId INTEGER NOT NULL,
	Quantity INTEGER NOT NULL,
	);
GO

CREATE TABLE InventoryGivingStatuses
	(
	Id   INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50) UNIQUE
	);
GO

CREATE TABLE InventoryGivings
	(
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY (1,1),
	InventoryGivingStatusId INTEGER NOT NULL,
	RequestDate DateTime NOT NULL,
	TakenById INTEGER NOT NULL,
	ApprovedById INTEGER NOT NULL,
	InventoryId INTEGER NOT NULL,
	Quantity INTEGER NOT NULL,
	Description NVARCHAR(1000) NULL
	);
GO

ALTER TABLE Warehouses
    ADD CONSTRAINT Warehouses_Cites_FK FOREIGN KEY (CityId)
        REFERENCES Cities (Id)
ON DELETE NO ACTION;
GO

ALTER TABLE Suppliers
    ADD CONSTRAINT Suppliers_Cites_FK FOREIGN KEY (CityId)
        REFERENCES Cities (Id)
ON DELETE NO ACTION;
GO

ALTER TABLE Workers
    ADD CONSTRAINT Workers_Cities_FK FOREIGN KEY (CityId)
        REFERENCES Cities (Id)
ON DELETE NO ACTION;
GO

ALTER TABLE Workers
    ADD CONSTRAINT Workers_Posts_FK FOREIGN KEY (PostId)
        REFERENCES Posts (Id)
ON DELETE NO ACTION;
GO

ALTER TABLE Districts
	ADD CONSTRAINT Districts_Countries_FK FOREIGN KEY (CountryId)
		REFERENCES Countries (Id)
ON DELETE NO ACTION;
GO

ALTER TABLE Cities
	ADD CONSTRAINT Cities_Districts_FK FOREIGN KEY (DistrictId)
		REFERENCES Districts (Id)
ON DELETE NO ACTION;
GO


ALTER TABLE ResourceSubCategories
    ADD CONSTRAINT ResourceSubCategories_ResourceCategories_FK FOREIGN KEY (ResourceCategoryId)
        REFERENCES ResourceCategories (Id)
ON DELETE NO ACTION;
GO

ALTER TABLE Resources
    ADD CONSTRAINT Resource_ResourceSubCategories_FK FOREIGN KEY (ResourceSubCategoryId)
        REFERENCES ResourceSubCategories (Id)
ON DELETE NO ACTION;
GO

ALTER TABLE Resources
    ADD CONSTRAINT Resources_MeasuringUnits_FK FOREIGN KEY (MeasuringUnitId)
        REFERENCES MeasuringUnits (Id)
ON DELETE NO ACTION;
GO

ALTER TABLE Resources
    ADD CONSTRAINT Resources_SafetyClasses_FK FOREIGN KEY (SafetyClassId)
        REFERENCES SafetyClasses (Id)
ON DELETE NO ACTION;
GO
 
ALTER TABLE Resources
    ADD CONSTRAINT Resources_EcologyClasses_FK FOREIGN KEY (EcologyClassId)
        REFERENCES EcologyClasses (Id)
ON DELETE NO ACTION;
GO

ALTER TABLE Supplies
    ADD CONSTRAINT Supplies_Workers_FK FOREIGN KEY (AcceptedById)
        REFERENCES Workers (Id)
ON DELETE NO ACTION;
GO

ALTER TABLE Orders
    ADD CONSTRAINT Workers_OrderedBy_FK FOREIGN KEY (OrderedById)
        REFERENCES Workers (Id)
ON DELETE NO ACTION;
GO

ALTER TABLE Orders
    ADD CONSTRAINT Workers_ApprovedBy_FK FOREIGN KEY (ApprovedById)
        REFERENCES Workers (Id)
ON DELETE NO ACTION;
GO

ALTER TABLE Orders
    ADD CONSTRAINT Orders_OrderStatuses_FK FOREIGN KEY (OrderStatusId)
        REFERENCES OrderStatuses (Id)
ON DELETE NO ACTION;
GO

ALTER TABLE Orders
    ADD CONSTRAINT Orders_Supplies_FK FOREIGN KEY (SupplyId)
        REFERENCES Supplies (Id)
ON DELETE NO ACTION;
GO

ALTER TABLE Orders
    ADD CONSTRAINT Orders_Suppliers_FK FOREIGN KEY (SupplierId)
        REFERENCES Suppliers (Id)
ON DELETE NO ACTION;
GO

ALTER TABLE OrderItems
    ADD CONSTRAINT OrderItems_Orders_FK FOREIGN KEY (OrderId)
        REFERENCES Orders (Id)
ON DELETE NO ACTION;
GO

ALTER TABLE OrderItems
    ADD CONSTRAINT OrderItems_Resources_FK FOREIGN KEY (ResourceId)
        REFERENCES Resources (Id)
ON DELETE NO ACTION;
GO

ALTER TABLE Inventory
    ADD CONSTRAINT Inventory_Warehouses_FK FOREIGN KEY (WarehouseId)
        REFERENCES Warehouses (Id)
ON DELETE NO ACTION;
GO

ALTER TABLE Inventory
    ADD CONSTRAINT Inventory_Resources_FK FOREIGN KEY (ResourceId)
        REFERENCES Resources (Id)
ON DELETE NO ACTION;
GO

ALTER TABLE Inventory
    ADD CONSTRAINT Inventory_OrderItems_FK FOREIGN KEY (OrderItemId)
        REFERENCES OrderItems (Id)
ON DELETE NO ACTION;
GO

ALTER TABLE InventoryGivings
    ADD CONSTRAINT InventoryGivings_InventoryGivningStatuses_FK FOREIGN KEY (InventoryGivingStatusId)
        REFERENCES InventoryGivningStatuses (Id)
ON DELETE NO ACTION;
GO

ALTER TABLE InventoryGivings
    ADD CONSTRAINT InventoryGivings_Inventory_FK FOREIGN KEY (InventoryId)
        REFERENCES Inventory (Id)
ON DELETE NO ACTION;
GO

ALTER TABLE InventoryGivings
    ADD CONSTRAINT InventoryGivings_ToWhom_FK FOREIGN KEY (TakenById)
        REFERENCES Workers (Id)
ON DELETE NO ACTION;
GO

ALTER TABLE InventoryGivings
    ADD CONSTRAINT InventoryGivings_ApprovedBy_FK FOREIGN KEY (ApprovedById)
        REFERENCES Workers (Id)
ON DELETE NO ACTION;
GO