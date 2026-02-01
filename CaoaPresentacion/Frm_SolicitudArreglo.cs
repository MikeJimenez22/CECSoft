using CapaNegocio;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace CaoaPresentacion
{
    public partial class Frm_SolicitudArreglo : Form
    {
        public Frm_SolicitudArreglo()
        {
            InitializeComponent();
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        string VariableCarnet;

        CN_ArreglosPagos objetoCN = new CN_ArreglosPagos();
        string fechaVerificacion = DateTime.Now.ToShortDateString();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tabla = new DataTable();
                DateTime FechaActual = DateTime.ParseExact(fechaVerificacion, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                string name = System.Windows.Forms.SystemInformation.ComputerName;
                this.GenerarCarnet();

                objetoCN.Insertar(VariableCarnet, FechaActual, CacheDatos.NumeroDeProgramacionAbono, comboBox1.Text, this.txtObservaciones.Text, "NO", FechaActual, CacheUsuario.IdUsuario, name, "14");
                MessageBox.Show("Se envio la Solucitud", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Frm_SolicitudArreglo_Load(object sender, EventArgs e)
        {
            int i;


            for (i = 1; i <= 31; i++)
            {
                comboBox1.Items.Add(i.ToString());
            }

           
        }

        private void GenerarCarnet()
        {
            try
            {
                CN_ArreglosPagos objetoCN = new CN_ArreglosPagos();

                DataTable Tabla = new DataTable();
                Tabla = objetoCN.ObtenerNumArreglo();
                VariableCarnet = Tabla.Rows[0][0].ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
