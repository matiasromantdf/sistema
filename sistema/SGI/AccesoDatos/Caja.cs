using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
   public class Caja
    {
        public float ImporteCaja { get; set; }
        public float ImporteCosto { get; set; }
        public float ImporteGanancia { get; set; }
        public float Iva { get; set; }

        public Caja() { }

        public string RegistrarCaja(float monto)
        {
            Conexion con = new Conexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = con.conectar();
            comando.CommandText = "update caja " +
                "set actual_caja=actual_caja+@monto";
            comando.Parameters.Add("@monto", SqlDbType.Decimal); 
            comando.Parameters["@monto"].Value = monto;
         
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

        public string RegistrarCosto(float monto)
        {
            Conexion con = new Conexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = con.conectar();
            comando.CommandText = "update caja " +
                "set actual_costo=actual_costo+@monto";
            comando.Parameters.Add("@monto", SqlDbType.Decimal);

            comando.Parameters["@monto"].Value = monto;

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

        public string RegistrarGanancia(float monto)
        {
            Conexion con = new Conexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = con.conectar();
            comando.CommandText = "update caja " +
                "set actual_ganancia=actual_ganancia+@monto";
            comando.Parameters.Add("@monto", SqlDbType.Decimal);

            comando.Parameters["@monto"].Value = monto;

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
        public string RegistrarIva(float monto)
        {
            Conexion con = new Conexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = con.conectar();
            comando.CommandText = "update caja " +
                "set iva=iva+@monto";
            comando.Parameters.Add("@monto", SqlDbType.Decimal);
            comando.Parameters["@monto"].Value = monto;

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

    }
}
