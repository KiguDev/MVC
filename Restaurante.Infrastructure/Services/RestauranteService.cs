using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
using Restaurante.Infrastructure.Data;

namespace Restaurante.Infrastructure.Services
{
    public class RestauranteService : IRestauranteService
    {
        public AppDbContext _context;
        public RestauranteService(AppDbContext context)
        {
            _context = context;
        }
        public Core.Entities.Restaurante Obtener(int id)
        {
            return _context.Restaurantes.FirstOrDefault(r => r.Id == id);
        }

        public List<Core.Entities.Restaurante> ObtenerRestaurantes()
        {
            return _context.Restaurantes.Include(r => r.Mesas).ToList();
        }

        public int insertar (Core.Entities.Restaurante restaurante)
        {
            _context.Restaurantes.Add(restaurante);
            _context.SaveChanges();
            return restaurante.Id;
        }

        public void Editar(Core.Entities.Restaurante restaurante)
        {
            _context.Restaurantes.Update(restaurante);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var restaurante = _context.Restaurantes.FirstOrDefault(r => r.Id == id);
            _context.Remove(restaurante);
            _context.SaveChanges();
        }
    }
}
