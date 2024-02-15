using PaymentContext.Shared.ValueObjects;

namespace paymentcontext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public String Street { get; private set; } = string.Empty;
        public String Number { get; private set; } = string.Empty;
        public String Neighborhood { get; private set; } = string.Empty;
        public String City { get; private set; } = string.Empty;
        public String State { get; private set; } = string.Empty;
        public String Country { get; private set; } = string.Empty;
        public String ZipCode { get; private set; } = string.Empty;
    }
}