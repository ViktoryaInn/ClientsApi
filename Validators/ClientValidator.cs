using ClientsApi.Schemas;
using ClientsApi.Validarors;
using FluentValidation;

namespace ClientsApi.Validators
{
    public class ClientValidator : AbstractValidator<ClientDto>
    {
        public ClientValidator()
        {
            RuleFor(c => c.GeneralExp).GreaterThanOrEqualTo(0);
            RuleFor(c => c.CurFieldExp).GreaterThanOrEqualTo(0);
            RuleFor(c => c.CurFieldExp).LessThanOrEqualTo(c => c.GeneralExp)
                .WithMessage("CurFieldExp must be less or equal to GeneralExp");
            RuleFor(c => c.MonExpences).GreaterThanOrEqualTo(0);
            RuleFor(c => c.MonIncome).GreaterThanOrEqualTo(0);
            
            RuleFor(c => c.LivingAddress).SetValidator(new AddressValidator());
            RuleFor(c => c.RegAddress).SetValidator(new AddressValidator());
            RuleForEach(c => c.Communications).SetValidator(new CommunicationValidator());
            RuleForEach(c => c.Jobs).SetValidator(new JobValidator());
        }
    }
}