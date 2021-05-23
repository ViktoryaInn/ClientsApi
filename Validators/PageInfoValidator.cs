using ClientsApi.Schemas;
using FluentValidation;

namespace ClientsApi.Validators
{
    public class PageInfoValidator : AbstractValidator<PageInfo>
    {
        public PageInfoValidator()
        {
            RuleFor(p => p.Limit).GreaterThanOrEqualTo(1);
            RuleFor(p => p.Page).GreaterThanOrEqualTo(1);
        }
    }
}