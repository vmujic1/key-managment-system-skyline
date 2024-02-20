using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            ExecuteVisualisationCommand(null);
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
    }
}
