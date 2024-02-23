using key_managment_system.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace key_managment_system.Dtos
{
    public class ReportsDTO : INotifyPropertyChanged
    {
        public ReportsDTO()
        {

        }
        public ReportsDTO(string firstname,string lastname,string email, string username, string roomname, string serialnumber, AccessLevelEnum accessLevel, DateTime timestamp)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Username = username;
            RoomName = roomname;
            SerialNumber = SerialNumber;
            AccessLevel = accessLevel; 
            Timestamp = timestamp;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }
        public string RoomName { get; set; }
        public string SerialNumber { get; set; }
        public AccessLevelEnum AccessLevel { get; set; }
        public DateTime Timestamp { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
