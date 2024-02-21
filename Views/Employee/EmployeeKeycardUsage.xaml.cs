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

namespace key_managment_system.Views.Employee
{
    /// <summary>
    /// Interaction logic for EmployeeKeycardUsage.xaml
    /// </summary>
    public partial class EmployeeKeycardUsage : UserControl
    {
        public EmployeeKeycardUsage()
        {
            InitializeComponent();
            Loaded += Reports_Loaded;
        }

        private async void Reports_Loaded(object sender, RoutedEventArgs e)
        {
            // Access the parent window
            var viewModel = new EmployeeKeycardUsageViewModel();
            EmployeesList.ItemsSource = await viewModel.Load();

            var navWindow = Window.GetWindow(this) as NavigationWindow;
            if (navWindow != null)
            {
                // Hide the navigation bar
                navWindow.ShowsNavigationUI = false;
            }
        }
    }
}
