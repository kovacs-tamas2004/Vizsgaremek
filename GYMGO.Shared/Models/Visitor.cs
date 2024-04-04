using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMGO.Shared.Models
{
    public class Visitor : IDbEntity<Visitor>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthsDay { get; set; }
        public string Email { get; set; }
        public string WorkingForm { get; set; }
        public Guid WorkingFormId { get; set; }
        public bool HasId => Id != Guid.Empty;
        public string HungarianFullName
        {
            set { }
            get => $"{LastName} {FirstName}";
        }

        public Visitor(Guid id, string firstName, string lastName, DateTime birthsDay, string email, string workingForm, Guid workingFormId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthsDay = birthsDay;
            Email = email;
            WorkingForm = workingForm;
            WorkingFormId = workingFormId;
        }

        public Visitor()
        {
            Id = Guid.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            BirthsDay = new DateTime();
            Email = string.Empty;
            WorkingForm = string.Empty;
            WorkingFormId = Guid.Empty;
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {String.Format("{0:yyyy.MM.dd.}", BirthsDay)}) {Email} {WorkingForm}";
        }
    }
}
