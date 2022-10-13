using MediatR;
using NETPCTest.Application.Cqrs.Contacts.Responses;
namespace NETPCTest.Application.Cqrs.Contacts.Commands
{
    /// <summary>
    /// I must set Id so i declare it as prop
    /// </summary>
    /// <param name="FirstName"></param>
    /// <param name="LastName"></param>
    /// <param name="Email"></param>
    /// <param name="Password"></param>
    /// <param name="PhoneNumber"></param>
    /// <param name="DateOfBirth"></param>
    public record UpdateContactCommand(string FirstName,
        string LastName, string Email, string Password,
        int CategoryId, int? SubCategoryId,
        int PhoneNumber, DateTime DateOfBirth) : IRequest<ContactResponse>
    {
        public int Id { get; set; }
    }
}
