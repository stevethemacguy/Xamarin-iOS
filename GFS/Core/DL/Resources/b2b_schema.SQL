/******************/
/*                */
/* b2b_schema.SQL */
/*                */
/******************/

/* Disable Foreign Keys */
pragma foreign_keys = off;
/* Begin Transaction */
begin transaction;

/* Database [b2b] */
pragma auto_vacuum=0;
pragma encoding='UTF-8';
pragma page_size=1024;

/* Drop table [main].[Product] */
drop table if exists [main].[Product];

/* Table structure [main].[Product] */
CREATE TABLE [main].[Product] (
  [ProductId] integer PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, 
  [Code] INT, 
  [Name] VARCHAR(50), 
  [Summary] varchar(250), 
  [Description] TEXT, 
  [AverageRating] FLOAT, 
  [AvailableForPickup] BOOLEAN, 
  [Url] varchar(250), 
  [Manufacturer] varchar(250), 
  [VolumePricesFlag] BOOLEAN, 
  [DateCreated] timestamp DEFAULT CURRENT_TIMESTAMP, 
  [DateModified] timestamp);
CREATE INDEX [main].[ndx_Product_Code] ON [Product] ([Code] COLLATE BINARY ASC);
CREATE INDEX [main].[ndx_Product_Summary] ON [Product] ([Name] COLLATE NOCASE ASC);

/* Data [main].[Product] */


/* Drop table [main].[Image] */
drop table if exists [main].[Image];

/* Table structure [main].[Image] */
CREATE TABLE [main].[Image] (
  [ImageId] integer PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, 
  [ImageType] varchar(30), 
  [Format] varchar(30), 
  [Url] varchar(250), 
  [ProductId] integer NOT NULL ON CONFLICT ROLLBACK CONSTRAINT [FK_Product_Image] REFERENCES [Product]([ProductId]) ON DELETE CASCADE);

/* Data [main].[Image] */


/* Drop table [main].[List] */
drop table if exists [main].[List];

/* Table structure [main].[List] */
CREATE TABLE [main].[List] (
  [ListId] integer PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, 
  [Title] varchar(30), 
  [DateCreated] timestamp DEFAULT CURRENT_TIMESTAMP);

/* Data [main].[List] */


/* Drop table [main].[ListProduct] */
drop table if exists [main].[ListProduct];

/* Table structure [main].[ListProduct] */
CREATE TABLE [main].[ListProduct] (
  [ListId] integer CONSTRAINT [PFK_List_Product] REFERENCES [List]([ListId]), 
  [ProductId] INTEGER CONSTRAINT [PFK_Product_List] REFERENCES [Product]([ProductId]), 
  [DateCreated] timestamp DEFAULT CURRENT_TIMESTAMP);

/* Data [main].[ListProduct] */


/* Drop table [main].[Manual] */
drop table if exists [main].[Manual];

/* Table structure [main].[Manual] */
CREATE TABLE [main].[Manual] (
  [ManualId] integer PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, 
  [Title] varchar(30), 
  [Url] varchar(250), 
  [Location] varchar(250), 
  [ProductId] integer CONSTRAINT [FK_Product_Manual] REFERENCES [Product]([ProductId]) ON DELETE CASCADE);

/* Data [main].[Manual] */


/* Drop table [main].[Note] */
drop table if exists [main].[Note];

/* Table structure [main].[Note] */
CREATE TABLE [main].[Note] (
  [NoteId] integer PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, 
  [Title] varchar(30), 
  [Value] text, 
  [DateCreated] timestamp DEFAULT CURRENT_TIMESTAMP, 
  [DateModified] timestamp);

/* Data [main].[Note] */


/* Drop table [main].[Price] */
drop table if exists [main].[Price];

/* Table structure [main].[Price] */
CREATE TABLE [main].[Price] (
  [PriceId] integer PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, 
  [CurrencyIso] varchar(5), 
  [PriceType] varchar(10), 
  [Value] CURRENCY(10, 2), 
  [FormattedValue] varchar(15), 
  [ProductId] integer NOT NULL ON CONFLICT ROLLBACK CONSTRAINT [FK_Product_Price] REFERENCES [Product]([ProductId]) ON DELETE CASCADE);

/* Data [main].[Price] */


/* Commit Transaction */
commit transaction;

/* Enable Foreign Keys */
pragma foreign_keys = on;
