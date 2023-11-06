using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Order
	{
		public int OrderId { get; set; }
		public DateTime CreatedAt { get; set; }
		public decimal OrderPrice { get; set; }
		public decimal DropPrice { get; set; }
		public string PaymentType { get; set; } = null!;
		public string DeliveryType { get; set; } = null!;
		public string Status { get; set; } = null!;
		public uint ProductsCount { get; set; }
		[ForeignKey("User")]
		public int ReceiverId { get; set; }
		public User Receiver { get; set; }
		public List<Product> Products { get; set; }
	}
}
