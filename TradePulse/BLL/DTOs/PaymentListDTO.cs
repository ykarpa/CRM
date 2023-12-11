using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTOs
{
    public class PaymentListDTO
    {
        public int PaymentId { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public uint Amount { get; set; }
        public string Purpose { get; set; }

    }
}
