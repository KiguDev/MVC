using Restaurante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Core.Interfaces
{
    public interface IMesasService
    {
        List<Mesa> GetMesas(int id);
        Entities.Mesa GetMesa(int id);
        void Insert(Mesa mesa);
        void Update(Mesa mesa);
        void Delete(Mesa mesa);
        void Delete(int[] id);
        void SaveChanges();
    }
}
