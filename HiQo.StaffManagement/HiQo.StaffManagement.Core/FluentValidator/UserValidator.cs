using System;
using System.Linq;
using System.Linq.Expressions;
using FluentValidation;
using HiQo.StaffManagement.Core.ViewModels;
using HiQo.StaffManagement.DAL.Context;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;
using HiQo.StaffManagement.DAL.Repositories;

namespace HiQo.StaffManagement.Core.FluentValidator
{
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        private readonly IRepository repository = new Repository(new StaffManagementContext());

        public UserValidator()
        {
            RuleFor(g => g.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .Length(1, 25).WithMessage("The number of characters must be from 2 to 25")
                .Matches("^[a-zA-Z]+$").WithMessage("First name сan't contain numbers");
           

            RuleFor(g => g.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .Length(1, 25).WithMessage("The number of characters must be from 2 to 25")
                .Matches("^[a-zA-Z]+$").WithMessage("Last name сan't contain numbers");

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

        private bool ExistenceOfFirstAndLastName(UserViewModel userVM)
        {
            var user = repository.Get<User>()
                .Where(g => g.FirstName == userVM.FirstName && g.LastName == userVM.LastName && userVM.UserId == 0);

            return !user.Any();
        }

        private bool ValidateDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}

