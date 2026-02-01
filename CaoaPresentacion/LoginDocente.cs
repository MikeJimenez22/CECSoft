using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;
using System.Net;

namespace CaoaPresentacion
{
    public partial class LoginDocente : Form
    {
        public LoginDocente()
        {
            InitializeComponent();
        }

        int Contador;
        DataTable tabla = new DataTable();
        string localIP = "";
        CD_Conexion conexion = new CD_Conexion();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarSesion();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GuardarSesion()
        {
            try
            {

                CN_Usuarios objetoCN = new CN_Usuarios();
               


                tabla = objetoCN.Login(this.txtusuario.Text, this.txtcontraseña.Text);
                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("Error al Iniciar Sesion");
                    this.VerificarUsuario(this.txtusuario.Text);
                }
                else
                {

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
                    
                        DataTable tabla3 = new DataTable();
                        CN_Usuarios objetoCN3 = new CN_Usuarios();
                        tabla = objetoCN3.VerificarEstado(CacheUsuario.IdUsuario);

                        string Estado = tabla.Rows[0][2].ToString();
                        if (Estado == "Inactivo")
                        {
                            MessageBox.Show("Este Usuario se encuentra Inactivo");
                            this.txtusuario.Text = string.Empty;
                            this.txtcontraseña.Text = string.Empty;
                            CacheUsuario objeto = new CacheUsuario();
                            objeto.EliminarValores();
                           
                        }
                        else
                        {
                            string name = System.Windows.Forms.SystemInformation.ComputerName;
                            this.ObtenerIp();
                            string FechaActual = DateTime.Now.ToShortDateString();
                            string HorActual = DateTime.Now.ToShortTimeString();
                            CacheUsuario.FechaIngreso = FechaActual.ToString();

                            /*Aca guardamos la conexion del Usuario*/

                            CN_ConexionesUsuarios objetoConexion = new CN_ConexionesUsuarios();
                            string codigoAleatorio = GenerarCodigoAleatorio(15);
                            objetoConexion.InsertarConexionesUsuarios(codigoAleatorio, FechaActual, HorActual, name, localIP, CacheUsuario.IdUsuario);
                            CacheUsuario.CodigoDeSesion = codigoAleatorio.ToString();

                        this.Hide();
                        Frm_Docente frm = new Frm_Docente();
                        frm.Show();

                            

                        

                      }
                    
                  }

            
                }
            
            catch (Exception)
            {
                MessageBox.Show("Error de Sesion, No se puede conectar con el Servidor,Verifique su Conexion", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("");
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

        private void VerificarUsuario(string texto)
        {
            CN_Usuarios objetoCN = new CN_Usuarios();
            DataTable tabla3 = new DataTable();
            tabla3 = objetoCN.VerificarUsuario(texto);

            if (tabla3.Rows.Count == 0)
            {
                MessageBox.Show("Usuario no Existe", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                int ContadorFinal = 3;
                Contador = Contador + 1;
                int ValorFinal;

                ValorFinal = ContadorFinal - Contador;
                MessageBox.Show("Te quedan " + ValorFinal + " Intentos", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtcontraseña.Text = string.Empty;
                if (ValorFinal == 0)
                {
                    objetoCN.InactivarUser(this.txtusuario.Text);
                    MessageBox.Show("Usuario Inactivado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtusuario.Text = string.Empty;
                    this.txtcontraseña.Text = string.Empty;
                }


            }

        }

        private void LoginDocente_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(cerrarform);
            this.txtusuario.Focus();
        }

        private void cerrarform(object sender, EventArgs e)
        {
            FrmOpcionesAcceso frm = new FrmOpcionesAcceso();
            frm.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.checkBox1.Checked == false)
                {
                    this.checkBox1.Checked = true;
                }
                else if (this.checkBox1.Checked == true)
                {
                    this.checkBox1.Checked = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.checkBox1.Checked == false)
                {
                    txtcontraseña.UseSystemPasswordChar = false;
                }
                else if (this.checkBox1.Checked == true)
                {
                    txtcontraseña.UseSystemPasswordChar = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
