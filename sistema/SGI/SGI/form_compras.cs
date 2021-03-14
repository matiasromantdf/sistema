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
    }
}
