using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteDAO
{
   public class Reservacion
    {
        public int Id { get; set; }
        public int MesaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public EstadoReservacion Estado { get; set; }
        public Cliente Cliente { get; set; }
        public Mesa Mesa { get; set; }

        public VentaReservacion VentaReservacion { get; set; }
    }


    public enum EstadoReservacion
    {
        Pendiente,
        EnUso,
        Cancelada,
        Finalizada
    } 
}
