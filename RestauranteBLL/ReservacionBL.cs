using RestauranteEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteBLL
{
    public enum EstadoReservacion
    {
        Pendiente,
        EnUso,
        Cancelada,
        Finalizada
    }
    public static class ReservacionBL
    {

        public static int Insertar(Reservacion reservacion)
        {
            var context = new cursoEntities();
            context.Reservacion.Add(reservacion);
            context.SaveChanges();
            return reservacion.Id;
        }

        public static bool Editar(Reservacion reservacion)
        {

            if (!Disponible(reservacion.Id, reservacion.Mesaid, reservacion.FechaInicio, reservacion.FechaFin))
                return false;

            var context = new cursoEntities();
            var res = context.Reservacion.Where(c => c.Id == reservacion.Id).FirstOrDefault();
            res.Mesaid = reservacion.Mesaid;
            res.FechaInicio = reservacion.FechaFin;
            context.SaveChanges();
            return true;
        }
        public static bool EditarEstado(int id, EstadoReservacion estado)
        {
 
            var context = new cursoEntities();
            var res = context.Reservacion.Where(c => c.Id == id).FirstOrDefault();
            res.Estado = (int)estado;
            context.SaveChanges();
            return true;
        }

        public static IEnumerable<Reservacion> ObtenerPorRestaurant(int id)
        { 
            var context = new cursoEntities();
            var mesas = context.Mesa.Where(c => c.RestauranteId == id); 
            return mesas.SelectMany(c=>c.Reservacion);
        }
        public static Reservacion Obtener(int id)
        {
            var context = new cursoEntities();
        
            return context.Reservacion.Where(c => c.Id == id).FirstOrDefault();
        }

        public static bool Disponible(int reservacionId, int MesaId, DateTime Desde, DateTime Hasta)
        {
            var context = new cursoEntities();
            var reservaciones = context.Reservacion.Where(c =>c.Id != reservacionId 
            && c.Mesaid == MesaId && c.Estado != (int)EstadoReservacion.Cancelada 
            && c.FechaInicio >= Desde && c.FechaInicio < Hasta);
            if (reservaciones.Any())
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
