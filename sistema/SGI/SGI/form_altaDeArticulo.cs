using System.Data;
using System.Windows.Forms;
using CapaNegocio;


namespace SGI
{
    
    public partial class form_altaDeArticulo : Form
    {
        Narticulo articulo;
        Nproveedor proveedor;
        
        
        public form_altaDeArticulo()
        {
            
            InitializeComponent();
        }

        private void form_altaDeArticulo_Load(object sender, System.EventArgs e)
        {
            proveedor = new Nproveedor();
            DataTable datos = proveedor.ObtenerTodos();
            combo_proveedor.DataSource = datos;
            combo_proveedor.DisplayMember = "nombre_proveedor";
            combo_proveedor.ValueMember = "id_proveedor";
                
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            articulo = new Narticulo();
           
            string respuesta=
            articulo.Nuevo(
                txt_cod.Text,
                combo_proveedor.SelectedValue.ToString(),
                txt_descripcion.Text,
                txt_costo.Text,
                txt_precio.Text,
                txt_iva.Text);
            MessageBox.Show(respuesta);
                
        }
    }
}
