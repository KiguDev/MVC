using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
using Restaurante.Infrastructure.Data;

namespace Restaurante.Infrastructure.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly AppDbContext DbContext;
        public EmpleadoService(AppDbContext context) => DbContext = context;
        public Empleado GetEmpleado(int id) => DbContext.Empleados.Where(e => e.Id == id).FirstOrDefault();
        public IEnumerable<Empleado> GetEmpleados(int id) => DbContext.Empleados.Where(e => e.RestauranteId == id);
        public void Insert(Empleado empleado) => DbContext.Add(empleado);
        public void Update(Empleado empleado) => DbContext.Update(empleado); 
        public void Delete(Empleado empleado) => DbContext.Remove(empleado);
        public void SaveChanges() => DbContext.SaveChanges();
        public void DeleteRange(int[] id) => DbContext.Empleados.RemoveRange(DbContext.Empleados.Where(e => id.Contains(e.Id)));
    }
}
