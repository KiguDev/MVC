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

        public EmpleadoService(AppDbContext context)
        {
            _context = context;
        }

        public void Editar(Empleado empleado)
        {
            _context.Update(empleado);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var empleado = _context.Empleados.Where(c => c.Id == id).FirstOrDefault();
            _context.Empleados.Remove(empleado);
            _context.SaveChanges();
        }

        public void Eliminar(int[] ids)
        {
            _context.RemoveRange(_context.Empleados.Where(c => ids.Contains(c.Id)));
            _context.SaveChanges();
        }

        public int Agregar(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
            return empleado.Id;
        }

        public Empleado Obtener(int id)
        {
            return _context.Empleados.FirstOrDefault(c=>c.Id == id);
        }

        public List<Empleado> ObtenerEmpleados(int ResId)
        {
            var empleados = _context.Empleados.Where(c => c.RestauranteId == ResId);
            return empleados.ToList();
        }
    }
}
