using key_managment_system.Views;
using key_managment_system.Views.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace key_managment_system.ViewModels
{
    public class ManagerDashboardViewModel : ViewModelBase
    {
        private ViewModelBase _currentChildView;
        

        public ManagerDashboardViewModel()
        {
            ShowVisualisationCommand = new ViewModelCommand(ExecuteVisualisationCommand);
            ShowReportsCommand = new ViewModelCommand(ExecuteReportsCommand);
            ShowAddUserCommand = new ViewModelCommand(ExecuteShowAddUserCommand);
            LogoutUserCommand = new ViewModelCommand(ExecuteLogoutUserCommand);
            ShowEditUserCommand = new ViewModelCommand(ExecuteShowEditUserCommand);
            ShowOfficeAccessCommand = new ViewModelCommand(ExecuteShowOfficeAcessCommand);

            ExecuteVisualisationCommand(null);
        }

        private void ExecuteShowOfficeAcessCommand(object obj)
        {
            CurrentChildView = new OfficeAccessViewModel();
        }

        private void ExecuteShowEditUserCommand(object obj)
        {
            CurrentChildView = new EditUserViewModel();
        }

        private void ExecuteShowAddUserCommand(object obj)
        {
            CurrentChildView = new AddUserViewModel();
        }

        private void ExecuteReportsCommand(object obj)
        {
            CurrentChildView = new ReportsViewModel();
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


        public ViewModelBase CurrentChildView { 
            get => _currentChildView;
            set { 
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
       
        public ICommand ShowVisualisationCommand { get; }
        public ICommand ShowReportsCommand { get; }
        public ICommand ShowAddUserCommand { get; }
        public ICommand LogoutUserCommand { get; }
        public ICommand ShowEditUserCommand{ get; }
        public ICommand ShowOfficeAccessCommand { get; }
    }
}
