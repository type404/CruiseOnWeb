--Creating table users
CREATE TABLE [dbo].[Users] (
[Id] int IDENTITY(1,1) NOT NULL,
[FirstName] nvarchar(max) NOT NULL,
[LastName] nvarchar(max) NOT NULL,
[Country] nvarchar(max) NOT NULL,
[UserId] nvarchar(max) NOT NULL,
PRIMARY KEY (Id)
);
GO
--Creating table cruises
CREATE TABLE [dbo].[Cruises] (
[CruiseId] int IDENTITY(1,1) NOT NULL,
[UsId] INT NOT NULL,
[CruiseName] nvarchar(max) NOT NULL,
[CruiseDepPortName] nvarchar(max) NOT NULL,
[CruiseArrPortName] nvarchar(max) NOT NULL,
[Cost] INT NOT NULL,
[Duration] INT NOT NULL,
PRIMARY KEY (CruiseId),
FOREIGN KEY (UsId) REFERENCES Users(Id)
);
GO
--Creating table booking
CREATE TABLE [dbo].[Bookings] (
[BookingId] int IDENTITY(1,1) NOT NULL,
[UsId] INT NOT NULL,
[CId] INT NOT NULL,
[StartDate] DATE NOT NULL,
[EndDate] DATE NOT NULL,
[NumberOfPeople] INT NOT NULL,
[TotalPrice] INT NOT NULL,
PRIMARY KEY (BookingId),
FOREIGN KEY (UsId) REFERENCES Users(Id),
FOREIGN KEY (CId) REFERENCES Cruises(CruiseId)
);
GO
CREATE TABLE [dbo].[Ports] (
[PId] int IDENTITY(1,1) NOT NULL,
[PortName] nvarchar(max) NOT NULL,
[PortLati] FLOAT NOT NULL,
[PortLongi] FLOAT NOT NULL,
[PortCountry] nvarchar(max) NOT NULL,
PRIMARY KEY (PId)
);
GO