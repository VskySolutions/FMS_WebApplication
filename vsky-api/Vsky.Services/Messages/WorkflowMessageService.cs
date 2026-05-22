using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using Vsky.Data;
using Vsky.Models;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Vsky.Services.Messages
{
    public class WorkflowMessageService : IWorkflowMessageService
    {
        #region Fields

        private readonly ApplicationDbContext _db;
        private readonly IEmailSender _emailSender;
        private readonly IMessageTokenProvider _messageTokenProvider;
        private readonly ITokenizer _tokenizer;

        #endregion

        #region Ctor

        public WorkflowMessageService(ApplicationDbContext db, IEmailSender emailSender, IMessageTokenProvider messageTokenProvider, ITokenizer tokenizer)
        {
            _db = db;
            _emailSender = emailSender;
            _messageTokenProvider = messageTokenProvider;
            _tokenizer = tokenizer;

        }

        #endregion

        #region Utilities

        #endregion

        #region Methods

        #region Send Welcome Email
        public async Task SendWelcomeEmail(ApplicationUser user, string password)
        {
            var template = await _db.MessageTemplates.FirstOrDefaultAsync(x => x.Name == MessageTemplateSystemNames.UserWelcomeMessage && x.Active);

            if (template != null)
            {
                // tokens
                var tokens = new List<Token>();

                _messageTokenProvider.AddUserTokens(tokens, user);

                var WEB_Domain = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["WEB_Domain"];

                // add password to the token list
                tokens.Add(new Token("User.Password", password));
                tokens.Add(new Token("User.Url", WEB_Domain));

                // email account
                var emailAccount = await _db.EmailAccounts.FirstOrDefaultAsync(x => x.Id == template.EmailAccountId) ?? await _db.EmailAccounts.FirstOrDefaultAsync();

                // replace subject and body tokens
                var subject = _tokenizer.Replace(template.Subject, tokens, false);
                var body = _tokenizer.Replace(template.Body, tokens, true);

                // send email
                await _emailSender.SendEmailAsync(emailAccount, subject, body, emailAccount.Email, emailAccount.DisplayName, user.Email, null);
            }
        }
        #endregion

        #region Send Reset Password Email
        public async Task SendResetPasswordEmail(ApplicationUser user, string password)
        {
            var template = await _db.MessageTemplates.FirstOrDefaultAsync(x => x.Name == MessageTemplateSystemNames.UserResetPassword && x.Active);

            if (template != null)
            {
                // tokens
                var tokens = new List<Token>();

                _messageTokenProvider.AddUserTokens(tokens, user);

                // add password to the token list
                tokens.Add(new Token("User.Password", password));

                // email account
                var emailAccount = await _db.EmailAccounts.FirstOrDefaultAsync(x => x.Id == template.EmailAccountId) ?? await _db.EmailAccounts.FirstOrDefaultAsync();

                // replace subject and body tokens
                var subject = _tokenizer.Replace(template.Subject, tokens, false);
                var body = _tokenizer.Replace(template.Body, tokens, true);

                // send email
                await _emailSender.SendEmailAsync(emailAccount, subject, body, emailAccount.Email, emailAccount.DisplayName, user.Email, null);
            }
        }
        #endregion

        #region Send Two Factor Token
        public async Task SendTwoFactorToken(ApplicationUser user, string code)
        {
            var template = await _db.MessageTemplates.FirstOrDefaultAsync(x => x.Name == MessageTemplateSystemNames.UserTwoFactorToken && x.Active);

            if (template != null)
            {
                // tokens
                var tokens = new List<Token>();

                _messageTokenProvider.AddUserTokens(tokens, user);

                // add code to the token list
                tokens.Add(new Token("User.TwoFactorToken", code));

                // email account
                var emailAccount = await _db.EmailAccounts.FirstOrDefaultAsync(x => x.Id == template.EmailAccountId) ?? await _db.EmailAccounts.FirstOrDefaultAsync();

                // replace subject and body tokens
                var subject = _tokenizer.Replace(template.Subject, tokens, false);
                var body = _tokenizer.Replace(template.Body, tokens, true);

                // send email
                await _emailSender.SendEmailAsync(emailAccount, subject, body, emailAccount.Email, emailAccount.DisplayName, user.Email, null);
            }
        }
        #endregion

        #region Send Student Enroll Class Email
        public async Task SendStudentEnrollClassEmail(ApplicationUser user, string studentName, string className)
        {
            var template = await _db.MessageTemplates.FirstOrDefaultAsync(x => x.Name == MessageTemplateSystemNames.StudentEnrollClass && x.Active);

            if (template != null)
            {
                // tokens
                var tokens = new List<Token>();

                _messageTokenProvider.AddUserTokens(tokens, user);

                tokens.Add(new Token("Student.Name", studentName));
                tokens.Add(new Token("Class.Name", className));

                // email account
                var emailAccount = await _db.EmailAccounts.FirstOrDefaultAsync(x => x.Id == template.EmailAccountId) ?? await _db.EmailAccounts.FirstOrDefaultAsync();

                // replace subject and body tokens
                var subject = _tokenizer.Replace(template.Subject, tokens, false);
                var body = _tokenizer.Replace(template.Body, tokens, true);

                // send email
                await _emailSender.SendEmailAsync(emailAccount, subject, body, emailAccount.Email, emailAccount.DisplayName, user.Email, null);
            }
        }
        #endregion

        #region Send Error B yMail
        public async Task SendErrorByMail(string error)
        {
            var template = await _db.MessageTemplates.FirstOrDefaultAsync(x => x.Name == MessageTemplateSystemNames.ApplicationError && x.Active);

            if (template != null)
            {
                // tokens
                var tokens = new List<Token>();

                //_messageTokenProvider.AddUserTokens(tokens, user);

                tokens.Add(new Token("error", error));
              
                // email account
                var emailAccount = await _db.EmailAccounts.FirstOrDefaultAsync(x => x.Id == template.EmailAccountId) ?? await _db.EmailAccounts.FirstOrDefaultAsync();

                // replace subject and body tokens
                var subject = _tokenizer.Replace(template.Subject, tokens, false);
                var body = _tokenizer.Replace(template.Body, tokens, true);

                // send email
                string toEmail = "sachin.bhanse@vskysolutions.com";
                await _emailSender.SendEmailAsync(emailAccount, subject, body, emailAccount.Email, emailAccount.DisplayName, toEmail, null);
            }
        }
        #endregion

        #region Send Nurturing Template Mail
        public async Task SendNurturingTemplateMail(string userId, int addUnSubscribeLink, string mailSubject, string mailBody, string toEmail, List<string> attachmentFilePathList, List<string> attachmentFileNameList)
        {
            var template = await _db.MessageTemplates.FirstOrDefaultAsync(x => x.Name == MessageTemplateSystemNames.NurturingTemplate && x.Active);

            if (template != null)
            {
                // tokens
                var tokens = new List<Token>();

                // email account
                var emailAccount = await _db.EmailAccounts.FirstOrDefaultAsync(x => x.Id == template.EmailAccountId) ?? await _db.EmailAccounts.FirstOrDefaultAsync();

                //Unsubcribe email
                var unSubscribeUrl = "";
                if (addUnSubscribeLink == 1)
                {
                    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(toEmail);
                    string encodeEmail = System.Convert.ToBase64String(plainTextBytes);

                    var WEB_Domain = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["WEB_Domain"];
                    unSubscribeUrl = WEB_Domain + encodeEmail + "/unsubscribe";
                    mailBody += "<br><br><p style='align:center'><a href='" + unSubscribeUrl + "' target='_blank'>Click here to Unsubscribe</a></p>";
                }                

                // replace subject and body tokens
                var subject = _tokenizer.Replace(mailSubject, tokens, false);
                var body = _tokenizer.Replace(mailBody, tokens, true);

                // send email
                //toEmail = "sachin.bhanse@vskysolutions.com";

                //Check email un-subscribed
                //var emailUnsubscribed = _db.UnsubscribedEmails.Where(x => x.Email.ToLower()== toEmail.ToLower()).FirstOrDefault();
                //if(emailUnsubscribed == null)
                //    await _emailSender.SendEmailAsync(emailAccount, subject, body, emailAccount.Email, emailAccount.DisplayName, toEmail, null, null, null, null, null, attachmentFilePathList, attachmentFileNameList, unSubscribeUrl);
            }
        }
        #endregion

        #region Send Trial Students Reminder Mail
        public async Task SendTrialStudentsReminderMail(ApplicationUser user, string studentName, string className)
        {
            var template = await _db.MessageTemplates.FirstOrDefaultAsync(x => x.Name == MessageTemplateSystemNames.TrialStudentReminder && x.Active);

            if (template != null)
            {
                // tokens 
                var tokens = new List<Token>();

                _messageTokenProvider.AddUserTokens(tokens, user);

                // add password to the token list
                tokens.Add(new Token("User.StudentName", studentName));
                tokens.Add(new Token("User.ClassName", className));

                // email account
                var emailAccount = await _db.EmailAccounts.FirstOrDefaultAsync(x => x.Id == template.EmailAccountId) ?? await _db.EmailAccounts.FirstOrDefaultAsync();

                // replace subject and body tokens
                var subject = _tokenizer.Replace(template.Subject, tokens, false);
                var body = _tokenizer.Replace(template.Body, tokens, true);

                // send email
                await _emailSender.SendEmailAsync(emailAccount, subject, body, emailAccount.Email, emailAccount.DisplayName, user.Email, null);
            }
        }
        #endregion

        #region Send Overdue task Mail
        public async Task SendOverdueTaskMail(ApplicationUser user, string messageText)
        {
            var template = await _db.MessageTemplates.FirstOrDefaultAsync(x => x.Name == MessageTemplateSystemNames.OverdueTask && x.Active);

            if (template != null)
            {
                // tokens 
                var tokens = new List<Token>();

                _messageTokenProvider.AddUserTokens(tokens, user);

                // add to the token list
                tokens.Add(new Token("MessageText", messageText));
                
                // email account
                var emailAccount = await _db.EmailAccounts.FirstOrDefaultAsync(x => x.Id == template.EmailAccountId) ?? await _db.EmailAccounts.FirstOrDefaultAsync();

                // replace subject and body tokens
                var subject = _tokenizer.Replace(template.Subject, tokens, false);
                var body = _tokenizer.Replace(template.Body, tokens, true);

                // send email
                string toEmail = user.Email;
                //string toEmail = "sachin.bhanse@vskysolutions.com";
                await _emailSender.SendEmailAsync(emailAccount, subject, body, emailAccount.Email, emailAccount.DisplayName, toEmail, null);
            }
        }
        #endregion

        #region Send Calendar Event Mail
        public async Task SendCalendarEventMail(ApplicationUser user, string userName, string eventName, string dateStr, string className, string locationName, string attendeesCount, string note)
        {
            var template = await _db.MessageTemplates.FirstOrDefaultAsync(x => x.Name == MessageTemplateSystemNames.CalendarEvent && x.Active);

            if (template != null)
            {
                // tokens 
                var tokens = new List<Token>();

                _messageTokenProvider.AddUserTokens(tokens, user);

                // add to the token list
                tokens.Add(new Token("UserName", userName));
                tokens.Add(new Token("EventName", eventName));
                tokens.Add(new Token("DateStr", dateStr));
                tokens.Add(new Token("ClassName", className));
                tokens.Add(new Token("LocationName", locationName));
                tokens.Add(new Token("AttendeesCount", attendeesCount));
                tokens.Add(new Token("Note", note));

                // email account
                var emailAccount = await _db.EmailAccounts.FirstOrDefaultAsync(x => x.Id == template.EmailAccountId) ?? await _db.EmailAccounts.FirstOrDefaultAsync();

                // replace subject and body tokens
                var subject = _tokenizer.Replace(template.Subject, tokens, false);
                var body = _tokenizer.Replace(template.Body, tokens, true);

                // send email
                string toEmail = user.Email;
                //string toEmail = "sachin.bhanse@vskysolutions.com";
                await _emailSender.SendEmailAsync(emailAccount, subject, body, emailAccount.Email, emailAccount.DisplayName, toEmail, null);
            }
        }
        #endregion

        #region Send Contact Us Mail
        public async Task SendContactUsMail(string toEmail, string fullName, string email, string phoneNumber, string message)
        {
            var template = await _db.MessageTemplates.FirstOrDefaultAsync(x => x.Name == MessageTemplateSystemNames.ContactUs && x.Active);

            if (template != null)
            {
                // tokens 
                var tokens = new List<Token>
                {
                    //_messageTokenProvider.AddUserTokens(tokens);
                    // add to the token list
                    new Token("fullName", fullName),
                    new Token("email", email),
                    new Token("phoneNumber", phoneNumber),
                    new Token("message", message)
                };

                // email account
                var emailAccount = await _db.EmailAccounts.FirstOrDefaultAsync(x => x.Id == template.EmailAccountId) ?? await _db.EmailAccounts.FirstOrDefaultAsync();

                // replace subject and body tokens
                var subject = _tokenizer.Replace(template.Subject, tokens, false);
                var body = _tokenizer.Replace(template.Body, tokens, true);

                // send email
                toEmail = "sachin.bhanse@vskysolutions.com";
                await _emailSender.SendEmailAsync(emailAccount, subject, body, emailAccount.Email, emailAccount.DisplayName, toEmail, null);
            }
        }
        #endregion

        #region Send Calendar Event Mail
        public async Task SendCostumeFormMail(ApplicationUser admin, ApplicationUser instructor, string PerformanceName, string ClassName)
        {
            var template = await _db.MessageTemplates.FirstOrDefaultAsync(x => x.Name == MessageTemplateSystemNames.CostumeForm && x.Active);

            if (template != null)
            {
                // tokens 
                var tokens = new List<Token>();

                _messageTokenProvider.AddUserTokens(tokens, admin);

                // add to the token list
                tokens.Add(new Token("User.FirstName", admin.FirstName));
                tokens.Add(new Token("Instructor.FirstName", instructor.FirstName));
                tokens.Add(new Token("Instructor.LastName", instructor.LastName));
                tokens.Add(new Token("PerformanceName", PerformanceName));
                tokens.Add(new Token("ClassName", ClassName));

                // email account
                var emailAccount = await _db.EmailAccounts.FirstOrDefaultAsync(x => x.Id == template.EmailAccountId) ?? await _db.EmailAccounts.FirstOrDefaultAsync();

                // replace subject and body tokens
                var subject = _tokenizer.Replace(template.Subject, tokens, false);
                var body = _tokenizer.Replace(template.Body, tokens, true);

                // send email
                //string toEmail = admin.Email;
                string toEmail = "sachin.bhanse@vskysolutions.com";
                await _emailSender.SendEmailAsync(emailAccount, subject, body, emailAccount.Email, emailAccount.DisplayName, toEmail, null);
            }
        }
        #endregion

        #region Send Approve/Reject Mail
        public async Task SendCostumeFormApprovalRejectMail(ApplicationUser admin, ApplicationUser instructor, string statusName, string PerformanceName, string ClassName)
        {
            var template = await _db.MessageTemplates.FirstOrDefaultAsync(x => x.Name == MessageTemplateSystemNames.CostumeFormApprovalReject && x.Active);

            if (template != null)
            {
                // tokens 
                var tokens = new List<Token>();

                _messageTokenProvider.AddUserTokens(tokens, admin);

                // add to the token list
                tokens.Add(new Token("Instructor.FirstName", instructor.FirstName));
                tokens.Add(new Token("User.FirstName", admin.FirstName));                
                tokens.Add(new Token("User.LastName", admin.LastName));
                tokens.Add(new Token("PerformanceName", PerformanceName));
                tokens.Add(new Token("ClassName", ClassName));
                tokens.Add(new Token("Status", statusName));

                // email account
                var emailAccount = await _db.EmailAccounts.FirstOrDefaultAsync(x => x.Id == template.EmailAccountId) ?? await _db.EmailAccounts.FirstOrDefaultAsync();

                // replace subject and body tokens
                var subject = _tokenizer.Replace(template.Subject, tokens, false);
                var body = _tokenizer.Replace(template.Body, tokens, true);

                // send email
                //string toEmail = admin.Email;
                string toEmail = "sachin.bhanse@vskysolutions.com";
                await _emailSender.SendEmailAsync(emailAccount, subject, body, emailAccount.Email, emailAccount.DisplayName, toEmail, null);
            }
        }
        #endregion

        #endregion
    }
}