using GYMGO.Shared.Dtos;
using GYMGO.Shared.Parameters;

namespace GYMGO.Shared.Extensions
{
    public static class OwnerQueryParametersExtension
    {
        public static OwnerQueryParametersDto ToDto(this OwnerQueryParameters parameters)
        {
            return new OwnerQueryParametersDto
            {
                MaxYearOfBirth = parameters.MaxYearOfBirth,
                MinYearOfBirth = parameters.MinYearOfBirth,
                Name = parameters.Name,
            };
        }

        public static OwnerQueryParameters ToOwnerQueryParameters(this OwnerQueryParametersDto parameters)
        {
            return new OwnerQueryParameters
            {
                MinYearOfBirth = parameters.MinYearOfBirth,
                MaxYearOfBirth = parameters.MaxYearOfBirth,
                Name = parameters.Name,
            };
        }
    }
}
