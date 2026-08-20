using CapaDatos;
using CapaNegocio;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace CaoaPresentacion
{
    public partial class Frm_Principal : Form
    {
        CN_Usuarios objetoCN2 = new CN_Usuarios();
        
        CN_Rol_Formularios objetoCN4 = new CN_Rol_Formularios();
        string fechaVerificacion = DateTime.Now.ToShortDateString();

        private readonly CN_Dashboard objDashboard = new CN_Dashboard();
        private readonly CN_Dashboard objDashboard2 = new CN_Dashboard();


        public Frm_Principal()
        {
            InitializeComponent();
            KeyPreview = true; // Habilita el evento KeyDown para el formulario
            KeyDown += MainForm_KeyDown; // Asocia el evento KeyDown al controlador MainForm_KeyDown

        }


  

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    // aca se abrira la ventana de FACTURACION
                    CacheDatos.TipoFactura = "estudiante_existente";
                    this.AbrirFacturacion();
                   


                }
                else if (e.KeyCode == Keys.F2)
                {
                    // Aca se abrira la ventana de Registro
                    
                    Frm_DatosGenerales frm = new Frm_DatosGenerales();
                    frm.Show();
              

                }
                else if (e.KeyCode == Keys.F3)
                {

                    
                    Frm_HistorialFacturasEstudiante frm = new Frm_HistorialFacturasEstudiante();
                    frm.Show();


                }else if (e.KeyCode == Keys.F4)
                {
                   
                    Frm_BusquedaEstudiantes frm = new Frm_BusquedaEstudiantes();
                    frm.Show();

                }
                else if (e.KeyCode == Keys.Escape)
                {
                  
                    Frm_ReporteRecepcion frm = new Frm_ReporteRecepcion();
                    frm.Show();
                }
               
            }
            catch (Exception)
            {
                this.panel14.BackColor = Color.Red;
                this.label21.Text = "Desconectado";

            }
            
        }

        private int tiempoActual = 0;
        private const int tiempoMaximo = 60;


        private  void Frm_Principal_Load(object sender, EventArgs e)
        {
            progressBarDashboard.Minimum = 0;
            progressBarDashboard.Maximum = tiempoMaximo;
            progressBarDashboard.Value = 0;

            lblActualizacion.Text = $"Actualización en: {tiempoMaximo} s";

            try
            {

                EstiloDataGestiones();
                DatosDashboard();
          


                panel14.BackColor = Color.FromArgb(212, 237, 218);
                label21.ForeColor = Color.FromArgb(40, 167, 69);
                label21.Text = "Sistema Conectado";

                MostrarBotonEstado();
            }
            catch
            {
                panel14.BackColor = Color.FromArgb(235, 154, 134);
                label21.ForeColor = Color.White;
                label21.Text = "Sistema Desconectado";

                MostrarBotonEstado();
                menuStrip.Enabled = false;
            }

            this.FormClosed += new FormClosedEventHandler(cerrarform);
            this.lblNombrePC.Text = "Terminal: " + Environment.MachineName;

            lblNombreUsuario.Text =
                "¡Bienvenido, " +
                CultureInfo.CurrentCulture.TextInfo.ToTitleCase(CacheUsuario.Nombres.ToLower()) +
                " " +
                CultureInfo.CurrentCulture.TextInfo.ToTitleCase(CacheUsuario.Apellidos.ToLower()) +
                "! | " +
                CultureInfo.CurrentCulture.TextInfo.ToTitleCase(CacheUsuario.TipoUsuario.ToLower());

            CacheDetalleProgramacion.Contador4 = true;

            AdministracionAcceso(CacheUsuario.TipoUsuario);

            BuscarCjaAsignada();

            timer1.Interval = 1000;
            timer1.Start();
        }

     










        private void MostrarBotonEstado()
        {
            if (this.label21.Text == "Sistema Conectado")
            {
                this.pbActualizar.Enabled = false;
                this.pbActualizar.Visible = false;
            }
            else if (this.label21.Text == "Sistema Desconectado")
            {
                this.pbActualizar.Enabled = true;
                this.pbActualizar.Visible = true;
            }

        }
        
        private void cerrarform(object sender, EventArgs e)
        {

            try
            {
                
                string FechaActual = DateTime.Now.ToShortDateString();
                string HoraActual = DateTime.Now.ToShortTimeString();

                CN_ConexionesUsuarios objetoConexiones = new CN_ConexionesUsuarios();
                objetoConexiones.DesconectarConexion(FechaActual, HoraActual, CacheUsuario.CodigoDeSesion);

                FrmInicioSesion frm = new FrmInicioSesion();
                frm.Show();
                this.Hide();
            }
            catch (Exception)
            {
                this.panel14.BackColor = Color.Red;
                this.label21.Text = "Desconectado";
                this.MostrarBotonEstado();
               this.menuStrip.Enabled = false;
            }

        }


        private async void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString() + " " +
                   DateTime.Now.ToLongTimeString();


            tiempoActual++;


            progressBarDashboard.Value = Math.Min(tiempoActual, tiempoMaximo);


            int restante = Math.Max(0, tiempoMaximo - tiempoActual);


            lblActualizacion.Text = $"Actualización en: {restante} s";


            if (tiempoActual >= tiempoMaximo)
            {
                timer1.Stop();

                try
                {
                    lblActualizacion.Text = "Actualizando dashboard...";


                    await Task.Run(() =>
                    {
                        DatosDashboard();
                    });


                    panel14.BackColor = Color.FromArgb(212, 237, 218);
                    label21.ForeColor = Color.FromArgb(40, 167, 69);
                    label21.Text = "Sistema Conectado";


                    MostrarBotonEstado();

                }
                catch
                {
                    panel14.BackColor = Color.Red;
                    label21.ForeColor = Color.White;
                    label21.Text = "Sistema Desconectado";


                    MostrarBotonEstado();

                    menuStrip.Enabled = false;
                }


                tiempoActual = 0;


                progressBarDashboard.Value = 0;


                lblActualizacion.Text =
                    $"Actualización en: {tiempoMaximo} s";


                timer1.Start();
            }
        }

        private void DatosDashboard()
        {
            try
            {
                CargarEstadisticasPrimarias();
                CargarEstadisticasSecundarias();
                CargarUltimoBackup();
                CargarCarteraTurnoActual();
                CargarGestiones();
                CargarAsistenciaDia();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex.Message , "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarEstadisticasPrimarias()
        {
            try
            {
                CN_Dashboard objetoCN = new CN_Dashboard();
                DataTable dtGeneral = objetoCN.MostrarDashboard();

                EjecutarEnUI(() =>
                {
                    if (dtGeneral != null && dtGeneral.Rows.Count > 0)
                    {
                        DataRow fila = dtGeneral.Rows[0];

                        lblEstudiantes.Text = fila[0].ToString();
                        lblMatriculasHoy.Text = fila[1].ToString();
                        lblMatriculasRegistradas.Text = fila[1].ToString();
                        lblCursos.Text = fila[2].ToString();
                        lblGrupos.Text = fila[3].ToString();
                        lblDocentes.Text = fila[4].ToString();
                    }
                    else
                    {
                        lblEstudiantes.Text = "0";
                        lblMatriculasHoy.Text = "0";
                        lblMatriculasRegistradas.Text = "0";
                        lblCursos.Text = "0";
                        lblGrupos.Text = "0";
                        lblDocentes.Text = "0";
                    }
                });
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void CargarEstadisticasSecundarias()
        {
            try
            {
                CN_Dashboard objetoCN = new CN_Dashboard();
                DataTable dtDiario = objetoCN.MostrarDashboardDiario();

                EjecutarEnUI(() =>
                {
                    if (dtDiario != null && dtDiario.Rows.Count > 0)
                    {
                        DataRow fila = dtDiario.Rows[0];

                        lblCarnetEstudiantil.Text = fila[0].ToString();
                        lblCertificadoGeneral.Text = fila[1].ToString();
                        lblMensualidades.Text = fila[2].ToString();
                        lblDiplomasCECNIC.Text = fila[3].ToString();
                        lblDiplomasINATEC.Text = fila[4].ToString();
                        lblGestiones.Text = fila[5].ToString();
                        lblFacturas.Text = fila[6].ToString();
                    }
                    else
                    {
                        lblCarnetEstudiantil.Text = "0";
                        lblCertificadoGeneral.Text = "0";
                        lblMensualidades.Text = "0";
                        lblDiplomasCECNIC.Text = "0";
                        lblDiplomasINATEC.Text = "0";
                        lblGestiones.Text = "0";
                        lblFacturas.Text = "0";
                    }
                });
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void CargarUltimoBackup()
        {
            try
            {
                CN_Dashboard objetoCN = new CN_Dashboard();
                DataTable dtBackup = objetoCN.UltimoBackup();

                EjecutarEnUI(() =>
                {
                    if (dtBackup != null && dtBackup.Rows.Count > 0)
                    {
                        DataRow fila = dtBackup.Rows[0];

                        lblBackup.Text =
                            "Última copia de seguridad: " + fila[0].ToString();
                    }
                    else
                    {
                        lblBackup.Text = "Última copia de seguridad: ---";
                    }
                });
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void CargarCarteraTurnoActual()
        {
            try
            {
                CN_Dashboard objetoCN = new CN_Dashboard();
                DataTable dtCartera = objetoCN.ObtenerCarteraTurnoActual();

                EjecutarEnUI(() =>
                {
                    if (dtCartera != null && dtCartera.Rows.Count > 0)
                    {
                        DataRow fila = dtCartera.Rows[0];

                        lblinsolventes.Text = fila[0].ToString();
                        lblsolventes.Text = fila[1].ToString();
                    }
                    else
                    {
                        lblinsolventes.Text = "0";
                        lblsolventes.Text = "0";
                    }
                });
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }


        private void CargarGestiones()
        {
            try
            {
                CN_GestionCobro objCN = new CN_GestionCobro();
                DataTable dt = objCN.ObtenerUltimas5GestionesCobro();

                if (dt == null || dt.Rows.Count == 0)
                {
                    dt = new DataTable();
                    dt.Columns.Add("Mensaje");
                    dt.Rows.Add("No hay registros");
                }

                EjecutarEnUI(() =>
                {
                    dataGestiones.DataSource = dt;

                    if (dt.Columns.Contains("Mensaje") &&
                        dataGestiones.Columns.Count > 0)
                    {
                        dataGestiones.Columns[0].DefaultCellStyle.Alignment =
                            DataGridViewContentAlignment.MiddleCenter;
                    }
                });
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void CargarAsistenciaDia()
        {
            try
            {
                CN_Dashboard objetoCN = new CN_Dashboard();
                DataTable tabla = objetoCN.AsistenciaGeneralDia();

                EjecutarEnUI(() =>
                {
                    if (tabla != null && tabla.Rows.Count > 0)
                    {
                        DataRow fila = tabla.Rows[0];

                        lblPresentes.Text = fila[0].ToString();
                        lblAusentes.Text = fila[1].ToString();
                        lblTardes.Text = fila[2].ToString();
                        lblJustificados.Text = fila[3].ToString();
                    }
                    else
                    {
                        lblPresentes.Text = "0";
                        lblAusentes.Text = "0";
                        lblTardes.Text = "0";
                        lblJustificados.Text = "0";
                    }
                });
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void MostrarError(Exception ex)
        {
            EjecutarEnUI(() =>
            {
                MessageBox.Show(
                    "Ocurrió un error al cargar la información.\n\n" +
                    ex.Message,
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            });
        }

        private void EjecutarEnUI(Action accion)
        {
            if (IsDisposed || Disposing)
                return;

            if (InvokeRequired)
            {
                Invoke(accion);
            }
            else
            {
                accion();
            }
        }


        private void EstiloDataGestiones()
        {
            dataGestiones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGestiones.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGestiones.Dock = DockStyle.Fill;

            dataGestiones.BackgroundColor = Color.White;
            dataGestiones.BorderStyle = BorderStyle.None;
            dataGestiones.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dataGestiones.EnableHeadersVisualStyles = false;
            dataGestiones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGestiones.MultiSelect = false;
            dataGestiones.ReadOnly = true;
            dataGestiones.RowHeadersVisible = false;

            // 🔵 HEADER (más moderno y limpio)
            dataGestiones.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGestiones.ColumnHeadersHeight = 45;

            dataGestiones.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(25, 42, 86);
            dataGestiones.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGestiones.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            dataGestiones.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 📄 FILAS (mejor lectura)
            dataGestiones.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGestiones.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 45);
            dataGestiones.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 230, 255);
            dataGestiones.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGestiones.DefaultCellStyle.Padding = new Padding(8, 5, 8, 5);

            // 🎨 alternancia de filas (clave para look pro)
            dataGestiones.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 251);

            // 📏 altura más controlada
            dataGestiones.RowTemplate.Height = 38;

            // 🌫 grid suave (no agresivo)
            dataGestiones.GridColor = Color.FromArgb(230, 230, 230);

            // 🖱 comportamiento más fluido
            dataGestiones.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // 🔒 extra seguridad visual
            dataGestiones.AllowUserToAddRows = false;
            dataGestiones.AllowUserToResizeRows = false;
        }


        private void VerificarEstado_Tick(object sender, EventArgs e)
        {
            try
            {
                DataTable tabla = new DataTable();
                CN_Usuarios objetoCN = new CN_Usuarios();
                tabla = objetoCN.VerificarEstado(CacheUsuario.IdUsuario);

                string Estado = tabla.Rows[0][2].ToString();
                if (Estado == "Inactivo")
                {
                    Application.Exit();
                }

            }
            catch (Exception)
            {
                this.panel14.BackColor = Color.FromArgb(235, 154, 134); // Rojo claro
                this.label21.ForeColor = Color.FromArgb(255, 255, 255);   // blanco
                this.label21.Text = "Sistema Desconectado";
                this.MostrarBotonEstado();

               this.menuStrip.Enabled = false;


            }
        }
        

        private void BuscarCjaAsignada()
        {
            DataTable tabla = new DataTable();
            CN_Usuarios objeto = new CN_Usuarios();

            tabla = objeto.BuscarCajaAsignada(CacheUsuario.IdUsuario);
            if (tabla.Rows.Count == 0)
            {
                gestionDeMatriculasToolStripMenuItem.Enabled = false;
                realizarPagosToolStripMenuItem.Enabled = false;
            }
            else if (tabla.Rows.Count != 0)
            {
                gestionDeMatriculasToolStripMenuItem.Enabled = true;
                realizarPagosToolStripMenuItem.Enabled = true;
            }
        }

  
     

        private void AbrirFacturacion()
        {
            try
            {
                CacheDatos.TipoFactura = "estudiante_existente";

                Frm_Facturacion frm = new Frm_Facturacion();
                frm.Show();
            
            }
            catch (Exception)
            {
                this.panel14.BackColor = Color.Red;
                this.label21.Text = "Desconectado";
                this.MostrarBotonEstado();


                this.menuStrip.Enabled = false;

            }
        }
        
      
        private void registroDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CachePersonaVentana.MetodoEntrada = "OFLINE";

                Frm_DatosGenerales frm = new Frm_DatosGenerales();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Conexion con el servidor", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gestionDeMatriculasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Nueva_Matricula frm = new Frm_Nueva_Matricula();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void consultaDeMatriculasEnLineaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_BusquedaMatriculasEnLinea frm = new Frm_BusquedaMatriculasEnLinea();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void universoEstudiantilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_BusquedaEstudiantes frm = new Frm_BusquedaEstudiantes();
                frm.Show();

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void realizarPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CacheDatos.TipoFactura = "estudiante_existente";
                Frm_Facturacion frm = new Frm_Facturacion();

                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void consultaDeFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_BusquedasFacturas frm = new Frm_BusquedasFacturas();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void controlDeAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void reporteUniversoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_ReportesUniverso frm = new Frm_ReportesUniverso();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gestionDeNotasAcademicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void solicitudDeCarnetEstudiantilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void carteraYCobroToolStripMenuItem_Click(object sender, EventArgs e)
        {       
            try
            {
                Frm_CuentasporCobrar frm = new Frm_CuentasporCobrar();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void arqueoDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_ConsultaDeFacturacion frm = new Frm_ConsultaDeFacturacion();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gestionDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Usuario frm = new Frm_Usuario();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmRoles frm = new FrmRoles();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     
        private void permisosDeAccesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Formularios_por_Roles frm = new Frm_Formularios_por_Roles();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCursos frm = new FrmCursos();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Grupo frm = new Frm_Grupo();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void turnosYHorariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                FrmCursos_turno frm = new FrmCursos_turno();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void arancelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Aranceles frm = new Frm_Aranceles();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void asignacionDeCajasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                Asignacion_Caja frm = new Asignacion_Caja();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cambioDeMonedaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_CambioDolar frm = new Frm_CambioDolar();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rolesDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmRolesUsuario frm = new FrmRolesUsuario();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdministracionAcceso(string rol)
        {
            try
            {
                // Lista de todos los menús que controlamos
                var menus = new Dictionary<string, ToolStripMenuItem>
        {
            { "RegistroDeDatos", registroDeDatosToolStripMenuItem },
            { "GestionDeMatriculas", gestionDeMatriculasToolStripMenuItem },
            { "ConsultaDeMatriculas", consultaDeMatriculasEnLineaToolStripMenuItem },
            { "UniversoEstudiantil", universoEstudiantilToolStripMenuItem },
            { "RealizarPagos", realizarPagosToolStripMenuItem },
            { "ConsultaFacturas", consultaDeFacturasToolStripMenuItem },
            { "CarteraCobro", carteraYCobroToolStripMenuItem },
            { "ReporteUniverso", reporteUniversoToolStripMenuItem },
            { "ArqueoCaja", arqueoDeCajaToolStripMenuItem },
            { "GestionUsuarios", gestionDeUsuariosToolStripMenuItem },
            { "Roles", rolesToolStripMenuItem },
            { "Permisos", permisosDeAccesoToolStripMenuItem },
            { "RolesUsuario", rolesDeUsuarioToolStripMenuItem },
            { "Empleados", gestionDeEmpleadosToolStripMenuItem },
            { "Incentivos", incentivosDeEjecutivoToolStripMenuItem },
            { "SolicitudesArreglos", solicitudesDeArreglosDePagoToolStripMenuItem },
            { "Cursos", cursosToolStripMenuItem },
            { "Grupos", gruposToolStripMenuItem },
            { "Turnos", turnosYHorariosToolStripMenuItem },
            { "Aranceles", arancelesToolStripMenuItem },
            { "AsignacionCajas", asignacionDeCajasToolStripMenuItem },
            { "CambioMoneda", cambioDeMonedaToolStripMenuItem },
            {"HistorialPagosEstudiante",historialPagosEstudianteToolStripMenuItem},
            {"ReporteDiario",reporteCajaDiariaToolStripMenuItem},
            {"ReporteNoAsignado",matriculasNoAsignadosToolStripMenuItem},
            {"Acerca",acercaDeToolStripMenuItem }
        };

                // Definición de permisos por rol (solo listamos los que están habilitados)
                var permisosPorRol = new Dictionary<string, List<string>>
        {
            { "SUPER_USUARIO", menus.Keys.ToList() },
            { "ADMINISTRADOR", menus.Keys.ToList() },
            { "REGISTRO ACADEMICO", new List<string>
                {
                    "RegistroDeDatos","GestionDeMatriculas","ConsultaDeMatriculas","UniversoEstudiantil",
                    "RealizarPagos","ConsultaFacturas","ControlAsistencia","GestionNotas","SolicitudCarnet",
                    "CarteraCobro","ReporteUniverso","HistorialPagosEstudiante","ReporteDiario","ReporteAusencias","ReporteNoAsignado","Acerca","CarnetAdministracion"
                }
            },
            { "CARTERA Y COBRO", new List<string>
                {
                    "RegistroDeDatos","GestionDeMatriculas","ConsultaDeMatriculas","UniversoEstudiantil",
                    "RealizarPagos","ConsultaFacturas","ControlAsistencia","SolicitudCarnet","CarteraCobro","ReporteUniverso"
                    ,"HistorialPagosEstudiante","ReporteDiario","SolicitudCarnet","ReporteAusencias","ReporteNoAsignado","Acerca","CarnetAdministracion"
                }
            },
            { "RECEPCION", new List<string>
                {
                    "RegistroDeDatos","GestionDeMatriculas","ConsultaDeMatriculas","UniversoEstudiantil",
                    "RealizarPagos","ConsultaFacturas","HistorialPagosEstudiante","ReporteDiario","CarteraCobro","ControlAsistencia",
                    "SolicitudCarnet","ReporteAusencias","ReporteUniverso","ReporteNoAsignado","Acerca","CarnetAdministracion"
                }
            },
            { "CAJA", new List<string>
                {
                    "RegistroDeDatos","GestionDeMatriculas","ConsultaDeMatriculas","UniversoEstudiantil",
                    "RealizarPagos","ConsultaFacturas","HistorialPagosEstudiante","ReporteDiario","CarteraCobro","ControlAsistencia",
                    "SolicitudCarnet","ReporteAusencias","ReporteUniverso","ReporteNoAsignado","Acerca","CarnetAdministracion"
                 }
            },
            { "COORDINACION", new List<string>
                {
                    "RegistroDeDatos","GestionDeMatriculas","ConsultaDeMatriculas","UniversoEstudiantil",
                    "RealizarPagos","ConsultaFacturas","ControlAsistencia","ReporteUniverso",
                    "Cursos","Grupos","Turnos","HistorialPagosEstudiante","ReporteDiario","CarteraCobro","SolicitudCarnet",
                    "ReporteAusencias","ReporteNoAsignado","Acerca","CarnetAdministracion"
                }
            },
            { "FINANZAS", new List<string>
                {
                    "RegistroDeDatos","GestionDeMatriculas","ConsultaDeMatriculas","UniversoEstudiantil",
                    "RealizarPagos","ConsultaFacturas","CarteraCobro","ArqueoCaja","HistorialPagosEstudiante","ReporteDiario",
                    "ReporteAusencias","ReporteUniverso","ReporteNoAsignado","Acerca","CarnetAdministracion"
                }
            },
            { "SOPORTE TECNICO", new List<string>
                {
                    "RegistroDeDatos","GestionDeMatriculas","ConsultaDeMatriculas","UniversoEstudiantil",
                    "RealizarPagos","HistorialPagosEstudiante","ReporteDiario","CarteraCobro","ReporteAusencias","ReporteUniverso",
                    "ReporteNoAsignado","Acerca"
                }
            },
            { "SUB_DIRECCION", new List<string>
                {
                    "RegistroDeDatos","GestionDeMatriculas","ConsultaDeMatriculas","UniversoEstudiantil",
                    "RealizarPagos","ConsultaFacturas","ControlAsistencia","CarteraCobro",
                    "ReporteUniverso","Cursos","Grupos","Turnos","HistorialPagosEstudiante","ReporteDiario","SolicitudCarnet",
                    "ReporteAusencias","ReporteNoAsignado","Acerca","CarnetAdministracion"
                }
            }
        };

                // Primero ocultamos todos
                foreach (var menu in menus.Values)
                {
                    menu.Enabled = false;
                    menu.Visible = false;
                }

                // Si el rol existe, activamos los permitidos
                if (permisosPorRol.ContainsKey(rol))
                {
                    foreach (var key in permisosPorRol[rol])
                    {
                        if (menus.ContainsKey(key))
                        {
                            menus[key].Enabled = true;
                            menus[key].Visible = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Rol no reconocido", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gestionDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Empleados frm = new Frm_Empleados();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void incentivosDeEjecutivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                Frm_Incentivo frm = new Frm_Incentivo();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void solicitudesDeArreglosDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_SolicitudesDeArreglos frm = new Frm_SolicitudesDeArreglos();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void historialPagosEstudianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_HistorialFacturasEstudiante frm = new Frm_HistorialFacturasEstudiante();
                frm.Show();
            }
            catch(Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reporteCajaDiariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_ReporteRecepcion frm = new Frm_ReporteRecepcion();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void matriculasNoAsignadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_EstudiantesNoAsignados frm = new Frm_EstudiantesNoAsignados();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_AcercaDe frm = new Frm_AcercaDe();
                frm.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void generarCarnetAdministracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void pbActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();

                if (conexion.Conexion().State == ConnectionState.Open)
                {
                    this.menuStrip.Enabled = true;
                    this.panel4.Enabled = true;



                    this.panel14.BackColor = Color.FromArgb(212, 237, 218); // Verde claro
                    this.label21.ForeColor = Color.FromArgb(40, 167, 69);   // Verde fuerte
                    this.label21.Text = "Sistema Conectado";
                    this.MostrarBotonEstado();

                }
                else if (conexion.Conexion().State == ConnectionState.Closed)
                {
                    MessageBox.Show("Reintente Conectarse", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Reintente Conectarse", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CachePersonaVentana.MetodoEntrada = "OFLINE";

                Frm_DatosGenerales frm = new Frm_DatosGenerales();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Conexion con el servidor", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Nueva_Matricula frm = new Frm_Nueva_Matricula();
                frm.Show();
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
                Frm_BusquedaEstudiantes frm = new Frm_BusquedaEstudiantes();
                frm.Show();

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_ReporteRecepcion frm = new Frm_ReporteRecepcion();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gestionesDeCobroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_HistorialGestiones frm = new Frm_HistorialGestiones();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void librosToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void controlDeAsistenciaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Asistencia frm = new Frm_Asistencia();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gestionDeNotasAcademicasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_NotasEstudiante frm = new Frm_NotasEstudiante();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void solicitudDeCarnetEstudiantilToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_CarnetEstudiantil frm = new Frm_CarnetEstudiantil();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void generarCarnetAdministracionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_CarnetAdministracion frm = new Frm_CarnetAdministracion();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void librosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_LibrosRegistro frm = new Frm_LibrosRegistro();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tiposDeDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_TiposDocumentos frm = new Frm_TiposDocumentos();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void registroDeNotasActasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Docente frm = new Frm_Docente();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void registroEnLibrosAcademicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_RegistroAcademico frm = new Frm_RegistroAcademico();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void egresadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Egresados frm = new Frm_Egresados();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void matriculasParaINATECToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_MatriculasParaInatec frm = new Frm_MatriculasParaInatec();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }


