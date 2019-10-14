﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteDAO
{
    public class VentaProducto
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public int ProductoId { get; set; }
        public double Subtotal { get; set; }
        public Venta Venta { get; set; }
        public Producto Producto { get; set; }
     
         
    }
}
