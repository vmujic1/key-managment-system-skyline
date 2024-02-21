using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace key_managment_system.Models
{
    public class KeycardRequest
    {
       
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        [ForeignKey("Sender")]
        public int SenderId { get; set; }
        public User Sender { get; set; }

        [ForeignKey("Receiver")]
        public int ReceiverId { get; set; }

        public User Receiver { get; set; }

        [ForeignKey("Keycard")]
        public int KeycardId { get; set; }
        public Keycard Keycard { get; set; }

       

        
    }
}
