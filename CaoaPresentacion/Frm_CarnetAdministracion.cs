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
using System.Drawing.Imaging;

namespace CaoaPresentacion
{
    public partial class Frm_CarnetAdministracion : Form
    {
        public Frm_CarnetAdministracion()
        {
            InitializeComponent();
            DataGridViewConfigurator.Configure(this.dataEmpleados);
        }

        private void Frm_CarnetAdministracion_Load(object sender, EventArgs e)
        {
            try
            {
                pbFotoEmpleado.Image = Properties.Resources.sin_perfil;
                pbFotoEmpleado.Tag = "default";
                pbFotoEmpleado.SizeMode = PictureBoxSizeMode.Zoom;

                PictureBoxCarnet.Size = new Size(638, 1013);
                PictureBoxCarnet.SizeMode = PictureBoxSizeMode.StretchImage;

                this.AgregarColumnaConIcono();
                this.ObtenerListadoEmpleadosActivos();

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerListadoEmpleadosActivos()
        {
            try
            {
                CN_Empleados objetoCN = new CN_Empleados();
                this.dataEmpleados.DataSource = objetoCN.Mostrar();
                this.OcultarColumnas();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OcultarColumnas()
        {
            try
            {
                dataEmpleados.Columns["Cedula"].Visible = false;
                //dataEmpleados.Columns["N_Inss"].Visible = false;
                // dataEmpleados.Columns["Estado_Civil"].Visible = false;
                dataEmpleados.Columns["Id_empleado"].Visible = false;
                dataEmpleados.Columns["Id_estado"].Visible = false;
                dataEmpleados.Columns["Id_persona"].Visible = false;
                dataEmpleados.Columns["Fecha_Ingreso"].Visible = false;
                // dataEmpleados.Columns["Fecha_Salida"].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedTab = tabEmpleados;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                dataEmpleados.Columns.Add(btnColumna);


                // Evento para dibujar iconos
                dataEmpleados.CellPainting += dataEmpleados_CellPainting;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataEmpleados_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataEmpleados.Columns["Seleccionar"].Index && e.RowIndex >= 0)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    // Cargar el ícono desde recursos (recomendado) o archivo
                    Bitmap icon = Properties.Resources.check1; // Usa tu recurso de imagen
                    int iconWidth = 16;
                    int iconHeight = 16;

                    // Posición centrada en la celda
                    int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                    int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                    e.Graphics.DrawImage(icon, new Rectangle(x, y, iconWidth, iconHeight));
                    e.Handled = true; // Indica que la celda está completamente pintada
                }



            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (this.dataEmpleados.Columns[e.ColumnIndex].Name == "Seleccionar")
                {

                    this.txtNombreEmpleado.Text = this.dataEmpleados.CurrentRow.Cells["Nombres"].Value.ToString();
                    this.txtApellidosEmpleado.Text = this.dataEmpleados.CurrentRow.Cells["Apellidos"].Value.ToString();
                    this.txtCodCarnet.Text = this.dataEmpleados.CurrentRow.Cells["Cod_Carnet"].Value.ToString();
                    this.txtTipoEmpleado.Text = this.dataEmpleados.CurrentRow.Cells["Tipo_Empleado"].Value.ToString();
                    this.tabControl1.SelectedTab = tabInicio;

                }



            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog
                {
                    Title = "Seleccionar imagen del empleado",
                    Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp"
                };

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (var imgTemp = Image.FromFile(ofd.FileName))
                    {
                        pbFotoEmpleado.Image = new Bitmap(imgTemp);
                    }
                    pbFotoEmpleado.Tag = "seleccionada";
                    pbFotoEmpleado.SizeMode = PictureBoxSizeMode.Zoom;
                    MessageBox.Show("Imagen Seleccionada Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                // Liberar imagen actual si existe
                if (pbFotoEmpleado.Image != null)
                {
                    pbFotoEmpleado.Image.Dispose();
                    pbFotoEmpleado.Image = null;
                }

               
                // Volver a la imagen por defecto
                pbFotoEmpleado.Image = Properties.Resources.sin_perfil;
                pbFotoEmpleado.Tag = "default";
                pbFotoEmpleado.SizeMode = PictureBoxSizeMode.Zoom;
                MessageBox.Show("Imagen Eliminada", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_CarnetAdministracion frm = new Frm_CarnetAdministracion();
                frm.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreEmpleado.Text))
                {
                    MessageBox.Show("Selecciona un Empleado",
                                    "SISTEMA CECNIC",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // VALIDAR FOTO
                if (pbFotoEmpleado.Tag == null || pbFotoEmpleado.Tag.ToString() == "default")
                {
                    MessageBox.Show("Debes seleccionar una foto del empleado",
                                    "SISTEMA CECNIC",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                
                this.lblNombre.Text = this.txtNombreEmpleado.Text;
                this.lblApellidos.Text = this.txtApellidosEmpleado.Text;
                this.lblTipoEmpleado.Text = this.txtTipoEmpleado.Text;
                this.lblCarnet.Text = this.txtCodCarnet.Text;


                // Copiar imagen al PictureBox del carnet
                pbCarnet.Image = (Image)pbFotoEmpleado.Image.Clone();
                pbCarnet.SizeMode = PictureBoxSizeMode.Zoom;

                // (opcional) copiar el tag si lo usás para validaciones
                pbCarnet.Tag = pbFotoEmpleado.Tag;

                GenerarCarnetCompleto();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema: " + ex.Message,
                                "SISTEMA CECNIC",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }
        private void GenerarCarnetCompleto()
        {
            try
            {
                int ancho = 638;
                int alto = 1013;

                Bitmap imagenCarnet = new Bitmap(ancho, alto);
                imagenCarnet.SetResolution(300, 300);

                using (Graphics g = Graphics.FromImage(imagenCarnet))
                {
                    // Calidad de dibujo
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                    // Fondo blanco
                    g.Clear(Color.White);

                    // 1️⃣ Fondo del carnet
                    DibujarFondoCarnet(g, ancho, alto);

                    // 2️⃣ Foto del empleado
                    DibujarFotoEmpleado(g);

                    

                    // 4️⃣ Labels
                    DibujarLabel(g, lblNombre);
                    DibujarLabel(g, lblApellidos);
                    DibujarLabel(g, lblTipoEmpleado);
                    DibujarLabel(g, lblCarnet);
                    // Agregar más labels si es necesario
                }

                GuardarImagen(imagenCarnet);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema: " + ex.Message,
                                "SISTEMA CECNIC",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void DibujarFondoCarnet(Graphics g, int anchoBitmap, int altoBitmap)
        {
            if (PictureBoxCarnet.Image != null)
            {
                // Mantener proporción original del fondo
                float ratio = (float)PictureBoxCarnet.Image.Width / PictureBoxCarnet.Image.Height;
                int anchoDibujo = anchoBitmap;
                int altoDibujo = altoBitmap;

                if (anchoBitmap / (float)altoBitmap > ratio)
                {
                    anchoDibujo = (int)(altoBitmap * ratio);
                }
                else
                {
                    altoDibujo = (int)(anchoBitmap / ratio);
                }

                int posX = (anchoBitmap - anchoDibujo) / 2;
                int posY = (altoBitmap - altoDibujo) / 2;

                g.DrawImage(PictureBoxCarnet.Image, posX, posY, anchoDibujo, altoDibujo);
            }
        }

        private void DibujarFotoEmpleado(Graphics g)
        {
            if (pbCarnet.Image != null)
            {
                int anchoOriginal = pbCarnet.Image.Width;
                int altoOriginal = pbCarnet.Image.Height;

                int anchoMax = pbCarnet.Width;
                int altoMax = pbCarnet.Height;

                float ratio = Math.Min((float)anchoMax / anchoOriginal, (float)altoMax / altoOriginal);

                int anchoDibujo = (int)(anchoOriginal * ratio);
                int altoDibujo = (int)(altoOriginal * ratio);

                int posX = pbCarnet.Location.X + (anchoMax - anchoDibujo) / 2;
                int posY = pbCarnet.Location.Y + (altoMax - altoDibujo) / 2;

                g.DrawImage(pbCarnet.Image, posX, posY, anchoDibujo, altoDibujo);
            }
        }



        private void DibujarLabel(Graphics g, Label lbl)
        {
            float escala = g.DpiY / 96f; // 96 DPI estándar de WinForms

            using (Font fuenteAjustada = new Font(
                lbl.Font.FontFamily,
                lbl.Font.Size / escala,
                lbl.Font.Style))
            {
                g.DrawString(lbl.Text,
                             fuenteAjustada,
                             new SolidBrush(lbl.ForeColor),
                             lbl.Location);
            }
        }



        private void GuardarImagen(Bitmap imagen)
        {
            try
            {
                string fecha = DateTime.Now.ToString("ddMMyyyy_HHmmssfff");
                string nombreImagen = $"Carnet_{fecha}";

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Imagen PNG|*.png";
                    sfd.FileName = nombreImagen;
                    sfd.Title = "Guardar carnet";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        imagen.Save(sfd.FileName, ImageFormat.Png);

                        MessageBox.Show("Carnet generado correctamente",
                                        "SISTEMA CECNIC",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la imagen: " + ex.Message,
                                "SISTEMA CECNIC",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            finally
            {
                imagen.Dispose();
            }

            // Abrir nuevo formulario
            Frm_CarnetAdministracion frm = new Frm_CarnetAdministracion();
            frm.Show();
            this.Hide();
        }
    }
}

