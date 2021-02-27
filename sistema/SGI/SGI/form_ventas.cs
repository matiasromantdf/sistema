using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
namespace SGI

{
    public partial class form_ventas : Form
    {
        CapaNegocio.Venta_CN ObjVenta_CN = new CapaNegocio.Venta_CN();
        
        public form_ventas()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
                  {
                     e.Handled = true;
                     SendKeys.Send("{TAB}");
                  }
           
        }

        private void txt_cant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void btn_agregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                btn_agregar_Click(this, e);
            }
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            CapaNegocio.Articulo_CN ObjArticulo_CN = new Articulo_CN();
            float precio = ObjArticulo_CN.obtenerPrecio(txt_codigo.Text);            
            string descripcion = ObjArticulo_CN.obtenerDescripcion(txt_codigo.Text);
            int cantidad = Convert.ToInt32(txt_cant.Text);
            float iva = ((precio*cantidad)/100)*ObjArticulo_CN.ObtenerIva(txt_codigo.Text);
            float subtotal = (cantidad * precio)+iva;

            datagrid_detalle.Rows.Add(
               txt_codigo.Text,
               descripcion,
               cantidad,
               precio,
               iva,
               subtotal
                );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form_busquedaPorNombre f = new form_busquedaPorNombre();
            AddOwnedForm(f);
            f.ShowDialog();
            txt_codigo.Focus();
        }

        private void txt_codigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                form_busquedaPorNombre f = new form_busquedaPorNombre();
                AddOwnedForm(f);
                f.ShowDialog();
                txt_codigo.Focus();
            }
        }

        private void form_ventas_Load(object sender, EventArgs e)
        {
          
            int numeroVenta = ObjVenta_CN.mostrarUltID();
            txt_num_venta.Text = Convert.ToString(numeroVenta+1);
            
        }

        private void txt_codigo_Leave(object sender, EventArgs e)
        {
            if (txt_codigo.Text!="")
            {
                CapaNegocio.Articulo_CN ObjArticulo_CN = new CapaNegocio.Articulo_CN();
            
            
            if (ObjArticulo_CN.Existe(txt_codigo.Text))
            {
                lbl_NombreDeArt.Text = ObjArticulo_CN.obtenerDescripcion(txt_codigo.Text);
                lbl_Precio.Text = Convert.ToString(ObjArticulo_CN.obtenerPrecio(txt_codigo.Text));
            }
            else
            {
                MessageBox.Show("No existe artículo con ése Código");
                txt_codigo.Focus();
            }
            }


        }

        private void form_ventas_Enter(object sender, EventArgs e)
        {
          
        }
    }
}
