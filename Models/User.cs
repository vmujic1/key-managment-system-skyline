using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace key_managment_system.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Keycard Keycard { get; set; }
        public RoleEnum Role { get; set; }

        public User()
        {
            
        }

    }
}
