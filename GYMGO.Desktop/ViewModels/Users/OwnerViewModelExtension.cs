using GYMGO.Shared.Parameters;

namespace GYMGO.Desktop.ViewModels.Users
{
    public static class OwnerViewModelExtension
    {
        public static OwnerQueryParameters ToOwnerQueryParameters(this OwnersViewModel ownersViewModel)
        {
            return new OwnerQueryParameters
            {
                MinYearOfBirth = ownersViewModel.FileteredMinBirthYear,
                MaxYearOfBirth = ownersViewModel.FilteredMaxBirthYear,
                Name = ownersViewModel.SerchedName
            };
        }
    }
}
