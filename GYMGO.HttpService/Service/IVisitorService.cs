using GYMGO.Shared.Models;
using GYMGO.Shared.Dtos;
using GYMGO.Shared.Responses;
using GYMGO.Shared.Parameters;

namespace GYMGO.HttpService.Service
{
    public interface IVisitorService : IBaseService<Visitor>
    {
        public Task<List<Visitor>> SearchAndFilterVisitorsAsync(VisitorQueryParameters visitorQueryParameters);

    }
}
