using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Infrastructure.Data;

namespace Restaurantes.Infrastructure.Services
{
    public class OrdenService : IOrdenService
    {
        public AppDbContext _context;

        public OrdenService(AppDbContext context)
        {
            _context = context;
        }

        public List<Orden> ObtenerOrdenes(int id)
        {
            return _context.Ordenes.Include(c => c.Restaurante).Where(d => d.RestauranteId == id).ToList();
        }

        public int Agregar(Orden orden)
        {
            orden.Estatus = 1;
            _context.Add(orden);
            _context.SaveChanges();
            return orden.Id;
        }

        public void CerrarOrden(int id)
        {
            var orden = _context.Ordenes.Where(c => c.Id == id).FirstOrDefault();
            orden.Estatus = 0;
            _context.SaveChanges();
        }

        public void Editar(Orden orden)
        {
            _context.Update(orden);
            _context.SaveChanges();
        }

        public Orden Obtener(int id)
        {
            return _context.Ordenes.FirstOrDefault(c => c.Id == id);
        }

    }
}
