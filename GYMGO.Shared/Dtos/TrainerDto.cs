namespace GYMGO.Shared.Dtos
{
    public class TrainerDto
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

        public TrainerDto(Guid id, string firstName, string lastName, DateTime birthsDay, string email, string address, bool young, bool middle, bool old, string workingLevels, Guid ageGroupid, Guid workingTypeid)
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

        public TrainerDto()
        {
            Id = Guid.NewGuid();
            FirstName = string.Empty;
            LastName = string.Empty;
            BirthsDay = new DateTime();
            Email = string.Empty;
            Address = string.Empty;
            WorkingLevels = string.Empty;
            AgeGroupId = Guid.NewGuid();
            WorkingTypeId = Guid.NewGuid();
        }
    }
}
