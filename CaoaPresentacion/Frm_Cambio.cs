using System;
using System.Windows.Forms;

namespace CaoaPresentacion
{
    public partial class Frm_Cambio : Form
    {
        public Frm_Cambio()
        {
            InitializeComponent();
        }

        private void Frm_Cambio_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtsubtotal.Text = CacheReferencia.Subtotal;
                this.txtDescuento.Text = CacheReferencia.Descuento;
                this.txtIva.Text = CacheReferencia.Iva;
                this.txtTotal.Text = CacheReferencia.Total;
                this.txtPagoCon.Text = CacheReferencia.PagoCon;
                this.txtCambio.Text = CacheReferencia.Cambio;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema " + ex);
            }
        }
    }
}
