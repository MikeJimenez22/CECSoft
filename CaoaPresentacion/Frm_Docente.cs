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
            // Configurar controles de búsqueda
            SetupSearchControls();

            this.AgregarBtnDatagridView();

        }

        string Id_usuario;
        string NombreUsuario;
        string IdEmpleado;
        int IdEstadoBusqueda = 3;
        string CodigoActa;
        string IdGrupoSeleccionado;
        string Estado;
    


        private void button1_Click(object sender, EventArgs e)
        {
            


        }

        private void Frm_Docente_Load(object sender, EventArgs e)
        {
            try
            {

                this.generarcodigoActa();
               

                this.cmbEstados.Text = "Activo";
                this.tabControl1.SelectedIndex = 0;
                Id_usuario = CacheUsuario.IdUsuario;
                NombreUsuario = CacheUsuario.Nombres + " " + CacheUsuario.Apellidos;
                IdEmpleado = CacheUsuario.IdEmpleado;
                this.Cargar_GruposPorDocente(Convert.ToInt32(IdEmpleado), IdEstadoBusqueda);

       
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
                IdEstadoBusqueda = 3;
                this.Cargar_GruposPorDocente(Convert.ToInt32(IdEmpleado), IdEstadoBusqueda);
            }
            else if (this.cmbEstados.Text == "Inactivo")
            {
                IdEstadoBusqueda = 4;
                this.Cargar_GruposPorDocente(Convert.ToInt32(IdEmpleado), IdEstadoBusqueda);
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

                this.tabControl1.SelectedIndex = 2;

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
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




                    this.tabControl1.SelectedIndex = 1;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 1;
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
                this.tabControl1.SelectedIndex = 3;
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

                            this.tabControl1.SelectedIndex = 1;
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
            try
            {
                if (this.txtNombreModulo.Text == string.Empty)
                {
                    MessageBox.Show("(*) Nombre de Modulo - Campo obligatorio", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (this.txtNombreModulo.Text != string.Empty)
                {
                    if (this.cmbGrupos.Text == "Selecciona un Grupo")
                    {
                        MessageBox.Show("Ningun grupo seleccionado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }else
                    {

                        if (this.dataEstudiantes.Rows.Count == 0)
                        {
                            MessageBox.Show("Ningun estudiante se ha agregado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }else
                        {
                            string ip = ObtenerIPLocal();
                            string nombrePC = Environment.MachineName;
                            string FechaActual = DateTime.Now.ToShortDateString();
                            string HoraActual = DateTime.Now.ToShortTimeString();

                            CN_NotaModulos objetoCN = new CN_NotaModulos();
                           // objetoCN.InsertarActaNota(this.txtCodigoActa.Text, FechaActual, HoraActual, CacheUsuario.IdUsuario, ip, nombrePC, this.label3.Text, this.txtObservaciones.Text);

                            CN_NotaModulos objetoCN2 = new CN_NotaModulos();

                            foreach (DataGridViewRow fila in dataEstudiantes.Rows)
                            {
                                if (!fila.IsNewRow) // Evita procesar la fila vacía al final
                                {
                                    string idMatricula = fila.Cells["Id_Matricula"]?.Value?.ToString();
                                    string observacion = fila.Cells["Observacion"]?.Value?.ToString() ?? ""; // Si es null, asigna una cadena vacía
                                    string estado = fila.Cells["Estado"]?.Value?.ToString() ?? "Reprobado"; // Si es null, asigna "Reprobado"

                                    // Validar que la nota sea un número entero válido
                                    int nota = 0;
                                    if (fila.Cells["Nota"]?.Value == null || !int.TryParse(fila.Cells["Nota"].Value.ToString(), out nota))
                                    {
                                        MessageBox.Show($"La nota en la fila {fila.Index + 1} no es válida o está vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }

                                    // Insertar en la base de datos
                                    objetoCN2.InsertarNotasEstudiante(idMatricula, this.txtNombreModulo.Text, this.cmbGrupos.Text, nota.ToString(), FechaActual, HoraActual, observacion, this.txtCodigoActa.Text, estado);
                                }
                            }


                            MessageBox.Show("Registrado correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            CacheDatosImpresion.CodigoActa = this.txtCodigoActa.Text;
                            //Frm_ReporteActaNotas frm = new Frm_ReporteActaNotas();
                            //frm.Show();

                            Reporte_ActaNota frm = new Reporte_ActaNota();
                            frm.Show();
                            this.Hide();
                           

                        }





                    }
                }

                }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        
    
     
        

     



    }
}

