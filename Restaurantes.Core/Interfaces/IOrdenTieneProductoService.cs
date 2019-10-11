using Restaurantes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurantes.Core.Interfaces
{
    public interface IOrdenTieneProductoService
    {
        List<OrdenTieneProducto> ObtenerOrdenTieneProductos(int id);
        OrdenTieneProducto Obtener(int id);
        int Agregar(OrdenTieneProducto ordenTieneProducto);
        bool CompruebaOrdenProducto(int ordid, int prodid);
        bool CompruebaOrdenProductoCantidad(int ordid, int prodid);
        int ActualizarOrdenProd(OrdenTieneProducto ordenprod);
        int ActualizarOrdenProdMinus(OrdenTieneProducto ordenprod);
        void Eliminar(int ordid, int prodid);
        void Eliminar(int[] ids);
    }
}
