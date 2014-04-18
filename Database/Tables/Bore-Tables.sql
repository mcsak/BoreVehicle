

/* Master tables*/

Create table VehicleMaster
(
VehicleID int identity primary key,
VehicleNumber varchar(25),
Name Varchar(25),
Others varchar(250),
Active tinyint default 1
)

create table Users
(
UserID int identity primary key,
UserName Varchar(50) not null,
FirstName varchar(25) not null,
LastName Varchar(25) default '',
Password varchar(100),
UserType varchar(25), -- Possibilities : SuperAdmin, Admin, Manager, Accountant, Supervisor
VehicleID int default -1 references VehicleMaster(VehicleID), -- -1 when one user having multiple vehicle mapped, 0 when all vechile
Active tinyint default 1,
LastLoginDateTime Datetime 
)

Create table VendorsMaster
(
VendorID int identity primary key,
VendorName varchar(100) not null,
VendorContact varchar(100),
VendorAddress Varchar(500),
OtherDetails varchar(250),
Active tinyint default 1
)

create table LabersMaster
(
LaberID bigint identity primary key,
LaberName varchar(100) not null,
LaberContact varchar(100),
LaberAddress Varchar(500),
OtherDetails varchar(250),
Active tinyint default 1,
VehicleID int default -1,
CreatedDate datetime default getdate(),
CreatedBy int references Users(UserID),
ModifiedDate datetime,
Modifiedby int references Users(UserID)
)

/* Transaction tables*/


--- TO store vehicle details


Create table Drivers(
DriverID int identity primary key,
UserName Varchar(50) not null,
FirstName varchar(25) not null,
LastName Varchar(25) default '',
Others varchar(200),
Active tinyint default 1,-- 1 when active, 0 when deleted, 2 when Releiving
CreateDateTime datetime default getdate(),
ReleivingDateTime datetime,
ModifiedBy int references Users(UserID),
ModifiedDate datetime
)

create table MenuMaster
(
MenuID int Identity primary key,
MenuName Varchar(100),
MenuPath varchar(250),
Active tinyint default 1
)

create table UserAndMenuCapabilities
(
RowID bigint Identity,
UserID int references Users(UserID),
MenuID int references MenuMaster(MenuID),
Active int default 1
)

create table SiteMangementLeads   -- this table holds all the site report details
(
LeadID bigint identity primary key,
PointNumber varchar(25),
DrillingDepth Numeric(18,2),
CasingDepth Numeric(18,2),
Welding numeric(18,2),
Cap int,
Holespipe int,
StartingRPM numeric(18,2),
EndingRPM numeric(18,2),
ClosingRPM numeric(18,2),
Collar int,
Bit varchar(50),
Hammer varchar(50),
DrillerName varchar(200),
PartyName Varchar(200),
PartyPhoneNumber varchar(250),
PartyAddress varchar(500),
Remarks Varchar(500),
Active tinyint default 1,
VehicleID int references VehicleMaster(VehicleID),
CreatedBy int references Users(UserID),
CreatedDate Datetime default getdate(),
ModifiedBy int references Users(UserID),
ModifiedDate Datetime,
BillingStatus Varchar(50) default 'No',-- 1 Generated, 2 Partialy Paid, 3 Closed ... This will be updated automatically based on its child table updation
)

create table SiteMangementLeadsBilling -- This tale holds all billing details of SiteManagementLeads
(
MasterBillID bigint identity,
BillNumber Varchar(50), -- This may not be usable bcz we will refer point number itself from SiteManagementLeads table.
DrillingDepthRate numeric(18,2) default 0.0, 
CasingDepthRate Numeric(18,2) default 0.0,
WeldingRate Numeric(18,2) default 0.0,
HolesPipeRate Numeric(18,2) default 0.0,
CollarRate Numeric(18,2) default 0.00,
DrillingDepthTotal numeric(18,2) default 0.0, 
CasingDepthTotal Numeric(18,2) default 0.0,
WeldingTotal Numeric(18,2) default 0.0,
HolesPipeTotal Numeric(18,2) default 0.0,
CollarTotal Numeric(18,2) default 0.00,
TotalBillingAmount numeric(18,2) default 0.0,
LeadID bigint references SiteMangementLeads(LeadID),
Remarks Varchar(500),
Active tinyint default 1,
BillStatus tinyint default 1,-- 1 generated, 2 when partialy paid, 3 closed
BillDate Datetime,
BillDateInteger int,
CreatedBy int references Users(UserID),
CreatedDate datetime default getdate(),
VehicleID int references VehicleMaster(VehicleID)
)


create table SiteManagementLeadsPayments
(
RowID bigint identity,
PaidAmount numeric(18,2) default 0.0, -- 0 when it's firts entry it means bill genertaed not yet paid.
BalanceAmount numeric(18,2) default 0.0, -- 0 When totally paid it means leads contract over.
PaidDate Datetime,
Remarks Varchar(500),
Active tinyint default 1, 
PaidDateInteger int,
LeadID bigint references SiteMangementLeads(LeadID),
VehicleID int references VehicleMaster(VehicleID),
CreatedBy int references Users(UserID),
CreatedDate datetime default Getdate(),
ModifiedBy int references Users(UserID),
ModifiedDate datetime
)

create table DieselExpenses
(
RowID bigint identity,
ExpenseDate datetime default getdate(),
RPM numeric(18,2),
Amount numeric(18,2),
Remarks Varchar(500),
Active tinyint,
VehicleID int references VehicleMaster(VehicleID),
CreatedBy int references Users(UserID),
CreatedDate Datetime default getdate(),
ModifiedBy int references Users(UserID),
ModifiedDate datetime
)

Create table BitExpenses
(
BitExpensesID bigint identity primary key,
BitExpensesCharID varchar(25),
ExpenseDate datetime default getdate(),
--BitNumber Varchar(10), -- this doubt full columns
Replaceable varchar(100),
VendorID int references VendorsMaster(VendorID),
--BitSize6Quantity int,
--BitSize6p5Quantity int,
--BitSize7Quantity int,
--BitSize7p5Quantity int,
--BitSize8Quantity int,
TotalAmount numeric(18,2),
Remarks Varchar(500),
Active tinyint Default 1, 
VehicleID int references VehicleMaster(VehicleID), 
CreatedBy int references Users(UserID),
CreatedDate Datetime default getdate(),
ModifiedBy int references Users(UserID),
ModifiedDate datetime,
PaymentStatus varchar(50)
)


create table BitExpensesChild
(
RowID bigint identity,
BitExpensesID bigint references BitExpenses(BitExpensesID),
bitSize Numeric(18,2),
BitQty int,
RatePerQty numeric(18,2) default 0.0,
TotalRate numeric(18,2) default 0.0,
GrandTotalRate numeric(18,2) default 0.0,
ReplacableAmount numeric(18,2) default 0.0,
Active tinyint default 1,
createdDate datetime default getdate()
)

Create table BitExpensesChildPayments
(
RowID bigint identity,
BitExpensesID bigint references BitExpenses(BitExpensesID),
PaidAmount numeric(18,2), -- 0 when intial entry
BalanceAmount numeric(18,2), -- 0 when complete
Remarks varchar(500),
Active tinyint default 1,
VehicleID int references VehicleMaster(VehicleID),
CreatedBy int references Users(UserID),
CreatedDate Datetime default getdate(),
ModifiedBy int references Users(UserID),
ModifiedDate datetime
)


create table BitSizesTransTempData
(
Size varchar(25),
Qty varchar(100),
RatePerQty varchar(100),
TotalRate varchar(100),
GrandTotalRate varchar(100)
)

create table HammerSizeTransTempData
(
Size varchar(25),
Qty varchar(100),
RatePerQty varchar(100),
TotalRate varchar(100),
GrandTotalRate varchar(100)
)

Create table HammerExpenses
(
HammerExpensesID bigint identity primary key,
HammerExpensesCharID varchar(25),
ExpenseDate datetime default getdate(),
--HammerNumber Varchar(10),
--Replaceable varchar(100),
VendorID int references VendorsMaster(VendorID),
--HammerSize6Quantity int,
--HammerSize6p5Quantity int,
--HammerSize7Quantity int,
--HammerSize7p5Quantity int,
--HammerSize8Quantity int,
TotalAmount numeric(18,2),
Remarks Varchar(500),
Active tinyint Default 1, 
VehicleID int references VehicleMaster(VehicleID), 
CreatedBy int references Users(UserID),
CreatedDate Datetime default getdate(),
ModifiedBy int references Users(UserID),
ModifiedDate datetime
)

create table HammerExpensesChild
(
RowID bigint identity,
HammerExpensesID bigint references HammerExpenses(HammerExpensesID),
HammerSize Numeric(18,2),
HammerQty int,
RatePerQty numeric(18,2) default 0.0,
TotalRate numeric(18,2) default 0.0,
GrandTotalRate numeric(18,2) default 0.0,
ReplacableAmount numeric(18,2) default 0.0,
Active tinyint default 1,
createdDate datetime default getdate()
)

Create table HammerExpensesChildPayments
(
RowID bigint identity,
HammerExpensesID bigint references HammerExpenses(HammerExpensesID),
PaidAmount numeric(18,2), -- 0 when intial entry
BalanceAmount numeric(18,2), -- 0 when complete
Remarks varchar(500),
Active tinyint default 1,
CreatedBy int references Users(UserID),
CreatedDate Datetime default getdate(),
ModifiedBy int references Users(UserID),
ModifiedDate datetime
)

Create table HammerSparesExpenses
(
RowID bigint identity,
HammerExpensesID bigint references HammerExpenses(HammerExpensesID),
SpareName varchar(100),
PaidAmount numeric(18,2), -- 0 when intial entry
BalanceAmount numeric(18,2), -- 0 when complete
Remarks varchar(500),
Active tinyint default 1,
CreatedBy int references Users(UserID),
CreatedDate Datetime default getdate(),
ModifiedBy int references Users(UserID),
ModifiedDate datetime
)

Create table CasingInward
(
CasingInwardID bigint identity primary key,
CasingDate datetime ,
CasingQuantity int,
BillNumber varchar(25),
BilledAmount numeric(18,2),
VendorID int references VendorsMaster(VendorID),
--VehicleID int references VehicleMaster(VehicleID),
PartyVehicleNo varchar(25),
Remarks varchar(500),
Active tinyint default 1,
CreatedBy int references Users(UserID),
CreatedDate Datetime default getdate(),
ModifiedBy int references Users(UserID),
ModifiedDate datetime
)

Create table CasingOutward
(
CasingOutwardID bigint identity primary key,
CasingDate datetime ,
CasingQuantity int,
VendorID int references VendorsMaster(VendorID),
PersonName varchar(100),
Remarks varchar(500),
VehicleID int references VehicleMaster(VehicleID),
Active tinyint default 1,
CreatedBy int references Users(UserID),
CreatedDate Datetime default getdate(),
ModifiedBy int references Users(UserID),
ModifiedDate datetime
)

Create table DailyExpenses
(
RowID bigint identity,
DailyExpenseDate datetime,
BillAmount numeric(18,2) default 0.0,
BalanceAmount numeric(18,2),
BitQuantity int default 0,
BitExpenses numeric(18,2) default 0.0,
HammerQuantity int default 0,
HammerExpenses numeric(18,2),
DieselQuantity numeric(18,2),
DieselAmount Numeric(18,2),
Remarks varchar(500),
Active tinyint default 1,
VehicleID int references VehicleMaster(VehicleID),
CreatedBy int references Users(UserID),
CreatedDate Datetime default getdate(),
ModifiedBy int references Users(UserID),
ModifiedDate datetime
)

Create table MangerAndUserPayments
(
RowID bigint identity,
UserID int references Users(UserID),
DateOfPayment Datetime,
Amount numeric(18,2) default 0.0,
 Salary decimal(18,2) default 0.0,
Remarks varchar(500),
Active tinyint default 1,
CreatedBy int references Users(UserID),
CreatedDate Datetime default getdate(),
ModifiedBy int references Users(UserID),
ModifiedDate datetime
)

Create table LabersPayments
(
RowID bigint identity,
LaberID bigint references LabersMaster(LaberID),
DateOfPayment datetime,
Amount numeric(18,2) default 0.0,
Remarks varchar(500),
Active tinyint default 1,
CreatedBy int references Users(UserID),
CreatedDate Datetime default getdate(),
ModifiedBy int references Users(UserID),
ModifiedDate datetime
)

Create table MonthlyStatusDetails
(
RowID bigint identity,
RemainingDieselQty int,
Remarks varchar(500),
Active tinyint default 1,
VehicleID int references VehicleMaster(VehicleID),
CreatedBy int references Users(UserID),
CreatedDate Datetime default getdate(),
ModifiedBy int references Users(UserID),
ModifiedDate datetime
)

Create table ConfigurationSetting
(
SettingID int identity,
Name varchar(100),
Value varchar(200),
Active int default 1,
LastModifedDate Datetime default getdate()
)

--Other Expenses Table

Create table OtherExpenses
(
RowID bigint Identity,
OtherExpenseDate datetime,
Particulars Varchar(500),
Amount numeric(18,2) default 0.0,
CreatedBy int references Users(UserID),
CreatedDate Datetime default getdate(),
ModifiedBy int references Users(UserID),
ModifiedDate datetime,
Active int default 1,
VehicleID int default -1
)

create table FundManagement
(
RowID bigint identity,
Amount numeric(18,2) default 0.0,
TransactionType Varchar(25), -- Credit/Debit,
ReceiptType tinyint, -- 1 SiteManagementBill, 2 Casing bill, 3 Bit, 4 Hammer, -1 Common fund
Details varchar(250), -- Cash, Transferred, petty cash
VehicleID int,-- vehicleID=-1 when it becomes Common fund
Active tinyint default 1,
CreatedDate Datetime default getdate(),
CreatedBy int,
ModifiedDate datetime,
ModifiedBy int
)

create table BalanceLedger
(
RowID bigint identity,
TransactionType varchar(25),--- Debit/Credit
Particulars varchar(50),
CreditAmount numeric(18,2) default 0.0,
DebitAmount numeric(18,2) default 0.0,
BalanceAmount numeric(18,2) default 0.0,
VehicleID int,
GrossTotalAmount numeric(18,2) default 0.0, -- this is a total amount of all vehicles
TransactionDate datetime,
TransactionDateInteger int,
Createdby int,
CreatedDate datetime default getdate(),
Active tinyint default 1
)