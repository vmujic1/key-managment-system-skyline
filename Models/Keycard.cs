using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace key_managment_system.Models
{
    public class Keycard
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public AccessLevelEnum AccessLevel { get; set; }

        public Keycard()
        {
            
        }
    }
}
