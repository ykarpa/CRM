using DAL.GenerickRepository;
using DAL.Models;

namespace BLL.Services
{
	public class OrderService : IService<Order>
	{
		private IGenericRepository<Order> orderRepository;

		public OrderService()
		{
			orderRepository = new TradePulseRepository<Order>();
		}

		public Task<List<Order>> GetAll()
		{
			return orderRepository.GetAll();
		}

		public Task<Order> GetById(int id)
		{
			return orderRepository.GetById(id);
		}

		public IQueryable<Order> GetQuaryable()
		{
			return orderRepository.GetQuaryable();
		}

		public void Create(Order order)
		{
			orderRepository.Create(order);
			orderRepository.Save();
		}

		public void Update(Order order)
		{
			orderRepository.Update(order);
			orderRepository.Save();
		}

		public void Delete(Order order)
		{
			orderRepository.Delete(order);
			orderRepository.Save();
		}
	}
}
