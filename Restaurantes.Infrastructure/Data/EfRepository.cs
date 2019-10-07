using Restaurantes.Core.Interfaces;
using Restaurantes.Core;
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

        public async Task<T> DeleteAsync<T>(T entity)
        {
            _appDbContext.Remove(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        public Task<List<T>> GetAllAsync<T>(int id)
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(int id, string table)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync<T>(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> InsertAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> LisAllAsync<T>()
        {
            throw new NotImplementedException();
        }

        public async Task<T> UpdateAsync<T>(T entity)
        {
            _appDbContext.Update(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        Task IAsyncRepository.DeleteAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }

        Task IAsyncRepository.UpdateAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
