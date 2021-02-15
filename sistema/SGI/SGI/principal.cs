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
    }
}
