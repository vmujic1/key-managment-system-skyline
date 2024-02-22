using key_managment_system.NewFolder;
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
    /// Interaction logic for DetailedReports.xaml
    /// </summary>
    public partial class DetailedReports : UserControl
    {
        private DetailedReportsViewModel viewModel;
        public event EventHandler DataChanged;


        public List<EditEmployeeDTO> Users { get; set; }

        public DetailedReports()
        {
            viewModel = new DetailedReportsViewModel();
            InitializeComponent();
            Loaded += Load;
        }

        private async void Load(object sender, RoutedEventArgs args)
        {
            Users = await viewModel.GetUsersFromDatabaseAsync();
            DataGrid.ItemsSource = Users;
        }



        private void UpdateUser(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;
            DetailedReportsPage edit = new DetailedReportsPage(Id);
            edit.Show();
        }

        public void RefreshData()
        {
            Users = viewModel.GetUsersFromDatabaseAsync().Result;
            DataGrid.ItemsSource = Users;
        }
    }
}
