﻿using Microsoft.EntityFrameworkCore;
using Restaurantes.Infrastructure.Data;
using Restaurantes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurantes.Core.Entities;

namespace Restaurantes.Infrastructure.Services
{
    public class RestauranteService : IRestauranteService
    {
        public AppDbContext _context;
        public RestauranteService(AppDbContext context)
        {
            _context = context;
        }


        //Editar Restaurante por contexto retornando el Id del restaurante
        public int Editar(Restaurantes.Core.Entities.Restaurante restaurante)
        {
            _context.Update(restaurante);
            _context.SaveChanges();
            return restaurante.Id;
        }

        public int Editar(int Id)
        {
            var restaurantes = _context.Restaurantes.Find(Id);
            Id = restaurantes.Id;
            _context.Restaurantes.UpdateRange();
            _context.SaveChanges();
            return restaurantes.Id;
        }

        public void Eliminar(int id)
        {
            var restaurante = _context.Restaurantes.FirstOrDefault(c => c.Id == id);
            _context.Remove(restaurante);
            _context.SaveChanges();
        }

        public void Eliminar(int[] ids)
        {
            var restaurantes = _context.Restaurantes.Where(c => ids.Contains(c.Id));
            _context.RemoveRange(restaurantes);
            _context.SaveChanges();

        }

        public void EliminarVarios(int[] ids)
        {
            var restaurantes = _context.Restaurantes.Where(c => ids.Contains(c.Id));
            _context.RemoveRange(restaurantes);
            _context.SaveChanges();
        }

        public int Insertar(Core.Entities.Restaurante restaurante)
        {
            _context.Restaurantes.Add(restaurante);
            _context.SaveChanges();
            return restaurante.Id;
        }



        public Core.Entities.Restaurante Obtener(int id)
        {
            return _context.Restaurantes.FirstOrDefault(c => c.Id == id);
        }


        public List<Core.Entities.Restaurante> ObtenerRestaurantes()
        {
            return _context.Restaurantes.Include(c => c.Mesas).Include(d => d.Empleados).ToList();
        }

       
    }
}
