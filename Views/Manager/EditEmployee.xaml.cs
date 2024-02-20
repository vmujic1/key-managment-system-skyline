using key_managment_system.DBContexts;
using key_managment_system.Models;
using key_managment_system.NewFolder;
using key_managment_system.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Page
    {
        private EditUserViewModel viewModel;

        public List<EditEmployeeDTO> Users { get; set; }

        public EditEmployee()
        {
            viewModel = new EditUserViewModel();
            InitializeComponent();
            Loaded += Load;
        }

        private async void Load(object sender, RoutedEventArgs args)
        {
            Users = await viewModel.GetUsersFromDatabaseAsync();
            DataGrid.ItemsSource = Users;
        }

        private async Task UpdateUser(object sender, RoutedEventArgs e)
        {



        }
    }
}
