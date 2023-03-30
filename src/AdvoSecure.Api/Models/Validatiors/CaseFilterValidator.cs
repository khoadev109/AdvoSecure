using FluentValidation;

namespace AdvoSecure.Api.Models.Validatiors
{
    public class CaseFilterValidator : AbstractValidator<CaseFilterRequest>
    {
        public CaseFilterValidator()
        {
            RuleFor(caseFilter => caseFilter.ContactName).NotEmpty().WithMessage("Please enter contact name");
        }
    }
}
