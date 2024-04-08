using System;
using System.Collections.Generic;
namespace GYMGO.Shared.Dtos
{
    public class VisitorDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthsDay { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string WorkingForm { get; set; }
        public Guid WorkingFormId { get; set; }

        public VisitorDto(Guid id, string firstName, string lastName, DateTime birthsDay, string email, string address, string workingForm, Guid workingFormId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthsDay = birthsDay;
            Email = email;
            Address = address;
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
            Address = string.Empty;
            WorkingForm = string.Empty;
            WorkingFormId = Guid.NewGuid();
        }
    }
}
