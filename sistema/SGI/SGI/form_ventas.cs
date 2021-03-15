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
        CapaNegocio.Nventa nventa = new CapaNegocio.Nventa();
       
        public void Inicializar() {
            
        }
        
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
       
        private void btn_agregar_Click(object sender, EventArgs e)//boton de agragar a detalle. veirifica primero si el item ya existe
        {
            if (txt_codigo.Text != "")
            {
                nventa.AgregarItem(txt_codigo.Text, Convert.ToInt32(txt_cant.Text));
                LlenarDGV();                
            }
        }
        private void LlenarDGV()
        {         
             DataTable tablaDetalleVenta = nventa.TablaDetalle();
             datagrid_detalle.Rows.Clear();
             foreach (DataRow fila in tablaDetalleVenta.Rows)
             {
                 datagrid_detalle.Rows.Add(
                     fila["codigo"],
                     fila["nombre"],
                     fila["cantidad"],
                     fila["precio"],
                     fila["iva"],
                     fila["subtotal"]
                     );
             }
            ActualizarTotal();
        }
        private void button1_Click(object sender, EventArgs e)//boton de busqueda por nombre
        {
            BuscarPorNombre();
        }
        private void BuscarPorNombre()
        {
            
            form_busquedaPorNombre f = new form_busquedaPorNombre("ventas");
            AddOwnedForm(f);
            f.ShowDialog();
            txt_codigo.Focus();
        }
        private void txt_codigo_KeyDown(object sender, KeyEventArgs e)//evento tecla f2 para buscar por nombre
        {
            if (e.KeyCode == Keys.F2)
            {
                BuscarPorNombre();
            }
        }

        private void form_ventas_Load(object sender, EventArgs e)// carga el numero de venta segun la ultima venta grabada en la bd
        {
            txt_num_venta.Text = Convert.ToString(nventa.Id);
            fecha.Value = nventa.Fecha;
            
        }

        private void txt_codigo_Leave(object sender, EventArgs e)
        {
            if (txt_codigo.Text!="")
            {
                CapaNegocio.Narticulo ObjArticulo_CN = new CapaNegocio.Narticulo();            
            
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

        private void datagrid_detalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            /*luego de modificar cantidad en el 
            DGV se actualiza el objeto en capa negocio, luego se actualiza el DGV
            */
        {
            if (e.RowIndex > -1)
            {
                if (Convert.ToInt32(datagrid_detalle.Rows[e.RowIndex].Cells["cantidad"].Value) < 1)
                {
                    nventa.EliminarItem(e.RowIndex);
                    LlenarDGV();
                    txt_codigo.Focus();
                }
                else
                {
                    nventa.CambiarCantidadDetalle(e.RowIndex, Convert.ToInt32(datagrid_detalle.Rows[e.RowIndex].Cells["cantidad"].Value));
                    LlenarDGV();
                    txt_codigo.Focus();
                }
            }
            ActualizarTotal();
        }

        private void ActualizarTotal()
        {
            nventa.CalcularBrutoyCosto();
            txt_total.Text = Convert.ToString(nventa.Total);
        }
        
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(nventa.ProcesarVenta());
            this.Close();
        }
    }
}
