﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GYMGO.Desktop.ViewModels.Base;
using GYMGO.Desktop.Views.Users;
using GYMGO.HttpService.Service;
using GYMGO.Shared.Models;
using GYMGO.Shared.Responses;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMGO.Desktop.ViewModels.Users
{
    public partial class OwnersViewModel : BaseViewModel
    {
        private readonly IOwnerService? _ownerService;

        [ObservableProperty]
        private ObservableCollection<Owner> _owners = new();

        [ObservableProperty]
        private Owner _selectedOwner;

        public uint FileteredMinBirthYear { get; set; } = 0;
        public uint FilteredMaxBirthYear { get; set; } = uint.MaxValue;
        public string SerchedName { get; set; } = string.Empty;

        public OwnersViewModel()
        {
            SelectedOwner = new Owner();
        }

        public OwnersViewModel(IOwnerService? ownerService)
        {
            SelectedOwner = new Owner();

            _ownerService = ownerService;
        }

        [RelayCommand]
        public async Task DoSave(Owner newOwner)
        {
            if (_ownerService is not null && newOwner is not null)
            {
                try
                {
                    using (var connection = new MySqlConnection("Server=localhost;Database=desktop;Uid=desktop_user;Pwd=password;"))
                    {
                        await connection.OpenAsync();

                        MySqlCommand command;
                        if (newOwner.HasId)
                        {
                            command = new MySqlCommand(
                                "UPDATE Owners SET LastName = @LastName, FirstName = @FirstName, " +
                                "BirthsDay = @BirthsDay, Email = @Email, Address = @Address, Ownership = @Ownership, Settlement = @Settlement " +
                                "WHERE Id = @Id", connection);
                            command.Parameters.AddWithValue("@Id", newOwner.Id);
                        }
                        else
                        {
                            command = new MySqlCommand(
                                "INSERT INTO Owners (LastName, FirstName, BirthsDay, Email, Address, Ownership, Settlement) " +
                                "VALUES (@LastName, @FirstName, @BirthsDay, @Email, @Address, @Ownership, @Settlement)", connection);
                        }

                        command.Parameters.AddWithValue("@LastName", newOwner.LastName);
                        command.Parameters.AddWithValue("@FirstName", newOwner.FirstName);
                        command.Parameters.AddWithValue("@BirthsDay", newOwner.BirthsDay);
                        command.Parameters.AddWithValue("@Email", newOwner.Email);
                        command.Parameters.AddWithValue("@Address", newOwner.Address);
                        command.Parameters.AddWithValue("@Ownership", newOwner.Ownership);
                        command.Parameters.AddWithValue("@Settlement", newOwner.Settlement);

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
        void DoNewOwner()
        {
            SelectedOwner = new Owner();
        }

        [RelayCommand]
        private async Task DoSearchingAndFiltering()
        {
            if (_ownerService != null)
            {
                List<Owner> owners = await _ownerService.SearchAndFilterOwnersAsync(this.ToOwnerQueryParameters());
                Owners = new ObservableCollection<Owner>(owners);
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
            if (Owners is not null && Owners.Any())
            {
                FileteredMinBirthYear = (uint)Owners.ToList().Select(owner => owner.BirthsDay.Year).Min();
                FilteredMaxBirthYear = (uint)Owners.ToList().Select(owner => owner.BirthsDay.Year).Max();
            }
            else
            {
                FileteredMinBirthYear = FilteredMaxBirthYear = (uint)DateTime.Now.Year;
            }
        }

        [RelayCommand]
        public async Task DoRemove(Owner ownerToDelete)
        {
            if (_ownerService is not null && ownerToDelete is not null)
            {
                ControllerResponse result = await _ownerService.DeleteAsync(ownerToDelete.Id);
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
            if (_ownerService is not null)
            {
                if (reloadData)
                {
                    List<Owner> owners = await _ownerService.SelectAllAsync();
                    Owners = new ObservableCollection<Owner>(owners);
                }
                SetFilteredMinMaxYear();
            }
        }
    }
}
