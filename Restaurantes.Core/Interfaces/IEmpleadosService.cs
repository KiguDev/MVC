using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.core.Interfaces
{
    public interface IEmpleadosService
    {
        List<Restaurante.Core.Entities.Empleado> ObtenerEmpleado(int id);
        Restaurante.Core.Entities.Empleado Obtener(int id);
        int InsertarEmpleado(Restaurante.Core.Entities.Empleado empleado);
        int EditarEmpleado(Restaurante.Core.Entities.Empleado Empleado);
        bool EliminarEmpleado(int id);
    }
}
