using DAL.GenerickRepository;
using DAL.Models;

namespace BLL.Services
{
	public class UserService : IService<User>
	{
		private IGenericRepository<User> userRepository;

		public UserService()
		{
			userRepository = new TradePulseRepository<User>();
		}

		public Task<List<User>> GetAll()
		{
			return userRepository.GetAll();
		}

		public Task<User> GetById(int id)
		{
			return userRepository.GetById(id);
		}

		public IQueryable<User> GetQuaryable()
		{
			return userRepository.GetQuaryable();
		}

		public void Create(User user)
		{
			userRepository.Create(user);
			userRepository.Save();
		}

		public void Update(User user)
		{
			userRepository.Update(user);
			userRepository.Save();
		}

		public void Delete(User user)
		{
			userRepository.Delete(user);
			userRepository.Save();
		}
	}
}