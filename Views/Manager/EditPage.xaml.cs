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
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private int id;
        private EditPageViewModel viewModel;

        public EditWindow(int id)
        {
            this.id = id;
            viewModel = new EditPageViewModel(id);
            InitializeComponent();
            DataContext = viewModel;
            Width = 300;
            Height = 600;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void txtKeycardId_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CloseModal(object sender, RoutedEventArgs e)
        {
            this.Close();
            EditEmployee eK = new EditEmployee();
            
            
            
            
        }
    }
}
