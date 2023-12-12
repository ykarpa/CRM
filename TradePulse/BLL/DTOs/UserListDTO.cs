// <copyright file="UserListDTO.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BLL.DTOs
{
    public class UserListDTO
    {
        public int UserId { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}