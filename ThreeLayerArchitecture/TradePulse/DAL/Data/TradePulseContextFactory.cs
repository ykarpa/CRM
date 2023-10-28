using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL.Data
{
	class TradePulseContextFactory : IDbContextFactory<TradePulseContext>
	{
		public TradePulseContext CreateDbContext()
		{
			IConfigurationRoot config = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();
			string connectionString = config.GetConnectionString("ConnectionString.NpgSql");
			if (connectionString == null)
			{
				Console.WriteLine("NO CONNECTION STRING");
			}
			var builder = new DbContextOptionsBuilder<TradePulseContext>();
			return new TradePulseContext(builder.Options);
		}
	}
}
