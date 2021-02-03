using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace AccesoDatos
{
    public class Conexion
    {
       SqlConnection conectar= new SqlConnection("Data Source=NOTEBOOKPAPI\\SQLEXPRESS;" +
                "Initial Catalog=ABM_complejo;" +
                "Integrated Security = True" +
                "");
    }
    public class Articulo
    {
        string cod_articulo;
        int id_proveedor_articulos;
        string descr_articulo;
        float costo_articulo;
        float precio_articulo;
        float iva;
        int stock_articulo;
        int reposicion_articulo;
        string unidad_medida;


    }
    public class Caja
    {

    }
    public class Ventas
    {

    }

}
