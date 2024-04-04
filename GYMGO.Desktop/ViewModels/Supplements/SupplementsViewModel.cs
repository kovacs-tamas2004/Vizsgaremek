using GYMGO.Desktop.ViewModels.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace GYMGO.Desktop.ViewModels.Supplements
{
    public partial class SupplementsViewModel : BaseViewModel
    {
        private NutrionalViewModel _nutrionalViewModel;
        private EquipmentViewModel _equipmentViewModel;

        public SupplementsViewModel()
        {
            _currentSupplementsChildView = new NutrionalViewModel();
            _nutrionalViewModel = new NutrionalViewModel();
            _equipmentViewModel = new EquipmentViewModel();

        }

        public SupplementsViewModel(NutrionalViewModel nutrionalViewModel, EquipmentViewModel equipmentViewModel)
        {
            _nutrionalViewModel = nutrionalViewModel;
            _equipmentViewModel = equipmentViewModel;

            _currentSupplementsChildView = new NutrionalViewModel();
        }

        [ObservableProperty]
        private BaseViewModel _currentSupplementsChildView;


        [RelayCommand]
        public void ShowNutrionalView()
        {
            CurrentSupplementsChildView = _nutrionalViewModel;
        }

        [RelayCommand]
        public void ShowEquipmentlView()
        {
            CurrentSupplementsChildView = _equipmentViewModel;
        }
    }
}
