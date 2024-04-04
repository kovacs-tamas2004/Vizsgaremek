using GYMGO.Shared.Parameters;

namespace GYMGO.Desktop.ViewModels.Users
{
    public static class VisitorViewModelExtension
    {
        public static VisitorQueryParameters ToVisitorQueryParameters(this VisitorsViewModel visitorsViewModel)
        {
            return new VisitorQueryParameters
            {
                MinYearOfBirth = visitorsViewModel.FileteredMinBirthYear,
                MaxYearOfBirth = visitorsViewModel.FilteredMaxBirthYear,
                Name = visitorsViewModel.SerchedName
            };
        }
    }
}
