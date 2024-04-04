using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMGO.Shared.Dtos
{
    public class OwnerDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthsDay { get; set; }
        public string Email { get; set; }
        public string Tulajdon { get; set; }
        public string Telepules { get; set; }

        public OwnerDto(Guid id, string firstName, string lastName, DateTime birthsDay, string email, string tulajdon, string telepules)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthsDay = birthsDay;
            Email = email;
            Tulajdon = tulajdon;
            Telepules = telepules;
        }

        public OwnerDto()
        {
            Id = Guid.NewGuid();
            FirstName = string.Empty;
            LastName = string.Empty;
            BirthsDay = new DateTime();
            Email = string.Empty;
            Tulajdon = string.Empty;
            Telepules = string.Empty;
        }
    }
}
