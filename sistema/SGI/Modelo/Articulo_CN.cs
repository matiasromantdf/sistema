using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;



namespace CapaNegocio
{
   
    public class Articulo_CN

    {
        Articulo ObjArticulo_CD = new CapaDatos.Articulo();


        public string nuevo(string codigo,string proveedor, string descripcion,string costo, string precio, string iva,string stock, string reposicion)
        {
            int _proveedor= Convert.ToInt32(proveedor);
            float _costo = float.Parse(costo);
            float _precio = float.Parse(precio);
            float _iva = float.Parse(iva);
            int _stock = Convert.ToInt32(stock);
            int _reposicion = Convert.ToInt32(reposicion);

            string respuesta= ObjArticulo_CD.Nuevo(codigo, _proveedor, descripcion, _costo, _precio, _iva, _stock, _reposicion);
            return respuesta;
        }
       public DataTable buscarPorNombre(string texto)
        {
           
            DataTable tabla = ObjArticulo_CD.BuscarPorNombre("%"+texto+"%");
            return tabla;
        }
        public bool Existe(string cod)
        {
            CapaDatos.Articulo articulo = new Articulo();
            if (articulo.Existe(cod))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string obtenerDescripcion(string cod)
        {
            
            return ObjArticulo_CD.Listar(cod).Descr_articulo;

        }
        public float obtenerPrecio(string cod)
        {                      
            
           return ObjArticulo_CD.Listar(cod).Precio_articulo;
           
        }
        public float ObtenerIva(string cod)
        {
            return ObjArticulo_CD.Listar(cod).Iva;
        }
        public string eliminar(string cod)
        {
            
            
            if (ObjArticulo_CD.Existe(cod))
            {
              return
              ObjArticulo_CD.Eliminar(cod);
            }
            else
            {
                return
                "el articulo no existe";
            }
            
        }
    }
    
}
