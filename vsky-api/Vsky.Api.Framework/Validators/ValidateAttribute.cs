using System;
using FluentValidation.AspNetCore;

namespace Vsky.Api.Framework.Validators
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed partial class ValidateAttribute : CustomizeValidatorAttribute
    {
        public ValidateAttribute()
        {
            RuleSet = "Validate";
        }
    }
}