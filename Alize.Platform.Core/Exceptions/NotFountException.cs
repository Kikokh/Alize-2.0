namespace Alize.Platform.Core.Exceptions
{
    public class NotFountException<T> : Exception where T : class
    {
        public NotFountException()
        {
        }

        public NotFountException(string? message) : base(message)
        {
        }
    }
}
