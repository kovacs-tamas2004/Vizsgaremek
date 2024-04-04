using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYMGO.Shared.Models;
using GYMGO.Shared.Dtos;

namespace GYMGO.Shared.Extensions
{
    public static class OwnerExtension
    {
        public static OwnerDto ToDto(this Owner owner)
        {
            return new OwnerDto
            {
                Id = owner.Id,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                BirthsDay = owner.BirthsDay,
                Email = owner.Email,
                Tulajdon = owner.Tulajdon,
                Telepules = owner.Telepules,
            };
        }

        public static Owner ToModel(this OwnerDto ownerdto)
        {
            return new Owner
            {
                Id = ownerdto.Id,
                FirstName = ownerdto.FirstName,
                LastName = ownerdto.LastName,
                BirthsDay = ownerdto.BirthsDay,
                Email = ownerdto.Email,
                Tulajdon=ownerdto.Tulajdon,
                Telepules=ownerdto.Telepules,
            };
        }
    }
}
