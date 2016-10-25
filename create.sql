IF OBJECT_ID('dbo.users', 'U') IS NOT NULL 
  DROP TABLE [dbo].[users]; 

CREATE TABLE [dbo].[users]
(
  [id] [int] IDENTITY(1,1) NOT NULL,
  [first_name] [nvarchar](100) NOT NULL,
  [last_name] [nvarchar](100) NOT NULL,
  [email_address] [nvarchar](250) NOT NULL,
	[hashed_password] [nvarchar](100) NOT NULL,
)

IF OBJECT_ID('dbo.widgets', 'U') IS NOT NULL
	DROP TABLE [dbo].[widgets];

CREATE TABLE [dbo].[widgets]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[description] [nvarchar](1000) NOT NULL,
	[color] [nvarchar](20) NOT NULL,
	[size] [nvarchar](20) NOT NULL,
	[quantity] [int] NOT NULL,
	[price] [money] NOT NULL 
)

INSERT INTO [dbo].[users] ([first_name],[last_name],[email_address],[hashed_password])
	VALUES ('Bob', 'Thomas', 'bob@localhost', 'test');
INSERT INTO [dbo].[users] ([first_name],[last_name],[email_address],[hashed_password])
	VALUES ('Jane', 'Thomas', 'jane@localhost', 'test');

INSERT INTO [dbo].[widgets] (name, description, color, size, quantity, price)
	VALUES ('Red Small Widget', 'A red small widget.', 'red', 'small', 4, 3.45);
INSERT INTO [dbo].[widgets] (name, description, color, size, quantity, price)
	VALUES ('Blue Medium Widget', 'A blue medium widget.', 'blue', 'medium', 6, 2.75);
INSERT INTO [dbo].[widgets] (name, description, color, size, quantity, price)
	VALUES ('Orange Large Widget', 'A orange large widget.', 'orange', 'large', 10, 13.65);	
INSERT INTO [dbo].[widgets] (name, description, color, size, quantity, price)
	VALUES ('Yellow Small Widget', 'A yellow small widget.', 'yellow', 'small', 3, 9.55);	