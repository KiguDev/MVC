using Restaurante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Core.Interfaces
{
    public interface IOrdenProducto
    {
        List<OrdenProducto> GetAll();
        OrdenProducto Get(OrdenProducto ordenProducto);
        List<OrdenProducto> GetAllInclude(int id);
        void Update(OrdenProducto ordenProducto);
        void Insert(OrdenProducto ordenProducto);
        void DeleteRercord(OrdenProducto ordenProducto);
        void SaveChanges();
    }
}
