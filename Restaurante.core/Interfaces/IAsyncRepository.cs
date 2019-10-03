using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.core.Interfaces
{
    public interface IAsyncRepository
    {
        Task<T> GetByIdAsync<T>(int id);
        Task<List<T>> ListAllAsync<T>();
        Task<T> AddAsync<T>(T entity);
        Task UpdateAsync<T>(T entity);
        Task DeleteAsync<T>(T entity);
    }
}
