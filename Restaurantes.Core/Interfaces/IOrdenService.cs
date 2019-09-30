using Restaurantes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurantes.Core.Interfaces
{
    public interface IOrdenService
    {
        List<Orden> ObtenerTodo();

        //int Insertar(Core.Entities.Empleado empleado);
        //void Editar(Core.Entities.Empleado empleado);
        //void Eliminar(Core.Entities.Empleado empleado);
    }
}
