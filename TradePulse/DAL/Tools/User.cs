namespace DAL.Models
{
	public class User
	{
		public int UserId { get; set; }
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public DateTime BirthDate { get; set; }
		public string Role { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string Password { get; set; } = null!;
		public DateTime CreatedAt { get; set; }
		public List<Order>? Orders { get; set; }
		public List<Product>? Products { get; set; }
	}
}