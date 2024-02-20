using key_managment_system.DBContexts;
using key_managment_system.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml;

namespace key_managment_system.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private string _errMsg;
        private bool _isViewVisible = true;
        private string rfid;

        public string Rfid { get => rfid; set { rfid = value; OnPropertyChanged(nameof(Rfid)); } }

        public string Username { get => _username; set { _username = value; OnPropertyChanged(nameof(Username)); } }
        public string Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string ErrorMessage { get => _errMsg; set { _errMsg = value; OnPropertyChanged(nameof(ErrorMessage));}}
        public bool IsViewVisible { get => _isViewVisible; set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); } }

        public ICommand LoginCommand { get; }
        public ICommand CreateAccountCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            CreateAccountCommand = new ViewModelCommand(ExcuteCreateAccount, CanExecuteCreateAccount);

        }

        private bool CanExecuteCreateAccount(object obj)
        {
            return true;
        }

        private async void ExcuteCreateAccount(object obj)
        {
            var context = new Context();
            User? user = await context.Users.Where(e => e.Keycard.SerialNumber.Equals(Rfid)).FirstOrDefaultAsync();
            List<Keycard> cards = await context.Keycards.ToListAsync();



            if (user != null)
            {
                user.Username = Username;
                user.Password = Password;
                context.SaveChangesAsync();


            }




        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || Username.Length < 3 || Password.Length < 3)
            {
                validData = false;
            }
            else validData = true;

            return validData;
        }

        private async void ExecuteLoginCommand(object obj)
        {
            var context = new Context();
            var foundUser = await context.Users.FirstOrDefaultAsync(user => user.Username == Username && user.Password == Password);
            //List<User> users = await context.Users.ToListAsync();
            bool correctCredentials = false;

            //foreach(var user in users)
            //{
            //    if(user.Username.Equals(Username) && user.Password.Equals(Password))
            //    {
            //        correctCredentials = true;

            //        break;
            //    }

            //}

            if (foundUser != null)
            {
                correctCredentials = true;
            }

            if (correctCredentials)
            {
                this.IsViewVisible = false;
                ManagerDashboardWindow man = new ManagerDashboardWindow();
                man.Visibility = Visibility.Visible;
            }
            else
            {

                ErrorMessage = "Invalid credentials!";

            }






        }




    }
}
