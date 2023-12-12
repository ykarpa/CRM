// <copyright file="UserDetailsDTO.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BLL.DTOs
{
    public class UserDetailsDTO : UserListDTO
    {
        public DateTime CreatedAt { get; set; }

        public DateTime BirthDate { get; set; }

        public string? Role { get; set; }
    }
}
