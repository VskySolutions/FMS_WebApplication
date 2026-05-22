using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vsky.Data;
using Vsky.Models;

namespace Vsky.Services.Messages
{
    public class EmailAccountService : IEmailAccountService
    {
        #region Fields

        private readonly IRepository<EmailAccount> _emailAccountRepository;

        #endregion

        #region Ctor

        public EmailAccountService(IRepository<EmailAccount> emailAccountRepository)
        {
            _emailAccountRepository = emailAccountRepository;
        }

        #endregion

        #region Methods

        public async virtual Task<EmailAccount> GetDefaultEmailAccount()
        {
            var query = from ea in _emailAccountRepository.Table
                        orderby ea.Id
                        select ea;

            var emailAccount = await query.FirstOrDefaultAsync();

            return emailAccount;
        }

        #endregion
    }
}