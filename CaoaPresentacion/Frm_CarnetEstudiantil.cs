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
using CapaNegocio;
using Utils;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using QRCoder;
using ZXing;
using ZXing.Common;

namespace CaoaPresentacion
{
    public partial class Frm_CarnetEstudiantil : Form
    {
        public Frm_CarnetEstudiantil()
        {
            InitializeComponent();
            DataGridViewConfigurator.Configure(this.dataListadoCarnet);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CN_Estudiantes objetoCN = new CN_Estudiantes();
                this.dataListadoCarnet.DataSource = objetoCN.MostrarCarnetEstudiantesListado(this.dateTimePicker1.Text, this.dateTimePicker2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.RecorrerCadaFila();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void RecorrerCadaFila()
        {
            try
            {
                // Preparar carpeta solo una vez
                string rutaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string fechaActual = DateTime.Now.ToString("dd-MM-yyyy");
                string nombreCarpeta = $"Carnet Estudiantes {fechaActual}";
                string rutaCompleta = Path.Combine(rutaDocumentos, nombreCarpeta);

                if (!Directory.Exists(rutaCompleta))
                {
                    Directory.CreateDirectory(rutaCompleta);
                    MessageBox.Show($"Carpeta creada con éxito:\n{rutaCompleta}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                foreach (DataGridViewRow fila in dataListadoCarnet.Rows)
                {
                    if (fila.IsNewRow) continue;

                    // Obtener los datos de la fila
                    string NombreSucursal = fila.Cells["NombreSucursal"].Value?.ToString();
                    string Carnet = fila.Cells["Cod_carnet"].Value?.ToString();
                    string Estudiante = fila.Cells["Estudiante"].Value?.ToString();
                    string Cursos = fila.Cells["Cursos"].Value?.ToString();
                    string Turnos = fila.Cells["Turnos"].Value?.ToString();
                    string Horarios = fila.Cells["Horarios"].Value?.ToString();
                    string FechaEmision = fila.Cells["FechaEmision"].Value?.ToString();
                    string FechaVencimiento = fila.Cells["FechaVencimiento"].Value?.ToString();

                

                    // Asignar datos a los labels del formulario
                    lblNombres.Text = Estudiante;
                    lblcurso.Text = string.Join(Environment.NewLine, Enumerable.Range(0, (Cursos.Length + 59) / 60).Select(i => Cursos.Substring(i * 60, Math.Min(60, Cursos.Length - i * 60))));
                    lblCodigoCarnet.Text = Carnet;
                    lblFechaEmision.Text = Convert.ToDateTime(FechaEmision).ToShortDateString();
                    lblFechaVencimiento.Text = Convert.ToDateTime(FechaVencimiento).ToShortDateString();
                    lblTurno.Text = string.Join(Environment.NewLine, Enumerable.Range(0, (Turnos.Length + 24) / 25).Select(i => Turnos.Substring(i * 20, Math.Min(20, Turnos.Length - i * 25))));
                    labelHorario.Text = string.Join(Environment.NewLine, Enumerable.Range(0, (Horarios.Length + 24) / 25).Select(i => Horarios.Substring(i * 20, Math.Min(20, Horarios.Length - i * 25))));
                    labelSucursal.Text = NombreSucursal;

                    // Asignar nombres completos para nombrar la imagen
                    lblNombres.Text = Estudiante;

                    // Generar código de barras
                    GenerarCodigoBarraEstudiante(Carnet);

                    // Generar imagen del carnet
                    GenerarCodigoImpresionCarnet(rutaCompleta);
                }

                MessageBox.Show("Proceso terminado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarCodigoImpresionCarnet(string rutaCarpeta)
        {
            try
            {
                int ancho = 638;
                int alto = 1013;
                Bitmap imagenGuardada = new Bitmap(ancho, alto);
                string fecha = DateTime.Now.ToString("ddMMyyyy");

                using (Graphics g = Graphics.FromImage(imagenGuardada))
                {
                    g.Clear(Color.White);

                    if (PictureBoxCarnet.Image != null)
                    {
                        g.DrawImage(PictureBoxCarnet.Image, 0, 0, PictureBoxCarnet.Width, PictureBoxCarnet.Height);
                    }

                    if (pictureBoxBarcode.Image != null)
                    {
                        g.DrawImage(pictureBoxBarcode.Image, pictureBoxBarcode.Location.X, pictureBoxBarcode.Location.Y, pictureBoxBarcode.Width, pictureBoxBarcode.Height);
                    }

                    g.DrawString(lblNombres.Text, lblNombres.Font, Brushes.Navy, lblNombres.Location);
                    g.DrawString(lblcurso.Text, lblcurso.Font, Brushes.Navy, lblcurso.Location);
                    g.DrawString(lblCodigoCarnet.Text, lblCodigoCarnet.Font, Brushes.Navy, lblCodigoCarnet.Location);
                    g.DrawString(lblFechaEmision.Text, lblFechaEmision.Font, Brushes.Navy, lblFechaEmision.Location);
                    g.DrawString(labelHorario.Text, labelHorario.Font, Brushes.Navy, labelHorario.Location);
                    g.DrawString(lblFechaVencimiento.Text, lblFechaVencimiento.Font, Brushes.Navy, lblFechaVencimiento.Location);
                    g.DrawString(lblTurno.Text, lblTurno.Font, Brushes.Navy, lblTurno.Location);
                    g.DrawString(labelSucursal.Text, labelSucursal.Font, Brushes.Navy, labelSucursal.Location);
                }

                string nombreImagen = $"Carnet_{lblNombres.Text}__{fecha}.png";
                string rutaArchivo = Path.Combine(rutaCarpeta, nombreImagen);
                imagenGuardada.Save(rutaArchivo, System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarCodigoBarraEstudiante(string CodigoCarnet)
        {
            // Crear un generador de código de barras
            BarcodeWriter barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128, // Formato de código de barras
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = 300,  // Ancho del código de barras
                    Height = 150, // Altura del código de barras
                    PureBarcode = true // ❗ Esta línea elimina el texto debajo del código de barras
                }
            };

            // Generar el código de barras y convertirlo en una imagen
            Bitmap barcodeBitmap = barcodeWriter.Write(CodigoCarnet);

            // Mostrar la imagen del código de barras en el PictureBox
            pictureBoxBarcode.Image = barcodeBitmap;
        }



        private void Frm_CarnetEstudiantil_Load(object sender, EventArgs e)
        {

        }
    }
}
