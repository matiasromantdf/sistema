﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
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

        public string Cod_articulo { get => cod_articulo; set => cod_articulo = value; }
        public int Id_proveedor_articulos { get => id_proveedor_articulos; set => id_proveedor_articulos = value; }
        public string Descr_articulo { get => descr_articulo; set => descr_articulo = value; }
        public float Costo_articulo { get => costo_articulo; set => costo_articulo = value; }
        public float Precio_articulo { get => precio_articulo; set => precio_articulo = value; }
        public float Iva { get => iva; set => iva = value; }
        public int Stock_articulo { get => stock_articulo; set => stock_articulo = value; }
        public int Reposicion_articulo { get => reposicion_articulo; set => reposicion_articulo = value; }

        public Articulo(string cod_articulo, int id_proveedor_articulos, string descr_articulo, float costo_articulo, float precio_articulo, float iva, int stock_articulo, int reposicion_articulo)
        {
            this.Cod_articulo = cod_articulo;
            this.Id_proveedor_articulos = id_proveedor_articulos;
            this.Descr_articulo = descr_articulo;
            this.Costo_articulo = costo_articulo;
            this.Precio_articulo = precio_articulo;
            this.Iva = iva;
            this.Stock_articulo = stock_articulo;
            this.Reposicion_articulo = reposicion_articulo;
            
        }
        public Articulo() { }


        public string Nuevo(string cod_articulo, int id_proveedor_articulos, string descr_articulo, float costo_articulo, float precio_articulo, float iva, int stock_articulo, int reposicion_articulo)
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

        public string Eliminar(string cod)
        {
            Conexion con = new Conexion();
            SqlCommand eliminar = new SqlCommand("delete from ARTICULOS where cod_articulo = @cod");
            eliminar.Connection= con.conectar();
            eliminar.Parameters.AddWithValue("@cod", cod);
           
            try
            {  eliminar.ExecuteNonQuery();
               return "eliminado con éxito";
              
            }
            catch (Exception e)
            {

                return e.Message;
            }
            

        }
        public DataTable BuscarPorNombre(string texto)
        {
            DataTable tablaResultados = new DataTable();
            
            Conexion con = new Conexion();
            SqlCommand select = new SqlCommand("select top 5 cod_articulo,descr_articulo,precio_articulo from articulos where descr_articulo like @texto");
            select.Connection = con.conectar();
            select.Parameters.AddWithValue("@texto", texto);
            SqlDataAdapter adp = new SqlDataAdapter(select);
            adp.Fill(tablaResultados);
            return tablaResultados;
        }
        public bool Existe(string cod)
        {
            Conexion con = new Conexion();
            SqlCommand seleccionar = new SqlCommand("select count(*) from ARTICULOS where cod_articulo = @cod");
            seleccionar.Connection = con.conectar();
            seleccionar.Parameters.AddWithValue("@cod", cod);
            SqlDataReader leer;
            leer = seleccionar.ExecuteReader();

            if (leer.HasRows)
            {
                leer.Read();
                if (leer.GetInt32(0) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public Articulo Listar(string cod)
        {
            Conexion con = new Conexion();
            SqlCommand seleccionar = new SqlCommand("select " +
                "cod_articulo," +
                "id_proveedor," +
                "descr_articulo," +
                "costo_articulo," +
                "precio_articulo," +
                "stock_articulo," +
                "reposicion_articulo," +
                "iva from ARTICULOS where cod_articulo = @cod");
            seleccionar.Parameters.AddWithValue("@cod", cod);
            seleccionar.Connection = con.conectar();
            SqlDataReader leer;
            leer = seleccionar.ExecuteReader();
            Articulo articulo = new Articulo();
            if (leer.HasRows)
             {               
                leer.Read();
                articulo.Cod_articulo = cod;
                articulo.id_proveedor_articulos = leer.GetInt32(1);
                articulo.Descr_articulo = leer.GetString(2);
                articulo.Costo_articulo = (float)leer.GetDecimal(3);
                articulo.Precio_articulo = (float)leer.GetDecimal(4);
                articulo.Stock_articulo = leer.GetInt32(5);
                articulo.Reposicion_articulo = leer.GetInt32(6);
                articulo.Iva = (float)leer.GetDecimal(7);
            }
            else
            {
                articulo = null;
            }
            return articulo;
        }

    }
  
}