using FluentValidation;
using NETPCTest.Application.Cqrs.Contacts.Commands;
using NETPCTest.Core.Entities;
using NETPCTest.Core.Interfaces;
using System.Text.RegularExpressions;

namespace NETPCTest.Application.Validators.Contacts
{
    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        /// <summary>
        /// classic stuff
        /// </summary>
        public CreateContactCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(250);
            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(250);
            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(250);
            RuleFor(x => x.Password)
                .NotEmpty()
                .Must(HasValidPassword);
            RuleFor(x => x.PhoneNumber)
                .NotEmpty();
            RuleFor(x => x.DateOfBirth)
                .NotEmpty();
        }
        private bool HasValidPassword(string pw)
        {
            var lowercase = new Regex("[a-z]+");
            var uppercase = new Regex("[A-Z]+");
            var digit = new Regex("(\\d)+");
            var symbol = new Regex("(\\W)+");

            return (lowercase.IsMatch(pw) && uppercase.IsMatch(pw) && digit.IsMatch(pw) && symbol.IsMatch(pw));
        }
    }
}
