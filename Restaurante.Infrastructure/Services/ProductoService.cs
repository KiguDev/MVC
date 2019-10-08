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
    public class ProductoService : IProductoService
    {
        public AppDbContext _context;

        public ProductoService(AppDbContext context)
        {
            _context = context;
        }

        public int Agregar(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return producto.Id;
        }

        public void Editar(Producto producto)
        {
            _context.Update(producto);
            _context.SaveChanges();
        }

        public void Eliminar(Producto producto)
        {
            _context.Remove(producto);
            _context.SaveChanges();
        }

        public Producto Obtener(int id)
        {
            return _context.Productos.FirstOrDefault(c => c.Id == id);
        }

        public List<Producto> ObtenerProductos(int id)
        {
            var productos = _context.Productos.Include(m => m.Restaurante).Where(p => p.RestauranteId == id).ToList();
            return productos;
        }
    }
}
