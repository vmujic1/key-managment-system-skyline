using key_managment_system.DBContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace key_managment_system.ViewModels
{
    public class ShowProfileViewModel : ViewModelBase
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



        private async void LoadUserData()
        {
            // Fetch user data from the database based on _userId
            // Example code (you need to implement this based on your database structure):
           
                    FirstName = UserManager.Instance.FirstName;
                    LastName = userData.LastName;
                    Email = userData.Email;

                    // Update other properties as needed
                }
         


    }

}