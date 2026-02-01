using System;
using System.Windows.Forms;

namespace CaoaPresentacion
{
    public partial class Frm_VerificacionReferencia : Form
    {
        public Frm_VerificacionReferencia()
        {
            InitializeComponent();
        }

        private void Frm_VerificacionReferencia_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtNReferencia.Text = CacheReferencia.NReferencia;
                this.txtTipo.Text = CacheReferencia.Tipo;
                this.txtEstudiante.Text = CacheReferencia.Estudiante;
                this.txtCodigoCarnet.Text = CacheReferencia.Carnet;
                this.txtNFactura.Text = CacheReferencia.Factura;
                this.txtFechaRegistro.Text = Convert.ToDateTime(CacheReferencia.FechaRegistro).ToShortDateString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema " + ex);
            }
        }
    }
}
