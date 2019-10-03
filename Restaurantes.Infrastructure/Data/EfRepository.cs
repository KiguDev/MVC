using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurantes.Core.Interfaces;

namespace Restaurantes.Infrastructure.Data
{
    public class EfRepository : IAsyncRepository
    {
        private readonly AppDbContext _appDbContext;

        public EfRepository(AppDbContext appdbContext)
        {
            _appDbContext = appdbContext;
        }

        public async Task<T> AddAsync<T>(T entity)
        {
            _appDbContext.Add(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync<T>(T entity)
        {
            _appDbContext.Remove(entity);
            await _appDbContext.SaveChangesAsync();
            
        }

        public Task<T> GetByIdAsync<T>(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> ListAllAsync<T>()
        {
            throw new NotImplementedException();
        }

        public async Task<T> UpdateAsync<T>(T entity)
        {
            _appDbContext.Update(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
