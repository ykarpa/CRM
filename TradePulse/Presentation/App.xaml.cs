using BLL.Services;
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

				  services.AddTransient<Categories>(provider => new Categories()
				  {
					  DataContext = provider.GetRequiredService<CategoriesViewModel>()
				  });
				  services.AddTransient<CategoriesViewModel>();
				  services.AddTransient<CategoryViewModel>();

				  services.AddTransient<Products>(provider => new Products()
				  {
					  DataContext = provider.GetRequiredService<ProductsViewModel>()
				  });
				  services.AddTransient<ProductsViewModel>();
				  services.AddTransient<ProductViewModel>();

				  services.AddTransient<ProductDetails>(provider => new ProductDetails()
				  {
					  DataContext = provider.GetRequiredService<ProductDetailsViewModel>()
				  });
				  services.AddTransient<ProductDetailsViewModel>();

				  services.AddTransient<Profile>(provider => new Profile()
				  {
					  DataContext = provider.GetRequiredService<ProfileViewModel>()
				  });
				  services.AddTransient<ProfileViewModel>();


                  services.AddTransient<Finance>(provider => new Finance()
                  {
                      DataContext = provider.GetRequiredService<FinanceViewModel>()
                  });
                  services.AddTransient<FinanceViewModel>();

                  services.AddTransient<ProfileModalDialog>(provider => new ProfileModalDialog()
				  {
					  DataContext = provider.GetRequiredService<ProfileViewModelModalDialog>()
				  });
				  services.AddTransient<ProfileViewModelModalDialog>();

                  services.AddTransient<Login>(provider => new Login()
				  {
					  DataContext = provider.GetRequiredService<LoginViewModel>()
				  });
				  services.AddTransient<LoginViewModel>();

				  services.AddTransient<Registration>(provider => new Registration()
				  {
					  DataContext = provider.GetRequiredService<RegistrationViewModel>()
				  });
				  services.AddTransient<RegistrationViewModel>();

				  services.AddSingleton<INavigationService, NavigationServices>();
				  services.AddSingleton<Func<Type, ViewModel>>(provider => viewModelType => (ViewModel)provider.GetRequiredService(viewModelType));

				  services.AddTransient<UserService>();
				  services.AddTransient<ProductService>();
				  services.AddTransient<OrderService>();
				  services.AddTransient<PaymentService>();
				  services.AddTransient<SubscriptionService>();
				  services.AddTransient<UsersSubscriptionsService>();
			  })
			  .Build();
		}

		protected override async void OnStartup(StartupEventArgs e)
		{
			await AppHost!.StartAsync();
			var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
			AuthService.UserService = AppHost.Services.GetRequiredService<UserService>();
			bool isExpired = await AuthService.CheckIfAuthExpired();
			startupForm.Show();
			if (isExpired)
			{
				var navService = AppHost.Services.GetRequiredService<INavigationService>();
				navService.NavigateTo<LoginViewModel>();
			}
			else
			{
				var mainViewModel = AppHost.Services.GetRequiredService<MainViewModel>();
				mainViewModel.ShowNavBarButtons();
			}
			base.OnStartup(e);
		}
		protected override async void OnExit(ExitEventArgs e)
		{
            await AuthService.WriteConfigOnShutDown();
			await AppHost!.StopAsync();
			base.OnExit(e);
		}
	}
}