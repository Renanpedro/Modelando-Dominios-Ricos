

using paymentcontext.Domain.ValueObjects;

namespace paymentcontext.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(
            string cardHolderName, 
            string cardNumber, 
            string lastTransactionNumber, 
            DateTime paidDate, 
            DateTime expireDate, 
            decimal total, 
            decimal totalPaid, 
            string payer, 
            Document document, 
            Address address, 
            Email email) : base(
                paidDate, 
                expireDate, 
                total, 
                totalPaid, 
                payer, 
                document, 
                address, 
                email)
        {
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
            LastTransactionNumber = lastTransactionNumber;
        }

        public string CardHolderName { get; private set; } = string.Empty;
        public string CardNumber { get; private set; } = string.Empty;
        public string LastTransactionNumber { get; private set; } = string.Empty;
    }
}