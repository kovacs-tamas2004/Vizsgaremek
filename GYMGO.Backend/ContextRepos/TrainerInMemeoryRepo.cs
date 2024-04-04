using GYMGO.Backend.Context;
using GYMGO.Backend.Repos;
using Microsoft.EntityFrameworkCore;

namespace GYMGO.Backend.ContextRepos
{
    public class TrainerInMemoryRepo : TrainerRepo<GymgoInMemoryContext>, ITrainerRepo
    {
        public TrainerInMemoryRepo(IDbContextFactory<GymgoInMemoryContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
