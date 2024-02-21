using key_managment_system.DBContexts;
using key_managment_system.Dtos;
using key_managment_system.NewFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace key_managment_system.ViewModels
{
    public class InfoRoomPageViewModel : ViewModelBase
    {
        private ObservableCollection<UserOfficeDto> _users;

        public ObservableCollection<UserOfficeDto> Users
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

        public async Task<List<UserOfficeDto>> GetUsersFromDatabase(int roomId)
        {
            Context context = new Context();
            var users = context.Users;
            var usersResult = users.Where(u => u.CurrentRoomId == roomId).Select(
                x => new UserOfficeDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Id = x.Id
                });

            

            return usersResult.ToList();
        }
    }
}
