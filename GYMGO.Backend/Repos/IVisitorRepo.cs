using GYMGO.Shared.Models;
using GYMGO.Shared.Parameters;

namespace GYMGO.Backend.Repos
{
    public interface IVisitorRepo : IRepositoryBase<Visitor>
    {
        public IQueryable<Visitor> GetVisitors(VisitorQueryParameters parameters);
    }
}
