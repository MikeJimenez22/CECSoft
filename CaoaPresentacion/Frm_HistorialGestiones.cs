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
    public partial class Frm_HistorialGestiones : Form
    {
        public Frm_HistorialGestiones()
        {
            InitializeComponent();
            this.cbBusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            DataGridViewConfigurator.Configure(dataGestiones);
        }

        private void Frm_HistorialGestiones_Load(object sender, EventArgs e)
        {
            try
            {
                this.cbBusqueda.Text = "HOY";
                this.Buscar();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FechaHoy = DateTime.Now.ToShortDateString();
            this.dtpFechaInicial.Text = FechaHoy;
            this.dtpFechaFinal.Text = FechaHoy;

            if (this.cbBusqueda.Text == "HOY")
            {
                this.dtpFechaInicial.Enabled = false;
                this.dtpFechaFinal.Enabled = false;
            }else if (this.cbBusqueda.Text == "POR RANGO")
            {
                this.dtpFechaInicial.Enabled = true;
                this.dtpFechaFinal.Enabled = true;
            }
        }

        private void btnBuscarPorCedula_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void Buscar()
        {
            try
            {
                CN_GestionCobro ObjetoCN = new CN_GestionCobro();
                this.dataGestiones.DataSource = ObjetoCN.BuscarGestionesPorRango(dtpFechaInicial.Text,dtpFechaFinal.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
