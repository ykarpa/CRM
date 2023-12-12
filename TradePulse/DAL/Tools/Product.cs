// <copyright file="Product.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DAL.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        public int ProductId { get; set; }

        public string Category { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? Model { get; set; }

        public decimal Price { get; set; }

        public uint ItemsAvailable { get; set; }

        public DateTime CreatedAt { get; set; }

        [ForeignKey("User")]
        public int VendorId { get; set; }

        public User? Vendor { get; set; }

        public List<Order>? Orders { get; set; }
    }
}
