using DAL.GenerickRepository;
using DAL.Models;

namespace BLL.Services
{
	public class ItemService: IService<Item>
	{
		private readonly IGenericRepository<Item> itemRepository;

        public ItemService()
        {
			itemRepository = new TradePulseRepository<Item>();
		}

        public Task<List<Item>> GetAll()
		{
			return itemRepository.GetAll();
		}

		public Task<Item> GetById(int id)
		{
			return itemRepository.GetById(id);
		}

		public IQueryable<Item> GetQuaryable()
		{
			return itemRepository.GetQuaryable();
		}

		public void Create(Item item)
		{
			itemRepository.Create(item);
			itemRepository.Save();
		}

		public void Update(Item item)
		{
			itemRepository.Update(item);
			itemRepository.Save();
		}

		public void Delete(Item item)
		{
			itemRepository.Delete(item);
			itemRepository.Save();
		}
	}
}
