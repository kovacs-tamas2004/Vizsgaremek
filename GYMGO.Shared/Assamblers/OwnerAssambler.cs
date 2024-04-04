using GYMGO.Shared.Dtos;
using GYMGO.Shared.Extensions;
using GYMGO.Shared.Models;

namespace GYMGO.Shared.Assamblers
{
    public class OwnerAssambler : Assambler<Owner, OwnerDto>
    {
        public override OwnerDto ToDto(Owner model)
        {
            return model.ToDto();
        }

        public override Owner ToModel(OwnerDto dto)
        {
            return dto.ToModel();
        }
    }
}
