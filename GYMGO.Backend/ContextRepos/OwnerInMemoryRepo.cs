using GYMGO.Backend.Context;
using GYMGO.Backend.Repos;
using Microsoft.EntityFrameworkCore;

namespace GYMGO.Backend.ContextRepos
{
    public class OwnerInMemoryRepo : OwnerRepo<GymgoInMemoryContext>, IOwnerRepo
    {
        public OwnerInMemoryRepo(IDbContextFactory<GymgoInMemoryContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
