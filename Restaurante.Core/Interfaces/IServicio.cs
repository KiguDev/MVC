using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurante.Core.Interfaces
{
    public interface IServicio<T> where T : class
    {
        List<T> GetAll();
        T Get(int id);
        List<T> GetAllInclude();
        void Update(T record);
        void Insert(T record);
        void DeleteRercord(T record);
        void SaveChanges();
    }
}
