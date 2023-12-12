// <copyright file="TradePulseRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DAL.GenerickRepository
{
    using DAL.Data;
    using Microsoft.EntityFrameworkCore;

    public class TradePulseRepository<T> : IGenericRepository<T>
        where T : class
    {
        private TradePulseContext context;
        private DbSet<T> table;

        public TradePulseRepository()
        {
            this.context = new TradePulseContext();
            this.table = this.context.Set<T>();
        }

        public async Task Create(T entity)
        {
            await this.table.AddAsync(entity);
        }

        public IQueryable<T> GetQuaryable()
        {
            return this.table.AsQueryable<T>();
        }

        public void Delete(T entity)
        {
            this.table.Remove(entity);
        }

        public Task<List<T>> GetAll()
        {
            return this.table.ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await this.table.FindAsync(id);
        }

        public async Task Save() => await this.context.SaveChangesAsync();

        public void Update(T entity)
        {
            this.table.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
        }
    }
}
