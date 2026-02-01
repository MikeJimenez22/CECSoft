using CapaDatos;
using CapaNegocio;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Drawing; // Para Color y Font
using Utils;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;


namespace CaoaPresentacion
{
    public partial class Frm_DatosGenerales : Form
    {
        CD_Conexion conexion = new CD_Conexion();
        string connectionString = "Server=82.180.172.52;Database=u625629450_register45;User ID=u625629450_tchsp435;Password=3Z|H4Ef]Qj!3;Pooling=true;Max Pool Size=100;";

        string IdPersona;
        string VariableCarnet;
        bool Edicion = false;

        public Frm_DatosGenerales()
        {
            InitializeComponent();
            this.cmbDepartamento.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCiudad.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbGenero.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTipoSangre.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbNivelAcademico.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMedio.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCompañia.DropDownStyle = ComboBoxStyle.DropDownList;

            this.CargarDepartamentos();
            this.CargarNivelesAcademicos();
            this.AgregarBtnDatagridView();
            DataGridViewConfigurator.Configure(this.dataAgenda, this.dataEnfermedadesPersona, this.dataEmfermedades,this.dataPersonas);

        }








        private void AgregarBtnDatagridView()
        {
            dataAgenda.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Eliminar",
                Name = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true

            });

            dataEmfermedades.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Seleccionar",
                Name = "Seleccionar",
                Text = "Seleccionar",
                UseColumnTextForButtonValue = true

            });

            dataPersonas.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Seleccionar",
                Name = "Seleccionar",
                Text = "Seleccionar",
                UseColumnTextForButtonValue = true

            });

            dataEnfermedadesPersona.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Eliminar",
                Name = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true

            });



            DataGridViewColumn columna = dataAgenda.Columns["Eliminar"];

            // Establece el ancho deseado para la columna (en píxeles)
            columna.Width = 80;


            DataGridViewColumn columna2 = dataEmfermedades.Columns["Seleccionar"];

            // Establece el ancho deseado para la columna (en píxeles)
            columna2.Width = 80;

            DataGridViewColumn columna3 = dataEnfermedadesPersona.Columns["Eliminar"];

            // Establece el ancho deseado para la columna (en píxeles)
            columna3.Width = 80;

            DataGridViewColumn columna4 = dataPersonas.Columns["Seleccionar"];

            // Establece el ancho deseado para la columna (en píxeles)
            columna4.Width = 80;



        }

        private void Frm_DatosGenerales_Load(object sender, EventArgs e)
        {
            try
            {
                this.Edicion = false;
                this.progressBar1.Visible = false;
                // Configurar controles en el formulario
                ConfigurarControles();

                this.txtcedula.Enabled = true;
                this.btnBuscarPorCedula.Enabled = true;
            }
            catch (Exception ex)
            {
                MostrarMensajeDeError(ex);
            }

        }

   

        private void ConfigurarControles()
        {
            this.cmbGenero.Text = "MASCULINO";
            this.cmbTipoSangre.Text = "-";
            this.cmbMedio.Text = "CELULAR";
            this.cmbCompañia.Text = "CLARO";
            this.MostrarEmfermedades();

            // Lista de controles en el orden de tabulación deseado
            var controles = ObtenerControles();

            AsignarIndicesDeTabulacion(controles);
            DeshabilitarControles(controles, new Control[] { btnNuevo });
            this.groupBox2.Enabled = false;
            this.groupBox3.Enabled = false;
            this.panel3.Enabled = false;
        }

        private void MostrarEmfermedades()
        {
            CN_Emfermedades objetoCN3 = new CN_Emfermedades();
            this.dataEmfermedades.DataSource = objetoCN3.MostrarEnfermedad(this.txtBuscar.Text);

        }

        private Control[] ObtenerControles()
        {
            // Lista de controles en el orden de tabulación deseado
            return new Control[]
            {
        btnNuevo,
        txtcedula,
        btnBuscarPorCedula,
        dtpFechaNacimiento,
        txtNombres,
        txtApellidos,
        cmbDepartamento,
        cmbCiudad,
        cmbTipoSangre,
        cmbGenero,
        txtDireccion,
        txtcorreo,
        cmbNivelAcademico,
        txtCentroTrabajo,
        txtCelularTrabajo,
        txtOcupacion,
        txtLlamarA,
        txtParentesco,
        txtCelularTutor,
        btnContinuar
            };
        }




        private void AsignarIndicesDeTabulacion(Control[] controles)
        {
            // Asignación de los índices de tabulación automáticamente
            for (int i = 0; i < controles.Length; i++)
            {
                controles[i].TabIndex = i;
            }
        }

        private void DeshabilitarControles(Control[] controles, Control[] excepciones)
        {
            // Deshabilitar todos los controles en la lista excepto los que están en excepciones
            foreach (var control in controles)
            {
                if (!excepciones.Contains(control))
                {
                    control.Enabled = false;
                }
            }
        }

        private void MostrarMensajeDeError(Exception ex)
        {
            MessageBox.Show("Ocurrió un error al cargar el formulario: " + ex.Message,
                            "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                // Cerrar el formulario actual
                this.Close();

                // Crear una nueva instancia de Frm_DatosGenerales
                Frm_DatosGenerales nuevoFormulario = new Frm_DatosGenerales();

                // Mostrar el nuevo formulario
                nuevoFormulario.Show();

                // Liberar los recursos del formulario anterior
                this.Dispose();

                Edicion = false;
            }
            catch (Exception ex)
            {
                MostrarMensajeDeError(ex);
            }
        }

        

        private string generarcodigo()
        {
            //creando una instancia de random
            Random aleatorio = new Random();

            int numero;
            numero = aleatorio.Next(1, 99999999);
            return numero.ToString();

        }




        private void btnBuscarPorCedula_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtCodigoPersona.Text = generarcodigo();

                if (this.txtcedula.Text == "   -      -")
                {
                    this.HabilitarControles();

                }
                else if (this.txtcedula.Text != "   -      -")
                {
                    int CantidadCaracteres = this.txtcedula.Text.Length;

                    if (CantidadCaracteres == 16)
                    {
                        CN_Personas objetoCN = new CN_Personas();
                        DataTable tabla = new DataTable();

                        tabla = objetoCN.ObtenerDatosCedula(this.txtcedula.Text);
                        if (tabla.Rows.Count == 0)
                        {
                            this.ExtraerFechaDeNacimiento();
                            this.HabilitarControles();
                        }
                        else if (tabla.Rows.Count != 0)
                        {
                            this.ObtenerDatosTabla(tabla);
                            this.ExtraerFechaDeNacimiento();
                            this.HabilitarControles();

                        }


                    }
                    else if (CantidadCaracteres < 16)
                    {
                        MessageBox.Show("Cedula no completa", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            catch (Exception ex)
            {
                MostrarMensajeDeError(ex);
            }
        }

        private void ObtenerDatosTabla(DataTable tabla)
        {
            this.txtNombres.Text = tabla.Rows[0][0].ToString();
            this.txtApellidos.Text = tabla.Rows[0][1].ToString();
            this.txtcedula.Text = tabla.Rows[0][2].ToString();
            this.txtcorreo.Text = tabla.Rows[0][3].ToString();
            this.cmbGenero.Text = tabla.Rows[0][4].ToString();
            this.cmbTipoSangre.Text = tabla.Rows[0][5].ToString();
            this.cmbDepartamento.Text = tabla.Rows[0][7].ToString();
            this.cmbCiudad.Text = tabla.Rows[0][6].ToString();
            this.txtDireccion.Text = tabla.Rows[0][8].ToString();
            this.cmbNivelAcademico.Text = tabla.Rows[0][9].ToString();
            this.txtCentroTrabajo.Text = tabla.Rows[0][10].ToString();
            this.txtCelularTrabajo.Text = tabla.Rows[0][11].ToString();
            this.txtOcupacion.Text = tabla.Rows[0][12].ToString();
            this.txtLlamarA.Text = tabla.Rows[0][13].ToString();
            this.txtCelularTutor.Text = tabla.Rows[0][14].ToString();
            this.txtParentesco.Text = tabla.Rows[0][15].ToString();
            this.txtCodigoPersona.Text = tabla.Rows[0][17].ToString();
            this.txtIdPersona.Text = tabla.Rows[0][18].ToString();

        }

        private void HabilitarControles()
        {
            dtpFechaNacimiento.Enabled = true;
            txtNombres.Enabled = true;
            txtApellidos.Enabled = true;
            txtDireccion.Enabled = true;
            txtcorreo.Enabled = true;
            cmbNivelAcademico.Enabled = true;
            cmbDepartamento.Enabled = true;
            cmbCiudad.Enabled = true;
            cmbGenero.Enabled = true;
            cmbTipoSangre.Enabled = true;
            txtCentroTrabajo.Enabled = true;
            txtCelularTrabajo.Enabled = true;
            txtOcupacion.Enabled = true;
            txtLlamarA.Enabled = true;
            txtParentesco.Enabled = true;
            txtCelularTutor.Enabled = true;
            btnContinuar.Enabled = true;
        }


        public void CargarDepartamentos()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("Select Id_departamento,Departamento from Tbl_Departamentos", conexion.Conexion());
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
            catch (Exception ex)
            {
                this.MostrarMensajeDeError(ex);
            }

        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbDepartamento.SelectedValue.ToString() != null)
                {

                    string id_pais = cmbDepartamento.SelectedValue.ToString();
                    this.CargarCiudades(id_pais);

                }
            }
            catch (Exception ex)
            {
                MostrarMensajeDeError(ex);
            }


        }

        public void CargarCiudades(string id_pais)
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("select Id_ciudad,Ciudad from Tbl_Ciudades where Id_departamento = @Id_departamento", conexion.Conexion());
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
            catch (Exception ex)
            {
                this.MostrarMensajeDeError(ex);
            }

        }

        // Método para extraer la fecha de nacimiento de la cédula
        private void ExtraerFechaDeNacimiento()
        {
            // Suponiendo que txtcedula contiene el número de cédula en el formato "041-150699-1010U"
            string cedula = txtcedula.Text;

            // Validar que la cédula tenga el formato correcto
            if (cedula.Length >= 13 && cedula[3] == '-' && cedula[10] == '-')
            {
                // Extraer la parte de la fecha "150699" que representa el formato ddMMyy
                string fechaStr = cedula.Substring(4, 6);

                // Formatear la fecha correctamente y convertirla a DateTime
                if (DateTime.TryParseExact(fechaStr, "ddMMyy", null, System.Globalization.DateTimeStyles.None, out DateTime fechaNacimiento))
                {
                    // Asignar la fecha de nacimiento al DateTimePicker
                    dtpFechaNacimiento.Value = fechaNacimiento;
                }
                else
                {
                    MessageBox.Show("Formato de fecha incorrecto en la cédula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Formato de cédula incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarNivelesAcademicos()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("Select Id_profesion,Nombre_profesion from Tbl_Profesion", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Nombre_profesion"] = "Selecciona un Nivel Academico";
                dt.Rows.InsertAt(fila, 0);

                cmbNivelAcademico.ValueMember = "Id_profesion";
                cmbNivelAcademico.DisplayMember = "Nombre_profesion";
                cmbNivelAcademico.DataSource = dt;


            }
            catch (Exception ex)
            {
                this.MostrarMensajeDeError(ex);
            }

        }

        private void txtcedula_TextChanged(object sender, EventArgs e)
        {
            // Obtener la posición actual del cursor
            int cursorPosition = txtcedula.SelectionStart;

            // Convertir el texto a mayúsculas
            txtcedula.Text = txtcedula.Text.ToUpper();

            // Restaurar la posición del cursor
            txtcedula.SelectionStart = cursorPosition;
        }

        private void txtNombres_TextChanged(object sender, EventArgs e)
        {

            this.convertirAMayusculas(txtNombres);
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            this.convertirAMayusculas(txtApellidos);
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            this.convertirAMayusculas(txtDireccion);
        }

        private void txtCentroTrabajo_TextChanged(object sender, EventArgs e)
        {
            this.convertirAMayusculas(txtCentroTrabajo);
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

        private void txtLlamarA_TextChanged(object sender, EventArgs e)
        {
            this.convertirAMayusculas(txtLlamarA);
        }

        private void txtParentesco_TextChanged(object sender, EventArgs e)
        {
            this.convertirAMayusculas(txtParentesco);
        }

        private void txtCelularTrabajo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarEntradaNumerica(e, txtCelularTrabajo, 8);
        }

        private void txtCelularTutor_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarEntradaNumerica(e, txtCelularTutor, 8);
        }

        private void ValidarEntradaNumerica(KeyPressEventArgs e, TextBox textBox, int maxLength)
        {
            // Permitir solo dígitos y controlar que no se ingresen más de maxLength caracteres
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || textBox.Text.Length >= maxLength && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla presionada
            }
        }

        private void txtCelularTutor_TextChanged(object sender, EventArgs e)
        {
            ValidarNumeroCelular(txtCelularTutor);
        }

        private void ValidarNumeroCelular(TextBox texto)
        {
            if (texto.Text.Length > 8)
            {
                texto.Text = texto.Text.Substring(0, 8);
                texto.SelectionStart = texto.Text.Length; // Coloca el cursor al final
            }
        }

        private void txtCelularTrabajo_TextChanged(object sender, EventArgs e)
        {
            ValidarNumeroCelular(txtCelularTrabajo);
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Edicion == true)
                {
                    this.EditarPersona();

                }else if (this.Edicion == false)
                {
                    this.GuardarPersona();
                }

               
            }
            catch (Exception ex)
            {
                MostrarMensajeDeError(ex);
            }
        }

        private void EditarPersona()
        {
            try
            {
                errorProvider1.Clear();
                string FechaActual = DateTime.Now.ToShortDateString();
                bool hayError = false;

                // Validación de campos obligatorios
                if (string.IsNullOrWhiteSpace(this.txtNombres.Text))
                {
                    errorProvider1.SetError(this.txtNombres, "Este campo es obligatorio. (*)");
                    hayError = true;
                }

                if (string.IsNullOrWhiteSpace(this.txtApellidos.Text))
                {
                    errorProvider1.SetError(this.txtApellidos, "Este campo es obligatorio. (*)");
                    hayError = true;
                }

                if (this.dtpFechaNacimiento.Value.Date == DateTime.Now.Date)
                {
                    errorProvider1.SetError(this.dtpFechaNacimiento, "La fecha de nacimiento no puede ser igual a la fecha actual. (*)");
                    hayError = true;
                }

                if (this.cmbDepartamento.SelectedIndex == 0) // Asumiendo que el primer índice es "Selecciona un Departamento"
                {
                    errorProvider1.SetError(this.cmbDepartamento, "Seleccione un departamento válido. (*)");
                    hayError = true;
                }

                if (this.cmbCiudad.SelectedIndex == 0) // Asumiendo que el primer índice es "Selecciona una Ciudad"
                {
                    errorProvider1.SetError(this.cmbCiudad, "Seleccione una ciudad válida. (*)");
                    hayError = true;
                }

                if (this.cmbNivelAcademico.SelectedIndex == 0) // Asumiendo que el primer índice es "Selecciona un Nivel Académico"
                {
                    errorProvider1.SetError(this.cmbNivelAcademico, "Seleccione un nivel académico válido. (*)");
                    hayError = true;
                }

                // Si hubo errores, mostramos un mensaje y salimos del método
                if (hayError)
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios antes de continuar.",
                                    "Advertencia",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                //Editar Datos de Persona
                CN_Personas objetoCN = new CN_Personas();
                objetoCN.EditarPersona(
                    this.txtIdPersona.Text,
                    this.txtNombres.Text.ToUpper(),
                    this.txtApellidos.Text.ToUpper(),
                    this.txtcedula.Text.ToUpper(),
                    this.txtcorreo.Text,
                    this.cmbGenero.Text.ToUpper(),
                    this.cmbTipoSangre.Text,
                    this.cmbCiudad.SelectedValue.ToString(),
                    "",
                    this.txtDireccion.Text,
                    this.cmbNivelAcademico.SelectedValue.ToString(),
                    this.txtCentroTrabajo.Text,
                    this.txtCelularTrabajo.Text,
                    this.txtOcupacion.Text,
                    this.txtLlamarA.Text,
                    this.txtCelularTutor.Text,
                    this.dtpFechaNacimiento.Text,
                    this.txtParentesco.Text
                    );

               

                MessageBox.Show("Editado Correctamente","SISTEMA CECNIC",MessageBoxButtons.OK, MessageBoxIcon.Information );

                this.panel3.Enabled = true;

            }
            catch (Exception ex)
            {
                MostrarMensajeDeError(ex);
            }
        }


        private void GuardarPersona()
        {
            try
            {
                // Limpia cualquier error previo en ErrorProvider
                errorProvider1.Clear();

                string FechaActual = DateTime.Now.ToShortDateString();
                bool hayError = false;

                // Validación de campos obligatorios
                if (string.IsNullOrWhiteSpace(this.txtNombres.Text))
                {
                    errorProvider1.SetError(this.txtNombres, "Este campo es obligatorio. (*)");
                    hayError = true;
                }

                if (string.IsNullOrWhiteSpace(this.txtApellidos.Text))
                {
                    errorProvider1.SetError(this.txtApellidos, "Este campo es obligatorio. (*)");
                    hayError = true;
                }

                if (this.dtpFechaNacimiento.Value.Date == DateTime.Now.Date)
                {
                    errorProvider1.SetError(this.dtpFechaNacimiento, "La fecha de nacimiento no puede ser igual a la fecha actual. (*)");
                    hayError = true;
                }

                if (this.cmbDepartamento.SelectedIndex == 0) // Asumiendo que el primer índice es "Selecciona un Departamento"
                {
                    errorProvider1.SetError(this.cmbDepartamento, "Seleccione un departamento válido. (*)");
                    hayError = true;
                }

                if (this.cmbCiudad.SelectedIndex == 0) // Asumiendo que el primer índice es "Selecciona una Ciudad"
                {
                    errorProvider1.SetError(this.cmbCiudad, "Seleccione una ciudad válida. (*)");
                    hayError = true;
                }

                if (this.cmbNivelAcademico.SelectedIndex == 0) // Asumiendo que el primer índice es "Selecciona un Nivel Académico"
                {
                    errorProvider1.SetError(this.cmbNivelAcademico, "Seleccione un nivel académico válido. (*)");
                    hayError = true;
                }

                // Si hubo errores, mostramos un mensaje y salimos del método
                if (hayError)
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios antes de continuar.",
                                    "Advertencia",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Insertar datos si no hay errores
                CN_Personas objetoCN = new CN_Personas();
                objetoCN.InsertarPersonas(
                    FechaActual,
                    txtNombres.Text.ToUpper(),
                    txtApellidos.Text.ToUpper(),
                    txtcedula.Text,
                    txtcorreo.Text,
                    cmbGenero.Text,
                    cmbTipoSangre.Text,
                    cmbCiudad.SelectedValue.ToString(),
                    "",
                    txtDireccion.Text,
                    txtCodigoPersona.Text,
                    cmbNivelAcademico.SelectedValue.ToString(),
                    txtCentroTrabajo.Text,
                    txtCelularTrabajo.Text,
                    txtOcupacion.Text.ToUpper(),
                    txtLlamarA.Text.ToUpper(),
                    txtCelularTutor.Text,
                    dtpFechaNacimiento.Value.ToShortDateString(),
                    txtParentesco.Text
                );


                this.ObtenerUltimaPersona();
                this.ObtenerAgendaTelefonica(this.txtIdPersonaAgenda.Text);
                this.ObtenerEnfermedadesPorPersona(this.txtIdPersonaEnfermedades.Text);

              


                MessageBox.Show("Registro guardado correctamente.",
                                "SISTEMA CECNIC",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                this.groupBox1.Enabled = false;
                this.groupBox2.Enabled = true;
                this.groupBox3.Enabled = true;
                this.panel3.Enabled = true;

            }
            catch (Exception ex)
            {
                this.MostrarMensajeDeError(ex);
            }
        }

        private void ObtenerUltimaPersona()
        {
            try
            {
                CN_Personas objetoCN = new CN_Personas();
                DataTable tabla = new DataTable();
                tabla = objetoCN.ObtenerUltimaPersona();
                if (tabla.Rows.Count != 0)
                {
                    string IdPersona = tabla.Rows[0][0].ToString();
                    ObtenerId(IdPersona);

                }
            }
            catch (Exception ex)
            {
                this.MostrarMensajeDeError(ex);
            }
        }


        private void ObtenerId(string Id)
        {
            try
            {
                this.txtIdPersonaAgenda.Text = Id;
                this.txtIdPersonaEnfermedades.Text = Id;



            }
            catch (Exception ex)
            {
                MostrarMensajeDeError(ex);
            }
        }


        private void ObtenerAgendaTelefonica(string Id)
        {
            try
            {
                CN_AgendaTelefonica objetoCN = new CN_AgendaTelefonica();
                this.dataAgenda.DataSource = objetoCN.MostrarAgenda(Id); ;
            }
            catch (Exception ex)
            {
                this.MostrarMensajeDeError(ex);
            }
        }

        private void ObtenerEnfermedadesPorPersona(string Id)
        {
            try
            {
                CN_Emfermedades objetoCN = new CN_Emfermedades();
                this.dataEnfermedadesPersona.DataSource = objetoCN.MostrarEnfermedadesPorPersona(Id);
            }
            catch (Exception ex)
            {
                this.MostrarMensajeDeError(ex);
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtNumeroTelefonico.Text == string.Empty)
                {
                    MessageBox.Show("Campo se encuentra vacio", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (this.txtNumeroTelefonico.Text != string.Empty)
                {
                    int CantidadCaracteres = this.txtNumeroTelefonico.Text.Length;
                    if (CantidadCaracteres < 8)
                    {
                        MessageBox.Show("Numero incompleto", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        if (NumeroTelefonicoExiste(dataAgenda, this.txtNumeroTelefonico.Text, "Numero"))
                        {
                            MessageBox.Show("El número de teléfono ya existe en la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else
                        {
                            CN_AgendaTelefonica objetoCN = new CN_AgendaTelefonica();
                            objetoCN.Insertar(this.txtIdPersonaAgenda.Text, this.cmbMedio.Text, this.cmbCompañia.Text, this.txtNumeroTelefonico.Text);
                            MessageBox.Show("Numero Telefonico Guardado Correctamente","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            this.ObtenerAgendaTelefonica(this.txtIdPersonaAgenda.Text);
                            this.cmbMedio.Text = "CELULAR";
                            this.cmbCompañia.Text = "CLARO";
                            this.txtNumeroTelefonico.Text = string.Empty;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                this.MostrarMensajeDeError(ex);
            }
        }

        private bool NumeroTelefonicoExiste(DataGridView dgv, string numeroTelefono, string nombreColumna)
        {
            foreach (DataGridViewRow fila in dgv.Rows)
            {
                // Asegurarse de que la fila no sea nueva o esté vacía.
                if (!fila.IsNewRow)
                {
                    // Comparar el valor de la columna con el número telefónico.
                    if (fila.Cells[nombreColumna].Value?.ToString() == numeroTelefono)
                    {
                        return true; // El número ya existe.
                    }
                }
            }
            return false; // El número no se encontró.
        }


        private void txtNumeroTelefonico_TextChanged(object sender, EventArgs e)
        {
            ValidarNumeroCelular(txtNumeroTelefonico);
        }

        private void txtNumeroTelefonico_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarEntradaNumerica(e, txtNumeroTelefonico, 8);
        }

        private void dataAgenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataAgenda.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    // Mostrar cuadro de diálogo de confirmación
                    DialogResult result = MessageBox.Show("¿Deseas eliminar este registro?",
                                                          "Confirmación de Eliminación",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        CN_AgendaTelefonica objetoCN = new CN_AgendaTelefonica();
                        objetoCN.Eliminar(this.dataAgenda.CurrentRow.Cells["Id_agenda"].Value.ToString());
                        this.ObtenerAgendaTelefonica(this.txtIdPersonaAgenda.Text);
                    }
                    else
                    {
                        MessageBox.Show("El registro no se eliminó.",
                                        "Operación Cancelada",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }



                }
            }
            catch (Exception ex)
            {
                MostrarMensajeDeError(ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MostrarMensajeDeError(ex);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.MostrarEmfermedades();
            }
            catch (Exception ex)
            {
                MostrarMensajeDeError(ex);
            }
        }

        private void dataEmfermedades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataEmfermedades.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                    // Mostrar cuadro de diálogo de confirmación
                    DialogResult result = MessageBox.Show("Estas seguro de Agregar",
                                                          "Confirmación",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {

                        CN_Emfermedades objetoCN = new CN_Emfermedades();
                        objetoCN.Insertar(this.txtIdPersonaEnfermedades.Text, this.dataEmfermedades.CurrentRow.Cells["IdEmfermedad"].Value.ToString());
                        this.ObtenerEnfermedadesPorPersona(this.txtIdPersonaEnfermedades.Text);
                        MessageBox.Show("Registrado correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.tabControl1.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("No se realizo el Registro.",
                                        "Operación Cancelada",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }



                }
            }
            catch (Exception ex)
            {
                MostrarMensajeDeError(ex);
            }
        }

        private void dataEnfermedadesPersona_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataEnfermedadesPersona.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    // Mostrar cuadro de diálogo de confirmación
                    DialogResult result = MessageBox.Show("¿Deseas eliminar este registro?",
                                                          "Confirmación de Eliminación",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {

                        CN_Emfermedades objeto = new CN_Emfermedades();
                        objeto.Eliminar(this.dataEnfermedadesPersona.CurrentRow.Cells["IdHistorialEnfermedades"].Value.ToString());
                        this.ObtenerEnfermedadesPorPersona(this.txtIdPersonaEnfermedades.Text);
                        MessageBox.Show("Eliminado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("El registro no se eliminó.",
                                        "Operación Cancelada",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }



                }
            }
            catch (Exception ex)
            {
                MostrarMensajeDeError(ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Mostrar cuadro de diálogo de confirmación
                DialogResult result = MessageBox.Show("Seleccione 'Sí' para realizar un registro completo o 'No' para registrar solo datos personales.",
                                              "Confirmación de Tipo de Registro",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string IdPersonaEstudiante = this.txtIdPersonaAgenda.Text;
                    CN_Estudiantes objetoCN = new CN_Estudiantes();
                    DataTable tabla = new DataTable();
                    tabla = objetoCN.BuscarEstudianteSiExtiste(this.txtIdPersonaAgenda.Text);
                    if (tabla.Rows.Count == 0)
                    {
                        string FechaActual = DateTime.Now.ToShortDateString();
                        string AñoActual = DateTime.Now.Year.ToString();

                        objetoCN.InsertarEstudiante(IdPersonaEstudiante, "00000000000", FechaActual, FechaActual, null, CacheUsuario.IdSucursal, "3");


                        Frm_Nueva_Matricula frm = new Frm_Nueva_Matricula();
                        frm.Show();
                        this.Hide();

                    }else if (tabla.Rows.Count != 0)
                    {
                        MessageBox.Show("Ya existe un Estudiante","SISTEMA CECNIC",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("Registrado correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }

            }
            catch (Exception ex)
            {
                MostrarMensajeDeError(ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                this.Edicion =  true;
                this.tabControl1.SelectedIndex = 2;
            }
            catch (Exception ex)
            {
                MostrarMensajeDeError(ex);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                CN_Personas objetoCN = new CN_Personas();
                this.dataPersonas.DataSource = objetoCN.MostrarPersonasPorNombres(this.txtBusqueda.Text);
            }
            catch (Exception ex)
            {
                MostrarMensajeDeError(ex);
            }
        }

        private void dataPersonas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataPersonas.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                    this.txtIdPersona.Text = this.dataPersonas.CurrentRow.Cells["Id_persona"].Value.ToString();
                    this.txtIdPersonaAgenda.Text = this.dataPersonas.CurrentRow.Cells["Id_persona"].Value.ToString();
                    this.txtIdPersonaEnfermedades.Text = this.dataPersonas.CurrentRow.Cells["Id_persona"].Value.ToString();

                    this.txtNombres.Text = this.dataPersonas.CurrentRow.Cells["Nombres"].Value.ToString();
                    this.txtApellidos.Text = this.dataPersonas.CurrentRow.Cells["Apellidos"].Value.ToString();
                    this.txtcedula.Text = this.dataPersonas.CurrentRow.Cells["Cedula"].Value.ToString();
                    this.txtcorreo.Text = this.dataPersonas.CurrentRow.Cells["Correo"].Value.ToString();
                    this.cmbGenero.Text = this.dataPersonas.CurrentRow.Cells["Genero"].Value.ToString();
                    this.cmbDepartamento.Text = this.dataPersonas.CurrentRow.Cells["Departamento"].Value.ToString();
                    this.cmbCiudad.Text = this.dataPersonas.CurrentRow.Cells["Ciudad"].Value.ToString();
                    this.cmbTipoSangre.Text = this.dataPersonas.CurrentRow.Cells["TipoSangre"].Value.ToString();
                    this.txtDireccion.Text = this.dataPersonas.CurrentRow.Cells["Direccion"].Value.ToString();
                    this.cmbNivelAcademico.Text = this.dataPersonas.CurrentRow.Cells["Descripcion"].Value.ToString();
                    this.txtCentroTrabajo.Text = this.dataPersonas.CurrentRow.Cells["Centro_Trabajo"].Value.ToString();
                    this.txtCelularTrabajo.Text = this.dataPersonas.CurrentRow.Cells["Celular_Trabajo"].Value.ToString();
                    this.txtOcupacion.Text = this.dataPersonas.CurrentRow.Cells["Ocupacion"].Value.ToString();
                    this.txtLlamarA.Text = this.dataPersonas.CurrentRow.Cells["NombreTutor"].Value.ToString();
                    this.txtCelularTutor.Text = this.dataPersonas.CurrentRow.Cells["CelularTutor"].Value.ToString();
                    this.txtParentesco.Text = this.dataPersonas.CurrentRow.Cells["Parentesco"].Value.ToString();
                    this.dtpFechaNacimiento.Text = this.dataPersonas.CurrentRow.Cells["FechaNacimiento"].Value.ToString();
                   
                    this.groupBox1.Enabled = true;
                    this.groupBox2.Enabled = true;
                    this.groupBox3.Enabled = true;

                    this.HabilitarControles();
                    this.txtcedula.Enabled = true;

                    this.ObtenerAgendaTelefonica(this.txtIdPersonaAgenda.Text);
                    this.ObtenerEnfermedadesPorPersona(this.txtIdPersonaEnfermedades.Text);
                    this.tabControl1.SelectedIndex = 0;

                }
            }
            catch (Exception ex)
            {
                MostrarMensajeDeError(ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                // Cerrar el formulario actual
                this.Close();

                // Crear una nueva instancia de Frm_DatosGenerales
                Frm_DatosGenerales nuevoFormulario = new Frm_DatosGenerales();

                // Mostrar el nuevo formulario
                nuevoFormulario.Show();

                // Liberar los recursos del formulario anterior
                this.Dispose();
            }
            catch (Exception ex)
            {
                MostrarMensajeDeError(ex);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MostrarMensajeDeError(ex);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                this.ConectarDB();
            }
            catch (Exception ex)
            {
                MostrarMensajeDeError(ex);
            }
        }

        private async void ConectarDB()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                // Mostrar la barra de progreso
                this.Invoke(new Action(() =>
                {
                    this.progressBar1.Visible = true;
                    this.progressBar1.Style = ProgressBarStyle.Marquee; // Modo de barra de progreso indeterminado
                    this.progressBar1.MarqueeAnimationSpeed = 30; // Ajustar la velocidad de la animación
                }));

                // Ejecutar la consulta de manera asincrónica
                await Task.Run(() =>
                {
                    // Abrir la conexión
                    connection.Open();

                    // Usar parámetros en la consulta para evitar SQL Injection y mejorar rendimiento
                    string query = @"SELECT a.codigo_referencia,a.fecha_registro,a.nombres,a.apellidos,a.correo,a.tiposangre,a.direccion,a.ocupacion,a.NombreTutor,a.CelularTutor,a.parentesco,
                    a.NombreCurso,a.Turno,a.Horario,a.FechaInicio,a.FechaNacimiento,a.Cedula,a.Observaciones,a.OrigenMatricula,a.genero FROM Estudiantes a JOIN Ejecutivos b ON a.idEjecutivo = b.idEjecutivo
                    WHERE a.codigo_referencia = @CodigoReferencia";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@CodigoReferencia", this.txtBusquedaRef.Text);

                    // Ejecutar la consulta y obtener un MySqlDataReader
                    MySqlDataReader reader = cmd.ExecuteReader();

                    // Leer los resultados de la consulta
                    if (reader.Read())
                    {
                        // Almacenar los datos en variables locales
                        string CodigoReferencia = reader.GetString(0);
                        string FechaRegistro = Convert.ToString(reader.GetDateTime(1));
                        string Nombres = reader.GetString(2);
                        string Apellidos = reader.GetString(3);
                        string Correo = reader.GetString(4);
                        string TipoSangre = reader.GetString(5);
                        string Direccion = reader.GetString(6);
                        string Ocupacion = reader.GetString(7);
                        string NombreTutor = reader.GetString(8);
                        string CelularTutor = reader.GetString(9);
                        string Parentesco = reader.GetString(10);
                        string NombreCurso = reader.GetString(11);
                        string Turno = reader.GetString(12);
                        string Horario = reader.GetString(13);
                        string FechaInicio = Convert.ToString(reader.GetDateTime(14));
                        string FechaNacimiento = Convert.ToString(reader.GetDateTime(15));
                        string Cedula = reader.GetString(16);
                        string Observaciones = reader.GetString(17);
                        string OrigenMatricula = reader.GetString(18);
                        string Genero = reader.GetString(19);



                        // Actualizar la UI con los datos obtenidos, usando Invoke para hilo principal
                        this.Invoke(new Action(() =>
                        {
                            this.txtNombres.Text = Nombres.ToUpper();
                            this.txtApellidos.Text = Apellidos.ToUpper();
                            //this.txtcorreo.Text = Correo.ToUpper();
                            this.cmbGenero.Text = Genero.ToUpper();
                            this.cmbTipoSangre.Text = TipoSangre.ToUpper();
                            this.txtDireccion.Text = Direccion.ToUpper();
                            this.txtOcupacion.Text = Ocupacion.ToUpper();
                            this.txtLlamarA.Text = NombreTutor.ToUpper();
                            this.txtParentesco.Text = Parentesco.ToUpper();
                            this.txtCelularTutor.Text = CelularTutor;
                            this.txtcedula.Text =  Cedula.ToUpper();
                            this.dtpFechaNacimiento.Text = FechaNacimiento;


                            CacheDetalleMatricula.NombreEstudianteOnline = Convert.ToString(reader.GetString(2) + " " + reader.GetString(3)).ToUpper();
                            CacheDetalleMatricula.NombreCursoOnline = NombreCurso;
                            CacheDetalleMatricula.TurnoOnline = Turno;
                            CacheDetalleMatricula.HorarioOnline = Horario;
                            CacheDetalleMatricula.FechaInicioOnline = FechaInicio;
                            CacheDetalleMatricula.OrigenMatriculaOnline = OrigenMatricula;
                            CacheDetalleMatricula.ObservacionesOnline = Observaciones;



                            // Cambiar la pestaña del tabControl al primer índice
                            this.HabilitarControles();
                            this.tabControl1.SelectedIndex = 0;
                            NotificacionMatriculaONLINE frm = new NotificacionMatriculaONLINE();
                            frm.ShowDialog();
                 
                        }));
                    }

                    reader.Close(); // Cerrar el lector cuando ya no sea necesario
                });
            }
            catch (Exception ex)
            {
                // Mostrar error
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
            finally
            {
                // Asegurarse de cerrar la conexión
                connection.Close();

                // Ocultar la barra de progreso cuando la operación haya terminado
                this.Invoke(new Action(() =>
                {
                    this.progressBar1.Visible = false;
                    this.txtBusquedaRef.Text = string.Empty;

                }));
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Edicion = false;
                this.tabControl1.SelectedIndex = 3;
            }
            catch (Exception ex)
            {
                MostrarMensajeDeError(ex);
            }
        }
    }
}
