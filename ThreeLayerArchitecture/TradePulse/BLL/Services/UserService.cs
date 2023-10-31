using DAL.GenerickRepository;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{

    public class UserService
    {
        private IGenericRepository<User> userRepository;

        public UserService(IGenericRepository<User> repository)
        {
            userRepository = repository;
        }

        public Task<List<User>> GetAll()
        {
            return userRepository.GetAll();
        }

        public Task<User> GetUserById(int id)
        {
            return userRepository.GetById(id);
        }

        public IQueryable<User> GetQuaryable()
        {
            return userRepository.GetQuaryable();
        }

        public void CreateUser(User user)
        {
            userRepository.Create(user);
            userRepository.Save();
        }

        public void UpdateUser(User user)
        {
            userRepository.Update(user);
            userRepository.Save();
        }

        public void DeleteUser(User user)
        {
            userRepository.Delete(user);
            userRepository.Save();
        }
    }
}