using Microsoft.VisualStudio.TestTools.UnitTesting;
using paymentcontext.Domain.ValueObjects;
using paymentcontext.Domain.Enums;
using paymentcontext.Domain.Entities;
using PaymentContext.Domain.Commands;

namespace PaymentContext.Tests
{
    [TestClass]
    public class CreateBoletoSubscriptionCommandTests
    {
        //Red, Green, Refactor
        
        [TestMethod]
        public void ShouldReturnErrorWhenNameIsInvalid()
        {
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "";

            command.Validate();
            Assert.AreEqual(false, command.Valid);
        }
    }
}