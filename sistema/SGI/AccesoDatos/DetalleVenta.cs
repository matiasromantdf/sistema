using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos
{
    public class DetalleVenta
    {
       
        public int Cantidad { get; set; }
        public float Subtotal { get; set; }
        public Venta Venta { get; set; }
        public Articulo Articulo { get; set; }

        public string Registrar()
        /*
         * codigo sql para grabar tabla detalle_venta               
         */
        {
            Conexion con = new Conexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = con.conectar();
            comando.CommandText = "Insert into detalle_venta(id_venta,cod_articulo,cant_artic_venta,subtotal) values(@id,@art,@cant,@subtotal)";
            comando.Parameters.Add("@id", SqlDbType.Int);
            comando.Parameters.Add("@art", SqlDbType.VarChar);
            comando.Parameters.Add("@cant", SqlDbType.Int);
            comando.Parameters.Add("@subtotal", SqlDbType.Decimal);

            comando.Parameters["@id"].Value = this.Venta.IdVenta;
            comando.Parameters["@art"].Value = this.Articulo.Cod_articulo;
            comando.Parameters["@cant"].Value = this.Cantidad;
            comando.Parameters["@subtotal"].Value = this.Subtotal;

            try
            {
                comando.ExecuteNonQuery();

                return "correcto";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                con.cerrarConexion();
            }


        }

        public DetalleVenta() { }
        public DetalleVenta(Venta venta, Articulo articulo, int cantidad, float subtotal)
        {
            this.Venta = venta;
            this.Articulo = articulo;
            this.Cantidad = cantidad;
            this.Subtotal = subtotal;
        }

       
    }
    

}
