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
    public partial class principal : Form
    {
        public principal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form_ventas form_Ventas = new form_ventas();
          
            form_Ventas.ShowDialog();
        }

        private void venderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_ventas form_Ventas = new form_ventas();

            form_Ventas.ShowDialog();
        }

        private void altaNuevoArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_altaDeArticulo f = new form_altaDeArticulo();
            f.Show();
        }

        private void eliminarArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_eliminarArticulo f = new form_eliminarArticulo();
            f.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void altaNuevoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_nuevoProveedor f = new form_nuevoProveedor();
            f.Show();
        }

        private void registraPagoAProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
