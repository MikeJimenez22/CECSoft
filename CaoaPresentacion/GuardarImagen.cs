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
using System.IO;
using System.Drawing.Imaging;

using CapaDatos;

using CapaNegocio;

namespace CaoaPresentacion
{
    public partial class GuardarImagen : Form
    {

        SqlConnection cn = new SqlConnection();

        public GuardarImagen()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialogo = new OpenFileDialog();
                DialogResult resultado = dialogo.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    ptbImagen.Image = Image.FromFile(dialogo.FileName);
                    ptbImagen.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                MemoryStream archivoMemoria = new MemoryStream();
                string rpt;

                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                cmd.Connection = cn;
                ptbImagen.Image.Save(archivoMemoria,ImageFormat.Bmp);
                cmd.CommandText = "Insertar_Imagen";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idUsuario",Convert.ToInt32(CacheUsuario.IdUsuario));
                cmd.Parameters.AddWithValue("@imagen",archivoMemoria.GetBuffer());
                rpt = cmd.ExecuteNonQuery()>0?"ok se guardo la imagen":"no se guardo";
                conexion.CerrarConexion();


            }
            catch (Exception ex)
            {
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                DataTable tabla = new DataTable();

                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                cmd.Connection = cn;

                cmd.CommandText = "VerImagen";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Idusuario", Convert.ToInt32(CacheUsuario.IdUsuario));

                SqlDataAdapter llenar = new SqlDataAdapter(cmd);
                llenar.Fill(tabla);

                Byte[] archivo = (byte[])tabla.Rows[0]["imagen"];

                Stream imagenn = new MemoryStream(archivo);
                ptbImagen.Image = Image.FromStream(imagenn);
                ptbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                conexion.CerrarConexion();



            }
            catch (Exception ex)
            {
               
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                CN_Usuarios objetoCN = new CN_Usuarios();

                objetoCN.EliminarFoto(CacheUsuario.IdUsuario);
                MessageBox.Show("Foto Eliminada Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarImagen_Load(object sender, EventArgs e)
        {

        }
    }
}
