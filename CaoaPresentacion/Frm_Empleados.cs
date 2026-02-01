using CapaDatos;
using CapaNegocio;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Utils;

namespace CaoaPresentacion
{
    public partial class Frm_Empleados : Form
    {
        CN_Empleados objetoCN = new CN_Empleados();

        bool Editar = false;
        bool ActivoBtn = false;
        string Id_empleado;
        string Id_Persona;
        string Id_Estado;

        string FechaActual;
        CD_Conexion conexion = new CD_Conexion();


        public Frm_Empleados()
        {
            InitializeComponent();
            this.cmbestadocivil.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTipoEmpleado.DropDownStyle = ComboBoxStyle.DropDownList;
            DataGridViewConfigurator.Configure(this.dataEmpleados);
        }

        private void Frm_Empleados_Load(object sender, EventArgs e)
        {
            // Establecer pestaña inicial
            tabControl1.SelectedIndex = 0;

            // Valores predeterminados
            cmbestadocivil.SelectedIndex = cmbestadocivil.FindStringExact("SOLTERO");
            cmbTipoEmpleado.SelectedIndex = cmbTipoEmpleado.FindStringExact("Seleccione");

            // Preparar formulario
            AgregarBtnDatagridView();
            radioButton1.Checked = true;
            MostrarEmpleadosPorEstado();
            Habilitar();
            GenerarCarnet();

            // Obtener fecha actual
            FechaActual = dateTimePicker1.Value.ToString("yyyy-MM-dd"); // mejor formato

            // Asignar evento al cerrar formulario
            this.FormClosed += cerrarform;

          

        }

        private void cerrarform(object sender, EventArgs e)
        {
            DatosAlmacenados objeto = new DatosAlmacenados();
            objeto.LimpiarDatos();

        }

        private void Mostrar()
        {
            CN_Empleados objetoCN = new CN_Empleados();
            this.dataEmpleados.DataSource = objetoCN.Mostrar();
            this.OcultarColumnas();
        }

        private void OcultarColumnas()
        {
            try
            {
                dataEmpleados.Columns["Cedula"].Visible = false;
                //dataEmpleados.Columns["N_Inss"].Visible = false;
               // dataEmpleados.Columns["Estado_Civil"].Visible = false;
                dataEmpleados.Columns["Id_empleado"].Visible = false;
                dataEmpleados.Columns["Id_estado"].Visible = false;
                dataEmpleados.Columns["Id_persona"].Visible = false;
               // dataEmpleados.Columns["Fecha_Salida"].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarInactivos()
        {
            CN_Empleados objetoCN = new CN_Empleados();
            this.dataEmpleados.DataSource = objetoCN.MostrarInactivos();
            this.OcultarColumnas();
        }

        private void GenerarCarnet()
        {
            try
            {
                string valor = "EMP_";
                string año = DateTime.Now.Year.ToString();
                string mes = DateTime.Now.Day.ToString();
                string cadenaCarnet;

                DataTable tabla = new DataTable();
                CN_Empleados objetoCN = new CN_Empleados();

                tabla = objetoCN.UltimoRegistro();
                if (tabla.Rows.Count == 0)
                {
                    cadenaCarnet = valor + año + "00001";
                    this.txtcarnet.Text = cadenaCarnet.ToString();
                }
                else
                {
                    int ultimodigito = Convert.ToInt32(tabla.Rows[0][0].ToString()) + 1;

                    cadenaCarnet = valor + año + "0000" + ultimodigito;
                    this.txtcarnet.Text = cadenaCarnet.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Habilitar()
        {
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker2.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Formularios_Vistas.Frm_VistaEstados frm = new Formularios_Vistas.Frm_VistaEstados();
            frm.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string FechaActual = DateTime.Now.ToShortDateString();

                if (Editar == true)
                {
                    if (this.cmbTipoEmpleado.Text == "Seleccione")
                    {
                        MessageBox.Show("Selecciones tipo de Empleado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }else
                    {
                        objetoCN.EditarEmpleado(Id_empleado, Id_Persona, this.txtcarnet.Text.Trim().ToUpper(), this.txtinss.Text.Trim().ToUpper(), this.cmbestadocivil.Text, FechaActual, FechaActual, "3", this.cmbTipoEmpleado.Text);
                        MessageBox.Show("Registro Modificado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Mostrar();
                        this.Limpiar();
                        Editar = false;
                        this.tabControl1.SelectedIndex = 0;

                    }

                   
                }
                else if (Editar == false)
                {
                    if (this.ActivoBtn == false)
                    {
                        MessageBox.Show("Seleccione una Persona del Registro");
                    }
                    else if (this.ActivoBtn == true)
                    {
                        if (this.cmbTipoEmpleado.Text == "Seleccione")
                        {
                            MessageBox.Show("Selecciones tipo de Empleado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {

                            objetoCN.InsertarEmpleado(CacheDatos.Id_Persona, this.txtcarnet.Text.Trim().ToUpper(), this.txtinss.Text.Trim().ToUpper(), this.cmbestadocivil.Text, FechaActual, FechaActual, "3", this.cmbTipoEmpleado.Text);
                            MessageBox.Show("Empleado Agregado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Mostrar();
                            this.Limpiar();
                            ActivoBtn = false;
                            this.tabControl1.SelectedIndex = 0;
                        }
                    }
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void AgregarBtnDatagridView()
        {
            dataEmpleados.Columns.Add(
       new DataGridViewButtonColumn()
       {
           HeaderText = "Editar",
           Name = "Editar",
           Text = "Editar",
           UseColumnTextForButtonValue = true
       });







        }

        private void dataEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (this.dataEmpleados.Columns[e.ColumnIndex].Name == "Editar")
                {
                    this.Limpiar();
                    Editar = true;
                    this.txtcarnet.Text = this.dataEmpleados.CurrentRow.Cells["Cod_Carnet"].Value.ToString();
                    //this.txtinss.Text = this.dataEmpleados.CurrentRow.Cells["N_Inss"].Value.ToString();
                    this.dateTimePicker1.Text = this.dataEmpleados.CurrentRow.Cells["Fecha_Ingreso"].Value.ToString();
                    //this.cmbestadocivil.Text = this.dataEmpleados.CurrentRow.Cells["Estado_Civil"].Value.ToString();
                    //this.dateTimePicker2.Text = this.dataEmpleados.CurrentRow.Cells["Fecha_Salida"].Value.ToString();
                    this.Id_empleado = this.dataEmpleados.CurrentRow.Cells["Id_empleado"].Value.ToString();
                    this.Id_Persona = this.dataEmpleados.CurrentRow.Cells["Id_persona"].Value.ToString();
                    this.Id_Estado = this.dataEmpleados.CurrentRow.Cells["Id_estado"].Value.ToString();
                    this.txtnombres.Text = this.dataEmpleados.CurrentRow.Cells["Nombres"].Value.ToString();
                    this.txtapellidos.Text = this.dataEmpleados.CurrentRow.Cells["Apellidos"].Value.ToString();
                    this.txtcedula.Text = this.dataEmpleados.CurrentRow.Cells["Cedula"].Value.ToString();
                    this.cmbTipoEmpleado.Text = this.dataEmpleados.CurrentRow.Cells["Tipo_Empleado"].Value.ToString();
                    this.txtIdEmpleado.Text = this.dataEmpleados.CurrentRow.Cells["Id_empleado"].Value.ToString();
                    this.tabControl1.SelectedIndex = 1;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this.Editar = false;
        }

        private void Limpiar()
        {
            this.GenerarCarnet();
            this.txtinss.Text = string.Empty;
            this.dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            this.dateTimePicker2.Text = DateTime.Now.ToShortDateString();
            CacheDatos.Id_Estado = "";
            CacheDatos.Id_Profesion = "";
            CacheDatos.Id_Persona = "";
            this.txtnombres.Text = string.Empty;
            this.txtapellidos.Text = string.Empty;
            this.txtemail.Text = string.Empty;
            this.txtdireccion.Text = string.Empty;
            this.txtcedula.Text = string.Empty;
            this.txtgenero.Text = string.Empty;
            this.txtciudad.Text = string.Empty;
            this.txtdepartamento.Text = string.Empty;


        }

        private void txtidpersona_TextChanged(object sender, EventArgs e)
        {
            CD_Conexion conexion = new CD_Conexion();
            conexion.AbrirConexion();
            SqlCommand cm = new SqlCommand("SELECT dbo.Tbl_Personas.Id_persona, dbo.Tbl_Personas.Fecha_Registro, dbo.Tbl_Personas.Nombres, dbo.Tbl_Personas.Apellidos, dbo.Tbl_Personas.Cedula, dbo.Tbl_Personas.Correo, dbo.Tbl_Personas.Genero, dbo.Tbl_Personas.TipoSangre, dbo.Tbl_Personas.Direccion, dbo.Tbl_Personas.CodigoPersona, dbo.Tbl_Ciudades.Ciudad, dbo.Tbl_Departamentos.Departamento, dbo.Tbl_Personas.Id_ciudad,dbo.Tbl_Personas.IdPartidaNacimiento FROM dbo.Tbl_Ciudades INNER JOIN dbo.Tbl_Personas ON dbo.Tbl_Ciudades.Id_ciudad = dbo.Tbl_Personas.Id_ciudad INNER JOIN dbo.Tbl_Departamentos ON dbo.Tbl_Ciudades.Id_departamento = dbo.Tbl_Departamentos.Id_departamento  where dbo.Tbl_Personas.Id_persona = '" + txtidpersona.Text + "'", conexion.Conexion());
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read() == true)
            {
                this.txtnombres.Text = dr["Nombres"].ToString();
                this.txtapellidos.Text = dr["Apellidos"].ToString();
                this.txtemail.Text = dr["Correo"].ToString();
                this.txtdireccion.Text = dr["Direccion"].ToString();
                this.txtcedula.Text = dr["Cedula"].ToString();
                this.txtgenero.Text = dr["Genero"].ToString();
                this.txtciudad.Text = dr["Ciudad"].ToString();
                this.txtdepartamento.Text = dr["Departamento"].ToString();

            }
            conexion.CerrarConexion();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                switch (CacheDatos.contador4)
                {
                    case true:
                        this.txtidpersona.Text = CacheDatos.Id_Persona.ToString();
                        break;

                    case false:
                        break;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_Empleados_Paint(object sender, PaintEventArgs e)
        {
            //this.dataEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void MostrarEmpleadosPorEstado()
        {
            try
            {

                if (this.radioButton1.Checked == true)
                {
                    this.Mostrar();
                }
                else if (this.radioButton2.Checked == true)
                {
                    this.MostrarInactivos();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.MostrarEmpleadosPorEstado();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.MostrarEmpleadosPorEstado();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtnombres.Text == string.Empty)
                {
                    MessageBox.Show("Primero debes de Seleccionar un Registro de la Tabla", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (this.txtnombres.Text != string.Empty)
                {
                    CN_Empleados objetoCN = new CN_Empleados();
                    objetoCN.ModificarEstado(this.txtIdEmpleado.Text, "3");
                    MessageBox.Show("Empleado Activado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.MostrarEmpleadosPorEstado();
                    this.tabControl1.SelectedIndex = 0;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (this.txtnombres.Text == string.Empty)
                {
                    MessageBox.Show("Primero debes de Seleccionar un Registro de la Tabla", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (this.txtnombres.Text != string.Empty)
                {
                    CN_Empleados objetoCN = new CN_Empleados();
                    objetoCN.ModificarEstado(this.txtIdEmpleado.Text, "4");
                    MessageBox.Show("Empleado Inactivado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.MostrarEmpleadosPorEstado();
                    this.tabControl1.SelectedIndex = 0;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            try
            {
                ActivoBtn = true;
               
                Formularios_Vistas.Frm_VistaPersonas frm = new Formularios_Vistas.Frm_VistaPersonas();
                frm.Show();
                this.tabControl1.SelectedIndex = 1;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
        }

        
    }
}
