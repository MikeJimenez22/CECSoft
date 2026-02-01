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


namespace CaoaPresentacion
{
    public partial class Frm_Principal : Form
    {
      
        
       
        CN_Usuarios objetoCN2 = new CN_Usuarios();
        CN_CierreCaja objetoCN3 = new CN_CierreCaja();
        CN_Rol_Formularios objetoCN4 = new CN_Rol_Formularios();
        string fechaVerificacion = DateTime.Now.ToShortDateString();

    
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

                    
                    FrmFacturasDeEstudiante frm = new FrmFacturasDeEstudiante();
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

              //  this.menuStrip.Enabled = false;


            }
            
        }
        
        private void crearRegistroToolStripMenuItem_Click(object sender, EventArgs e)
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




        private void Frm_Principal_Load(object sender, EventArgs e)
        {
            try
            {
           
                this.label21.Text = "Conectado";
                this.panel14.BackColor = Color.Green;
               
                this.MostrarBotonEstado();

                this.FormClosed += new FormClosedEventHandler(cerrarform);
                this.lblNombres.Text = CacheUsuario.Nombres;
                this.lblApellidos.Text = CacheUsuario.Apellidos;
                this.lblcarnet.Text = CacheUsuario.CodigoCarnet;
                this.lblTipoUsuario.Text = CacheUsuario.TipoUsuario;
               
                CacheDetalleProgramacion.Contador4 = true;

                this.AdministracionAcceso(CacheUsuario.TipoUsuario);
                this.MostrarCantidadActualUniverso();
              
                this.BuscarCjaAsignada();
              

            }
            catch (Exception)
            {

                this.panel14.BackColor = Color.Red;
                this.label21.Text = "Desconectado";
                this.MostrarBotonEstado();
                this.menuStrip.Enabled = false;
                
            }


        }


        private void MostrarBotonEstado()
        {
            if (this.label21.Text == "Conectado")
            {
                this.button1.Enabled = false;
                this.button1.Visible = false;
            }
            else if (this.label21.Text == "Desconectado")
            {
                this.button1.Enabled = true;
                this.button1.Visible = true;
            }

        }


        private void MostrarCantidadActualUniverso()
        {

            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            DataTable tabla = new DataTable();

            tabla = objetoCN.CalcularCantidadActualUniverso();
            if (tabla.Rows.Count == 0)
            {
                this.label7.Text = "0";
            }
            else
            {
                this.label7.Text = tabla.Rows[0][0].ToString();
            }

        }


        private void MostrarCantidadMatriculasHoy()
        {
            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            DataTable tabla = new DataTable();

            string FechaActual = DateTime.Now.ToShortDateString();

            tabla = objetoCN.CalcularCantidadActualUniversoHoy(Convert.ToDateTime(FechaActual));
            if (tabla.Rows.Count == 0)
            {
                this.label8.Text = "0";
            }
            else
            {
                this.label8.Text = tabla.Rows[0][0].ToString();
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


        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text = DateTime.Now.ToLongDateString();
            this.label2.Text = DateTime.Now.ToLongTimeString();


         

            try
            {
                this.MostrarCantidadActualUniverso();
                this.MostrarCantidadMatriculasHoy();

            }
            catch (Exception)
            {
                this.panel14.BackColor = Color.Red;
                this.label21.Text = "Desconectado";
                this.MostrarBotonEstado();

              this.menuStrip.Enabled = false;

            }


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
                this.panel14.BackColor = Color.Red;
                this.label21.Text = "Desconectado";
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
        
        


        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();

                if (conexion.Conexion().State == ConnectionState.Open)
                {
                    this.menuStrip.Enabled = true;
                    this.panel4.Enabled = true;

                  

                    this.panel14.BackColor = Color.Green;
                    this.label21.Text = "Conectado";
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

        private void solicitudDeCarnetEstudiantilToolStripMenuItem_Click(object sender, EventArgs e)
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
                Frm_ArqueodeCaja frm = new Frm_ArqueodeCaja();
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
            { "ControlAsistencia", controlDeAsistenciaToolStripMenuItem },
            { "GestionNotas", gestionDeNotasAcademicasToolStripMenuItem },
            { "SolicitudCarnet", solicitudDeCarnetEstudiantilToolStripMenuItem },
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
            {"ReporteAusencias",inasistenciasToolStripMenuItem},
            {"ReporteNoAsignado",matriculasNoAsignadosToolStripMenuItem},
            {"Acerca",acercaDeToolStripMenuItem },
            {"CarnetAdministracion",generarCarnetAdministracionToolStripMenuItem}
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
                FrmFacturasDeEstudiante frm = new FrmFacturasDeEstudiante();
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

        private void inasistenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                Frm_Inasistencias frm = new Frm_Inasistencias();
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
    }
    }


