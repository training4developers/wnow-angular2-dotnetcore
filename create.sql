IF OBJECT_ID('dbo.students', 'U') IS NOT NULL 
  DROP TABLE [dbo].[students]; 

CREATE TABLE [dbo].[students]
(
  [id] [int] IDENTITY(1,1) NOT NULL,
  [first_name] [nvarchar](100) NOT NULL,
  [last_name] [nvarchar](100) NOT NULL,
	[hashed_password] [nvarchar](100) NOT NULL,
)

IF OBJECT_ID('dbo.contact_info', 'U') IS NOT NULL
	DROP TABLE [dbo].[contact_info];

CREATE TABLE [dbo].[contact_info]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parent_id] [int] NOT NULL,
	[method] [nvarchar](20) NOT NULL,
	[value] [nvarchar](100) NOT NULL,
	[priority] [int] NOT NULL 
)

INSERT INTO [dbo].[students] ([first_name],[last_name],[hashed_password]) values ('Bob', 'Thomas', 'test');
INSERT INTO [dbo].[students] ([first_name],[last_name],[hashed_password]) values ('Jane', 'Thomas', 'test');

INSERT INTO [dbo].[contact_info] (parent_id, method, value, priority) values (1, 'email', 'bob@domain.com', 1);
INSERT INTO [dbo].[contact_info] (parent_id, method, value, priority) values (2, 'email', 'jane@domain.com', 1);