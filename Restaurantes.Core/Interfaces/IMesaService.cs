using Restaurantes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurantes.Core.Interfaces
{
    public interface IMesaService
    {
        List<Mesa> ObtenerMesas(int id);
       Mesa Obtener(int id);

        int Insertar(Mesa mesa);

        void Editar(Mesa mesa);

        void Eliminar(int id);

    }
}

//void EliminarVarios(int[] ids);


////Interfaz de Mesa
//List<Mesa> ObtenerMesa();
//Mesa ObtenerM(int id);
//int Agregar(Mesa mesa);
//void Editar(Mesa mesa);
//void Remover(Mesa mesa);