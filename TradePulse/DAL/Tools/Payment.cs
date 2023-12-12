// <copyright file="Payment.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DAL.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Payment
    {
        public int PaymentId { get; set; }

        [ForeignKey("User")]
        public int From { get; set; }

        [ForeignKey("User")]
        public int To { get; set; }

        public uint Amount { get; set; }

        public string Purpose { get; set; } = null!;

        public User? Sender { get; set; }

        public User? Receiver { get; set; }
    }
}
