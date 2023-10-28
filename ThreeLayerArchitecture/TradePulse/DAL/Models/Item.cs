﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
	public class Item
	{
		public int ItemId { get; set; }
		public string Category { get; set; } = null!;
		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;
		public string? Model { get; set; }
		public decimal Price { get; set; }
		public uint ItemsAvailable { get; set; }
		public DateTime CreatedAt { get; set; }
		[ForeignKey("User")]
		public int VendorId { get; set; }
		public User Vendor {  get; set; }
		public ICollection<Order> Orders { get; set; }
	}
}
