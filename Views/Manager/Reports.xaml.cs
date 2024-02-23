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
            //MessageBox.Show(((ComboBoxItem)ColumnCombo.SelectedItem).Content.ToString());
            string columnCombo = ((ComboBoxItem)ColumnCombo.SelectedItem).Content.ToString();

            if (string.IsNullOrEmpty(tekst.Text.ToString()) && columnCombo != "No filter")
            {
                MessageBox.Show("Please enter text for filtering.");
            } 
            else
            {
                if (columnCombo == "No filter")
                {
                    var temp = await viewModel.GetRecordsFromDatabaseAsync();
                    EmployeesList.ItemsSource = temp;
                }
                else if (columnCombo == "First Name")
                {
                    var temp = await viewModel.GetRecordsFromDatabaseAsync_FN(tekst.Text.ToString());
                    EmployeesList.ItemsSource = temp;
                }
                else if (columnCombo == "Last Name")
                {
                    await Task.Delay(500);
                    var temp = await viewModel.GetRecordsFromDatabaseAsync_LN(tekst.Text.ToString());
                    EmployeesList.ItemsSource = temp;
                }
                else if (columnCombo == "Email")
                {
                    await Task.Delay(500);
                    var temp = await viewModel.GetRecordsFromDatabaseAsync_EMAIL(tekst.Text.ToString());
                    EmployeesList.ItemsSource = temp;
                }
                else if (columnCombo == "Username")
                {
                    await Task.Delay(500);
                    var temp = await viewModel.GetRecordsFromDatabaseAsync_USERNAME(tekst.Text.ToString());
                    EmployeesList.ItemsSource = temp;
                }
                else if (columnCombo == "Room Name")
                {
                    await Task.Delay(500);
                    var temp = await viewModel.GetRecordsFromDatabaseAsync_RN(tekst.Text.ToString());
                    EmployeesList.ItemsSource = temp;
                }
                else if (columnCombo == "Serial Number")
                {
                    await Task.Delay(500);
                    var temp = await viewModel.GetRecordsFromDatabaseAsync_SN(tekst.Text.ToString());
                    EmployeesList.ItemsSource = temp;
                }
                else if (columnCombo == "Access Level")
                {
                    await Task.Delay(500);
                    var temp = await viewModel.GetRecordsFromDatabaseAsync_AL(tekst.Text.ToString());
                    EmployeesList.ItemsSource = temp;
                }
                else if (columnCombo == "All columns")
                {
                    await Task.Delay(500);
                    var temp = await viewModel.GetRecordsFromDatabaseAsync_ALL(tekst.Text.ToString());
                    EmployeesList.ItemsSource = temp;
                }
            }

           

        }
    }
}
