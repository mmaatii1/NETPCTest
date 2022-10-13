using NETPCTest.Core.Entities;
namespace NETPCTest.Application.Cqrs.Contacts.Requests
{
    public record CreateContactRequest(string FirstName,
        string LastName, string Email, string Password,
        Category Category, SubCategory? SubCategory,
        int PhoneNumber, DateTime DateOfBirth)
    {
    }
}
