using BLL.DTOs;
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
				Product = Task.Run(() => ProductService.GetProductDetails(_productId)).Result;
			}
		}
		private ProductService ProductService;

		private ProductDetailsDTO? _product;
		public ProductDetailsDTO Product
		{
			get => _product!;
			private set
			{
				_product = value;
				OnPropertyChange(nameof(Product));
			}
		}

		public ProductDetailsViewModel(ProductService productService)
		{
			ProductService = productService;
		}
	}
}
