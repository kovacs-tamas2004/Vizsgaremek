using GYMGO.Shared.Dtos;
using GYMGO.Shared.Extensions;
using GYMGO.Shared.Models;

namespace GYMGO.Shared.Assamblers
{
    public class VisitorAssambler : Assambler<Visitor, VisitorDto>
    {
        public override VisitorDto ToDto(Visitor model)
        {
            return model.ToDto();
        }

        public override Visitor ToModel(VisitorDto dto)
        {
            return dto.ToModel();
        }
    }
}
