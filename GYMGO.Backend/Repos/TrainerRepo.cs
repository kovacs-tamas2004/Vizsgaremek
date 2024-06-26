﻿using GYMGO.Backend.Context;
using GYMGO.Shared.Models;
using GYMGO.Shared.Parameters;
using GYMGO.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace GYMGO.Backend.Repos
{
    public class TrainerRepo<TDbConstext> : RepositoryBase<TDbConstext, Trainer>, ITrainerRepo
        where TDbConstext : DbContext
    {
        public TrainerRepo(IDbContextFactory<TDbConstext> dbContextFactory) : base(dbContextFactory)
        {
            
        }

        public IQueryable<Trainer> GetTrainers(TrainerQueryParameters parameters)
        {
            IQueryable<Trainer> filteredTrainer = FindByCondition(trainer => trainer.BirthsDay.Year >= parameters.MinYearOfBirth
                                           && trainer.BirthsDay.Year <= parameters.MaxYearOfBirth
                                  )
                                  .OrderBy(trainer => trainer.HungarianFullName);

            SearchByTrainerName(ref filteredTrainer, parameters.Name);
            return filteredTrainer;
        }

        private void SearchByTrainerName(ref IQueryable<Trainer> trainers, string trainerName)
        {
            if (!trainers.Any() || string.IsNullOrEmpty(trainerName))
            {
                return;
            }
            trainers = trainers.Where(trainer => trainer.HungarianFullName.ToLower().Contains(trainerName.Trim().ToLower()));
        }
    }
}
