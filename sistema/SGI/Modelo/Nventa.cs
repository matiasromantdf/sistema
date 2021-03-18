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
        List<DetalleVenta> detalleVenta = new List<DetalleVenta>();
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

           
            for (int i = 0; i < detalleVenta.Count; i++)
            {
                tabla.Rows.Add(detalleVenta[i].Articulo.Cod_articulo,
                    detalleVenta[i].Articulo.Descr_articulo,
                   detalleVenta[i].Cantidad,
                    detalleVenta[i].Articulo.Precio_articulo,
                   detalleVenta[i].Articulo.Iva,
                    detalleVenta[i].Subtotal);
            }

            return tabla;

        }
        
        public void EliminarItem(int indice)
        {            
            detalleVenta.RemoveAt(indice);
        }
      
        public void CalcularBrutoyCosto()
        {
            float iva=0,suma=0,costo = 0;
            for (int i = 0; i < detalleVenta.Count; i++)
            {
                suma += detalleVenta[i].Subtotal;
                costo += (detalleVenta[i].Articulo.Costo_articulo * detalleVenta[i].Cantidad);
                iva += (detalleVenta[i].Subtotal) - (detalleVenta[i].Articulo.Precio_articulo*detalleVenta[i].Cantidad);
            }
            venta.Bruto= suma;
            venta.Costo = costo;
            venta.Iva = iva;
        }
        

      public void CambiarCantidadDetalle(int indice, int cant)
        {
            detalleVenta[indice].Cantidad = cant;
            detalleVenta[indice].Subtotal = cant * detalleVenta[indice].Articulo.Precio_articulo * ((detalleVenta[indice].Articulo.Iva/100)+1);
            CalcularBrutoyCosto();
        }
        public void AgregarItem(string cod, int cantidad)
        {
            bool yaExiste = false;
            for (int i = 0; i < detalleVenta.Count; i++)
            {
                if (detalleVenta[i].Articulo.Cod_articulo==cod)
                {
                    detalleVenta[i].Cantidad += cantidad;
                    detalleVenta[i].Subtotal = detalleVenta[i].Cantidad *
                        detalleVenta[i].Articulo.Precio_articulo *
                        (((detalleVenta[i].Articulo.Iva) / 100) + 1);
                    yaExiste = true;
                }
            }
            if (yaExiste==false)
            {
                CapaDatos.Articulo articulo = new Articulo();
                articulo=articulo.Listar(cod);
                detalleVenta.Add(
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
            caja.RegistrarCosto(venta.Costo);
            caja.RegistrarGanancia(venta.Bruto - venta.Costo - venta.Iva);
            caja.RegistrarIva(venta.Iva);

            foreach (DetalleVenta item in detalleVenta)
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
            detalleVenta.Clear();
        }


    }
}
