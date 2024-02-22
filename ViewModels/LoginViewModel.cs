using key_managment_system.DBContexts;
using key_managment_system.Models;
using key_managment_system.Views;
using key_managment_system.Views.Employee;
using key_managment_system.Views.Manager;
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

        public string Rfid
        { get => rfid; set { rfid = value; OnPropertyChanged(nameof(Rfid)); } }

        public string Username
        { get => _username; set { _username = value; OnPropertyChanged(nameof(Username)); } }
        public string Password
        { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string ErrorMessage
        { get => _errMsg; set { _errMsg = value; OnPropertyChanged(nameof(ErrorMessage)); } }
        public bool IsViewVisible
        { get => _isViewVisible; set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); } }

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
            var keycard = await context.Keycards.FirstOrDefaultAsync(k => string.Equals(k.SerialNumber, rfid));

            if(keycard is null)
            {
                // TODO
                return;
            }

            User? user = await context.Users.FirstOrDefaultAsync(e => e.KeycardId == keycard.Id);
            List<Keycard> cards = await context.Keycards.ToListAsync();

            if (user != null)
            {
                user.Username = Username;
                user.Password = Password;
                await context.SaveChangesAsync();
                this.IsViewVisible = false;
                LoginView man = new LoginView();
                man.Visibility = Visibility.Visible;
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

            if (correctCredentials  && foundUser.Role  == RoleEnum.Manager)

            {
                this.IsViewVisible = false;
                ManagerDashboard man = new ManagerDashboard();
                man.Visibility = Visibility.Visible;
            }
            else
            {
                if (correctCredentials && foundUser.Role == RoleEnum.Employee)

                {
                    LoggedInUser = foundUser;
                    this.IsViewVisible = false;
                    EmployeeDashboard man = new EmployeeDashboard();
                    man.Visibility = Visibility.Visible;
                    var temp = new CardUsing();
                    
                }
                else
                {
                    ErrorMessage = "Invalid credentials!";
                }
            }

            
            
        }
        private User _loggedInUser;

        public User LoggedInUser
        {
            get => _loggedInUser;
            set
            {
                _loggedInUser = value;
                OnPropertyChanged(nameof(LoggedInUser));
            }
        }
    }
}