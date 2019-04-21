using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExist()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Rafael";
            command.LastName = "Bernardo";
            command.Document = "99999999999";
            command.Email = "t@t.com";
            command.BarCode = "123456789";
            command.BoletoNumber = "12345678";
            command.PaymentNumber = "213135";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 50;
            command.TotalPaid = 50;
            command.Payer = "Bernardo";
            command.PayerEmail = "h@h.com";
            command.PayerDocument = "10350828962";
            command.PayerDocumentType = Domain.Enums.EDocumentType.CPF;
            command.Street = "awd";
            command.Number = "awd";
            command.Neighbohood = "awdw";
            command.City = "awd";
            command.State = "awd";
            command.Coutry = "awd";
            command.ZipCode = "awd";

            handler.Handle(command);
            Assert.IsFalse(handler.Valid);

    }
    }
}
