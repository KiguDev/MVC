using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Core.Interfaces
{
    public interface IEmpleadoService
    {
        List<Entities.Empleado> ObtenerEmpleado();
        Entities.Empleado Obtener(int id);

        int Insertar(Core.Entities.Empleado empleado);
        void Editar(Core.Entities.Empleado empleado);
        void Eliminar(Core.Entities.Empleado empleado);
    }
}
