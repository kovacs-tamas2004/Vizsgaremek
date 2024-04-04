using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMGO.Shared.Dtos
{
    public class VisitorDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthsDay { get; set; }
        public string Email { get; set; }
        public string WorkingForm { get; set; }
        public Guid WorkingFormId { get; set; }

        public VisitorDto(Guid id, string firstName, string lastName, DateTime birthsDay, string email, string workingForm, Guid workingFormId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthsDay = birthsDay;
            Email = email;
            WorkingForm = workingForm;
            WorkingFormId = workingFormId;
        }

        public VisitorDto()
        {
            Id = Guid.NewGuid();
            FirstName = string.Empty;
            LastName = string.Empty;
            BirthsDay = new DateTime();
            Email = string.Empty;
            WorkingForm = string.Empty;
            WorkingFormId = Guid.NewGuid();
        }
    }
}
