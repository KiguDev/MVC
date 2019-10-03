using Restaurantes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantes.Infrastructure.Data
{
    public class EfRepository : IAsyncRepository
    {
        private readonly AppDbContext _appDbContext;
        public EfRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
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

        public async Task<T> GetByIdAsync<T>(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> ListAllAsync<T>()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
