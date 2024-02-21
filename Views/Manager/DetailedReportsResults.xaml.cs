using key_managment_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace key_managment_system.Views.Manager
{
    /// <summary>
    /// Interaction logic for DetailedReportsResults.xaml
    /// </summary>
    public partial class DetailedReportsResults : Window
    {

        string _firstName;
        string _lastName;
        DateTime _startDate;
        DateTime _endDate;

        public DetailedReportsResults(string FirstName, string LastName, DateTime StartDate, DateTime EndDate)
        {
            InitializeComponent();
            _firstName = FirstName;
            _lastName = LastName;
            _startDate = StartDate;
            _endDate = EndDate;
            Loaded += Reports_Loaded;
        }

        private async void Reports_Loaded(object sender, RoutedEventArgs e)
        {
            // Access the parent window
            var viewModel = new DetailedReportsResultsViewModel();
            EmployeesList.ItemsSource = await viewModel.Load(_firstName, _lastName, _startDate, _endDate);

            var navWindow = Window.GetWindow(this) as NavigationWindow;
            if (navWindow != null)
            {
                // Hide the navigation bar
                navWindow.ShowsNavigationUI = false;
            }
        }
    }
}
