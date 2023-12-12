// <copyright file="SubscriptionListDTO.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BLL.DTOs
{
    public class SubscriptionListDTO
    {
        public int SubscriptionId { get; set; }

        public uint Price { get; set; }

        public string? Description { get; set; }

        public string? Type { get; set; }

        public uint AllowedItemsCount { get; set; }

        public TimeSpan Term { get; set; }
    }
}
