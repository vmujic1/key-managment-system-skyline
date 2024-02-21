using key_managment_system.DBContexts;
using key_managment_system.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace key_managment_system.ViewModels
{
    public class EditPageViewModel : ViewModelBase

    {


        private int _userId;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _accessLevel;
        private string _errorMessage;

        

        
        public string FirstName
        { get => _firstName; set { _firstName = value; OnPropertyChanged(nameof(FirstName)); } }
        public string LastName
        { get => _lastName; set { _lastName = value; OnPropertyChanged(nameof(LastName)); } }

        public string Email
        { get => _email; set { _email = value; OnPropertyChanged(nameof(Email)); } }

        public string ErrorMessage
        { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }



        public string AccessLevel
        { get => _accessLevel; set { _accessLevel = value; OnPropertyChanged(nameof(AccessLevel)); } }
        public ICommand UpdateUserCommand { get; }







        public EditPageViewModel(int userId)
        {
            _userId = userId;
            LoadUserData();
            UpdateUserCommand = new ViewModelCommand(ExecuteUpdateUserCommand, CanExecuteUpdateUserCommand);

        }

        private bool CanExecuteUpdateUserCommand(object obj)
        {
            return true;
        }

        private async void ExecuteUpdateUserCommand(object obj)
        {
            var context = new Context();
            var userData = await context.Users.FindAsync(_userId);
            var keycard = await context.Keycards.FirstOrDefaultAsync(k => k.Id.Equals(userData.KeycardId));

           


            userData.Email = Email;
            userData.FirstName = FirstName;
            userData.LastName = LastName;

            
            await context.SaveChangesAsync();

            if (AccessLevel.Equals("Low")) {
                MessageBox.Show("Evo ga");
                keycard.AccessLevel = AccessLevelEnum.Low;
                await context.SaveChangesAsync();

            }
            else if(AccessLevel.Equals("Medium")) {
                keycard.AccessLevel = AccessLevelEnum.Medium;
                await context.SaveChangesAsync();

            }

            else if(AccessLevel.Equals("High"))
            {
                keycard.AccessLevel = AccessLevelEnum.Medium;
                await context.SaveChangesAsync();
            }
            else
            {
                ErrorMessage = "Invalid access level!";
            }



        }

        private async void LoadUserData()
        {
            // Fetch user data from the database based on _userId
            // Example code (you need to implement this based on your database structure):
            using (Context c = new Context())
            {
                var userData = await c.Users.FindAsync(_userId);
                var keycard = await c.Keycards.FirstOrDefaultAsync(k => k.Id.Equals(userData.KeycardId));

                if (userData != null)
                {
                    FirstName = userData.FirstName;
                    LastName = userData.LastName;
                    Email = userData.Email;
                    AccessLevel = keycard.AccessLevel.ToString();
                    
                    // Update other properties as needed
                }
            }
        }



    }
}
