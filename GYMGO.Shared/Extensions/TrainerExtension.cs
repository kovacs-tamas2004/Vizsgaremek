using GYMGO.Shared.Models;
using GYMGO.Shared.Dtos;

namespace GYMGO.Shared.Extensions
{
    public static class TrainerExtension
    {
        public static TrainerDto ToDto(this Trainer trainer)
        {
            return new TrainerDto
            {
                Id = trainer.Id,
                FirstName = trainer.FirstName,
                LastName = trainer.LastName,
                BirthsDay = trainer.BirthsDay,
                Email = trainer.Email,
                Address = trainer.Address,
                Young = trainer.Young,
                Middle = trainer.Middle,
                Old = trainer.Old,
                WorkingLevels = trainer.WorkingLevels,
                AgeGroupId = trainer.AgeGroupId,
                WorkingTypeId = trainer.WorkingTypeId
            };
        }

        public static Trainer ToModel(this TrainerDto trainerdto)
        {
            return new Trainer
            {
                Id= trainerdto.Id,
                FirstName= trainerdto.FirstName,
                LastName= trainerdto.LastName,
                BirthsDay= trainerdto.BirthsDay,
                Email = trainerdto.Email,
                Address = trainerdto.Address,
                Young = trainerdto.Young,
                Middle = trainerdto.Middle,
                Old = trainerdto.Old,
                WorkingLevels= trainerdto.WorkingLevels,
                AgeGroupId = trainerdto.AgeGroupId,
                WorkingTypeId = trainerdto.WorkingTypeId
            };
        }
    }
}
