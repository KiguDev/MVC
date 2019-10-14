using Microsoft.EntityFrameworkCore;
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

        public int insertar(Core.Entities.Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return producto.Id;
        }

        public void Editar(Core.Entities.Producto producto)
        {
            _context.Productos.Update(producto);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var producto = _context.Productos.FirstOrDefault(m => m.Id == id);
            _context.Remove(producto);
            _context.SaveChanges();
        }



        public void EliminarVarios(int[] ids)
        {
            var producto = _context.Productos;
            var productoEliminar = producto.Where(m => ids.Contains(m.Id));
            _context.RemoveRange(productoEliminar);
            _context.SaveChanges();

        }


        public Core.Entities.Producto Obtener(int id)
        {
            return _context.Productos.FirstOrDefault(m => m.Id == id);
        }

        public List<Core.Entities.Producto> ObtenerProductos(int id)
        {
            var productos = _context.Productos.Include(m => m.Restaurante).Where(mes => mes.RestauranteId == id).ToList();
            return productos;
        }
    }
}
