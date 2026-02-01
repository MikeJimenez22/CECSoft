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

namespace CaoaPresentacion
{
    public partial class FrmCursos : Form
    {
        public FrmCursos()
        {
            InitializeComponent();
            this.cmbEstados.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        string IdEstado;

        private void FrmCursos_Load(object sender, EventArgs e)
        {
            try
            {
                this.cmbEstados.Text = "Activos";
                this.cmbCategoria.Text = "Seleccione";
                this.AgregarColumnaConIcono();
                this.MostrarCursosPorEstado();

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(this.cmbEstados.Text == "Activos")
                {
                    this.IdEstado = "3";
                }else if (this.cmbEstados.Text == "Inactivos")
                {
                    this.IdEstado = "4";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarCursosPorEstado()
        {
            try
            {
                CN_Cursos objetoCN = new CN_Cursos();
                this.dataCursos.DataSource = objetoCN.MostrarCursosPorEstado(IdEstado);
                this.dataCursos.Columns["Id_curso"].Visible = false;
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
                btnColumna.HeaderText = "Actualizar estado";
                btnColumna.Name = "Actualizar";
                btnColumna.Text = ""; // El texto no se usará porque dibujaremos un ícono
                btnColumna.UseColumnTextForButtonValue = false;
                dataCursos.Columns.Add(btnColumna);



                // Evento para pintar el botón con un ícono
                dataCursos.CellPainting += datacursos_CellPainting;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void datacursos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataCursos.Columns["Actualizar"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Cargar el ícono desde recursos (recomendado) o archivo
                Bitmap icon = Properties.Resources._118839_applications_system_applications_system; // Usa tu recurso de imagen
                int iconWidth = 16;
                int iconHeight = 16;

                // Posición centrada en la celda
                int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                e.Graphics.DrawImage(icon, new Rectangle(x, y, iconWidth, iconHeight));
                e.Handled = true; // Indica que la celda está completamente pintada
            }
            
        }

        private void dataCursos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Evitar clic en encabezado
                {
                   

                    // Detectar columna presionada
                    if (e.ColumnIndex == dataCursos.Columns["Actualizar"].Index)
                    {
                        string Estado = this.dataCursos.CurrentRow.Cells["Estado"].Value.ToString();
                        string IdCurso = this.dataCursos.CurrentRow.Cells["Id_curso"].Value.ToString();

                        if (Estado == "Activo")
                        {
                            CN_Cursos objetoCN = new CN_Cursos();
                            objetoCN.ActualizarEstadoCurso(IdCurso,"4");
                            MessageBox.Show("Curso Inactivado correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.MostrarCursosPorEstado();
                        }
                        else if (Estado == "Inactivo")
                        {
                            CN_Cursos objetoCN2 = new CN_Cursos();
                            objetoCN2.ActualizarEstadoCurso(IdCurso, "3");
                            MessageBox.Show("Curso Inactivado correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.MostrarCursosPorEstado();
                        }
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpiar errores antes de validar
                errorProvider1.Clear();

                // Validar nombre del curso
                if (string.IsNullOrWhiteSpace(txtNombreCurso.Text))
                {
                    errorProvider1.SetError(txtNombreCurso, "Campo vacío, ingrese el curso");
                    return;
                }

                // Validar duración del curso
                if (string.IsNullOrWhiteSpace(txtDuracionCurso.Text))
                {
                    errorProvider1.SetError(txtDuracionCurso, "Campo vacío, ingrese la duración");
                    return;
                }

                if (!int.TryParse(txtDuracionCurso.Text, out int duracion) || duracion <= 0)
                {
                    errorProvider1.SetError(txtDuracionCurso, "La duración debe ser un número mayor a 0");
                    return;
                }

                // Validar duplicados
                CN_Cursos objetoCN = new CN_Cursos();
                DataTable tabla = objetoCN.MostrarCursosPorNombre(txtNombreCurso.Text.Trim());

                if (tabla.Rows.Count > 0)
                {
                    MessageBox.Show("Ya existe este curso, intente con otro",
                                    "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Insertar si no existe
                CN_Cursos objetoCN2 = new CN_Cursos();
                objetoCN2.InsertarCurso(txtNombreCurso.Text.Trim(),
                                       txtDuracionCurso.Text.Trim(),
                                       "3",
                                       cmbCategoria.Text);

                MessageBox.Show("Registrado correctamente",
                                "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tabControl1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema: " + ex.Message,
                                "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void convertirAMayusculas(TextBox texto)
        {
            // Obtener la posición actual del cursor
            int cursorPosition = texto.SelectionStart;

            // Convertir el texto a mayúsculas
            texto.Text = texto.Text.ToUpper();

            // Restaurar la posición del cursor
            texto.SelectionStart = cursorPosition;
        }

        private void txtNombreCurso_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.convertirAMayusculas(this.txtNombreCurso);
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtDuracionCurso_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir teclas de control como Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        private void btnNuevoRol_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedIndex = 1;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarCursosPorEstado();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
