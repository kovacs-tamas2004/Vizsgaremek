using System;
using System.Collections.Generic;
namespace GYMGO.Shared.Dtos
{
    public class OwnerDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthsDay { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Ownership { get; set; }
        public string Settlement { get; set; }

        public OwnerDto(Guid id, string firstName, string lastName, DateTime birthsDay, string email, string address, string ownership, string settlement)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthsDay = birthsDay;
            Email = email;
            Address = address;
            Ownership = ownership;
            Settlement = settlement;
        }

        public OwnerDto()
        {
            Id = Guid.NewGuid();
            FirstName = string.Empty;
            LastName = string.Empty;
            BirthsDay = new DateTime();
            Email = string.Empty;
            Address = string.Empty;
            Ownership = string.Empty;
            Settlement = string.Empty;
        }
    }
}
