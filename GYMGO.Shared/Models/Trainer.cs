using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMGO.Shared.Models
{
    public class Trainer : IDbEntity<Trainer>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthsDay { get; set; }
        public string Email { get; set; }
        public bool Fiatal { get; set; }
        public bool Kozep { get; set; }
        public bool Idos { get; set; }
        public string WorkingLevels { get; set; }
        public Guid AgeGroupId { get; set; }
        public Guid WorkingTypeId { get; set; }
        public bool HasId => Id != Guid.Empty;
        public string HungarianFullName
        {
            set { }
            get => $"{LastName} {FirstName}";
        }

        public Trainer(Guid id, string firstName, string lastName, DateTime birthsDay, string email, bool fiatal, bool kozep, bool idos, string workingLevels, Guid ageGroupid, Guid workingTypeid)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthsDay = birthsDay;
            Email = email;
            Fiatal = fiatal;
            Kozep = kozep;
            Idos = idos;
            WorkingLevels = workingLevels;
            AgeGroupId = ageGroupid;
            WorkingTypeId = workingTypeid;
        }

        public Trainer()
        {
            Id = Guid.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            BirthsDay = new DateTime();
            Email = string.Empty;
            WorkingLevels = string.Empty;
            AgeGroupId = Guid.Empty;
            WorkingTypeId= Guid.Empty;
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {String.Format("{0:yyyy.MM.dd.}", BirthsDay)}) {Email} {Fiatal} {Kozep} {Idos} {WorkingLevels}";
        }
    }
}
