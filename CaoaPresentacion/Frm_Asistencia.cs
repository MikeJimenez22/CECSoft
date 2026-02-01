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
    public partial class Frm_Asistencia : Form
    {
        public Frm_Asistencia()
        {
            InitializeComponent();
            this.Cargar_Cursos();
            this.Cargar_Estados();
            this.cmbTurnos.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbEstados.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbBusquedas.DropDownStyle = ComboBoxStyle.DropDownList;

            // Configurar controles de búsqueda
            SetupSearchControls();

            DataGridViewConfigurator.Configure(this.dataMatriculas,this.dataGrupos);


        }

        string Estado;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedIndex = 1;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.cmbTurnos.Text == "Selecciona un Curso")
                {
                    MessageBox.Show("Error, selecciona un curso", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (this.cmbEstados.Text == "Selecciona un Estado")
                {
                    MessageBox.Show("Error, selecciona un estado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CN_Grupos objetoCN = new CN_Grupos();
                    this.dataGrupos.DataSource = objetoCN.MostrarPorGrupoPorEstado(this.cmbEstados.Text, this.cmbTurnos.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_Asistencia_Load(object sender, EventArgs e)
        {
            try
            {
                this.AgregarBtnDatagridView();
                this.cmbEstados.Text = "Activo";
                this.dateFechaActual.Text = DateTime.Now.ToShortDateString();
                this.tabControl1.SelectedIndex = 0;

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Cargar_Cursos()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("Select Id_curso,Nombre_curso from Tbl_Cursos where id_estado = '3' ORDER BY Nombre_curso asc", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Nombre_curso"] = "Selecciona un Curso";
                dt.Rows.InsertAt(fila, 0);

                cmbTurnos.ValueMember = "Id_curso";
                cmbTurnos.DisplayMember = "Nombre_curso";
                cmbTurnos.DataSource = dt;
                
            }
            catch (Exception)
            {
                MessageBox.Show("Error de sistema");
            }
        }

        public void Cargar_Estados()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("select Id_estado,Estado from Tbl_Estados where Id_estado = 3 or Id_estado = 4", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Estado"] = "Selecciona un Estado";
                dt.Rows.InsertAt(fila, 0);

                cmbEstados.ValueMember = "Id_estado";
                cmbEstados.DisplayMember = "Estado";
                cmbEstados.DataSource = dt;


            }
            catch (Exception)
            {
                MessageBox.Show("Error de sistema");
            }
        }

        private void AgregarBtnDatagridView()
        {
            dataGrupos.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Seleccionar",
                Name = "Seleccionar",
                Text = "Seleccionar",
                UseColumnTextForButtonValue = true

            });

            dataEstudiantes.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Seleccionar",
                Name = "Seleccionar",
                Text = "Seleccionar",
                UseColumnTextForButtonValue = true

            });

            

            DataGridViewColumn columna = dataGrupos.Columns["Seleccionar"];
            // Establece el ancho deseado para la columna (en píxeles)
            columna.Width = 70;

            DataGridViewColumn columna2 = this.dataEstudiantes.Columns["Seleccionar"];
            columna2.Width = 60;
            
        }

        private void dataGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataGrupos.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                    this.txtCurso.Text = this.dataGrupos.CurrentRow.Cells["Nombre_curso"].Value.ToString();
                    this.txtNombresDocente.Text = this.dataGrupos.CurrentRow.Cells["Nombres"].Value.ToString();
                    this.txtApellidosDocente.Text = this.dataGrupos.CurrentRow.Cells["Apellidos"].Value.ToString();
                    this.txtTurno.Text = this.dataGrupos.CurrentRow.Cells["Turno"].Value.ToString();
                    this.txtHorario.Text = this.dataGrupos.CurrentRow.Cells["Horario"].Value.ToString();
                    this.txtEstado.Text = this.dataGrupos.CurrentRow.Cells["Estado"].Value.ToString();
                    this.txtIdGrupo.Text = this.dataGrupos.CurrentRow.Cells["Id_Grupo"].Value.ToString();
                    this.MostrarEstudiantesPorGrupo(this.dataGrupos.CurrentRow.Cells["Id_Grupo"].Value.ToString());
                    this.txtIdMoneda.Text = this.dataGrupos.CurrentRow.Cells["IdMoneda"].Value.ToString();
                    this.txtPrecioCurso.Text = this.dataGrupos.CurrentRow.Cells["Precio"].Value.ToString();
                    // Verificar si la columna ComboBox ya existe
                    dataMatriculas.Columns["Id_Matricula"].Visible = false;

                    this.tabControl1.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }

        private void MostrarEstudiantesPorGrupo(string IdGrupo)
        {
            CN_AsistenciaEstudiante objetoCN = new CN_AsistenciaEstudiante();
            this.dataMatriculas.DataSource = objetoCN.MostrarEstudiantesPorGrupo(IdGrupo);
            this.AgregarColumnaData();
        }

        private void AgregarColumnaData()
        {
            try
            {
                // Asegurar que la edición esté activada en el DataGridView
                this.dataMatriculas.ReadOnly = false;
                this.dataMatriculas.AllowUserToAddRows = false;
                this.dataMatriculas.AllowUserToDeleteRows = true;
                this.dataMatriculas.EditMode = DataGridViewEditMode.EditOnEnter;

                // Agregar columna "Estado" como ComboBox
                if (!dataMatriculas.Columns.Contains("Estado"))
                {
                    DataGridViewComboBoxColumn estadoColumn = new DataGridViewComboBoxColumn
                    {
                        Name = "Estado",
                        HeaderText = "Estado",
                        Width = 150
                    };
                    estadoColumn.Items.AddRange("PRESENTE", "AUSENTE","TARDE","JUSTIFICADO","EGRESADO","BAJA","QUITAR");
                    dataMatriculas.Columns.Add(estadoColumn);
                }

                if (!dataMatriculas.Columns.Contains("Comentarios"))
                {
                    DataGridViewTextBoxColumn observacionColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "Comentarios",
                        HeaderText = "Comentarios",
                        Width = 150
                    };
                   dataMatriculas.Columns.Add(observacionColumn);
                }


                // Deshabilitar edición en columnas específicas
                if (dataMatriculas.Columns.Contains("Cod_Matricula")) dataMatriculas.Columns["Cod_Matricula"].ReadOnly = true;
                if (dataMatriculas.Columns.Contains("Nombres")) dataMatriculas.Columns["Nombres"].ReadOnly = true;
                if (dataMatriculas.Columns.Contains("Apellidos")) dataMatriculas.Columns["Apellidos"].ReadOnly = true;

                this.InicializarComboEstado();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InicializarComboEstado()
        {
            foreach (DataGridViewRow row in dataMatriculas.Rows)
            {
                if (!row.IsNewRow) // Evita modificar la última fila vacía (si está activada)
                {
                    row.Cells["Estado"].Value = "AUSENTE";
                }
            }
        }

        private void SetupSearchControls()
        {
            // Configurar controles de búsqueda
            radioButton1.Checked = true; // Puedes considerar si este valor por defecto es necesario
            cmbBusquedas.Text = "Carnet";
            radioButton1.Checked = true; // Igual aquí, verifica si es necesario
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtCurso.Text == string.Empty)
                {
                    MessageBox.Show("Selecciona un Grupo", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }else
                {
                    this.tabControl1.SelectedIndex = 2;
                }
                
            }
            catch(Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.Estado = "3";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.Estado = "4";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtbusqueda.Text == string.Empty)
                {
                    MessageBox.Show("opps!, No hay nada que buscar", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (this.txtbusqueda.Text != string.Empty)
                {
                    if (this.cmbBusquedas.Text == "Carnet")
                    {

                        this.MostrarPorCarnet();

                    }
                    else if (this.cmbBusquedas.Text == "Nombres")
                    {

                        this.MostrarPorNombre();

                    }
                    else if (this.cmbBusquedas.Text == "Apellidos")
                    {

                        this.MostrarPorApellidos();

                    }
                    else if (this.cmbBusquedas.Text == "Codigo Matricula")
                    {

                        this.MostrarPorCodigoMatricula();
                    }

                    dataEstudiantes.Columns["Origen"].Visible = false;
                    dataEstudiantes.Columns["Fecha"].Visible = false;
                    dataEstudiantes.Columns["HoraRegistro"].Visible = false;
                    dataEstudiantes.Columns["Cedula"].Visible = false;
                    dataEstudiantes.Columns["Direccion"].Visible = false;
                    dataEstudiantes.Columns["NombreTutor"].Visible = false;
                    dataEstudiantes.Columns["CelularTutor"].Visible = false;
                    dataEstudiantes.Columns["Parentesco"].Visible = false;
                    dataEstudiantes.Columns["FechaNacimiento"].Visible = false;
                    dataEstudiantes.Columns["Estado"].Visible = false;
                    dataEstudiantes.Columns["Id_Matricula"].Visible = false;
                    dataEstudiantes.Columns["Id_Grupo"].Visible = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void MostrarPorCarnet()
        {
            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            this.dataEstudiantes.DataSource = objetoCN.MostrarPorCarnet(this.txtbusqueda.Text, Estado);

        }

        private void MostrarPorNombre()
        {
            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            this.dataEstudiantes.DataSource = objetoCN.MostrarPorNombre(this.txtbusqueda.Text, Estado);

        }

        private void MostrarPorCodigoMatricula()
        {
            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            this.dataEstudiantes.DataSource = objetoCN.MostrarPorCodMatricula(this.txtbusqueda.Text, Estado);

        }

        private void MostrarPorApellidos()
        {
            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            this.dataEstudiantes.DataSource = objetoCN.MostrarPorApellidos(this.txtbusqueda.Text, Estado);

        }

        private void dataEstudiantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataEstudiantes.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                    // Obtener la fuente de datos (DataTable)
                    DataTable dt = (DataTable)dataMatriculas.DataSource;

                    // Verificar si hay una fila seleccionada en dataMatriculas
                    if (dataEstudiantes.CurrentRow != null)
                    {
                        string idMatricula = dataEstudiantes.CurrentRow.Cells["Id_Matricula"].Value.ToString();
                        string CodMatricula = dataEstudiantes.CurrentRow.Cells["Cod_Matricula"].Value.ToString();
                        string nombres = dataEstudiantes.CurrentRow.Cells["Nombres"].Value.ToString();
                        string apellidos = dataEstudiantes.CurrentRow.Cells["Apellidos"].Value.ToString();

                        CN_Matriculas objetoCN = new CN_Matriculas();
                        objetoCN.ActualizarMatriculaGrupo(this.txtIdGrupo.Text, CodMatricula);

                        CN_Detalle_Programacion objetoDetalle = new CN_Detalle_Programacion();
                        objetoDetalle.ActualizarHistorialPago(CodMatricula, this.txtIdMoneda.Text,this.txtPrecioCurso.Text);

                        // Verificar que el DataTable no sea nulo
                        if (dt != null)
                        {
                            // **Crear nueva fila**
                            DataRow row = dt.NewRow();
                            row["Id_Matricula"] = idMatricula;
                            row["Cod_Matricula"] = CodMatricula;
                            row["Nombres"] = nombres;
                            row["Apellidos"] = apellidos;

                            // **Agregar la fila al DataTable antes de asignar las columnas extra**
                            dt.Rows.Add(row);

                            // **Ahora asignar valores a las columnas adicionales que fueron agregadas después**
                            int lastRowIndex = dataMatriculas.Rows.Count - 1; // Obtener el índice de la última fila agregada
                            if (lastRowIndex >= 0) // Verificar que haya filas
                            {
                                dataMatriculas.Rows[lastRowIndex].Cells["Estado"].Value = "AUSENTE";
                                dataMatriculas.Rows[lastRowIndex].Cells["Comentarios"].Value = "";
                            }

                            
                            this.tabControl1.SelectedIndex = 0;

                        }


                        }
                    }

            }
            catch (Exception)
            {

                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener valores generales
                string fechaActual = dateFechaActual.Text;
                string horaActual = DateTime.Now.ToShortTimeString();
                string idUsuario = CacheUsuario.IdUsuario;

                // Instancia de lógica de negocio
                CN_AsistenciaEstudiante asistenciaEstudianteService = new CN_AsistenciaEstudiante();

                // Recorrer filas del DataGridView
                foreach (DataGridViewRow fila in dataMatriculas.Rows)
                {
                    if (fila.IsNewRow) continue; // Saltar fila vacía

                    string idMatricula = fila.Cells["Id_Matricula"].Value?.ToString();
                    string estado = fila.Cells["Estado"].Value?.ToString()?.Trim().ToUpper();
                    string comentarios = fila.Cells["Comentarios"].Value?.ToString();

                    // Validar datos obligatorios
                    if (string.IsNullOrEmpty(idMatricula) || string.IsNullOrEmpty(estado))
                        continue;

                    // Evaluar estado con if
                    if (estado == "PRESENTE" || estado == "AUSENTE" || estado == "TARDE" || estado == "JUSTIFICADO")
                    {
                        // Evaluar si el campo comentarios está vacío
                        comentarios = string.IsNullOrWhiteSpace(comentarios) ? "-" : comentarios;

                        asistenciaEstudianteService.InsertarAsistenciaEstudiante(
                            idMatricula, fechaActual, horaActual, estado, comentarios, idUsuario
                        );
                    }
                    else if (estado == "EGRESADO" || estado == "BAJA")
                    {
                        // Lógica especial para egresados o bajas (si aplica)
                        RealizarAccionEspecial(fila);
                    }
                    else if (estado == "QUITAR")
                    {
                        CN_AsistenciaEstudiante objetoCN = new CN_AsistenciaEstudiante();
                        objetoCN.QuitarMatriculaDeGrupo(idMatricula);
                    }
                    

                }
                MessageBox.Show("Asistencia Registrado correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Frm_Asistencia frm = new Frm_Asistencia();
                this.Hide();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error en el sistema",
                    "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void RealizarAccionEspecial(DataGridViewRow row)
        {
            string idMatricula = row.Cells["Id_Matricula"].Value?.ToString();
            string motivoBaja = row.Cells["Comentarios"].Value?.ToString()?.Trim();
            string estado = row.Cells["Estado"].Value?.ToString();
            string fechaActual = DateTime.Now.ToShortDateString();
            string horaActual = DateTime.Now.ToShortTimeString();

            string nombrePC = Environment.MachineName;
            string usuario = CacheUsuario.IdUsuario;

            CN_Bajas objetoCN = new CN_Bajas();
            CN_AsistenciaEstudiante asistenciaEstudianteService = new CN_AsistenciaEstudiante();

            if (string.IsNullOrEmpty(idMatricula) || string.IsNullOrEmpty(estado))
                return; // Validación temprana

            switch (estado)
            {
                case "BAJA":
                    // Si no se escribió nada, usamos "Baja" como comentario por defecto
                    if (string.IsNullOrWhiteSpace(motivoBaja))
                        motivoBaja = "Baja";
                    asistenciaEstudianteService.InsertarAsistenciaEstudiante(idMatricula,fechaActual,horaActual,estado,motivoBaja,CacheUsuario.IdUsuario);
                    objetoCN.Insertar("BAJA", motivoBaja, fechaActual, idMatricula, usuario, nombrePC);
                    objetoCN.DarBaja(idMatricula);
                    break;

                case "EGRESADO":
                    motivoBaja = "Egresado";
                    asistenciaEstudianteService.InsertarAsistenciaEstudiante(idMatricula, fechaActual, horaActual, estado, motivoBaja, CacheUsuario.IdUsuario);
                    objetoCN.Insertar("EGRESADO", "EGRESADO", fechaActual, idMatricula, usuario, nombrePC);
                    objetoCN.DarBaja(idMatricula);
                    break;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Asistencia frm = new Frm_Asistencia();
                this.Hide();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                this.DarDeBaja();
               
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DarDeBaja()
        {
            string nombrePC = Environment.MachineName;
            string fechaActual = DateTime.Now.ToShortDateString();
            string usuario = CacheUsuario.IdUsuario;

            CN_Bajas gestorBajas = new CN_Bajas();
            CN_AsistenciaEstudiante gestorAsistencia = new CN_AsistenciaEstudiante();

            // Procesar ausentes por regular
            ProcesarAusentes(dataAusentesRegular, gestorAsistencia.MostrarAusentesPorRegular(), gestorBajas, fechaActual, usuario, nombrePC);

            // Procesar ausentes por encuentro
            ProcesarAusentes(dataAusentesPorEncuentro, gestorAsistencia.MostrarAusentesPorEncuentro(), gestorBajas, fechaActual, usuario, nombrePC);
            MessageBox.Show("Asistencia Actualizada", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ProcesarAusentes(DataGridView dataGrid, DataTable fuenteDatos, CN_Bajas gestorBajas, string fecha, string usuario, string pc)
        {
            dataGrid.DataSource = fuenteDatos;

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (!row.IsNewRow)
                {
                    string idMatricula = row.Cells["Id_Matricula"].Value?.ToString();

                    if (!string.IsNullOrEmpty(idMatricula))
                    {
                        gestorBajas.Insertar("OTRO", "AUSENCIAS (SISTEMA AUTOMATICO)", fecha, idMatricula, usuario, pc);
                        gestorBajas.DarBaja(idMatricula);
                    }
                }
            }

       }





        // Aquí puedes agregar más lógica según tus necesidades.
    }
}

