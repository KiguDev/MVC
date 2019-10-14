using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Core.Interfaces
{
    public interface IEmpleadoService
    {
        List<Entities.Empleado> ObtenerEmpleados(int id);
        Entities.Empleado Obtener(int id);

        int insertar(Restaurante.Core.Entities.Empleado empleado);

        void Editar(Restaurante.Core.Entities.Empleado empleado);

        void Eliminar(int id);
        void EliminarVarios(int[] ids);
    }
}
