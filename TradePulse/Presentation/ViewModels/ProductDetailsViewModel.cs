using BLL.Services;
using DAL.Models;
using Presentation.Core;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
	public class ProductDetailsViewModel : ViewModel
	{
		private int _productId;
		public int ProductId
		{
			get => _productId;
			set
			{
				_productId = value;
				Product = Task.Run(() => ProductService.GetById(_productId)).Result;
			}
		}
		private IService<Product> ProductService;

		private Product _product;
		public Product Product
		{
			get => _product;
			private set
			{
				_product = value;
				OnPropertyChange(nameof(Product));
			}
		}

		public ProductDetailsViewModel(IService<Product> productService)
		{
			ProductService = productService;
		}
	}
}
