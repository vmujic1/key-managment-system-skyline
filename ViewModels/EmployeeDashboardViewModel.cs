﻿using key_managment_system.ViewModels;
using key_managment_system.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace key_managment_system.ViewModels
{
    public class EmployeeDashboardViewModel : ViewModelBase
    {
        private ViewModelBase _currentChildView;

        public string _currentUser;

        public string CurrentUser
        { get => _currentUser; set { _currentUser = value; OnPropertyChanged(nameof(CurrentUser)); } }


        public EmployeeDashboardViewModel()
        {
            CurrentUser = UserManager.Instance.FirstName + " " + UserManager.Instance.LastName;
            KeycardUsageReportCommand = new ViewModelCommand(ExecuteKeycardUsageReportCommand);
            LogoutUserCommand = new ViewModelCommand(ExecuteLogoutUserCommand);
            ShowProfileViewCommand=  new ViewModelCommand(ExecuteShowProfileCommand);
            ShowVisualizationCommand = new ViewModelCommand(ExecuteShowVisualizationCommand);
            ExecuteShowVisualizationCommand(null);
        }

        private void ExecuteShowVisualizationCommand(object obj)
        {
            CurrentChildView = new EmployeeVisualizationViewModel();
        }

        private void ExecuteShowProfileCommand(object obj)
        {
            CurrentChildView = new ShowProfileViewModel();
        }

        private void ExecuteKeycardUsageReportCommand(object obj)
        {
            CurrentChildView = new EmployeeKeycardUsageViewModel();
        }

        private void ExecuteVisualisationCommand(object obj)
        {
            CurrentChildView = new VisualisationViewModel();

        }

        private void ExecuteLogoutUserCommand(object obj)
        {
            var newWindow = new LoginView();
            newWindow.Show();
        }

        public ViewModelBase CurrentChildView
        {
            get => _currentChildView;
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public ICommand KeycardUsageReportCommand { get; }
        public ICommand LogoutUserCommand { get; }
        public ICommand ShowProfileViewCommand { get; }

        public ICommand ShowVisualizationCommand { get; }

    }
}
