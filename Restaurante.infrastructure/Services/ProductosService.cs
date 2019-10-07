using Restaurante.core.Entities;
using Restaurante.core.Interfaces;
using Restaurante.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurante.infrastructure.Services
{
    public class ProductosService : IProductosService
    {
        public AppDbContext _context;
        public ProductosService(AppDbContext context)
        {
            _context = context;
        }

        public int EditarProducto(Producto producto)
        {
            _context.Update(producto);
            _context.SaveChanges();
            return producto.Id;
        }

        public bool EliminarProducto(int id)
        {
            var producto = _context.Productos.FirstOrDefault(c => c.Id == id);
            _context.Remove(producto);
            _context.SaveChanges();
            return true;
        }

        public bool EliminarProductos(int[] ids)
        {
            _context.RemoveRange(_context.Productos.Where(c => ids.Contains(c.Id)));
            _context.SaveChanges();
            return true;
        }

        public int InsertarProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return producto.Id;
        }

        public Producto Obtener(int id)
        {
            return _context.Productos.FirstOrDefault(c => c.Id == id);
        }

        public List<Producto> ObtenerProducto(int id)
        {
            return _context.Productos.Where(c => c.RestauranteId == id).ToList();
        }
    }
}
