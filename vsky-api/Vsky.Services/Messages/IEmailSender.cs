using System.Collections.Generic;
using System.Threading.Tasks;
using Vsky.Models;

namespace Vsky.Services.Messages
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailAccount emailAccount, string subject, string body,
            string fromAddress, string fromName, string toAddress, string toName = null,
             string replyToAddress = null, string replyToName = null,
            IEnumerable<string> bcc = null, IEnumerable<string> cc = null,
            List<string> attachmentFilePathList = null, List<string> attachmentFileNameList = null,
            string unSubscribeUrl=null, IDictionary<string, string> headers = null);

        Task SendMultipleEmailAtOnceAsync(EmailAccount emailAccount, string subject, string body,
            string fromAddress, string fromName, List<string> toAddressList, string toName = null,
             string replyToAddress = null, string replyToName = null,
            IEnumerable<string> bcc = null, IEnumerable<string> cc = null,
            List<string> attachmentFilePathList = null, List<string> attachmentFileNameList = null,
            IDictionary<string, string> headers = null);
    }
}