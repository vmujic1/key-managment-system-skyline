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

      
        public EmployeeDashboardViewModel()
        {
            ShowCardUsingCommand = new ViewModelCommand(ExecuteCardUsingCommand);
            ShowRequestsEmployeeCommand = new ViewModelCommand(ExecuteRequestsEmployeeCommand);
            LogoutUserCommand = new ViewModelCommand(ExecuteLogoutUserCommand);
            ExecuteCardUsingCommand(null);
        }

        private void ExecuteCardUsingCommand(object obj)
        {
            CurrentChildView = new CardUsingViewModel();
        }

        private void ExecuteRequestsEmployeeCommand(object obj)
        {
            CurrentChildView = new RequestsEmployeeViewModel();

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

        public ICommand ShowCardUsingCommand { get; }
        public ICommand ShowRequestsEmployeeCommand { get; }
        public ICommand LogoutUserCommand { get; }
}
}
