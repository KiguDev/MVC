﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurantes.Core.Interfaces
{
    public interface IAsyncRepository
    {
        Task<T> GetByIdAsync<T>(int id);
        Task<List<T>> ListAllAsync<T>();
        Task<T> AddAsync<T>(T entity);
        Task<T> UpdateAsync<T>(T entity);
        Task DeleteAsync<T>(T entity);
    }
}
