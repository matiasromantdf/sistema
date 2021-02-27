using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Proveedor_CN
    {
        public string NuevoProveedor(string nombre,string tel)
        {
            CapaDatos.Proveedor prov = new CapaDatos.Proveedor();
            return prov.NuevoProveedor(nombre,tel);
        }
    }
}
