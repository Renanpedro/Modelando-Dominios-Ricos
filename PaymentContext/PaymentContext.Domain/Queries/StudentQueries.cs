using System.Linq.Expressions;
using paymentcontext.Domain.Entities;

namespace PaymentContext.Domain.Queries
{
      public static class StudentQueries
    {
        public static Expression<Func<Student, bool>> GetStudentInfo(string document)
        {
            return x => x.Document.Number == document;
        }

    }
}