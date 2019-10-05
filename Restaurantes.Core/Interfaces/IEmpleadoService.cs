using System;
using System.Collections.Generic;
using Restaurantes.Core.Entities;

namespace Restaurantes.Core.Interfaces
{
    public interface IEmpleadoService
    {
        List<Empleado> ObtenerEmpleados(int id);
        Empleado Obtener(int id);
        int Agregar(Empleado empleado);
        void Editar(Empleado empleado);
        void Eliminar(Empleado empleado);
        void Eliminar(int[] ids);
    }
}
