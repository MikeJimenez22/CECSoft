using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using System.Data.SqlClient;
using CapaNegocio;
using System.Net;
using System.Drawing.Printing;
using Utils;

namespace CaoaPresentacion
{
    public partial class Frm_Docente : Form
    {
        public Frm_Docente()
        {
            InitializeComponent();
            this.Cargar_Estados();

            this.cmbGrupos.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbEstados.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbBusquedas.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbEstadoDocente.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbDocente.DropDownStyle = ComboBoxStyle.DropDownList;
            DataGridViewConfigurator.Configure(dataEstudiantes,dataModulosCurso,dataMatriculas);
            CargarDocentes(3);
            // Configurar controles de búsqueda
            SetupSearchControls();

            this.AgregarBtnDatagridView();

        }

        string Id_usuario;
        string NombreUsuario;
        string IdEmpleado;
        string CodigoActa;
        string IdGrupoSeleccionado;
        string Estado;
    


        private void button1_Click(object sender, EventArgs e)
        {
            


        }
        public void CargarDocentes(int IdEstado)
        {
            try
            {
                CN_Empleados objetoCN = new CN_Empleados();

                DataTable dt = objetoCN.MostrarDocentes(IdEstado);

                cbDocente.ValueMember = "Id_empleado";
                cbDocente.DisplayMember = "Docente";
                cbDocente.DataSource = dt;

                // Seleccionar automáticamente el primer docente
                if (dt.Rows.Count > 0)
                {
                    cbDocente.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_Docente_Load(object sender, EventArgs e)
        {
            try
            {
                
                this.cmbEstados.Text = "Activo";
                this.cmbEstadoDocente.Text = "Activo";

                this.generarcodigoActa();



                this.tabControl1.SelectedTab = tabNotas;
                
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupSearchControls()
        {
            // Configurar controles de búsqueda
            radioButton1.Checked = true; // Puedes considerar si este valor por defecto es necesario
            cmbBusquedas.Text = "Carnet";
            radioButton1.Checked = true; // Igual aquí, verifica si es necesario
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
            dataModulosCurso.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Seleccionar",
                Name = "Seleccionar",
                Text = "Seleccionar",
                UseColumnTextForButtonValue = true

            });

            dataMatriculas.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Seleccionar",
                Name = "Seleccionar",
                Text = "Seleccionar",
                UseColumnTextForButtonValue = true

            });

            DataGridViewColumn columna = dataModulosCurso.Columns["Seleccionar"];
            // Establece el ancho deseado para la columna (en píxeles)
            columna.Width = 70;

            DataGridViewColumn columna1 = dataMatriculas.Columns["Seleccionar"];
            // Establece el ancho deseado para la columna (en píxeles)
            columna1.Width = 70;



        }


     
        public void Cargar_GruposPorDocente(int idEmpleado, int IdEstado)
        {
            try
            {
                // Crear la conexión
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();

                // Crear el comando para ejecutar el procedimiento almacenado
                SqlCommand cmd = new SqlCommand("SPBuscarGruposPorDocente", conexion.Conexion());
                cmd.CommandType = CommandType.StoredProcedure; // Indicar que es un procedimiento almacenado

                // Agregar el parámetro requerido por el procedimiento almacenado
                cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                cmd.Parameters.AddWithValue("@Idestado", IdEstado);

                // Ejecutar el procedimiento y llenar un DataTable
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Cerrar la conexión
                conexion.CerrarConexion();

                // Agregar una fila adicional para el mensaje "Selecciona un Curso"
                DataRow fila = dt.NewRow();
                fila["DisplayText"] = "Selecciona un Grupo";
                dt.Rows.InsertAt(fila, 0);

                // Asignar los datos al ComboBox
                cmbGrupos.DisplayMember = "DisplayText";
                cmbGrupos.ValueMember = "Id_Grupo";
                cmbGrupos.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de sistema, el error es");
            }
        }

        private void cmbEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbEstados.Text == "Activo")
            {
                
                this.Cargar_GruposPorDocente(Convert.ToInt32(cbDocente.SelectedValue), 3);
            }
            else if (this.cmbEstados.Text == "Inactivo")
            {
               
                this.Cargar_GruposPorDocente(Convert.ToInt32(cbDocente.SelectedValue), 4);
            }
        }

        private void generarcodigoActa()
        {
            //creando una instancia de random
            Random aleatorio = new Random();
            CodigoActa = aleatorio.Next(1, 99999999).ToString();

            this.txtCodigoActa.Text = CodigoActa;
        }

        private void MostrarEstudiantesPorGrupo(string IdGrupo)
        {
            CN_AsistenciaEstudiante objetoCN = new CN_AsistenciaEstudiante();
            this.dataEstudiantes.DataSource = objetoCN.MostrarEstudiantesPorGrupo(IdGrupo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarEstudiantesPorGrupo(this.cmbGrupos.SelectedValue.ToString());
                dataEstudiantes.Columns["Id_Matricula"].Visible = false;
                dataEstudiantes.Columns["Cod_Matricula"].Visible = false;

                this.AgregarColumnasData();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarColumnasData()
        {
            try
            {
                // Asegurar que la edición esté activada en el DataGridView
                dataEstudiantes.ReadOnly = false;
                dataEstudiantes.AllowUserToAddRows = false; // Evita filas en blanco
                dataEstudiantes.AllowUserToDeleteRows = true;
                dataEstudiantes.EditMode = DataGridViewEditMode.EditOnEnter;

                // Agregar columna "Nota"
                if (!dataEstudiantes.Columns.Contains("Nota"))
                {
                    DataGridViewTextBoxColumn notaColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "Nota",
                        HeaderText = "Nota",
                        Width = 150
                    };
                    dataEstudiantes.Columns.Add(notaColumn);
                }

                // Agregar columna "Observacion"
                if (!dataEstudiantes.Columns.Contains("Observacion"))
                {
                    DataGridViewTextBoxColumn observacionColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "Observacion",
                        HeaderText = "Observacion",
                        Width = 150
                    };
                    dataEstudiantes.Columns.Add(observacionColumn);
                }

                // Agregar columna "Estado" como ComboBox
                if (!dataEstudiantes.Columns.Contains("Estado"))
                {
                    DataGridViewComboBoxColumn estadoColumn = new DataGridViewComboBoxColumn
                    {
                        Name = "Estado",
                        HeaderText = "Estado",
                        Width = 150
                    };
                    estadoColumn.Items.AddRange("Aprobado", "Reprobado");
                    dataEstudiantes.Columns.Add(estadoColumn);
                }

                // Agregar columna "Eliminar" como CheckBox
                if (!dataEstudiantes.Columns.Contains("Eliminar"))
                {
                    DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn
                    {
                        Name = "Eliminar",
                        HeaderText = "Eliminar",
                        Width = 100
                    };
                    dataEstudiantes.Columns.Add(checkColumn);
                }

                // Deshabilitar edición en columnas específicas
                if (dataEstudiantes.Columns.Contains("Nombres")) dataEstudiantes.Columns["Nombres"].ReadOnly = true;
                if (dataEstudiantes.Columns.Contains("Apellidos")) dataEstudiantes.Columns["Apellidos"].ReadOnly = true;

                // Inicializar valores
                InicializarNotas();
                InicializarEstado();
                InicializarCheckBox();

                // Suscribir eventos
                dataEstudiantes.CellBeginEdit += dataEstudiantes_CellBeginEdit;
                dataEstudiantes.CellEndEdit += dataEstudiantes_CellEndEdit;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema: ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void txtNombreModulo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreModulo.Text))
            {
                lblMensaje.Visible = true;  // Muestra el Label si está vacío
                lblMensaje.Text = "Este campo es obligatorio"; // Mensaje opcional
            }
            else
            {
                lblMensaje.Visible = false; // Oculta el Label si hay texto
            }
        }


        private void dataEstudiantes_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            string columnName = dataEstudiantes.Columns[e.ColumnIndex].Name;
            if (columnName == "Nota" || columnName == "Observacion")
            {
                dataEstudiantes.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
            }
        }

     


        private void InicializarCheckBox()
        {
            foreach (DataGridViewRow row in dataEstudiantes.Rows)
            {
                row.Cells["Eliminar"].Value = false; // Inicialmente desmarcado
            }
        }

        private void InicializarNotas()
        {
            foreach (DataGridViewRow row in dataEstudiantes.Rows)
            {
                if (!row.IsNewRow) // Evita modificar la última fila vacía (si está activada)
                {
                    row.Cells["Nota"].Value = 0;
                }
            }
        }

        private void InicializarEstado()
        {
            foreach (DataGridViewRow row in dataEstudiantes.Rows)
            {
                if (!row.IsNewRow) // Evita modificar la última fila vacía (si está activada)
                {
                    row.Cells["Estado"].Value = "Reprobado";
                }
            }
        }

        private void dataEstudiantes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (dataEstudiantes.Columns[e.ColumnIndex].Name == "Nota")
            {
                // Obtener el valor ingresado
                string valor = dataEstudiantes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                if (string.IsNullOrWhiteSpace(valor))
                {
                    MessageBox.Show("La nota no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataEstudiantes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0"; // Reemplaza con un valor válido
                    ActualizarEstado(e.RowIndex, 0); // Estado = "Reprobado" por defecto
                    return;
                }

                // Validar si el valor es un número válido
                if (!int.TryParse(valor, out int nota) || nota < 0 || nota > 100)
                {
                    MessageBox.Show("Ingrese una nota válida entre 0 y 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataEstudiantes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0"; // Restaurar un valor válido
                    ActualizarEstado(e.RowIndex, 0); // Estado = "Reprobado" por defecto
                }
                else
                {
                    // Actualizar el estado según la nota
                    ActualizarEstado(e.RowIndex, nota);
                }
            }
        }

        // Método para actualizar la columna "Estado" según la nota
        private void ActualizarEstado(int rowIndex, int nota)
        {
            string estado = (nota >= 60) ? "Aprobado" : "Reprobado";

            if (dataEstudiantes.Columns.Contains("Estado"))
            {
                dataEstudiantes.Rows[rowIndex].Cells["Estado"].Value = estado;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                CN_ModulosCurso objetoCN = new CN_ModulosCurso();
                this.dataModulosCurso.DataSource = objetoCN.MostrarModulosPorGrupo(IdGrupoSeleccionado);

                this.tabControl1.SelectedTab = tabModulos;

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(cmbGrupos, cmbGrupos.Text);

            if (cmbGrupos.SelectedIndex > 0) // Evita la opción "Selecciona un Grupo"
            {
                IdGrupoSeleccionado = cmbGrupos.SelectedValue.ToString();
            }
            else
            {
                IdGrupoSeleccionado = string.Empty; // Borra el TextBox si se selecciona la opción predeterminada
            }
        }

        private void dataModulosCurso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataModulosCurso.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                    this.txtNombreModulo.Text = this.dataModulosCurso.CurrentRow.Cells["Descripcion"].Value.ToString(); ;

                    this.tabControl1.SelectedTab = tabNotas;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = tabNotas;
        }


      

        private void dataEstudiantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se hizo clic en la columna "Eliminar"
            if (e.RowIndex >= 0 && dataEstudiantes.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                // Confirmar el cambio de CheckBox
                dataEstudiantes.CommitEdit(DataGridViewDataErrorContexts.Commit);

                bool isChecked = Convert.ToBoolean(dataEstudiantes.Rows[e.RowIndex].Cells["Eliminar"].Value);

                if (isChecked) // Si el CheckBox está marcado
                {
                    DialogResult resultado = MessageBox.Show("¿Desea eliminar esta fila?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (resultado == DialogResult.Yes)
                    {
                        dataEstudiantes.Rows.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        // Si el usuario cancela, desmarcar el CheckBox
                        dataEstudiantes.Rows[e.RowIndex].Cells["Eliminar"].Value = false;
                    }
                }
            }
        }

      

        private void ValidarNota_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Ingrese solo números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        
        public void MostrarPorCarnet()
        {
            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            this.dataMatriculas.DataSource = objetoCN.MostrarPorCarnet(this.txtbusqueda.Text, Estado);
           
        }
        private void MostrarPorNombre()
        {
            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            this.dataMatriculas.DataSource = objetoCN.MostrarPorNombre(this.txtbusqueda.Text, Estado);
           
        }

        private void MostrarPorCodigoMatricula()
        {
            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            this.dataMatriculas.DataSource = objetoCN.MostrarPorCodMatricula(this.txtbusqueda.Text, Estado);
          
        }


        private void MostrarPorApellidos()
        {
            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            this.dataMatriculas.DataSource = objetoCN.MostrarPorApellidos(this.txtbusqueda.Text, Estado);
          
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            this.Estado = "3";
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            this.Estado = "4";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedTab = tabEstudiante;
                this.txtbusqueda.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
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

                dataMatriculas.Columns["Origen"].Visible = false;
                dataMatriculas.Columns["Fecha"].Visible = false;
                dataMatriculas.Columns["HoraRegistro"].Visible = false;
                dataMatriculas.Columns["Cedula"].Visible = false;
                dataMatriculas.Columns["Direccion"].Visible = false;
                dataMatriculas.Columns["NombreTutor"].Visible = false;
                dataMatriculas.Columns["CelularTutor"].Visible = false;
                dataMatriculas.Columns["Parentesco"].Visible = false;
                dataMatriculas.Columns["FechaNacimiento"].Visible = false;
                dataMatriculas.Columns["Estado"].Visible = false;
                dataMatriculas.Columns["Id_Matricula"].Visible = false;
                dataMatriculas.Columns["Id_Grupo"].Visible = false;
            }
        }

        private void dataMatriculas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataMatriculas.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                    // Obtener la fuente de datos (DataTable)
                    DataTable dt = (DataTable)dataEstudiantes.DataSource;

                    // Verificar si hay una fila seleccionada en dataMatriculas
                    if (dataMatriculas.CurrentRow != null)
                    {
                        // Obtener valores de la fila seleccionada
                        string idMatricula = dataMatriculas.CurrentRow.Cells["Id_Matricula"].Value.ToString();
                        string CodMatricula = dataMatriculas.CurrentRow.Cells["Cod_Matricula"].Value.ToString();
                        string nombres = dataMatriculas.CurrentRow.Cells["Nombres"].Value.ToString();
                        string apellidos = dataMatriculas.CurrentRow.Cells["Apellidos"].Value.ToString();

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
                            int lastRowIndex = dataEstudiantes.Rows.Count - 1; // Obtener el índice de la última fila agregada
                            if (lastRowIndex >= 0) // Verificar que haya filas
                            {
                                dataEstudiantes.Rows[lastRowIndex].Cells["Nota"].Value = 0;
                                dataEstudiantes.Rows[lastRowIndex].Cells["Observacion"].Value = "";
                                dataEstudiantes.Rows[lastRowIndex].Cells["Estado"].Value = "Reprobado";
                            }

                            this.tabControl1.SelectedTab = tabNotas;
                        }
                        else
                        {
                            MessageBox.Show("No se encontró un DataTable en dataEstudiantes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
         GuardarActaNotas();
        }

        private void GuardarActaNotas()
        {
            try
            {
                // 1. Validaciones generales
                if (string.IsNullOrWhiteSpace(txtNombreModulo.Text))
                {
                    MessageBox.Show(
                        "Debe ingresar el nombre del módulo.",
                        "SISTEMA CECNIC",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtNombreModulo.Focus();
                    return;
                }

                if (cmbGrupos.SelectedIndex < 0 ||
                    cmbGrupos.SelectedValue == null ||
                    cmbGrupos.Text == "Selecciona un Grupo")
                {
                    MessageBox.Show(
                        "Debe seleccionar un grupo.",
                        "SISTEMA CECNIC",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    cmbGrupos.Focus();
                    return;
                }

                int cantidadEstudiantes = dataEstudiantes.Rows
                    .Cast<DataGridViewRow>()
                    .Count(fila => !fila.IsNewRow);

                if (cantidadEstudiantes == 0)
                {
                    MessageBox.Show(
                        "Debe agregar al menos un estudiante al acta de notas.",
                        "SISTEMA CECNIC",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // 2. Validar todas las filas antes de guardar
                foreach (DataGridViewRow fila in dataEstudiantes.Rows)
                {
                    if (fila.IsNewRow)
                        continue;

                    string idMatricula =
                        Convert.ToString(fila.Cells["Id_Matricula"].Value)?.Trim();

                    if (string.IsNullOrWhiteSpace(idMatricula))
                    {
                        MessageBox.Show(
                            $"No se encontró la matrícula del estudiante en la fila {fila.Index + 1}.",
                            "SISTEMA CECNIC",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        dataEstudiantes.CurrentCell = fila.Cells["Id_Matricula"];
                        return;
                    }

                    string valorNota =
                        Convert.ToString(fila.Cells["Nota"].Value)?.Trim();

                    if (!int.TryParse(valorNota, out int nota))
                    {
                        MessageBox.Show(
                            $"La nota de la fila {fila.Index + 1} está vacía o no es válida.",
                            "SISTEMA CECNIC",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        dataEstudiantes.CurrentCell = fila.Cells["Nota"];
                        dataEstudiantes.BeginEdit(true);
                        return;
                    }

                    if (nota < 0 || nota > 100)
                    {
                        MessageBox.Show(
                            $"La nota de la fila {fila.Index + 1} debe estar entre 0 y 100.",
                            "SISTEMA CECNIC",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        dataEstudiantes.CurrentCell = fila.Cells["Nota"];
                        dataEstudiantes.BeginEdit(true);
                        return;
                    }
                }

                // 3. Datos generales
                string codigoActa = txtCodigoActa.Text.Trim();
                string nombreModulo = txtNombreModulo.Text.Trim();
                string nombreGrupo = cmbGrupos.Text.Trim();
                string nombreDocente = cbDocente.Text.Trim();
                string observacionesActa = txtObservaciones.Text.Trim();

                string ip = ObtenerIPLocal();
                string nombrePC = Environment.MachineName;

                DateTime fechaHoraActual = DateTime.Now;
                string fechaActual = fechaHoraActual.ToShortDateString();
                string horaActual = fechaHoraActual.ToShortTimeString();

                CN_NotaModulos objetoCN = new CN_NotaModulos();

                // 4. Guardar encabezado del acta
                objetoCN.InsertarActaNota(
                    codigoActa,
                    fechaActual,
                    horaActual,
                    CacheUsuario.IdUsuario,
                    ip,
                    nombrePC,
                    nombreDocente,
                    observacionesActa);

                // 5. Guardar notas
                foreach (DataGridViewRow fila in dataEstudiantes.Rows)
                {
                    if (fila.IsNewRow)
                        continue;

                    string idMatricula =
                        Convert.ToString(fila.Cells["Id_Matricula"].Value).Trim();

                    int nota = Convert.ToInt32(fila.Cells["Nota"].Value);

                    string observacion =
                        Convert.ToString(fila.Cells["Observacion"].Value)?.Trim()
                        ?? string.Empty;

                    string estado =
                        Convert.ToString(fila.Cells["Estado"].Value)?.Trim();

                    if (string.IsNullOrWhiteSpace(estado))
                    {
                        estado = nota >= 60
                            ? "Aprobado"
                            : "Reprobado";
                    }

                    objetoCN.InsertarNotasEstudiante(
                        idMatricula,
                        nombreModulo,
                        nombreGrupo,
                        nota.ToString(),
                        fechaActual,
                        horaActual,
                        observacion,
                        codigoActa,
                        estado);
                }

                MessageBox.Show(
                    "El acta de notas fue registrada correctamente.",
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Frm_Docente formulario = new Frm_Docente();
                formulario.Show();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al registrar el acta de notas.\n\n" +
                    "Detalle: " + ex.Message,
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        static string ObtenerIPLocal()
        {
            string ipAddress = "No encontrada";
            foreach (IPAddress ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) // IPv4
                {
                    ipAddress = ip.ToString();
                    break;
                }
            }
            return ipAddress;
        }

        private void cmbEstadoDocente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbEstadoDocente.Text == "Activo")
                {
                    CargarDocentes(3);
                }else if (cmbEstadoDocente.Text == "Inactivo")
                {
                    CargarDocentes(4);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbDocente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                toolTip1.SetToolTip(cbDocente, cbDocente.Text);

                if (cmbEstadoDocente.Text == "Activo")
                {
                    this.Cargar_GruposPorDocente(Convert.ToInt32(cbDocente.SelectedValue),3);
                }else
                {
                    this.Cargar_GruposPorDocente(Convert.ToInt32(cbDocente.SelectedValue), 4);
                }

                
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabNotas;
        }
    }
}

