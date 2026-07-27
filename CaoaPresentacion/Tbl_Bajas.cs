using CapaNegocio;
using System;
using System.Globalization;
using System.Windows.Forms;
using Utils;

namespace CaoaPresentacion
{
    public partial class Tbl_Bajas : Form
    {
        public Tbl_Bajas()
        {
            InitializeComponent();
            DataGridViewConfigurator.Configure(dataBajas);
        }

        private void Tbl_Bajas_Load(object sender, EventArgs e)
        {
            try
            {
                this.dateTimePicker1.Text = DateTime.Now.ToShortDateString();
                this.dateTimePicker2.Text = DateTime.Now.ToShortDateString();

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.BuscarEntre_fechas();
                this.txtTotal.Text = dataBajas.Rows.Count.ToString();
                // this.CalcularTipos();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void BuscarEntre_fechas()
        {
            CN_Bajas objetoCN = new CN_Bajas();

            DateTime fecha1 = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime fecha2 = DateTime.ParseExact(dateTimePicker2.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            this.dataBajas.DataSource = objetoCN.MostrarBajas(fecha1, fecha2);

        }

        private void CalcularTipos()
        {
            int Economico = 0;
            int Salud = 0;
            int Laborales = 0;
            int Egresado = 0;
            int otro = 0;


            foreach (DataGridViewRow row in dataBajas.Rows)
            {
                if (row.Cells["Motivo_baja"].Value.ToString() == "Motivos Economico")
                {
                    Economico = Economico + 1;
                }

                if (row.Cells["Motivo_baja"].Value.ToString() == "Motivos de Salud")
                {
                    Salud = Salud + 1;
                }

                if (row.Cells["Motivo_baja"].Value.ToString() == "Motivos Laborales")
                {
                    Laborales = Laborales + 1;
                }

                if (row.Cells["Motivo_baja"].Value.ToString() == "Egresado")
                {
                    Egresado = Egresado + 1;
                }

                if (row.Cells["Motivo_baja"].Value.ToString() == "Otro")
                {
                    otro = otro + 1;
                }


            }
        }
    }
}
