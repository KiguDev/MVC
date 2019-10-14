using Newtonsoft.Json;
using RestauranteEntity;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamic
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
            dict.Add(1, new List<string>() { "meeh", "baah" });
            dict.Add(2, new List<string>() { "asdfg", "qpowe" });

            var res = JsonConvert.SerializeObject(dict);

            dynamic usuario1 = new ExpandoObject();
            usuario1.Nombre = "Fer";
            usuario1.Edad = 1;
            usuario1.Modelos = new List<string>() { "1212", "asdsd" };

            dynamic usuario2 = new ExpandoObject();
            usuario2.Nombre = "Fer 2";
            usuario2.Edad = 2;

            var dict2 = new Dictionary<int, dynamic>();
            dict2.Add(1, usuario1);
            dict2.Add(2, usuario2);

            var res2 = JsonConvert.SerializeObject(dict2);
            var ser = JsonConvert.DeserializeObject(res2);


            //  LinqClass.ObtenerVentasMayores(100);
            LinqClass.ObtenerVentasPorFiltros(0, "jos", "");

            var context = new cursoEntities();
            var resStoreProcedure =   context.SELECTCLIENTES("jos") as IEnumerable<Cliente>;

        }
    }
}
