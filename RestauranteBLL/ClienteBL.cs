using RestauranteEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteBLL
{
   
    public class ClienteBL
    {

        public static int Insertar(Cliente Cliente)
        { 
            var context = new cursoEntities();
            context.Cliente.Add(Cliente);
            context.SaveChanges();
            return Cliente.Id;
        }

        public static bool Editar(Cliente Cliente)
        {
            try
            {
                var context = new cursoEntities();
                var cte = context.Cliente.Where(c => c.Id == Cliente.Id).FirstOrDefault();
                cte.Nombre = Cliente.Nombre;
                cte.DireccionFiscal = Cliente.DireccionFiscal;
                cte.Email = Cliente.Email;
                cte.RazonSocial = Cliente.RazonSocial;
                cte.Rfc = Cliente.Rfc;
                cte.Telefono = Cliente.Telefono;
            

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
                var emp = context.Cliente.Where(c => c.Id ==  id).FirstOrDefault();
                context.Cliente.Remove(emp);
                context.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public static Cliente Obtener(int id)
        {
            try
            {
                var context = new cursoEntities();
                return context.Cliente.Where(c => c.Id == id).FirstOrDefault();
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public static IEnumerable<Cliente> ObtenerTodos()
        { 
            try
            {
                var context = new cursoEntities();
                return context.Cliente; 
            }
            catch (Exception err)
            {
                throw err;
            } 
        }



    }

}

 