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
    public class EmpleadoService : IEmpleadoService
    {
        public AppDbContext _context;
        public EmpleadoService(AppDbContext context)
        {
            _context = context;
        }

        public int Agregar(Empleado empleado)
        {
            _context.Add(empleado);
            _context.SaveChanges();
            return empleado.Id;
        }

        public void Editar(Empleado empleado)
        {
            _context.Update(empleado);
            _context.SaveChanges();
        }

        public void Eliminar(Empleado empleado)
        {
            _context.Remove(empleado);
            _context.SaveChanges();
        }

        public void Eliminar(int[] ids)
        {
            _context.RemoveRange(_context.Empleados.Where
                (c => ids.Contains(c.Id)));
            _context.SaveChanges();
        }

        public Empleado Obtener(int id)
        {
            return _context.Empleados.FirstOrDefault(c => c.Id == id);
        }

        public List<Empleado> ObtenerEmpleados(int id)
        {
            return _context.Empleados.Include(c => c.Restaurante).Where
                (d => d.RestauranteId == id).ToList();
        }
    }
}
