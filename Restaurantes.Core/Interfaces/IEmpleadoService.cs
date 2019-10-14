using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurantes.Core.Interfaces
{
    public interface IEmpleadoService
    {
        List<Restaurantes.Core.Entities.Empleado> ObtenerEmpleado(int id);
        Restaurantes.Core.Entities.Empleado Obtener(int id);
        IEnumerable<Restaurantes.Core.Entities.Empleado> Obtener();

        int insertar(Restaurantes.Core.Entities.Empleado empleado);

        void Editar(Restaurantes.Core.Entities.Empleado empleado);

        void Eliminar(int id);
        void EliminarVarios(int[] ids);
    }
}
