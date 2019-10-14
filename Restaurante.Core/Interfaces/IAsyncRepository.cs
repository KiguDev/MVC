using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Core.Interfaces
{
    public interface IAsyncRepository<T> where T: class
    {
        Task<T> GetByIdAsync<T>(int id);
        Task<List<T>> GetAllAsync<T>();
        Task AddAsync<T>(T entity);
        Task UpdateSync<T>(T entity);
        Task DeleteAsync<T>(T entity);

    }
}
