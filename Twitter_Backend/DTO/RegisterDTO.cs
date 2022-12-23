namespace Twitter_Backend.DTO
{
    public class RegisterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string ContactNumber { get; set; }

        public DateTime DOB { get; set; }
    }
}
