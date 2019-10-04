using Microsoft.EntityFrameworkCore;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurantes.Infrastructure.Services
{
    public class MesaService : IMesaService
    {
        public AppDbContext _context;
        public MesaService(AppDbContext context)
        {
            _context = context;
        }

        public Mesa Obtener(int id)
        {
            return _context.Mesas.FirstOrDefault(c => c.Id == id);
        }

        public List<Mesa> ObtenerMesas(int id)
        {
            return _context.Mesas.Where(c => c.RestauranteId == id).ToList();
        }

        public int Agregar(Mesa mesa)
        {
            _context.Add(mesa);
            _context.SaveChanges();

            return mesa.Id;
        }

        public void Editar(Mesa mesa)
        {
            _context.Update(mesa);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var mesa = _context.Mesas.FirstOrDefault(c => c.Id == id);

            _context.Remove(mesa);
            _context.SaveChanges();
        }

        public void Eliminar(int[] ids)
        {
            _context.RemoveRange(_context.Mesas.Where(c => ids.Contains(c.Id)));
            _context.SaveChanges();
        }
    }
}
