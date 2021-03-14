using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Venta
    {
        public int IdVenta { set; get; }
        public DateTime FechaVenta { set; get; }
        public float Costo { set; get; }
        public float Bruto { set; get; }
        public float Iva { set; get; }




        public Venta()
        {
            IdVenta = MostrarUltIdVenta() + 1;
            FechaVenta = DateTime.Now;
            Bruto = 0;
            Costo = 0;
        }
              
     
        public string Registrar()
        {
            Conexion con = new Conexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = con.conectar();
            comando.CommandText = "Insert into ventas(fecha_venta,costo_venta,monto_venta,iva_venta) values(@fecha,@costo,@monto,@iva)";
            comando.Parameters.Add("@fecha", SqlDbType.Date);
            comando.Parameters.Add("@costo", SqlDbType.Decimal);
            comando.Parameters.Add("@monto", SqlDbType.Decimal);
            comando.Parameters.Add("@iva", SqlDbType.Decimal);

            comando.Parameters["@fecha"].Value = this.FechaVenta;
            comando.Parameters["@costo"].Value = (this.Costo);
            comando.Parameters["@monto"].Value = (this.Bruto);
            comando.Parameters["@iva"].Value = (this.Iva);

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
        public int MostrarUltIdVenta()
        {
            Conexion con = new Conexion();
            SqlCommand comando = new SqlCommand("select top 1 id_venta from ventas order by id_venta desc");
            comando.Connection = con.conectar();
            SqlDataReader leer;
            leer = comando.ExecuteReader();
            if (leer.HasRows)
            {
                leer.Read();
                int ultimoID = leer.GetInt32(0);
                return ultimoID;
            }
            else
            {
                return 0;
            }
            
        }
    }
}
