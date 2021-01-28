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
    public partial class form_ventas : Form
    {
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
            MessageBox.Show("hoahsdoas");
        }
    }
}
