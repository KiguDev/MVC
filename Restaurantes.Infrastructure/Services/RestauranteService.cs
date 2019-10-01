using Microsoft.EntityFrameworkCore;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurantes.Infrastructure.Services
{
    public class RestauranteService : IRestauranteService
    {


        public AppDbContext _context;


        public RestauranteService(AppDbContext context)
        {
            _context = context;
        }


        //Empleado
        //--------------------------------------------------------------------------------------------
        //Obtener Restaurantes por id
        public Restaurante Obtener(int id)
        {
            return _context.Restaurantes.FirstOrDefault(c => c.Id == id);
        }

        //Obtener listado de restaurantes
        public List<Restaurante> ObtenerRestaurantes()
        {
            return _context.Restaurantes.Include(c => c.Mesas).ToList();
        }

        //Obtener listado de restaurantes por id para agregar
        public int Agregar(Restaurante restaurante)
        {
            _context.Add(restaurante);
            _context.SaveChanges();
            return restaurante.Id;
        }

        // Editar Restaurante 
        public void Editar(Restaurante restaurante)
        {
            _context.Update(restaurante);
            _context.SaveChanges();
        }

        //Empleado
        //--------------------------------------------------------------------------------------------
        //Obtner Empleado por ID
        public Empleado ObtenerE(int id)
        {
            return _context.Empleados.FirstOrDefault(c => c.Id == id);
        }

        //Listado de Empleados 
        public List<Empleado> ObtenerEmpleado()
        {
            return _context.Empleados.Include(c => c.RestauranteId).ToList();
        }

        // Agregar Empleado 
        public int Agregar(Empleado empleado)
        {
            _context.Add(empleado);
            _context.SaveChanges();
            return empleado.Id;
        }

        //Editar Empleado
        public void Editar(Empleado empleado)
        {
            _context.Update(empleado);
            _context.SaveChanges();
        }

        //Remover Empleado
        public void Remove(Empleado empleado)
        {
            _context.Empleados.Remove(empleado);
            _context.SaveChanges();
        }

        //Mesas
//--------------------------------------------------------------------------------------------
        //Obtener Mesa por ID
        public Mesa ObtenerM(int id)
        {
            return _context.Mesas.FirstOrDefault(c => c.Id == id);
        }
        // Obtener el listado de Mesas
        public List<Mesa> ObtenerMesa()
        {
            return _context.Mesas.Include(c => c.Id).ToList();
        }
        //Agregar Mesas
        public int Agregar(Mesa mesa)
        {
            _context.Add(mesa);
            _context.SaveChanges();
            return mesa.Id;
        }
        //Editar Mesas
        public void Editar(Mesa mesa)
        {
            _context.Update(mesa);
            _context.SaveChanges();
        }
        //Eliminar Mesa
        public void Remove(Mesa mesa)
        {
            _context.Mesas.Remove(mesa);
            _context.SaveChanges();

        }
        //Ordenes
        //--------------------------------------------------------------------------------------------
        //public List<Orden> ObtenerTodo()
        //{
        //    return _context.Orden;
        //}

    }
}
