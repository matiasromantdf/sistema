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
        int idVenta {set;get;}
        DateTime fechaVenta { set; get; }
        float costo { set; get; }
        float bruto { set; get; }
        List  <DetalleVenta> detalle= new List<DetalleVenta>();

        public Venta()
        {
        }
        public void AgregarDetalle(DetalleVenta det)
        {
            detalle.Add(det);
        }
        public Venta(int idVenta, DateTime fechaVenta, float costo, float bruto, List<DetalleVenta> detalle)
        {
            this.idVenta = idVenta;
            this.fechaVenta = fechaVenta;
            this.costo = costo;
            this.bruto = bruto;
            this.detalle = detalle;
        }
        public int mostrarUltId()
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
