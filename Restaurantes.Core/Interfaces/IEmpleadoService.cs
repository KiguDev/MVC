using Restaurantes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurantes.Core.Interfaces
{
    public interface IEmpleadoService
    {
        List<Empleado> ObtenerEmpleados(int id);
        Empleado Obtener(int id);
        int Agregar(Empleado empleado);
        void Editar(Empleado empleado);
        void Eliminar(int id);
        void Eliminar(int[] ids);
    }
}

