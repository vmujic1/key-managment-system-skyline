using key_managment_system.DBContexts;
using key_managment_system.Models;
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

namespace key_managment_system.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            //HashAllPaswords();
        }

        public async void HashAllPaswords()
        {
            var context = new Context();

            List<User> users = new List<User>();

            users = await (context.Users.ToListAsync());

            foreach (var user in users)
            {
                user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(user.Password, 13);
                await context.SaveChangesAsync();
            }
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
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

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtPwd_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPwd_TextChanged(object sender, RoutedEventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPwd_PasswordChanged(object sender, RoutedEventArgs e)
        {
            
        }

        private void PrijaviSe(object sender, MouseButtonEventArgs e)
        {
            LoginFirstTimeView man = new LoginFirstTimeView();
            this.Visibility = Visibility.Hidden;
            man.Show();

        }
    }
}
;