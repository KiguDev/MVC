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
    public class OrdenService : IOrdenService
    {

        public AppDbContext _context;

        public OrdenService(AppDbContext context)
        {
            _context = context;
        }

        public int Agregar(Orden orden)
        {
            _context.Ordenes.Add(orden);
            _context.SaveChanges();
            return orden.Id;
        }

        public void Editar(Orden orden)
        {
            _context.Update(orden);
            _context.SaveChanges();
        }

        public void Eliminar(Orden orden)
        {
            _context.Remove(orden);
            _context.SaveChanges();
        }

        public Orden Obtener(int id)
        {
            return _context.Ordenes.FirstOrDefault(c => c.Id == id);
        }

        public List<Orden> ObtenerOrdenes(int id)
        {
            var ordenes = _context.Ordenes.Where(p => p.RestauranteId == id).ToList();
            return ordenes;
        }
    }
}
