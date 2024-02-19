using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace key_managment_system.Models
{
    public class Record
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public DateTime TimeStamp { get; set; }
        public Room Room { get; set; }

        public Record()
        {
            
        }

    }
}
