using Restaurante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Core.Interfaces
{
    public interface IEmpleadoService
    {
        List<Empleado> ObtenerEmpleados(int id);
        Empleado Obtener(int id);
        int Agregar(Empleado empleado);
        void Editar(Empleado empleado);
        void Eliminar(Empleado empleado);
    }
}
