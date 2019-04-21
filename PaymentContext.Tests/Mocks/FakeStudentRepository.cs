using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        {
        }

        public bool DocumentExist(string document)
        {
            if (document == "99999999999")
                return true;
            return false;
        }

        public bool EmailExist(string email)
        {
            if (email == "teste@teste.com")
                return true;
            return false;
        }
    }
}
