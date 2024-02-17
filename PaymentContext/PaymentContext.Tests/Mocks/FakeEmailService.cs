using paymentcontext.Domain.Entities;
using paymentcontext.Domain.Service;
using PaymentContext.Domain.Repositories;

namespace paymentcontext.Tests.Mocks
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string email, string subject, string body)
        {

        }
    }
}