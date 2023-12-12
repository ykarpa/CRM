// <copyright file="PaymentListDTO.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BLL.DTOs
{
    public class PaymentListDTO
    {
        public int PaymentId { get; set; }

        public int From { get; set; }

        public int To { get; set; }

        public uint Amount { get; set; }

        public string? Purpose { get; set; }
    }
}
