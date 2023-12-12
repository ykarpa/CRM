// <copyright file="OrderService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BLL.Services
{
    using BLL.DTOs;
    using DAL.GenerickRepository;
    using DAL.Models;

    public class OrderService : IService<Order>
    {
        private IGenericRepository<Order> orderRepository;

        public OrderService()
        {
            this.orderRepository = new TradePulseRepository<Order>();
        }

        public OrderService(IGenericRepository<Order> orderService)
        {
            this.orderRepository = orderService;
        }

        public Task<List<Order>> GetAll()
        {
            return this.orderRepository.GetAll();
        }

        public Task<Order> GetById(int id)
        {
            return this.orderRepository.GetById(id);
        }

        public IQueryable<Order> GetQuaryable()
        {
            return this.orderRepository.GetQuaryable();
        }

        public void Create(Order order)
        {
            this.orderRepository.Create(order);
            this.orderRepository.Save();
        }

        public void Update(Order order)
        {
            this.orderRepository.Update(order);
            this.orderRepository.Save();
        }

        public void Delete(Order order)
        {
            this.orderRepository.Delete(order);
            this.orderRepository.Save();
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
                ProductsCount = o.ProductsCount,
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
                ReceiverId = order.ReceiverId,
            };
        }
    }
}
