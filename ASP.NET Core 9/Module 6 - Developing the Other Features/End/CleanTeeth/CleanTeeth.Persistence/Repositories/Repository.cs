using CleanTeeth.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CleanTeethDbContext context;

        public Repository(CleanTeethDbContext context)
        {
            this.context = context;
        }

        public Task<T> Add(T entity)
        {
            context.Add(entity);
            return Task.FromResult(entity);
        }

        public Task Delete(T entity)
        {
            context.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<int> GetTotalAmountOfRecords()
        {
            return await context.Set<T>().CountAsync();
        }

        public Task Update(T entity)
        {
            context.Update(entity);
            return Task.CompletedTask;
        }
    }
}
