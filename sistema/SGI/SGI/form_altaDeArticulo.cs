using System.Windows.Forms;
using CapaNegocio;


namespace SGI
{
    
    public partial class form_altaDeArticulo : Form
    {
        Articulo_CN articulo;
        
        public form_altaDeArticulo()
        {
            
            InitializeComponent();
        }

        private void form_altaDeArticulo_Load(object sender, System.EventArgs e)
        {

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            articulo = new Articulo_CN();
           
            string respuesta=
            articulo.nuevo(
                txt_cod.Text,
                txt_prov.Text,
                txt_descripcion.Text,
                txt_costo.Text,
                txt_precio.Text,
                txt_iva.Text,
                txt_stock.Text,
                txt_repo.Text);
            MessageBox.Show(respuesta);
                
        }
    }
}
