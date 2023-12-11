using BLL.DTOs;
using DAL.GenerickRepository;
using DAL.Models;

namespace BLL.Services
{
	public class UsersSubscriptionsService : IService<UsersSubscriptions>
	{
		private IGenericRepository<UsersSubscriptions> usersSubscriptionsRepository;

		public UsersSubscriptionsService()
		{
			usersSubscriptionsRepository = new TradePulseRepository<UsersSubscriptions>();
		}
        public UsersSubscriptionsService(IGenericRepository<UsersSubscriptions>usersSubscriptions)
        {
            usersSubscriptionsRepository = usersSubscriptions;
        }

        public Task<List<UsersSubscriptions>> GetAll()
		{
			return usersSubscriptionsRepository.GetAll();
		}

		public Task<UsersSubscriptions> GetById(int id)
		{
			throw new InvalidOperationException("UsersSubscription table has no primary key");
		}

		public IQueryable<UsersSubscriptions> GetQuaryable()
		{
			return usersSubscriptionsRepository.GetQuaryable();
		}

		public void Create(UsersSubscriptions usersSubscriptions)
		{
			usersSubscriptionsRepository.Create(usersSubscriptions);
			usersSubscriptionsRepository.Save();
		}

		public void Update(UsersSubscriptions usersSubscriptions)
		{
			usersSubscriptionsRepository.Update(usersSubscriptions);
			usersSubscriptionsRepository.Save();
		}

		public void Delete(UsersSubscriptions usersSubscriptions)
		{
			usersSubscriptionsRepository.Delete(usersSubscriptions);
			usersSubscriptionsRepository.Save();
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
