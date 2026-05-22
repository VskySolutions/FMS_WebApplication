using System.Threading.Tasks;
using Vsky.Models;

namespace Vsky.Services.Messages
{
    public interface IEmailAccountService
    {
        Task<EmailAccount> GetDefaultEmailAccount();
    }
}