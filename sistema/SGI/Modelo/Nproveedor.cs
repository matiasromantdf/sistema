using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class Nproveedor
    {
        CapaDatos.Proveedor prov = new CapaDatos.Proveedor();
        public string NuevoProveedor(string nombre, string tel, string cuit)
        {
            return prov.NuevoProveedor(nombre, tel, cuit);
        }
        public DataTable ObtenerTodos()
        {
            DataTable tabla = prov.ObtenerTodos();
            return tabla;
        }
        public string IncrementarDeuda(int id, float monto)
        {
            return prov.ActualizarCC(monto*-1, id);

        }
        public string DismiuirDeuda(int id, float monto)
        {
            return prov.ActualizarCC(monto, id);

        }

    }
}
