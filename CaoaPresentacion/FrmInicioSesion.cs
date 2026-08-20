using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using CapaNegocio;
using CapaDatos;
using System.Net;
using System.IO;
using OfficeOpenXml;
using System.Globalization;
using System.Net.Mail;

namespace CaoaPresentacion
{
    public partial class FrmInicioSesion : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);


        CD_Conexion conexion = new CD_Conexion();
        string localIP;
        string FechaActual, HoraActual;
        private const int MaxIntentos = 3;
        private int intentosFallidos = 0;
        private bool mostrarContrasena = false;


        //Credenciales cuenta de Google para enviar Notificaciones del sistema
        const string Usuario = "registroacademico.mga2023@gmail.com";
        const string Password = "wxdeymkcmdrpszdx";
        string CodigoTemporal;
        
        
        public FrmInicioSesion()
        {
            InitializeComponent();
            this.comboBoxServidores.DropDownStyle = ComboBoxStyle.DropDownList;
            this.MouseDown += FrmInicioSesion_MouseDown;

        }

        private bool ValidarCampos()
        {
            bool valido = true;

            if (txtusuario.Text == "Ingresa tu usuario" ||
                string.IsNullOrWhiteSpace(txtusuario.Text))
            {
                valido = false;
                txtusuario.BackColor = Color.MistyRose;
            }
            else
            {
                txtusuario.BackColor = Color.White;
            }

            if (txtcontraseña.Text == "Ingresa tu contraseña" ||
                string.IsNullOrWhiteSpace(txtcontraseña.Text))
            {
                valido = false;
                txtcontraseña.BackColor = Color.MistyRose;
            }
            else
            {
                txtcontraseña.BackColor = Color.White;
            }

            if (!valido)
            {
                MessageBox.Show(
                    "Complete los campos requeridos para iniciar sesión.",
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                if (txtusuario.Text == "Ingresa tu usuario")
                    txtusuario.Focus();
                else
                    txtcontraseña.Focus();
            }

            return valido;
        }

        private void FrmInicioSesion_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xF012, 0);
        }

        private void FrmInicioSesion_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormClosed += new FormClosedEventHandler(cerrarform);

                txtusuario.ForeColor = Color.Gray;
                txtusuario.Text = "Ingresa tu usuario";

                txtcontraseña.UseSystemPasswordChar = false;
                txtcontraseña.ForeColor = Color.Gray;
                txtcontraseña.Text = "Ingresa tu contraseña";

                pictureBox2.Image = Properties.Resources.ojoCerrado;



                this.panel2.Visible = false;      // Oculta el formulario
                this.panel2.Enabled = false; // Deshabilita el panel

                this.panel3.Visible = false;      // Oculta el formulario
                this.panel3.Enabled = false; // Deshabilita el panel

                comboBoxServidores.Items.AddRange(ConfiguracionConexiones.CadenasConexion.Keys.ToArray());
                comboBoxServidores.SelectedIndex = 0; // Por defecto selecciona la primera opción

                this.MostrarRequisitos(textBox1.Text);


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cerrarform(object sender, EventArgs e)
        {

            try
            {
                Application.Exit();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



    

      

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                // Si está mostrando el placeholder, no hacer nada
                if (txtcontraseña.Text == "Ingresa tu contraseña")
                    return;

                mostrarContrasena = !mostrarContrasena;

                txtcontraseña.UseSystemPasswordChar = !mostrarContrasena;

                pictureBox2.Image = mostrarContrasena
                    ? Properties.Resources.ojo_abierto
                    : Properties.Resources.ojoCerrado;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            string opcionSeleccionada = comboBoxServidores.SelectedItem.ToString();
            string cadenaSeleccionada = ConfiguracionConexiones.CadenasConexion[opcionSeleccionada];

            // Crear la conexión o actualizar la existente
            CD_Conexion conexion = new CD_Conexion();
            conexion.CambiarConexion(cadenaSeleccionada);

            try
            {
                if (!ValidarCampos())
                    return;

                conexion.AbrirConexion();
                this.GuardarSesion(this.txtusuario.Text,this.txtcontraseña.Text); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex.Message, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void GuardarSesion(string usuario,string contraseña)
        {
            try
            {
                CN_Usuarios objetoCN = new CN_Usuarios();
                DataTable tabla = new DataTable();
                tabla = objetoCN.Login(usuario,contraseña);
                if (tabla.Rows.Count == 0)
                {
                    this.VerificarUsuario(usuario);
                }else if (tabla.Rows.Count != 0)
                {
                    /****************************************************************************/
                    CacheUsuario.IdUsuario = tabla.Rows[0][0].ToString();
                    CacheUsuario.Usuario = tabla.Rows[0][1].ToString();
                    CacheUsuario.IdEmpleado = tabla.Rows[0][3].ToString();
                    CacheUsuario.CodigoCarnet = tabla.Rows[0][4].ToString();
                    CacheUsuario.Nombres = tabla.Rows[0][5].ToString();
                    CacheUsuario.Apellidos = tabla.Rows[0][6].ToString();
                    CacheUsuario.Estado = tabla.Rows[0][8].ToString();
                    CacheUsuario.IdSucursal = tabla.Rows[0][9].ToString();
                    CacheUsuario.NombreSucursal = tabla.Rows[0][10].ToString();
                    CacheUsuario.DireccionSucursal = tabla.Rows[0][11].ToString();
                    /****************************************************************************/
                    Name = System.Windows.Forms.SystemInformation.ComputerName;
                    this.ObtenerIp();
                    FechaActual = DateTime.Now.ToShortDateString();
                    HoraActual = DateTime.Now.ToShortTimeString();
                    /****************************************************************************/
                    CN_ConexionesUsuarios objetoconexiones = new CN_ConexionesUsuarios();
                    DataTable tablaconexiones = new DataTable();
                    tablaconexiones = objetoconexiones.MostrarConexionesUsuarios(this.txtusuario.Text);
                    if (tablaconexiones.Rows.Count != 0)
                    {
                        string Estado = tablaconexiones.Rows[0][9].ToString();
                        if (Estado == "Conectado")
                        {
                            MessageBox.Show("No es posible iniciar sesión: el usuario ya está conectado en otro equipo.",
                            "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.button3.Visible = true;
                            this.button3.Enabled = true;
                            
                        }else if (Estado == "Desconectado")
                        {
                            RegistrarConexion(CacheUsuario.IdUsuario,localIP,usuario,contraseña,CacheUsuario.IdUsuario);
                        }
                    }else if (tablaconexiones.Rows.Count == 0)
                    {
                            RegistrarConexion(CacheUsuario.IdUsuario, localIP, usuario, contraseña, CacheUsuario.IdUsuario);

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex.Message, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void RegistrarConexion(string idUsuario, string localIP, string txtUsuario, string txtContraseña, string txtIdUsuario)
        {
            try
            {
                // Datos de sistema
                string name = System.Windows.Forms.SystemInformation.ComputerName;
                string fechaActual = DateTime.Now.ToShortDateString();
                string horaActual = DateTime.Now.ToShortTimeString();
                CacheUsuario.FechaIngreso = fechaActual;

                // Verificar estado del usuario
                CN_Usuarios objetoCN = new CN_Usuarios();
                DataTable tabla = objetoCN.VerificarEstado(idUsuario);
                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontro ningun usuario", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else if (tabla.Rows.Count != 0)
                {
                    string estado = tabla.Rows[0][2].ToString();
                    if (estado == "Inactivo")
                    {
                        MessageBox.Show("Este Usuario se encuentra Inactivo",
                        "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        txtusuario.Text = string.Empty;
                        txtcontraseña.Text = string.Empty;

                    } else if (estado == "Activo")
                    {
                        CN_Usuarios objetousuario = new CN_Usuarios();
                        DataTable tablaCaja = new DataTable();
                        tablaCaja = objetousuario.ObtenerCajaUsuario(idUsuario);
                        if (tablaCaja.Rows.Count == 0)
                        {
                            MessageBox.Show("Usuario sin Caja Asignada", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (tablaCaja.Rows.Count != 0)
                        {
                            CacheUsuario.IdCaja = tablaCaja.Rows[0][0].ToString();
                            CacheUsuario.Caja = tablaCaja.Rows[0][1].ToString();


                            CN_Usuarios objetoRol = new CN_Usuarios();
                            DataTable tablaRol = new DataTable();
                            tablaRol = objetoRol.ObtenerRolUsuario(idUsuario);
                            if (tablaRol.Rows.Count == 0)
                            {
                                MessageBox.Show("No se encuentra ningun Rol Asignado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }else if (tablaRol.Rows.Count > 1)
                            {
                                MessageBox.Show("Usuario no puede tener 2 Roles al mismo tiempo","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            }else if (tablaRol.Rows.Count == 1)
                            {
                                CacheUsuario.TipoUsuario = tablaRol.Rows[0][0].ToString();
                                Cargar_EstadoPermisos(CacheUsuario.TipoUsuario);

                                // Guardar conexión del usuario
                                CN_ConexionesUsuarios objetoConexion = new CN_ConexionesUsuarios();
                                string codigoAleatorio = GenerarCodigoAleatorio(15);
                                CacheUsuario.CodigoDeSesion = codigoAleatorio;
                                objetoConexion.InsertarConexionesUsuarios(
                                     codigoAleatorio,
                                     fechaActual,
                                     horaActual,
                                     name,
                                     localIP,
                                     idUsuario
                                 );

                                //valida que matriculas tienen mas de 30 dias ausentes apartir de la ultima vez que estaba ausente y valida si la mensualidad del mes actual este pendiente
                                EjecutarProcesoBajasAutomaticas();

                                Frm_Principal frm = new Frm_Principal();
                                frm.Show();
                                this.Hide();
                              
                            }
                            
                        }
                        
                    }

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex.Message, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EjecutarProcesoBajasAutomaticas()
        {
            try
            {
                CN_Bajas objetoCN = new CN_Bajas();

                objetoCN.EjecutarBajaAutomaticaInasistencia(
                    Convert.ToInt32(CacheUsuario.IdUsuario),
                    Environment.MachineName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible ejecutar la revisión automática de bajas.\n\n" +
                    ex.Message,
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }







        private void Cargar_EstadoPermisos(string TEXTO)
        {
            try
            {
                CN_Rol_Formularios objetoCN4 = new CN_Rol_Formularios();
                DataTable tabla = new DataTable();
                CachePosFormularios.TipoRol_de_Acceso = TEXTO;

                tabla = objetoCN4.Mostrar_FormulariosxRol_Estado(CachePosFormularios.TipoRol_de_Acceso);

                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("Error no se ningun Permiso con este Rol", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tabla.Rows.Count != 0)
                {
                    CachePosFormularios.Formulario1 = tabla.Rows[0][0].ToString();
                    CachePosFormularios.Formulario2 = tabla.Rows[1][0].ToString();
                    CachePosFormularios.Formulario3 = tabla.Rows[2][0].ToString();
                    CachePosFormularios.Formulario4 = tabla.Rows[3][0].ToString();
                    CachePosFormularios.Formulario5 = tabla.Rows[4][0].ToString();
                    CachePosFormularios.Formulario6 = tabla.Rows[5][0].ToString();
                    CachePosFormularios.Formulario7 = tabla.Rows[6][0].ToString();
                    CachePosFormularios.Formulario8 = tabla.Rows[7][0].ToString();
                    CachePosFormularios.Formulario9 = tabla.Rows[8][0].ToString();
                    CachePosFormularios.Formulario10 = tabla.Rows[9][0].ToString();
                    CachePosFormularios.Formulario11 = tabla.Rows[10][0].ToString();
                    CachePosFormularios.Formulario12 = tabla.Rows[11][0].ToString();
                    CachePosFormularios.Formulario13 = tabla.Rows[12][0].ToString();
                    CachePosFormularios.Formulario14 = tabla.Rows[13][0].ToString();
                    CachePosFormularios.Formulario15 = tabla.Rows[14][0].ToString();
                    CachePosFormularios.Formulario16 = tabla.Rows[15][0].ToString();
                    CachePosFormularios.Formulario17 = tabla.Rows[16][0].ToString();
                    CachePosFormularios.Formulario18 = tabla.Rows[17][0].ToString();
                    CachePosFormularios.Formulario19 = tabla.Rows[18][0].ToString();
                    CachePosFormularios.Formulario20 = tabla.Rows[19][0].ToString();
                    CachePosFormularios.Formulario21 = tabla.Rows[20][0].ToString();
                    CachePosFormularios.Formulario22 = tabla.Rows[21][0].ToString();
                    CachePosFormularios.Formulario23 = tabla.Rows[22][0].ToString();
                    CachePosFormularios.Formulario24 = tabla.Rows[23][0].ToString();
                    CachePosFormularios.Formulario25 = tabla.Rows[24][0].ToString();
                    CachePosFormularios.Formulario26 = tabla.Rows[25][0].ToString();
                    CachePosFormularios.Formulario27 = tabla.Rows[26][0].ToString();
                    CachePosFormularios.Formulario28 = tabla.Rows[27][0].ToString();
                    CachePosFormularios.Formulario29 = tabla.Rows[28][0].ToString();
                    CachePosFormularios.Formulario30 = tabla.Rows[29][0].ToString();
                    CachePosFormularios.Formulario31 = tabla.Rows[30][0].ToString();
                    CachePosFormularios.Formulario32 = tabla.Rows[31][0].ToString();

                    
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        
        private void ObtenerIp()
        {
            IPHostEntry host;

            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
        }

        static string GenerarCodigoAleatorio(int longitud)
        {
            const string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder resultado = new StringBuilder(longitud);
            Random random = new Random();

            for (int i = 0; i < longitud; i++)
            {
                int index = random.Next(caracteres.Length);
                resultado.Append(caracteres[index]);
            }

            return resultado.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string Usuario = this.txtusuario.Text;

                DataTable tabla = new DataTable();
                CN_ConexionesUsuarios objetoCN = new CN_ConexionesUsuarios();

                tabla = objetoCN.MostrarIdUsuario(Usuario);
                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("Usuario no Existe", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tabla.Rows.Count != 0)
                {
                    string IdUsuario = tabla.Rows[0][0].ToString();
                    CN_ConexionesUsuarios objeto = new CN_ConexionesUsuarios();
                    objeto.ActualizarConexiones(IdUsuario);
                    this.button3.Visible = false;
                    this.button3.Enabled = false;
                    MessageBox.Show("Conectese nuevamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtcontraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    this.GuardarSesion(this.txtusuario.Text, this.txtcontraseña.Text);
                }
             
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedIndex = 1;
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
                if (this.txtusuariorecuperacion.Text == string.Empty)
                {
                    MessageBox.Show("Ingresa su usuario", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }else if (this.txtCorreo.Text == string.Empty)
                {
                    MessageBox.Show("Ingresa su Correo", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {

                    CN_Personas objetoCN = new CN_Personas();
                    DataTable tabla = new DataTable();
                    tabla = objetoCN.VerificarCorreo(this.txtCorreo.Text, this.txtusuariorecuperacion.Text);
                    if (tabla.Rows.Count == 0)
                    {
                        MessageBox.Show("Error correo no encontrado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (tabla.Rows.Count != 0)
                    {
                        string fechaActual = DateTime.Now.ToLongDateString();
                        string horaActual = DateTime.Now.ToLongTimeString();

                        // Generar código de autorización
                        string codigo = generarcodigoSolicitud();
                        CodigoTemporal = codigo;

                        // Construcción del mensaje en HTML
                        StringBuilder mensajeBuilder = new StringBuilder();
                        mensajeBuilder.AppendLine("<html>");
                        mensajeBuilder.AppendLine("<body style='font-family: Arial, sans-serif; color:#333; background-color:#f9f9f9; padding:20px;'>");

                        mensajeBuilder.AppendLine("<div style='max-width:600px; margin:auto; background:#ffffff; border-radius:10px; box-shadow:0 0 10px rgba(0,0,0,0.1); padding:20px;'>");

                        mensajeBuilder.AppendLine("<h2 style='color:#0056b3; text-align:center;'>Actualización de Contraseña</h2>");
                        mensajeBuilder.AppendLine("<p style='text-align:center; font-size:14px; color:#666;'>");
                        mensajeBuilder.AppendLine("Fecha: <b>" + fechaActual + "</b><br>");
                        mensajeBuilder.AppendLine("Hora: <b>" + horaActual + "</b>");
                        mensajeBuilder.AppendLine("</p>");

                        mensajeBuilder.AppendLine("<hr style='border:none; border-top:1px solid #ddd; margin:20px 0;'>");

                        mensajeBuilder.AppendLine("<p style='font-size:16px; text-align:center;'>");
                        mensajeBuilder.AppendLine("Tu código de recuperación es:");
                        mensajeBuilder.AppendLine("</p>");

                        mensajeBuilder.AppendLine("<div style='text-align:center; margin:20px;'>");
                        mensajeBuilder.AppendLine("<span style='font-size:24px; font-weight:bold; color:#ffffff; background:#28a745; padding:10px 20px; border-radius:5px; display:inline-block;'>");
                        mensajeBuilder.AppendLine(codigo);
                        mensajeBuilder.AppendLine("</span>");
                        mensajeBuilder.AppendLine("</div>");

                        mensajeBuilder.AppendLine("<p style='text-align:center; font-size:14px; color:#555;'>");
                        mensajeBuilder.AppendLine("Utiliza este código para continuar con el proceso de actualización de tu contraseña.");
                        mensajeBuilder.AppendLine("</p>");

                        mensajeBuilder.AppendLine("<hr style='border:none; border-top:1px solid #ddd; margin:20px 0;'>");

                        mensajeBuilder.AppendLine("<p style='text-align:center; font-size:12px; color:#999;'>");
                        mensajeBuilder.AppendLine("¡Capacitación sin límites!");
                        mensajeBuilder.AppendLine("</p>");

                        mensajeBuilder.AppendLine("</div>");
                        mensajeBuilder.AppendLine("</body>");
                        mensajeBuilder.AppendLine("</html>");

                        // Envío de correo
                        string error;
                        Enviar(mensajeBuilder,
                               "registroacademico.mga2023@gmail.com",
                               this.txtCorreo.Text,
                               "Actualización de Contraseña",
                               out error);

                        this.panel2.Enabled = true;
                        this.panel2.Visible = true;

                        this.panel1.Enabled = false;

                    }
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Enviar(StringBuilder Mensaje, string De, string Para, string Asunto, out string Error)
        {
            Error = "";
            try
            {
                // Crear el mensaje
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(De);
                mail.To.Add(Para);
                mail.Subject = Asunto;
                mail.Body = Mensaje.ToString();
                mail.IsBodyHtml = true; // 👈 Esto indica que el contenido es HTML

                // Configuración SMTP
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(Usuario, Password);
                smtp.EnableSsl = true;

                // Enviar
                smtp.Send(mail);

                Error = "Se ha enviado un código temporal a su correo, no cierre esta ventana.";
                MessageBox.Show(Error, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Error = "Error: " + ex.Message;
                MessageBox.Show(Error, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }




        private string generarcodigoSolicitud()
        {
            string CodigoAnulacion = string.Empty;
            //creando una instancia de random
            Random aleatorio = new Random();
            CodigoAnulacion = Convert.ToString(aleatorio.Next(99999, 999999));
            return CodigoAnulacion;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigoTemporal.Text == CodigoTemporal)
                {
                    this.panel3.Enabled = true;
                    this.panel3.Visible = true;

                    this.panel2.Enabled = false;

                }else if (txtCodigoTemporal.Text != CodigoTemporal)
                {
                    MessageBox.Show("Codigo Incorrecto", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBox1.Text == string.Empty)
                {
                    MessageBox.Show("Ingresa la nueva contraseña", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }else
                {
                    if (ValidarContraseña(this.textBox1.Text, this.textBox1) == true)
                    {
                        string fechaActual = DateTime.Now.ToShortDateString();
                        CN_Usuarios objetoCN = new CN_Usuarios();
                        objetoCN.ActualizarContraseña(textBox1.Text, txtusuariorecuperacion.Text);
                        MessageBox.Show("Contraseña Actualizada Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        FrmInicioSesion frm = new FrmInicioSesion();
                        frm.Show();
                        this.Hide();
                    }

                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private bool ValidarContraseña(string contraseña, Control control)
        {
            // Limpiamos errores previos para ese control
            errorProvider1.SetError(control, "");

            if (string.IsNullOrWhiteSpace(contraseña))
            {
                errorProvider1.SetError(control, "La contraseña es obligatoria.");
                return false;
            }

            if (contraseña.Length < 5)
            {
                errorProvider1.SetError(control, "Debe tener al menos 5 caracteres.");
                return false;
            }

            if (!contraseña.Any(char.IsUpper))
            {
                errorProvider1.SetError(control, "Debe contener al menos una letra mayúscula.");
                return false;
            }

            if (!contraseña.Any(char.IsLower))
            {
                errorProvider1.SetError(control, "Debe contener al menos una letra minúscula.");
                return false;
            }

            if (!contraseña.Any(char.IsDigit))
            {
                errorProvider1.SetError(control, "Debe contener al menos un número.");
                return false;
            }

            if (!contraseña.Any(c => "!@#$%^&*()_+-=[]{}|;:,.<>?".Contains(c)))
            {
                errorProvider1.SetError(control, "Debe contener al menos un carácter especial.");
                return false;
            }

            if (contraseña.Contains(" "))
            {
                errorProvider1.SetError(control, "No se permiten espacios en blanco.");
                return false;
            }

            // ✅ Validar que no haya números consecutivos
            if (TieneNumerosConsecutivos2(contraseña))
            {
                errorProvider1.SetError(control, "No debe contener números consecutivos (ej. 123 o 4567).");
                return false;
            }

            return true; // ✅ La contraseña cumple todas las condiciones
        }

        private bool TieneNumerosConsecutivos2(string texto)
        {
            int consecutivosAsc = 1;
            int consecutivosDesc = 1;

            for (int i = 1; i < texto.Length; i++)
            {
                if (char.IsDigit(texto[i]) && char.IsDigit(texto[i - 1]))
                {
                    int actual = (int)char.GetNumericValue(texto[i]);
                    int anterior = (int)char.GetNumericValue(texto[i - 1]);

                    if (actual == anterior + 1)
                    {
                        consecutivosAsc++;
                        consecutivosDesc = 1; // reset descendente
                    }
                    else if (actual == anterior - 1)
                    {
                        consecutivosDesc++;
                        consecutivosAsc = 1; // reset ascendente
                    }
                    else
                    {
                        consecutivosAsc = 1;
                        consecutivosDesc = 1;
                    }

                    if (consecutivosAsc >= 3 || consecutivosDesc >= 3)
                    {
                        return true; // Hay una secuencia de al menos 3 números consecutivos
                    }
                }
                else
                {
                    consecutivosAsc = 1;
                    consecutivosDesc = 1;
                }
            }

            return false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.MostrarRequisitos(textBox1.Text);
        }


        private void MostrarRequisitos(string contraseña)
        {


            // Validaciones
            bool largo = contraseña.Length >= 5;
            bool mayuscula = contraseña.Any(char.IsUpper);
            bool minuscula = contraseña.Any(char.IsLower);
            bool numero = contraseña.Any(char.IsDigit);
            bool especial = contraseña.Any(c => "!@#$%^&*()_+-=[]{}|;:,.<>?".Contains(c));
            bool sinEspacios = !contraseña.Contains(" ");
            bool sinConsecutivos = !TieneNumerosConsecutivos(contraseña);

            // Construimos el checklist con ✔ ❌ y colores en varias líneas
            lblRequisitos.Text =
                $"{(largo ? "✅" : "❌")} Mínimo 5 caracteres{Environment.NewLine}" +
                $"{(mayuscula ? "✅" : "❌")} Una letra mayúscula{Environment.NewLine}" +
                $"{(minuscula ? "✅" : "❌")} Una letra minúscula{Environment.NewLine}" +
                $"{(numero ? "✅" : "❌")} Un número{Environment.NewLine}" +
                $"{(especial ? "✅" : "❌")} Un carácter especial (!@#$...){Environment.NewLine}" +
                $"{(sinEspacios ? "✅" : "❌")} Sin espacios{Environment.NewLine}" +
                $"{(sinConsecutivos ? "✅" : "❌")} Sin números consecutivos";
        }

        private bool TieneNumerosConsecutivos(string texto)
        {
            int consecutivosAsc = 1;
            int consecutivosDesc = 1;

            for (int i = 1; i < texto.Length; i++)
            {
                if (char.IsDigit(texto[i]) && char.IsDigit(texto[i - 1]))
                {
                    int actual = (int)char.GetNumericValue(texto[i]);
                    int anterior = (int)char.GetNumericValue(texto[i - 1]);

                    if (actual == anterior + 1) // Ascendente (1,2)
                    {
                        consecutivosAsc++;
                        consecutivosDesc = 1;
                    }
                    else if (actual == anterior - 1) // Descendente (3,2)
                    {
                        consecutivosDesc++;
                        consecutivosAsc = 1;
                    }
                    else
                    {
                        consecutivosAsc = 1;
                        consecutivosDesc = 1;
                    }

                    if (consecutivosAsc >= 3 || consecutivosDesc >= 3)
                    {
                        return true; // Hay 3 o más números consecutivos
                    }
                }
                else
                {
                    consecutivosAsc = 1;
                    consecutivosDesc = 1;
                }
            }

            return false; // No hay números consecutivos
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtusuariorecuperacion.Text = string.Empty;
                this.txtCorreo.Text = string.Empty;
                this.txtCodigoTemporal.Text = string.Empty;
                this.textBox1.Text = string.Empty;

                this.tabControl1.SelectedIndex = 0;

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPage1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xF012, 0);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtusuario_Enter(object sender, EventArgs e)
        {
            if (txtusuario.Text == "Ingresa tu usuario")
            {
                txtusuario.Text = "";
                txtusuario.ForeColor = Color.Black;
            }
        }

        private void txtusuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtusuario.Text))
            {
                txtusuario.Text = "Ingresa tu usuario";
                txtusuario.ForeColor = Color.Gray;
            }
        }

        private void txtcontraseña_Enter(object sender, EventArgs e)
        {
            if (txtcontraseña.Text == "Ingresa tu contraseña")
            {
                txtcontraseña.Text = "";
                txtcontraseña.ForeColor = Color.Black;
                txtcontraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtcontraseña_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcontraseña.Text))
            {
                txtcontraseña.UseSystemPasswordChar = false;
                txtcontraseña.ForeColor = Color.Gray;
                txtcontraseña.Text = "Ingresa tu contraseña";
            }
        }

        private void VerificarUsuario(string usuario)
        {
            CN_Usuarios usuarioCN = new CN_Usuarios();
            DataTable resultado = usuarioCN.VerificarUsuario(usuario);

            if (resultado.Rows.Count == 0)
            {
                MessageBox.Show("El usuario no existe.",
                                "SISTEMA CECNIC",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            intentosFallidos++;
            int intentosRestantes = MaxIntentos - intentosFallidos;

            if (intentosRestantes > 0)
            {
                MessageBox.Show($"Contraseña incorrecta. Te quedan {intentosRestantes} intento(s).",
                                "SISTEMA CECNIC",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtcontraseña.Clear();
            }
            else
            {
                usuarioCN.InactivarUser(txtusuario.Text);
                MessageBox.Show("Has superado el número máximo de intentos. El usuario ha sido inactivado.",
                                "SISTEMA CECNIC",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtusuario.Clear();
                txtcontraseña.Clear();
                intentosFallidos = 0; // Reiniciar contador en caso de reintento futuro
            }
        }








    }
}
