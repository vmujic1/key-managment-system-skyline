using key_managment_system.ViewModels;
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
            KeycardUsageReportCommand = new ViewModelCommand(ExecuteKeycardUsageReportCommand);
            ExecuteVisualisationCommand(null);
        }

        private void ExecuteKeycardUsageReportCommand(object obj)
        {
            CurrentChildView = new EmployeeKeycardUsageViewModel();
        }

        private void ExecuteVisualisationCommand(object obj)
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

        public ICommand KeycardUsageReportCommand { get; }

    }
}
