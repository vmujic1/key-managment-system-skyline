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

namespace key_managment_system.ViewModels
{
    public class EditUserViewModel : ViewModelBase
    {
        private ObservableCollection<EditEmployeeDTO> _users;

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

        public async Task<List<EditEmployeeDTO>> GetUsersFromDatabaseAsync()
        {
            // Implement your logic to connect to MySQL database and retrieve user data asynchronously
            // For simplicity, a dummy data is provided here
            // Replace this with your actual data retrieval logic
            Context context = new Context();
            var test = await (from k in context.Keycards
                       join u in context.Users
                          on k.Id equals u.Keycard.Id
                       select new { u.FirstName, u.LastName, Rfid = k.SerialNumber }).ToListAsync();
            var users = test.Select(x => new EditEmployeeDTO { FirstName = x.FirstName, LastName = x.LastName, Rfid = x.Rfid }).ToList();

            return users;
        }
    }
}
