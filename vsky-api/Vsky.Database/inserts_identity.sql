-- roles
IF NOT EXISTS (SELECT 1 FROM AspNetRoles WHERE Name = 'SuperAdmin')
INSERT INTO [dbo].[AspNetRoles](Id,Name,NormalizedName,ConcurrencyStamp) VALUES('8CF035C0-43AA-43D7-A69A-14CC0F37FF60','SuperAdmin','superadmin', NEWID())
GO

IF NOT EXISTS (SELECT 1 FROM AspNetRoles WHERE Name = 'Administrator')
INSERT INTO [dbo].[AspNetRoles](Id,Name,NormalizedName,ConcurrencyStamp) VALUES('A71C8317-D9A6-4DDF-99AD-EE2E1E94B4A4','Administrator','administrator', NEWID())
GO

IF NOT EXISTS (SELECT 1 FROM AspNetRoles WHERE Name = 'employee')
INSERT INTO [dbo].[AspNetRoles](Id,Name,NormalizedName,ConcurrencyStamp) VALUES('36F9191D-DFBD-43E2-8B2F-18AB4868C3A7','Employee','employee', NEWID())
GO

-- admin user
IF NOT EXISTS (SELECT 1 FROM AspNetUsers WHERE UserName = 'admin')
INSERT INTO [dbo].[AspNetUsers]([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], 
[ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName],
Active, Deleted)
VALUES('E434CC54-A37B-4309-A53F-DD4E4B0A673A', 'admin', 'admin', 'no-reply@vsky.com', 
'no-reply@vsky.com', 1, 'AQAAAAEAACcQAAAAEE2+xl5AffREtEsXUqOUa4PswxTu699HMQ1cx7vXqX8OiVS5Qk7+NfJhRIFT3xNPog==', 'WG3ARFGF3MHH2QLFUA6KTF63CSMRT6NZ',
'817231a4-d725-4858-b6f5-e5aae3d2736d', '9000079267', 1, 0, NULL, 1, 0, 'John', 'Deo', 1, 0)
GO

IF NOT EXISTS (SELECT 1 FROM AspNetUserRoles WHERE UserId = 'E434CC54-A37B-4309-A53F-DD4E4B0A673A' AND RoleId = '8CF035C0-43AA-43D7-A69A-14CC0F37FF60')
INSERT INTO [dbo].[AspNetUserRoles](UserId, RoleId) VALUES('E434CC54-A37B-4309-A53F-DD4E4B0A673A', '8CF035C0-43AA-43D7-A69A-14CC0F37FF60')
GO
