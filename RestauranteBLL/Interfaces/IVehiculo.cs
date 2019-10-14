using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteBLL.Interfaces
{
  public interface IVehiculo
    {
         void Moverse(double velocidad, double altitud, double gasolina);
         void Encender();
         void Apagar(); 
    }
}
