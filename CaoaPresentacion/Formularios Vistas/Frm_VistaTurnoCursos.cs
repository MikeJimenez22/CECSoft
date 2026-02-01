using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CaoaPresentacion.Frm_VistaTurnoCursos
{
    public partial class Frm_VistaTurnoCursos : Form
    {
        public Frm_VistaTurnoCursos()
        {
            InitializeComponent();
        }

        private void Frm_VistaTurnoCursos_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void Mostrar()
        {
            CN_Cursos_Turnos objetoCN = new CN_Cursos_Turnos();
            this.dataEmpleados.DataSource = objetoCN.MostrarCursoTurno();
        }

        private void dataEmpleados_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataEmpleados.Rows.Count == 0)
                {
                    MessageBox.Show("No se encuentra ningun Registro en esta Tabla");
                }
                else if (this.dataEmpleados.Rows.Count != 0)
                {
                    CacheDatos.Id_CursoTurno = this.dataEmpleados.CurrentRow.Cells["Id_Curso_turno"].Value.ToString();
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
    }
}
