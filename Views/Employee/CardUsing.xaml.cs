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
using key_managment_system.DBContexts;
using key_managment_system.Models;
using key_managment_system.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace key_managment_system.Views.Employee
{
    /// <summary>
    /// Interaction logic for CardUsing.xaml
    /// </summary>
    public partial class CardUsing : UserControl
    {
        public CardUsing()
        {
            
            InitializeComponent();
            Loaded += CardUsing_Loaded;
        }
        private async void CardUsing_Loaded(object sender, RoutedEventArgs e)
        { 

            var loginViewModel = (LoginViewModel)Application.Current.MainWindow.DataContext;

            if (loginViewModel != null && loginViewModel.LoggedInUser != null)
            {
                int currentUserId = loginViewModel.LoggedInUser.Id;
                var viewModel = new CardUsingViewModel();
                EmployeesList.ItemsSource = await viewModel.Load(currentUserId);
            }


            var navWindow = Window.GetWindow(this) as NavigationWindow;
            if (navWindow != null)
            {
                // Sakrij traku za navigaciju
                navWindow.ShowsNavigationUI = false;
            }
        }

    }
}
