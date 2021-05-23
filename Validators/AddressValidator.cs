using ClientsApi.Schemas;
using FluentValidation;

namespace ClientsApi.Validarors
{
    public class AddressValidator : AbstractValidator<AddressDto>
    {
        public AddressValidator()
        {
            RuleFor(a => a.City).NotEmpty();
            RuleFor(a => a.Country).NotEmpty();
            RuleFor(a => a.Region).NotEmpty();
            RuleFor(a => a.House).NotEmpty();
            RuleFor(a => a.Street).NotEmpty();
        }
    }
}