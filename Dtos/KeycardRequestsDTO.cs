using key_managment_system.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace key_managment_system.Dtos
{
    public class KeycardRequestsDTO : INotifyPropertyChanged
    {
        public KeycardRequestsDTO()
        {
        }

        public KeycardRequestsDTO(KeycardRequest request)
        {
            Id = request.Id;
            FirstName = request.FirstName;
            LastName = request.LastName;
            Rfid = request.Keycard.SerialNumber;
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
