namespace NETPCTest.Core.Exceptions
{
    //defining base class for custom exceptions
    public abstract class CoreException : Exception
    {
        protected CoreException(string title, string message)
            : base(message) =>
            Title = title;

        public string Title { get; }
    }
}
