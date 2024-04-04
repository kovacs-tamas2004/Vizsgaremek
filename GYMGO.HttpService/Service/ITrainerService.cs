using GYMGO.Shared.Models;
using GYMGO.Shared.Dtos;
using GYMGO.Shared.Responses;
using GYMGO.Shared.Parameters;

namespace GYMGO.HttpService.Service
{
    public interface ITrainerService : IBaseService<Trainer>
    {
        public Task<List<Trainer>> SearchAndFilterTrainersAsync(TrainerQueryParameters trainerQueryParameters);

    }
}
