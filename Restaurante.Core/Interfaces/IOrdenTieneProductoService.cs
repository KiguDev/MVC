using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Core.Interfaces
{
    public interface IOrdenTieneProductoService
    {
        List<Entities.OrdenTieneProducto> ObtenerOrdenTProducto(int id);
        Entities.OrdenTieneProducto Obtener(int id);

        int insertar(Restaurante.Core.Entities.OrdenTieneProducto orden);

        void Editar(Restaurante.Core.Entities.OrdenTieneProducto orden);

        void Eliminar(int id);

       // List<Entities.Orden> ObtenerTodas();
    }
}
