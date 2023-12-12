// <copyright file="UsersSubscriptions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DAL.Models
{
    using Microsoft.EntityFrameworkCore;

    [Keyless]
    public class UsersSubscriptions
    {
        public string Status { get; set; } = null!;

        public DateTime PaymentDate { get; set; }

        public int UserId { get; set; }

        public int SubscriptionId { get; set; }

        public User? User { get; set; }

        public Subscription? Subscription { get; set; }
    }
}
