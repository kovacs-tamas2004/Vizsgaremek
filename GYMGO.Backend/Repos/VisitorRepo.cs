using GYMGO.Backend.Context;
using GYMGO.Shared.Models;
using GYMGO.Shared.Parameters;
using GYMGO.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace GYMGO.Backend.Repos
{
    public class VisitorRepo<TDbConstext> : RepositoryBase<TDbConstext, Visitor>, IVisitorRepo
        where TDbConstext : DbContext
    {
        public VisitorRepo(IDbContextFactory<TDbConstext> dbContextFactory) : base(dbContextFactory)
        {

        }

        public IQueryable<Visitor> GetVisitors(VisitorQueryParameters parameters)
        {
            IQueryable<Visitor> filteredVisitor = FindByCondition(visitor => visitor.BirthsDay.Year >= parameters.MinYearOfBirth
                                           && visitor.BirthsDay.Year <= parameters.MaxYearOfBirth
                                  )
                                  .OrderBy(visitor => visitor.HungarianFullName);

            SearchByVisitorName(ref filteredVisitor, parameters.Name);
            return filteredVisitor;
        }

        private void SearchByVisitorName(ref IQueryable<Visitor> visitors, string visitorName)
        {
            if (!visitors.Any() || string.IsNullOrEmpty(visitorName))
            {
                return;
            }
            visitors = visitors.Where(visitor => visitor.HungarianFullName.ToLower().Contains(visitorName.Trim().ToLower()));
        }
    }
}
