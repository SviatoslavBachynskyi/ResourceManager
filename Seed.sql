﻿USE ResourceManager2;

INSERT INTO Posts(Name) VALUES
('Завгосп')
,('Двірник')
,('Менеджер')
,('Бухгалтер')
,('Головний бухгалтер')
,('Директор')
,('Кур''єр')
,('Бізнес-аналітик')
;
GO

INSERT INTO Countries(Name) VALUES
('Україна');
GO

INSERT INTO Districts(Name, Countries_CountryId) SELECT 'Львівська' ,CountryId FROM Countries WHERE Name = 'Україна';
INSERT INTO Districts(Name, Countries_CountryId) SELECT 'Харківська' ,CountryId FROM Countries WHERE Name = 'Україна';
INSERT INTO Districts(Name, Countries_CountryId) SELECT 'Київська' ,CountryId FROM Countries WHERE Name = 'Україна';
INSERT INTO Districts(Name, Countries_CountryId) SELECT 'Волинська' ,CountryId FROM Countries WHERE Name = 'Україна';
INSERT INTO Districts(Name, Countries_CountryId) SELECT 'Одеська' ,CountryId FROM Countries WHERE Name = 'Україна';
INSERT INTO Districts(Name, Countries_CountryId) SELECT 'Дніпропетровська' ,CountryId FROM Countries WHERE Name = 'Україна';
GO
 
INSERT INTO Cities(Name, Districts_DistrictId) SELECT 'Львів', DistrictId FROM Districts WHERE Name = 'Львівська';
INSERT INTO Cities(Name, Districts_DistrictId) SELECT 'Харків', DistrictId FROM Districts WHERE Name = 'Харківська';
INSERT INTO Cities(Name, Districts_DistrictId) SELECT 'Київ', DistrictId FROM Districts WHERE Name = 'Київська';
INSERT INTO Cities(Name, Districts_DistrictId) SELECT 'Луцьк', DistrictId FROM Districts WHERE Name = 'Волинська';
INSERT INTO Cities(Name, Districts_DistrictId) SELECT 'Одеса', DistrictId FROM Districts WHERE Name = 'Одеська';
INSERT INTO Cities(Name, Districts_DistrictId) SELECT 'Кривий Ріг', DistrictId FROM Districts WHERE Name = 'Дніпропетровська';
GO

INSERT INTO Workers(FirstName, FatherName, LastName, Posts_PostId, Cities_CityId, Address)
SELECT 'Іван', 'Васильович','Петренко', PostId, CityId, 'вул. Дніпровська 10' FROM Posts p, Cities ct WHERE p.Name = 'Двірник' AND ct.Name='Львів';

INSERT INTO Workers(FirstName, FatherName, LastName, Posts_PostId, Cities_CityId, Address)
SELECT 'Антон', 'Іванович','Андрієнко', PostId, CityId, 'вул. Миколи Лисенка 5' FROM Posts p, Cities ct WHERE p.Name = 'Двірник' AND ct.Name='Львів';

INSERT INTO Workers(FirstName, FatherName, LastName, Posts_PostId, Cities_CityId, Address)
SELECT 'Петро', 'Васильович','Іваненко', PostId, CityId, 'вул. Лукаша 5' FROM Posts p, Cities ct WHERE p.Name = 'Завгосп' AND ct.Name='Львів';

INSERT INTO Workers(FirstName, FatherName, LastName, Posts_PostId, Cities_CityId, Address)
SELECT 'Остап', 'Анатолійович','Вишня', PostId, CityId, 'вул. Кульпарківська 7' FROM Posts p, Cities ct WHERE p.Name = 'Менеджер' AND ct.Name='Львів';

INSERT INTO Workers(FirstName, FatherName, LastName, Posts_PostId, Cities_CityId, Address)
SELECT 'Олена', 'Андріївна','Васильєва', PostId, CityId, 'пров. Волкова, 36' FROM Posts p, Cities ct WHERE p.Name = 'Бухгалтер' AND ct.Name='Львів';

INSERT INTO Workers(FirstName, FatherName, LastName, Posts_PostId, Cities_CityId, Address)
SELECT 'Федір', 'Йосипович','Броварчук', PostId, CityId, 'вул. Заміська 35' FROM Posts p, Cities ct WHERE p.Name = 'Кур''єр' AND ct.Name='Львів';

INSERT INTO Workers(FirstName, FatherName, LastName, Posts_PostId, Cities_CityId, Address)
SELECT 'Марія', 'Сергійович','Шинкаренко', PostId, CityId, 'вул. Жовківська	18' FROM Posts p, Cities ct WHERE p.Name = 'Кур''єр' AND ct.Name='Львів';

INSERT INTO Workers(FirstName, FatherName, LastName, Posts_PostId, Cities_CityId, Address)
SELECT 'Валентина', 'Романівна','Броваренко', PostId, CityId, 'вул. Галицька 30' FROM Posts p, Cities ct WHERE p.Name = 'Двірник' AND ct.Name='Львів';

INSERT INTO Workers(FirstName, FatherName, LastName, Posts_PostId, Cities_CityId, Address)
SELECT 'Андрій', 'Віталійович','Кравчина', PostId, CityId, 'пров. Гагаріна, 28' FROM Posts p, Cities ct WHERE p.Name = 'Менеджер' AND ct.Name='Київ';

INSERT INTO Workers(FirstName, FatherName, LastName, Posts_PostId, Cities_CityId, Address)
SELECT 'Юрій', 'Петрович','Іванченко', PostId, CityId, 'вул. Дніпровська 10' FROM Posts p, Cities ct WHERE p.Name = 'Директор' AND ct.Name='Київ';

INSERT INTO Workers(FirstName, FatherName, LastName, Posts_PostId, Cities_CityId, Address)
SELECT 'Тетяна', 'Валентинівна', 'Сергієнко', PostId, CityId, 'вул. Михайла Грушевського, 72' FROM Posts p, Cities ct WHERE p.Name = 'Завгосп' AND ct.Name='Київ';

INSERT INTO Workers(FirstName, FatherName, LastName, Posts_PostId, Cities_CityId, Address)
SELECT 'Олександр', 'Миколайович','Пономарчук', PostId, CityId, 'пл. Тараса Шевченка, 18' FROM Posts p, Cities ct WHERE p.Name = 'Бізнес-аналітик' AND ct.Name='Київ';

INSERT INTO Workers(FirstName, FatherName, LastName, Posts_PostId, Cities_CityId, Address)
SELECT 'Єлизавета', 'Євгеновівна','Шинкаренко', PostId, CityId, 'пл. Леніна, 31' FROM Posts p, Cities ct WHERE p.Name = 'Двірник' AND ct.Name='Київ';

INSERT INTO Workers(FirstName, FatherName, LastName, Posts_PostId, Cities_CityId, Address)
SELECT 'Леонід', 'Янович','Боднаренко', PostId, CityId, 'просп. Тараса Шевченка, 41' FROM Posts p, Cities ct WHERE p.Name = 'Кур''єр' AND ct.Name='Київ';

INSERT INTO Workers(FirstName, FatherName, LastName, Posts_PostId, Cities_CityId, Address)
SELECT 'Єлизавета', 'Петрівна','Середа', PostId, CityId, 'вул. Михайла Грушевського, 70' FROM Posts p, Cities ct WHERE p.Name = 'Головний бухгалтер' AND ct.Name='Київ';

INSERT INTO Workers(FirstName, FatherName, LastName, Posts_PostId, Cities_CityId, Address)
SELECT 'Федір', 'Сергійович','Шевчук', PostId, CityId, 'просп. Тараса Шевченка, 62' FROM Posts p, Cities ct WHERE p.Name = 'Менеджер' AND ct.Name='Харків';

INSERT INTO Workers(FirstName, FatherName, LastName, Posts_PostId, Cities_CityId, Address)
SELECT 'Артем', 'Олександрович','Захарчук', PostId, CityId, 'вул. Пацаєва, 31' FROM Posts p, Cities ct WHERE p.Name = 'Кур''єр' AND ct.Name='Харків';

INSERT INTO Workers(FirstName, FatherName, LastName, Posts_PostId, Cities_CityId, Address)
SELECT 'B''ячеслав', 'Євгенійович','Лисенко', PostId, CityId, 'пл. Михайла Грушевського, 60' FROM Posts p, Cities ct WHERE p.Name = 'Завгосп' AND ct.Name='Харків';

INSERT INTO Workers(FirstName, FatherName, LastName, Posts_PostId, Cities_CityId, Address)
SELECT 'Софія', 'Анатоліївна','Панасюк', PostId, CityId, 'пров. Тараса Шевченка, 15' FROM Posts p, Cities ct WHERE p.Name = 'Бухгалтер' AND ct.Name='Харків';

INSERT INTO Workers(FirstName, FatherName, LastName, Posts_PostId, Cities_CityId, Address)
SELECT 'Генадій', 'Олександрович','Артемів', PostId, CityId, 'вул. Малиновського 22' FROM Posts p, Cities ct WHERE p.Name = 'Двірник' AND ct.Name='Харків';
GO

INSERT INTO Warehouses (WarehouseNumber, Volume, Address, Cities_CityId)
SELECT 1, 300, 'вул. Городоцька, 105', CityId FROM Cities WHERE Name = 'Львів';

INSERT INTO Warehouses (WarehouseNumber, Volume, Address, Cities_CityId)
SELECT 2, 250, 'вул. Кульпарківська, 23', CityId FROM Cities WHERE Name = 'Львів';

INSERT INTO Warehouses (WarehouseNumber, Volume, Address, Cities_CityId)
SELECT 1, 300, 'вул. Електротехнічна, 4', CityId FROM Cities WHERE Name = 'Київ';

INSERT INTO Warehouses (WarehouseNumber, Volume, Address, Cities_CityId)
SELECT 2, 350, 'вул. Володимира Винниченка, 11', CityId FROM Cities WHERE Name = 'Київ';

INSERT INTO Warehouses (WarehouseNumber, Volume, Address, Cities_CityId)
SELECT 1, 500, 'вул. Заводська, 30', CityId FROM Cities WHERE Name = 'Харків';

INSERT INTO Warehouses (WarehouseNumber, Volume, Address, Cities_CityId)
SELECT 2, 400, 'вул. Квітки-Основ''яненка, 13', CityId FROM Cities WHERE Name = 'Харків';
GO


INSERT INTO Suppliers (Name, Address, Contact, Cities_CityId)
SELECT 'ООО “ВЕЛЮКС Украина”', 'вул. Ревуцокого, 44а' ,'+380996265290', CityId FROM Cities WHERE Name = 'Київ';

INSERT INTO Suppliers (Name, Address, Contact, Cities_CityId)
SELECT 'ООО "Торговый Дом "ЕВРОТОН"', 'вул. Єршова, 11' ,'+380631737711', CityId FROM Cities WHERE Name = 'Луцьк';

INSERT INTO Suppliers (Name, Address, Contact, Cities_CityId)
SELECT 'ТзОВ «Апельсин»"', 'вул. Рівненська 76 а' ,'+380964176588', CityId FROM Cities WHERE Name = 'Луцьк';

INSERT INTO Suppliers (Name, Address, Contact, Cities_CityId)
SELECT 'Компанія «Імпорт-офіс Україна»', 'вул. Пирогівський шлях 34В' ,'+380444619687', CityId FROM Cities WHERE Name = 'Київ';

INSERT INTO Suppliers (Name, Address, Contact, Cities_CityId)
SELECT 'АЗК WOG', 'вул. Рудненська, 8' ,'+380322475776', CityId FROM Cities WHERE Name = 'Львів';

INSERT INTO Suppliers (Name, Address, Contact, Cities_CityId)
SELECT 'ПАТ "Північний гірничо-збагачувальний комбінат"', '' ,'+380964975900', CityId FROM Cities WHERE Name = 'Кривий Ріг';

INSERT INTO Suppliers (Name, Address, Contact, Cities_CityId)
SELECT 'ПАТ "Криворізький залізорудний комбінат"', 'вул. Симбірцева, 1-А' ,'+380564442300', CityId FROM Cities WHERE Name = 'Кривий Ріг';
GO

INSERT INTO Suppliers (Name, Address, Contact, Cities_CityId)
SELECT 'Bpsferallc', 'вул. Леніна, 44' ,'+380638372234', CityId FROM Cities WHERE Name = 'Харків';
GO

INSERT INTO MeasuringUnits(Name) VALUES
('Штуки')
,('Кілограми')
,('Літри')
,('Сантиметри')
,(N'м³')
;
GO

INSERT INTO EcologyClasses(CodeName) VALUES
('I')
,('II')
,('III')
,('IV');
GO

INSERT INTO SafetyClasses(CodeName) VALUES
('E')
,('O')
,('F')
,('F+')
,('T')
,('T+')
,('C')
,('Xn')
,('Xi');
GO

INSERT INTO ResourceCategories(Name) VALUES
('Будівельні матеріали')
,('Інструменти')
,('Витратні матеріали')
GO

INSERT INTO ResourceSubCategories(Name, ResourceCategories_ResourceCategoryId)
SELECT 'Природнього походження', ResourceCategoryId  FROM ResourceCategories WHERE Name='Будівельні матеріали';

INSERT INTO ResourceSubCategories(Name, ResourceCategories_ResourceCategoryId)
SELECT 'Метал', ResourceCategoryId  FROM ResourceCategories WHERE Name='Будівельні матеріали';

INSERT INTO ResourceSubCategories(Name, ResourceCategories_ResourceCategoryId)
SELECT 'В''яжучі речовини', ResourceCategoryId  FROM ResourceCategories WHERE Name='Будівельні матеріали';

INSERT INTO ResourceSubCategories(Name, ResourceCategories_ResourceCategoryId)
SELECT 'Камінні', ResourceCategoryId  FROM ResourceCategories WHERE Name='Будівельні матеріали';

INSERT INTO ResourceSubCategories(Name, ResourceCategories_ResourceCategoryId)
SELECT 'Розчини', ResourceCategoryId  FROM ResourceCategories WHERE Name='Будівельні матеріали';

INSERT INTO ResourceSubCategories(Name, ResourceCategories_ResourceCategoryId)
SELECT 'Спеціальні будматеріали', ResourceCategoryId  FROM ResourceCategories WHERE Name='Будівельні матеріали';

INSERT INTO ResourceSubCategories(Name, ResourceCategories_ResourceCategoryId)
SELECT 'Для прибирання', ResourceCategoryId  FROM ResourceCategories WHERE Name='Інструменти';

INSERT INTO ResourceSubCategories(Name, ResourceCategories_ResourceCategoryId)
SELECT 'Загального призначення', ResourceCategoryId  FROM ResourceCategories WHERE Name='Інструменти'

INSERT INTO ResourceSubCategories(Name, ResourceCategories_ResourceCategoryId)
SELECT 'Для ремонту', ResourceCategoryId  FROM ResourceCategories WHERE Name='Інструменти';

INSERT INTO ResourceSubCategories(Name, ResourceCategories_ResourceCategoryId)
SELECT 'Канцтовари', ResourceCategoryId  FROM ResourceCategories WHERE Name='Витратні матеріали';

INSERT INTO ResourceSubCategories(Name, ResourceCategories_ResourceCategoryId)
SELECT 'Паливо', ResourceCategoryId  FROM ResourceCategories WHERE Name='Витратні матеріали';

INSERT INTO ResourceSubCategories(Name, ResourceCategories_ResourceCategoryId)
SELECT 'Сировина', ResourceCategoryId  FROM ResourceCategories WHERE Name='Витратні матеріали';
GO


INSERT INTO Resources(Name, MeasuringUnits_MeasuringUnitId, NeedLicense, ResourceSubCategories_ResourceSubCategoryId)
SELECT 'Лопата', MeasuringUnitId, 0, ResourceSubCategoryId FROM MeasuringUnits mu, ResourceSubCategories rsc
WHERE mu.Name = 'Штуки' AND rsc.Name = 'Загального призначення';

INSERT INTO Resources(Name, MeasuringUnits_MeasuringUnitId, NeedLicense, ResourceSubCategories_ResourceSubCategoryId)
SELECT 'Мітла', MeasuringUnitId, 0, ResourceSubCategoryId FROM MeasuringUnits mu, ResourceSubCategories rsc
WHERE mu.Name = 'Штуки' AND rsc.Name = 'Для прибирання';

INSERT INTO Resources(Name, MeasuringUnits_MeasuringUnitId, NeedLicense, ResourceSubCategories_ResourceSubCategoryId)
SELECT 'Упаковка Паперу А4 500шт', MeasuringUnitId, 0, ResourceSubCategoryId FROM MeasuringUnits mu, ResourceSubCategories rsc
WHERE mu.Name = 'Штуки' AND rsc.Name = 'Канцтовари';

INSERT INTO Resources(Name, MeasuringUnits_MeasuringUnitId, NeedLicense, ResourceSubCategories_ResourceSubCategoryId)
SELECT 'Картирдж для принтера', MeasuringUnitId, 0, ResourceSubCategoryId FROM MeasuringUnits mu, ResourceSubCategories rsc
WHERE mu.Name = 'Штуки' AND rsc.Name = 'Канцтовари';

INSERT INTO Resources(Name, MeasuringUnits_MeasuringUnitId, NeedLicense, ResourceSubCategories_ResourceSubCategoryId)
SELECT 'Кулькова ручка', MeasuringUnitId, 0, ResourceSubCategoryId FROM MeasuringUnits mu, ResourceSubCategories rsc
WHERE mu.Name = 'Штуки' AND rsc.Name = 'Канцтовари';

INSERT INTO Resources(Name, MeasuringUnits_MeasuringUnitId, ResourceSubCategories_ResourceSubCategoryId, EcologyClasses_EcologyClassId, SafetyClasses_SafetyClassId)
SELECT 'Біла фарба', MeasuringUnitId, ResourceSubCategoryId, EcologyClassId, SafetyClassId
FROM MeasuringUnits mu, ResourceSubCategories rsc, EcologyClasses EC, SafetyClasses SC
WHERE mu.Name = 'Літри' AND rsc.Name = 'Спеціальні будматеріали' AND EC.CodeName='II' AND SC.CodeName='T';

INSERT INTO Resources(Name, MeasuringUnits_MeasuringUnitId, ResourceSubCategories_ResourceSubCategoryId, EcologyClasses_EcologyClassId, SafetyClasses_SafetyClassId)
SELECT 'Клей', MeasuringUnitId, ResourceSubCategoryId, EcologyClassId, SafetyClassId
FROM MeasuringUnits mu, ResourceSubCategories rsc, EcologyClasses EC, SafetyClasses SC
WHERE mu.Name = 'Літри' AND rsc.Name = 'В''яжучі речовини' AND EC.CodeName='II' AND SC.CodeName='T';

INSERT INTO Resources(Name, MeasuringUnits_MeasuringUnitId, ResourceSubCategories_ResourceSubCategoryId, EcologyClasses_EcologyClassId, SafetyClasses_SafetyClassId)
SELECT 'Бензин А-95', MeasuringUnitId, ResourceSubCategoryId, EcologyClassId, SafetyClassId
FROM MeasuringUnits mu, ResourceSubCategories rsc, EcologyClasses EC, SafetyClasses SC
WHERE mu.Name = 'Літри' AND rsc.Name = 'Паливо' AND EC.CodeName='II' AND SC.CodeName='F+';

INSERT INTO Resources(Name, MeasuringUnits_MeasuringUnitId, ResourceSubCategories_ResourceSubCategoryId, SafetyClasses_SafetyClassId)
SELECT 'Дрова', MeasuringUnitId, ResourceSubCategoryId, SafetyClassId
FROM MeasuringUnits mu, ResourceSubCategories rsc, SafetyClasses SC
WHERE mu.Name = N'м³' AND rsc.Name = 'Паливо' AND SC.CodeName='F';

INSERT INTO Resources(Name, MeasuringUnits_MeasuringUnitId, ResourceSubCategories_ResourceSubCategoryId, SafetyClasses_SafetyClassId)
SELECT 'Вугілля', MeasuringUnitId, ResourceSubCategoryId, SafetyClassId
FROM MeasuringUnits mu, ResourceSubCategories rsc, SafetyClasses SC
WHERE mu.Name = 'Кілограми' AND rsc.Name = 'Паливо' AND SC.CodeName='F';

INSERT INTO Resources(Name, MeasuringUnits_MeasuringUnitId, ResourceSubCategories_ResourceSubCategoryId, EcologyClasses_EcologyClassId, SafetyClasses_SafetyClassId)
SELECT 'Сірка', MeasuringUnitId, ResourceSubCategoryId, EcologyClassId, SafetyClassId
FROM MeasuringUnits mu, ResourceSubCategories rsc, EcologyClasses EC, SafetyClasses SC
WHERE mu.Name = 'Кілограми' AND rsc.Name = 'Сировина' AND EC.CodeName='III' AND SC.CodeName='E';

INSERT INTO Resources(Name, MeasuringUnits_MeasuringUnitId, NeedLicense, ResourceSubCategories_ResourceSubCategoryId, EcologyClasses_EcologyClassId, SafetyClasses_SafetyClassId)
SELECT 'Фосфор', MeasuringUnitId, 1, ResourceSubCategoryId, EcologyClassId, SafetyClassId
FROM MeasuringUnits mu, ResourceSubCategories rsc, EcologyClasses EC, SafetyClasses SC
WHERE mu.Name = 'Кілограми' AND rsc.Name = 'Сировина' AND EC.CodeName='I' AND SC.CodeName='C';

INSERT INTO Resources(Name, MeasuringUnits_MeasuringUnitId, ResourceSubCategories_ResourceSubCategoryId, EcologyClasses_EcologyClassId, SafetyClasses_SafetyClassId)
SELECT 'Натрій', MeasuringUnitId, ResourceSubCategoryId, EcologyClassId, SafetyClassId
FROM MeasuringUnits mu, ResourceSubCategories rsc, EcologyClasses EC, SafetyClasses SC
WHERE mu.Name = 'Кілограми' AND rsc.Name = 'Сировина' AND EC.CodeName='I' AND SC.CodeName='C';

INSERT INTO Resources(Name, MeasuringUnits_MeasuringUnitId, ResourceSubCategories_ResourceSubCategoryId, EcologyClasses_EcologyClassId, SafetyClasses_SafetyClassId)
SELECT 'Магній', MeasuringUnitId, ResourceSubCategoryId, EcologyClassId, SafetyClassId
FROM MeasuringUnits mu, ResourceSubCategories rsc, EcologyClasses EC, SafetyClasses SC
WHERE mu.Name = 'Кілограми' AND rsc.Name = 'Сировина' AND EC.CodeName='I' AND SC.CodeName='C';

INSERT INTO Resources(Name, MeasuringUnits_MeasuringUnitId, ResourceSubCategories_ResourceSubCategoryId, EcologyClasses_EcologyClassId, SafetyClasses_SafetyClassId)
SELECT 'Асбест', MeasuringUnitId, ResourceSubCategoryId, EcologyClassId, SafetyClassId
FROM MeasuringUnits mu, ResourceSubCategories rsc, EcologyClasses EC, SafetyClasses SC
WHERE mu.Name = 'Кілограми' AND rsc.Name = 'Сировина' AND EC.CodeName='I' AND SC.CodeName='C';

INSERT INTO Resources(Name, MeasuringUnits_MeasuringUnitId, ResourceSubCategories_ResourceSubCategoryId)
SELECT 'Залізна руда', MeasuringUnitId, ResourceSubCategoryId
FROM MeasuringUnits mu, ResourceSubCategories rsc
WHERE mu.Name = 'Кілограми' AND rsc.Name = 'Сировина';
GO

INSERT INTO OrderStatuses(Name) VALUES
('Нове'),
('Виконується'),
('Скасоване'),
('Завершене');
GO

--ORDER1
INSERT INTO Orders(WayBillNumber, OrderPrice, OrderDate, ShipmentPrice, TotalPrice, CompleteDate,
OrderStatuses_OrderStatusId, Workers_OrderedBy, Suppliers_SupplierId)
SELECT 'T00001', 1150, '2020/03/20', 53, 1203,'2020/03/25', OrderStatusId, WorkerId, SupplierId 
FROM OrderStatuses os, Workers w, Suppliers s
WHERE os.Name='Завершене' AND W.LastName='Петренко' AND s.Name = 'ООО “ВЕЛЮКС Украина”';

INSERT INTO OrderItems(Orders_OrderId, Resources_ResourceId, UnitPrice, Quantity)
SELECT  OrderId, ResourceId, 90, 5
FROM Orders, Resources r
WHERE WayBillNumber='T00001' AND r.Name = 'Лопата';

INSERT INTO OrderItems(Orders_OrderId, Resources_ResourceId, UnitPrice, Quantity)
SELECT  OrderId, ResourceId, 70, 10
FROM Orders, Resources r
WHERE WayBillNumber='T00001' AND r.Name = 'Мітла';

INSERT INTO Inventory (InventoryNum, Quantity, Resources_ResourceId, Warehouses_WareHouseId)
SELECT 'R00001', 5, ResourceId, WarehouseId
FROM Resources r, Warehouses w JOIN Cities c ON w.Cities_CityId=c.CityId 
WHERE r.Name = 'Лопата' AND WarehouseNumber = 1 AND c.Name = 'Львів';

INSERT INTO Inventory (InventoryNum, Quantity, Resources_ResourceId, Warehouses_WareHouseId)
SELECT 'R00002', 10, ResourceId, WarehouseId
FROM Resources r, Warehouses w JOIN Cities c ON w.Cities_CityId=c.CityId 
WHERE r.Name = 'Мітла' AND WarehouseNumber = 1 AND c.Name = 'Львів';

INSERT INTO SupplyItems (OrderItems_OrderItemId, Quantity, Inventory_InventoryId, ArrivalDate, Workers_AcceptedBy)
SELECT OrderItemId, 5, InventoryId, '2020/03/25', WorkerId
FROM Workers, OrderItems oi JOIN Inventory iv ON oi.Resources_ResourceId = iv.Resources_ResourceId
JOIN Orders o ON o.OrderId = Orders_OrderId
WHERE InventoryNum = 'R00001' AND LastName = 'Іваненко' AND WayBillNumber = 'T00001';

INSERT INTO SupplyItems (OrderItems_OrderItemId, Quantity, Inventory_InventoryId, ArrivalDate, Workers_AcceptedBy)
SELECT OrderItemId, 10, InventoryId, '2020/03/25', WorkerId
FROM Workers, OrderItems oi JOIN Inventory iv ON oi.Resources_ResourceId = iv.Resources_ResourceId
JOIN Orders o ON o.OrderId = Orders_OrderId
WHERE InventoryNum = 'R00002' AND LastName = 'Іваненко' AND WayBillNumber = 'T00001';

--Order2
INSERT INTO Orders(WayBillNumber, OrderPrice, OrderDate, ShipmentPrice, TotalPrice, CompleteDate,
OrderStatuses_OrderStatusId, Workers_OrderedBy, Suppliers_SupplierId)
SELECT 'T00002', 800, '2020/03/20', 45, 845,'2020/03/22', OrderStatusId, WorkerId, SupplierId 
FROM OrderStatuses os, Workers w, Suppliers s
WHERE os.Name='Завершене' AND W.LastName='Середа' AND s.Name = 'Компанія «Імпорт-офіс Україна»';

INSERT INTO OrderItems(Orders_OrderId, Resources_ResourceId, UnitPrice, Quantity)
SELECT  OrderId, ResourceId, 100, 3
FROM Orders, Resources r
WHERE WayBillNumber='T00002' AND r.Name = 'Упаковка Паперу А4 500шт';

INSERT INTO OrderItems(Orders_OrderId, Resources_ResourceId, UnitPrice, Quantity)
SELECT  OrderId, ResourceId, 250, 2
FROM Orders, Resources r
WHERE WayBillNumber='T00002' AND r.Name = 'Картирдж для принтера';

INSERT INTO Inventory (InventoryNum, Quantity, Resources_ResourceId, Warehouses_WareHouseId)
SELECT 'R00003', 3, ResourceId, WarehouseId
FROM Resources r, Warehouses w JOIN Cities c ON w.Cities_CityId=c.CityId 
WHERE r.Name = 'Упаковка Паперу А4 500шт' AND WarehouseNumber = 1 AND c.Name = 'Київ';

INSERT INTO Inventory (InventoryNum, Quantity, Resources_ResourceId, Warehouses_WareHouseId)
SELECT 'R00004', 2, ResourceId, WarehouseId
FROM Resources r, Warehouses w JOIN Cities c ON w.Cities_CityId=c.CityId 
WHERE r.Name = 'Картирдж для принтера' AND WarehouseNumber = 1 AND c.Name = 'Київ';

INSERT INTO SupplyItems (OrderItems_OrderItemId, Quantity, Inventory_InventoryId, ArrivalDate, Workers_AcceptedBy)
SELECT OrderItemId, 3, InventoryId, '2020/03/22', WorkerId
FROM Workers, OrderItems oi JOIN Inventory iv ON oi.Resources_ResourceId = iv.Resources_ResourceId
JOIN Orders o ON o.OrderId = Orders_OrderId
WHERE InventoryNum = 'R00003' AND LastName = 'Сергієнко' AND WayBillNumber = 'T00002';

INSERT INTO SupplyItems (OrderItems_OrderItemId, Quantity, Inventory_InventoryId, ArrivalDate, Workers_AcceptedBy)
SELECT OrderItemId, 2, InventoryId, '2020/03/22', WorkerId
FROM Workers, OrderItems oi JOIN Inventory iv ON oi.Resources_ResourceId = iv.Resources_ResourceId
JOIN Orders o ON o.OrderId = Orders_OrderId
WHERE InventoryNum = 'R00004' AND LastName = 'Сергієнко' AND WayBillNumber = 'T00002';

--Order3
INSERT INTO Orders(WayBillNumber, OrderPrice, OrderDate, ShipmentPrice, TotalPrice, CompleteDate,
OrderStatuses_OrderStatusId, Workers_OrderedBy, Suppliers_SupplierId)
SELECT 'T00003', 1000, '2020/03/17', 70, 1070,'2020/03/19', OrderStatusId, WorkerId, SupplierId 
FROM OrderStatuses os, Workers w, Suppliers s
WHERE os.Name='Завершене' AND W.LastName='Вишня' AND s.Name = 'ТзОВ «Апельсин»"';

INSERT INTO OrderItems(Orders_OrderId, Resources_ResourceId, UnitPrice, Quantity)
SELECT  OrderId, ResourceId, 10, 100
FROM Orders, Resources r
WHERE WayBillNumber='T00003' AND r.Name = 'Кулькова ручка';

INSERT INTO Inventory (InventoryNum, Quantity, Resources_ResourceId, Warehouses_WareHouseId)
SELECT 'R00005', 100, ResourceId, WarehouseId
FROM Resources r, Warehouses w JOIN Cities c ON w.Cities_CityId=c.CityId 
WHERE r.Name = 'Кулькова ручка' AND WarehouseNumber = 2 AND c.Name = 'Львів';

INSERT INTO SupplyItems (OrderItems_OrderItemId, Quantity, Inventory_InventoryId, ArrivalDate, Workers_AcceptedBy)
SELECT OrderItemId, 100, InventoryId, '2020/03/19', WorkerId
FROM Workers, OrderItems oi JOIN Inventory iv ON oi.Resources_ResourceId = iv.Resources_ResourceId
JOIN Orders o ON o.OrderId = Orders_OrderId
WHERE InventoryNum = 'R00005' AND LastName = 'Іваненко' AND WayBillNumber = 'T00003';

--Order5
INSERT INTO Orders(WayBillNumber, OrderPrice, OrderDate, ShipmentPrice, TotalPrice, CompleteDate,
OrderStatuses_OrderStatusId, Workers_OrderedBy, Suppliers_SupplierId)
SELECT 'T00005', 2900, '2020/04/03', 118, 3018,'2020/04/06', OrderStatusId, WorkerId, SupplierId 
FROM OrderStatuses os, Workers w, Suppliers s
WHERE os.Name='Завершене' AND W.LastName='Кравчина' AND s.Name = 'ООО “ВЕЛЮКС Украина”';

INSERT INTO OrderItems(Orders_OrderId, Resources_ResourceId, UnitPrice, Quantity)
SELECT  OrderId, ResourceId, 20, 20
FROM Orders, Resources r
WHERE WayBillNumber='T00005' AND r.Name = 'Клей';

INSERT INTO Inventory (InventoryNum, Quantity, Resources_ResourceId, Warehouses_WareHouseId)
SELECT 'R00010', 20, ResourceId, WarehouseId
FROM Resources r, Warehouses w JOIN Cities c ON w.Cities_CityId=c.CityId 
WHERE r.Name = 'Клей' AND WarehouseNumber = 1 AND c.Name = 'Київ';

INSERT INTO SupplyItems (OrderItems_OrderItemId, Quantity, Inventory_InventoryId, ArrivalDate, Workers_AcceptedBy)
SELECT OrderItemId, 20, InventoryId, '2020/04/06', WorkerId
FROM Workers, OrderItems oi JOIN Inventory iv ON oi.Resources_ResourceId = iv.Resources_ResourceId
JOIN Orders o ON o.OrderId = Orders_OrderId
WHERE InventoryNum = 'R00010' AND LastName = 'Сергієнко' AND WayBillNumber = 'T00005';

INSERT INTO OrderItems(Orders_OrderId, Resources_ResourceId, UnitPrice, Quantity)
SELECT  OrderId, ResourceId, 25, 100
FROM Orders, Resources r
WHERE WayBillNumber='T00005' AND r.Name = 'Біла фарба';

INSERT INTO Inventory (InventoryNum, Quantity, Resources_ResourceId, Warehouses_WareHouseId)
SELECT 'R00011', 100, ResourceId, WarehouseId
FROM Resources r, Warehouses w JOIN Cities c ON w.Cities_CityId=c.CityId 
WHERE r.Name = 'Біла фарба' AND WarehouseNumber = 1 AND c.Name = 'Київ';

INSERT INTO SupplyItems (OrderItems_OrderItemId, Quantity, Inventory_InventoryId, ArrivalDate, Workers_AcceptedBy)
SELECT OrderItemId, 100, InventoryId, '2020/04/06', WorkerId
FROM Workers, OrderItems oi JOIN Inventory iv ON oi.Resources_ResourceId = iv.Resources_ResourceId
JOIN Orders o ON o.OrderId = Orders_OrderId
WHERE InventoryNum = 'R00011' AND LastName = 'Сергієнко' AND WayBillNumber = 'T00005'

--Order6
INSERT INTO Orders(WayBillNumber, OrderPrice, OrderDate, ShipmentPrice, TotalPrice, CompleteDate,
OrderStatuses_OrderStatusId, Workers_OrderedBy, Suppliers_SupplierId)
SELECT 'T00006', 25000, '2020/04/17', 0, 25000,'2020/04/19', OrderStatusId, WorkerId, SupplierId 
FROM OrderStatuses os, Workers w, Suppliers s
WHERE os.Name='Завершене' AND W.LastName='Броварчук' AND s.Name = 'АЗК WOG';

INSERT INTO OrderItems(Orders_OrderId, Resources_ResourceId, UnitPrice, Quantity)
SELECT  OrderId, ResourceId, 25, 1000
FROM Orders, Resources r
WHERE WayBillNumber='T00006' AND r.Name = 'Бензин А-95';

INSERT INTO Inventory (InventoryNum, Quantity, Resources_ResourceId, Warehouses_WareHouseId)
SELECT 'R00012', 1000, ResourceId, WarehouseId
FROM Resources r, Warehouses w JOIN Cities c ON w.Cities_CityId=c.CityId 
WHERE r.Name = 'Бензин А-95' AND WarehouseNumber = 2 AND c.Name = 'Львів';

INSERT INTO SupplyItems (OrderItems_OrderItemId, Quantity, Inventory_InventoryId, ArrivalDate, Workers_AcceptedBy)
SELECT OrderItemId, 1000, InventoryId, '2020/04/19', WorkerId
FROM Workers, OrderItems oi JOIN Inventory iv ON oi.Resources_ResourceId = iv.Resources_ResourceId
JOIN Orders o ON o.OrderId = Orders_OrderId
WHERE InventoryNum = 'R00012' AND LastName = 'Іваненко' AND WayBillNumber = 'T00006';

--Order7
INSERT INTO Orders(WayBillNumber, OrderPrice, OrderDate, ShipmentPrice, TotalPrice, CompleteDate,
OrderStatuses_OrderStatusId, Workers_OrderedBy, Suppliers_SupplierId)
SELECT 'T00007', 500, '2020/04/09', 200, 700,'2020/04/14', OrderStatusId, WorkerId, SupplierId 
FROM OrderStatuses os, Workers w, Suppliers s
WHERE os.Name='Завершене' AND W.LastName='Шевчук' AND s.Name = 'Bpsferallc';

INSERT INTO OrderItems(Orders_OrderId, Resources_ResourceId, UnitPrice, Quantity)
SELECT  OrderId, ResourceId, 5, 100
FROM Orders, Resources r
WHERE WayBillNumber='T00007' AND r.Name = 'Дрова';

INSERT INTO Inventory (InventoryNum, Quantity, Resources_ResourceId, Warehouses_WareHouseId)
SELECT 'R00013', 100, ResourceId, WarehouseId
FROM Resources r, Warehouses w JOIN Cities c ON w.Cities_CityId=c.CityId 
WHERE r.Name = 'Дрова' AND WarehouseNumber = 2 AND c.Name = 'Харків';

INSERT INTO SupplyItems (OrderItems_OrderItemId, Quantity, Inventory_InventoryId, ArrivalDate, Workers_AcceptedBy)
SELECT OrderItemId, 100, InventoryId, '2020/04/14', WorkerId
FROM Workers, OrderItems oi JOIN Inventory iv ON oi.Resources_ResourceId = iv.Resources_ResourceId
JOIN Orders o ON o.OrderId = Orders_OrderId
WHERE InventoryNum = 'R00013' AND LastName = 'Лисенко' AND WayBillNumber = 'T00007';

--Order8
INSERT INTO Orders(WayBillNumber, OrderPrice, OrderDate, ShipmentPrice, TotalPrice, CompleteDate,
OrderStatuses_OrderStatusId, Workers_OrderedBy, Suppliers_SupplierId)
SELECT 'T00008', 15500, '2020/04/18', 900, 16400,'2020/04/23', OrderStatusId, WorkerId, SupplierId 
FROM OrderStatuses os, Workers w, Suppliers s
WHERE os.Name='Завершене' AND W.LastName='Шевчук' AND s.Name = 'ПАТ "Північний гірничо-збагачувальний комбінат"';

INSERT INTO OrderItems(Orders_OrderId, Resources_ResourceId, UnitPrice, Quantity)
SELECT  OrderId, ResourceId, 5, 1000
FROM Orders, Resources r
WHERE WayBillNumber='T00008' AND r.Name = 'Вугілля';

INSERT INTO Inventory (InventoryNum, Quantity, Resources_ResourceId, Warehouses_WareHouseId)
SELECT 'R00014', 1000, ResourceId, WarehouseId
FROM Resources r, Warehouses w JOIN Cities c ON w.Cities_CityId=c.CityId 
WHERE r.Name = 'Вугілля' AND WarehouseNumber = 2 AND c.Name = 'Харків';

INSERT INTO SupplyItems (OrderItems_OrderItemId, Quantity, Inventory_InventoryId, ArrivalDate, Workers_AcceptedBy)
SELECT OrderItemId, 1000, InventoryId, '2020/04/23', WorkerId
FROM Workers, OrderItems oi JOIN Inventory iv ON oi.Resources_ResourceId = iv.Resources_ResourceId
JOIN Orders o ON o.OrderId = Orders_OrderId
WHERE InventoryNum = 'R00014' AND LastName = 'Лисенко' AND WayBillNumber = 'T00008';

INSERT INTO OrderItems(Orders_OrderId, Resources_ResourceId, UnitPrice, Quantity)
SELECT  OrderId, ResourceId, 7, 1500
FROM Orders, Resources r
WHERE WayBillNumber='T00008' AND r.Name = 'Сірка';

INSERT INTO Inventory (InventoryNum, Quantity, Resources_ResourceId, Warehouses_WareHouseId)
SELECT 'R00015', 1500, ResourceId, WarehouseId
FROM Resources r, Warehouses w JOIN Cities c ON w.Cities_CityId=c.CityId 
WHERE r.Name = 'Сірка' AND WarehouseNumber = 2 AND c.Name = 'Харків';

INSERT INTO SupplyItems (OrderItems_OrderItemId, Quantity, Inventory_InventoryId, ArrivalDate, Workers_AcceptedBy)
SELECT OrderItemId, 1500, InventoryId, '2020/04/23', WorkerId
FROM Workers, OrderItems oi JOIN Inventory iv ON oi.Resources_ResourceId = iv.Resources_ResourceId
JOIN Orders o ON o.OrderId = Orders_OrderId
WHERE InventoryNum = 'R00015' AND LastName = 'Лисенко' AND WayBillNumber = 'T00008';

--Order9
INSERT INTO Orders(WayBillNumber, OrderPrice, OrderDate, ShipmentPrice, TotalPrice, CompleteDate,
OrderStatuses_OrderStatusId, Workers_OrderedBy, Suppliers_SupplierId)
SELECT 'T00009', 17800, '2020/04/23', 985, 18785,'2020/04/26', OrderStatusId, WorkerId, SupplierId 
FROM OrderStatuses os, Workers w, Suppliers s
WHERE os.Name='Завершене' AND W.LastName='Шевчук' AND s.Name = 'ПАТ "Криворізький залізорудний комбінат"';

INSERT INTO OrderItems(Orders_OrderId, Resources_ResourceId, UnitPrice, Quantity)
SELECT  OrderId, ResourceId, 65, 100
FROM Orders, Resources r
WHERE WayBillNumber='T00009' AND r.Name = 'Фосфор';

INSERT INTO Inventory (InventoryNum, Quantity, Resources_ResourceId, Warehouses_WareHouseId)
SELECT 'R00016', 100, ResourceId, WarehouseId
FROM Resources r, Warehouses w JOIN Cities c ON w.Cities_CityId=c.CityId 
WHERE r.Name = 'Фосфор' AND WarehouseNumber = 1 AND c.Name = 'Харків';

INSERT INTO SupplyItems (OrderItems_OrderItemId, Quantity, Inventory_InventoryId, ArrivalDate, Workers_AcceptedBy)
SELECT OrderItemId, 100, InventoryId, '2020/04/26', WorkerId
FROM Workers, OrderItems oi JOIN Inventory iv ON oi.Resources_ResourceId = iv.Resources_ResourceId
JOIN Orders o ON o.OrderId = Orders_OrderId
WHERE InventoryNum = 'R00016' AND LastName = 'Лисенко' AND WayBillNumber = 'T00009';

INSERT INTO OrderItems(Orders_OrderId, Resources_ResourceId, UnitPrice, Quantity)
SELECT  OrderId, ResourceId, 35, 50
FROM Orders, Resources r
WHERE WayBillNumber='T00009' AND r.Name = 'Натрій';

INSERT INTO Inventory (InventoryNum, Quantity, Resources_ResourceId, Warehouses_WareHouseId)
SELECT 'R00017', 50, ResourceId, WarehouseId
FROM Resources r, Warehouses w JOIN Cities c ON w.Cities_CityId=c.CityId 
WHERE r.Name = 'Натрій' AND WarehouseNumber = 1 AND c.Name = 'Харків';

INSERT INTO SupplyItems (OrderItems_OrderItemId, Quantity, Inventory_InventoryId, ArrivalDate, Workers_AcceptedBy)
SELECT OrderItemId, 50, InventoryId, '2020/04/26', WorkerId
FROM Workers, OrderItems oi JOIN Inventory iv ON oi.Resources_ResourceId = iv.Resources_ResourceId
JOIN Orders o ON o.OrderId = Orders_OrderId
WHERE InventoryNum = 'R00017' AND LastName = 'Лисенко' AND WayBillNumber = 'T00009';

INSERT INTO OrderItems(Orders_OrderId, Resources_ResourceId, UnitPrice, Quantity)
SELECT  OrderId, ResourceId, 55, 70
FROM Orders, Resources r
WHERE WayBillNumber='T00009' AND r.Name = 'Магній';

INSERT INTO Inventory (InventoryNum, Quantity, Resources_ResourceId, Warehouses_WareHouseId)
SELECT 'R00018', 70, ResourceId, WarehouseId
FROM Resources r, Warehouses w JOIN Cities c ON w.Cities_CityId=c.CityId 
WHERE r.Name = 'Магній' AND WarehouseNumber = 1 AND c.Name = 'Харків';

INSERT INTO SupplyItems (OrderItems_OrderItemId, Quantity, Inventory_InventoryId, ArrivalDate, Workers_AcceptedBy)
SELECT OrderItemId, 70, InventoryId, '2020/04/26', WorkerId
FROM Workers, OrderItems oi JOIN Inventory iv ON oi.Resources_ResourceId = iv.Resources_ResourceId
JOIN Orders o ON o.OrderId = Orders_OrderId
WHERE InventoryNum = 'R00018' AND LastName = 'Лисенко' AND WayBillNumber = 'T00009';

INSERT INTO OrderItems(Orders_OrderId, Resources_ResourceId, UnitPrice, Quantity)
SELECT  OrderId, ResourceId, 9, 300
FROM Orders, Resources r
WHERE WayBillNumber='T00009' AND r.Name = 'Асбест';

INSERT INTO Inventory (InventoryNum, Quantity, Resources_ResourceId, Warehouses_WareHouseId)
SELECT 'R00019', 300, ResourceId, WarehouseId
FROM Resources r, Warehouses w JOIN Cities c ON w.Cities_CityId=c.CityId 
WHERE r.Name = 'Асбест' AND WarehouseNumber = 1 AND c.Name = 'Харків';

INSERT INTO SupplyItems (OrderItems_OrderItemId, Quantity, Inventory_InventoryId, ArrivalDate, Workers_AcceptedBy)
SELECT OrderItemId, 300, InventoryId, '2020/04/26', WorkerId
FROM Workers, OrderItems oi JOIN Inventory iv ON oi.Resources_ResourceId = iv.Resources_ResourceId
JOIN Orders o ON o.OrderId = Orders_OrderId
WHERE InventoryNum = 'R00019' AND LastName = 'Лисенко' AND WayBillNumber = 'T00009';

INSERT INTO OrderItems(Orders_OrderId, Resources_ResourceId, UnitPrice, Quantity)
SELECT  OrderId, ResourceId, 3, 1000
FROM Orders, Resources r
WHERE WayBillNumber='T00009' AND r.Name = 'Залізна руда';

INSERT INTO Inventory (InventoryNum, Quantity, Resources_ResourceId, Warehouses_WareHouseId)
SELECT 'R00020', 1000, ResourceId, WarehouseId
FROM Resources r, Warehouses w JOIN Cities c ON w.Cities_CityId=c.CityId 
WHERE r.Name = 'Залізна руда' AND WarehouseNumber = 1 AND c.Name = 'Харків';

INSERT INTO SupplyItems (OrderItems_OrderItemId, Quantity, Inventory_InventoryId, ArrivalDate, Workers_AcceptedBy)
SELECT OrderItemId, 1000, InventoryId, '2020/04/26', WorkerId
FROM Workers, OrderItems oi JOIN Inventory iv ON oi.Resources_ResourceId = iv.Resources_ResourceId
JOIN Orders o ON o.OrderId = Orders_OrderId
WHERE InventoryNum = 'R00020' AND LastName = 'Лисенко' AND WayBillNumber = 'T00009';