using key_managment_system.DBContexts;
using key_managment_system.Dtos;
using key_managment_system.NewFolder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace key_managment_system.ViewModels
{
    public class RequestsViewModel : ViewModelBase
    {
        public ICommand DeleteUserCommand { get; }
        private int _userId;

        public int Id { get; set; }

        private ObservableCollection<KeycardRequestsDTO> _requests;
        public RequestsViewModel()
        {
            _requests = new ObservableCollection<KeycardRequestsDTO>();
            LoadUsers();

        }

        private async void LoadUsers()
        {
            var requests = await GetRequestsFromDatabaseAsync();
            foreach (var user in requests)
            {
                _requests.Add(user);
            }
        }
        public ObservableCollection<KeycardRequestsDTO> Requests
        {
            get { return _requests; }
            set
            {
                if (_requests != value)
                {
                    _requests = value;
                    OnPropertyChanged(nameof(Requests));
                }
            }
        }

        public async Task<List<KeycardRequestsDTO>> GetRequestsFromDatabaseAsync()
        {
            // Implement your logic to connect to MySQL database and retrieve user data asynchronously
            // For simplicity, a dummy data is provided here
            // Replace this with your actual data retrieval logic
            Context context = new Context();

            // baca greske cesto
            var test = await (from k in context.Keycards
                              join u in context.KeycardRequests
                                 on k.Id equals u.Keycard.Id
                              select new { u.Id, u.FirstName, u.LastName, Rfid = k.SerialNumber }).ToListAsync();
            var requests = test.Select(x => new KeycardRequestsDTO { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName, Rfid = x.Rfid }).ToList();

            
            return requests;
        }
    }
}
