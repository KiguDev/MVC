using Newtonsoft.Json;
using Restaurante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteMVC.Models
{
    //DTO = DATA TRANSFER OBJECT
    public class RestauranteDTO 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public int Mesas { get; set; }
    }
}
