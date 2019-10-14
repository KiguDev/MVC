using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Core.Interfaces
{
    public interface IEmpleadoService
    {
        IEnumerable<Entities.Empleado> GetEmpleados(int id);
        Entities.Empleado GetEmpleado(int id);
        void Insert(Entities.Empleado empleado);
        void Update(Entities.Empleado empleado);
        void Delete(Entities.Empleado empleado);
        void DeleteRange(int[] id);
        void SaveChanges();
    }
}
