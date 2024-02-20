namespace key_managment_system.Models
{
    public class Keycard
    {
        public Keycard()
        {
        }
        
        public int Id { get; set; }

        public string SerialNumber { get; set; }

        public AccessLevelEnum AccessLevel { get; set; }

    }
}