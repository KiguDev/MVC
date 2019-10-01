using Restaurante.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.core.Interfaces
{
    public interface IOrdenesService
    {
        List<Orden> ObtenerTodos();
    }
}
