using System.Collections.Generic;


namespace Restaurantes.Core.Interfaces
{
    public interface IRestauranteService 
    {
        List<Entities.Restaurante> ObtenerRestaurantes();
        Entities.Restaurante Obtener(int id);

        int Insertar(Entities.Restaurante restaurante);

        void Editar(Entities.Restaurante restaurante);

        void Eliminar(int id);

        void EliminarVarios(int[] ids);

    }





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

