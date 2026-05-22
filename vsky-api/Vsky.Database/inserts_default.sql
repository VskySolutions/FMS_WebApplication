-- email account
IF NOT EXISTS (SELECT 1 FROM EmailAccount WHERE Email = 'postmaster@zotworks.com')
INSERT INTO [dbo].[EmailAccount](Id, Email, DisplayName, Host, Port, Username, Password, EnableSsl, UseDefaultCredentials)
VALUES('A77C569E-2329-442E-A476-E5E977051CB5', 'postmaster@zotworks.com', 'Vsky Technology', 'mail.zotworks.com',
587, 'postmaster@zotworks.com', '45{GHJ#@$GH', 0, 0)
GO

-- message
IF NOT EXISTS (SELECT 1 FROM MessageTemplate WHERE Name = 'User.WelcomeMessage')
INSERT [dbo].[MessageTemplate] ([Id], [Name], [BccEmailAddresses], [Subject], [Body], [Active], [EmailAccountId]) VALUES (N'DFE5EAD8-9045-43C9-AE83-2A4756B45790', N'User.WelcomeMessage', N'', N'Welcome to Vsky, Your Account Details Inside', N'Dear %User.FirstName% %User.LastName%,<br><br>Welcome to Vsky! We are thrilled to have you as a new member of our system.<br>This email contains your account details to help you get started and make the most of our services.<br><br>Below are your login credentials:<br><br><b><b>Username: %User.Username%</b><br><b>Password: %User.Password%</b><br><br>Please note that your password is securely encrypted in our system, ensuring the safety of your account.<br><br>Best regards,<br>Vsky', 1, N'A77C569E-2329-442E-A476-E5E977051CB5')
GO

IF NOT EXISTS (SELECT 1 FROM MessageTemplate WHERE Name = 'User.ChangePassword')
INSERT [dbo].[MessageTemplate] ([Id], [Name], [BccEmailAddresses], [Subject], [Body], [Active], [EmailAccountId]) VALUES (N'34E83A55-415B-46C7-9008-FC8ECD3C14CE', N'User.ChangePassword', N'', N'Vsky - Password Changed', N'Hello %User.FirstName% %User.LastName%,<br><br>You have successfully changed the password for your Vsky account.<br>Please reach out to the admin if you have not done this.<br><br>Thanks,<br>Team Vsky', 1, N'A77C569E-2329-442E-A476-E5E977051CB5')
GO

IF NOT EXISTS (SELECT 1 FROM MessageTemplate WHERE Name = 'User.ResetPassword')
INSERT [dbo].[MessageTemplate] ([Id], [Name], [BccEmailAddresses], [Subject], [Body], [Active], [EmailAccountId]) VALUES (N'E88E0084-9418-49D8-879F-5348DFF9B092', N'User.ResetPassword', N'', N'Vsky - Password has been reset', N'Hello %User.FirstName%,<br><br>Admin has reset the password for your Vsky Account.<br><br>Please find the new password below:<br><br><b>%User.Password%</b><br><br>Thanks,<br>Team Vsky', 1, N'A77C569E-2329-442E-A476-E5E977051CB5')
GO

User.TwoFactorToken