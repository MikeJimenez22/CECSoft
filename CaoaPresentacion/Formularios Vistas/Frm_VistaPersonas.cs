using CapaNegocio;
using System;
using System.Windows.Forms;
using Utils;

namespace CaoaPresentacion.Formularios_Vistas
{
    public partial class Frm_VistaPersonas : Form
    {
        public Frm_VistaPersonas()
        {
            InitializeComponent();
            DataGridViewConfigurator.Configure(datapersonas);
        }

        private void Frm_VistaPersonas_Load(object sender, EventArgs e)
        {
            if (CacheDatos.VentanaProp == "Estudiante")
            {
                this.AgregarBtnDatagridViewEstudiante();
                this.Mostrar();
            }
            else
            {
                this.AgregarBtnDatagridViewPersona();
                this.Mostrar();
            }

            this.datapersonas.Columns["Id_persona"].Visible = false;
            this.datapersonas.Columns["Cedula"].Visible = false;
            this.datapersonas.Columns["Correo"].Visible = false;
            this.datapersonas.Columns["Genero"].Visible = false;
            this.datapersonas.Columns["TipoSangre"].Visible = false;
            this.datapersonas.Columns["CodigoPersona"].Visible = false;
            this.datapersonas.Columns["Id_ciudad"].Visible = false;
            this.datapersonas.Columns["IdPartidaNacimiento"].Visible = false;


        }

        private void Mostrar()
        {
            CN_Personas objetoCN = new CN_Personas();
            this.datapersonas.DataSource = objetoCN.Mostrar(this.txtBusqueda.Text);

        }

        private void AgregarBtnDatagridViewEstudiante()
        {
            datapersonas.Columns.Add(
       new DataGridViewButtonColumn()
       {
           HeaderText = "Seleccionar Estudiante",
           Name = "Seleccionar_Estudiante",
           Text = "Seleccionar",
           UseColumnTextForButtonValue = true
       });

        }

        private void AgregarBtnDatagridViewPersona()
        {
            datapersonas.Columns.Add(
       new DataGridViewButtonColumn()
       {
           HeaderText = "Seleccionar Persona",
           Name = "Seleccionar",
           Text = "Seleccionar",
           UseColumnTextForButtonValue = true
       });

        }



        private void datapersonas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.datapersonas.Columns[e.ColumnIndex].Name == "Seleccionar_Estudiante")
                {
                    CacheDatos.VarIdPersonaStudents = this.datapersonas.CurrentRow.Cells["Id_persona"].Value.ToString();
                    MessageBox.Show("Estudiante Seleccionado Correctamente");
                    this.Hide();
                    CacheDatos.contador3 = true;


                }
                else if (this.datapersonas.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                    CacheDatos.Id_Persona = this.datapersonas.CurrentRow.Cells["Id_persona"].Value.ToString();
                    MessageBox.Show("Registro Seleccionado");
                    CacheDatos.contador4 = true;
                    this.Hide();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema, El error es " + ex);
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            this.Mostrar();
        }
    }
}
