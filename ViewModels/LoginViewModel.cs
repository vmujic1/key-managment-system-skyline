using key_managment_system.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace key_managment_system.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;   
        private string _errMsg;
        private bool _isViewVisible = true;

        public string Username { get => _username; set { _username = value; OnPropertyChanged(nameof(Username));}}
        public string Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password));}}
        public string ErrMsg { get => _errMsg; set { _errMsg = value; OnPropertyChanged(nameof(ErrMsg));}}
        public bool IsViewVisible { get => _isViewVisible; set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible));}}

        public ICommand LoginCommand { get;}

        public LoginViewModel()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            
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

        private void ExecuteLoginCommand(object obj)
        {
           Contex contex = new Contex();
          
        }
    }
}
