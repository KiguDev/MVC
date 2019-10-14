using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
using Restaurante.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurante.Infrastructure.Services
{
    public class OrdenService : IOrdenService
    {
        private readonly AppDbContext _dbContext;
        public OrdenService(AppDbContext dbContext) => _dbContext = dbContext;
        public void Delete(Orden orden) => _dbContext.Ordenes.Remove(orden);

        public Orden Get(int id) => _dbContext.Ordenes.Find(id);

        public List<Orden> GetAll() => _dbContext.Ordenes.ToList();

        public void Insert(Orden orden) => _dbContext.Ordenes.Add(orden);

        public void SaveChanges() => _dbContext.SaveChanges();

        public void Update(Orden orden) => _dbContext.Ordenes.Update(orden);
    }
}
