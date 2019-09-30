using System;
using System.Collections.Generic;
using System.Text;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Infrastructure.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Restaurantes.Infrastructure.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        //Se declara el contexto
        public AppDbContext _context;

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
            return empleado.Id;
        }

        public Empleado Obtener(int id)
        {
            return _context.Empleados.FirstOrDefault(c=>c.Id == id);
        }

        public List<Empleado> ObtenerEmpleados()
        {
            return _context.Empleados.Include(c=>c.Restaurante).ToList();
        }
    }
}
