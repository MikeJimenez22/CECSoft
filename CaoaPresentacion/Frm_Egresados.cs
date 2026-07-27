using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapaNegocio;
using Utils;

namespace CaoaPresentacion
{
    public partial class Frm_Egresados : Form
    {
        public Frm_Egresados()
        {
            InitializeComponent();
            DataGridViewConfigurator.Configure(dataEgresados);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarEgresados();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       private void MostrarEgresados()
        {
            try
            {
                CN_Bajas objetoCN = new CN_Bajas();
                dataEgresados.DataSource = objetoCN.ConsultarEgresadosPorFecha(
                dpFechaInicio.Value,
                dpFechaFinal.Value);
                dataEgresados.Columns["Id_Matricula"].Visible = false;

                this.label3.Text = "Total de Registros: " + dataEgresados.Rows.Count;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Frm_Egresados_Load(object sender, EventArgs e)
        {
            try
            {
                string FechaActual = DateTime.Now.ToShortDateString();
                dpFechaInicio.Text = FechaActual;
                dpFechaFinal.Text = FechaActual;
                this.MostrarEgresados();

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
