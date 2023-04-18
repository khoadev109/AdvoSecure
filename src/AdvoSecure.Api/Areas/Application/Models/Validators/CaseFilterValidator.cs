using AdvoSecure.Api.Areas.Application.Models.Case;
using FluentValidation;

namespace AdvoSecure.Api.Areas.Application.Models.Validators
{
    public class CaseFilterValidator : AbstractValidator<CaseFilterRequest>
    {
        public CaseFilterValidator()
        {
            RuleFor(caseFilter => caseFilter.ContactName).NotEmpty().WithMessage("Please enter contact name");
        }
    }
}
