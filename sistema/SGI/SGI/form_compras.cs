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
    public partial class form_compras : Form
    {
        Nproveedor proveedor;
        public form_compras()
        {
            InitializeComponent();
        }

        private void form_compras_Load(object sender, EventArgs e)
        {
            proveedor = new Nproveedor();
            DataTable datos = proveedor.ObtenerTodos();
            combo_proveedor.DataSource = datos;
            combo_proveedor.DisplayMember = "nombre_proveedor";
            combo_proveedor.ValueMember = "id_proveedor";
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            form_busquedaPorNombre f = new form_busquedaPorNombre("compras");
            AddOwnedForm(f);
            f.ShowDialog();
            txt_codigo.Focus();
        }

        private void lbl_nombre_Click(object sender, EventArgs e)
        {

        }

        private void txt_codigo_Leave(object sender, EventArgs e)
        {
            CapaNegocio.Narticulo articulo = new CapaNegocio.Narticulo();
            if (txt_codigo.Text != "" && articulo.Existe(txt_codigo.Text))
            {              

                if (articulo.Existe(txt_codigo.Text))
                {
                    lbl_nombre.Text = articulo.obtenerDescripcion(txt_codigo.Text);
                    lbl_precio.Text = Convert.ToString(articulo.obtenerPrecio(txt_codigo.Text));
                    lbl_costo.Text = Convert.ToString(articulo.obtenerCosto(txt_codigo.Text));
                    lbl_stock.Text = Convert.ToString(articulo.obtenerStock(txt_codigo.Text));

                }
                else
                {
                    MessageBox.Show("No existe artículo con ése Código");
                    txt_codigo.Focus();
                }
            }

            else
            {
                MessageBox.Show("No existe ése artículo");
            }

        }
    }
}
