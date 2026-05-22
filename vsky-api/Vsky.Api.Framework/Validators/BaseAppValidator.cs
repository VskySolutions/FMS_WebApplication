using FluentValidation;

namespace Vsky.Api.Framework.Validators
{
    public abstract partial class BaseAppValidator<TModel> : AbstractValidator<TModel> where TModel : class
    {
    }
}