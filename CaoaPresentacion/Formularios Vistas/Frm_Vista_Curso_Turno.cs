using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CaoaPresentacion.Formularios_Vistas
{
    public partial class Frm_Vista_Curso_Turno : Form
    {
        public Frm_Vista_Curso_Turno()
        {
            InitializeComponent();

        }

        private void Frm_Vista_Curso_Turno_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void Mostrar()
        {
            CN_Cursos_Turnos objetoCN = new CN_Cursos_Turnos();
            this.dataTurnoCursos.DataSource = objetoCN.Mostrar(this.txtBuscar.Text);
        }

        private void dataTurnoCursos_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataTurnoCursos.Rows.Count == 0)
                {
                    MessageBox.Show("No se encuentra ningun Registro en esta Tabla");
                }
                else if (this.dataTurnoCursos.Rows.Count != 0)
                {
                    CacheDatos.Id_CursoTurno = this.dataTurnoCursos.CurrentRow.Cells["Id_Curso_turno"].Value.ToString();

                    MessageBox.Show("Registro Seleccionado Correctamente", "CECNIC SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    CacheDatos.contador6 = true;



                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema, el error es " + ex);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void dataTurnoCursos_Paint(object sender, PaintEventArgs e)
        {
            this.dataTurnoCursos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
