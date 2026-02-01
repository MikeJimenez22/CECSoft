using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CaoaPresentacion
{
    public partial class Frm_BusquedaMatriculasEnLinea : Form
    {
        string connectionString = "Server=82.180.172.52;Database=u625629450_register45;User ID=u625629450_tchsp435;Password=3Z|H4Ef]Qj!3;Pooling=true;Max Pool Size=100;";

        public Frm_BusquedaMatriculasEnLinea()
        {
            InitializeComponent();
        }

        private void Frm_BusquedaMatriculasEnLinea_Load(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosFiltrados()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT codigo_referencia,fecha_registro,nombres,apellidos,direccion,NombreCurso,Turno,Horario,FechaInicio,OrigenMatricula FROM u625629450_register45.Estudiantes where fecha_registro between @desde and @hasta; ";

                    MySqlCommand command = new MySqlCommand(query, connection);

                    // Parámetros
                    command.Parameters.AddWithValue("@desde", dateTimePicker1.Value.Date);
                    command.Parameters.AddWithValue("@hasta", dateTimePicker2.Value.Date); 

                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al cargar datos");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha1 = Convert.ToDateTime(this.dateTimePicker1.Text);
                DateTime fecha2 = Convert.ToDateTime(this.dateTimePicker2.Text);
                if (fecha1 <= fecha2)
                {
                    this.CargarDatosFiltrados();
                }else if (fecha1 > fecha2)
                {
                    MessageBox.Show("La fecha Inicial debe ser menor que la fecha final", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
