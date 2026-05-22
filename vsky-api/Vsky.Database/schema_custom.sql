IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DropDownType')
CREATE TABLE [dbo].[DropDownType](
    [Id] [nvarchar](450) NOT NULL,
	[Type] [nvarchar](128) NOT NULL    
    CONSTRAINT [PK_DropDownType] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DropDown')
CREATE TABLE [dbo].[DropDown](
    [Id] [nvarchar](450) NOT NULL,
	[DropDownTypeId] [nvarchar](450) NOT NULL,
	[DropDownValue] [nvarchar](128) NOT NULL,
    [CreatedOnUtc] [datetime2](6) NOT NULL,
    [CreatedById] [nvarchar](450) NOT NULL,
    [UpdatedOnUtc] [datetime2](6) NULL,
    [UpdatedById] [nvarchar](450) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
    CONSTRAINT [PK_DropDown] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_DropDown_DropDownType_DropDownTypeId] FOREIGN KEY(DropDownTypeId) REFERENCES [dbo].[DropDownType]([Id])
)
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SubscriptionPlan')
CREATE TABLE [dbo].[SubscriptionPlan](
    [Id] [nvarchar](450) NOT NULL,
    [Name] [nvarchar](128) NOT NULL,
    [Fees] [decimal](18,4) NOT NULL,
    [MaxUsersAllowed] [int] NOT NULL,
    [CreatedOnUtc] [datetime2](6) NOT NULL,
    [CreatedById] [nvarchar](450) NOT NULL,
    [UpdatedOnUtc] [datetime2](6) NULL,
    [UpdatedById] [nvarchar](450) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
    CONSTRAINT [PK_SubscriptionPlan] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Company')
CREATE TABLE [dbo].[Company](
    [Id] [nvarchar](450) NOT NULL,
    [Name] [nvarchar](128) NOT NULL,
    [Address] [nvarchar](256) NULL,
    [City] [nvarchar](128) NULL,
	[CountryId] [nvarchar](450) NULL,
    [StateProvinceId] [nvarchar](450) NULL,
    [ZipCode] [nvarchar](32) NULL,
    [ContactName] [nvarchar](64) NULL,
    [PhoneNumber] [nvarchar](16) NULL,
    [EmailAddress] [nvarchar](64) NULL,
	[SubscriptionPlanId] [nvarchar](450) NULL,
	[SubscriptionStartDate] [datetime2](6) NULL,
    [SubscriptionEndDate] [datetime2](6) NULL,
    [LogoId] [nvarchar](450) NULL,
    [CreatedOnUtc] [datetime2](6) NOT NULL,
    [CreatedById] [nvarchar](450) NOT NULL,
    [UpdatedOnUtc] [datetime2](6) NULL,
    [UpdatedById] [nvarchar](450) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL, 
	CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Company_SubscriptionPlan_SubscriptionPlanId] FOREIGN KEY(SubscriptionPlanId) REFERENCES [dbo].[SubscriptionPlan]([Id]),
	CONSTRAINT [FK_Company_Country_CountryId] FOREIGN KEY(CountryId) REFERENCES [dbo].[Country]([Id]),
	CONSTRAINT [FK_Company_StateProvince_StateProvinceId] FOREIGN KEY(StateProvinceId) REFERENCES [dbo].[StateProvince]([Id]),
	CONSTRAINT [FK_Company_Picture_LogoId] FOREIGN KEY(LogoId) REFERENCES [dbo].[Picture]([Id])
)
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Transaction')
CREATE TABLE [dbo].[Transaction](
    [Id] [nvarchar](450) NOT NULL,
	[CompanyId] [nvarchar](450) NOT NULL,    
    [TransactionDate] [datetime2](6) NULL,
	[Amount] [decimal](18,4) NULL,
	[PaymentRef] [nvarchar](32) NULL,
	[PaymentMethodId] [int] NULL,
	[IsSuccessfulPayment] [bit] NULL,
    [CreatedOnUtc] [datetime2](6) NOT NULL,
    [CreatedById] [nvarchar](450) NOT NULL,
    [UpdatedOnUtc] [datetime2](6) NULL,
    [UpdatedById] [nvarchar](450) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
    CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Transsaction_Company_CompanyId] FOREIGN KEY(CompanyId) REFERENCES [dbo].[Company]([Id]))
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Customer')
CREATE TABLE [dbo].[Customer](
    [Id] [nvarchar](450) NOT NULL,
    [Name] [nvarchar](128) NOT NULL,
    [Address] [nvarchar](256) NULL,
    [City] [nvarchar](128) NULL,
	[CountryId] [nvarchar](450) NULL,
    [StateProvinceId] [nvarchar](450) NULL,
    [ZipCode] [nvarchar](32) NULL,
    [ContactName] [nvarchar](64) NULL,
    [PhoneNumber] [nvarchar](16) NULL,
    [EmailAddress] [nvarchar](64) NULL,
	[AlternativeEmailAddress] [nvarchar](64) NULL,
	[Website] [nvarchar](64) NULL,
	[CompanyId] [nvarchar](450) NOT NULL,
	[CompanyTypeId] [nvarchar](450) NOT NULL,
	[CompanyStatusId] [nvarchar](450) NOT NULL,
    [CreatedOnUtc] [datetime2](6) NOT NULL,
    [CreatedById] [nvarchar](450) NOT NULL,
    [UpdatedOnUtc] [datetime2](6) NULL,
    [UpdatedById] [nvarchar](450) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL, 
	CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Customer_Company_CompanyId] FOREIGN KEY(CompanyId) REFERENCES [dbo].[Company]([Id]),
	CONSTRAINT [FK_Customer_DropDown_CompanyTypeId] FOREIGN KEY(CompanyTypeId) REFERENCES [dbo].[DropDown]([Id]),
	CONSTRAINT [FK_Customer_DropDown_CompanyStatusId] FOREIGN KEY(CompanyStatusId) REFERENCES [dbo].[DropDown]([Id]) ,
	CONSTRAINT [FK_Customer_Country_CountryId] FOREIGN KEY(CountryId) REFERENCES [dbo].[Country]([Id]),
	CONSTRAINT [FK_Customer_StateProvince_StateProvinceId] FOREIGN KEY(StateProvinceId) REFERENCES [dbo].[StateProvince]([Id]) 
)
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'Project')
CREATE TABLE [dbo].[Project](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
    [Code] [nvarchar](64) NOT NULL,
    [Description] [nvarchar](MAX) NULL,
    [ProjectPriorityId] [nvarchar](450) NULL,
    [ProjectStatusId] [nvarchar](450) NULL,
    [ProjectTypeId] [nvarchar](450) NULL,
    [StartDate] [datetime2](6) NULL,
    [EndDate] [datetime2](6) NULL,
    [GoLiveDate] [datetime2](6) NULL,
    [Website] [nvarchar](128) NULL,
    [CustomerId] [nvarchar](450) NOT NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
    [CreatedById] [nvarchar](450) NOT NULL,
	[UpdatedById] [nvarchar](450) NULL,
	[UpdatedOnUtc] [datetime2](6) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Project_Customer_CustomerId] FOREIGN KEY(CustomerId) REFERENCES [dbo].[Customer]([Id]),
	CONSTRAINT [FK_Project_DropDown_ProjectPriorityId] FOREIGN KEY(ProjectPriorityId) REFERENCES [dbo].[DropDown]([Id]),
	CONSTRAINT [FK_Project_DropDown_ProjectStatusId] FOREIGN KEY(ProjectStatusId) REFERENCES [dbo].[DropDown]([Id]) ,
	CONSTRAINT [FK_Project_DropDown_ProjectTypeId] FOREIGN KEY(ProjectTypeId) REFERENCES [dbo].[DropDown]([Id])	)	
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'Department')
CREATE TABLE [dbo].[Department](
	[Id] [nvarchar](450) NOT NULL,
	[DeptNo] [nvarchar](128) NULL,
    [Name] [nvarchar](128) NULL,
    [Description] [nvarchar](256) NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
    [CreatedById] [nvarchar](450) NOT NULL,
	[UpdatedById] [nvarchar](450) NULL,
	[UpdatedOnUtc] [datetime2](6) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED ([Id] ASC))	
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'StoryBoard')
CREATE TABLE [dbo].[StoryBoard](
	[Id] [nvarchar](450) NOT NULL,
	[ProjectId] [nvarchar](450) NOT NULL,
    [Title] [nvarchar](128) NOT NULL,
    [Description] [nvarchar](max) NULL,
    [StoryPriorityId] [nvarchar](450) NULL,
    [StoryStatusId] [nvarchar](450) NULL,
    [StoryIdentifiedDate] [datetime2](6) NULL,
    [StoryEndDate] [datetime2](6) NULL,
    [Notes] [nvarchar](max) NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
    [CreatedById] [nvarchar](450) NOT NULL,
	[UpdatedById] [nvarchar](450) NULL,
	[UpdatedOnUtc] [datetime2](6) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	CONSTRAINT [PK_StoryBoard] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_StoryBoard_DropDown_StoryPriorityId] FOREIGN KEY(StoryPriorityId) REFERENCES [dbo].[DropDown]([Id]),
	CONSTRAINT [FK_StoryBoard_DropDown_StoryStatusId] FOREIGN KEY(StoryStatusId) REFERENCES [dbo].[DropDown]([Id]) ,
	CONSTRAINT [FK_StoryBoard_Project_ProjectId] FOREIGN KEY(ProjectId) REFERENCES [dbo].[Project]([Id]))	
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'WorkOrder')
CREATE TABLE [dbo].[WorkOrder](
	[Id] [nvarchar](450) NOT NULL,
	[Title] [nvarchar](128) NOT NULL,
    [Description] [nvarchar](max) NULL,
	[WorkOrderNo] [nvarchar](128) NULL,
    [WOTypeId] [nvarchar](450) NULL,
    [WOStatusId] [nvarchar](450) NULL,
    [CloseDate] [datetime2](6) NULL,
    [TargetDate] [datetime2](6) NULL,
    [Notes] [nvarchar](max) NULL,
    [ProjectId] [nvarchar](450) NOT NULL,
    [StoryId] [nvarchar](450) NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
    [CreatedById] [nvarchar](450) NOT NULL,
	[UpdatedById] [nvarchar](450) NULL,
	[UpdatedOnUtc] [datetime2](6) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	CONSTRAINT [PK_WorkOrder] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_WorkOrder_DropDown_WOTypeId] FOREIGN KEY(WOTypeId) REFERENCES [dbo].[DropDown]([Id]),
	CONSTRAINT [FK_WorkOrder_DropDown_WOStatusId] FOREIGN KEY(WOStatusId) REFERENCES [dbo].[DropDown]([Id]),
	CONSTRAINT [FK_WorkOrder_Project_ProjectId] FOREIGN KEY(ProjectId) REFERENCES [dbo].[Project]([Id]),
	CONSTRAINT [FK_WorkOrder_StoryBoard_StoryBoardId] FOREIGN KEY(StoryId) REFERENCES [dbo].[StoryBoard]([Id]))	
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'Employee')
CREATE TABLE [dbo].[Employee](
	[Id] [nvarchar](450),
	[CompanyId] [nvarchar](450) NOT NULL,
    [EmployeeCode] [nvarchar](128) NULL,
    [DepartmentId] [nvarchar](450) NULL,
    [DesignationId] [nvarchar](450) NULL,
	[ShiftId] [nvarchar](450) NULL,
    [FirstName] [nvarchar](128) NULL,
    [MiddleName] [nvarchar](128) NULL,
    [LastName] [nvarchar](128) NULL,
    [CellPhone] [nvarchar](30) NULL,
    [Email] [nvarchar](50) NULL,
    [JoiningDate] [datetime2](6) NULL,
    [ProfilePhotoId] [nvarchar](450) NULL,
    [Address1] [nvarchar](500) NULL,
    [Address2] [nvarchar](500) NULL,
    [StateProvinceId] [nvarchar](450) NULL,
    [CountryId] [nvarchar](450) NULL,
    [City] [nvarchar](64) NULL,
    [Gender] [nvarchar](32) NULL,
    [EmployeeTypeId] [nvarchar](450) NULL,
    [AadhaarCardNo] [nvarchar](32) NULL,
    [PanCardNo] [nvarchar](32) NULL,
	[Epfuanno] [nvarchar](32) NULL,	
    [TrainingPeriodStartDate] [datetime2](6) NULL,
    [TrainingPeriodEndDate] [datetime2](6) NULL,
    [TrainingPeriodNote] [nvarchar](256) NULL,
    [ProbationPeriodStartDate] [datetime2](6) NULL,
    [ProbationPeriodEndDate] [datetime2](6) NULL,
    [ProbationPeriodNote] [nvarchar](256) NULL,
    [PermanentDate] [datetime2](6) NULL,
    [ReleaseDate] [datetime2](6) NULL,
    [WorkExperienceType] [nvarchar](128) NULL,
    [WorkExperienceDetails] [nvarchar](256) NULL,
    [WorkShiftTiming] [nvarchar](32) NULL,
	[ZipCode] [nvarchar](10) NULL,
    [EmgConName] [nvarchar](64) NULL,
    [EmgPhoneNo] [nvarchar](32) NULL,
    [EmployeeStatusId] [nvarchar](450) NULL,
    [Education] [nvarchar](64) NULL,
	[SameAsPermanentAddress] [bit] NULL,
    [CurrentAddress1] [nvarchar](64) NULL,
    [CurrentAddress2] [nvarchar](64) NULL,
    [CurrentStateProvinceId] [nvarchar](450) NULL,
    [CurrentCountryId] [nvarchar](128) NULL,
    [CurrentCity] [nvarchar](64) NULL,
    [CurrentZipCode] [nvarchar](10) NULL,
	[PersonalEmail] [nvarchar](50) NULL,
    [WorkTypeId] [nvarchar](450) NULL,
    [UserId] [nvarchar](450) NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
    [CreatedById] [nvarchar](450) NOT NULL,
	[UpdatedById] [nvarchar](450) NULL,
	[UpdatedOnUtc] [datetime2](6) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Employee_DropDown_DesignationId] FOREIGN KEY(DesignationId) REFERENCES [dbo].[DropDown]([Id]),
	CONSTRAINT [FK_Employee_DropDown_EmployeeStatusId] FOREIGN KEY(EmployeeStatusId) REFERENCES [dbo].[DropDown]([Id]),
	CONSTRAINT [FK_Employee_DropDown_WorkTypeId] FOREIGN KEY(WorkTypeId) REFERENCES [dbo].[DropDown]([Id]),
	CONSTRAINT [FK_Employee_DropDown_EmployeeTypeId] FOREIGN KEY(EmployeeTypeId) REFERENCES [dbo].[DropDown]([Id]),
	CONSTRAINT [FK_Employee_StateProvince_StateProvinceId] FOREIGN KEY(CurrentStateProvinceId) REFERENCES [dbo].[StateProvince]([Id]),
	CONSTRAINT [FK_Employee_AspNetUsers_UserId] FOREIGN KEY(UserId) REFERENCES [dbo].[AspNetUsers]([Id]),
	CONSTRAINT [FK_Employee_Company_CompanyId] FOREIGN KEY(CompanyId) REFERENCES [dbo].[Company]([Id]),
	CONSTRAINT [FK_Employee_Department_DepartmentId] FOREIGN KEY(DepartmentId) REFERENCES [dbo].[Department]([Id]))	
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'ProjectTask')
CREATE TABLE [dbo].[ProjectTask](
	[Id] [nvarchar](450) NOT NULL,
	[ProjectId] [nvarchar](450) NOT NULL,
    [WorkOrderId] [nvarchar](450) NULL,
    [TaskName] [nvarchar](256) NOT NULL,
    [Description] [nvarchar](max) NULL,
    [StatusId] [nvarchar](450) NULL,
    [PriorityId] [nvarchar](450) NULL,
    [EstimateTime] [decimal](18, 2) NULL,
    [Instructions] [nvarchar](max) NULL,
    [StartDate] [datetime2](6) NULL,
    [EndDate] [datetime2](6) NULL,
    [DueDate] [datetime2](6) NULL,
	[TaskMonth] [datetime2](6) NULL,
    [AssignedToId] [nvarchar](450) NULL,
	[CreatedOnUtc] [datetime2](6) NOT NULL,
    [CreatedById] [nvarchar](450) NOT NULL,
	[UpdatedById] [nvarchar](450) NULL,
	[UpdatedOnUtc] [datetime2](6) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	CONSTRAINT [PK_ProjectTask] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_ProjectTask_DropDown_StatusId] FOREIGN KEY(StatusId) REFERENCES [dbo].[DropDown]([Id]),
	CONSTRAINT [FK_ProjectTask_DropDown_PriorityId] FOREIGN KEY(PriorityId) REFERENCES [dbo].[DropDown]([Id]),
	CONSTRAINT [FK_ProjectTask_Project_ProjectId] FOREIGN KEY(ProjectId) REFERENCES [dbo].[Project]([Id]),
	CONSTRAINT [FK_ProjectTask_WorkOrder_WorkOrderId] FOREIGN KEY(WorkOrderId) REFERENCES [dbo].[WorkOrder]([Id]),
	CONSTRAINT [FK_ProjectTask_Employee_AssignedToId] FOREIGN KEY(AssignedToId) REFERENCES [dbo].[Employee]([Id]))	
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'ProjectActivity')
CREATE TABLE [dbo].[ProjectActivity](
	[Id] [nvarchar](450) NOT NULL,
	[ProjectId] [nvarchar](450) NOT NULL,
    [TaskId] [nvarchar](450) NULL,
    [WorkOrderId] [nvarchar](450) NULL,
    [ActivityName] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[AssignedToId] [nvarchar](450) NULL,
	[DueDate] [datetime2](6) NULL,
	[EstimateHours] [decimal](18, 2) NULL,    
	[CreatedOnUtc] [datetime2](6) NOT NULL,
    [CreatedById] [nvarchar](450) NOT NULL,
	[UpdatedById] [nvarchar](450) NULL,
	[UpdatedOnUtc] [datetime2](6) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	CONSTRAINT [PK_ProjectActivity] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_ProjectActivity_Project_ProjectId] FOREIGN KEY(ProjectId) REFERENCES [dbo].[Project]([Id]),
	CONSTRAINT [FK_ProjectActivity_ProjectTask_TaskId] FOREIGN KEY(TaskId) REFERENCES [dbo].[ProjectTask]([Id]),	
	CONSTRAINT [FK_ProjectActivity_WorkOrder_WorkOrderId] FOREIGN KEY(WorkOrderId) REFERENCES [dbo].[WorkOrder]([Id]),
	CONSTRAINT [FK_ProjectActivity_Employee_AssignedToId] FOREIGN KEY(AssignedToId) REFERENCES [dbo].[Employee]([Id]))	
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE	TABLE_NAME = 'Project_Employee_Mapping')
CREATE TABLE [dbo].[Project_Employee_Mapping](
	[Id] [nvarchar](450) NOT NULL,
	[ProjectId] [nvarchar](450) NOT NULL,
    [EmployeeId] [nvarchar](450)  NULL,
    [Role] [nvarchar](256) NULL,	
	CONSTRAINT [PK_Project_Employee_Mapping] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Project_Employee_Mapping_Project_ProjectId] FOREIGN KEY(ProjectId) REFERENCES [dbo].[Project]([Id]),
	CONSTRAINT [FK_Project_Employee_Mapping_Employee_EmployeeId] FOREIGN KEY(EmployeeId) REFERENCES [dbo].[Employee]([Id]))	
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'AspNetUsers' AND COLUMN_NAME = 'CompanyId')
ALTER TABLE AspNetUsers ADD [CompanyId] [nvarchar](450) NULL
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_AspNetUsers_Company_CompanyId')
ALTER TABLE [AspNetUsers] ADD CONSTRAINT [FK_AspNetUsers_Company_CompanyId] FOREIGN KEY (CompanyId) REFERENCES [Company]([Id])
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Contact' AND COLUMN_NAME = 'CustomerId')
ALTER TABLE Contact ADD [CustomerId] [nvarchar](450) NULL
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_Contact_Customer_CustomerId')
ALTER TABLE [Contact] ADD CONSTRAINT [FK_Contact_Customer_CustomerId] FOREIGN KEY (CustomerId) REFERENCES [Customer]([Id])
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Contact' AND COLUMN_NAME = 'AltPhoneNumber')
ALTER TABLE Contact ADD [AltPhoneNumber] [nvarchar](16) NULL
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Contact' AND COLUMN_NAME = 'AltEmailAddress')
ALTER TABLE Contact ADD [AltEmailAddress] [nvarchar](128) NULL
GO
