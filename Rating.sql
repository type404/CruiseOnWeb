CREATE TABLE [dbo].[Ratings] (
[RatingId] int IDENTITY(1,1) NOT NULL,
[Rating] int NOT NULL,
[BookingId] int NOT NULL,
[Comments] NVARCHAR (Max) NOT NULL,
PRIMARY KEY (RatingId),
FOREIGN KEY (BookingId) REFERENCES [dbo].[Bookings](BookingId),
);