using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
using Restaurante.Infrastructure.Data;

namespace Restaurante.Infrastructure.Services
{
    public class MesaService : IMesaService
    {
        public AppDbContext _context;
        public MesaService(AppDbContext context)
        {
            _context = context;
        }

        public int insertar(Core.Entities.Mesa mesa)
        {
            _context.Mesas.Add(mesa);
            _context.SaveChanges();
            return mesa.Id;
        }

        public void Editar(Core.Entities.Mesa mesa)
        {
            _context.Mesas.Update(mesa);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var mesa = _context.Mesas.FirstOrDefault(m => m.Id == id);
            _context.Remove(mesa);
            _context.SaveChanges();
        }



        public void EliminarVarios(int[] ids)
        {
            var mesas = _context.Mesas;

            //var restaurantesEliminar = restaurantes.Where(r => r.Id == ids.Where(id => id == r.Id).FirstOrDefault());
            var mesasEliminar = mesas.Where(m => ids.Contains(m.Id));
            _context.RemoveRange(mesasEliminar);
            _context.SaveChanges();

        }


        public Core.Entities.Mesa Obtener(int id)
        {
            return _context.Mesas.FirstOrDefault(m => m.Id == id);
        }

        public List<Core.Entities.Mesa> ObtenerMesas(int id)
        {
           var mesas =  _context.Mesas.Include( m => m.Restaurante).Where(mes => mes.RestauranteId == id).ToList();
            return mesas;
        }

       /* Core.Entities.Mesa IMesaService.Obtener(int id)
        {
            return _context.Mesas.FirstOrDefault(m => m.Id == id);
        }*/
    }
}
