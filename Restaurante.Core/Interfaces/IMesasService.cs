using System;
using System.Collections.Generic;
using System.Text;
using Restaurante.Core.Entities;

namespace Restaurante.Core.Interfaces
{
    public interface IMesasService
    {
        List<Mesa> ObtenerMesas(int id);
        Mesa Obtener(int id);
        int Agregar(Mesa mesa);
        void Editar(Mesa mesa);
        void Eliminar(Mesa mesa);
        void Eliminar(int[] ids);
    }
}
