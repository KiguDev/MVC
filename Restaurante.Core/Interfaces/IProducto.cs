using Restaurante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Core.Interfaces
{
    public interface IProductoService
    {
        Producto Get(int id);
        IEnumerable<Producto> GetAll(int id);
        void Insert(Producto producto);
        void Edit(Producto producto);
        void Delete(Producto producto);
        void SaveChanges();
    }
}
