// <copyright file="UsersSubscriptionsService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BLL.Services
{
    using BLL.DTOs;
    using DAL.GenerickRepository;
    using DAL.Models;

    public class UsersSubscriptionsService : IService<UsersSubscriptions>
    {
        private IGenericRepository<UsersSubscriptions> usersSubscriptionsRepository;

        public UsersSubscriptionsService()
        {
            this.usersSubscriptionsRepository = new TradePulseRepository<UsersSubscriptions>();
        }

        public UsersSubscriptionsService(IGenericRepository<UsersSubscriptions> usersSubscriptions)
        {
            this.usersSubscriptionsRepository = usersSubscriptions;
        }

        public Task<List<UsersSubscriptions>> GetAll()
        {
            return this.usersSubscriptionsRepository.GetAll();
        }

        public Task<UsersSubscriptions> GetById(int id)
        {
            throw new InvalidOperationException("UsersSubscription table has no primary key");
        }

        public IQueryable<UsersSubscriptions> GetQuaryable()
        {
            return this.usersSubscriptionsRepository.GetQuaryable();
        }

        public void Create(UsersSubscriptions usersSubscriptions)
        {
            this.usersSubscriptionsRepository.Create(usersSubscriptions);
            this.usersSubscriptionsRepository.Save();
        }

        public void Update(UsersSubscriptions usersSubscriptions)
        {
            this.usersSubscriptionsRepository.Update(usersSubscriptions);
            this.usersSubscriptionsRepository.Save();
        }

        public void Delete(UsersSubscriptions usersSubscriptions)
        {
            this.usersSubscriptionsRepository.Delete(usersSubscriptions);
            this.usersSubscriptionsRepository.Save();
        }

        public async Task<List<UserSubscriptionListDTO>> GetUserSubscriptionsList()
        {
            return (await this.GetAll()).Select(us => new UserSubscriptionListDTO()
            {
                SubscriptionId = us.SubscriptionId,
                UserId = us.UserId,
                Status = us.Status,
                PaymentDate = us.PaymentDate,
            }).ToList();
        }
    }
}
