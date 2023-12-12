// <copyright file="ProductListDTO.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BLL.DTOs
{
    public class ProductListDTO
    {
        public int ProductId { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public uint ItemsAvailable { get; set; }

        public string? Model { get; set; }

        public string? Category { get; set; }
    }
}
