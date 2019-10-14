using LinqKit;
using RestauranteEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamic
{
   public static class LinqClass
    {

        public static void ObtenerVentasMayores(double cantidad)
        {
            var context = new cursoEntities();
             
            //Inner join desde el mismo contexto(inferido)
            var res = from cte in context.Cliente.Where(c => c.Venta.Any())
                      select new { cte.Id, Total = cte.Venta.Sum(d => d.Total) };

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(res);

            
            //Origenes de datos independientes
            var cts = context.Cliente.Select(d => new { Id = d.Id, Nombre = d.Nombre }).ToList();
            var ventas = context.Venta.Where(c => c.Cliente.Any())
                .Select(d => new {ClienteId = d.Cliente.FirstOrDefault().Id,Total = d.Total }).ToList();


            //Inner join
            var res2 = from ct in cts
                       join v in ventas on ct.Id equals v.ClienteId into resTmp
                       select new {Id = ct.Id,ct.Nombre,Total = resTmp.Sum(d=>d.Total) }; 
            var jsonRes2 = Newtonsoft.Json.JsonConvert.SerializeObject(res2);
             
             
            //Left Join
            var resSinVentas = from cte in context.Cliente
                               join vta in context.Venta on cte.Id equals vta.Cliente.FirstOrDefault().Id into vps
                               from r in vps.DefaultIfEmpty() 
                               select new { cte.Id, Total = r == null ? 0 : r.Total};

            var jsonresSinVentas = Newtonsoft.Json.JsonConvert.SerializeObject(resSinVentas);


        }



        public static void ObtenerVentasPorFiltros(double cantidad, string cliente, string restaurante)
        {
            var context = new cursoEntities();
            var predicate = PredicateBuilder.New<Venta>(true);


            //Si se envia el cliente filtrar por su nombre
            if (!String.IsNullOrEmpty(cliente))
            {
                predicate = predicate.And(c => c.Cliente.Any() && c.Cliente.FirstOrDefault().Nombre.ToLower().Contains(cliente.ToLower()));

            }  
            //Si se envia la cantidad, validar que el total de la venta sea mayor o igual
            if (cantidad > 0)
            {
                predicate = predicate.And(c => c.Total > cantidad);
            }

            //Si se envia el restaurante filtrar por su nombre 
            if (!String.IsNullOrEmpty(restaurante))
            {
                predicate = predicate.And(c => context.Restaurante.Where(d => d.Id == c.RestauranteId).Any()
                && context.Restaurante.Where(d => d.Nombre.ToLower().Contains(restaurante.ToLower())).Any());
            }

            //O(N)

            var ventasfecha = context.VentaFechasFER.ToList();
            var res =  context.Venta.AsExpandable().Where(predicate).Select(d=>new {Cliente = d.Cliente.FirstOrDefault().Nombre, Total = d.Total }).ToList();
         


        }


    }
}
