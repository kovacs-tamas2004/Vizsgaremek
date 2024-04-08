namespace GYMGO.Shared.Models
{
    public class Trainer : IDbEntity<Trainer>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthsDay { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool Young { get; set; }
        public bool Middle { get; set; }
        public bool Old { get; set; }
        public string WorkingLevels { get; set; }
        public Guid AgeGroupId { get; set; }
        public Guid WorkingTypeId { get; set; }
        public bool HasId => Id != Guid.Empty;
        public string HungarianFullName
        {
            set { }
            get => $"{LastName} {FirstName}";
        }

        public Trainer(Guid id, string firstName, string lastName, DateTime birthsDay, string email, string address, bool young, bool middle, bool old, string workingLevels, Guid ageGroupid, Guid workingTypeid)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthsDay = birthsDay;
            Email = email;
            Address = address;
            Young = young;
            Middle = middle;
            Old = old;
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
            Address = string.Empty;
            WorkingLevels = string.Empty;
            AgeGroupId = Guid.Empty;
            WorkingTypeId= Guid.Empty;
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {String.Format("{0:yyyy.MM.dd.}", BirthsDay)}) {Email} {Address} {Young} {Middle} {Old} {WorkingLevels}";
        }
    }
}
