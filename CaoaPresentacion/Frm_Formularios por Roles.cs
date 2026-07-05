using CapaDatos;
using CapaNegocio;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Utils;
using CaoaPresentacion;

namespace CaoaPresentacion
{
    public partial class Frm_Formularios_por_Roles : Form
    {
        public Frm_Formularios_por_Roles()
        {
            InitializeComponent();
            this.Cargar_ComboRoles();
           DataGridViewConfigurator.Configure(dataFormularios);
        }

        CD_Conexion conexion = new CD_Conexion();

        CN_Rol_Formularios objetoCN = new CN_Rol_Formularios();

        private void Frm_Formularios_por_Roles_Load(object sender, EventArgs e)
        {
            this.AgregarBtnDatagridView();
            this.Mostrar();
           
        }

        private void AgregarBtnDatagridView()
        {
            dataFormularios.Columns.Add(
        new DataGridViewButtonColumn()
        {
            HeaderText = "Modificar Estado",
            Name = "Modificar",
            Text = "Modificar",
            UseColumnTextForButtonValue = true
        });




        }

        private void Mostrar()
        {
            CN_Rol_Formularios objetoCN = new CN_Rol_Formularios();
            this.dataFormularios.DataSource = objetoCN.Mostrar_FormulariosxRol(this.cmbRol.Text);
            this.dataFormularios.Columns["Id_Rol_Formularios"].Visible = false;
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.Mostrar();
        }

        public void Cargar_ComboRoles()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();


                SqlCommand cmd = new SqlCommand("select Descripcion,IdRol from Tbl_Roles where Id_estado = '3'", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Descripcion"] = "Selecciona un Rol";
                dt.Rows.InsertAt(fila, 0);

                cmbRol.ValueMember = "IdRol";
                cmbRol.DisplayMember = "Descripcion";
                cmbRol.DataSource = dt;


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataFormularios_Click(object sender, EventArgs e)
        {

        }

        private void dataFormularios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataFormularios.Columns[e.ColumnIndex].Name == "Modificar")
                {
                    if (this.dataFormularios.CurrentRow.Cells["Estado"].Value.ToString() == "Activo")
                    {
                        objetoCN.ModificarRolFormulario(this.dataFormularios.CurrentRow.Cells["Id_Rol_Formularios"].Value.ToString(), "4");
                        MessageBox.Show("Formulario Inactivado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Mostrar();
                    }
                    else if (this.dataFormularios.CurrentRow.Cells["Estado"].Value.ToString() == "Inactivo")
                    {
                        objetoCN.ModificarRolFormulario(this.dataFormularios.CurrentRow.Cells["Id_Rol_Formularios"].Value.ToString(), "3");
                        MessageBox.Show("Formulario Activado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Mostrar();
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
                this.Cargar_ComboRoles();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                CN_Rol_Formularios objetoCN = new CN_Rol_Formularios();
                foreach (DataGridViewRow row in dataFormularios.Rows)
                {
                    objetoCN.ModificarRolFormulario(row.Cells["Id_Rol_Formularios"].Value.ToString(), "4");
                    this.Mostrar();
                }

                MessageBox.Show("Se han Inactivado todos los Formularios", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                CN_Rol_Formularios objetoCN = new CN_Rol_Formularios();
                foreach (DataGridViewRow row in dataFormularios.Rows)
                {
                    objetoCN.ModificarRolFormulario(row.Cells["Id_Rol_Formularios"].Value.ToString(), "3");
                    this.Mostrar();
                }

                MessageBox.Show("Se han Activado todos los Formularios", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
