using DAL.GenerickRepository;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UsersSubscriptionsService
    {
        private IGenericRepository<UsersSubscriptions> usersSubscriptionsRepository;

        public UsersSubscriptionsService(IGenericRepository<UsersSubscriptions> repository)
        {
            usersSubscriptionsRepository = repository;
        }

        public Task<List<UsersSubscriptions>> GetAll()
        {
            return usersSubscriptionsRepository.GetAll();
        }

        public Task<UsersSubscriptions> GetUsersSubscriptionsById(int id)
        {
            return usersSubscriptionsRepository.GetById(id);
        }

        public IQueryable<UsersSubscriptions> GetQuaryable()
        {
            return usersSubscriptionsRepository.GetQuaryable();
        }

        public void CreateUsersSubscriptions(UsersSubscriptions usersSubscriptions)
        {
            usersSubscriptionsRepository.Create(usersSubscriptions);
            usersSubscriptionsRepository.Save();
        }

        public void UpdateUsersSubscriptions(UsersSubscriptions usersSubscriptions)
        {
            usersSubscriptionsRepository.Update(usersSubscriptions);
            usersSubscriptionsRepository.Save();
        }

        public void DeleteUsersSubscriptions(UsersSubscriptions usersSubscriptions)
        {
            usersSubscriptionsRepository.Delete(usersSubscriptions);
            usersSubscriptionsRepository.Save();
        }
    }
}
