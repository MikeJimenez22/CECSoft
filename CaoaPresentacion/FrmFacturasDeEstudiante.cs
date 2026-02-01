using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CaoaPresentacion
{
    public partial class FrmFacturasDeEstudiante : Form
    {
        string Estado;


        public FrmFacturasDeEstudiante()
        {
            InitializeComponent();
            this.cmbBusquedas.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 1;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (this.cmbBusquedas.Text == "Carnet")
            {
                this.MostrarPorCarnet();

            }
            else if (this.cmbBusquedas.Text == "Nombres")
            {
                this.MostrarPorNombre();

            }
            else if (this.cmbBusquedas.Text == "Apellidos")
            {
                this.MostrarPorApellidos();

            }
        }


        public void MostrarPorCarnet()
        {
            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            this.dataEstudiantes.DataSource = objetoCN.MostrarPorCarnet(this.txtbusqueda.Text, Estado);

        }
        private void MostrarPorNombre()
        {
            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            this.dataEstudiantes.DataSource = objetoCN.MostrarPorNombre(this.txtbusqueda.Text, Estado);

        }


        private void MostrarPorApellidos()
        {
            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            this.dataEstudiantes.DataSource = objetoCN.MostrarPorApellidos(this.txtbusqueda.Text, Estado);

        }


        private void FrmFacturasDeEstudiante_Load(object sender, EventArgs e)
        {
            try
            {
                this.cmbBusquedas.Text = "Apellidos";
                this.radioButton6.Checked = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarFacturasCompletadas()
        {
            CN_Factura objetoCN = new CN_Factura();
            this.datafactura.DataSource = objetoCN.MostrarFacturasCompletadasestudiante(this.txtcarnetestudiantil.Text);
        }

        private void MostrarFacturaDetalle(string NumeroFactura)
        {
            CN_Factura objetoCN = new CN_Factura();
            this.dataDetalles.DataSource = objetoCN.MostrarFacturaDetalle(NumeroFactura);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            this.Estado = "3";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            this.Estado = "4";
        }

        private void dataEstudiantes_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtnombres.Text = this.dataEstudiantes.CurrentRow.Cells["Nombres"].Value.ToString();
                this.txtapellidos.Text = this.dataEstudiantes.CurrentRow.Cells["Apellidos"].Value.ToString();
                this.txtcarnetestudiantil.Text = this.dataEstudiantes.CurrentRow.Cells["Carnet Estudiantil"].Value.ToString();


                this.tabControl1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtcarnetestudiantil_TextChanged(object sender, EventArgs e)
        {
            this.MostrarFacturasCompletadas();
        }

        private void datafactura_Click(object sender, EventArgs e)
        {
            try
            {
                string NumFactura = this.datafactura.CurrentRow.Cells["Num_Factura"].Value.ToString();
                this.MostrarFacturaDetalle(NumFactura);

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
