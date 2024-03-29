using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace paymentcontext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}