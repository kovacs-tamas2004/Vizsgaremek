using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                Fiatal = trainer.Fiatal,
                Kozep = trainer.Kozep,
                Idos = trainer.Idos,
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
                Fiatal = trainerdto.Fiatal,
                Kozep = trainerdto.Kozep,
                Idos = trainerdto.Idos,
                WorkingLevels= trainerdto.WorkingLevels,
                AgeGroupId = trainerdto.AgeGroupId,
                WorkingTypeId = trainerdto.WorkingTypeId
            };
        }
    }
}
