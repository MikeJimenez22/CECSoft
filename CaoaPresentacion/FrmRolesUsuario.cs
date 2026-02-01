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
    public partial class FrmRolesUsuario : Form
    {
        public FrmRolesUsuario()
        {
            InitializeComponent();
            cmbEstados.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoles.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            DataGridViewConfigurator.Configure(this.dataRolUsuario);
            
        }

        string IdEstado;

        private void FrmRolesUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                this.cmbEstados.Text = "Activos";
                this.AgregarColumnaConIcono();
                MostrarRolesUsuarioPorEstado();
                this.Cargar_Usuarios();
                this.Cargar_Roles();


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarRolesUsuarioPorEstado();
        }

        private void MostrarRolesUsuarioPorEstado()
        {
            try
            {
                CN_Roles_Usuarios objetoCN = new CN_Roles_Usuarios();
                this.dataRolUsuario.DataSource = objetoCN.Mostrar(IdEstado);
                this.dataRolUsuario.Columns["Id_Rol_Usuario"].Visible = false; 
                this.dataRolUsuario.Columns["Id_usuario"].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        public void Cargar_Usuarios()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand(@"select b.Id_usuario,b.Usuario from Tbl_Empleados a join
                Tbl_Usuarios b on a.Id_empleado = b.Id_empleado
                where a.Tipo_Empleado = 'Administracion' and  b.Id_estado = 3", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Usuario"] = "Selecciona un Usuario";
                dt.Rows.InsertAt(fila, 0);

                cmbUsuario.ValueMember = "Id_usuario";
                cmbUsuario.DisplayMember = "Usuario";
                cmbUsuario.DataSource = dt;


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Cargar_Roles()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("select IdRol,Descripcion from Tbl_Roles where Id_estado = '3'", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Descripcion"] = "Selecciona un Rol";
                dt.Rows.InsertAt(fila, 0);

                cmbRoles.ValueMember = "IdRol";
                cmbRoles.DisplayMember = "Descripcion";
                cmbRoles.DataSource = dt;


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
                CN_Roles_Usuarios objetoCN = new CN_Roles_Usuarios();

                DataTable tabla = objetoCN.VerificarSiExistenRoles(cmbUsuario.SelectedValue.ToString());

                if (tabla.Rows.Count > 0)
                {
                    MessageBox.Show("No es posible asignar más de un rol activo a un mismo usuario.",
                                    "SISTEMA CECNIC",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    this.Cargar_Roles();
                    this.Cargar_Usuarios();
                    return;
                }else if (tabla.Rows.Count == 0)
                {
                    CN_Roles_Usuarios objetoCN2 = new CN_Roles_Usuarios();
                    // Insertar el nuevo rol
                    objetoCN2.InsertarRolUsuario(cmbUsuario.SelectedValue.ToString(),
                                                 cmbRoles.SelectedValue.ToString(),
                                                 "3");

                    MessageBox.Show("Registrado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Refrescar datos
                    MostrarRolesUsuarioPorEstado();
                    tabControl1.SelectedIndex = 0;
                    Cargar_Roles();
                    Cargar_Usuarios();
                }

              
            }
            catch (Exception)
            {
                MessageBox.Show("Error en el sistema: ",
                                "SISTEMA CECNIC",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
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
                dataRolUsuario.Columns.Add(btnColumna);



                // Evento para pintar el botón con un ícono
                dataRolUsuario.CellPainting += dataRolUsuario_CellPainting;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataRolUsuario_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataRolUsuario.Columns["Actualizar"].Index && e.RowIndex >= 0)
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

        private void dataRolUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Evitar clic en encabezado
                {
                    CN_Roles_Usuarios objetoCN = new CN_Roles_Usuarios();

                    // Detectar columna presionada
                    if (e.ColumnIndex == dataRolUsuario.Columns["Actualizar"].Index)
                    {
                        string Estado = this.dataRolUsuario.CurrentRow.Cells["Estado"].Value.ToString();
                        string IdRolUsuario = this.dataRolUsuario.CurrentRow.Cells["Id_Rol_Usuario"].Value.ToString();
                        string IdUsuario = this.dataRolUsuario.CurrentRow.Cells["Id_usuario"].Value.ToString();

                        if (Estado == "Activo")
                        {
                            objetoCN.ModificarEstadoRol_Usuario(IdRolUsuario,"4");
                            MessageBox.Show("Rol de usuario Inactivado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MostrarRolesUsuarioPorEstado();
                        }
                        else if (Estado == "Inactivo")
                        {
                            DataTable tabla = objetoCN.VerificarSiExistenRoles(IdUsuario);
                            if (tabla.Rows.Count > 0)
                            {
                                MessageBox.Show("No es posible asignar más de un rol activo a un mismo usuario.",
                                   "SISTEMA CECNIC",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Warning);
                              
                            }else if (tabla.Rows.Count == 0)
                            {
                                CN_Roles_Usuarios objetoCN2 = new CN_Roles_Usuarios();
                                objetoCN2.ModificarEstadoRol_Usuario(IdRolUsuario, "3");
                                MessageBox.Show("Rol de usuario activado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MostrarRolesUsuarioPorEstado();
                            }
                            
                           

                        }
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevoRol_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 0;
        }
    }
}
