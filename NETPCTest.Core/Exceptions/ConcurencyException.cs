
namespace NETPCTest.Core.Exceptions
{
    public abstract class ConcurencyException  : CoreException
    {
    protected ConcurencyException(string message)
        : base("Conflict", message)
    {
    }
    }
}
