using BLL.Services;
using DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.ViewModels;
using Presentation.Views;
using System.Windows;
using Presentation.Core;
using Presentation.Services;
using System;

namespace Presentation
{
	public partial class App : Application
	{
		public static IHost? AppHost { get; private set; }
		public App()
		{
			AppHost = Host.CreateDefaultBuilder()
				.ConfigureServices((hostContext, services) =>
				{
					services.AddSingleton<MainWindow>(provider => new MainWindow()
					{
						DataContext = provider.GetRequiredService<MainViewModel>()
					});
					services.AddSingleton<MainViewModel>();

					services.AddSingleton<Categories>(provider => new Categories()
					{
						DataContext = provider.GetRequiredService<CategoriesViewModel>()
					});
					services.AddSingleton<CategoriesViewModel>();

					services.AddSingleton<Products>(provider => new Products()
					{
						DataContext = provider.GetRequiredService<ProductsViewModel>()
					});
					services.AddSingleton<ProductsViewModel>();
					services.AddSingleton<ProductViewModel>();

					services.AddSingleton<ProductDetails>(provider => new ProductDetails()
					{
						DataContext = provider.GetRequiredService<ProductDetailsViewModel>()
					});
					services.AddSingleton<ProductDetailsViewModel>();

					services.AddSingleton<INavigationService, NavigationServices>();
					services.AddSingleton<Func<Type, ViewModel>>(provider => viewModelType => (ViewModel)provider.GetRequiredService(viewModelType));
					
					services.AddTransient<IService<User>, UserService>();
					services.AddTransient<IService<Product>, ProductService>();
					services.AddTransient<IService<Order>, OrderService>();
					services.AddTransient<IService<Payment>, PaymentService>();
					services.AddTransient<IService<Subscription>, SubscriptionService>();
					services.AddTransient<IService<UsersSubscriptions>, UsersSubscriptionsService>();
				})
				.Build();
		}

		protected override async void OnStartup(StartupEventArgs e)
		{
			await AppHost!.StartAsync();

			var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
			startupForm.Show();

			base.OnStartup(e);
		}
		protected override async void OnExit(ExitEventArgs e)
		{
			await AppHost!.StopAsync();
			base.OnExit(e);
		}
	}
}
