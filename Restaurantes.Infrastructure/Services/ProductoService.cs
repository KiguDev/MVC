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
    public class ProductoService : IProductoService
    {
        public AppDbContext _context;
        public ProductoService(AppDbContext context)
        {
            _context = context;
        }

        public int Agregar(Producto producto)
        {
            _context.Add(producto);
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

        public void Eliminar(int[] ids)
        {
            _context.RemoveRange(_context.Productos.Where(c => ids.Contains(c.Id)));
            _context.SaveChanges();
        }

        public Producto Obtener(int id)
        {
            return _context.Productos.FirstOrDefault(c => c.Id == id);
        }

        public List<Producto> ObtenerProductos(int id)
        {
            return _context.Productos.Include(c => c.Restaurante).Where(d => d.RestauranteId == id).ToList();
        }
    }
}
