using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using Utils;

namespace CaoaPresentacion
{
    public partial class Frm_HistorialFacturasEstudiante : Form
    {
        string Estado;

        public Frm_HistorialFacturasEstudiante()
        {
            InitializeComponent();
            this.cmbBusquedas.DropDownStyle = ComboBoxStyle.DropDownList;
            DataGridViewConfigurator.Configure(dataEstudiantes,dataFacturas,dataDetalleFactura);
            dataFacturas.CellFormatting += dataFacturas_CellFormatting;
        }

        private void dataFacturas_CellFormatting(
    object sender,
    DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dataFacturas.Columns[e.ColumnIndex].Name != "Origen")
                return;

            if (e.Value == null)
                return;

            string origen = e.Value.ToString().Trim().ToUpper();

            if (origen == "POR MATRICULA")
            {
                e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);
                e.CellStyle.ForeColor = Color.FromArgb(21, 128, 61);
                e.CellStyle.Font = new Font(dataFacturas.Font, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else if (origen == "HISTORICA POR CARNET")
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 237, 213);
                e.CellStyle.ForeColor = Color.FromArgb(194, 65, 12);
                e.CellStyle.Font = new Font(dataFacturas.Font, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            this.Estado = "3";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            this.Estado = "4";
        }

        private void Frm_HistorialFacturasEstudiante_Load(object sender, EventArgs e)
        {
            try
            {
                this.radioButton6.Checked = true;
                this.cmbBusquedas.Text = "APELLIDOS";
                lbltotalFacturas.Text = "0";
                lblTotalPagado.Text = "0";
                lblPrimeraFactura.Text = "-";
                lblUltimaFactura.Text = "-";

                this.AgregarColumnaConIcono();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtbusqueda.Text == string.Empty)
                {
                    MessageBox.Show(
                      "Por favor, ingrese un criterio de búsqueda antes de continuar.",
                      "SISTEMA CECNIC",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Warning);
                    return;
                }

                this.MostrarMatriculas();


            }
            catch (Exception)
            {
                MessageBox.Show("Error: ", "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarMatriculas()
        {
            try
            {
                CN_Matriculas objetoCN = new CN_Matriculas();
                dataEstudiantes.DataSource = objetoCN.MostrarMatriculas(this.txtbusqueda.Text, Convert.ToInt32(Estado), cmbBusquedas.Text);
                ActualizarBotonSeleccionar(dataEstudiantes);
                OcultarColumnas();
                ContarFilas();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK);
            }
        }

        private void ContarFilas()
        {
            this.lbltotal.Text = Convert.ToString(this.dataEstudiantes.Rows.Count);
        }

        private void OcultarColumnas()
        {
            this.dataEstudiantes.Columns["Fecha"].Visible = false;
            this.dataEstudiantes.Columns["Fecha_Registro"].Visible = false;
            this.dataEstudiantes.Columns["HoraRegistro"].Visible = false;
            this.dataEstudiantes.Columns["Cedula"].Visible = false;
            this.dataEstudiantes.Columns["FechaNacimiento"].Visible = false;
            this.dataEstudiantes.Columns["Id_Matricula"].Visible = false;
            this.dataEstudiantes.Columns["Id_Grupo"].Visible = false;
            this.dataEstudiantes.Columns["Estado"].Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = tabEstudiante;
        }

        private void AgregarColumnaConIcono()
        {
            try
            {
                // BOTÓN ESTUDIANTES
                DataGridViewButtonColumn btnEstudiante = new DataGridViewButtonColumn();

                btnEstudiante.HeaderText = "Seleccionar";
                btnEstudiante.Name = "Seleccionar";
                btnEstudiante.Text = "";
                btnEstudiante.UseColumnTextForButtonValue = false;

                // Inicialmente oculto
                btnEstudiante.Visible = false;

                dataEstudiantes.Columns.Add(btnEstudiante);


                // BOTÓN FACTURAS
                DataGridViewButtonColumn btnFactura = new DataGridViewButtonColumn();

                btnFactura.HeaderText = "Seleccionar";
                btnFactura.Name = "Seleccionar";
                btnFactura.Text = "";
                btnFactura.UseColumnTextForButtonValue = false;

                // Inicialmente oculto
                btnFactura.Visible = false;

                dataFacturas.Columns.Add(btnFactura);


                // Eventos
                dataEstudiantes.CellPainting += dataEstudiantes_CellPainting;
                dataFacturas.CellPainting += dataFacturas_CellPainting;
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Error de Sistema",
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ActualizarBotonSeleccionar(DataGridView dgv)
        {
            if (dgv.Columns.Contains("Seleccionar"))
            {
                dgv.Columns["Seleccionar"].Visible = dgv.Rows.Count > 0;
            }
        }

        private void dataEstudiantes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    Color fondo = Color.White;
                    Bitmap icon = null;

                    if (e.ColumnIndex == dataEstudiantes.Columns["Seleccionar"].Index)
                    {
                        fondo = Color.SteelBlue; // Azul hielo
                        icon = Properties.Resources.edit_button;
                    }
                   

                    if (icon != null)
                    {
                        // Pintar fondo personalizado
                        using (SolidBrush brush = new SolidBrush(fondo))
                        {
                            e.Graphics.FillRectangle(brush, e.CellBounds);
                        }

                        // Dibujar bordes normales de la celda
                        e.Paint(e.CellBounds, DataGridViewPaintParts.Border);

                        // Tamaño del icono
                        int iconWidth = 16;
                        int iconHeight = 16;

                        // Centrar icono
                        int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                        int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                        e.Graphics.DrawImage(icon, new Rectangle(x, y, iconWidth, iconHeight));

                        e.Handled = true;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Error de Sistema",
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void dataFacturas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    Color fondo = Color.White;
                    Bitmap icon = null;

                    if (e.ColumnIndex == dataFacturas.Columns["Seleccionar"].Index)
                    {
                        fondo = Color.SteelBlue; // Azul hielo
                        icon = Properties.Resources.edit_button;
                    }


                    if (icon != null)
                    {
                        // Pintar fondo personalizado
                        using (SolidBrush brush = new SolidBrush(fondo))
                        {
                            e.Graphics.FillRectangle(brush, e.CellBounds);
                        }

                        // Dibujar bordes normales de la celda
                        e.Paint(e.CellBounds, DataGridViewPaintParts.Border);

                        // Tamaño del icono
                        int iconWidth = 16;
                        int iconHeight = 16;

                        // Centrar icono
                        int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                        int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                        e.Graphics.DrawImage(icon, new Rectangle(x, y, iconWidth, iconHeight));

                        e.Handled = true;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Error de Sistema",
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dataEstudiantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (this.dataEstudiantes.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                    CN_Factura ObjetoCN = new CN_Factura();
                    int IdMatricula = Convert.ToInt32(this.dataEstudiantes.CurrentRow.Cells["Id_Matricula"].Value.ToString());
                    string Codigo = this.dataEstudiantes.CurrentRow.Cells["Carnet Estudiantil"].Value.ToString();
                    string Nombres = this.dataEstudiantes.CurrentRow.Cells["Nombres"].Value.ToString();
                    string Apellidos = this.dataEstudiantes.CurrentRow.Cells["Apellidos"].Value.ToString();

                    this.txtCarnet.Text = Codigo;
                    this.txtNombres.Text = Nombres;
                    this.txtApellidos.Text = Apellidos;

                     this.dataFacturas.DataSource =  ObjetoCN.MostrarFacturasEstudiante(Codigo,IdMatricula);
                    CalcularResumenFacturas();
                    this.dataFacturas.Columns["Id_Factura"].Visible = false;
                    ActualizarBotonSeleccionar(dataFacturas);
                    this.tabControl1.SelectedTab = tabHistorial;

                }
             
               
              
                    
                

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularResumenFacturas()
        {
            int totalFacturas = 0;
            decimal totalPagado = 0;

            DateTime? primeraFactura = null;
            DateTime? ultimaFactura = null;

            foreach (DataGridViewRow fila in dataFacturas.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                totalFacturas++;

                // SUMAR TOTAL EN C$
                if (fila.Cells["Total a Pagar en C$"].Value != null &&
                    decimal.TryParse(
                        fila.Cells["Total a Pagar en C$"].Value.ToString(),
                        out decimal totalFila))
                {
                    totalPagado += totalFila;
                }

                // OBTENER FECHA
                if (fila.Cells["Fecha_factura"].Value != null &&
                    DateTime.TryParse(
                        fila.Cells["Fecha_factura"].Value.ToString(),
                        out DateTime fecha))
                {
                    if (!primeraFactura.HasValue || fecha < primeraFactura.Value)
                    {
                        primeraFactura = fecha;
                    }

                    if (!ultimaFactura.HasValue || fecha > ultimaFactura.Value)
                    {
                        ultimaFactura = fecha;
                    }
                }
            }

            lbltotalFacturas.Text = totalFacturas.ToString();

            lblTotalPagado.Text = totalPagado.ToString("N2");

            lblPrimeraFactura.Text = primeraFactura.HasValue
                ? primeraFactura.Value.ToString("dd/MM/yyyy")
                : "-";

            lblUltimaFactura.Text = ultimaFactura.HasValue
                ? ultimaFactura.Value.ToString("dd/MM/yyyy")
                : "-";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = tabHistorial;
        }

        private void dataFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (this.dataFacturas.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                   string NumFactura = this.dataFacturas.CurrentRow.Cells["Num_Factura"].Value.ToString();
                    this.txtFactura.Text = NumFactura;
                    this.txtFechaFactura.Text = this.dataFacturas.CurrentRow.Cells["Fecha_factura"].Value.ToString();
                    this.txtFormaPago.Text = this.dataFacturas.CurrentRow.Cells["Tipo_Pago"].Value.ToString();
                    this.txtTotal.Text = this.dataFacturas.CurrentRow.Cells["Total a Pagar en C$"].Value.ToString();

                    MostrarDetalleFactura(NumFactura);

                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarDetalleFactura(string NumFactura)
        {
            CN_FacturDetalle objetoFactura = new CN_FacturDetalle();
            dataDetalleFactura.DataSource = objetoFactura.MostrarDetalleFactura(
                NumFactura
            );
        }
    }
}
