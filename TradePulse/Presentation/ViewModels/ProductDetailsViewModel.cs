using BLL.DTOs;
using BLL.Services;
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
				Product = Task.Run(async () => await _productService.GetProductDetails(_productId)).Result;
			}
		}
		private readonly ProductService _productService;

		private ProductDetailsDTO? _product;
		public ProductDetailsDTO Product
		{
			get => _product!;
			private set
			{
				_product = value;
				OnPropertyChange();
			}
		}

		public ProductDetailsViewModel(ProductService productService)
		{
			_productService = productService;
		}
	}
}
