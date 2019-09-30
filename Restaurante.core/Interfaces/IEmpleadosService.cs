using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.core.Interfaces
{
    public interface IEmpleadosService
    {
        List<Entities.Empleado> ObtenerEmpleado(int id);
        Entities.Empleado Obtener(int id);
        int InsertarEmpleado(Entities.Empleado empleado);
        int EditarEmpleado(Entities.Empleado Empleado);
        bool EliminarEmpleado(int id);
    }
}
