using RestauranteEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteBLL
{ 
    public class MesaBL
    {

        public static int Insertar(Mesa Mesa)
        { 
            var context = new cursoEntities();
            context.Mesa.Add(Mesa);
            context.SaveChanges();
            return Mesa.Id;
        }

        public static bool Editar(Mesa Mesa)
        {
            try
            {
                var context = new cursoEntities();
                var mesa = context.Mesa.Where(c => c.Id == Mesa.Id).FirstOrDefault();
                mesa.Identificador = Mesa.Identificador;
                mesa.Capacidad = Mesa.Capacidad;
                context.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public static bool Eliminar(int id)
        {
            try
            {
                var context = new cursoEntities();
                var emp = context.Mesa.Where(c => c.Id ==  id).FirstOrDefault();
                context.Mesa.Remove(emp);
                context.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public static Mesa Obtener(int id)
        {
            try
            {
                var context = new cursoEntities();
                return context.Mesa.Where(c => c.Id == id).FirstOrDefault();
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public static IEnumerable<Mesa> ObtenerPorRestaurant(int id)
        { 
            try
            {
                var context = new cursoEntities();
                return context.Mesa.Where(c => c.RestauranteId == id); 
            }
            catch (Exception err)
            {
                throw err;
            } 
        }



    }

}

 