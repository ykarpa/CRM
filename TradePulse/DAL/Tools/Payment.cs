using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
	public class Payment
	{
		public int PaymentId { get; set; }
		[ForeignKey("User")]
		public int From { get; set; }
		[ForeignKey("User")]
		public int To { get; set; }
		public uint Amount { get; set; }
		public string Purpose { get; set; } = null!;

		public User Sender { get; set; }
		public User Receiver { get; set; }
	}
}
