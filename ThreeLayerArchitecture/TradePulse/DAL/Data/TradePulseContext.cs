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
		public DbSet<Item> Items { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<Subscription> Subscriptions { get; set; }
		public DbSet<UsersSubscriptions> UsersSubscriptions { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseNpgsql("Host=surus.db.elephantsql.com;Username=ezzaidoo;Password=VvgDIad5Osco_z1erVN-xhbJ3xuqdBCZ;Database=ezzaidoo;");
		}
		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	modelBuilder.Entity<OrderItems>(builder => builder.HasNoKey());
		//}
	}
}
