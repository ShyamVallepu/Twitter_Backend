using System.ComponentModel.DataAnnotations;

namespace Twitter_Backend.DTO
{
    public class LoginDTO
    {
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
