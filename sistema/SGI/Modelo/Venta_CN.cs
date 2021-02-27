using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class Venta_CN
    {
        CapaDatos.Venta objVenta = new CapaDatos.Venta();

        public int mostrarUltID()
        {
            return objVenta.mostrarUltId();           
        }

    }
}
