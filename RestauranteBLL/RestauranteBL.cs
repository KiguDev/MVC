using RestauranteEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteBLL
{
   public class RestauranteBL
    {
         //CRUD
        public static int InsertarRestaurante(Restaurante res)
        {
            var context = new cursoEntities(); 
            context.Restaurante.Add(res); 
            context.SaveChanges();
            return res.Id;
        }

        public static bool Edit(Restaurante res)
        {
            try
            {
                var context = new cursoEntities();

                var r = context.Restaurante.Where(c => c.Id == res.Id).FirstOrDefault();
                r.Nombre = res.Nombre;
                r.Logo = res.Logo;
                r.PaginaWeb = res.PaginaWeb;
                r.Telefono = res.Telefono;
                r.Domicilio = res.Domicilio;
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
                var r = context.Restaurante.Where(c => c.Id == id).FirstOrDefault();
                context.Restaurante.Remove(r);
                context.SaveChanges();
                return true; 
            }
            catch (Exception err)
            {
                //TODO: Validar la excepcion y guardarla en un LOG
                return false;
            }

        }


        public static IEnumerable<Restaurante> ObtenerTodos()
        {
            var context = new cursoEntities();
            return context.Restaurante;
        }


        public IEnumerable<Restaurante> ConsultarRestaurantes(string nombre) 
        {
            var restaurantes = new List<Restaurante>(); //Contexto
            var tmpList = new List<Restaurante>();
            foreach(var r in restaurantes)
            {
                if (r.Nombre.Contains(nombre.ToLower())){
                    tmpList.Add(r);
                    break;
                }
            } 
            return tmpList; 
        }

        public static Restaurante ConsultarRestaurante(int id)
        {                                  //if       //else
            var context =   new cursoEntities();
          
            return context.Restaurante.Where(c=>c.Id == id).FirstOrDefault();
         
        }

    }
}
