using DAL.GenerickRepository;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService
    {
        private IGenericRepository<Order> orderRepository;

        public OrderService(IGenericRepository<Order> repository)
        {
            orderRepository = repository;
        }

        public Task<List<Order>> GetAll()
        {
            return orderRepository.GetAll();
        }

        public Task<Order> GetOrderById(int id)
        {
            return orderRepository.GetById(id);
        }

        public IQueryable<Order> GetQuaryable()
        {
            return orderRepository.GetQuaryable();
        }

        public void CreateOrder(Order order)
        {
            orderRepository.Create(order);
            orderRepository.Save();
        }

        public void UpdateOrder(Order order)
        {
            orderRepository.Update(order);
            orderRepository.Save();
        }

        public void DeleteOrder(Order order)
        {
            orderRepository.Delete(order);
            orderRepository.Save();
        }
    }
}
