namespace BLL.Services
{
	public interface IService<T> where T : class
	{
		public Task<List<T>> GetAll();

		public Task<T> GetById(int id);

		public IQueryable<T> GetQuaryable();

		public void Create(T instance);

		public void Update(T instance);

		public void Delete(T instance);
	}
}
