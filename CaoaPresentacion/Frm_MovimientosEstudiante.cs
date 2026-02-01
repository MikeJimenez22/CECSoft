using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CaoaPresentacion
{
    public partial class Frm_MovimientosEstudiante : Form
    {
        public Frm_MovimientosEstudiante()
        {
            InitializeComponent();
        }

        private void Frm_MovimientosEstudiante_Load(object sender, EventArgs e)
        {
            try
            {
                this.label2.Text = CacheMovimientoEstudiante.TipoMovimiento;
                this.textBox1.Text = CacheMovimientoEstudiante.IdMatricula;
                this.RealizarBusqueda(this.label2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ContarFilas()
        {
            try
            {
                int valor = this.dataGridView1.Rows.Count;
                if (valor == 0)
                {
                    this.label3.Text = "No se encontraron Registros";
                }
                else
                {
                    this.label3.Text = "Registros encontrados: " + valor.ToString();

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void RealizarBusqueda(string TipoMovimiento)
        {
            switch (TipoMovimiento)
            {
                case "Reingresos":
                    CN_VistaUniverso objetoCN = new CN_VistaUniverso();
                    this.dataGridView1.DataSource = objetoCN.MostrarAltas(this.textBox1.Text);
                    this.ContarFilas();
                    break;

                case "Bajas":
                    CN_VistaUniverso objetoCN2 = new CN_VistaUniverso();
                    this.dataGridView1.DataSource = objetoCN2.MostrarBajas(this.textBox1.Text);
                    this.ContarFilas();
                    break;
            }
        }
    }
}
