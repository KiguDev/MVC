using Restaurante.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Infrastructure.Data
{
    public class EfRepository : IAsyncRepository
    {
        private readonly AppDbContext _appDbContext; 
        public EfRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task DeleteAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync<T>(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> InsertAsync<T>(T entity)
        {
            _appDbContext.Add(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
