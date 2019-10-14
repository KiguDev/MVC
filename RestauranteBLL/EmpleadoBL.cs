using RestauranteEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteBLL
{
    public enum Puesto
    {
        [Description("Cajero de piso")]
        Cajero,
        Mesero,
        Gerente,
        Cocinero,
        Ayudante,
        Seguridad,
        Limpieza, 
        Habitacion
    }
    public class EmpleadoBL
    {

        public static int Insertar(Empleado empleado)
        { 
            var context = new cursoEntities();
            context.Empleado.Add(empleado);
            context.SaveChanges();
            return empleado.Id;
        }

        public static bool Editar(Empleado empleado)
        {
            try
            {
                var context = new cursoEntities();
                var emp = context.Empleado.Where(c => c.Id == empleado.Id).FirstOrDefault();
                emp.Nombre = empleado.Nombre;
                emp.Puesto = empleado.Puesto;
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
                var emp = context.Empleado.Where(c => c.Id ==  id).FirstOrDefault();
                context.Empleado.Remove(emp);
                context.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public static Empleado Obtener(int id)
        {
            try
            {
                var context = new cursoEntities();
                return context.Empleado.Where(c => c.Id == id).FirstOrDefault();
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public static IEnumerable<Empleado> ObtenerPorRestaurant(int id)
        { 
            try
            {
                var context = new cursoEntities();
                return context.Empleado.Where(c => c.RestauranteId == id); 
            }
            catch (Exception err)
            {
                throw err;
            } 
        }



    }

}

 