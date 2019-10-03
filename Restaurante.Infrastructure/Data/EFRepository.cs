using Restaurante.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Infrastructure.Data
{
    public class EFRepository : IAsyncRepository
    {
        private readonly AppDbContext _appDbContext;
        public EFRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task AddAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync<T>(T entity)
        {
            _appDbContext.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync<T>() => new List<T>();

        public Task<T> GetByIdAsync<T>(int id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync<T>(T entity)
        {
            _appDbContext.Add(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public Task UpdateSync<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
