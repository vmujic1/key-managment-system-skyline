using key_managment_system.DBContexts;
using key_managment_system.Models;
using key_managment_system.ViewModels;
using Microsoft.EntityFrameworkCore;
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

    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : UserControl
    {
        


        public Reports()
        {
            InitializeComponent();
            Loaded += Reports_Loaded;   
        }

        private async void Reports_Loaded(object sender, RoutedEventArgs e)
        {
            // Access the parent window
            var viewModel = new ReportsViewModel();
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
