using GYMGO.Shared.Parameters;

namespace GYMGO.Desktop.ViewModels.Users
{
    public static class TrainerViewModelExtension
    {
        public static TrainerQueryParameters ToTrainerQueryParameters(this TrainersViewModel trainersViewModel)
        {
            return new TrainerQueryParameters
            {
                MinYearOfBirth = trainersViewModel.FileteredMinBirthYear,
                MaxYearOfBirth = trainersViewModel.FilteredMaxBirthYear,
                Name = trainersViewModel.SerchedName
            };
        }
    }
}
