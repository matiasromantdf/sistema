using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Proveedor
    {
        int id_proveedor;
        float cc_proveedor;
        string nombre_proveedor;
        string telefono_proveedor;

        public Proveedor()
        {
        }

        public Proveedor(int id_proveedor, float cc_proveedor, string nombre_proveedor)
        {
            this.Id_proveedor = id_proveedor;
            this.Cc_proveedor = cc_proveedor;
            this.Nombre_proveedor = nombre_proveedor;
        }

        public string NuevoProveedor(string nombre, string tel)
        {
            Conexion con = new Conexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = con.conectar();
            comando.CommandText = "insert into proveedores " +
                "(cc_proveedor,nombre_proveedor,telefono_proveedor) values(@cc,@nombre,@tel)";
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);            
            comando.Parameters.Add("@cc", SqlDbType.Decimal);
            comando.Parameters.Add("@tel", SqlDbType.VarChar);


            comando.Parameters["@nombre"].Value = nombre;
            comando.Parameters["@cc"].Value = 0;
            comando.Parameters["@tel"].Value = tel;


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

        public string AumentarDeudaCC(float monto, int id)
        {
            Conexion con = new Conexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = con.conectar();
            comando.CommandText = "update proveedores set cc_proveedor=ccproveedor-@monto where id_proveedor = @id";
            comando.Parameters.Add("@monto", SqlDbType.Decimal);
            comando.Parameters.Add("@id", SqlDbType.Int);

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
        public string DisminuirDeudaCC(float monto, int id)
        {
            Conexion con = new Conexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = con.conectar();
            comando.CommandText = "update proveedores set cc_proveedor=ccproveedor+@monto where id_proveedor = @id";
            comando.Parameters.Add("@monto", SqlDbType.Decimal);
            comando.Parameters.Add("@id", SqlDbType.Int);

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
        public int Id_proveedor { get => id_proveedor; set => id_proveedor = value; }
        public float Cc_proveedor { get => cc_proveedor; set => cc_proveedor = value; }
        public string Nombre_proveedor { get => nombre_proveedor; set => nombre_proveedor = value; }
        public string Telefono_proveedor { get => telefono_proveedor; set => telefono_proveedor = value; }
    }
}
