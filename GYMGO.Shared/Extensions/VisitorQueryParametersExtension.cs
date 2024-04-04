using GYMGO.Shared.Dtos;
using GYMGO.Shared.Parameters;

namespace GYMGO.Shared.Extensions
{
    public static class VisitorQueryParametersExtension
    {
        public static VisitorQueryParametersDto ToDto(this VisitorQueryParameters parameters)
        {
            return new VisitorQueryParametersDto
            {
                MaxYearOfBirth = parameters.MaxYearOfBirth,
                MinYearOfBirth = parameters.MinYearOfBirth,
                Name = parameters.Name,
            };
        }

        public static VisitorQueryParameters ToVisitorQueryParameters(this VisitorQueryParametersDto parameters)
        {
            return new VisitorQueryParameters
            {
                MinYearOfBirth = parameters.MinYearOfBirth,
                MaxYearOfBirth = parameters.MaxYearOfBirth,
                Name = parameters.Name,
            };
        }
    }
}
