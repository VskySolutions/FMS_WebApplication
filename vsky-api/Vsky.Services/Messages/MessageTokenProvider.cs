using System.Collections.Generic;
using Vsky.Models;

namespace Vsky.Services.Messages
{
    public class MessageTokenProvider : IMessageTokenProvider
    {
        #region Fields

        #endregion

        #region Ctor

        #endregion

        #region Methods

        public void AddUserTokens(IList<Token> tokens, ApplicationUser user)
        {
            tokens.Add(new Token("User.Email", user.Email));
            tokens.Add(new Token("User.Username", user.UserName));
            tokens.Add(new Token("User.FirstName", user.FirstName));
            tokens.Add(new Token("User.LastName", user.LastName));
        }

        #endregion
    }
}