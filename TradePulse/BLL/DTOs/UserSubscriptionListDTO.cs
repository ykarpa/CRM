namespace BLL.DTOs
{
    public class UserSubscriptionListDTO
    {
        public string Status { get; set; }
        public DateTime PaymentDate { get; set; }
        public int UserId { get; set; }
        public int SubscriptionId { get; set; }
    }
}
