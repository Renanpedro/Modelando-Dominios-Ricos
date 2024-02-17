using Microsoft.VisualStudio.TestTools.UnitTesting;
using paymentcontext.Domain.ValueObjects;
using paymentcontext.Domain.Enums;
using paymentcontext.Domain.Entities;

namespace PaymentContext.Tests
{
    [TestClass]
    public class DocumentTests
    {
        //Red, Green, Refactor
        
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var doc = new Document("26949692000102", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        [DataTestMethod]
        [DataRow("05912709000")] //DataRow para enviar mais de um cpf para o test
        [DataRow("09981995088")]
        [DataRow("63403376001")]
        public void ShouldReturnSuccessWhenCpfIsValid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}