using DAL.Models;

namespace BLL.DTOs
{
	public class ProductDetailsDTO : ProductListDTO
	{
		public DateTime CreatedAt { get; set; }
		public int VendorId { get; set; }
	}
}
