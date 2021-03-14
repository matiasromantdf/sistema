using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGI
{
    public partial class form_busquedaPorNombre : Form
    {
        
        public form_busquedaPorNombre()
        {
            InitializeComponent();
        }

      

        private void form_busqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

      

        private void txt_busqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                trasladar();
            }

        }

        private void form_busqueda_Load(object sender, EventArgs e)
        {
                     

        }

        private void txt_busqueda_TextChanged(object sender, EventArgs e)
        {
            DataTable resultadosDeBusqueda;
            CapaNegocio.Narticulo articulo = new CapaNegocio.Narticulo();
            resultadosDeBusqueda = articulo.buscarPorNombre("%" + txt_busqueda.Text + "%");
            data_grid_resultados.DataSource = resultadosDeBusqueda;
            data_grid_resultados.Columns[1].Width = 200;
        }
        private void trasladar()
        {
            form_ventas padre = Owner as form_ventas;
            padre.txt_codigo.Text = data_grid_resultados.CurrentRow.Cells[0].Value.ToString();
            this.Close();
            padre.txt_codigo.Focus();
        }
        private void data_grid_resultados_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode==Keys.Enter)
            {
                trasladar();
            }
        }

   
        private void data_grid_resultados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            trasladar();
        }
    }
}
