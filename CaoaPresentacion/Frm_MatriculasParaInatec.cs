using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using CapaNegocio;
using Utils;

namespace CaoaPresentacion
{
    public partial class Frm_MatriculasParaInatec : Form
    {
        public Frm_MatriculasParaInatec()
        {
            InitializeComponent();
            this.cmbAño.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMes.DropDownStyle = ComboBoxStyle.DropDownList;
            DataGridViewConfigurator.Configure(dataGrupos,dataEstudiantes);
        }

     

        private void Frm_MatriculasParaInatec_Load(object sender, EventArgs e)
        {
            try
            {
                CargarAnios();
                CargarMeses();
                this.AgregarColumnaConIcono();
                mostrarGruposInatec();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarAnios()
        {
            cmbAño.Items.Clear();

            int añoActual = DateTime.Now.Year;

            cmbAño.Items.Add(añoActual);
            cmbAño.Items.Add(añoActual - 1);

            cmbAño.SelectedIndex = 0;
        }

        private void CargarMeses()
        {
            cmbMes.Items.Clear();

            int añoSeleccionado = Convert.ToInt32(cmbAño.SelectedItem);
            int añoActual = DateTime.Now.Year;

            int ultimoMes = (añoSeleccionado == añoActual)
                ? DateTime.Now.Month
                : 12;

            for (int i = 1; i <= ultimoMes; i++)
            {
                string mes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);
                cmbMes.Items.Add(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(mes));
            }

            if (cmbMes.Items.Count > 0)
                cmbMes.SelectedIndex = cmbMes.Items.Count - 1;
        }

        private void cmbAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMeses();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                mostrarGruposInatec();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrarGruposInatec()
        {
            try
            {
                CN_Grupos objetoCN = new CN_Grupos();
                int año = Convert.ToInt32(cmbAño.SelectedItem);
                int mes = cmbMes.SelectedIndex + 1;

                DateTime fechaInicio = new DateTime(año, mes, 1);
                DateTime fechaFinal = fechaInicio.AddMonths(1).AddDays(-1);

                dataGrupos.DataSource = objetoCN.ConsultarGruposInatecPorFecha(fechaInicio, fechaFinal);
                dataGrupos.Columns["Id_Grupo"].Visible = false;

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AgregarColumnaConIcono()
        {
            try
            {
                // Agregar columna de botón
                DataGridViewButtonColumn btnColumna = new DataGridViewButtonColumn();
                btnColumna.HeaderText = "Mostrar";
                btnColumna.Name = "Mostrar";
                btnColumna.Text = ""; // El texto no se usará porque dibujaremos un ícono
                btnColumna.UseColumnTextForButtonValue = false;
                dataGrupos.Columns.Add(btnColumna);


                dataGrupos.CellPainting += dataGrupos_CellPainting;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGrupos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGrupos.Columns["Mostrar"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, false);

                // Editar
                using (SolidBrush brush = new SolidBrush(Color.DodgerBlue))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }
                Bitmap icon = Properties.Resources.lupa;

                int iconWidth = 16;
                int iconHeight = 16;

                int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                e.Graphics.DrawImage(icon, new Rectangle(x, y, iconWidth, iconHeight));

                // Borde
                e.Graphics.DrawRectangle(Pens.White,
                    e.CellBounds.Left,
                    e.CellBounds.Top,
                    e.CellBounds.Width - 1,
                    e.CellBounds.Height - 1);

                e.Handled = true;
            }
        }

        private void dataGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Evitar clic en encabezado
                {

                    if (e.ColumnIndex == dataGrupos.Columns["Mostrar"].Index)
                    {
                        string IdGrupo = this.dataGrupos.CurrentRow.Cells["Id_Grupo"].Value.ToString();
                        string Turno = this.dataGrupos.CurrentRow.Cells["Turno"].Value.ToString();
                        this.txtDocente.Text = this.dataGrupos.CurrentRow.Cells["Docente"].Value.ToString();
                        this.txtCurso.Text = this.dataGrupos.CurrentRow.Cells["Curso"].Value.ToString();
                        this.txtTurno.Text = Turno;
                        this.txtHorario.Text = this.dataGrupos.CurrentRow.Cells["Horario"].Value.ToString();
                        this.txtDepartamento.Text = "Managua";
                        this.txtMunicipio.Text = "Managua";


                        int año = Convert.ToInt32(cmbAño.SelectedItem);
                        int mes = cmbMes.SelectedIndex + 1;

                        DateTime fechaInicio = new DateTime(año, mes, 1);
                        DateTime fechaFinal = fechaInicio.AddMonths(1).AddDays(-1);

                        CN_Grupos objetoCN = new CN_Grupos();

                        DataSet resultado =
                            objetoCN.ConsultarEstudiantesGrupoInatec(
                                Convert.ToInt32(IdGrupo),
                                fechaInicio,
                                fechaFinal,
                                Turno);

                        /* ==========================================
                           TABLA 0: FECHA INICIO
                           ========================================== */
                        if (resultado.Tables.Count > 0 &&
                            resultado.Tables[0].Rows.Count > 0 &&
                            resultado.Tables[0].Rows[0]["Fecha Inicio"] != DBNull.Value)
                        {
                            DateTime fechaOferta = Convert.ToDateTime(
                                resultado.Tables[0].Rows[0]["Fecha Inicio"]);

                            txtFechaInicio.Text = fechaOferta.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            txtFechaInicio.Text = "Sin fecha";
                        }


                        /* ==========================================
                            TABLA 1: FECHA FINAL
                            ========================================== */
                        if (resultado.Tables.Count > 1 &&
                            resultado.Tables[1].Rows.Count > 0 &&
                            resultado.Tables[1].Rows[0]["Fecha Final"] != DBNull.Value)
                        {
                            DateTime fechaFinalOferta = Convert.ToDateTime(
                                resultado.Tables[1].Rows[0]["Fecha Final"]);

                            txtFechaFinal.Text = fechaFinalOferta.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            txtFechaFinal.Text = "Sin fecha";
                        }

                        /* ==========================================
                            TABLA 2: LISTADO DE ESTUDIANTES
                            ========================================== */
                        if (resultado.Tables.Count > 2)
                        {
                            dataEstudiantes.DataSource = resultado.Tables[2];

                             lblCantidadEstudiantes.Text =
                                resultado.Tables[2].Rows.Count.ToString();

                            dataEstudiantes.Columns["Id_Matricula"].Visible = false;
                            dataEstudiantes.Columns["Ultima Fecha de Vencimiento"].Visible = false;
                            dataEstudiantes.Columns["Fecha Inicio"].Visible = false;
                        }
                        else
                        {
                            dataEstudiantes.DataSource = null;

                             lblCantidadEstudiantes.Text = "0";
                        }
                        
                        tabControl1.SelectedTab = tabEstudiantes;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex.Message, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = tabGrupos;
        }
    }
}
