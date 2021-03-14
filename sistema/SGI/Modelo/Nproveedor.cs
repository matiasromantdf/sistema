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
        public string NuevoProveedor(string nombre,string tel, string cuit)
        {
            CapaDatos.Proveedor prov = new CapaDatos.Proveedor();
            return prov.NuevoProveedor(nombre,tel,cuit);
        }
        public DataTable ObtenerTodos()
        {
            Proveedor prov = new Proveedor();
            DataTable tabla = prov.ObtenerTodos();
            return tabla;
        }
    }
}
