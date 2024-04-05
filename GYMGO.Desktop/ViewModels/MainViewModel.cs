using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FontAwesome.Sharp;
using GYMGO.Desktop.ViewModels.Base;
using GYMGO.Desktop.ViewModels.ControlPanel;
using GYMGO.Desktop.ViewModels.Users;

namespace GYMGO.Desktop.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        private ControlPanelViewModel _controlPanelViewModel;
        private UsersViewModel _usersViewModel;

        public MainViewModel()
        {
            _controlPanelViewModel = new ControlPanelViewModel();
            _usersViewModel = new UsersViewModel();

            _currentChildView = _controlPanelViewModel;
        }

        public MainViewModel(
            ControlPanelViewModel controlPanelViewModel,
            UsersViewModel usersViewModel
            )
        {
            _controlPanelViewModel = controlPanelViewModel;
            _usersViewModel = usersViewModel;


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
    }
}
