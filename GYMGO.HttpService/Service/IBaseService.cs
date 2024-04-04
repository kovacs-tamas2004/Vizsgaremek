using GYMGO.Shared.Responses;
using GYMGO.Shared.Models;

namespace GYMGO.HttpService.Service
{
    public interface IBaseService<TEntity>
    {
        public Task<List<TEntity>> SelectAllAsync();
        public Task<ControllerResponse> UpdateAsync(TEntity entity);
        public Task<ControllerResponse> DeleteAsync(Guid id);
        public Task<ControllerResponse> InsertAsync(TEntity entity);
    }
}
