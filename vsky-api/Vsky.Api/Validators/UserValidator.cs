using FluentValidation;
using Vsky.Api.Framework.Validators;
using Vsky.Api.Models;

namespace Vsky.Api.Validators
{
    public class UserValidator : BaseAppValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required");
        }
    }
}