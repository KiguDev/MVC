using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurantes.Infrastructure.Services
{
    public class OrdenService : IOrdenService
    {
        public AppDbContext _context;

        public OrdenService(AppDbContext context)
        {
            _context = context;
        }

        public Orden Obtener(int id)
        {
            return _context.Ordenes.FirstOrDefault(c => c.Id == id);
        }

        public List<Orden> ObtenerOrdenes(int id)
        {
            return _context.Ordenes.Where(c => c.RestauranteId == id).ToList();
        }

        public int Agregar(Orden orden)
        {
            orden.FechaAlta = DateTime.Now;
            orden.Total = 0;
            _context.Add(orden);
            _context.SaveChanges();

            return orden.Id;
        }

        public void Editar(Orden orden)
        {
            _context.Update(orden);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var orden = _context.Ordenes.FirstOrDefault(c => c.Id == id);

            _context.Remove(orden);
            _context.SaveChanges();
        }

        public void Eliminar(int[] ids)
        {
            _context.RemoveRange(_context.Ordenes.Where(c => ids.Contains(c.Id)));
            _context.SaveChanges();
        }      
    }
}
