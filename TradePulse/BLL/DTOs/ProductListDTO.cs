namespace BLL.DTOs
{
	public class ProductListDTO
	{
		public int ProductId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public uint ItemsAvailable { get; set; }
		public string? Model { get; set; }
		public string? Category { get; set; }

	}
}
