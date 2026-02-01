using CapaNegocio;
using System;
using System.Globalization;
using System.Windows.Forms;
using Utils;

namespace CaoaPresentacion
{
    public partial class Frm_PagoIncentivo : Form
    {


        public Frm_PagoIncentivo()
        {
            InitializeComponent();
            DataGridViewConfigurator.Configure(this.dataGridView1,this.dataGridView2);
        }


        string IdEstado;

        private void Frm_PagoIncentivo_Load(object sender, EventArgs e)
        {
            try
            {
                this.dateTimePicker1.Text = CacheIncentivo.FechaInicial;
                this.dateTimePicker2.Text = CacheIncentivo.FechaFinal;
                IdEstado = CacheIncentivo.Estado;
                BuscarPorFecha();
                CalcularIncentivo();
                this.SumarTotales();
                this.ContarFilas();
              

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void SumarTotales()
        {
            try
            {
                double subtotal = 0;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    subtotal += Convert.ToDouble(row.Cells["Total"].Value);
                }

                this.txtMontoAPagar.Text = Convert.ToString(subtotal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void ContarFilas()
        {
            this.label4.Text = "Total de Registros: " + this.dataGridView1.Rows.Count.ToString();

        }


        private void BuscarPorFecha()
        {
            try
            {
                CN_Incentivo objetoCN = new CN_Incentivo();

                DateTime fecha1 = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime fecha2 = DateTime.ParseExact(dateTimePicker2.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                this.dataGridView1.DataSource = objetoCN.MostrarUniversoPorEjecutivo(fecha1, fecha2, IdEstado);
                this.dataGridView1.Columns["Id_Matricula"].Visible = false;
                this.dataGridView1.Columns["Cod_Matricula"].Visible = false;
                this.dataGridView1.Columns["FechaNacimiento"].Visible = false;
                this.dataGridView1.Columns["Celular 1"].Visible = false;
                this.dataGridView1.Columns["Celular 2"].Visible = false;
                this.dataGridView1.Columns["tipoCurso"].Visible = false;
                this.dataGridView1.Columns["Duracion"].Visible = false;
                this.dataGridView1.Columns["Dias"].Visible = false;
                this.dataGridView1.Columns["Nombre Docente"].Visible = false;
                this.dataGridView1.Columns["Apellido Docente"].Visible = false;
                this.dataGridView1.Columns["Estado"].Visible = false;
                this.dataGridView1.Columns["Id_Grupo"].Visible = false;
                this.dataGridView1.Columns["Id Empleado"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


      


        private void CalcularIncentivo()
        {
            try
            {
                CN_Incentivo objetoCN = new CN_Incentivo();

                DateTime fecha1 = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime fecha2 = DateTime.ParseExact(dateTimePicker2.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                this.dataGridView2.DataSource = objetoCN.MostrarPagoTotalIncentivo(fecha1, fecha2, IdEstado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


       








    }
}
