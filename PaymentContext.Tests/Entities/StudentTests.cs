using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Email _email;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            _name = new Name("Rafael", "Bernardo");
            _document = new Document("10350828962", Domain.Enums.EDocumentType.CPF);
            _email = new Email("rafael.dsbernardo@gmail.com");
            _address = new Address("Rua 1", "123", "Legal", "Londrina", "PR", "BR", "86031280");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);

        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PayPalPayment(DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "BERNARDO", _document, _address, _email, "123456789");

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenHaNodActiveSubscription()
        {
            var payment = new PayPalPayment(DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "BERNARDO", _document, _address, _email, "123456789");

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Valid);
        }
    }
}
