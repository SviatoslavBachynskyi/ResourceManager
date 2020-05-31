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
	CountryId INTEGER NOT NULL
	);
GO

CREATE TABLE Cities
	(
	CityId INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL,
	DistrictId INTEGER NOT NULL
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
	ResourceCategoryId INTEGER NOT NULL
	);
GO

CREATE TABLE Resources 
    (
    ResourceId        INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(100) NOT NULL,
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
    PostId   INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
    Name     nvarchar (50) NOT NULL );
GO

CREATE TABLE Workers 
    (
    WorkerId    INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL, 
    FatherName NVARCHAR(50), 
    LastName NVARCHAR(50) NOT NULL,
	CityId INTEGER NOT NULL,
	Address NVARCHAR(200) NULL,
    PostId INTEGER NOT NULL );
GO

CREATE TABLE Warehouses
	(
	WarehouseId INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	WarehouseNumber INTEGER NOT NULL,
	Volume NUMERIC(18,3) NULL,
	CityId INTEGER NOT NULL,
	Address NVARCHAR(200) NULL,
	CONSTRAINT CityNumber UNIQUE(WarehouseNumber, CityId)
	);
GO

CREATE TABLE Suppliers 
    (
    SupplierId   INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
    Name         NVARCHAR(100) NOT NULL , 
    Address NVARCHAR(200) NOT NULL,
	Contact NVARCHAR(200) NOT NULL,
	CityId INTEGER NOT NULL);
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
	OrderStatusId INTEGER NOT NULL,
	OrderedById INTEGER NOT NULL,
	SupplierId INTEGER NOT NULL);
GO

CREATE TABLE OrderItems
    (
    OrderItemId   INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	ResourceId INTEGER NOT NULL,
	UnitPrice NUMERIC (18,2) NOT NULL,
	Quantity INTEGER NOT NULL,
	OrderId INTEGER NOT NULL);
GO

CREATE TABLE SupplyItems
	(
	SupplyItemId INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	OrderItemId INTEGER NOT NULL,
	InventoryId INTEGER NOT NULL,
	Quantity INTEGER NOT NULL,
	ArrivalDate   DATE NOT NULL,
	AcceptedById INTEGER NOT NULL
	);
GO

CREATE TABLE Inventory
	(
	InventoryId INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	InventoryNum VARCHAR(30) NOT NULL UNIQUE,
	WareHouseId INTEGER NOT NULL,
	ResourceId INTEGER NOT NULL,
	Quantity INTEGER NOT NULL,
	);
GO

CREATE TABLE InventoryGivings
	(
	InventoryGivingId INTEGER NOT NULL PRIMARY KEY IDENTITY (1,1),
	DateTime DATETIME NOT NULL,
	TakenById INTEGER NOT NULL,
	ApprovedById INTEGER NOT NULL,
	InventoryId INTEGER NOT NULL,
	Quantity INTEGER NOT NULL,
	Description NVARCHAR(1000) NULL
	);
GO

ALTER TABLE Warehouses
    ADD CONSTRAINT Warehouses_Cites_FK FOREIGN KEY (CityId)
        REFERENCES Cities (CityId)
ON DELETE NO ACTION;
GO

ALTER TABLE Suppliers
    ADD CONSTRAINT Suppliers_Cites_FK FOREIGN KEY (CityId)
        REFERENCES Cities (CityId)
ON DELETE NO ACTION;
GO

ALTER TABLE Workers
    ADD CONSTRAINT Workers_Cities_FK FOREIGN KEY (CityId)
        REFERENCES Cities (CityId)
ON DELETE NO ACTION;
GO

ALTER TABLE Workers
    ADD CONSTRAINT Workers_Posts_FK FOREIGN KEY (PostId)
        REFERENCES Posts (PostId)
ON DELETE NO ACTION;
GO

ALTER TABLE Districts
	ADD CONSTRAINT Districts_Countries_FK FOREIGN KEY (CountryId)
		REFERENCES Countries (CountryId)
ON DELETE NO ACTION;
GO

ALTER TABLE Cities
	ADD CONSTRAINT Cities_Districts_FK FOREIGN KEY (DistrictId)
		REFERENCES Districts (DistrictId)
ON DELETE NO ACTION;
GO


ALTER TABLE ResourceSubCategories
    ADD CONSTRAINT ResourceSubCategories_ResourceCategories_FK FOREIGN KEY (ResourceCategoryId)
        REFERENCES ResourceCategories (ResourceCategoryId)
ON DELETE NO ACTION;
GO

ALTER TABLE Resources
    ADD CONSTRAINT Resource_ResourceSubCategories_FK FOREIGN KEY (ResourceSubCategoryId)
        REFERENCES ResourceSubCategories (ResourceSubCategoryId)
ON DELETE NO ACTION;
GO

ALTER TABLE Resources
    ADD CONSTRAINT Resources_MeasuringUnits_FK FOREIGN KEY (MeasuringUnitId)
        REFERENCES MeasuringUnits (MeasuringUnitId)
ON DELETE NO ACTION;
GO

ALTER TABLE Resources
    ADD CONSTRAINT Resources_SafetyClasses_FK FOREIGN KEY (SafetyClassId)
        REFERENCES SafetyClasses (SafetyClassId)
ON DELETE NO ACTION;
GO
 
ALTER TABLE Resources
    ADD CONSTRAINT Resources_EcologyClasses_FK FOREIGN KEY (EcologyClassId)
        REFERENCES EcologyClasses (EcologyClassId)
ON DELETE NO ACTION;
GO

ALTER TABLE Orders
    ADD CONSTRAINT Workers_OrderedBy_FK FOREIGN KEY (OrderedById)
        REFERENCES Workers (WorkerId)
ON DELETE NO ACTION;
GO

ALTER TABLE Orders
    ADD CONSTRAINT Orders_OrderStatuses_FK FOREIGN KEY (OrderStatusId)
        REFERENCES OrderStatuses (OrderStatusId)
ON DELETE NO ACTION;
GO

ALTER TABLE Orders
    ADD CONSTRAINT Orders_Suppliers_FK FOREIGN KEY (SupplierId)
        REFERENCES Suppliers (SupplierId)
ON DELETE NO ACTION;
GO

ALTER TABLE OrderItems
    ADD CONSTRAINT OrderItems_Orders_FK FOREIGN KEY (OrderId)
        REFERENCES Orders (OrderId)
ON DELETE NO ACTION;
GO

ALTER TABLE OrderItems
    ADD CONSTRAINT OrderItems_Resources_FK FOREIGN KEY (ResourceId)
        REFERENCES Resources (ResourceId)
ON DELETE NO ACTION;
GO

ALTER TABLE SupplyItems
    ADD CONSTRAINT SupplyItems_OrderItems_FK FOREIGN KEY (OrderItemId)
        REFERENCES OrderItems (OrderItemId)
ON DELETE NO ACTION;
GO


ALTER TABLE SupplyItems
    ADD CONSTRAINT SupplyItems_Workers_FK FOREIGN KEY (AcceptedById)
        REFERENCES Workers (WorkerId)
ON DELETE NO ACTION;
GO

ALTER TABLE Inventory
    ADD CONSTRAINT Inventory_Warehouses_FK FOREIGN KEY (WarehouseId)
        REFERENCES Warehouses (WarehouseId)
ON DELETE NO ACTION;
GO

ALTER TABLE Inventory
    ADD CONSTRAINT Inventory_Resources_FK FOREIGN KEY (ResourceId)
        REFERENCES Resources (ResourceId)
ON DELETE NO ACTION;
GO

ALTER TABLE SupplyItems
    ADD CONSTRAINT SupplyItems_Inventory_FK FOREIGN KEY (InventoryId)
        REFERENCES Inventory (InventoryId)
ON DELETE NO ACTION;
GO

ALTER TABLE InventoryGivings
    ADD CONSTRAINT InventoryGivings_Inventory_FK FOREIGN KEY (InventoryId)
        REFERENCES Inventory (InventoryId)
ON DELETE NO ACTION;
GO

ALTER TABLE InventoryGivings
    ADD CONSTRAINT InventoryGivings_ToWhom_FK FOREIGN KEY (TakenById)
        REFERENCES Workers (WorkerId)
ON DELETE NO ACTION;
GO

ALTER TABLE InventoryGivings
    ADD CONSTRAINT InventoryGivings_ApprovedBy_FK FOREIGN KEY (ApprovedById)
        REFERENCES Workers (WorkerId)
ON DELETE NO ACTION;
GO