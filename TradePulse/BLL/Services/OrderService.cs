using BLL.DTOs;
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
        public OrderService(IGenericRepository<Order> orderService)
        {
			orderRepository = orderService;
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

        public async Task<List<OrderListDTO>> GetOrdersList()
        {
            return (await this.GetAll()).Select(o => new OrderListDTO()
            {
                OrderId = o.OrderId,
                OrderPrice = o.OrderPrice,
                DropPrice = o.DropPrice,
                PaymentType = o.PaymentType,
                DeliveryType = o.DeliveryType,
                Status = o.Status,
                ProductsCount = o.ProductsCount
            }).ToList();
        }

        public async Task<OrderDetailsDTO> GetOrderDetails(int id)
        {
            var order = await this.GetById(id);
            return new OrderDetailsDTO()
            {
                CreatedAt = order.CreatedAt,
                OrderPrice = order.OrderPrice,
                DropPrice = order.DropPrice,
                PaymentType = order.PaymentType,
                DeliveryType = order.DeliveryType,
                Status = order.Status,
                ProductsCount = order.ProductsCount,
                ReceiverId = order.ReceiverId
            };
        }
    }
}
