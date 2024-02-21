using key_managment_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace key_managment_system.Dtos
{
    public class UserOfficeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserOfficeDto() { }
        public UserOfficeDto(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }
    }
}
