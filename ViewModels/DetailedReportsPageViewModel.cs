using key_managment_system.DBContexts;
using key_managment_system.Models;
using key_managment_system.Views.Manager;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace key_managment_system.ViewModels
{
    public class DetailedReportsPageViewModel : ViewModelBase
    {
        private int _userId;
        private string _firstName;
        private string _lastName;

        private DateTime _startDate;
        private DateTime _endDate;

        public DetailedReportsPageViewModel(int userId)
        {
            _userId = userId;
            LoadUserData();
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            GenerateReport = new ViewModelCommand(ExecuteGenerateReportCommand, CanExecuteGenerateReportCommand);
        }

        public string FirstName
        { get => _firstName; set { _firstName = value; OnPropertyChanged(nameof(FirstName)); } }
        public string LastName
        { get => _lastName; set { _lastName = value; OnPropertyChanged(nameof(LastName)); } }

        public DateTime StartDate
        { get => _startDate; set { _startDate = value; OnPropertyChanged(nameof(StartDate)); } }

        public DateTime EndDate
        { get => _endDate; set { _endDate = value; OnPropertyChanged(nameof(EndDate)); } }

        public ICommand GenerateReport { get; }

        private bool CanExecuteGenerateReportCommand(object obj)
        {
            return true;
        }

        private async void ExecuteGenerateReportCommand(object obj)
        {
            var context = new Context();
            var userData = await context.Users.FindAsync(_userId);
            var keycard = await context.Keycards.FirstOrDefaultAsync(k => k.Id.Equals(userData.KeycardId));
            
            userData.FirstName = FirstName;
            userData.LastName = LastName;

            DetailedReportsResults newWindow = new DetailedReportsResults(FirstName,LastName,StartDate,EndDate);
            newWindow.Show();

        }

        private async void LoadUserData()
        {
            // Fetch user data from the database based on _userId
            // Example code (you need to implement this based on your database structure):
            using (Context c = new Context())
            {
                var userData = await c.Users.FindAsync(_userId);
                var keycard = await c.Keycards.FirstOrDefaultAsync(k => k.Id.Equals(userData.KeycardId));

                if (userData != null)
                {
                    FirstName = userData.FirstName;
                    LastName = userData.LastName;
                }
            }
        }
    }
}
