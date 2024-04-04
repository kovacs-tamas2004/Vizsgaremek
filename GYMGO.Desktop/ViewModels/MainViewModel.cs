using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FontAwesome.Sharp;
using GYMGO.Desktop.ViewModels.Base;
using GYMGO.Desktop.ViewModels.ControlPanel;
using GYMGO.Desktop.ViewModels.Gympass;
using GYMGO.Desktop.ViewModels.Users;
using GYMGO.Desktop.ViewModels.Supplements;

namespace GYMGO.Desktop.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        private ControlPanelViewModel _controlPanelViewModel;
        private UsersViewModel _usersViewModel;
        private GympassViewModel _gympassViewModel;
        private SupplementsViewModel _supplementsViewModel;

        public MainViewModel()
        {
            _controlPanelViewModel = new ControlPanelViewModel();
            _usersViewModel = new UsersViewModel();
            _gympassViewModel = new GympassViewModel();
            _supplementsViewModel = new SupplementsViewModel();

            _currentChildView = _controlPanelViewModel;
        }

        public MainViewModel(
            ControlPanelViewModel controlPanelViewModel,
            UsersViewModel usersViewModel,
            GympassViewModel gympassViewModel,
            SupplementsViewModel supplementsViewModel
            )
        {
            _controlPanelViewModel = controlPanelViewModel;
            _usersViewModel = usersViewModel;
            _gympassViewModel = gympassViewModel;
            _supplementsViewModel = supplementsViewModel;


            CurrentChildView = _controlPanelViewModel;
            ShowDashbord();
        }

        [ObservableProperty]
        private string _caption = string.Empty;

        [ObservableProperty]
        private IconChar _icon = new IconChar();

        [ObservableProperty]
        private BaseViewModel _currentChildView;

        [RelayCommand]
        public void ShowDashbord()
        {
            Caption = "Vezérlőpult";
            Icon=IconChar.SolarPanel;
            CurrentChildView = _controlPanelViewModel;
        }

        [RelayCommand]
        public void ShowUsers()
        {
            Caption = "Felhasználók";
            Icon = IconChar.UserGroup;
            CurrentChildView = _usersViewModel;
        }

        [RelayCommand]
        public void ShowGympass()
        {
            Caption = "Bérletek/jegyek";
            Icon = IconChar.CartShopping;
            CurrentChildView = _gympassViewModel;
        }

        [RelayCommand]
        public void ShowSupplements()
        {
            Caption = "Kiegészítők";
            Icon = IconChar.Pills;
            CurrentChildView = _supplementsViewModel;
        }
    }
}
