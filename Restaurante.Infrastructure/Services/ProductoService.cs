using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
using Restaurante.Infrastructure.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Infrastructure.Services
{
    public class ProductoService : IProductoService
    {
        private readonly AppDbContext _dbContext;
        public ProductoService(AppDbContext dbContext) => _dbContext = dbContext;
        public void Delete(Producto producto) => _dbContext.Productos.Remove(producto);
        public void Edit(Producto producto) => _dbContext.Update(producto);
        public Producto Get(int id) => _dbContext.Productos.Find(id);
        public IEnumerable<Producto> GetAll(int id) => throw new NotImplementedException();
        public void Insert(Producto producto) => _dbContext.Productos.Add(producto);
        public void SaveChanges() => _dbContext.SaveChanges();
    }
}
