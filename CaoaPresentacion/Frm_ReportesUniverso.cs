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
using CapaDatos;
using CapaNegocio;
using Utils;

namespace CaoaPresentacion
{
    public partial class Frm_ReportesUniverso : Form
    {
        public Frm_ReportesUniverso()
        {
            InitializeComponent();
            DataGridViewConfigurator.Configure(this.dataAsistencia);
            this.cmbTurno.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void Frm_ReportesUniverso_Load(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedIndex = 1;
                this.cmbTurno.Text = "Selecciona un Turno";
                this.AgregarBtnDatagridView();

            }
            catch (Exception)
            {
                MessageBox.Show("Error de sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarReporteAsistencia();
            }
            catch (Exception)
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
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarUniversoPorGrupo();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarUniversoPorGrupo()
        {
            try
            {
                CN_AsistenciaEstudiante objeto = new CN_AsistenciaEstudiante();
                this.dataUniversoPorGrupo.DataSource = objeto.MostrarUniversoPorGrupo();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarEstudiantesPorCurso();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarEstudiantesPorCurso()
        {
            try
            {
                CN_AsistenciaEstudiante objeto = new CN_AsistenciaEstudiante();
                this.dataEstudiantesCurso.DataSource = objeto.MostrarEstudiantesPorCurso();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarEstudiantesPorCategorias();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarEstudiantesPorCategorias()
        {
            try
            {
                CN_AsistenciaEstudiante objeto = new CN_AsistenciaEstudiante();
                this.dataEstudiantesCategorias.DataSource = objeto.MostrarEstudiantesPorCategorias();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        

        private void button12_Click(object sender, EventArgs e)
        {

            try
            {
                this.MostrarEstudiantesPorTurnos();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarEstudiantesPorTurnos()
        {
            CN_AsistenciaEstudiante objeto = new CN_AsistenciaEstudiante();
            this.dataEstudiantesTurnos.DataSource = objeto.MostrarEstudiantesPorTurnos();
        }

        private void asistenciaDiaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 1;
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 2;
        }

        private void cursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 3;
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 4;
        }

        private void turnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 5;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbTurno.Text == "Selecciona un Turno")
                {
                    MessageBox.Show("Primero selecciona un Turno", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }else
                {
                    this.MostrarGruposActivosPorTurno(this.cmbTurno.Text);
                    this.dataGruposActivos.Columns["Id_Grupo"].Visible = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarAsistenciaPorGrupo(string Fecha,string IdGrupo)
        {
            try
            {
                CN_AsistenciaEstudiante objetoCN = new CN_AsistenciaEstudiante();
                this.DataAsistenciaPorGrupo.DataSource = objetoCN.MostrarAsistenciaPorGrupo(Fecha,IdGrupo);
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarGruposActivosPorTurno(string Turno)
        {
            try
            {
                CN_AsistenciaEstudiante objetoCN = new CN_AsistenciaEstudiante();
                this.dataGruposActivos.DataSource = objetoCN.MostrarGruposActivosPorTurno(Turno);
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void asistenciaPorGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 6;
        }

        private void AgregarBtnDatagridView()
        {
            dataGruposActivos.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Seleccionar",
                Name = "Seleccionar",
                Text = "Seleccionar",
                UseColumnTextForButtonValue = true

            });


            
            DataGridViewColumn columna = dataGruposActivos.Columns["Seleccionar"];

            // Establece el ancho deseado para la columna (en píxeles)
            columna.Width = 70;
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 6;
        }

        private void dataGruposActivos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataGruposActivos.Columns[e.ColumnIndex].Name == "Seleccionar")
                {

                    string IdGrupo = this.dataGruposActivos.CurrentRow.Cells["Id_Grupo"].Value.ToString();
                    string Fecha = this.dtpFecha.Text;
                    this.MostrarAsistenciaPorGrupo(Fecha,IdGrupo);
                    this.tabControl1.SelectedIndex = 7;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.CopyDataGridViewToClipboard(dataAsistencia);
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            MessageBox.Show("Reporte Copiado ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string ObtenerValorCelda(DataGridViewRow row, string columnName)
        {
            return row.Cells[columnName]?.Value?.ToString() ?? "0"; // Asume "0" si es nulo
        }
    }
}
