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
    public partial class FrmRoles : Form
    {
        public FrmRoles()
        {
            InitializeComponent();
            this.cmbEstados.DropDownStyle = ComboBoxStyle.DropDownList;
            DataGridViewConfigurator.Configure(this.dataRoles);
        }

        string IdEstado;
        string Id_de_Rol;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarRolesPorEstado(IdEstado);
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
                if (this.cmbEstados.Text == "Activos")
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

        private void MostrarRolesPorEstado(string IdEstado)
        {
            try
            {
                CN_Roles objetoCN = new CN_Roles();
                this.dataRoles.DataSource = objetoCN.Mostrar(IdEstado);
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmRoles_Load(object sender, EventArgs e)
        {
            try
            {
                cmbEstados.Text = "Activos";
                this.AgregarColumnaConIcono();
                MostrarRolesPorEstado(IdEstado);
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
                dataRoles.Columns.Add(btnColumna);


              
                // Evento para pintar el botón con un ícono
                dataRoles.CellPainting += dataRoles_CellPainting;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataRoles_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataRoles.Columns["Actualizar"].Index && e.RowIndex >= 0)
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

        private void dataRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Evitar clic en encabezado
                {
                    CN_Roles objetoCN = new CN_Roles();

                    // Detectar columna presionada
                    if (e.ColumnIndex == dataRoles.Columns["Actualizar"].Index)
                    {
                        string Estado = this.dataRoles.CurrentRow.Cells["Estado"].Value.ToString();
                        string IdRol = this.dataRoles.CurrentRow.Cells["IdRol"].Value.ToString();

                        if (Estado == "Activo")
                        {
                            objetoCN.ModificarEstado(IdRol,"4");
                            MessageBox.Show("Rol Inactivado correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MostrarRolesPorEstado(IdEstado);
                        }
                        else if (Estado == "Inactivo")
                        {
                            objetoCN.ModificarEstado(IdRol, "3");
                            MessageBox.Show("Rol Activado correctamente ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MostrarRolesPorEstado(IdEstado);

                        }
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();

                if (this.txtDescripcion.Text == string.Empty)
                {
                    errorProvider1.SetError(this.txtDescripcion,"Ingresa un error");
                }else if (this.txtDescripcion.Text != string.Empty)
                {
                    CN_Roles objetoCN = new CN_Roles();
                    DataTable tabla = new DataTable();
                    tabla = objetoCN.BuscarSiExisteRol(this.txtDescripcion.Text);
                    if (tabla.Rows.Count != 0)
                    {
                        MessageBox.Show("Ya existe este Rol, intente con otro", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }else if (tabla.Rows.Count == 0)
                    {
                        objetoCN.Insertar(this.txtDescripcion.Text.Trim().ToUpper(),"3");
                        this.ObtenerId();
                        this.InsertarFormularios_a_Rol();
                        MessageBox.Show("Registro Guardado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.cmbEstados.Text = "Activos";
                        this.MostrarRolesPorEstado("3");
                        this.tabControl1.SelectedIndex = 0;
                        this.txtDescripcion.Text = string.Empty;

                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerId()
        {
            try
            {
                CN_Roles objeto = new CN_Roles();
                DataTable tabla = new DataTable();

                tabla = objeto.BuscarIdRol(this.txtDescripcion.Text);
                if (tabla.Rows.Count != 0)
                {
                    this.Id_de_Rol = tabla.Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertarFormularios_a_Rol()
        {
            try
            {
                CN_Formularios objetoForm = new CN_Formularios();
                CN_Rol_Formularios objetoRolForm = new CN_Rol_Formularios();

                DataTable TablaFormularios = new DataTable();
                TablaFormularios = objetoForm.Mostrar();

                foreach (DataRow row2 in TablaFormularios.Rows)
                {
                    string IdFormulario = row2["IdFormularioSistema"].ToString();
                    objetoRolForm.InsertarRolFormulario(Id_de_Rol, IdFormulario);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
