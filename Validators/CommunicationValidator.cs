using ClientsApi.Enums;
using ClientsApi.Schemas;
using FluentValidation;

namespace ClientsApi.Validators
{
    public class CommunicationValidator : AbstractValidator<CommunicationDto>
    {
        public CommunicationValidator()
        {
            When(c => c.Type == CommunicationType.Email, () => RuleFor(c => c.Value).EmailAddress().NotNull());
            When(c => c.Type == CommunicationType.Phone, () => RuleFor(c => c.Value).Phone().NotNull());
        }
    }
}