namespace BLL.DTOs
{
    public class OrderDetailsDTO : OrderListDTO
    {
        public DateTime CreatedAt { get; set; }
        public int ReceiverId { get; set; }
    }
}
