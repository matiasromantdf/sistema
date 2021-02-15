using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;



namespace CapaNegocio
{
   
    public class Articulo_CN

    {
        Articulo_CD artcapadatos;


        public string insertar(string codigo,string proveedor, string descripcion,string costo, string precio, string iva,string stock, string reposicion)
        {
            int _proveedor= Convert.ToInt32(proveedor);
            float _costo = float.Parse(costo);
            float _precio = float.Parse(precio);
            float _iva = float.Parse(iva);
            int _stock = Convert.ToInt32(stock);
            int _reposicion = Convert.ToInt32(reposicion);

            artcapadatos = new Articulo_CD(codigo, _proveedor, descripcion, _costo,_precio, _iva, _stock, _reposicion);
            return artcapadatos.InsertarNuevoArticulo();
        }
    }
    
}
