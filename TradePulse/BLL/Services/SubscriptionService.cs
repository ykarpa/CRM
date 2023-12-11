using BLL.DTOs;
using DAL.GenerickRepository;
using DAL.Models;

namespace BLL.Services
{
	public class SubscriptionService : IService<Subscription>
	{
		private IGenericRepository<Subscription> subscriptionRepository;

		public SubscriptionService()
		{
			subscriptionRepository = new TradePulseRepository<Subscription>();
		}
        public SubscriptionService(IGenericRepository<Subscription>subscriptionService)
        {
            subscriptionRepository = subscriptionService;
        }
        public Task<List<Subscription>> GetAll()
		{
			return subscriptionRepository.GetAll();
		}

		public Task<Subscription> GetById(int id)
		{
			return subscriptionRepository.GetById(id);
		}

		public IQueryable<Subscription> GetQuaryable()
		{
			return subscriptionRepository.GetQuaryable();
		}

		public void Create(Subscription subscription)
		{
			subscriptionRepository.Create(subscription);
			subscriptionRepository.Save();
		}

		public void Update(Subscription subscription)
		{
			subscriptionRepository.Update(subscription);
			subscriptionRepository.Save();
		}

		public void Delete(Subscription subscription)
		{
			subscriptionRepository.Delete(subscription);
			subscriptionRepository.Save();
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
                Term = s.Term
            }).ToList();
        }
    }
}
