using Restaurante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Core.Interfaces
{
     public interface IOrdenService
    {
        Orden Get(int id);
        List<Orden> GetAll();
        void Insert(Orden orden);
        void Update(Orden orden);
        void Delete(Orden orden);
        void SaveChanges();
    }
}
