using GYMGO.Shared.Models;
using GYMGO.Shared.Dtos;
using GYMGO.Shared.Responses;
using GYMGO.Shared.Parameters;

namespace GYMGO.HttpService.Service
{
    public interface IOwnerService : IBaseService<Owner>
    {
        public Task<List<Owner>> SearchAndFilterOwnersAsync(OwnerQueryParameters ownerQueryParameters);

    }
}
