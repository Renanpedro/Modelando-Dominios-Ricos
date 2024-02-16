using PaymentContext.Shared.ValueObjects;
using Flunt.Validations;

namespace paymentcontext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Street, 3, "Address.Street", "A rua deve conter 3 caracteres")
            );
        }

        public String Street { get; private set; } = string.Empty;
        public String Number { get; private set; } = string.Empty;
        public String Neighborhood { get; private set; } = string.Empty;
        public String City { get; private set; } = string.Empty;
        public String State { get; private set; } = string.Empty;
        public String Country { get; private set; } = string.Empty;
        public String ZipCode { get; private set; } = string.Empty;
    }
}