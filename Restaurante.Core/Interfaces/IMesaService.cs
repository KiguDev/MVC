using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Core.Interfaces
{
    public interface IMesaService
    {
        List<Entities.Mesa> ObtenerMesas(int id);
        Entities.Mesa Obtener(int id);

        int insertar(Restaurante.Core.Entities.Mesa mesa);

        void Editar(Restaurante.Core.Entities.Mesa mesa);

        void Eliminar(int id);
    }
}
