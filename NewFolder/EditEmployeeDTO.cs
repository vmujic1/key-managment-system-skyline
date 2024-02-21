using key_managment_system.Models;
using System.ComponentModel;

namespace key_managment_system.NewFolder
{
    public class EditEmployeeDTO : INotifyPropertyChanged
    {
        public EditEmployeeDTO()
        {
        }

        public EditEmployeeDTO(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Rfid = user.Keycard.SerialNumber;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Rfid { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
