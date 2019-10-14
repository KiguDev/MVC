using RestauranteEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace RestauranteBLL
{
    public static class ViewBLL
    {

        public static IEnumerable<CLIENTESRESERVACIONESVENTASTOTALES> ObtenerTodos()
        {
            var context = new cursoEntities();
            return context.CLIENTESRESERVACIONESVENTASTOTALES;
        }
    }
}
