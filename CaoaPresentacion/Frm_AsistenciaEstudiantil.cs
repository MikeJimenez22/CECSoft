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

namespace CaoaPresentacion
{
    public partial class Frm_AsistenciaEstudiantil : Form
    {
        public Frm_AsistenciaEstudiantil()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarReporteAsistencia();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarReporteAsistencia()
        {
            try
            {
                string fecha = this.dateTimePicker1.Text;
                CN_AsistenciaEstudiante objetoCN = new CN_AsistenciaEstudiante();
                this.dataAsistencia.DataSource = objetoCN.MostrarReporteAsistencia(fecha);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                this.CopyDataGridViewToClipboard(dataAsistencia);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CopyDataGridViewToClipboard(DataGridView dgv)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("*ASISTENCIA ESTUDIANTIL DEL DIA " + dateTimePicker1.Text + "*\t");

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow) // Evitar la fila nueva en DataGridView si existe
                {
                    // Agregar los datos de la fila actual
                    sb.AppendLine($"*{row.Cells["Nombres"].Value}\t{row.Cells["Apellidos"].Value}\t{row.Cells["Nombre_curso"].Value}\t{row.Cells["Turno"].Value}\t{row.Cells["Horario"].Value}*");
                    // Aquí puedes personalizar los valores de las categorías
                    sb.AppendLine("PRESENTES\t" + ObtenerValorCelda(row, "PRESENTES"));
                    sb.AppendLine("AUSENTES\t" + ObtenerValorCelda(row, "AUSENTES"));
                    sb.AppendLine("JUSTIFICADOS\t" + ObtenerValorCelda(row, "JUSTIFICADOS"));
                    sb.AppendLine("TARDE\t" + ObtenerValorCelda(row, "TARDE"));
                    sb.AppendLine("EGRESADO\t" + ObtenerValorCelda(row, "EGRESADO"));
                    sb.AppendLine("BAJA\t" + ObtenerValorCelda(row, "BAJA"));

                    // Separador opcional entre las filas (puedes eliminarlo si no lo necesitas)
                    sb.AppendLine(new string('-', 50));
                }
            }

            // Copiar al portapapeles
            Clipboard.SetText(sb.ToString());
            MessageBox.Show("Datos copiados", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string ObtenerValorCelda(DataGridViewRow row, string columnName)
        {
            return row.Cells[columnName]?.Value?.ToString() ?? "0"; // Asume "0" si es nulo
        }

        private void reporteAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 0;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarUniversoPorGrupo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarUniversoPorGrupo()
        {
            CN_AsistenciaEstudiante objeto = new CN_AsistenciaEstudiante();
            this.dataUniversoPorGrupo.DataSource = objeto.MostrarUniversoPorGrupo();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarEstudiantesPorCurso();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarEstudiantesPorCurso()
        {
            CN_AsistenciaEstudiante objeto = new CN_AsistenciaEstudiante();
            this.dataEstudiantesCurso.DataSource = objeto.MostrarEstudiantesPorCurso();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarEstudiantesPorCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarEstudiantesPorCategorias()
        {
            CN_AsistenciaEstudiante objeto = new CN_AsistenciaEstudiante();
            this.dataEstudiantesCategorias.DataSource = objeto.MostrarEstudiantesPorCategorias();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarEstudiantesPorTurnos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarEstudiantesPorTurnos()
        {
            CN_AsistenciaEstudiante objeto = new CN_AsistenciaEstudiante();
            this.dataEstudiantesTurnos.DataSource = objeto.MostrarEstudiantesPorTurnos();
        }

        private void estudiantesPorGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 1;
        }

        private void estudiantesPorCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 2;
        }

        private void estudiantesPorCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 3;
        }

        private void estudiantesPorTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 4;
        }
    }
}
