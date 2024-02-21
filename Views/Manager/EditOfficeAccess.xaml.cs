using key_managment_system.Models;
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
using System.Windows.Shapes;

namespace key_managment_system.Views.Manager
{
    /// <summary>
    /// Interaction logic for EditOfficeAccess.xaml
    /// </summary>
    public partial class EditOfficeAccess : Window
    {
        private int id {  get; set; }
        public EditOfficeAccess(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        public  void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (((ComboBoxItem)accessLevelCombo.SelectedItem).Content.ToString() == "Low")
            {
                EditOfficeAccessViewModel viewModel = new EditOfficeAccessViewModel(id, 0);
                viewModel.ExecuteUpdateOffice(AccessLevelEnum.Low);
                this.Close();
            }
            else if (((ComboBoxItem)accessLevelCombo.SelectedItem).Content.ToString() == "Medium")
            {
                EditOfficeAccessViewModel viewModel = new EditOfficeAccessViewModel(id, 1);
                viewModel.ExecuteUpdateOffice(AccessLevelEnum.Medium);
                this.Close();
            }
            else if (((ComboBoxItem)accessLevelCombo.SelectedItem).Content.ToString() == "High")
            {
                EditOfficeAccessViewModel viewModel = new EditOfficeAccessViewModel(id, 2);
                viewModel.ExecuteUpdateOffice(AccessLevelEnum.High);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please choose access level !");
            }
            
            
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
