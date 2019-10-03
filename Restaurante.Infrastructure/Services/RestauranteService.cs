using Microsoft.EntityFrameworkCore;
using Restaurante.Core.Entities;
using Restaurante.Infrastructure.Data;
using Restaurante.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurante.Infrastructure.Services
{
    public class RestauranteService : IRestauranteService
    {
        private readonly AppDbContext _context;
        public RestauranteService(AppDbContext context) => _context = context;
        public Core.Entities.Restaurante Obtener(int id) => _context.Restaurantes.FirstOrDefault(c => c.Id == id);
        public List<Core.Entities.Restaurante> ObtenerRestaurantes() => _context.Restaurantes.Include(r => r.Mesas).ToList();
        public void InsertRecord(Core.Entities.Restaurante restaurante) => _context.Restaurantes.Add(restaurante);
        public void SaveChanges() => _context.SaveChanges();
        public void Edit(Core.Entities.Restaurante restaurante) => _context.Update(restaurante);
        public void Delete(Core.Entities.Restaurante restaurante) => _context.Remove(restaurante);
        public void Delete(List<int> ids) => _context.Restaurantes.RemoveRange(_context.Restaurantes.Where(r => ids.Contains(r.Id)));
    }
}
