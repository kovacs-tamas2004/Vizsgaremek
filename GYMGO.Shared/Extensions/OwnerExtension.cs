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
                Address = owner.Address,
                Ownership = owner.Ownership,
                Settlement = owner.Settlement,
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
                Address = ownerdto.Address,
                Ownership = ownerdto.Ownership,
                Settlement = ownerdto.Settlement,
            };
        }
    }
}
