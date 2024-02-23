using key_managment_system.DBContexts;
using key_managment_system.Dtos;
using key_managment_system.Models;
using key_managment_system.NewFolder;
using key_managment_system.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
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

        private ReportsViewModel viewModel;
        public event EventHandler DataChanged;

        public List<ReportsDTO> Users { get; set; }

        public Reports()
        {
            viewModel = new ReportsViewModel();
            InitializeComponent();
            Loaded += Load;
        }

        private async void Load(object sender, RoutedEventArgs args)
        {
            Users = await viewModel.GetRecordsFromDatabaseAsync();
            EmployeesList.ItemsSource = Users;
        }

        private async void click_zmirko(object sender, RoutedEventArgs e)
        {
            
            await Task.Delay(1000);
            var temp = await viewModel.GetRecordsFromDatabaseAsync_FN(tekst.Text.ToString());
            EmployeesList.ItemsSource = temp;
        }
    }
}
