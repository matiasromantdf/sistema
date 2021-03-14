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
    public partial class form_eliminarArticulo : Form
    {
        public form_eliminarArticulo()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Narticulo objArticulo_CN = new Narticulo();
            MessageBox.Show(objArticulo_CN.eliminar(txt_codEliminar.Text));
        }

        private void txt_codEliminar_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void form_eliminarArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                form_busquedaPorNombre f = new form_busquedaPorNombre();
                f.ShowDialog();
            }
        }

        private void txt_codEliminar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                form_busquedaPorNombre f = new form_busquedaPorNombre();
                f.ShowDialog();
            }
        }

        private void form_eliminarArticulo_Load(object sender, EventArgs e)
        {

        }
    }
}
