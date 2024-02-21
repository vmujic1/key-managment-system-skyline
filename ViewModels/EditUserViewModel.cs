using key_managment_system.DBContexts;
using key_managment_system.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using key_managment_system.NewFolder;
using System.Windows;

namespace key_managment_system.ViewModels
{
    public class EditUserViewModel : ViewModelBase
    {
        public ICommand DeleteUserCommand { get; }
        private int _userId;

        public int Id { get; set; }

        private ObservableCollection<EditEmployeeDTO> _users;

        public EditUserViewModel()
        {
            _users = new ObservableCollection<EditEmployeeDTO>();
            DeleteUserCommand = new ViewModelCommand(ExecuteDeleteUserCommand, CanExecuteDeleteUserCommand);

            LoadUsers();
        }

        private async void LoadUsers()
        {
            var users = await GetUsersFromDatabaseAsync();
            foreach (var user in users)
            {
                _users.Add(user);
            }
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

                    // Remove the user from the ObservableCollection
                    var userToRemove = _users.FirstOrDefault(u => u.Id == Id);
                    if (userToRemove != null)
                    {
                        _users.Remove(userToRemove);
                    }

                    OnPropertyChanged(nameof(Users)); // Notify that the Users property has changed
                    Users = new ObservableCollection<EditEmployeeDTO>(await GetUsersFromDatabaseAsync());


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

            // baca greske cesto
            var test = await (from k in context.Keycards
                              join u in context.Users
                                 on k.Id equals u.Keycard.Id
                              select new { u.Id, u.FirstName, u.LastName, Rfid = k.SerialNumber }).ToListAsync();
            var users = test.Select(x => new EditEmployeeDTO { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName, Rfid = x.Rfid }).ToList();

            return users;
        }
    }
}
