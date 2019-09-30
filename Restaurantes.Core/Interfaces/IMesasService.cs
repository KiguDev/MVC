using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.core.Interfaces
{
    public interface IMesasService
    {
        List<Restaurante.Core.Entities.Mesa> ObtenerMesas(int id);
        Restaurante.Core.Entities.Mesa Obtener(int id);
        int InsertarMesa(Restaurante.Core.Entities.Mesa mesa);
        int EditarMesa(Restaurante.Core.Entities.Mesa mesa);
        bool EliminarMesa(int id);
    }
}
