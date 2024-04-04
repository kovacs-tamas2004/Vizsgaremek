using GYMGO.Backend.Context;
using GYMGO.Backend.Repos;
using Microsoft.EntityFrameworkCore;

namespace GYMGO.Backend.ContextRepos
{
    public class VisitorInMemoryRepo : VisitorRepo<GymgoInMemoryContext>, IVisitorRepo
    {
        public VisitorInMemoryRepo(IDbContextFactory<GymgoInMemoryContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
