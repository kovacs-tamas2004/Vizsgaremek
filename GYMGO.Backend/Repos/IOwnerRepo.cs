using GYMGO.Shared.Models;
using GYMGO.Shared.Parameters;

namespace GYMGO.Backend.Repos
{
    public interface IOwnerRepo : IRepositoryBase<Owner>
    {
        public IQueryable<Owner> GetOwners(OwnerQueryParameters parameters);
    }
}
