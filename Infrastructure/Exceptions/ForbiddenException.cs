namespace Winterra.Infrastructure.Exceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException() 
            : base("Forbidden: You do not have permission to access this resource.") { }

        public ForbiddenException(string message) 
            : base(message) { }

        public ForbiddenException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
