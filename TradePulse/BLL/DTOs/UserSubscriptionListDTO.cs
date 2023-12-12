// <copyright file="UserSubscriptionListDTO.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BLL.DTOs
{
    public class UserSubscriptionListDTO
    {
        public string? Status { get; set; }

        public DateTime PaymentDate { get; set; }

        public int UserId { get; set; }

        public int SubscriptionId { get; set; }
    }
}
