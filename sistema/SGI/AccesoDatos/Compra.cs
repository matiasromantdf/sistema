using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Compra
    {
        public int Id_compra {get;}
        public int Id_proveedor { set; get; }
        public string Num_factura { set; get; }
        public DateTime Fecha_compra { set; get; }
        public float Monto_compra { set; get; }
        public float Iva_compra { set; get; }



    }
}
