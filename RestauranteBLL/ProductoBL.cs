using RestauranteEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteBLL
{
   public class ProductoBL
    {
         //CRUD
        public static int Insertar(Producto res)
        {
            var context = new cursoEntities(); 
            context.Producto.Add(res); 
            context.SaveChanges();
            return res.Id;
        }

        public static bool Edit(Producto res)
        {
            try
            {
                var context = new cursoEntities();

                var r = context.Producto.Where(c => c.Id == res.Id).FirstOrDefault();
                r.Nombre = res.Nombre;
                r.Descripcion = res.Descripcion;
                r.Imagen = res.Imagen;
                r.Precio = res.Precio;
                r.CategoriaId = res.CategoriaId;
              
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
                var r = context.Producto.Where(c => c.Id == id).FirstOrDefault();
                context.Producto.Remove(r);
                context.SaveChanges();
                return true; 
            }
            catch (Exception err)
            {
                //TODO: Validar la excepcion y guardarla en un LOG
                return false;
            }

        }


        public static IEnumerable<Producto> ObtenerTodos()
        {
            var context = new cursoEntities();
            return context.Producto;
        }

        public static IEnumerable<Producto> ObtenerPorCategoria(int id)
        {
            var context = new cursoEntities();
            return context.Producto.Where(c=>c.CategoriaId == id);
        }
 

        public static Producto Consultar(int id)
        {                                  //if       //else
            var context =   new cursoEntities();
          
            return context.Producto.Where(c=>c.Id == id).FirstOrDefault();
         
        }

    }
}
