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
    public partial class Frm_Inasistencias : Form
    {
        public Frm_Inasistencias()
        {
            InitializeComponent();
            DataGridViewConfigurator.Configure(this.dtaAusentes);
        }

        private void Frm_Inasistencias_Load(object sender, EventArgs e)
        {
            try
            {
                // Agregar la columna de icono
                AgregarColumnaConIcono();

                // Ajuste general de columnas
                dtaAusentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Ajustar columna específica
                const string columnaRetirar = "Retirar";
                if (dtaAusentes.Columns.Contains(columnaRetirar))
                {
                    var col = dtaAusentes.Columns[columnaRetirar];
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    col.Width = 100;
                }
                else
                {
                    MessageBox.Show(
                        $"Advertencia: No se encontró la columna '{columnaRetirar}'.",
                        "SISTEMA CECNIC",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }

                // Cargar datos
                MostrarListadoAusentes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error en el sistema:\n" + ex.Message,
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

        }

        private void MostrarListadoAusentes()
        {
            try
            {
                CN_Matriculas objetoCN = new CN_Matriculas();
                dtaAusentes.DataSource = objetoCN.ObtenerEstudiantesAusentes();
                this.dtaAusentes.Columns["Id_Matricula"].Visible = false;
                this.label2.Text = "Total: "+Convert.ToString(dtaAusentes.Rows.Count);
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
                btnColumna.HeaderText = "Retirar";
                btnColumna.Name = "Retirar";
                btnColumna.Text = ""; // El texto no se usará porque dibujaremos un ícono
                btnColumna.UseColumnTextForButtonValue = false;
                dtaAusentes.Columns.Add(btnColumna);


                // Evento para pintar el botón con un ícono
                dtaAusentes.CellPainting += dtaAusentes_CellPainting;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtaAusentes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dtaAusentes.Columns["Retirar"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Cargar el ícono desde recursos (recomendado) o archivo
                Bitmap icon = Properties.Resources.suspendido; // Usa tu recurso de imagen
                int iconWidth = 16;
                int iconHeight = 16;

                // Posición centrada en la celda
                int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                e.Graphics.DrawImage(icon, new Rectangle(x, y, iconWidth, iconHeight));
                e.Handled = true; // Indica que la celda está completamente pintada
            }
        }

        private void dtaAusentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Evitar clic en encabezado
                {
                    if (e.ColumnIndex == dtaAusentes.Columns["Retirar"].Index)
                    {
                            

                        string TipoUsuario = CacheUsuario.TipoUsuario;
                        if (TipoUsuario == "ADMINISTRADOR" || TipoUsuario == "COORDINACION" || TipoUsuario == "SUPER_USUARIO")
                        {
                            string nombrePC = Environment.MachineName;
                            CN_Bajas objetoCN = new CN_Bajas();
                            string IdMatricula = this.dtaAusentes.CurrentRow.Cells["Id_Matricula"].Value.ToString();

                            objetoCN.Insertar("BAJA", "INASISTENCIA",IdMatricula, CacheUsuario.IdUsuario, nombrePC);
                            objetoCN.DarBaja(IdMatricula);
                            MessageBox.Show("Se le ha dado de Baja al estudiante Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.MostrarListadoAusentes();
                        }
                        else
                        {
                            MessageBox.Show("No tienes acceso para realizar esta Accion", "ControlPlus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }



                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema: ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
