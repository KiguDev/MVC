
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurantes.Core.Interfaces
    {
        public interface IMesaService
        {
            List<Restaurantes.Core.Entities.Mesa> ObtenerMesas(int id);
            Restaurantes.Core.Entities.Mesa Obtener(int id);
            IEnumerable<Restaurantes.Core.Entities.Mesa> Obtener();

            int insertar(Restaurantes.Core.Entities.Mesa mesa);

            void Editar(Restaurantes.Core.Entities.Mesa mesa);

            void Eliminar(int id);
            void EliminarVarios(int[] ids);
        }
    }




//void EliminarVarios(int[] ids);


////Interfaz de Mesa
//List<Mesa> ObtenerMesa();
//Mesa ObtenerM(int id);
//int Agregar(Mesa mesa);
//void Editar(Mesa mesa);
//void Remover(Mesa mesa);