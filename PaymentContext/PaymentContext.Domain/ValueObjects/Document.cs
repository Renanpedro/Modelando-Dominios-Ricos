using paymentcontext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace paymentcontext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;
        }

        public string Number { get; private set; } = string.Empty;
        public EDocumentType Type { get; private set; }
    }
}