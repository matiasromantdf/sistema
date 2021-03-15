using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class Nventa
    {
        
        Venta venta = new CapaDatos.Venta();
        List<DetalleVenta> detalle = new List<DetalleVenta>();
        Caja caja = new Caja();

        
        public DataTable TablaDetalle()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("codigo");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("cantidad");
            tabla.Columns.Add("precio");
            tabla.Columns.Add("iva");
            tabla.Columns.Add("subtotal");

           
            for (int i = 0; i < detalle.Count; i++)
            {
                tabla.Rows.Add(detalle[i].Articulo.Cod_articulo,
                    detalle[i].Articulo.Descr_articulo,
                   detalle[i].Cantidad,
                    detalle[i].Articulo.Precio_articulo,
                   detalle[i].Articulo.Iva,
                    detalle[i].Subtotal);
            }

            return tabla;

        }
        
        public void EliminarItem(int indice)
        {            
            detalle.RemoveAt(indice);
        }
      
        public void CalcularBrutoyCosto()
        {
            float iva=0,suma=0,costo = 0;
            for (int i = 0; i < detalle.Count; i++)
            {
                suma += detalle[i].Subtotal;
                costo += (detalle[i].Articulo.Costo_articulo * detalle[i].Cantidad);
                iva += (detalle[i].Subtotal) - (detalle[i].Articulo.Precio_articulo*detalle[i].Cantidad);
            }
            venta.Bruto= suma;
            venta.Costo = costo;
            venta.Iva = iva;
        }
        

      public void CambiarCantidadDetalle(int indice, int cant)
        {
            detalle[indice].Cantidad = cant;
            detalle[indice].Subtotal = cant * detalle[indice].Articulo.Precio_articulo * ((detalle[indice].Articulo.Iva/100)+1);
            CalcularBrutoyCosto();
        }
        public void AgregarItem(string cod, int cantidad)
        {
            bool yaExiste = false;
            for (int i = 0; i < detalle.Count; i++)
            {
                if (detalle[i].Articulo.Cod_articulo==cod)
                {
                    detalle[i].Cantidad += cantidad;
                    detalle[i].Subtotal = detalle[i].Cantidad *
                        detalle[i].Articulo.Precio_articulo *
                        (((detalle[i].Articulo.Iva) / 100) + 1);
                    yaExiste = true;
                }
            }
            if (yaExiste==false)
            {
                CapaDatos.Articulo articulo = new Articulo();
                articulo=articulo.Listar(cod);
                detalle.Add(
                    new DetalleVenta(
                    venta,
                    articulo,
                    cantidad,
                    (articulo.Precio_articulo*cantidad*((articulo.Iva/100)+1))
                    ));
                

            }
            CalcularBrutoyCosto();
        }
        public string ProcesarVenta()
        {
            
            venta.Registrar();
            caja.RegistrarCaja(venta.Bruto);
            caja.RegistrarCosto(venta.Costo);
            caja.RegistrarGanancia(venta.Bruto - venta.Costo - venta.Iva);
            caja.RegistrarIva(venta.Iva);

            foreach (DetalleVenta item in detalle)
            {
                item.Registrar();
                // registrar detalle_venta
                /*
                 * codigo para descontar stock en cada articulo
                 */
                item.Articulo.ActualizarReposicion(item.Cantidad);
                item.Articulo.ActualizarStock(item.Cantidad * -1);

            }
            return "OK";
        }

        public float Total
        {
            get
            {
                return venta.Bruto;
            }
        }
        public int Id
        {
            get
            {
                return venta.IdVenta;
            }

        }
        public DateTime Fecha
        {
            get
            {
                return venta.FechaVenta;

            }
        }

        public void VaciarDetalle()
        {
            detalle.Clear();
        }


    }
}
