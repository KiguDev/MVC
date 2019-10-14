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
            var producto = _context.Productos.FirstOrDefault(p => p.Id == id);
            _context.Remove(producto);
            _context.SaveChanges();
        }



        public void EliminarVarios(int[] ids)
        {
            var productos = _context.Productos;

            //var restaurantesEliminar = restaurantes.Where(r => r.Id == ids.Where(id => id == r.Id).FirstOrDefault());
            var productosEliminar = productos.Where(p => ids.Contains(p.Id));
            _context.RemoveRange(productosEliminar);
            _context.SaveChanges();

        }


        public Core.Entities.Producto Obtener(int id)
        {
            return _context.Productos.FirstOrDefault(p => p.Id == id);
        }

        public List<Core.Entities.Producto> ObtenerProductos(int id)
        {
            var productos = _context.Productos.Include(m => m.Restaurante).Where(p => p.RestauranteId == id).ToList();
            return productos;
        }
    }
}
