using Restaurante.core.Entities;
using Restaurante.core.Interfaces;
using Restaurante.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurante.infrastructure.Services
{
    public class EmpleadosService : IEmpleadosService
    {
        public AppDbContext _context;
        public EmpleadosService(AppDbContext context)
        {
            _context = context;
        }

        public int EditarEmpleado(Empleado Empleado)
        {
            _context.Update(Empleado);
            _context.SaveChanges();
            return Empleado.Id;
        }

        public bool EliminarEmpleado(int id)
        {
            var empleado = _context.Empleados.FirstOrDefault(c => c.Id == id);
            _context.Remove(empleado);
            _context.SaveChanges();
            return true;
        }

        public bool EliminarEmpleados(int[] ids)
        {
            _context.RemoveRange(_context.Empleados.Where(c => ids.Contains(c.Id)));
            _context.SaveChanges();
            return true;
        }

        public int InsertarEmpleado(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
            return empleado.Id;
        }

        public Empleado Obtener(int id)
        {
            return _context.Empleados.FirstOrDefault(c => c.Id == id);
        }

        public List<Empleado> ObtenerEmpleado(int id)
        {
            return _context.Empleados.Where(c => c.RestauranteId == id).ToList();
        }
    }
}
