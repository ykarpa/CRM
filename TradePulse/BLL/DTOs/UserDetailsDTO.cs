namespace BLL.DTOs
{
    public class UserDetailsDTO : UserListDTO
    {
        public DateTime CreatedAt { get; set; }
        public DateTime BirthDate { get; set; }
        public string Role { get; set; }
    }
}
