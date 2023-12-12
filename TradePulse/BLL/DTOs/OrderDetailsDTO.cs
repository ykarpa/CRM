// <copyright file="OrderDetailsDTO.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BLL.DTOs
{
    public class OrderDetailsDTO : OrderListDTO
    {
        public DateTime CreatedAt { get; set; }

        public int ReceiverId { get; set; }
    }
}
