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

        public Task<List<Product>> GetAll()
		{
			return productRepository.GetAll();
		}

		public Task<Product> GetById(int id)
		{
			return productRepository.GetById(id);
		}

		public IQueryable<Product> GetQuaryable()
		{
			return productRepository.GetQuaryable();
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
	}
}
