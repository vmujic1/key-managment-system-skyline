using key_managment_system.DBContexts;
using key_managment_system.Models;
using key_managment_system.NewFolder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace key_managment_system.ViewModels
{
    public class EditUserViewModel : ViewModelBase
    {
        private ObservableCollection<EditEmployeeDTO> _users;

        public ICommand DeleteUserCommand { get; }
        private int _userId;

        public int Id { get; set; }


        public EditUserViewModel()
        {

            DeleteUserCommand = new ViewModelCommand(ExecuteDeleteUserCommand, CanExecuteDeleteUserCommand);


        }

        public EditUserViewModel(int userId)
        {
            _userId = userId;
            DeleteUserCommand = new ViewModelCommand(ExecuteDeleteUserCommand, CanExecuteDeleteUserCommand);

        }

        private bool CanExecuteDeleteUserCommand(object obj)
        {
            return true;
        }

        private async void ExecuteDeleteUserCommand(object obj)
        {
            var context = new Context();
            

            var userData = await context.Users.FirstOrDefaultAsync(u => u.Id == Id);

            if (userData != null)
            {
                var keycard = await context.Keycards.FirstOrDefaultAsync(k => k.Id.Equals(userData.KeycardId));

                if (keycard != null)
                {
                    context.Keycards.Remove(keycard);

                    context.Users.Remove(userData);
                    await context.SaveChangesAsync();

                    MessageBox.Show("User deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Keycard not found for the user.");
                }
            }
            else
            {
                MessageBox.Show("User not found.");
            }
        }

        public ObservableCollection<EditEmployeeDTO> Users
        {
            get { return _users; }
            set
            {
                if (_users != value)
                {
                    _users = value;
                    OnPropertyChanged(nameof(Users));
                }
            }
        }

        public int SelectedUserId => _userId;

        public async Task<List<EditEmployeeDTO>> GetUsersFromDatabaseAsync()
        {
            // Implement your logic to connect to MySQL database and retrieve user data asynchronously
            // For simplicity, a dummy data is provided here
            // Replace this with your actual data retrieval logic
            Context context = new Context();
            var test = await (from k in context.Keycards
                       join u in context.Users
                          on k.Id equals u.Keycard.Id
                       select new { u.Id,u.FirstName, u.LastName, Rfid = k.SerialNumber }).ToListAsync();
            var users = test.Select(x => new EditEmployeeDTO { Id = x.Id,FirstName = x.FirstName, LastName = x.LastName, Rfid = x.Rfid }).ToList();

            return users;
        }
    }
}
