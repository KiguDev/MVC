using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Core.Interfaces
{
    public interface IAsyncRepository
    {
        Task GetByIdAsync<T>(int id);
        Task<List<T>> ListAllASync<T>();
        Task<T> AddASync<T>(T entity);
        Task UpdateAsync<T>(T entity);
        Task DeleteAsync<T>(T entity);
    }
}
