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
using Utils;
using System.Globalization;

namespace CaoaPresentacion
{
    public partial class Frm_HistorialGestiones : Form
    {
        public Frm_HistorialGestiones()
        {
            InitializeComponent();
            this.cbBusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            DataGridViewConfigurator.Configure(dataGestiones,dataGestionesProgramadas);
        }

        private void Frm_HistorialGestiones_Load(object sender, EventArgs e)
        {
            try
            {
                this.AgregarColumnaConIcono();
                this.cbBusqueda.Text = "HOY";
                this.Buscar();
                this.MostrarGestionesProgramadasHoy();
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
                DataGridViewButtonColumn btnColumna1 = new DataGridViewButtonColumn();
                btnColumna1.HeaderText = "Gestion";
                btnColumna1.Name = "Gestion";
                btnColumna1.Text = "";
                btnColumna1.UseColumnTextForButtonValue = false;

                dataGestionesProgramadas.Columns.Add(btnColumna1);




                dataGestionesProgramadas.CellPainting += dataGestionesProgramadas_CellPainting;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "ControlPlus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GestionesProgramadasHoy()
        {
            try
            {
                CN_GestionCobro ObjetoCN = new CN_GestionCobro();
                this.dataGestionesProgramadas.DataSource = ObjetoCN.BuscarGestionesProgramadasParaHoy();

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FechaHoy = DateTime.Now.ToShortDateString();
            this.dtpFechaInicial.Text = FechaHoy;
            this.dtpFechaFinal.Text = FechaHoy;

            if (this.cbBusqueda.Text == "HOY")
            {
                this.dtpFechaInicial.Enabled = false;
                this.dtpFechaFinal.Enabled = false;
            }else if (this.cbBusqueda.Text == "POR RANGO")
            {
                this.dtpFechaInicial.Enabled = true;
                this.dtpFechaFinal.Enabled = true;
            }
        }

        private void btnBuscarPorCedula_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void Buscar()
        {
            try
            {
                CN_GestionCobro ObjetoCN = new CN_GestionCobro();
                this.dataGestiones.DataSource = ObjetoCN.BuscarGestionesPorRango(dtpFechaInicial.Text,dtpFechaFinal.Text);
                this.label5.Text = "Total de Registros: " + this.dataGestiones.Rows.Count.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarGestionesProgramadasHoy()
        {
            try
            {
                CN_GestionCobro ObjetoCN = new CN_GestionCobro();
                this.dataGestionesProgramadas.DataSource = ObjetoCN.BuscarGestionesProgramadasParaHoy();
                this.dataGestionesProgramadas.Columns["Id_Detalle_Programacion"].Visible = false;
                this.label6.Text = "Total de Registros: " + dataGestionesProgramadas.Rows.Count.ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void historialDeGestionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = tabHistorial;
        }

        private void gestionesHoyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = tabGestionesparaHoy;
        }

        private void dataGestionesProgramadas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGestionesProgramadas.Columns["Gestion"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, false);

                using (SolidBrush brush = new SolidBrush(Color.DodgerBlue))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }

                Bitmap icon = Properties.Resources.edit_button;

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

        private void dataGestionesProgramadas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Evitar clic en encabezado
                {
                    if (e.ColumnIndex == dataGestionesProgramadas.Columns["Gestion"].Index)
                    {
                        CN_GestionCobro ObjetoCN = new CN_GestionCobro();
                        
                        string IdDetalleProgramacion1 = this.dataGestionesProgramadas.CurrentRow.Cells["Id_Detalle_Programacion"].Value.ToString();
                        DataTable tabla = ObjetoCN.BuscarCarteraPorDetalle(IdDetalleProgramacion1);
                        if (tabla.Rows.Count > 0)
                        {
                            string Carnet = tabla.Rows[0][1].ToString();
                            string Estudiante = tabla.Rows[0][2].ToString() + " " + tabla.Rows[0][3].ToString();
                            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                            Estudiante = textInfo.ToTitleCase(Estudiante.ToLower());
                            string Celular = tabla.Rows[0][4].ToString();
                            string Curso = tabla.Rows[0][19].ToString();
                            string Turno = tabla.Rows[0][20].ToString();
                            string Horario = tabla.Rows[0][21].ToString();
                            string Concepto = tabla.Rows[0][7].ToString();
                            string Total = tabla.Rows[0][10].ToString();
                            string Mora = tabla.Rows[0][15].ToString();
                            string Abonado = tabla.Rows[0][16].ToString();
                            string Saldo = tabla.Rows[0][17].ToString();
                            string NivelMora = tabla.Rows[0][14].ToString();
                            string EstadoCartera = tabla.Rows[0][23].ToString();
                            string IdDetalleProgramacion = tabla.Rows[0][0].ToString();
                            DateTime fechaVencimiento = Convert.ToDateTime(tabla.Rows[0][11].ToString());

                            DateTime fechaActual = DateTime.Today;
                            int diasMora = 0;
                            if (fechaActual > fechaVencimiento)
                            {
                                diasMora = (fechaActual - fechaVencimiento).Days;
                            }

                            FrmHistorialGestion frm = new FrmHistorialGestion(Carnet, Estudiante, Celular, Curso, Turno, Horario, Concepto, fechaVencimiento.ToShortDateString(), Total, Mora, Abonado, Saldo, diasMora.ToString(), NivelMora, EstadoCartera, Convert.ToInt32(IdDetalleProgramacion));
                            frm.Show();
                        }else 
                        {
                            MessageBox.Show("Error, intente de nuevo", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        
                      
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
