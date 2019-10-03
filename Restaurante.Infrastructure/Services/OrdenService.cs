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
        private readonly AppDbContext DbContext;

        public OrdenService(AppDbContext dbContext) => DbContext = dbContext;
        public void Delete(Orden orden) => DbContext.Ordenes.Remove(orden);
        public List<Orden> GetAll() => DbContext.Ordenes.ToList();
    }
}
