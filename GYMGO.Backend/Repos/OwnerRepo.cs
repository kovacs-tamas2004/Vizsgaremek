using GYMGO.Backend.Context;
using GYMGO.Shared.Models;
using GYMGO.Shared.Parameters;
using GYMGO.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace GYMGO.Backend.Repos
{
    public class OwnerRepo<TDbConstext> : RepositoryBase<TDbConstext, Owner>, IOwnerRepo
        where TDbConstext : DbContext
    {
        public OwnerRepo(IDbContextFactory<TDbConstext> dbContextFactory) : base(dbContextFactory)
        {

        }

        public IQueryable<Owner> GetOwners(OwnerQueryParameters parameters)
        {
            IQueryable<Owner> filteredOwner = FindByCondition(owner => owner.BirthsDay.Year >= parameters.MinYearOfBirth
                                           && owner.BirthsDay.Year <= parameters.MaxYearOfBirth
                                  )
                                  .OrderBy(owner => owner.HungarianFullName);

            SearchByOwnerName(ref filteredOwner, parameters.Name);
            return filteredOwner;
        }

        private void SearchByOwnerName(ref IQueryable<Owner> owners, string ownerName)
        {
            if (!owners.Any() || string.IsNullOrEmpty(ownerName))
            {
                return;
            }
            owners = owners.Where(owner => owner.HungarianFullName.ToLower().Contains(ownerName.Trim().ToLower()));
        }
    }
}
