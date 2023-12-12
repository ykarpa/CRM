// <copyright file="UserService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BLL.Services
{
    using BLL.DTOs;
    using DAL.GenerickRepository;
    using DAL.Models;

    public class UserService : IService<User>
    {
        private IGenericRepository<User> userRepository;

        public UserService()
        {
            this.userRepository = new TradePulseRepository<User>();
        }

        public UserService(IGenericRepository<User> userService)
        {
            this.userRepository = userService;
        }

        public Task<List<User>> GetAll()
        {
            return this.userRepository.GetAll();
        }

        public Task<User> GetById(int id)
        {
            return this.userRepository.GetById(id);
        }

        public IQueryable<User> GetQuaryable()
        {
            return this.userRepository.GetQuaryable();
        }

        public void Create(User user)
        {
            this.userRepository.Create(user);
            this.userRepository.Save();
        }

        public void Update(User user)
        {
            this.userRepository.Update(user);
            this.userRepository.Save();
        }

        public void Delete(User user)
        {
            this.userRepository.Delete(user);
            this.userRepository.Save();
        }

        public async Task<List<UserListDTO>> GetUsersList()
        {
            return (await this.GetAll()).Select(u => new UserListDTO()
            {
                UserId = u.UserId,
                Email = u.Email,
                Password = u.Password,
                FirstName = u.FirstName,
                LastName = u.LastName,
            }).ToList();
        }

        public async Task<UserDetailsDTO> GetUserDetails(int id)
        {
            var user = await this.GetById(id);
            return new UserDetailsDTO()
            {
                UserId = user.UserId,
                Email = user.Email,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                CreatedAt = user.CreatedAt,
            };
        }
    }
}