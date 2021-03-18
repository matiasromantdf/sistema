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
        Nproveedor Prove;
        Ncompra compra = new Ncompra();
        public form_compras()
        {
            InitializeComponent();
        }

        private void form_compras_Load(object sender, EventArgs e)
        {
            txt_fecha.Text = Convert.ToString(DateTime.Today.ToShortDateString());
            Prove = new Nproveedor();
            DataTable datos = Prove.ObtenerTodos();
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

        private void button2_Click(object sender, EventArgs e)//nuevo Articulo
        {
            form_altaDeArticulo f = new form_altaDeArticulo();
            f.ShowDialog();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txt_cc.Text!="")
            {
                MessageBox.Show(Prove.IncrementarDeuda((int)combo_proveedor.SelectedValue, Convert.ToInt32(txt_cc.Text)));
                               
            }
        }

        private void btn_agregarDetalle_Click(object sender, EventArgs e)
        {
            /* el metodo AgregarDetalle recibe strings y luego
             * los convierte para crear un nuevo objeto DetalleCompra 
             * de la capa Datos
             */
            compra.AgregarAlDetalle(
                txt_codigo.Text,
                txt_cantidad.Text,
                txt_costo.Text,
                txt_precio.Text
                );           
            LlenarDGV();

        }
        private void LlenarDGV()
        {
            DataTable tablaDetalle = compra.ObtenerTablaDetalle();
            dgv_detalle.Rows.Clear();
            foreach (DataRow fila in tablaDetalle.Rows)
            {
                dgv_detalle.Rows.Add(
                    fila["codigo"],
                    fila["nombre"],
                    fila["cantidad"],
                    fila["costo"],
                    fila["precio"],
                    fila["subtotal"]
                    );
            }            
        }
    }
}
