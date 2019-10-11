﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurantes.Core.Entities
{
    public class Orden
    {
        public int Id { get; set; }
        public ICollection<OrdenTieneProducto> Productos { get; set; }
        public int RestauranteId { get; set; }
        public Restaurante Restaurante { get; set; }
        public DateTime FechaAlta{ get; set; }
        public int Estatus { get; set; }
        public double Total { get; set; }
    }

    public enum OrdenEstatus
    {
        Pendiente,
        Cocinando,
        Enviado,
        Entregado
    }
}
