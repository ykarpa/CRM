using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
	public class TradePulseContext: DbContext
	{
		public TradePulseContext() : base()
		{

		}
		public TradePulseContext(DbContextOptions<TradePulseContext> options) : base(options) 
		{
			
		}
		
		public DbSet<User> Users { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Items { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<Subscription> Subscriptions { get; set; }
		public DbSet<UsersSubscriptions> UsersSubscriptions { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseNpgsql(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
		}
		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	modelBuilder.Entity<OrderItems>(builder => builder.HasNoKey());
		//}
	}
}
