using FluentValidation;
using Vsky.Api.Framework.Validators;
using Vsky.Api.Models;

namespace Vsky.Api.Validators
{
    public class ChangePasswordValidator : BaseAppValidator<ChangePasswordModel>
    {
        public ChangePasswordValidator()
        {
            RuleFor(x => x.OldPassword).NotEmpty().WithMessage("Old password is required");
            RuleFor(x => x.NewPassword).NotEmpty().WithMessage("New password is required");
        }
    }
}