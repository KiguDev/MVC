using Restaurante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Core.Interfaces
{
    public interface IOrdenProductosService
    {
        List<OrdenProducto> ObtenerOrdenProducto(int id);
        OrdenProducto Obtener(int ordenId, int productoId);
        void Agregar(OrdenProducto ordenProducto);
        void Editar(OrdenProducto ordenProducto);
        void Eliminar(OrdenProducto ordenProducto);
    }
}
