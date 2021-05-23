using ClientsApi.Schemas;
using ClientsApi.Validarors;
using FluentValidation;

namespace ClientsApi.Validators
{
    public class JobValidator : AbstractValidator<JobDto>
    {
        public JobValidator()
        {
            RuleFor(j => j.DateDismissal).GreaterThanOrEqualTo(j => j.DateEmp);
            RuleFor(j => j.MonIncome).GreaterThanOrEqualTo(0);
            RuleFor(j => j.Tin).Tin();
            RuleForEach(j => j.PhoneNumbers).Phone();
            RuleFor(j => j.Site).Url();

            RuleFor(j => j.Address).SetValidator(new AddressValidator());
        }
    }
}