using System;
using System.Collections.Generic;
using Restaurantes.Core.Entities;

namespace Restaurantes.Core.Interfaces
{
    public interface IOrdenService
    {
        List<Orden> ObtenerTodo();
    }
}
