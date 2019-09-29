--Creating table profiles
CREATE TABLE [dbo].[Profiles] (
[Id] int IDENTITY(1,1) NOT NULL,
[FirstName] nvarchar(max) NOT NULL,
[LastName] nvarchar(max) NOT NULL,
[Country] nvarchar(max) NOT NULL,
[ProfileId] nvarchar(128) NOT NULL,
PRIMARY KEY (Id),
FOREIGN KEY (ProfileId) REFERENCES [dbo].[AspNetUsers](Id)
);
--Creating table cruises
CREATE TABLE [dbo].[Cruises] (
[CruiseId] int IDENTITY(1,1) NOT NULL,
[CruiseName] nvarchar(256) NOT NULL,
[CruiseDepPortName] nvarchar(max) NOT NULL,
[CruiseArrPortName] nvarchar(max) NOT NULL,
[CostPerNight] Float NOT NULL,
[Duration] INT NOT NULL,
PRIMARY KEY (CruiseId),
);
CREATE UNIQUE NONCLUSTERED INDEX [CruiseNameIndex]
    ON [dbo].[Cruises]([CruiseName] ASC);

--Creating table booking
CREATE TABLE [dbo].[Bookings] (
[BookingId] int IDENTITY(1,1) NOT NULL,
[Username] NVARCHAR (256) NOT NULL,
[CruiseName] NVARCHAR (256) NOT NULL,
[StartDate] DATE NOT NULL,
[EndDate] DATE NOT NULL,
[NumberOfPeople] INT NOT NULL,
[TotalPrice] Float NOT NULL,
PRIMARY KEY (BookingId),
FOREIGN KEY (Username) REFERENCES [dbo].[AspNetUsers](UserName),
FOREIGN KEY (CruiseName) REFERENCES Cruises(CruiseName)
);
GO