using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string neighbohood, string city, string state, string coutry, string zipCode)
        {
            Street = street;
            Number = number;
            Neighbohood = neighbohood;
            City = city;
            State = state;
            Coutry = coutry;
            ZipCode = zipCode;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Street, 3, "Address.Street", "A rua deve conter pelo menos 3 caracteres")
            );
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighbohood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Coutry { get; private set; }
        public string ZipCode { get; private set; }
    }
}
