using Restaurante.Core.Entities;
using System.Collections.Generic;

namespace Restaurante.infrastructure.Services
{
    public interface IOrdenService
    {
        List<Ordenes> ObtenerTodo();
    }
}