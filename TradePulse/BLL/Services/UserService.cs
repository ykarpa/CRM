using BLL.DTOs;
using DAL.GenerickRepository;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
	public class UserService : IService<User>
	{
		private IGenericRepository<User> userRepository;

		public UserService()
		{
			userRepository = new TradePulseRepository<User>();
		}
        public UserService(IGenericRepository<User> userService)
        {
            userRepository = userService;
        }
        public Task<List<User>> GetAll()
		{
			return userRepository.GetAll();
		}

		public Task<User> GetById(int id)
		{
			return userRepository.GetById(id);
		}

		public IQueryable<User> GetQueryable()
		{
			return userRepository.GetQueryable();
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

        public async Task<List<UserListDTO>> GetUsersList()
        {
            return (await this.GetAll()).Select(u => new UserListDTO()
            {
                UserId = u.UserId,
                Email = u.Email,
                Password = u.Password,
                FirstName = u.FirstName,
                LastName = u.LastName
            }).ToList();
        }

        public async Task<UserDetailsDTO>? GetUserDetails(int id)
        {
            var user = await this.GetById(id);
			if(user == null)
			{
				return null!;
			}
            return new UserDetailsDTO()
            {
                UserId = user.UserId,
                Email = user.Email,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                CreatedAt = user.CreatedAt,
				Role = user.Role
            };
        }

		public async Task<UserDetailsDTO>? GetUserDetailsByEmail(string email)
		{

			var user = await Task.Run(() => GetQueryable().Where(u => u.Email == email).FirstOrDefaultAsync());
			if (user == null)
			{
				return null!;
			}
			return new UserDetailsDTO()
			{
				UserId = user.UserId,
				Email = user.Email,
				Password = user.Password,
				FirstName = user.FirstName,
				LastName = user.LastName,
				BirthDate = user.BirthDate,
				CreatedAt = user.CreatedAt,
				Role = user.Role
			};
		}
	}
}