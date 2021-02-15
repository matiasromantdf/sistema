using System.Windows.Forms;
using CapaNegocio;


namespace SGI
{
    
    public partial class form_altaDeArticulo : Form
    {
        Articulo_CN obj_cn_articulo;
        
        public form_altaDeArticulo()
        {
            
            InitializeComponent();
        }

        private void form_altaDeArticulo_Load(object sender, System.EventArgs e)
        {

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            obj_cn_articulo = new Articulo_CN();
            MessageBox.Show(
            obj_cn_articulo.insertar(
                txt_cod.Text,
                txt_prov.Text,
                txt_descripcion.Text,
                txt_costo.Text,
                txt_precio.Text,
                txt_iva.Text,
                txt_stock.Text,
                txt_repo.Text));
                
        }
    }
}
