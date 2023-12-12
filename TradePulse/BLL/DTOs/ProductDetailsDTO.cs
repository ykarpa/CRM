// <copyright file="ProductDetailsDTO.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BLL.DTOs
{
    public class ProductDetailsDTO : ProductListDTO
    {
        public DateTime CreatedAt { get; set; }

        public int VendorId { get; set; }
    }
}
