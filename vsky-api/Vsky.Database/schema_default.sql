IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'ActivityLogType')
CREATE TABLE [dbo].[ActivityLogType](
	[Id] [nvarchar](450) NOT NULL,
	[SystemKeyword] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
	CONSTRAINT [PK_ActivityLogType] PRIMARY KEY CLUSTERED([Id] ASC)
)
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'ActivityLog')
CREATE TABLE [dbo].[ActivityLog](
	[Id] [nvarchar](450) NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[IpAddress] [nvarchar](200) NULL,
	[EntityName] [nvarchar](400) NULL,
	[ActivityLogTypeId] [nvarchar](450) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[EntityId] [nvarchar](450) NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
	CONSTRAINT [PK_ActivityLog] PRIMARY KEY CLUSTERED([Id] ASC),
	CONSTRAINT [FK_ActivityLog_ActivityLogType_ActivityLogTypeId] FOREIGN KEY(ActivityLogTypeId) REFERENCES [dbo].[ActivityLogType]([Id]),
	CONSTRAINT [FK_ActivityLog_AspNetUsers_UserId] FOREIGN KEY(UserId) REFERENCES [dbo].[AspNetUsers]([Id])	
)	
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'Country')
CREATE TABLE [dbo].[Country](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[TwoLetterIsoCode] [nvarchar](2) NULL,
	[ThreeLetterIsoCode] [nvarchar](3) NULL,
	[NumericIsoCode] [int] NOT NULL,	
	[Active] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,	
	CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED([Id] ASC)
)
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'StateProvince')
CREATE TABLE [dbo].[StateProvince](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Abbreviation] [nvarchar](100) NULL,
	[CountryId] [nvarchar](450) NOT NULL,
	[Active] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	CONSTRAINT [PK_StateProvince] PRIMARY KEY CLUSTERED([Id] ASC),
	CONSTRAINT [FK_StateProvince_Country_CountryId] FOREIGN KEY(CountryId) REFERENCES [dbo].[Country]([Id])
)	
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'Contact')
CREATE TABLE [dbo].[Contact](
	[Id] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](128) NOT NULL,
	[LastName] [nvarchar](128) NULL,
	[Email] [nvarchar](128) NULL,
	[Phone] [nvarchar](16) NULL,
	[Fax] [nvarchar](16) NULL,
	[Address1] [nvarchar](128) NULL,
	[Address2] [nvarchar](128) NULL,
	[City] [nvarchar](128) NULL,
	[CountryId] [nvarchar](450) NULL,
	[StateProvinceId] [nvarchar](450) NULL,
	[County] [nvarchar](128) NULL,
	[ZipCode] [nvarchar](128) NULL,
	[CreatedById] [nvarchar](450) NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
	[UpdatedById] [nvarchar](450) NULL,
	[UpdatedOnUtc] [datetime2](6) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Contact_StateProvince_StateProvinceId] FOREIGN KEY(StateProvinceId) REFERENCES [dbo].[StateProvince]([Id]),
	CONSTRAINT [FK_Contact_Country_CountryId] FOREIGN KEY(CountryId) REFERENCES [dbo].[Country]([Id])
)
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'EmailAccount')
CREATE TABLE [dbo].[EmailAccount](
	[Id] [nvarchar](450) NOT NULL,
	[DisplayName] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Host] [nvarchar](255) NOT NULL,
	[Username] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Port] [int] NOT NULL,
	[EnableSsl] [bit] NOT NULL,
	[UseDefaultCredentials] [bit] NOT NULL,
	CONSTRAINT [PK_EmailAccount] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'MessageTemplate')
CREATE TABLE [dbo].[MessageTemplate](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[BccEmailAddresses] [nvarchar](200) NULL,
	[Subject] [nvarchar](1000) NULL,
	[EmailAccountId] [nvarchar](450) NOT NULL,
	[Body] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
	[DelayBeforeSend] [int] NULL,
	[DelayPeriodId] [int] NULL,
	[AttachedDownloadId] [nvarchar](450) NULL,
	CONSTRAINT [PK_MessageTemplate] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'Setting')
CREATE TABLE [dbo].[Setting](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[ReferenceId] [nvarchar](450) NULL,
	CONSTRAINT [PK_Setting] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'Log')
CREATE TABLE [dbo].[Log](
	[Id] [nvarchar](450) NOT NULL,
	[ShortMessage] [nvarchar](max) NOT NULL,
	[IpAddress] [nvarchar](200) NULL,
	[UserId] [nvarchar](450) NULL,
	[LogLevelId] [int] NOT NULL,
	[FullMessage] [nvarchar](max) NULL,
	[PageUrl] [nvarchar](max) NULL,
	[ReferrerUrl] [nvarchar](max) NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
	CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Log_AspNetUsers_UserId] FOREIGN KEY(UserId) REFERENCES [dbo].[AspNetUsers]([Id])	
)
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'QueuedEmail')
CREATE TABLE [dbo].[QueuedEmail](
	[Id] [nvarchar](450) NOT NULL,
	[From] [nvarchar](500) NOT NULL,
	[FromName] [nvarchar](500) NULL,
	[To] [nvarchar](500) NOT NULL,
	[ToName] [nvarchar](500) NULL,
	[ReplyTo] [nvarchar](500) NULL,
	[ReplyToName] [nvarchar](500) NULL,
	[Cc] [nvarchar](500) NULL,
	[Bcc] [nvarchar](500) NULL,
	[Subject] [nvarchar](1000) NULL,
	[EmailAccountId] [nvarchar](450) NOT NULL,
	[PriorityId] [int] NOT NULL,
	[Body] [nvarchar](max) NULL,
	[AttachmentFilePath] [nvarchar](max) NULL,
	[AttachmentFileName] [nvarchar](max) NULL,
	[AttachedDownloadId] [nvarchar](450) NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
	[DontSendBeforeDateUtc] [datetime2](6) NULL,
	[SentTries] [int] NOT NULL,
	[SentOnUtc] [datetime2](6) NULL,
	CONSTRAINT [PK_QueuedEmail] PRIMARY KEY CLUSTERED([Id] ASC)
)
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'PermissionRecord')
CREATE TABLE [dbo].[PermissionRecord](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[SystemName] [nvarchar](255) NOT NULL,
	[Category] [nvarchar](255) NOT NULL,
	CONSTRAINT [PK_PermissionRecord] PRIMARY KEY CLUSTERED([Id] ASC)
) 
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'PermissionRecord_Role_Mapping')
CREATE TABLE [dbo].[PermissionRecord_Role_Mapping](
	[PermissionRecord_Id] [nvarchar](450) NOT NULL,
	[Role_Id] [nvarchar](450) NOT NULL,
	CONSTRAINT [PK_PermissionRecord_Role_Mapping] PRIMARY KEY CLUSTERED([PermissionRecord_Id] ASC, [Role_Id] ASC),
	CONSTRAINT [FK_PermissionRecord_Role_Mapping_PermissionRecord_PermissionRecord_Id] FOREIGN KEY(PermissionRecord_Id) REFERENCES [dbo].[PermissionRecord]([Id]),
	CONSTRAINT [FK_PermissionRecord_Role_Mapping_AspNetRoles_Role_Id] FOREIGN KEY(Role_Id) REFERENCES [dbo].[AspNetRoles]([Id])
)
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'ScheduleTask')
CREATE TABLE [dbo].[ScheduleTask](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[Seconds] [int] NOT NULL,
	[LastEnabledUtc] [datetime2](6) NULL,
	[Enabled] [bit] NOT NULL,
	[StopOnError] [bit] NOT NULL,
	[LastStartUtc] [datetime2](6) NULL,
	[LastEndUtc] [datetime2](6) NULL,
	[LastSuccessUtc] [datetime2](6) NULL,
	CONSTRAINT [PK_ScheduleTask] PRIMARY KEY CLUSTERED([Id] ASC)
) 
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'Download')
CREATE TABLE [dbo].[Download](
	[Id] [nvarchar](450) NOT NULL,
	[UseDownloadUrl] [bit] NOT NULL,
	[DownloadUrl] [nvarchar](max) NULL,
	[DownloadBinary] [varbinary](max) NULL,
	[ContentType] [nvarchar](max) NULL,
	[Filename] [nvarchar](max) NULL,
	[Extension] [nvarchar](max) NULL,
	[IsNew] [bit] NOT NULL,
	CONSTRAINT [PK_Download] PRIMARY KEY CLUSTERED([Id] ASC)
) 
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'Picture')
CREATE TABLE [dbo].[Picture](
	[Id] [nvarchar](450) NOT NULL,
	[MimeType] [nvarchar](40) NOT NULL,
	[SeoFilename] [nvarchar](300) NULL,
	[AltAttribute] [nvarchar](max) NULL,
	[TitleAttribute] [nvarchar](max) NULL,
	[IsNew] [bit] NOT NULL,
	[VirtualPath] [nvarchar](max) NULL,
	CONSTRAINT [PK_Picture] PRIMARY KEY CLUSTERED([Id] ASC)
) 
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'PictureBinary')
CREATE TABLE [dbo].[PictureBinary](
	[Id] [nvarchar](450) NOT NULL,
	[PictureId] [nvarchar](450) NOT NULL,
	[BinaryData] [varbinary](max) NULL,
	CONSTRAINT [PK_PictureBinary] PRIMARY KEY CLUSTERED([Id] ASC),
	CONSTRAINT [FK_PictureBinary_Picture_PictureId] FOREIGN KEY(PictureId) REFERENCES [dbo].[Picture]([Id]),
) 
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_ActivityLog_ActivityLogTypeId' AND object_id = OBJECT_ID('ActivityLog'))
CREATE NONCLUSTERED INDEX [IX_ActivityLog_ActivityLogTypeId] ON [dbo].[ActivityLog]([ActivityLogTypeId] ASC)
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_ActivityLog_CreatedOnUtc' AND object_id = OBJECT_ID('ActivityLog'))
CREATE NONCLUSTERED INDEX [IX_ActivityLog_CreatedOnUtc] ON [dbo].[ActivityLog]([CreatedOnUtc] DESC)
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_ActivityLog_UserId' AND object_id = OBJECT_ID('ActivityLog'))
CREATE NONCLUSTERED INDEX [IX_ActivityLog_UserId] ON [dbo].[ActivityLog]([UserId] ASC)
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_ActivityLog_ActivityLogTypeId' AND object_id = OBJECT_ID('ActivityLog'))
CREATE NONCLUSTERED INDEX [IX_ActivityLog_ActivityLogTypeId] ON [dbo].[ActivityLog]([ActivityLogTypeId] ASC)
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Country_DisplayOrder' AND object_id = OBJECT_ID('Country'))
CREATE NONCLUSTERED INDEX [IX_Country_DisplayOrder] ON [dbo].[Country]([DisplayOrder] ASC)
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_StateProvince_CountryId' AND object_id = OBJECT_ID('StateProvince'))
CREATE NONCLUSTERED INDEX [IX_StateProvince_CountryId] ON [dbo].[StateProvince]([CountryId] ASC)
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Log_CreatedOnUtc' AND object_id = OBJECT_ID('Log'))
CREATE NONCLUSTERED INDEX [IX_Log_CreatedOnUtc] ON [dbo].[Log]([CreatedOnUtc] DESC)
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Log_UserId' AND object_id = OBJECT_ID('Log'))
CREATE NONCLUSTERED INDEX [IX_Log_UserId] ON [dbo].[Log]([UserId] ASC)
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_QueuedEmail_SentOnUtc_DontSendBeforeDateUtc_Extended' AND object_id = OBJECT_ID('QueuedEmail'))
CREATE NONCLUSTERED INDEX [IX_QueuedEmail_SentOnUtc_DontSendBeforeDateUtc_Extended] ON [dbo].[QueuedEmail]([SentOnUtc] ASC, [DontSendBeforeDateUtc] ASC) INCLUDE([SentTries])
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_QueuedEmail_CreatedOnUtc' AND object_id = OBJECT_ID('QueuedEmail'))
CREATE NONCLUSTERED INDEX [IX_QueuedEmail_CreatedOnUtc] ON [dbo].[QueuedEmail]([CreatedOnUtc] DESC)
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_PermissionRecord_Role_Mapping_Role_Id' AND object_id = OBJECT_ID('PermissionRecord_Role_Mapping'))
CREATE NONCLUSTERED INDEX [IX_PermissionRecord_Role_Mapping_Role_Id] ON [dbo].[PermissionRecord_Role_Mapping]([Role_Id] ASC)
GO
	
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_PermissionRecord_Role_Mapping_PermissionRecord_Id' AND object_id = OBJECT_ID('PermissionRecord_Role_Mapping'))
CREATE NONCLUSTERED INDEX [IX_PermissionRecord_Role_Mapping_PermissionRecord_Id] ON [dbo].[PermissionRecord_Role_Mapping]([PermissionRecord_Id] ASC)
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_PictureBinary_PictureId' AND object_id = OBJECT_ID('PictureBinary'))	
CREATE NONCLUSTERED INDEX [IX_PictureBinary_PictureId] ON [dbo].[PictureBinary]([PictureId] ASC)
GO
