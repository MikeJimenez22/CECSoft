using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CaoaPresentacion
{
    public partial class Frm_VistaEstudiantes : Form
    {
        CN_Estudiantes objetoCN = new CN_Estudiantes();

        public Frm_VistaEstudiantes()
        {
            InitializeComponent();
        }

        private void Frm_VistaEstudiantes_Load(object sender, EventArgs e)
        {
            try
            {
                this.AgregarBtnDatagridView();
                this.checkBox1.Checked = false;
                BusquedaEstudiante();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema,el error es " + ex);
            }
        }




        private void AgregarBtnDatagridView()
        {
            dataEstudiantes.Columns.Add(
       new DataGridViewButtonColumn()
       {
           HeaderText = "Seleccionar",
           Name = "Seleccionar",
           Text = "Seleccionar",
           UseColumnTextForButtonValue = true
       });


        }

        private void MostrarEstudiante()
        {
            CN_Estudiantes objetoCN = new CN_Estudiantes();
            this.dataEstudiantes.DataSource = objetoCN.MostrarEstudiantes(this.txtbusqueda.Text, this.dateTimePicker1.Text);

        }

        private void MostrarEstudianteEspecifico()
        {
            CN_Estudiantes objetoCN = new CN_Estudiantes();
            this.dataEstudiantes.DataSource = objetoCN.MostrarEstudiantesEspecifico(this.txtbusqueda.Text);

        }


        private void dataEstudiantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataEstudiantes.Columns[e.ColumnIndex].Name == "Seleccionar")
                {

                    CacheDatos.Id_Estudiante = this.dataEstudiantes.CurrentRow.Cells["Id_estudiante"].Value.ToString();
                    MessageBox.Show("Estudiante Seleccionado Correctamente");
                    this.Hide();
                    CacheDatos.Contador = true;



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema, el Error es " + ex);
            }
        }

        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtbusqueda.Text == string.Empty)
            {
                MessageBox.Show("Por Favor Ingresa el Nombre a Buscar", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.BusquedaEstudiante();
            }


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            BusquedaEstudiante();
        }

        private void BusquedaEstudiante()
        {
            if (this.checkBox1.Checked == false)
            {
                this.dateTimePicker1.Text = Convert.ToDateTime(this.dateTimePicker1.Text).ToShortDateString();
                this.MostrarEstudiante();
            }
            else if (this.checkBox1.Checked == true)
            {
                this.dateTimePicker1.Text = Convert.ToDateTime(this.dateTimePicker1.Text).ToShortDateString();
                this.dateTimePicker1.Enabled = false;
                this.MostrarEstudianteEspecifico();
            }
        }
    }
}
