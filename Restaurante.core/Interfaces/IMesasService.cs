using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.core.Interfaces
{
    public interface IMesasService
    {
        List<Entities.Mesa> ObtenerMesas(int id);
        Entities.Mesa Obtener(int id);
        int InsertarMesa(Entities.Mesa mesa);
        int EditarMesa(Entities.Mesa mesa);
        bool EliminarMesa(int id);
        bool EliminarMesas(int[] ids);
    }
}
