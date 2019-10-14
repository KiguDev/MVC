using RestauranteEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteBLL
{
   public class CategoriaBL
    {
         //CRUD
        public static int Insertar(Categoria res)
        {
            var context = new cursoEntities(); 
            context.Categoria.Add(res); 
            context.SaveChanges();
            return res.Id;
        }

        public static bool Edit(Categoria res)
        {
            try
            {
                var context = new cursoEntities();

                var r = context.Categoria.Where(c => c.Id == res.Id).FirstOrDefault();
                r.Descripcion = res.Descripcion;
                r.Nombre = res.Nombre;
              
                context.SaveChanges();
                return true;

            }
            catch(Exception err)
            {
                //TODO: Validar la excepcion y guardarla en un LOG
                return false;
            }

        }

        public static bool Eliminar(int id)
        {
            try
            {
                var context = new cursoEntities();
                var r = context.Categoria.Where(c => c.Id == id).FirstOrDefault();
                context.Categoria.Remove(r);
                context.SaveChanges();
                return true; 
            }
            catch (Exception err)
            {
                //TODO: Validar la excepcion y guardarla en un LOG
                return false;
            }

        }


        public static IEnumerable<Categoria> ObtenerTodos()
        {
            var context = new cursoEntities();
            return context.Categoria;
        }

        public static IEnumerable<Categoria> ObtenerPorRestaurante(int id)
        {
            var context = new cursoEntities();
            return context.Categoria.Where(c=>c.RestauranteId == id);
        } 
        public static Categoria Consultar(int id)
        {                                  //if       //else
            var context =   new cursoEntities();
          
            return context.Categoria.Where(c=>c.Id == id).FirstOrDefault();
         
        }

    }
}
