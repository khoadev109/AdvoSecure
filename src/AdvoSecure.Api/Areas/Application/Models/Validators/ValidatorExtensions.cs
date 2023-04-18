using AdvoSecure.Api.Areas.Application.Models.Validators.Custom;
using FluentValidation;

namespace AdvoSecure.Api.Areas.Application.Models.Validators
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T, IList<TElement>> ListMustContainFewerThan<T, TElement>(this IRuleBuilder<T, IList<TElement>> ruleBuilder, int num)
        {
            return ruleBuilder.Must(list => list.Count < num).WithMessage("The list contains too many items");
        }

        public static IRuleBuilderOptions<T, IList<TElement>> ListMustContainFewerThanWithProperties<T, TElement>(this IRuleBuilder<T, IList<TElement>> ruleBuilder, int num)
        {
            return ruleBuilder.Must((rootObject, list, context) =>
            {
                context.MessageFormatter.AppendArgument("MaxElements", num);
                return list.Count < num;
            })
            .WithMessage("{PropertyName} must contain fewer than {MaxElements} items.");
        }

        public static IRuleBuilderOptions<T, IList<TElement>> ListMustContainFewerThanWithTotal<T, TElement>(this IRuleBuilder<T, IList<TElement>> ruleBuilder, int num)
        {

            return ruleBuilder.Must((rootObject, list, context) =>
            {
                context.MessageFormatter
                  .AppendArgument("MaxElements", num)
                  .AppendArgument("TotalElements", list.Count);

                return list.Count < num;
            })
            .WithMessage("{PropertyName} must contain fewer than {MaxElements} items. The list contains {TotalElements} element");
        }

        public static IRuleBuilderOptions<T, IList<TElement>> ListMustContainFewerThanCustomized<T, TElement>(this IRuleBuilder<T, IList<TElement>> ruleBuilder, int num)
        {
            return ruleBuilder.SetValidator(new ListCountValidator<T, TElement>(num));
        }
    }
}
