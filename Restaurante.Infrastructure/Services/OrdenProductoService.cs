using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
using Restaurante.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurante.Infrastructure.Services
{
    public class OrdenProductoService : IOrdenProductosService
    {
        public AppDbContext _context;

        public OrdenProductoService(AppDbContext context)
        {
            _context = context;
        }
        public void Agregar(OrdenProducto ordenProducto)
        {
            var producto = _context.Productos.FirstOrDefault(c => c.Id == ordenProducto.ProductoId);
            var orden = _context.Ordenes.FirstOrDefault(c => c.Id == ordenProducto.OrdenId);
            _context.Add(ordenProducto);
            _context.SaveChanges();

        }

        public void Editar(OrdenProducto ordenProducto)
        {
            var producto = _context.Productos.FirstOrDefault(c => c.Id == ordenProducto.ProductoId);
            var orden = _context.Ordenes.FirstOrDefault(c => c.Id == ordenProducto.OrdenId);
            _context.Update(ordenProducto);
            _context.SaveChanges();
        }

        public void Eliminar(OrdenProducto ordenProducto)
        {
            var orden = _context.Ordenes.FirstOrDefault(c => c.Id == ordenProducto.OrdenId);
            _context.Remove(orden);
            _context.SaveChanges();
        }

        public OrdenProducto Obtener(int ordenId, int productoId)
        {

            return _context.OrdenProductos.FirstOrDefault(c => c.OrdenId == ordenId && c.ProductoId == productoId); 
        }

        public List<OrdenProducto> ObtenerOrdenProducto(int id)
        {
            return _context.OrdenProductos.Where(c => c.OrdenId == id).ToList();
        }
    }
}
