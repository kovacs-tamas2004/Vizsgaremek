using GYMGO.Desktop.ViewModels.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYMGO.Desktop.ViewModels.Gympass;

namespace GYMGO.Desktop.ViewModels.Gympass
{
    public partial class GympassViewModel : BaseViewModel
    {
        private PassesViewModel _passesViewModel;
        private TicketsViewModel _ticketsViewModel;

        public GympassViewModel()
        {
            _currentGympassChildView = new PassesViewModel();
            _passesViewModel = new PassesViewModel();
            _ticketsViewModel = new TicketsViewModel();
        }

        public GympassViewModel(PassesViewModel passesViewModel, TicketsViewModel ticketsViewModel)
        {
            _passesViewModel = passesViewModel;
            _ticketsViewModel = ticketsViewModel;

            _currentGympassChildView = new PassesViewModel();
        }

        [ObservableProperty]
        private BaseViewModel _currentGympassChildView;


        [RelayCommand]
        public void ShowPassesView()
        {
            CurrentGympassChildView = _passesViewModel;
        }

        [RelayCommand]
        public void ShowTicketsView()
        {
            CurrentGympassChildView = _ticketsViewModel;
        }
    }
}
