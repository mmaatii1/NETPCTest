
namespace NETPCTest.Core.Exceptions
{
    public class EmailExists : ConcurencyException
    {
        public EmailExists(string email) : base($"Account with email: {email} already exits")
        {
        }
    }
}
