using key_managment_system.DBContexts;
using key_managment_system.Models;
using key_managment_system.NewFolder;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace key_managment_system.ViewModels
{
    public class ShowProfileViewModel : ViewModelBase
    {
        private int _userId;
        private string _firstName;
        private string _lastName;
        private string _keycardId;
        private string _role;
        private string _errorMessage;



        
        public string FirstName
        { get => _firstName; set { _firstName = value; OnPropertyChanged(nameof(FirstName)); } }
        public string LastName
        { get => _lastName; set { _lastName = value; OnPropertyChanged(nameof(LastName)); } }

        public string KeycardId
        { get => _keycardId; set { _keycardId = value; OnPropertyChanged(nameof(KeycardId)); } }
        public string Role
        { get => _role; set { _role = value; OnPropertyChanged(nameof(Role)); } }

        public string ErrorMessage
        { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }

        public ICommand RequestKeycardCommand { get; }

        public ShowProfileViewModel()
        {
            RequestKeycardCommand = new ViewModelCommand(ExecuteRequestKeycardCommand, CanExecuteRequestKeycardCommand);

            LoadUserData();
        }

        private bool CanExecuteRequestKeycardCommand(object obj)
        {
            return true;
        }

        private async void ExecuteRequestKeycardCommand(object obj)
        {
            var context = new Context();

            var request = new KeycardRequest();

            request.FirstName = UserManager.Instance.FirstName;
            request.LastName = UserManager.Instance.LastName;
            request.SenderId = UserManager.Instance.UserId;
            request.ReceiverId = 5;
            request.KeycardId = UserManager.Instance.KeycardId;

            context.KeycardRequests.Add(request);
            
            await context.SaveChangesAsync();
        }

        private async void LoadUserData()
        {
            // Fetch user data from the database based on _userId
            // Example code (you need to implement this based on your database structure):
           
            FirstName = UserManager.Instance.FirstName;
            LastName = UserManager.Instance.LastName;

            var context = new Context();
            var k = context.Keycards.FirstOrDefault(k => k.Id == UserManager.Instance.KeycardId);
            KeycardId = k.SerialNumber;

            if(UserManager.Instance.Role == (int)RoleEnum.Employee)
            {
                Role = "Employee";

            } else if(UserManager.Instance.Role == (int)RoleEnum.Manager)
            {
               Role = "Manager";

            }
            else
            {
                Role = "Administrator";

            }





            // Update other properties as needed
        }



    }

}