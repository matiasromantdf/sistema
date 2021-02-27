using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CapaDatos
{
    public class Conexion
    {
        SqlConnection ObjConexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString);

        public SqlConnection conectar()
        {
            ObjConexion.Open();
            return ObjConexion;
            
        }
        public void cerrarConexion()
        {
            
            ObjConexion.Close();
           
        }
        
    }
    
}
