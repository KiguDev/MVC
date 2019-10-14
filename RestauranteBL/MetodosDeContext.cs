using RestauranteEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteBL
{
   public class MetodosDeContext<T>
    { 
        

        public static void Insertar(T value)
        {
            var context = new cursoEntities();
            var tipo = context.Set(value.GetType());
            tipo.Add(value);
        } 

        public void Eliminar(int id)
        {
            
        }

        public void Obtener(int id)
        {
           
        } 
       
    }
}
