using FluentValidation;
using Vsky.Api.Framework.Validators;
using Vsky.Api.Models;

namespace Vsky.Api.Validators
{
    public class TokenValidator : BaseAppValidator<TokenModel>
    {
        public TokenValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}