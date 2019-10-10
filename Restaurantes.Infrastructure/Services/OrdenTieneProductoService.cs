using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurantes.Infrastructure.Services
{
    public class OrdenTieneProductoService : IOrdenTieneProductoService
    {
        public AppDbContext _context;

        public OrdenTieneProductoService(AppDbContext context)
        {
            _context = context;
        }

        public void Eliminar(int id)
        {
            var ordenTieneProducto = _context.OrdenTieneProductos.FirstOrDefault(c => c.OrdenId == id);

            _context.Remove(ordenTieneProducto);
            _context.SaveChanges();
        }

        public void Eliminar(int[] ids)
        {
            _context.RemoveRange(_context.OrdenTieneProductos.Where(c => ids.Contains(c.OrdenId)));
            _context.SaveChanges();
        }

        public List<OrdenTieneProducto> ObtenerOrdenTieneProductos(int id)
        {
            return _context.OrdenTieneProductos.Where(c => c.OrdenId == id).ToList();
        }

        public OrdenTieneProducto Obtener(int id)
        {
            return _context.OrdenTieneProductos.FirstOrDefault(c => c.OrdenId == id);
        }

        public int Agregar(OrdenTieneProducto ordenTieneProducto)
        {
            _context.Add(ordenTieneProducto);
            _context.SaveChanges();

            return ordenTieneProducto.OrdenId;
        }
    }
}
