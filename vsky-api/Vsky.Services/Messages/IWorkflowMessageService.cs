using System.Collections.Generic;
using System.Threading.Tasks;
using Vsky.Models;

namespace Vsky.Services.Messages
{
    public interface IWorkflowMessageService
    {
        Task SendWelcomeEmail(ApplicationUser user, string password);

        Task SendResetPasswordEmail(ApplicationUser user, string password);

        Task SendTwoFactorToken(ApplicationUser user, string code);

        Task SendStudentEnrollClassEmail(ApplicationUser user, string studentName, string className);

        Task SendErrorByMail(string ex);

        Task SendNurturingTemplateMail(string userId, int addUnSubscribeLink, string mailSubject, string mailBody, string toEmail, List<string> attachmentFilePathList, List<string> attachmentFileNameList);

        Task SendTrialStudentsReminderMail(ApplicationUser user, string studentName, string className);

        Task SendOverdueTaskMail(ApplicationUser user, string messageText);

        Task SendContactUsMail(string toEmail, string fullName, string email, string phoneNumber, string message);

        Task SendCalendarEventMail(ApplicationUser user, string userName, string eventName, string dateStr, string className, string locationName, string attendeesCount, string note);

        Task SendCostumeFormMail(ApplicationUser admin, ApplicationUser instructor, string PerformanceName, string ClassName);

        Task SendCostumeFormApprovalRejectMail(ApplicationUser admin, ApplicationUser instructor, string statusName, string PerformanceName, string ClassName);
    }
}