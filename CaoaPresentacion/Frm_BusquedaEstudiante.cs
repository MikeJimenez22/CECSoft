using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CaoaPresentacion
{
    public partial class Frm_BusquedaEstudiante : Form
    {
        public Frm_BusquedaEstudiante()
        {
            InitializeComponent();

            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }



        private void BuscarApellidos()
        {
            CN_Estudiantes objetoCN = new CN_Estudiantes();
            this.dataestudiantes.DataSource = objetoCN.BuscarPorApellidos(this.txtbuscar.Text);
        }

        private void BuscarCedula()
        {
            CN_Estudiantes objetoCN = new CN_Estudiantes();
            this.dataestudiantes.DataSource = objetoCN.BuscarPorCedula(this.txtbuscar.Text);
        }

        private void Frm_BusquedaEstudiante_Load(object sender, EventArgs e)
        {
            this.comboBox1.Text = "Cedula";
            this.AgregarBtnDatagridView();
            this.BuscarApellidos();
          
        }

        private void AgregarBtnDatagridView()
        {
            dataestudiantes.Columns.Add(
       new DataGridViewButtonColumn()
       {
           HeaderText = "Seleccionar Estudiante",
           Name = "Select",
           Text = "Select",
           UseColumnTextForButtonValue = true
       });


        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.Text == "Cedula")
            {
                this.BuscarCedula();
            }
            else if (this.comboBox1.Text == "Apellidos")
            {
                this.BuscarApellidos();
            }
        }

        private void dataestudiantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (this.dataestudiantes.Columns[e.ColumnIndex].Name == "Select")

                CacheDatos.CodCarnet = this.dataestudiantes.CurrentRow.Cells["Cod_carnet"].Value.ToString();
            CacheDatos.PasarCarnet = true;
            this.Hide();

        }

    }
}

