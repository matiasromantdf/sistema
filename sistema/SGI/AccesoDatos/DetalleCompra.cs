using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
   public class DetalleCompra
    {
        public Compra Compra { get; set; }
        public Articulo Articulo { get; set; }
        public int CantCompra { get; set; }
        public float Costo { get; set; }
        public float Precio { get; set; }
        public float Subtotal { get; set; }

        public DetalleCompra(Compra compra, Articulo articulo, int cantCompra, float costo,float precio ,float subtotal)
        {
            Compra = compra;
            Articulo = articulo;
            CantCompra = cantCompra;
            Costo = costo;
            Precio = precio;
            Subtotal = subtotal;
        }
    }
}
