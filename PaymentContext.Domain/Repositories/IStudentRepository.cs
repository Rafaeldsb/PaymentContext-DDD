using PaymentContext.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Domain.Repositories
{
    public interface IStudentRepository
    {
        bool DocumentExist(string document);
        bool EmailExist(string email);
        void CreateSubscription(Student student);

    }
}
