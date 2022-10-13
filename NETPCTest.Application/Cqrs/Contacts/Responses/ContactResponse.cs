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
    /// <param name="PhoneNumber"></param>
    /// <param name="DateOfBirth"></param>
    public class ContactResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    };

}
