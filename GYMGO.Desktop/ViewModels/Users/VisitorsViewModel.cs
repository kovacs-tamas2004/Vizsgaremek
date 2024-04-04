using GYMGO.Desktop.ViewModels.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GYMGO.HttpService.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GYMGO.Shared.Models;
using GYMGO.Shared.Extensions;
using GYMGO.Shared.Responses;
using GYMGO.Desktop.Views.Users;

namespace GYMGO.Desktop.ViewModels.Users
{
    public partial class VisitorsViewModel : BaseViewModel
    {
        private readonly IVisitorService? _visitorService;

        [ObservableProperty]
        private ObservableCollection<string> _workingForms = new(new WorkingForm().AllWorkingForms);

        [ObservableProperty]
        private ObservableCollection<Visitor> _visitors = new();

        [ObservableProperty]
        private Visitor _selectedVisitor;

        private string _selectedWorkingForm = string.Empty;
        public string SelectedWorkingForm
        {
            get => _selectedWorkingForm;

            set
            {
                if (value != null && SelectedVisitor is not null)
                {
                    SetProperty(ref _selectedWorkingForm, value);
                    SelectedVisitor.WorkingForm = _selectedWorkingForm;
                }
            }
        }

        public uint FileteredMinBirthYear { get; set; } = 0;
        public uint FilteredMaxBirthYear { get; set; } = uint.MaxValue;
        public string SerchedName { get; set; } = string.Empty;

        public VisitorsViewModel()
        {
            SelectedVisitor = new Visitor();
            SelectedWorkingForm = _workingForms[0];
        }

        public VisitorsViewModel(IVisitorService? visitorService)
        {
            SelectedVisitor = new Visitor();

            _visitorService = visitorService;
        }

        [RelayCommand]
        public async Task DoSave(Visitor newVisitor)
        {
            if (_visitorService is not null && newVisitor is not null)
            {
                ControllerResponse result = new();
                if (newVisitor.HasId)
                    result = await _visitorService.UpdateAsync(newVisitor);
                else
                    result = await _visitorService.InsertAsync(newVisitor);
                if (!result.HasError)
                {
                    await UpdateView();
                }
            }
        }

        [RelayCommand]
        void DoNewVisitor()
        {
            SelectedVisitor = new Visitor();
        }

        [RelayCommand]
        private async Task DoSearchingAndFiltering()
        {
            if (_visitorService != null)
            {
                List<Visitor> visitors = await _visitorService.SearchAndFilterVisitorsAsync(this.ToVisitorQueryParameters());
                Visitors = new ObservableCollection<Visitor>(visitors);
                await UpdateView(false);
            }
        }

        [RelayCommand]
        private async Task DoResetFilterAndSerachParameter()
        {
            SerchedName = string.Empty;
            FileteredMinBirthYear = 0;
            FilteredMaxBirthYear = uint.MaxValue;
            await InitializeAsync();
        }

        private void SetFilteredMinMaxYear()
        {
            if (Visitors is not null && Visitors.Any())
            {
                FileteredMinBirthYear = (uint)Visitors.ToList().Select(visitor => visitor.BirthsDay.Year).Min();
                FilteredMaxBirthYear = (uint)Visitors.ToList().Select(visitor => visitor.BirthsDay.Year).Max();
            }
            else
            {
                FileteredMinBirthYear = FilteredMaxBirthYear = (uint)DateTime.Now.Year;
            }
        }

        [RelayCommand]
        public async Task DoRemove(Visitor visitorToDelete)
        {
            if (_visitorService is not null && visitorToDelete is not null)
            {
                ControllerResponse result = await _visitorService.DeleteAsync(visitorToDelete.Id);
                if (result is not null && !result.HasError)
                {
                    await UpdateView();
                }
            }
        }

        public override async Task InitializeAsync()
        {
            await UpdateView();
        }

        private async Task UpdateView(bool reloadData = true)
        {
            if (_visitorService is not null)
            {
                if (reloadData)
                {
                    List<Visitor> visitors = await _visitorService.SelectAllAsync();
                    Visitors = new ObservableCollection<Visitor>(visitors);
                }
                SetFilteredMinMaxYear();
            }
        }
    }
}