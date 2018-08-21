using FluentValidation;
using HiQo.StaffManagement.Core.ViewModels;

namespace HiQo.StaffManagement.Core.FluentValidator
{
    public class LoginUserValidator : AbstractValidator<LoginViewModel>
    {
        public LoginUserValidator()
        {
            RuleFor(g => g.Email)
                .NotEmpty().WithMessage("Username can't be empty");

            RuleFor(g => g.Email)
                .EmailAddress().WithMessage("Incorrect email");

            RuleFor(g => g.Password)
                .NotEmpty().WithMessage("Password can't be empty");
        }
    }
}
