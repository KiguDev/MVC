using Restaurantes.Infrastructure.Data;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
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

        public int Insertar(Empleado empleado)
        {
           
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
            return empleado.Id;
        }

       

        public Empleado Obtener(int id)
        {
            return _context.Empleados.FirstOrDefault(e => e.Id == id);
        }

        public List<Empleado> ObtenerEmpleados(int id)
        {

            var empleados = _context.Empleados.Where(e => e.RestauranteId == id).ToList();
            return empleados;
        }

    }
}
