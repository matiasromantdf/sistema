using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public Compra()
        {
            Id_compra = MostrarUltIdCompra() + 1;
        }
        public int MostrarUltIdCompra()
        {
            Conexion con = new Conexion();
            SqlCommand comando = new SqlCommand("select top 1 id_compra from compra order by id_compra desc");
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
        public Compra(int id_proveedor, string num_factura, DateTime fecha_compra, float monto_compra, float iva_compra)
        {
            Id_proveedor = id_proveedor;
            Num_factura = num_factura;
            Fecha_compra = fecha_compra;
            Monto_compra = monto_compra;
            Iva_compra = iva_compra;
        }
    }
}
