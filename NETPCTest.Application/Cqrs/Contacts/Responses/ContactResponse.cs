using NETPCTest.Core.Entities;

namespace NETPCTest.Application.Cqrs.Contacts.Responses
{
    /// <summary>
    /// i will return the same response for all of the cruds,
    /// is it okay to return object like that from cqrs? Ive
    /// been reading and rlly i think this approach is okay,
    /// it give valid info about entity that we interact with,
    /// additionally all of its wrapped by my middleware
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="FirstName"></param>
    /// <param name="LastName"></param>
    /// <param name="Email"></param>
    /// <param name="Password"></param>
    /// <param name="Category"></param>
    /// <param name="SubCategory"></param>
    /// <param name="PhoneNumber"></param>
    /// <param name="DateOfBirth"></param>
    public record ContactResponse(int Id, string FirstName,
        string LastName, string Email, string Password,
        int CategoryId, int SubCategoryId,
        string CategoryName, string SubCategoryName,
        int PhoneNumber, DateTime DateOfBirth)
    {
    }
}
