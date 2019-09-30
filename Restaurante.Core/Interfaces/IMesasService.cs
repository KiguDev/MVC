using System;
using System.Collections.Generic;
using System.Text;
using Restaurante.Core.Entities;

namespace Restaurante.Core.Interfaces
{
    public interface IMesasService
    {
        List<Mesa> ObtenerMesas();
        Mesa Obtener(int id);
        int Agregar(Mesa mesa);
        void Editar(Mesa mesa);
        void Eliminar(Mesa mesa);

    }
}
