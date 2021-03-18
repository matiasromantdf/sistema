using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
   public class Ncompra
    {
        public Proveedor proveedor;
        public List <DetalleCompra> detalleCompra;
        public Compra compra;
        public Articulo articulo;

        public Ncompra()
        {
            proveedor = new Proveedor();
            detalleCompra = new List<DetalleCompra>();
            compra = new Compra();
        }
        public void AgregarAlDetalle(string cod,string cant,string costo,string precio)
        {
            articulo = new Articulo();
            detalleCompra.Add(new DetalleCompra(
                compra,
                articulo.Listar(cod),
                Convert.ToInt32(cant),
                float.Parse(costo),
                float.Parse(precio),
                (Convert.ToInt32(cant)) * (float.Parse(costo))
                ));
        }
        public DataTable ObtenerTablaDetalle()
        {
            /*
             * creo un objeto datatable y por cada objeto detalleCompra
             * agrego una fila en la tabla con los datos del objeto
             * luego retorna la tabla
             * 
             */
            DataTable tabla = new DataTable();
            tabla.Columns.Add("codigo");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("cantidad");
            tabla.Columns.Add("costo");
            tabla.Columns.Add("precio");
            tabla.Columns.Add("subtotal");


            for (int i = 0; i < detalleCompra.Count; i++)
            {
                tabla.Rows.Add(
                    detalleCompra[i].Articulo.Cod_articulo,
                   detalleCompra[i].Articulo.Descr_articulo,
                    detalleCompra[i].CantCompra,
                   detalleCompra[i].Costo,
                   detalleCompra[i].Precio,
                    detalleCompra[i].Subtotal);
            }

            return tabla;

        }

    }

}
