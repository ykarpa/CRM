using BLL.DTOs;
using BLL.Services;
using Presentation.Core;
using System;
using System.IO;
using System.Numerics;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation.Services
{
	public class AuthService
	{
		private static string config = Path.Combine(Directory.GetCurrentDirectory(), "config.json");
		private static AuthConfig authConfig;

		public static UserService UserService { get; set; } = null!;
		public static UserDetailsDTO CurrentUser { get; private set; }

		private static int currentUserId;
		public static int CurrentUserId
		{
			get => currentUserId;
			set
			{
				currentUserId = value;
				if (value != 0)
				{
					Task.Run(async () => await CheckIfUserExistsById(value));
				}
			}
		}

		public static async Task<bool> CheckIfAuthExpired()
		{
			try
			{
				string t = await File.ReadAllTextAsync(config);
				authConfig = JsonSerializer.Deserialize<AuthConfig>(t)!;

				double month = TimeSpan.FromDays(30).TotalSeconds;
				double seconds = DateTime.Now.Ticks / TimeSpan.TicksPerSecond;
				bool authExpired = seconds - authConfig.LastVisited > month || authConfig.User == 0;
				bool userExists = await CheckIfUserExistsById(authConfig.User);
				authExpired = authExpired || !userExists;
				if (authConfig.User != 0)
				{
					CurrentUserId = authConfig.User;
				}
				return authExpired;
			}
			catch
			{
				return true;
			}
		}

		private static async Task<bool> CheckIfUserExistsById(int id)
		{
			UserDetailsDTO user = await UserService.GetUserDetails(id)!;
			if (user == null)
			{
				return false;
			}
			CurrentUser = user;
			return true;
		}

		public static async Task WriteConfigOnShutDown()
		{
			long seconds = DateTime.Now.Ticks / TimeSpan.TicksPerSecond;
			AuthConfig cfg = new AuthConfig() { LastVisited = seconds, User = CurrentUserId };
			string json = JsonSerializer.Serialize(cfg);
			await File.WriteAllTextAsync(config, json);
		}

		public static void Login(UserDetailsDTO user)
		{
			CurrentUser = user;
			CurrentUserId = user.UserId;
		}
	}
}
