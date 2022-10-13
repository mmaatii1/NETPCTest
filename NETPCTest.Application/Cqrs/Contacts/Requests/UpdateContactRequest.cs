using NETPCTest.Core.Entities;

namespace NETPCTest.Application.Cqrs.Contacts.Requests
{
    public record UpdateContactRequest(string FirstName,
        string LastName, string Email, string Password,
        int CategoryId, int? SubCategoryId,
        int PhoneNumber, DateTime DateOfBirth)
    {
    }
}
