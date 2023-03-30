using FluentValidation.Validators;
using FluentValidation;

namespace AdvoSecure.Api.Models.Validatiors.Custom
{
    public class NotNullValidator<T, TProperty> : PropertyValidator<T, TProperty>
    {
        public override string Name => "NotNullValidator";

        public override bool IsValid(ValidationContext<T> context, TProperty value)
        {
            return value != null;
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
          => "'{PropertyName}' must not be empty.";
    }
}
