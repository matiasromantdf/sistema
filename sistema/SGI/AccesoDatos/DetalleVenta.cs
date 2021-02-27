using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos
{
    public class DetalleVenta
    {
        CapaDatos.Venta venta;
        CapaDatos.Articulo articulo;
        int cantidad { get; set; }
        float subtotal { get; set; }

        public void registrar()
        /*
         * codigo sql para grabar tabla detalle_venta
         * tambien hay que descontar stock del obj articulo
         *         
         */
        {

        }
        public DetalleVenta() { }
        public DetalleVenta(Venta venta, Articulo articulo, int cantidad, float subtotal)
        {
            this.venta = venta;
            this.articulo = articulo;
            this.cantidad = cantidad;
            this.subtotal = subtotal;
        }
    }
    

}
