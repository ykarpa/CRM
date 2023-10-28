using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GenerickRepository
{
	public interface IGenerickRepository<T>
	{
		public Task<List<T>> GetAll();
		public Task<T> GetById(int id);
		public Task Create(T entity);
		public void Update(T entity);
		public void Delete(T entity);
		public Task Save();
	}
}
