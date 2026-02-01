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
    public partial class Frm_EstudiantesNoAsignados : Form
    {
        public Frm_EstudiantesNoAsignados()
        {
            InitializeComponent();
            DataGridViewConfigurator.Configure(this.dtaMatriculasNoAsignados);
        }

        private void Frm_EstudiantesNoAsignados_Load(object sender, EventArgs e)
        {
            try
            {
                this.MostrarListadoNoAsignados();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void MostrarListadoNoAsignados()
        {
            try
            {
                CN_Matriculas objetoCN = new CN_Matriculas();
                dtaMatriculasNoAsignados.DataSource = objetoCN.ObtenerEstudiantesNoAsignados();
                this.dtaMatriculasNoAsignados.Columns["Id_Matricula"].Visible = false;
                this.label2.Text = "Total: "+Convert.ToInt32(dtaMatriculasNoAsignados.Rows.Count);
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       

    }
}
