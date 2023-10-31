using DAL.GenerickRepository;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ItemService
    {
        private IGenericRepository<Item> itemRepository;

        public ItemService(IGenericRepository<Item> repository)
        {
            itemRepository = repository;
        }

        public Task<List<Item>> GetAll()
        {
            return itemRepository.GetAll();
        }

        public Task<Item> GetItemById(int id)
        {
            return itemRepository.GetById(id);
        }

        public IQueryable<Item> GetQuaryable()
        {
            return itemRepository.GetQuaryable();
        }

        public void CreateItem(Item item)
        {
            itemRepository.Create(item);
            itemRepository.Save();
        }

        public void UpdateItem(Item item)
        {
            itemRepository.Update(item);
            itemRepository.Save();
        }

        public void DeleteItem(Item item)
        {
            itemRepository.Delete(item);
            itemRepository.Save();
        }
    }
}
