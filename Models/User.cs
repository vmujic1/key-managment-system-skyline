using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace key_managment_system.Models
{
    public class User : INotifyPropertyChanged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        [ForeignKey("Keycard")]
        public int KeycardId { get; set; }

        public Keycard Keycard { get; set; }

        public RoleEnum Role { get; set; }

        public User()
        {
            
        }

        public override string? ToString()
        {
            return FirstName + " " + LastName + " " +  Keycard.SerialNumber;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
