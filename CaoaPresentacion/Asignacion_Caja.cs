using CapaDatos;
using CapaNegocio;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CaoaPresentacion
{
    public partial class Asignacion_Caja : Form
    {
        CN_Usuarios objetoCN = new CN_Usuarios();
        CD_Conexion conexion = new CD_Conexion();

        public Asignacion_Caja()
        {
            InitializeComponent();

            this.cmbCaja.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;

            this.Cargar_ComboCaja();
            this.Cargar_ComboEstados();
            this.Cargar_ComboUsuario();

        }

        private void Asignacion_Caja_Load(object sender, EventArgs e)
        {
            this.AgregarBtnDatagridView();
            this.Mostrar();
        }

        private void AgregarBtnDatagridView()
        {
            datAsignacion.Columns.Add(
       new DataGridViewButtonColumn()
       {
           HeaderText = "Cambiar Estado",
           Name = "Cambiar",
           Text = "Cambiar",
           UseColumnTextForButtonValue = true
       });

            datAsignacion.Columns.Add(
                new DataGridViewButtonColumn()
                {

                    HeaderText = "Eliminar",
                    Name = "Eliminar",
                    Text = "Eliminar",
                    UseColumnTextForButtonValue = true


                });


        }

        private void Mostrar()
        {
            CN_Usuarios objetoCN = new CN_Usuarios();
            this.datAsignacion.DataSource = objetoCN.MostrarUsuarioCajas();
        }

        public void Cargar_ComboCaja()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("Select IdCaja,NombreCaja from Tbl_Cajas where Id_estado = '3'", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["NombreCaja"] = "Selecciona una Caja";
                dt.Rows.InsertAt(fila, 0);

                cmbCaja.ValueMember = "IdCaja";
                cmbCaja.DisplayMember = "NombreCaja";
                cmbCaja.DataSource = dt;


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Cargar_ComboEstados()
        {
            try
            {

                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("Select Id_estado,Estado from Tbl_Estados where Id_Estado = '3' or Id_Estado = '4'", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Estado"] = "Selecciona un Estado";
                dt.Rows.InsertAt(fila, 0);

                cmbEstado.ValueMember = "Id_estado";
                cmbEstado.DisplayMember = "Estado";
                cmbEstado.DataSource = dt;


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public void Cargar_ComboUsuario()
        {
            try
            {

                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("select Id_usuario, Usuario from Tbl_Usuarios where Id_estado = '3'", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Usuario"] = "Seleccione un Usuario";
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

        private void cmbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

            conexion.AbrirConexion();
            SqlCommand cm = new SqlCommand("select a.Usuario, b.Cod_Carnet, c.Nombres, c.Apellidos, c.Cedula from Tbl_Usuarios a join Tbl_Empleados b on a.Id_empleado = b.Id_empleado join Tbl_Personas c on c.Id_persona = b.Id_persona where a.Id_usuario = '" + this.cmbUsuario.SelectedValue + "'", conexion.Conexion());
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read() == true)
            {
                this.txtuser.Text = dr["Usuario"].ToString();
                this.txtcarnetEmpleado.Text = dr["Cod_Carnet"].ToString();
                this.TxtNombreCompleto.Text = dr["Nombres"].ToString() + " " + dr["Apellidos"].ToString();
                this.txtCedulaIdentidad.Text = dr["Cedula"].ToString();




            }
            conexion.CerrarConexion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbCaja.Text == "Selecciona una Caja")
                {
                    MessageBox.Show("Error campo Caja No Seleccionado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (this.cmbCaja.Text != "Selecciona una Caja")
                {
                    bool UsuarioEncontrado = false;

                    string NombreUser = this.cmbUsuario.Text;
                    foreach (DataGridViewRow row in datAsignacion.Rows)
                    {
                        if (row.Cells["Usuario"].Value.ToString() == NombreUser)
                        {
                            UsuarioEncontrado = true;
                        }

                    }

                    if (UsuarioEncontrado == false)
                    {
                        CN_Usuarios objetoCN2 = new CN_Usuarios();
                        objetoCN2.AsignacionCaja(this.cmbCaja.SelectedValue.ToString(), this.cmbUsuario.SelectedValue.ToString(), this.cmbEstado.SelectedValue.ToString());
                        MessageBox.Show("Agregado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Cargar_ComboCaja();
                        this.Cargar_ComboEstados();
                        this.Cargar_ComboUsuario();
                        this.Mostrar();
                    }
                    else
                    {
                        MessageBox.Show("No se puede Asignar otra Caja a este Usuario, porque ya se encontro una", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void datAsignacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (this.datAsignacion.Columns[e.ColumnIndex].Name == "Cambiar")
            {
                if (this.datAsignacion.CurrentRow.Cells["Estado"].Value.ToString() == "Activo")
                {
                    objetoCN.InactivarUsuaroCaja(this.datAsignacion.CurrentRow.Cells["IdCajaUsuario"].Value.ToString());
                    MessageBox.Show("Se inactivo Usuario - Caja");
                    this.Mostrar();
                }
                else if (this.datAsignacion.CurrentRow.Cells["Estado"].Value.ToString() == "Inactivo")
                {
                    objetoCN.ActivarUsuaroCaja(this.datAsignacion.CurrentRow.Cells["IdCajaUsuario"].Value.ToString());
                    MessageBox.Show("Se activo Usuario - Caja");
                    this.Mostrar();
                }
            }
            else if (this.datAsignacion.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                CN_Usuarios objetoUsuario = new CN_Usuarios();
                objetoUsuario.EliminarAsignacion(this.datAsignacion.CurrentRow.Cells["IdCajaUsuario"].Value.ToString());
                MessageBox.Show("Registro Eliminado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Mostrar();

            }
        }
    }
}
