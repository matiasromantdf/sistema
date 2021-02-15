using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class Conexion
    {
        private SqlConnection ObjConexion = new SqlConnection("Data Source=NOTEBOOKPAPI\\SQLEXPRESS;" +
               "Initial Catalog=sistema;" +
               "Integrated Security = True" +
               "");

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
