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
    public partial class form_nuevoProveedor : Form
    {
        public form_nuevoProveedor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Proveedor_CN prov = new Proveedor_CN();
            string resultado = prov.NuevoProveedor(txt_nombreProv.Text,txt_nombreProv.Text);
            MessageBox.Show(resultado);
        }
    }
}
