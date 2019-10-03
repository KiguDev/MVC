using Microsoft.EntityFrameworkCore;
using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
using Restaurante.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurante.Infrastructure.Services
{
    public class MesaService:IMesasService
    {
        private readonly AppDbContext appDbContext;
        public MesaService(AppDbContext context) => appDbContext = context;
        public Mesa GetMesa(int id) => appDbContext.Mesa.FirstOrDefault(m => m.Id == id);
        public List<Mesa> GetMesas(int id) => appDbContext.Mesa.Where(m => m.RestauranteId == id).ToList();
        public void Insert(Mesa mesa) => appDbContext.Add(mesa);
        public void SaveChanges() => appDbContext.SaveChanges();
        public void Update(Mesa mesa) => appDbContext.Update(mesa);
        public void Delete(Mesa mesa) => appDbContext.Remove(mesa);
        public void Delete(int[] id) => appDbContext.RemoveRange(appDbContext.Mesa.Where(m => id.Contains(m.Id)));
    }
}
