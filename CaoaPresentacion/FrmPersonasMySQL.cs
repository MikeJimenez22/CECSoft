using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;


using CapaNegocio;
using CapaDatos;



namespace CaoaPresentacion
{
    public partial class FrmPersonasMySQL : Form
    {
        public FrmPersonasMySQL()
        {
            InitializeComponent();

            this.cmbDepartamento.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCiudad.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbProfesiones.DropDownStyle = ComboBoxStyle.DropDownList;

            this.Cargar_ComboDepartamento();
            this.Cargar_ComboProfesion();
        }

        string connectionString = "server=82.180.172.52;user id=u625629450_tchsp435;password=3Z|H4Ef]Qj!3;database=u625629450_register45;";
        string codigopersona;
        CD_Conexion conexion = new CD_Conexion();

        private void FrmPersonasMySQL_Load(object sender, EventArgs e)
        {

            try
            {
                this.checkBox1.Checked = true;
                this.cmbGenero.Text = "MASCULINO";

                this.cmbDepartamento.Text = "Managua";
                this.cmbCiudad.Text = "Managua";
                this.cmbProfesiones.Text = "Secundaria";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {

                    connection.Open();
                    
                    string consulta = "SELECT * FROM u625629450_register45.personas order by fechaRegistro desc;";


                    using (MySqlCommand command = new MySqlCommand(consulta, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            // Crear un DataTable para almacenar los datos de la consulta
                            DataTable dataTable = new DataTable();

                            // Llenar el DataTable con los datos de la consulta
                            adapter.Fill(dataTable);

                            // Asignar el DataTable al DataGridView
                            dataGridView1.DataSource = dataTable;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Conectarse a la Base de datos:" + ex.ToString(), "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Busqueda por Nombres
                string NombreaBuscar = this.textBox1.Text;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string consulta = "SELECT * FROM u625629450_register45.personas where nombres LIKE '" + NombreaBuscar + "%'";

                    using (MySqlCommand command = new MySqlCommand(consulta, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            // Crear un DataTable para almacenar los datos de la consulta
                            DataTable dataTable = new DataTable();

                            // Llenar el DataTable con los datos de la consulta
                            adapter.Fill(dataTable);

                            // Asignar el DataTable al DataGridView
                            dataGridView1.DataSource = dataTable;
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema: " + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarRegistro()
        {

        }


        public void Cargar_ComboDepartamento()
        {
            try
            {

                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("Select Id_departamento,Departamento from Tbl_Departamentos", conexion.Conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Departamento"] = "Selecciona un Departamento";
                dt.Rows.InsertAt(fila, 0);

                cmbDepartamento.ValueMember = "Id_departamento";
                cmbDepartamento.DisplayMember = "Departamento";
                cmbDepartamento.DataSource = dt;


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void AgregarBtnDatagridView()
        {
            dataGridView1.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Seleccionar",
                Name = "OK",
                Text = "OK",
                UseColumnTextForButtonValue = true

            });



            DataGridViewColumn columna = dataGridView1.Columns["Alta"];

            // Establece el ancho deseado para la columna (en píxeles)
            columna.Width = 50;



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtnombres.Text = this.dataGridView1.CurrentRow.Cells["nombres"].Value.ToString();
                this.txtapellidos.Text = this.dataGridView1.CurrentRow.Cells["apellidos"].Value.ToString();
                this.txtcedula.Text = this.dataGridView1.CurrentRow.Cells["cedula"].Value.ToString();
                this.dateTimePicker1.Text = this.dataGridView1.CurrentRow.Cells["fecha_nacimiento"].Value.ToString();
                this.txtdireccion.Text = this.dataGridView1.CurrentRow.Cells["direccion"].Value.ToString();
                this.txttiposangre.Text = this.dataGridView1.CurrentRow.Cells["tipo_sangre"].Value.ToString();
                this.txtcentrotrabajo.Text = this.dataGridView1.CurrentRow.Cells["centro_trabajo"].Value.ToString();
                this.txtcelulartrabajo.Text = this.dataGridView1.CurrentRow.Cells["celular_trabajo"].Value.ToString();
                this.txtocupacion.Text = this.dataGridView1.CurrentRow.Cells["ocupacion"].Value.ToString();
                this.txtnombretutor.Text = this.dataGridView1.CurrentRow.Cells["nombre_tutor"].Value.ToString();
                this.txtparentesco.Text = this.dataGridView1.CurrentRow.Cells["parentesco"].Value.ToString();
                this.txtcelulartutor.Text = this.dataGridView1.CurrentRow.Cells["celular_tutor"].Value.ToString();
                this.txtFechaInicio.Text = this.dataGridView1.CurrentRow.Cells["fechaInicio"].Value.ToString();
                this.txtIbservaciones.Text = this.dataGridView1.CurrentRow.Cells["Observaciones"].Value.ToString();

                MessageBox.Show("Registro seleccionado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tabControl1.SelectedIndex = 1;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema: " + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartamento.SelectedValue.ToString() != null)
            {

                string id_pais = cmbDepartamento.SelectedValue.ToString();
                this.cargar_Ciudades(id_pais);
                this.errorProvider1.Clear();
            }
        }

        public void Cargar_ComboProfesion()
        {
            try
            {

                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("Select Id_profesion,Nombre_profesion from Tbl_Profesion", conexion.Conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Nombre_profesion"] = "Selecciona una profesion";
                dt.Rows.InsertAt(fila, 0);

                cmbProfesiones.ValueMember = "Id_profesion";
                cmbProfesiones.DisplayMember = "Nombre_profesion";
                cmbProfesiones.DataSource = dt;


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void cargar_Ciudades(string id_pais)
        {
            try
            {

                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("select Id_ciudad,Ciudad from Tbl_Ciudades where Id_departamento = @Id_departamento", conexion.Conexion);
                cmd.Parameters.AddWithValue("Id_departamento", id_pais);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();


                DataRow dr = dt.NewRow();
                dr["Ciudad"] = "Selecciona una Ciudad";
                dt.Rows.InsertAt(dr, 0);

                cmbCiudad.ValueMember = "Id_ciudad";
                cmbCiudad.DisplayMember = "Ciudad";
                cmbCiudad.DataSource = dt;


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BloquearContenedoresTexto()
        {
            this.txtnombres.Enabled = true;
            this.txtapellidos.Enabled = true;
         
           
            this.txtcentrotrabajo.Enabled = true;
            this.txtcelulartrabajo.Enabled = true;
            this.txtocupacion.Enabled = true;
            this.txtdireccion.Enabled = true;
            this.txtnombretutor.Enabled = true;
            this.txtparentesco.Enabled = true;
            this.txtcelulartutor.Enabled = true;
            this.cmbDepartamento.Enabled = true;
            this.cmbCiudad.Enabled = true;
            this.cmbProfesiones.Enabled = true;
            this.cmbGenero.Enabled = true;
        }

        private void DesbloquearContenedoresTexto()
        {
            this.txtnombres.Enabled = false;
            this.txtapellidos.Enabled = false;
           
            this.txtcentrotrabajo.Enabled = false;
            this.txtcelulartrabajo.Enabled = false;
            this.txtocupacion.Enabled = false;
            this.txtdireccion.Enabled = false;
            this.txtnombretutor.Enabled = false;
            this.txtparentesco.Enabled = false;
            this.txtcelulartutor.Enabled = false;
            this.cmbDepartamento.Enabled = false;
            this.cmbCiudad.Enabled = false;
            this.cmbProfesiones.Enabled = false;
            this.cmbGenero.Enabled = false;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    this.DesbloquearContenedoresTexto();
                }
                else if (checkBox1.Checked == false)
                {
                    this.BloquearContenedoresTexto();

                }
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
                if (this.checkBox1.Checked == true)
                {
                    this.checkBox1.Checked = false;
                }
                else if (this.checkBox1.Checked == false)
                {
                    this.checkBox1.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarPersona();
                CachePersonaVentana.MetodoEntrada = "ONLINE";
                Frm_NuevaPersona frm = new Frm_NuevaPersona();
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarPersona()
        {
            try
            {
                CN_Personas objetoCN = new CN_Personas();
                string FechaActual = DateTime.Now.ToShortDateString();

                string NombreCompleto;
                string ApellidosCompletos;
                this.generarcodigo();

                NombreCompleto = this.txtnombres.Text.Trim().ToUpper();
                ApellidosCompletos = this.txtapellidos.Text.Trim().ToUpper();
                objetoCN.InsertarPersonas(FechaActual, NombreCompleto, ApellidosCompletos, this.txtcedula.Text, "", this.cmbGenero.Text, this.txttiposangre.Text, this.cmbCiudad.SelectedValue.ToString(), this.txtcedula.Text, this.txtdireccion.Text, codigopersona, this.cmbProfesiones.SelectedValue.ToString(), this.txtcentrotrabajo.Text, this.txtcelulartrabajo.Text, this.txtocupacion.Text, this.txtnombretutor.Text.Trim().ToUpper(), this.txtcelulartutor.Text, this.dateTimePicker1.Text, this.txtparentesco.Text);
                MessageBox.Show("Registro Guardado Correctamente");
                this.tabControl1.SelectedIndex = 1;



                LiberadorDeMemoria liberador = new LiberadorDeMemoria();
                liberador.alzheimer();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void generarcodigo()
        {
            //creando una instancia de random
            Random aleatorio = new Random();

            int numero;
            numero = aleatorio.Next(1, 99999999);
            this.codigopersona = numero.ToString();

        }


    }
}
