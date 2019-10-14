using RestauranteEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteBLL
{
    public static class VentaBL
    {
         
        public static Cliente ObtenerCliente(int ventaId)
        {
            var context = new cursoEntities();
            return context.Venta.Where(c => c.Id == ventaId).SelectMany(c => c.Cliente).FirstOrDefault();
        }

        public static int InsertarVenta(Venta venta)
        {
            var context = new cursoEntities();
            context.Venta.Add(venta);    //O(1)
            context.SaveChanges();
            return venta.Id;
        }


        public static bool EditarVenta(Venta venta)
        {
            try
            {
                var context = new cursoEntities();
                var vTmp = context.Venta.Where(c => c.Id == venta.Id).FirstOrDefault(); //O(n)
                if (vTmp == null) return false;
                vTmp.MesaId = venta.MesaId;
                vTmp.TipoVenta = venta.TipoVenta;
                vTmp.Total = venta.Total;
                context.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                //Buen manejo de excepciones
                return false;
            }
        }

        public static bool InsertarCliente(int clienteId, int ventaId)
        {
            var context = new cursoEntities();
            var venta = context.Venta.Where(c => c.Id == ventaId);
            var cliente = context.Cliente.Where(c => c.Id == clienteId);

            if (venta.Any())
            {
                venta.FirstOrDefault().Cliente.Add(cliente.FirstOrDefault());
            }

            context.SaveChanges();
            return true;
        }

        public static bool InsertarProductoVenta(VentaProducto ventaProducto)
        {
            try
            {
                var context = new cursoEntities();
                var venta = context.Venta.Where(c => c.Id == ventaProducto.VentaId);
                if (!venta.Any())
                    return false;
                context.VentaProducto.Add(ventaProducto);
                //Actualizar el total de la venta
                venta.First().Total += (ventaProducto.Cantidad * ventaProducto.Precio);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static bool EditarProductoVenta(VentaProducto ventaProducto)
        {
            try
            {
                var context = new cursoEntities();
                var ventaProd = context.VentaProducto.Where(c => c.Id == ventaProducto.Id).FirstOrDefault();
                if ( ventaProd == null)
                    return false;

                if (ventaProducto.Cantidad > 0)
                {
                    //Actualizar el total de la venta
                    ventaProd.Venta.Total -= ventaProd.Subtotal;
                    ventaProd.Cantidad = ventaProducto.Cantidad;
                    ventaProd.Venta.Total += ventaProducto.Cantidad * ventaProducto.Precio;
                }
                else
                {
                    ventaProd.Venta.Total -= ventaProd.Subtotal;
                    context.VentaProducto.Remove(ventaProd); 
                }
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static IEnumerable<Venta> ObtenerTodas(DateTime fechaIn, DateTime fechaFin)
        {
            var context = new cursoEntities();
            var ventas = context.Venta.ToList(); //10,000 registros
            ventas = ventas.Where(c => c.Fecha >= fechaIn && c.Fecha <= fechaFin).ToList();

            var ventasQ = context.Venta.AsQueryable();
            ventasQ = ventasQ.Where(c => c.Fecha >= fechaIn && c.Fecha <= fechaFin); //????????

            return ventasQ.AsEnumerable();//2
        }

        public static Venta Obtener(int id)
        {
            var context = new cursoEntities();
            return context.Venta.Where(c => c.Id == id).FirstOrDefault();
        }
        public static IEnumerable<Venta> ObtenerPorRestaurant(int id)
        {
            var context = new cursoEntities();
            return context.Venta.Where(c => c.RestauranteId == id) ;
        }

    }

    public enum TipoVenta
    {
        OnSite,
        PickAndGo,
        Delivery
    }

    public enum EstadoVenta
    {
        Abierta,
        Finalizada,
        Cancelada
    }
}
