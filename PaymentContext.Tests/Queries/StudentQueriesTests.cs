using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTests
    {
        private IList<Student> _students = new List<Student>();

        public StudentQueriesTests()
        {
            for(var i = 0; i <= 10; i++)
            {
                _students.Add(new Student(
                    new Name("Aluno", i.ToString()),
                    new Document("1111111111" + i.ToString(), Domain.Enums.EDocumentType.CPF),
                    new Email(i.ToString() + "@teste.com")
                ));
            }
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("12345678910");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.IsNull(studn);
        }

        [TestMethod]
        public void ShouldReturnNotNullWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("11111111115");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.IsNotNull(studn);
        }
    }
}
