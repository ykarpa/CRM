using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DAL.Models;
using BLL.Services;
using System.Linq;
using Presentation.Core;
using Presentation.Services;
using System;

namespace Presentation.ViewModels
{
	public class ProductsViewModel : ViewModel
	{
		private ObservableCollection<ProductViewModel> _products;

		public ObservableCollection<ProductViewModel> Products
		{
			get => _products;
			set
			{
				_products = value;
				OnPropertyChange();
			}
		}

		public Func<int, RelayCommand> InitNavCommand { get; private set; }
		public IService<Product> ProductService { get; set; }
		private async Task LoadProducts()
		{
			var products = await ProductService.GetAll();

			var productViewModels = products.Select(product => new ProductViewModel()
			{
				Title = product.Title,
				Description = product.Description,
				Price = product.Price,
				Model = product.Model!,
				ItemsAvailable = product.ItemsAvailable,
				NavigateToDetails = InitNavCommand(product.ProductId)
			});
			Products = new ObservableCollection<ProductViewModel>(productViewModels);
		}

		public ProductsViewModel(IService<Product> productService, INavigationService navigation)
		{
			ProductService = productService;
			InitNavCommand = (id) => new RelayCommand(o => true, o =>
			{
				navigation.NavigateTo<ProductDetailsViewModel>();
				navigation.InitParam<ProductDetailsViewModel, int>("ProductId", id);
			});
			Task.Run(LoadProducts);
		}
	}
}
