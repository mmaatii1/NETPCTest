namespace NETPCTest.Core.Exceptions
{
    //base class for notFound, i will use to define entity not found excep
    public abstract class NotFoundException : CoreException
    {
        protected NotFoundException(string message)
            : base("Not Found", message)
        {
        }
    }
}
