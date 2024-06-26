﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GYMGO.HttpService.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GYMGO.Shared.Models;
using GYMGO.Shared.Responses;
using GYMGO.desktop.ViewModels.Base;
using MySql.Data.MySqlClient;

namespace GYMGO.Desktop.ViewModels.Users
{
    public partial class TrainersViewModel : BaseViewModelWithAsyncInitialization
    {
        private readonly ITrainerService? _trainerService;

        [ObservableProperty]
        private ObservableCollection<string> _workingLevels = new(new WorkingLevels().AllWorkingLevels);

        [ObservableProperty]
        private ObservableCollection<Trainer> _trainers = new();

        [ObservableProperty]
        private Trainer _selectedTrainer;

        private string _selectedWorkingLevels = string.Empty;
        public string SelectedWorkingLevels
        {
            get => _selectedWorkingLevels;

            set
            {
                if (value != null && SelectedTrainer is not null)
                {
                    SetProperty(ref _selectedWorkingLevels, value);
                    SelectedTrainer.WorkingLevels = _selectedWorkingLevels;
                }
            }
        }

        public uint FileteredMinBirthYear { get; set; } = 0;
        public uint FilteredMaxBirthYear { get; set; } = uint.MaxValue;
        public string SerchedName { get; set; } = string.Empty;

        public TrainersViewModel()
        {
            SelectedTrainer = new Trainer();
            SelectedWorkingLevels = _workingLevels[0];
        }

        public TrainersViewModel(ITrainerService? trainerService)
        {
            SelectedTrainer = new Trainer();

            _trainerService = trainerService;
        }

        [RelayCommand]
        public async Task DoSave(Trainer newTrainer)
        {
            if (_trainerService is not null && newTrainer is not null)
            {
                try
                {
                    using (var connection = new MySqlConnection("Server=localhost;Database=desktop;Uid=desktop_user;Pwd=password;"))
                    {
                        await connection.OpenAsync();

                        MySqlCommand command;
                        if (newTrainer.HasId)
                        {
                            command = new MySqlCommand(
                                "UPDATE Trainers SET LastName = @LastName, FirstName = @FirstName, " +
                                "BirthsDay = @BirthsDay, Email = @Email, Address = @Address, WorkingLevels = @WorkingLevels, " +
                                "Young = @Young, Middle = @Middle, Old = @Old " +
                                "WHERE Id = @Id", connection);
                            command.Parameters.AddWithValue("@Id", newTrainer.Id);
                        }
                        else
                        {
                            command = new MySqlCommand(
                                "INSERT INTO Trainers (LastName, FirstName, BirthsDay, Email, Address, Young, Middle, Old, WorkingLevels) " +
                                "VALUES (@LastName, @FirstName, @BirthsDay, @Email, @Address, @Young, @Middle, @Old, @WorkingLevels)", connection);
                        }

                        command.Parameters.AddWithValue("@LastName", newTrainer.LastName);
                        command.Parameters.AddWithValue("@FirstName", newTrainer.FirstName);
                        command.Parameters.AddWithValue("@BirthsDay", newTrainer.BirthsDay);
                        command.Parameters.AddWithValue("@Email", newTrainer.Email);
                        command.Parameters.AddWithValue("@Address", newTrainer.Address);
                        command.Parameters.AddWithValue("@Young", newTrainer.Young);
                        command.Parameters.AddWithValue("@Middle", newTrainer.Middle);
                        command.Parameters.AddWithValue("@Old", newTrainer.Old);
                        command.Parameters.AddWithValue("@WorkingLevels", newTrainer.WorkingLevels);

                        await command.ExecuteNonQueryAsync();

                        await UpdateView();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hiba történt az adatok mentése közben: {ex.Message}");
                }
            }    
        }

        [RelayCommand]
        void DoNewTrainer()
        {
            SelectedTrainer = new Trainer();
        }

        [RelayCommand]
        private async Task DoSearchingAndFiltering()
        {
            if (_trainerService != null)
            {
                List<Trainer> trainers = await _trainerService.SearchAndFilterTrainersAsync(this.ToTrainerQueryParameters());
                Trainers = new ObservableCollection<Trainer>(trainers);
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
            if (Trainers is not null && Trainers.Any())
            {
                FileteredMinBirthYear = (uint)Trainers.ToList().Select(trainer => trainer.BirthsDay.Year).Min();
                FilteredMaxBirthYear = (uint)Trainers.ToList().Select(trainer => trainer.BirthsDay.Year).Max();
            }
            else
            {
                FileteredMinBirthYear = FilteredMaxBirthYear = (uint)DateTime.Now.Year;
            }
        }

        [RelayCommand]
        public async Task DoRemove(Trainer trainerToDelete)
        {
            if (_trainerService is not null && trainerToDelete is not null)
            {
                ControllerResponse result = await _trainerService.DeleteAsync(trainerToDelete.Id);
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
            if (_trainerService is not null)
            {
                if (reloadData)
                {
                    List<Trainer> trainers = await _trainerService.SelectAllAsync();
                    Trainers = new ObservableCollection<Trainer>(trainers);
                }
                SetFilteredMinMaxYear();
            }
        }
    }
}
