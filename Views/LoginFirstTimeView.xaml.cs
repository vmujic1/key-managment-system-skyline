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

namespace key_managment_system.Views
{
    /// <summary>
    /// Interaction logic for LoginFirstTimeView.xaml
    /// </summary>
    public partial class LoginFirstTimeView : Window
    {
        public LoginFirstTimeView()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void rfid_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PrijaviSe(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
