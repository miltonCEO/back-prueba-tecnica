using BolsaEmpleo.DTOs;
using FluentValidation;

namespace BolsaEmpleo.Validators
{
    public class UserInsertValidator : AbstractValidator<UserInsertDto>
    {
        public UserInsertValidator() 
        {
            RuleFor(x => x.userName).NotEmpty();

        }
    }
}
