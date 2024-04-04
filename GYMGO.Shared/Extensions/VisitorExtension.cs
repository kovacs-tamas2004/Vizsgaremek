using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYMGO.Shared.Models;
using GYMGO.Shared.Dtos;

namespace GYMGO.Shared.Extensions
{
    public static class VisitorExtension
    {
        public static VisitorDto ToDto(this Visitor visitor)
        {
            return new VisitorDto
            {
                Id = visitor.Id,
                FirstName = visitor.FirstName,
                LastName = visitor.LastName,
                BirthsDay = visitor.BirthsDay,
                Email = visitor.Email,
                WorkingForm = visitor.WorkingForm,
                WorkingFormId = visitor.WorkingFormId,
            };
        }

        public static Visitor ToModel(this VisitorDto visitordto)
        {
            return new Visitor
            {
                Id = visitordto.Id,
                FirstName = visitordto.FirstName,
                LastName = visitordto.LastName,
                BirthsDay = visitordto.BirthsDay,
                Email = visitordto.Email,
                WorkingForm = visitordto.WorkingForm,
                WorkingFormId = visitordto.WorkingFormId,
            };
        }
    }
}
