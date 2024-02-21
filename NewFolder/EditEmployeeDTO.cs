using key_managment_system.Models;

namespace key_managment_system.NewFolder
{
    public class EditEmployeeDTO
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
    }
}
