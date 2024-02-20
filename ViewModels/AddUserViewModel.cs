using key_managment_system.DBContexts;
using key_managment_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Windows.Controls;

namespace key_managment_system.ViewModels
{
    public class AddUserViewModel : ViewModelBase
    {
        private string _firstname;
        private string _lastname;
        private string _email;
        private string _keycardid;
        private string _role;
        public string _errMsg;
        private bool _isViewVisible = true;

        public string FirstName { get => _firstname; set { _firstname = value; OnPropertyChanged(nameof(FirstName)); } }
        public string LastName { get => _lastname; set { _lastname = value; OnPropertyChanged(nameof(LastName)); } }
        public string Email { get => _email; set { _email = value; OnPropertyChanged(nameof(Email)); } }
        public string KeycardId { get => _keycardid; set { _keycardid = value; OnPropertyChanged(nameof(KeycardId)); } }
        public string Role { get => _role; set { _role = value; OnPropertyChanged(nameof(Role)); } }

        public string ErrorMessage { get => _errMsg; set { _errMsg = value; OnPropertyChanged(nameof(ErrorMessage)); } }
        public bool IsViewVisible { get => _isViewVisible; set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); } }

        public ICommand AddUserCommand { get; }

        public AddUserViewModel()
        {
            AddUserCommand = new ViewModelCommand(ExecuteAddUserCommand, CanExecuteAddUserCommand);
        }

        private bool CanExecuteAddUserCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrEmpty(FirstName) || 
                string.IsNullOrEmpty(LastName) ||
                string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(KeycardId)) 
            {
                validData = false;
            }
            else validData = true;

            return validData;
        }

        private async void ExecuteAddUserCommand(object obj)
        {
            var context = new Context();
            List<Keycard> keycards = await context.Keycards.ToListAsync();
            bool keycardExists = false;


            foreach (var keycard in keycards)
            {
                if (keycard.SerialNumber.Equals(KeycardId))
                {

                    keycardExists = true;
                    break;
                }

            }

            if (!keycardExists)
            {
                var a = FirstName;
                var b = LastName;
                var c = Email;
                var d = KeycardId;

                MessageBox.Show(Role.ToString());
                MessageBox.Show(RoleEnum.Manager.ToString());
                AccessLevelEnum accessLevel;
                RoleEnum role;

                if (Role.ToString() ==  RoleEnum.Manager.ToString())
                {
                    MessageBox.Show("BRAO");

                    accessLevel = AccessLevelEnum.Medium; 
                    role = RoleEnum.Manager;
                }
                else if(Role.ToString() == RoleEnum.Employee.ToString()) 
                {
                    accessLevel = AccessLevelEnum.Low;
                    role = RoleEnum.Employee;
                } else
                {
                    ErrorMessage = "Invalid role!";
                    return;
                }

                Keycard keycard = new Keycard();

                keycard.SerialNumber = d;
                keycard.AccessLevel = accessLevel;
                await context.Keycards.AddAsync(keycard);
                await context.SaveChangesAsync();

                User user = new User();


                user.FirstName = a;
                user.LastName = b;
                user.Email = c;
                user.Keycard = keycard;
                user.Role = role;

                ErrorMessage = "";
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                FirstName = "";
                LastName = "";
                Email = "";
                KeycardId = "";
                Role = "";
            }
            else
            {
                ErrorMessage = "Keycard with the same serial number already exists!";
            }
        }
    }
}
