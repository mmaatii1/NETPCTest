using NETPCTest.Application.Cqrs.Contacts.Responses;
using NETPCTest.Core.Entities;
using MediatR;


namespace NETPCTest.Application.Cqrs.Contacts.Commands
{
    /// <summary>
    /// i use records because theyr immutable, which i want in this case,
    /// and its fast to write
    /// </summary>
    /// <param name="FirstName"></param>
    /// <param name="LastName"></param>
    /// <param name="Email"></param>
    /// <param name="Password"></param>
    /// <param name="Category"></param>
    /// <param name="SubCategory"></param>
    /// <param name="PhoneNumber"></param>
    /// <param name="DateOfBirth"></param>
    public record CreateContactCommand(string FirstName, 
        string LastName, string Email, string Password,
        Category Category, SubCategory? SubCategory,
        int PhoneNumber, DateTime DateOfBirth) : IRequest<ContactResponse>
    {
    }
}
