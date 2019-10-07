using Restaurantes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurantes.Core.Interfaces
{
  public  interface IEmpleadoService
    {
        List<Entities.Empleado> ObtenerEmpleados(int id);
        Entities.Empleado Obtener(int id);

        int Insertar(Empleado empleado);

        void Editar(Empleado empleado);

        void Eliminar(int id);
    }
}
