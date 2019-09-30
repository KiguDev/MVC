using Microsoft.EntityFrameworkCore;
using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
using Restaurante.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurante.infrastructure.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        public AppDbContext _context;

        public EmpleadoService(AppDbContext context)
        {
            _context = context;
        }

        public void Editar(Empleado empleado)
        {
            _context.Update(empleado);
            _context.SaveChanges();
        }

        public void Eliminar(Empleado empleado)
        {
            _context.Empleados.Remove(empleado);
            _context.SaveChanges();
        }

        public int Insertar(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
            return empleado.Id;
        }

        public Core.Entities.Empleado Obtener(int id)
        {
            return _context.Empleados.FirstOrDefault(c => c.Id == id);

        }

        public List<Core.Entities.Empleado> ObtenerEmpleado()
        {
            return _context.Empleados.Include(c => c.Restaurante).ToList();
        }
    }
}
