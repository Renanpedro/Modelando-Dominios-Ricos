using paymentcontext.Domain.Enums;
using PaymentContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace PaymentContext.Domain.Commands
{
    public class CreatePayPalSubscriptionCommand : Notifiable, ICommand
    {
        public string FirstName { get;  set; } = string.Empty;
        public string LastName { get;  set; } = string.Empty;
        public string Document { get;  set; } = string.Empty;
        public string Email { get;  set; } = string.Empty;

        public string TransactionCode { get;  set; } = string.Empty;
        
        public string PaymentNumber { get;  set; } = string.Empty;
        public DateTime PaidDate { get;  set; }
        public DateTime ExpireDate { get;  set; }
        public decimal  Total { get;  set; }
        public decimal TotalPaid { get;  set; }
        public string Payer { get;  set; } = string.Empty;
        public string PayerDocument { get;  set; }
        public EDocumentType PayerDocumentType { get;  set; }
        public string PayerEmail { get;  set; }

        public String Street { get;  set; } = string.Empty;
        public String Number { get;  set; } = string.Empty;
        public String Neighborhood { get;  set; } = string.Empty;
        public String City { get;  set; } = string.Empty;
        public String State { get;  set; } = string.Empty;
        public String Country { get;  set; } = string.Empty;
        public String ZipCode { get;  set; } = string.Empty;

         public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}