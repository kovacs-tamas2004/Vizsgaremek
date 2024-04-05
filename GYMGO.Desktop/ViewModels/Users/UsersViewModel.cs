using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GYMGO.Desktop.ViewModels.Base;
using System.Threading.Tasks;
using GYMGO.HttpService.Service;
using System.Net.Http;

namespace GYMGO.Desktop.ViewModels.Users
{
    public partial class UsersViewModel : BaseViewModel
    {
        private readonly VisitorsViewModel _visitorsViewModel;
        private readonly OwnersViewModel _ownersViewModel;
        private readonly TrainersViewModel _trainersViewModel;

        public UsersViewModel()
        {
            _currentVisitorsChildView = new VisitorsViewModel();
            _visitorsViewModel = new VisitorsViewModel();
            _ownersViewModel = new OwnersViewModel();            
            _trainersViewModel=new TrainersViewModel();
        }

        public UsersViewModel(VisitorsViewModel visitorsViewModel, OwnersViewModel ownersViewModel, TrainersViewModel trainersViewModel)
        {
            _visitorsViewModel = visitorsViewModel;
            _ownersViewModel = ownersViewModel;
            _trainersViewModel = trainersViewModel;

            _currentVisitorsChildView = new VisitorsViewModel();
        }

        [ObservableProperty]
        private BaseViewModel _currentVisitorsChildView;


        [RelayCommand]
        public async Task ShowVisitorsView()
        {
            await _visitorsViewModel.InitializeAsync();
            CurrentVisitorsChildView = _visitorsViewModel;
        }

        [RelayCommand]
        public async Task ShowOwnersView()
        {
            await _ownersViewModel.InitializeAsync();
            CurrentVisitorsChildView = _ownersViewModel;
        }

        [RelayCommand]
        public async Task ShowTrainersView()
        {
            await _trainersViewModel.InitializeAsync();
            CurrentVisitorsChildView = _trainersViewModel;
        }
    }
}
