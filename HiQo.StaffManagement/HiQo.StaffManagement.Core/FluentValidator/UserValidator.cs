using System;
using System.Linq;
using FluentValidation;
using HiQo.StaffManagement.Core.ViewModels;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;

namespace HiQo.StaffManagement.Core.FluentValidator
{
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        private readonly IRepository _repository;

        public UserValidator(IRepository repository) 
        {
            _repository = repository;

            RuleFor(g => g.FirstName)
                .NotNull()
                .NotEmpty()
                .WithMessage("First name is required");

            RuleFor(g => g.FirstName)
                .Length(1, 25)
                .When(g => !string.IsNullOrWhiteSpace(g.FirstName))
                .WithMessage("The number of characters must be from 2 to 25");

            RuleFor(g => g.FirstName)
                .Matches("^[a-zA-Z]+$")
                .WithMessage("Incorrect first name");

            RuleFor(g => g.LastName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Last name is required");

            RuleFor(g => g.LastName)
                .Length(1, 25)
                .When(g => !string.IsNullOrWhiteSpace(g.LastName))
                .WithMessage("The number of characters must be from 2 to 25");

            RuleFor(g => g.LastName)
                .Matches("^[a-zA-Z]+$")
                .WithMessage("Incorrect last name");

            RuleFor(g => g.BirthDate)
                .NotEmpty().WithMessage("Birthday is required")
                .Must(ValidateDate).WithMessage("Incorrect date");

            RuleFor(g => g.MainPhoneNumber)
                .NotEmpty().WithMessage("Mobile phone is required")
                .Matches(@"^\+375\((17|29|33|44)\)[0-9]{3}-[0-9]{2}-[0-9]{2}$").WithMessage("Incorrect phone");

            RuleFor(g => g.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress();

            RuleFor(g => g.CurrentDepartmentId)
                .NotEmpty().WithMessage("Select a department");

            RuleFor(g => g.CurrentCategoryId)
                .NotEmpty().WithMessage("Select a category");

            RuleFor(g => g.CurrentPositionId)
                .NotEmpty().WithMessage("Select a position");

            RuleFor(g => g.CurrentPositionLevelId)
                .NotEmpty().WithMessage("Select a position level");

            RuleFor(g => g.CurrentRoleId)
                .NotEmpty().WithMessage("Select a role");

            RuleFor(g => g).Must(ExistenceOfFirstAndLastName).WithMessage("This user already exists");
        }

        private bool ExistenceOfFirstAndLastName(UserViewModel userVm)
        {
            var user = _repository.Get<User>()
                .Where(g => g.FirstName == userVm.FirstName && g.LastName == userVm.LastName && userVm.UserId == 0);

            return !user.Any();
        }

        private bool ValidateDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}

