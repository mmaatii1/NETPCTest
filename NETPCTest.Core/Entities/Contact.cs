namespace NETPCTest.Core.Entities
{
    public class Contact : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Category Category { get; set; } = null!;
        public SubCategory? SubCategory { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
