using GYMGO.Shared.Models;
using GYMGO.Shared.Parameters;

namespace GYMGO.Backend.Repos
{
    public interface ITrainerRepo : IRepositoryBase<Trainer>
    {
        public IQueryable<Trainer> GetTrainers(TrainerQueryParameters parameters);
    }
}
