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
                  services.AddTransient<MainViewModel>();

                  services.AddSingleton<Categories>(provider => new Categories()
                  {
                      DataContext = provider.GetRequiredService<CategoriesViewModel>()
                  });
                  services.AddTransient<CategoriesViewModel>();
                  services.AddTransient<CategoryViewModel>();

                  services.AddSingleton<Products>(provider => new Products()
                  {
                      DataContext = provider.GetRequiredService<ProductsViewModel>()
                  });
                  services.AddTransient<ProductsViewModel>();
                  services.AddTransient<ProductViewModel>();

                  services.AddSingleton<ProductDetails>(provider => new ProductDetails()
                  {
                      DataContext = provider.GetRequiredService<ProductDetailsViewModel>()
                  });
                  services.AddTransient<ProductDetailsViewModel>();

                  services.AddSingleton<Profile>(provider => new Profile()
                  {
                      DataContext = provider.GetRequiredService<ProfileViewModel>()
                  });

                  services.AddSingleton<ProfileViewModel>();


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