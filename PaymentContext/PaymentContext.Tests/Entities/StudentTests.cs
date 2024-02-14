using paymentcontext.Domain.Entities;

namespace paymentcontext.tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void AdicionarAssinatura()
        {
            var subscription = new Subscription(null);
            var student = new Student("André", "Baltieri", "123456789", "hello@ablta.io");
            student.AddSubscription(subscription);
        }
    }
}