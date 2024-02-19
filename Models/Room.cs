using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace key_managment_system.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AccessLevelEnum AccessLevel { get; set; }

        public Room()
        {
            
        }
    }
}
