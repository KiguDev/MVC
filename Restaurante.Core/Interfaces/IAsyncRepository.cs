using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Core.Interfaces
{
    public interface IAsyncRepository
    {
         Task<T> GetByIdAsync<T>(int id);
         Task<List<T>> GetAllAsync<T>(int id);
         Task UpdateAsync<T>(T entity);
         Task<T> InsertAsync<T>(T entity);
         Task DeleteAsync<T>(T entity);


    }
}
