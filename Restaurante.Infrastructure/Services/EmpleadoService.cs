using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
using Restaurante.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurante.Infrastructure.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        public AppDbContext _context;

        public EmpleadoService(AppDbContext context)
        {
            _context = context;
        }

        public List<Empleado> ObtenerEmpleados(int id)
        {
            var empleados = _context.Empleados.Where(e => e.RestauranteId == id).ToList();
            return empleados;
        }
        public Empleado Obtener(int id)
        {
            return _context.Empleados.FirstOrDefault(c => c.Id == id);
        }

        public int Agregar(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
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
    }
}
