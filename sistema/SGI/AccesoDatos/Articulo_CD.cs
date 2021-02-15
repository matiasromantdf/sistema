using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class Articulo_CD

    {
        string cod_articulo;
        int id_proveedor_articulos;
        string descr_articulo;
        float costo_articulo;
        float precio_articulo;
        float iva;
        int stock_articulo;
        int reposicion_articulo;
        

        public Articulo_CD(string cod_articulo, int id_proveedor_articulos, string descr_articulo, float costo_articulo, float precio_articulo, float iva, int stock_articulo, int reposicion_articulo)
        {
            this.cod_articulo = cod_articulo;
            this.id_proveedor_articulos = id_proveedor_articulos;
            this.descr_articulo = descr_articulo;
            this.costo_articulo = costo_articulo;
            this.precio_articulo = precio_articulo;
            this.iva = iva;
            this.stock_articulo = stock_articulo;
            this.reposicion_articulo = reposicion_articulo;
            
        }

        public string Cod_articulo { get => cod_articulo; set => cod_articulo = value; }
        public int Id_proveedor_articulos { get => id_proveedor_articulos; set => id_proveedor_articulos = value; }
        public string Descr_articulo { get => descr_articulo; set => descr_articulo = value; }
        public float Costo_articulo { get => costo_articulo; set => costo_articulo = value; }
        public float Precio_articulo { get => precio_articulo; set => precio_articulo = value; }
        public float Iva { get => iva; set => iva = value; }
        public int Stock_articulo { get => stock_articulo; set => stock_articulo = value; }
        public int Reposicion_articulo { get => reposicion_articulo; set => reposicion_articulo = value; }
       

        public string InsertarNuevoArticulo()
        {
            Conexion con = new Conexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = con.conectar();
            comando.CommandText = "insert into articulos" +
                    "(cod_articulo,id_proveedor,descr_articulo,costo_articulo,precio_articulo,iva,stock_articulo,reposicion_articulo)" +
                    " values(@cod,@proveedor,@descr,@costo,@precio,@iva,@stock,@reposicion)";
            comando.Parameters.Add("@cod", SqlDbType.VarChar);
            comando.Parameters.Add("@proveedor", SqlDbType.Int);
            comando.Parameters.Add("@descr", SqlDbType.VarChar);
            comando.Parameters.Add("@costo", SqlDbType.Decimal);
            comando.Parameters.Add("@precio", SqlDbType.Decimal);
            comando.Parameters.Add("@iva", SqlDbType.Decimal);
            comando.Parameters.Add("@stock", SqlDbType.Int);            
            comando.Parameters.Add("@reposicion", SqlDbType.Int);

            comando.Parameters["@cod"].Value = cod_articulo;
            comando.Parameters["@proveedor"].Value = id_proveedor_articulos;
            comando.Parameters["@descr"].Value = descr_articulo;
            comando.Parameters["@costo"].Value = costo_articulo;
            comando.Parameters["@precio"].Value = precio_articulo;
            comando.Parameters["@iva"].Value = iva;
            comando.Parameters["@stock"].Value = stock_articulo;            
            comando.Parameters["@reposicion"].Value = reposicion_articulo;

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
