// <copyright file="SubscriptionService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BLL.Services
{
    using BLL.DTOs;
    using DAL.GenerickRepository;
    using DAL.Models;

    public class SubscriptionService : IService<Subscription>
    {
        private IGenericRepository<Subscription> subscriptionRepository;

        public SubscriptionService()
        {
            this.subscriptionRepository = new TradePulseRepository<Subscription>();
        }

        public SubscriptionService(IGenericRepository<Subscription> subscriptionService)
        {
            this.subscriptionRepository = subscriptionService;
        }

        public Task<List<Subscription>> GetAll()
        {
            return this.subscriptionRepository.GetAll();
        }

        public Task<Subscription> GetById(int id)
        {
            return this.subscriptionRepository.GetById(id);
        }

        public IQueryable<Subscription> GetQuaryable()
        {
            return this.subscriptionRepository.GetQuaryable();
        }

        public void Create(Subscription subscription)
        {
            this.subscriptionRepository.Create(subscription);
            this.subscriptionRepository.Save();
        }

        public void Update(Subscription subscription)
        {
            this.subscriptionRepository.Update(subscription);
            this.subscriptionRepository.Save();
        }

        public void Delete(Subscription subscription)
        {
            this.subscriptionRepository.Delete(subscription);
            this.subscriptionRepository.Save();
        }

        public async Task<List<SubscriptionListDTO>> GetSubscriptionsList()
        {
            return (await this.GetAll()).Select(s => new SubscriptionListDTO()
            {
                SubscriptionId = s.SubscriptionId,
                Price = s.Price,
                Description = s.Description,
                Type = s.Type,
                AllowedItemsCount = s.AllowedItemsCount,
                Term = s.Term,
            }).ToList();
        }
    }
}
