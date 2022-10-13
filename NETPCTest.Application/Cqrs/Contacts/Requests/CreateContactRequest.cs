using NETPCTest.Core.Entities;
namespace NETPCTest.Application.Cqrs.Contacts.Requests
{
    public record CreateContactRequest(string FirstName,
        string LastName, string Email, string Password,
        int CategoryId, int? SubCategoryId,
        int PhoneNumber, DateTime DateOfBirth)
    {
    }
}
