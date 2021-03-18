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
        public int Id_proveedor { set; get; }
        public float Cc_proveedor { set; get; }
        public string Nombre_proveedor { set; get; }
        public string Telefono_proveedor { set; get; }
        public string Cuit_proveedor { get; set; }

        public Proveedor()
        {
        }
        public Proveedor Listar(int id_prov)
        {
            Conexion con = new Conexion();
            SqlCommand seleccionar = new SqlCommand("select " +
                "id_proveedor," +
                "cc_proveedor," +
                "nombre_proveedor," +
                "telefono_proveedor," +
                "cuit_proveedor from proveedores where id_proveedor = @cod");
            seleccionar.Parameters.AddWithValue("@cod", id_prov);
            seleccionar.Connection = con.conectar();
            SqlDataReader leer;
            leer = seleccionar.ExecuteReader();
           
            if (leer.HasRows)
            {
                leer.Read();

                Id_proveedor = id_prov;
                Cc_proveedor = (float)leer.GetDecimal(1);
                Nombre_proveedor = leer.GetString(2);
                Telefono_proveedor = leer.GetString(3);
                Cuit_proveedor = leer.GetString(4);
            }
            else
            {
               return null;
            }
            return this;

        }
        public Proveedor(int id_proveedor, float cc_proveedor, string nombre_proveedor)
        {
            this.Id_proveedor = id_proveedor;
            this.Cc_proveedor = cc_proveedor;
            this.Nombre_proveedor = nombre_proveedor;
        }


        public string NuevoProveedor(string nombre, string tel, string cuit)
        {
            Conexion con = new Conexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = con.conectar();
            comando.CommandText = "insert into proveedores " +
                "(cc_proveedor,nombre_proveedor,telefono_proveedor) values(@cc,@nombre,@tel)";
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@cc", SqlDbType.Decimal);
            comando.Parameters.Add("@tel", SqlDbType.VarChar);
            comando.Parameters.Add("@cuit", SqlDbType.VarChar);


            comando.Parameters["@nombre"].Value = nombre;
            comando.Parameters["@cc"].Value = 0;
            comando.Parameters["@tel"].Value = tel;
            comando.Parameters["@cuit"].Value = cuit;


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
        public DataTable ObtenerTodos()
        {
            DataTable tablaResultados = new DataTable();

            Conexion con = new Conexion();
            SqlCommand select = new SqlCommand("select * from proveedores");
            select.Connection = con.conectar();           
            SqlDataAdapter adp = new SqlDataAdapter(select);
            adp.Fill(tablaResultados);
            return tablaResultados;
        }
        public string ActualizarCC(float monto, int id)
        {
            Conexion con = new Conexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = con.conectar();
            comando.CommandText = "update proveedores set cc_proveedor=cc_proveedor+@monto where id_proveedor = @id";
            comando.Parameters.Add("@monto", SqlDbType.Decimal);
            comando.Parameters.Add("@id", SqlDbType.Int);

            comando.Parameters["@monto"].Value = monto;
            comando.Parameters["@id"].Value = id;


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
