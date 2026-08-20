using CapaDatos;
using CapaNegocio;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using Utils;
using System.Drawing;


namespace CaoaPresentacion
{
    public partial class Frm_Nueva_Matricula : Form
    {

        CD_Conexion conexion = new CD_Conexion();
        string VariableCarnet;
        string NuevaModificacionCarnet;
        bool Continuar = false;
        string TipoMatricula;





        /*Obetnemos el Valor de la Moneda*/
        string ValorMoneda;
        string IdMoneda;

        string VariableProgramacion;
        string IdMatricula;
        string Fecha = Convert.ToString(DateTime.Now.ToShortDateString());
        double ProporcionalCancelar;

        int numero;

        public Frm_Nueva_Matricula()
        {
            InitializeComponent();
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTipoMatricula.DropDownStyle = ComboBoxStyle.DropDownList;


            this.Cargar_ComboEjecutivo();
            this.Cargar_ComboDocente();
            this.Cargar_ComboMoneda();
            DataGridViewConfigurator.Configure(dataEstudiantes);
        }

        private void Frm_Nueva_Matricula_Load(object sender, EventArgs e)
        {
            try
            {
                this.Habiltar();
                this.Continuar = false;
                this.MostrarPagosAbonados();
                this.label8.Visible = false;
                this.cmbTipoMatricula.Text = "NUEVO INGRESO";
                this.comboBox1.Text = "Recepcion";
                this.AgregarColumnaConIcono();
                this.checkBox1.Checked = false;
                this.dpFechaEstudiante.Text = DateTime.Now.ToShortDateString();
               

                this.FormClosed += new FormClosedEventHandler(cerrarform);
                //this.Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema" + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }


      


        private void MostrarEstudiante()
        {
            CN_Estudiantes objetoCN = new CN_Estudiantes();
            this.dataEstudiantes.DataSource = objetoCN.MostrarEstudiantes(this.txtbusqueda.Text, this.dpFechaEstudiante.Value);

        }

        private void MostrarEstudianteEspecifico()
        {
            CN_Estudiantes objetoCN = new CN_Estudiantes();
            this.dataEstudiantes.DataSource = objetoCN.MostrarEstudiantesEspecifico(this.txtbusqueda.Text);

        }

        private void AgregarColumnaConIcono()
        {
            try
            {
                // Movimientos
                DataGridViewButtonColumn btnColumna = new DataGridViewButtonColumn();
                btnColumna.HeaderText = "Seleccionar";
                btnColumna.Name = "Seleccionar";
                btnColumna.UseColumnTextForButtonValue = false;
                btnColumna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                btnColumna.Width = 70; // 👈 ancho fijo
                dataEstudiantes.Columns.Add(btnColumna);


                // Evento para dibujar iconos
                dataEstudiantes.CellPainting += dataEstudiantes_CellPainting;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarPagosAbonados()
        {
            CN_ActualizacionDatos objCN = new CN_ActualizacionDatos();
            this.dataGridView1.DataSource = objCN.Mostrar();
        }

        private void Habiltar()
        {
            this.btnNuevo.Enabled = true;
            this.button1.Enabled = false;
            this.button2.Enabled = false;
            this.button3.Enabled = false;
            this.button4.Enabled = false;
            this.dateTimePicker1.Enabled = false;
            this.comboBox1.Enabled = false;
            this.comboBox3.Enabled = false;
            this.groupBox1.Enabled = false;
            this.cmbTipoMatricula.Enabled = false;
            this.txtObservaciones.Enabled = false;

        }

        private void Inhabilitar()
        {
            this.btnNuevo.Enabled = false;
            this.button1.Enabled = true;
            this.button2.Enabled = true;
            this.button3.Enabled = true;
            this.button4.Enabled = true;
            this.dateTimePicker1.Enabled = true;
            this.comboBox1.Enabled = true;
            this.cmbTipoMatricula.Enabled = true;
            this.txtObservaciones.Enabled = true;


            this.comboBox3.Enabled = true;
            this.groupBox1.Enabled = true;
        }

        private void cerrarform(object sender, EventArgs e)
        {
            DatosAlmacenados objeto = new DatosAlmacenados();
            objeto.LimpiarDatos();
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.MostrarEstudiante();
            this.tabControl1.SelectedTab = tabEstudiante;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Formularios_Vistas.Frm_VistaGrupos frm = new Formularios_Vistas.Frm_VistaGrupos();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show(
             "¿Deseas continuar?, verifica que sea el grupo correcto",  // Mensaje
             "Confirmación",                // Título
            MessageBoxButtons.YesNo,       // Botones: Sí y No
            MessageBoxIcon.Question        // Ícono de pregunta
            );

                if (resultado == DialogResult.Yes)
                {
                    this.IniciarProcesoMatricula();
                }
                else
                {
                    Formularios_Vistas.Frm_VistaGrupos frm = new Formularios_Vistas.Frm_VistaGrupos();
                    frm.Show();
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void IniciarProcesoMatricula()
        {
            try
            {
                // Limpiar errores previos
                errorProvider1.Clear();

                bool hayError = false;

                // Validaciones con ErrorProvider
                if (string.IsNullOrWhiteSpace(this.txtnombreCompleto.Text))
                {
                    errorProvider1.SetError(txtnombreCompleto, "Debe ingresar el nombre completo.");
                    hayError = true;
                }

                if (string.IsNullOrWhiteSpace(this.txtnombrecurso.Text))
                {
                    errorProvider1.SetError(txtnombrecurso, "Debe ingresar el nombre del curso.");
                    hayError = true;
                }

                if (this.txtempleado.Text == "Selecciona un Ejecutivo")
                {
                    errorProvider1.SetError(txtempleado, "Debe seleccionar un ejecutivo.");
                    hayError = true;
                }

                if (this.comboBox3.Text == "Selecciona un Docente")
                {
                    errorProvider1.SetError(comboBox3, "Debe seleccionar un docente.");
                    hayError = true;
                }

                // Si hubo errores, no continuar
                if (hayError) return;

                // Validar si tipo de matrícula es válido
                if (this.comboBox1.Text != "Recepcion" &&
                    this.comboBox1.Text != "Ejecutivo de Venta" &&
                    this.comboBox1.Text != "Relaciones Publicas")
                {
                    errorProvider1.SetError(comboBox1, "Debe seleccionar un tipo de matrícula válido.");
                    return;
                }

                // Validar duración
                if (this.txtduracion.Text == "0")
                {
                    MessageBox.Show("Lo siento, curso sin duración definida. Cierre la ventana y modifique duración diferente de cero.",
                        "SISTEMA CECNIC",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    this.Habiltar();
                    this.Limpiar();

                    DatosAlmacenados objeto = new DatosAlmacenados();
                    objeto.LimpiarDatos();
                    this.IdMatricula = string.Empty;
                    return;
                }

                // Proceso con estudiante
                CN_Estudiantes objetoEstudiante = new CN_Estudiantes();
                DataTable tablaEstudiante = objetoEstudiante.Buscar_ModificacionCarnet(this.txtidestudiante.Text);

                DateTime Fecha1 = Convert.ToDateTime(this.dateTimePicker1.Text);
                DateTime Fecha2 = Convert.ToDateTime(this.dateTimePicker2.Text);
                string HoraRegistro = DateTime.Now.ToShortTimeString();

                if (Fecha1 < Fecha2)
                {
                    errorProvider1.SetError(dateTimePicker1, "La fecha de inicio no puede ser menor a la fecha de registro de matrícula.");
                    return;
                }

                if (tablaEstudiante.Rows.Count != 0)
                {
                    // Estudiante existente: actualizar carnet
                    this.GenerarCarnet();
                    GenerarCarnetEstudiante();
                    CacheValoresCodigos.NuevoCambioCarnet = NuevaModificacionCarnet;
                    objetoEstudiante.ModificarCarnet(this.txtidestudiante.Text, NuevaModificacionCarnet);
                    CN_Matriculas ObjetoCN = new CN_Matriculas();

                   int IdMatricula = ObjetoCN.InsertarMatricula(VariableCarnet, this.dateTimePicker1.Value,Convert.ToInt32(this.txtidestudiante.Text),
                        this.comboBox1.Text, this.txtempleado.Text,Convert.ToInt32(CacheDatos.Id_Grupo),Convert.ToInt32(CacheUsuario.IdUsuario),3,
                        this.txtObservaciones.Text,
                        this.cmbTipoMatricula.Text, "Confirmado");

                   
                    MessageBox.Show("Matrícula guardada correctamente.",
                        "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.RealizarProcesoMatricula(IdMatricula);
                }
                else
                {
                    // Nuevo estudiante
                    this.GenerarCarnet();
                    CN_Matriculas ObjetoCN = new CN_Matriculas();
                    int IdMatricula = ObjetoCN.InsertarMatricula(VariableCarnet, this.dateTimePicker1.Value, Convert.ToInt32(this.txtidestudiante.Text),
                        this.comboBox1.Text, this.txtempleado.Text, Convert.ToInt32(CacheDatos.Id_Grupo), Convert.ToInt32(CacheUsuario.IdUsuario), 3,
                        this.txtObservaciones.Text,
                        this.cmbTipoMatricula.Text, "Pendiente");

                    MessageBox.Show("Matrícula guardada correctamente.",
                        "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.RealizarProcesoMatricula(IdMatricula);
                }

               
            }
            catch (Exception)
            {
                MessageBox.Show("Error en el sistema: ",
                    "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /*En este Fragnento de Codigo se genera la programacion de Pagos*/

        private void GenerarProgramaciondePago()
        {
            CN_ProgramacionPagos objetoCN = new CN_ProgramacionPagos();
            this.GenerarNumProgramacion();
            int Dia = DateTime.Now.Day;
            double TotalMonto = Convert.ToDouble(this.txtduracion.Text) * Convert.ToDouble(this.txtMensualidad.Text) * Convert.ToDouble(this.ValorMoneda);

            this.IdMoneda = this.txtidmoneda.Text;
            objetoCN.Insertar(VariableProgramacion, VariableCarnet, "11", Dia.ToString(), TotalMonto.ToString(), this.IdMoneda, "17", "0", "10", TotalMonto.ToString());

        }

        /*finaliza codigo*/

        private void generarcodigo()
        {
            //creando una instancia de random
            Random aleatorio = new Random();
            numero = aleatorio.Next(1, 99999999);
        }

        private void InsertarFactMatc()
        {
            try
            {
                CN_Factura_Matricula objetoCN = new CN_Factura_Matricula();
                this.generarcodigo();
                DateTime fecha1 = DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                CacheDatos.CodigoMatricula_VentanaFactura = numero.ToString();
                objetoCN.Insertar(fecha1, VariableCarnet, numero.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("");
            }
        }


        /*Genera el COdigo Programacion*/



        private void GenerarNumProgramacion()
        {
            try
            {
                CN_ProgramacionPagos objetoCN = new CN_ProgramacionPagos();

                DataTable Tabla = new DataTable();
                Tabla = objetoCN.MostrarNumeroProgramacion();
                VariableProgramacion = Tabla.Rows[0][0].ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /**/

        /*Codigo que genera todos los detalles de programacion de Pagos de una Matricula*/


        private void GenerarDetalles_ProgramacionPago()
        {
            double MontoMensualidad = Convert.ToDouble(this.txtMensualidad.Text);
            double ValorMoneda = Convert.ToDouble(this.txtValorMoneda.Text);
            double MontoEnCordobas = MontoMensualidad * ValorMoneda;
            int DuracionCurso = Convert.ToInt32(this.txtduracion.Text);
            double PropSem = MontoEnCordobas / 4;
            int diaActual = Convert.ToDateTime(this.dateTimePicker1.Text).Day;
            int MesActual = Convert.ToDateTime(this.dateTimePicker1.Text).Month;
            int AñoActual = Convert.ToDateTime(this.dateTimePicker1.Text).Year;

            // Calcular el monto proporcional a cancelar
            if (diaActual >= 1 && diaActual <= 7)
            {
                ProporcionalCancelar = MontoEnCordobas;
            }
            else if (diaActual >= 8 && diaActual <= 15)
            {
                ProporcionalCancelar = MontoEnCordobas - PropSem;
            }
            else if (diaActual >= 16 && diaActual <= 22)
            {
                ProporcionalCancelar = MontoEnCordobas - (PropSem * 2);
            }
            else if (diaActual >= 23)
            {
                ProporcionalCancelar = MontoEnCordobas - (PropSem * 3);
            }
            CN_Detalle_Programacion objetoCN = new CN_Detalle_Programacion();
            // Insertar el pago proporcional
            objetoCN.Insertar(
                VariableProgramacion,
                Convert.ToDateTime(this.dateTimePicker1.Text).ToShortDateString(),
                "PROPORCIONAL, " + ObtenerNombreMes(MesActual).ToUpper() + " " + AñoActual,
                this.ProporcionalCancelar.ToString(),
                "1",
                Convert.ToDateTime(this.dateTimePicker1.Text).ToShortDateString(),
                "0",
                "10"
            );

            // Inicializar variables para iterar
            int Dia_Limite = 7;
            int MesSiguiente = MesActual;
            int Año = AñoActual;

            // Determinar el número de iteraciones (si inicia en el mismo mes o al siguiente)
            int inicioIteracion = (diaActual >= 1 && diaActual <= 7) ? 1 : 0;

            for (int i = inicioIteracion; i < DuracionCurso; i++)
            {
                // Incrementar el mes
                MesSiguiente++;

                // Si el mes es mayor a 12, reiniciar a enero y aumentar el año
                if (MesSiguiente > 12)
                {
                    MesSiguiente = 1; // Volver a enero
                    Año++; // Aumentar el año
                }
             
                // Insertar los detalles de mensualidad
                objetoCN.Insertar(
                    VariableProgramacion,
                    $"{Año}-{MesSiguiente.ToString("D2")}-{Dia_Limite}",
                    $"MENSUALIDAD, {this.ObtenerNombreMes(MesSiguiente).ToUpper()} {Año}",
                    MontoMensualidad.ToString(),
                    IdMoneda,
                    $"{Año}-{MesSiguiente.ToString("D2")}-{Dia_Limite}",
                    "0",
                    "10"
                );
            }
        }


        public string ObtenerNombreMes(int numeroMes)
        {
            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };

            if (numeroMes >= 1 && numeroMes <= 12)
            {
                return meses[numeroMes - 1];
            }
            else
            {
                return "Mes inválido";
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Nueva_Matricula frm = new Frm_Nueva_Matricula();
                frm.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

         
        }

        private void Limpiar()
        {
            this.comboBox1.Text = "Recepcion";
            this.Cargar_ComboDocente();

            CacheDatos.Id_Estudiante = string.Empty;
            CacheDatos.Id_Grupo = string.Empty;
            this.dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            this.txtnombreCompleto.Text = string.Empty;
            this.txtcarnet.Text = string.Empty;
            this.txtidestudiante.Text = string.Empty;
            CacheDatos.Contador = false;
            this.dateTimePicker2.Text = DateTime.Now.ToLongDateString();
            this.txtnombrecurso.Text = string.Empty;
            this.txtduracion.Text = string.Empty;
            this.txtturno.Text = string.Empty;
            this.txtdias.Text = string.Empty;
            this.txthorario.Text = string.Empty;
            this.txtcodDocente.Text = string.Empty;
            this.txtNombreDocente.Text = string.Empty;
            this.txtApellidoocente.Text = string.Empty;
            this.txtidcurso.Text = "0";
            this.groupBox1.Enabled = true;
            this.cmbTipoMatricula.Text = "NUEVO INGRESO";
            this.txtObservaciones.Text = string.Empty;





            DatosAlmacenados objeto = new DatosAlmacenados();
            objeto.LimpiarDatos();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                switch (CacheDatos.Contador)
                {
                    case true:
                        this.txtidestudiante.Text = CacheDatos.Id_Estudiante;
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

        private void txtidestudiante_TextChanged(object sender, EventArgs e)
        {

            CD_Conexion conexion = new CD_Conexion();
            conexion.AbrirConexion();
            SqlCommand cm = new SqlCommand("select a.Id_estudiante,a.Cod_carnet,b.Nombres,b.Apellidos,a.Fecha_Ingreso,a.Fecha_Finalizacion,c.NombreSucursal,d.Estado from Tbl_Estudiantes a join Tbl_Personas b on a.Id_persona = b.Id_persona join TblSucursales c on a.Id_sucursal = c.Id_sucursal join Tbl_Estados d on  a.Id_estado = d.Id_estado where a.Id_estudiante = '" + this.txtidestudiante.Text + "'", conexion.Conexion());
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read() == true)
            {
                this.txtnombreCompleto.Text = dr["Nombres"].ToString() + " " + dr["Apellidos"].ToString();
                this.txtcarnet.Text = dr["Cod_carnet"].ToString();
            }
            conexion.CerrarConexion();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            CD_Conexion conexion = new CD_Conexion();
           conexion.AbrirConexion();
            SqlCommand cm = new SqlCommand("select a.Id_Grupo, f.Nombre_curso, f.Duracion, b.Precio,h.ValorMoneda, b.IdMoneda, h.Descripcion, g.Turno, g.Dias, c.Horario, d.Cod_Carnet, e.Nombres, e.Apellidos, a.Id_Curso_turno, a.Id_Horario, a.Id_empleado, f.Id_curso from Tbl_Grupos a join Tbl_Curso_Turnos b on a.Id_Curso_turno = b.Id_Curso_turno join Tbl_Horarios c on a.Id_Horario = c.Id_Horario join Tbl_Empleados d on a.Id_empleado = d.Id_empleado join Tbl_Personas e on d.Id_persona = e.Id_persona join Tbl_Cursos f on f.Id_Curso = b.Id_Curso join Tbl_Turnos g on b.Id_turno = g.Id_turno join Tbl_TipoMoneda h on h.IdMoneda = b.IdMoneda where a.Id_Grupo = '" + textBox1.Text + "'", conexion.Conexion());
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read() == true)
            {
                this.txtnombrecurso.Text = dr["Nombre_curso"].ToString();
                this.txtduracion.Text = dr["Duracion"].ToString();
                this.txtturno.Text = dr["Turno"].ToString();
                this.txtdias.Text = dr["Dias"].ToString();
                this.txthorario.Text = dr["Horario"].ToString();
                this.txtcodDocente.Text = dr["Cod_Carnet"].ToString();
                this.txtNombreDocente.Text = dr["Nombres"].ToString();
                this.txtApellidoocente.Text = dr["Apellidos"].ToString();
                this.txtidcurso.Text = dr["Id_curso"].ToString();
                this.txtMensualidad.Text = dr["Precio"].ToString();
                this.comboBox2.Text = dr["Descripcion"].ToString();
                this.ValorMoneda = dr["ValorMoneda"].ToString();

            }
            conexion.CerrarConexion();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                switch (CacheDatos.Contador2)
                {
                    case true:
                        this.textBox1.Text = CacheDatos.Id_Grupo;
                        break;

                    case false:
                        break;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de sistema ");
            }
        }

        private void txtidcurso_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CN_ModulosCurso objetoCN = new CN_ModulosCurso();

                this.dataModulos.DataSource = objetoCN.MostrarModulos(this.txtidcurso.Text);

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void GenerarCarnet()
        {
            try
            {
                CN_Matriculas objetoCN = new CN_Matriculas();

                DataTable Tabla = new DataTable();
                Tabla = objetoCN.ObtenerNumeroMatricula();
                VariableCarnet = Tabla.Rows[0][0].ToString();

                CacheDatos.Codigo_Matricula_Exp = Tabla.Rows[0][0].ToString();



            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Recepcion")
            {
                this.txtempleado.Enabled = false;
                this.txtempleado.DropDownStyle = ComboBoxStyle.Simple;
                this.txtempleado.Text = "Recepcion";

                this.TipoMatricula = "Recepcion";
                this.label8.Visible = false;

                CN_Aranceles objetoArancel = new CN_Aranceles();
                DataTable tabla = new DataTable();
                tabla = objetoArancel.MostrarInformacionArancel(8);
                if (tabla.Rows.Count != 0)
                {
                    CacheDatos.IdArancel = tabla.Rows[0][0].ToString();
                    CacheDatos.NombreArancel = tabla.Rows[0][1].ToString();
                    CacheDatos.Precio = tabla.Rows[0][2].ToString();
                    CacheDatos.IdMoneda = tabla.Rows[0][3].ToString();
                    CacheDatos.ValorMoneda = tabla.Rows[0][4].ToString();
                }
                CacheDatos.OrigenMatricula = "RECEPCION";


            }
            else if (comboBox1.Text == "Ejecutivo de Venta")
            {
                this.txtempleado.Enabled = true;
                this.Cargar_ComboEjecutivo();
                this.txtempleado.DropDownStyle = ComboBoxStyle.DropDownList;

                this.TipoMatricula = "Ejecutivo";
                this.label8.Visible = true;

               

                CacheDatos.OrigenMatricula = "EJECUTIVO";
            }
            else if (comboBox1.Text == "Relaciones Publicas")
            {
                this.txtempleado.Enabled = false;
                this.txtempleado.DropDownStyle = ComboBoxStyle.Simple;
                this.txtempleado.Text = "Relaciones Publicas";

                this.TipoMatricula = "RelacionPublicas";
                this.label8.Visible = false;

                CN_Aranceles objetoArancel = new CN_Aranceles();
                DataTable tabla = new DataTable();
                tabla = objetoArancel.MostrarInformacionArancel(20);
                if (tabla.Rows.Count != 0)
                {
                    CacheDatos.IdArancel = tabla.Rows[0][0].ToString();
                    CacheDatos.NombreArancel = tabla.Rows[0][1].ToString();
                    CacheDatos.Precio = tabla.Rows[0][2].ToString();
                    CacheDatos.IdMoneda = tabla.Rows[0][3].ToString();
                    CacheDatos.ValorMoneda = tabla.Rows[0][4].ToString();
                }

                CacheDatos.OrigenMatricula = "RELACIONESPUBLICAS";
            }
        }

        private void txtcodigoMat_TextChanged(object sender, EventArgs e)
        {
            CD_Conexion conexion = new CD_Conexion();
            conexion.AbrirConexion();
            SqlCommand cm = new SqlCommand("select * from Tbl_Matricula where Cod_Matricula = '" + this.txtcodigoMat.Text + "'", conexion.Conexion());
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read() == true)
            {
                this.IdMatricula = dr["Id_Matricula"].ToString();

            }
            conexion.CerrarConexion();
            dr.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            this.Inhabilitar();
            this.Limpiar();

        }


        public void Cargar_ComboEjecutivo()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("Select CONCAT(b.Nombres, ' ', b.Apellidos) as Ejecutivo, a.Id_empleado from Tbl_Empleados a join Tbl_Personas b on a.Id_persona = b.Id_persona where a.Tipo_Empleado = 'Ejecutivo de Venta' and a.Id_estado = '3'", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Ejecutivo"] = "Selecciona un Ejecutivo";
                dt.Rows.InsertAt(fila, 0);

                txtempleado.ValueMember = "Id_empleado";
                txtempleado.DisplayMember = "Ejecutivo";
                txtempleado.DataSource = dt;


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public void Cargar_ComboDocente()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("Select CONCAT(b.Nombres, ' ', b.Apellidos) as Ejecutivo, a.Id_empleado from Tbl_Empleados a join Tbl_Personas b on a.Id_persona = b.Id_persona where a.Tipo_Empleado = 'Docente' and a.Id_estado = '3' AND a.Id_empleado = '76'", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                comboBox3.ValueMember = "Id_empleado";
                comboBox3.DisplayMember = "Ejecutivo";
                comboBox3.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void HabilitarBotones()
        {
            if (Continuar == false)
            {
                this.button1.Enabled = true;
                this.button1.Visible = true;


            }
            else if (Continuar == true)
            {
                this.button1.Enabled = false;
                this.button1.Visible = false;


            }
        }

        private void GenerarCarnetEstudiante()
        {
            try
            {
                CN_Estudiantes objetoCN = new CN_Estudiantes();

                DataTable Tabla = new DataTable();
                Tabla = objetoCN.ObtenerCarnetEstudiante();
                NuevaModificacionCarnet = Tabla.Rows[0][0].ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        public void Cargar_ComboMoneda()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("Select IdMoneda,Descripcion from Tbl_TipoMoneda", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Descripcion"] = "Selecciona una Moneda";
                dt.Rows.InsertAt(fila, 0);

                comboBox2.ValueMember = "IdMoneda";
                comboBox2.DisplayMember = "Descripcion";
                comboBox2.DataSource = dt;


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CD_Conexion conexion = new CD_Conexion();
            conexion.AbrirConexion();
            SqlCommand cm = new SqlCommand("select  IdMoneda,ValorMoneda from Tbl_TipoMoneda where IdMoneda = '" + this.comboBox2.SelectedValue + "'", conexion.Conexion());
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read() == true)
            {
                this.txtidmoneda.Text = dr["IdMoneda"].ToString();
                this.txtValorMoneda.Text = dr["ValorMoneda"].ToString();

            }
            conexion.CerrarConexion();
        }

        private void RealizarProcesoMatricula(int IdMatricula)
        {
            try
            {
                string origen = this.TipoMatricula;
                string estado = "0";

                if (this.txtcarnet.Text == "00000000000")
                {
                    // Nuevo ingreso según tipo
                    estado = ObtenerEstadoMatricula(origen);
                    ProcesarMatricula(origen, estado, true,IdMatricula);
                }
                else
                {
                    CN_VerificacionMatricula verificador = new CN_VerificacionMatricula();
                    DataTable tabla = verificador.VerificacionSiCanceloMatricula(this.txtcarnet.Text);

                    if (tabla.Rows.Count == 0) return;

                    int cancelado = Convert.ToInt32(tabla.Rows[0][0]);
                    estado = ObtenerEstadoMatricula(origen);

                    // Cancelado == 0 -> proceso normal, Cancelado != 0 -> proceso con cancelación
                    ProcesarMatricula(origen, estado, cancelado == 0,IdMatricula);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerEstadoMatricula(string tipo)
        {
            string id = "0";
            string codigo = tipo == "Recepcion" ? "1" :
                            tipo == "RelacionPublicas" ? "2" :
                            tipo == "Ejecutivo" ? "3" : "0";

            if (codigo != "0")
            {
                CN_ActivacionMatriculas objetoCN = new CN_ActivacionMatriculas();
                DataTable tabla = objetoCN.MostrarEstadoActivacion(codigo);
                if (tabla.Rows.Count > 0)
                    id = tabla.Rows[0][2].ToString();
            }

            return id;
        }

        private void ProcesarMatricula(string origen, string estado, bool guardarEnCache,int IdMatricula)
        {
            // Generar programaciones y factura
            this.GenerarProgramaciondePago();
            this.GenerarDetalles_ProgramacionPago();
            this.InsertarFactMatc();

            if (guardarEnCache)
            {
                CacheDatos.TipoMatriculaOrigen = origen;
                CacheDatos.IdEstadoMatriculaActivacion = estado;
            }

            CacheDatos.Id_Matricula = IdMatricula.ToString();
            //Obtenemos la Ultima Matricula
            CN_Matriculas objetoCN = new CN_Matriculas();
            DataTable tabla = new DataTable();
            tabla = objetoCN.ObtenerUltimaMatricula();
            if (tabla.Rows.Count != 0)
            {
                CacheDatos.NombreMatricula = tabla.Rows[0][0].ToString();
                CacheDatos.ApellidosMatricula = tabla.Rows[0][1].ToString();
                CacheDatos.CedulaMatricula = tabla.Rows[0][2].ToString();
                CacheDatos.CarnetEstudianteMatricula = tabla.Rows[0][3].ToString();
                CacheDatos.CodMatricula = tabla.Rows[0][4].ToString();
            }

            // Facturación
            Frm_Facturacion frmFact = new Frm_Facturacion();
            CacheDatos.TipoFactura = "NuevaMatricula";
            this.Close();
            this.Dispose();
            frmFact.Show();

            // Limpieza y habilitación
            this.Habiltar();
            this.Limpiar();

            DatosAlmacenados datos = new DatosAlmacenados();
            datos.LimpiarDatos();
            this.IdMatricula = string.Empty;

            CacheDatos.TipoMatriculaOrigen = string.Empty;
            CacheDatos.IdEstadoMatriculaActivacion = string.Empty;

       

            this.Continuar = false;
            this.HabilitarBotones();
        }





        private void txtempleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.txtempleado.Text != "Selecciona un Ejecutivo")
            {
                this.label8.Visible = false;
            }
            else
            {
                this.label8.Visible = true;
            }
        }




        private void txtidmoneda_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataEstudiantes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    Color fondo = Color.White;
                    Bitmap icon = null;

                    if (e.ColumnIndex == dataEstudiantes.Columns["Seleccionar"].Index)
                    {
                        fondo = Color.DodgerBlue; // Azul hielo
                        icon = Properties.Resources.edit_button;
                    }
                    

                    if (icon != null)
                    {
                        // Pintar fondo personalizado
                        using (SolidBrush brush = new SolidBrush(fondo))
                        {
                            e.Graphics.FillRectangle(brush, e.CellBounds);
                        }

                        // Dibujar bordes normales de la celda
                        e.Paint(e.CellBounds, DataGridViewPaintParts.Border);

                        // Tamaño del icono
                        int iconWidth = 16;
                        int iconHeight = 16;

                        // Centrar icono
                        int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                        int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                        e.Graphics.DrawImage(icon, new Rectangle(x, y, iconWidth, iconHeight));

                        e.Handled = true;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Error de Sistema",
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dataEstudiantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (this.dataEstudiantes.Columns[e.ColumnIndex].Name == "Seleccionar")
                {

                   this.txtidestudiante.Text = this.dataEstudiantes.CurrentRow.Cells["Id_estudiante"].Value.ToString();
                    MessageBox.Show("Estudiante Seleccionado Correctamente");

                    this.tabControl1.SelectedTab = tabNuevaMatricula;

                }
              
                

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == false)
            {
               
                this.MostrarEstudiante();
            }
            else if (this.checkBox1.Checked == true)
            {
              
                this.dpFechaEstudiante.Enabled = false;
                this.MostrarEstudianteEspecifico();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.txtbusqueda.Text == string.Empty)
            {
                MessageBox.Show("Por Favor Ingresa el Nombre a Buscar", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (this.checkBox1.Checked == false)
                {

                    this.MostrarEstudiante();
                }
                else if (this.checkBox1.Checked == true)
                {

                    this.dpFechaEstudiante.Enabled = false;
                    this.MostrarEstudianteEspecifico();
                }
            }

        }
    }
}
