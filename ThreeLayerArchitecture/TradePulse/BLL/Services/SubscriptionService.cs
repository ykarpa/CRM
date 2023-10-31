using DAL.GenerickRepository;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SubscriptionService
    {
        private IGenericRepository<Subscription> subscriptionRepository;

        public SubscriptionService(IGenericRepository<Subscription> repository)
        {
            subscriptionRepository = repository;
        }

        public Task<List<Subscription>> GetAll()
        {
            return subscriptionRepository.GetAll();
        }

        public Task<Subscription> GetSubscriptionById(int id)
        {
            return subscriptionRepository.GetById(id);
        }

        public IQueryable<Subscription> GetQuaryable()
        {
            return subscriptionRepository.GetQuaryable();
        }

        public void CreateSubscription(Subscription subscription)
        {
            subscriptionRepository.Create(subscription);
            subscriptionRepository.Save();
        }

        public void UpdateSubscription(Subscription subscription)
        {
            subscriptionRepository.Update(subscription);
            subscriptionRepository.Save();
        }

        public void DeleteSubscription(Subscription subscription)
        {
            subscriptionRepository.Delete(subscription);
            subscriptionRepository.Save();
        }
    }
}
