namespace NETPCTest.Core.Exceptions
{
    public abstract class BadRequestException : CoreException
    {
        protected BadRequestException(string message)
            : base("Bad Request", message)
        {
        }
    }
}