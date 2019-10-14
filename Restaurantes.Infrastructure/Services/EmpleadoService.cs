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

        public void Editar(Empleado empleado)
        {
            _context.Update(empleado);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var empleado = _context.Empleados.FirstOrDefault(e => e.Id == id);
            _context.Remove(empleado);
            _context.SaveChanges();
        }

        public void EliminarVarios(int[] ids)
        {
            var empleados = _context.Empleados;

            //var restaurantesEliminar = restaurantes.Where(r => r.Id == ids.Where(id => id == r.Id).FirstOrDefault());
            var empleadosEliminar = empleados.Where(m => ids.Contains(m.Id));
            _context.RemoveRange(empleadosEliminar);
            _context.SaveChanges();

        }

        public int insertar(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
            return empleado.Id;
        }

        public Core.Entities.Empleado Obtener(int id)
        {
            return _context.Empleados.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Core.Entities.Empleado> Obtener()
        {
            return _context.Empleados;
        }


        public List<Core.Entities.Empleado> ObtenerEmpleado(int id)
        {
            var empleados = _context.Empleados.Include(m => m.Restaurante).Where(mes => mes.RestauranteId == id).ToList();
            return empleados;
        }
    }
}
