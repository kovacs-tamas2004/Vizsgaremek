using GYMGO.Shared.Dtos;
using GYMGO.Shared.Extensions;
using GYMGO.Shared.Models;

namespace GYMGO.Shared.Assamblers
{
    public class TrainerAssambler : Assambler<Trainer, TrainerDto>
    {
        public override TrainerDto ToDto(Trainer model)
        {
            return model.ToDto();
        }

        public override Trainer ToModel(TrainerDto dto)
        {
            return dto.ToModel();
        }
    }
}
