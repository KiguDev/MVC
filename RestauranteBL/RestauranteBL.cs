using RestauranteDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteBL
{
   public class RestauranteBL
    {
         //CRUD

        public int InsertarRestaurante(Restaurante res)
        {
            var restaurantes = new List<Restaurante>(); //Contexto
            restaurantes.Add(res);
            //id = 0;
            //UpdateDatabase();
            //id = Autoincrementable
            return res.Id;
        }

        public void Insertar(Restaurante res)
        {
            MetodosDeContext<Restaurante>.Insertar(res);
        }


        public bool Edit(Restaurante res)
        {
            try
            {
                var restaurantes = new List<Restaurante>(); //Contexto
                var c = new List<Object>();
                
                restaurantes.Add(res);
                var r = ConsultarRestaurante(res.Id, restaurantes);
                r.Nombre = res.Nombre;
                r.Logo = res.Logo;
                r.PaginaWeb = res.PaginaWeb;
                r.Telefono = res.Telefono;
                r.Domicilio = res.Domicilio;
                //UPDATEDATABASE(); 
                return true;

            }
            catch(Exception err)
            {
                //TODO: Validar la excepcion y guardarla en un LOG
                return false;
            }

        }

        public bool Eliminar(int id)
        {
            try
            {
                var restaurantes = new List<Restaurante>(); //Contexto
 
                var r = ConsultarRestaurante(id, restaurantes);
                restaurantes.Remove(r);
                //UPDATEDATABASE(); 
                return true; 
            }
            catch (Exception err)
            {
                //TODO: Validar la excepcion y guardarla en un LOG
                return false;
            }

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

        public Restaurante ConsultarRestaurante(int id,List<Restaurante> context = null)
        {                                      //if       //else
            var restaurantes = context != null ? context : new List<Restaurante>();
            var res = new Restaurante();
            foreach (var r in restaurantes)
            {
                if (r.Id == id)
                {
                    res = r;
                    break;
                }
            }
            return res;
         
        }

    }
}
