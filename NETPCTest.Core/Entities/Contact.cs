namespace NETPCTest.Core.Entities
{
    public class Contact : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        //add this id in order to seed
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public SubCategory? SubCategory { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
