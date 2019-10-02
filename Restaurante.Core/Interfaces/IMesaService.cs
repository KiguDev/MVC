using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Core.Interfaces
{
    public interface IMesaService
    {
        List<Entities.Mesa> ObtenerMesas();
        Entities.Mesa Obtener(int id);

        int Insertar(Core.Entities.Mesa mesa);
        void Editar(Core.Entities.Mesa mesa);
        void Eliminar(Core.Entities.Mesa Mesa);
        void Eliminar(int[] ids);

    }
}
