IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'AspNetRoleClaims')
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED([Id] ASC)
)
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'AspNetRoles')
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED([Id] ASC)
)
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'AspNetUserClaims')
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED([Id] ASC)
)
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'AspNetUserLogins')
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
	CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED([LoginProvider] ASC,	[ProviderKey] ASC)
)
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'AspNetUserRoles')
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED([UserId] ASC,	[RoleId] ASC)
)
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'AspNetUsers')
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED([Id] ASC)
)
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'AspNetUserTokens')
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
	CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED([UserId] ASC, [LoginProvider] ASC, [Name] ASC)
)
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_AspNetRoleClaims_RoleId' AND object_id = OBJECT_ID('AspNetRoleClaims'))
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims] ([RoleId] ASC)
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'RoleNameIndex' AND object_id = OBJECT_ID('AspNetRoles'))
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]([NormalizedName] ASC) WHERE ([NormalizedName] IS NOT NULL)
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_AspNetUserClaims_UserId' AND object_id = OBJECT_ID('AspNetUserClaims'))
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]([UserId] ASC)
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_AspNetUserLogins_UserId' AND object_id = OBJECT_ID('AspNetUserLogins'))
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]([UserId] ASC)
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_AspNetUserRoles_RoleId' AND object_id = OBJECT_ID('AspNetUserRoles'))
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]([RoleId] ASC)
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'EmailIndex' AND object_id = OBJECT_ID('AspNetUsers'))
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]([NormalizedEmail] ASC)
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'UserNameIndex' AND object_id = OBJECT_ID('AspNetUsers'))
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]([NormalizedUserName] ASC) WHERE ([NormalizedUserName] IS NOT NULL)
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'FK_AspNetRoleClaims_AspNetRoles_RoleId') AND parent_object_id = OBJECT_ID(N'AspNetRoleClaims'))
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'FK_AspNetUserClaims_AspNetUsers_UserId') AND parent_object_id = OBJECT_ID(N'AspNetUserClaims'))
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'FK_AspNetUserLogins_AspNetUsers_UserId') AND parent_object_id = OBJECT_ID(N'AspNetUserLogins'))
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'FK_AspNetUserRoles_AspNetRoles_RoleId') AND parent_object_id = OBJECT_ID(N'AspNetUserRoles'))
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'FK_AspNetUserRoles_AspNetUsers_UserId') AND parent_object_id = OBJECT_ID(N'AspNetUserRoles'))
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'FK_AspNetUserTokens_AspNetUsers_UserId') AND parent_object_id = OBJECT_ID(N'AspNetUserTokens'))
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
GO
