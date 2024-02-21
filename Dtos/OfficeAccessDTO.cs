using key_managment_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace key_managment_system.NewFolder
{
    public class OfficeAccessDTO
    {
        public OfficeAccessDTO() { }

        public string Name { get; set; }
        public AccessLevelEnum AccessLevel { get; set; }

        public int Id {  get; set; }

        public OfficeAccessDTO(Room room)
        {
            this.Id = room.Id;
            this.Name = room.Name;
            this.AccessLevel = room.AccessLevel;
        }
        
    }
}
