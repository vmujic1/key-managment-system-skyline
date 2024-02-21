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
            ExecuteCardUsingCommand(null);
        }

        private void ExecuteCardUsingCommand(object obj)
        {
            CurrentChildView = new ReportsViewModel();
        }

        private void ExecuteRequestsEmployeeCommand(object obj)
        {
            CurrentChildView = new VisualisationViewModel();

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
    }
}
