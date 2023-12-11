namespace BLL.DTOs
{
	public class OrderListDTO
	{
		public int OrderId { get; set; }
        public decimal OrderPrice { get; set; }
        public decimal DropPrice { get; set; }
        public string PaymentType { get; set; }
        public string DeliveryType { get; set; }
        public string Status { get; set; }
        public uint ProductsCount { get; set; }

    }
}