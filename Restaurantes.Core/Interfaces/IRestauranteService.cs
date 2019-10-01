using Restaurantes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurantes.Core.Interfaces
{
    public interface IRestauranteService
    {
        //Interfaz de Restaurante
        List<Restaurante> ObtenerRestaurantes();
        Restaurante Obtener(int id);
        int Agregar(Restaurante restaurante);
        void Editar(Restaurante restaurante);
        void Eliminar(int id);



        ////Interfaz de Empleado
        //List<Empleado> ObtenerEmpleado();
        //Empleado ObtenerE(int id);
        //int Agregar(Empleado empleado);
        //void Editar(Empleado empleado);
        //void Remover(Empleado empleado);


        ////Interfaz de Mesa
        //List<Mesa> ObtenerMesa();
        //Mesa ObtenerM(int id);
        //int Agregar(Mesa mesa);
        //void Editar(Mesa mesa);
        //void Remover(Mesa mesa);
    }
}
