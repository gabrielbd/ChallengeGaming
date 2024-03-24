
namespace PredifyGaming.Domain
{
    public class DomainException : Exception
    {
        public DomainException(string errorMessage)
            : base(errorMessage)
        {

        }
        public static void When(bool hasError, string errorMessage)
        {
            if (hasError)
                throw new DomainException(errorMessage);
        }
    }
}
