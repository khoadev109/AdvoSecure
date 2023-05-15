using AdvoSecure.Application.Dtos;
using FluentValidation;

namespace AdvoSecure.Application.Validators
{
    public class CaseFilterValidator : AbstractValidator<CaseFilterRequestDto>
    {
        public CaseFilterValidator()
        {
            RuleFor(caseFilter => caseFilter.ContactName).NotEmpty().WithMessage("Please enter contact name");
        }
    }
}
