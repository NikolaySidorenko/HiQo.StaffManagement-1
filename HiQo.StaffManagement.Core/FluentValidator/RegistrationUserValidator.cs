using System;
using System.Linq;
using FluentValidation;
using HiQo.StaffManagement.Core.ViewModels;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;

namespace HiQo.StaffManagement.Core.FluentValidator
{
    public class RegistrationUserValidator : AbstractValidator<RegistrationUserViewModel>
    {
        private readonly IRepository _repository;

        public RegistrationUserValidator(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

            RuleFor(g => g.Email)
                .NotEmpty().WithMessage("Username can't be empty");

            RuleFor(g => g.Email)
                .EmailAddress().WithMessage("Incorrect email");

            RuleFor(g => g.Password)
                .NotEmpty().WithMessage("Password can't be empty");

            RuleFor(g => g.Password)
                .MinimumLength(6).WithMessage("Minimum length 6");

            RuleFor(g => g.FirstName)
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
                .WithMessage("Last name is required");

            RuleFor(g => g.LastName)
                .Length(1, 25)
                .When(g => !string.IsNullOrWhiteSpace(g.LastName))
                .WithMessage("The number of characters must be from 2 to 25");

            RuleFor(g => g.LastName)
                .Matches("^[a-zA-Z]+$")
                .WithMessage("Incorrect last name");


            RuleFor(g => g).Must(ExistenceOfFirstAndLastName).WithMessage("This user already exists");

            RuleFor(g => g).Must(ExistenceOfUserName).WithMessage("This user already exists");

            RuleFor(g => g).Must(CheckPasswords).WithMessage("Passwords don't match");
        }

        private bool ExistenceOfFirstAndLastName(RegistrationUserViewModel userVm)
        {
            var user = _repository.Get<User>()
                .Where(g => g.FirstName == userVm.FirstName && g.LastName == userVm.LastName);

            return !user.Any();
        }

        private bool ExistenceOfUserName(RegistrationUserViewModel userVm)
        {
            var user = _repository.Get<User>()
                .Where(g => g.UserName == userVm.Email);

            return !user.Any();
        }

        private bool CheckPasswords(RegistrationUserViewModel userVm)
        {
            return userVm.Password == userVm.ConfirmPassword;
        }
    }
}