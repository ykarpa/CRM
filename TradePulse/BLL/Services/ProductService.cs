using BLL.DTOs;
using DAL.GenerickRepository;
using DAL.Models;

namespace BLL.Services
{
	public class ProductService: IService<Product>
	{
		private readonly IGenericRepository<Product> productRepository;
        public ProductService()
        {
			productRepository = new TradePulseRepository<Product>();
		}
        public ProductService(IGenericRepository<Product> productService)
        {
			productRepository = productService;
        }
        public Task<List<Product>> GetAll()
		{
			return productRepository.GetAll();
		}

		public Task<Product> GetById(int id)
		{
			return productRepository.GetById(id);
		}

		public IQueryable<Product> GetQueryable()
		{
			return productRepository.GetQueryable();
		}

		public void Create(Product product)
		{
			productRepository.Create(product);
			productRepository.Save();
		}

		public void Update(Product product)
		{
			productRepository.Update(product);
			productRepository.Save();
		}

		public void Delete(Product product)
		{
			productRepository.Delete(product);
			productRepository.Save();
		}

		public async Task<List<ProductListDTO>> GetProductsList()
		{
			return (await this.GetAll()).Select(p => new ProductListDTO()
			{
				Title = p.Title,
				Price = p.Price,
				Description = p.Description,
				ItemsAvailable = p.ItemsAvailable,
				Model = p.Model,
				ProductId = p.ProductId,
				Category = p.Category
			}).ToList();
		}

		public async Task<ProductDetailsDTO> GetProductDetails(int id)
		{
			var product = await this.GetById(id);
			return new ProductDetailsDTO()
			{
				CreatedAt = product.CreatedAt,
				Description = product.Description,
				ItemsAvailable = product.ItemsAvailable,
				Model = product.Model,
				ProductId = product.ProductId,
				Price= product.Price,
				Title = product.Title,
				VendorId = product.VendorId,
				Category = product.Category
			};
		}

        public async Task Create(ProductDetailsDTO productDTO)
        {
            Product product = new()
            {
                Title = productDTO.Title,
				Description = productDTO.Description,
				Model = productDTO.Model,
				Price = productDTO.Price,
                Category = productDTO.Category,
				ItemsAvailable = productDTO.ItemsAvailable,
				VendorId = productDTO.VendorId,
                CreatedAt = DateTime.Now.ToUniversalTime(),
                Vendor = null,
                Orders = null,
            };
            try
            {
                this.Create(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
