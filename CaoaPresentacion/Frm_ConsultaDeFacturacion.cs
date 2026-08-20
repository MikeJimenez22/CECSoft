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
using ClosedXML.Excel;

namespace CaoaPresentacion
{
    public partial class Frm_ConsultaDeFacturacion : Form
    {
        public Frm_ConsultaDeFacturacion()
        {
            InitializeComponent();
            cmbCajas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAnio.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Cargar_ComboBoxCaja();
            DataGridViewConfigurator.Configure(dataFacturas,dataDetalleFactura);
            
        }

        private void Frm_ConsultaDeFacturacion_Load(object sender, EventArgs e)
        {
            try
            {

                CargarMeses();
                CargarAnios();

                chkRangoManual.Checked = false;

                dtpFechaDesde.Enabled = false;
                dtpFechaHasta.Enabled = false;

                ActualizarFechasPorMes();
                lbltotalFacturas.Text = "0";
                lblTotalPagado.Text = "0";
                txtEfectivo.Text = "C$ 0.00";
                txtDeposito.Text = "C$ 0.00";
                txtTarjeta.Text = "C$ 0.00";
                txtCheque.Text = "C$ 0.00";
                txtTransferencia.Text = "C$ 0.00";
                txtROC.Text = "C$ 0.00";
                txtROS.Text = "C$ 0.00";
                txtFacturasAnuladas.Text = "C$ 0.00";
                txtEntradas.Text = "C$ 0.00";
                txtSalidas.Text = "C$ 0.00";

                dtpFechaDesde.Value = DateTime.Today;
                dtpFechaHasta.Value = DateTime.Today;
               
                AgregarColumnaConIcono();
                this.ContarFilas();
            

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

        private void CargarMeses()
        {
            cmbMes.Items.Clear();

            cmbMes.Items.Add("Enero");
            cmbMes.Items.Add("Febrero");
            cmbMes.Items.Add("Marzo");
            cmbMes.Items.Add("Abril");
            cmbMes.Items.Add("Mayo");
            cmbMes.Items.Add("Junio");
            cmbMes.Items.Add("Julio");
            cmbMes.Items.Add("Agosto");
            cmbMes.Items.Add("Septiembre");
            cmbMes.Items.Add("Octubre");
            cmbMes.Items.Add("Noviembre");
            cmbMes.Items.Add("Diciembre");

            cmbMes.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void CargarAnios()
        {
            cmbAnio.Items.Clear();

            int anioActual = DateTime.Now.Year;

            for (int anio = anioActual - 5; anio <= anioActual + 1; anio++)
            {
                cmbAnio.Items.Add(anio);
            }

            cmbAnio.SelectedItem = anioActual;
        }

        private void ActualizarFechasPorMes()
        {
            if (cmbMes.SelectedIndex < 0 || cmbAnio.SelectedIndex < 0)
                return;

            int mes = cmbMes.SelectedIndex + 1;
            int anio = Convert.ToInt32(cmbAnio.SelectedItem);

            DateTime fechaInicio = new DateTime(anio, mes, 1);

            DateTime fechaFin = new DateTime(
                anio,
                mes,
                DateTime.DaysInMonth(anio, mes)
            );

            dtpFechaDesde.Value = fechaInicio;
            dtpFechaHasta.Value = fechaFin;
        }

        private void AgregarColumnaConIcono()
        {
            try
            {
                // BOTÓN ESTUDIANTES
                DataGridViewButtonColumn btnFactura = new DataGridViewButtonColumn();

                btnFactura.HeaderText = "Seleccionar";
                btnFactura.Name = "Seleccionar";
                btnFactura.Text = "";
                btnFactura.UseColumnTextForButtonValue = false;

                // Inicialmente oculto
                btnFactura.Visible = false;

                dataFacturas.Columns.Add(btnFactura);


               


                // Eventos
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

        public void Cargar_ComboBoxCaja()
        {
            try
            {
                CN_Cajas ObjetoCN = new CN_Cajas();

                // Obtener las cajas activas
                DataTable dt = ObjetoCN.MostrarCajasActivas();

                // Agregar opción inicial
                DataRow fila = dt.NewRow();

                fila["IdCaja"] = 0;
                fila["NombreCaja"] = "Selecciona una Caja";

                dt.Rows.InsertAt(fila, 0);

                // Configurar ComboBox
                cmbCajas.ValueMember = "IdCaja";
                cmbCajas.DisplayMember = "NombreCaja";
                cmbCajas.DataSource = dt;

                cmbCajas.SelectedIndex = 0;
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarFacturas();
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

        private void ResaltarFacturasAnuladas()
        {
            foreach (DataGridViewRow fila in dataFacturas.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                string estado = Convert.ToString(
                    fila.Cells["Estado"].Value
                ).Trim();

                if (estado.Equals("Anulado", StringComparison.OrdinalIgnoreCase))
                {
                    // Fondo rojo claro
                    fila.DefaultCellStyle.BackColor = Color.MistyRose;

                    // Texto rojo oscuro
                    fila.DefaultCellStyle.ForeColor = Color.DarkRed;

                    // Texto en negrita
                    fila.DefaultCellStyle.Font = new Font(
                        dataFacturas.Font,
                        FontStyle.Bold
                    );
                }
            }
        }

        private void MostrarFacturas()
        {
            if (cmbCajas.SelectedIndex == 0)
            {
                MessageBox.Show(
                    "Seleccione una Caja.",
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbCajas.Focus();
                return;
            }

            DateTime fechaDesde = dtpFechaDesde.Value.Date;
            DateTime fechaHasta = dtpFechaHasta.Value.Date;

            // Validar que la fecha inicial no sea mayor
            if (fechaDesde > fechaHasta)
            {
                MessageBox.Show(
                    "La fecha inicial no puede ser mayor que la fecha final.",
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                dtpFechaDesde.Focus();
                return;
            }

            // Validar que ambas fechas pertenezcan al mismo mes y año
            if (fechaDesde.Month != fechaHasta.Month ||
                fechaDesde.Year != fechaHasta.Year)
            {
                MessageBox.Show(
                    "Las fechas seleccionadas deben pertenecer al mismo mes.",
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                dtpFechaHasta.Focus();
                return;
            }

            int idCaja = Convert.ToInt32(cmbCajas.SelectedValue);

            CN_Factura objetoCN = new CN_Factura();

            DataSet ds = objetoCN.ObtenerFacturasPorFechaYCaja(
               fechaDesde.ToString("yyyy-MM-dd"),
               fechaHasta.ToString("yyyy-MM-dd"),
               idCaja.ToString()
           );

            dataFacturas.DataSource = ds.Tables[0];
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                txtROC.Text = "C$ " +
                    Convert.ToDecimal(ds.Tables[1].Rows[0]["TotalROC"]).ToString("N2");

                txtROS.Text = "C$ " +
                    Convert.ToDecimal(ds.Tables[1].Rows[0]["TotalROS"]).ToString("N2");
            }
            else
            {
                txtROC.Text = "C$ 0.00";
                txtROS.Text = "C$ 0.00";
            }


            if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                DataRow fila = ds.Tables[2].Rows[0];

                decimal totalAnuladas =
                    Convert.ToDecimal(fila["TotalFacturaAnulada"]);

                decimal totalEntradas =
                    Convert.ToDecimal(fila["TotalEntrada"]);

                decimal totalSalidas =
                    Convert.ToDecimal(fila["TotalSalida"]);

                txtFacturasAnuladas.Text =
                    "C$ " + totalAnuladas.ToString("N2");

                txtEntradas.Text =
                    "C$ " + totalEntradas.ToString("N2");

                txtSalidas.Text =
                    "C$ " + totalSalidas.ToString("N2");
            }
            else
            {
                txtFacturasAnuladas.Text = "C$ 0.00";
                txtEntradas.Text = "C$ 0.00";
                txtSalidas.Text = "C$ 0.00";
            }

            ActualizarBotonSeleccionar(dataFacturas);

            OcultarColumnas();

            ContarFilas();
            ResaltarFacturasAnuladas();
            CalcularResumenFacturas();
            CalcularTotalesPorTipoPago();
        }


        private void CalcularResumenFacturas()
        {
            int totalFacturas = 0;
            decimal totalPagado = 0;

            foreach (DataGridViewRow fila in dataFacturas.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                // Obtener el estado de la factura
                string estado = Convert.ToString(
                    fila.Cells["Estado"].Value
                ).Trim();

                // Solo tomar facturas completadas
                if (!estado.Equals("Completado", StringComparison.OrdinalIgnoreCase))
                    continue;

                // CONTAR FACTURA
                totalFacturas++;

                // SUMAR TOTAL EN C$
                if (fila.Cells["MontoTotal_a_Pagar"].Value != null &&
                    fila.Cells["MontoTotal_a_Pagar"].Value != DBNull.Value &&
                    decimal.TryParse(
                        fila.Cells["MontoTotal_a_Pagar"].Value.ToString(),
                        out decimal totalFila))
                {
                    totalPagado += totalFila;
                }
            }

            // MOSTRAR RESULTADOS
            lbltotalFacturas.Text = totalFacturas.ToString();

            lblTotalPagado.Text = "C$ " + totalPagado.ToString("N2");
        }


        private void OcultarColumnas()
        {
          
            dataFacturas.Columns["PagoCon"].Visible = false;
            dataFacturas.Columns["Cambio"].Visible = false;
            dataFacturas.Columns["NReferencia"].Visible = false;
            dataFacturas.Columns["SubTotal"].Visible = false;
            dataFacturas.Columns["Iva"].Visible = false;
            dataFacturas.Columns["Tipo_documento"].Visible = false;
            dataFacturas.Columns["Tipo_Movimiento"].Visible = false;
            dataFacturas.Columns["Cantidad"].Visible = false;
            dataFacturas.Columns["FechaRegistro"].Visible = false;
            dataFacturas.Columns["HorayFecha"].Visible = false;
            dataFacturas.Columns["Usuario"].Visible = false;
            dataFacturas.Columns["Carnet Empleado"].Visible = false;
        }

        private void ContarFilas()
        {
            this.lbltotal.Text = "Total de Registros: " +  this.dataFacturas.Rows.Count;
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

        private void ActualizarBotonSeleccionar(DataGridView dgv)
        {
            if (dgv.Columns.Contains("Seleccionar"))
            {
                dgv.Columns["Seleccionar"].Visible = dgv.Rows.Count > 0;
            }
        }

        private void dataFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (this.dataFacturas.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                    string NumFactura = this.dataFacturas.CurrentRow.Cells["Num_Factura"].Value.ToString();
                    string Fecha = Convert.ToDateTime(this.dataFacturas.CurrentRow.Cells["Fecha_factura"].Value.ToString()).ToShortDateString();
                    this.txtFecha_Factura.Text = Fecha;
                   this.txtHora_Factura.Text = this.dataFacturas.CurrentRow.Cells["HorayFecha"].Value.ToString();
                    this.txtNum_Factura.Text = NumFactura;
                   this.txtEstado_Factura.Text = this.dataFacturas.CurrentRow.Cells["Estado"].Value.ToString();
                   this.txtCliente_Factura.Text = this.dataFacturas.CurrentRow.Cells["Nombre_Completo"].Value.ToString();
                   this.txtTotal_Factura.Text = this.dataFacturas.CurrentRow.Cells["MontoTotal_a_Pagar"].Value.ToString();
                   this.txtTipo_Factura.Text = this.dataFacturas.CurrentRow.Cells["Tipo_Pago"].Value.ToString();
                   this.txtTipoDocumento_Factura.Text = this.dataFacturas.CurrentRow.Cells["Tipo_documento"].Value.ToString();
                   this.txtPagoCon_Factura.Text = this.dataFacturas.CurrentRow.Cells["PagoCon"].Value.ToString();
                   this.txtReferencia_Factura.Text = this.dataFacturas.CurrentRow.Cells["NReferencia"].Value.ToString();
                   this.txtTipoMovimiento_Factura.Text = this.dataFacturas.CurrentRow.Cells["Tipo_Movimiento"].Value.ToString();
                   this.txtCambio_Factura.Text = this.dataFacturas.CurrentRow.Cells["Cambio"].Value.ToString();
                   this.txtCajero_Factura.Text = this.dataFacturas.CurrentRow.Cells["Facturado Por"].Value.ToString();

                    MostrarDetalleFactura(NumFactura);
                    this.tabControl1.SelectedTab = tabDatosFactura;

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!chkRangoManual.Checked)
            {
                ActualizarFechasPorMes();
            }
        }

        private void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!chkRangoManual.Checked)
            {
                ActualizarFechasPorMes();
            }
        }

        private void chkRangoManual_CheckedChanged(object sender, EventArgs e)
        {
            bool manual = chkRangoManual.Checked;

            dtpFechaDesde.Enabled = manual;
            dtpFechaHasta.Enabled = manual;

            cmbMes.Enabled = !manual;
            cmbAnio.Enabled = !manual;

            if (!manual)
            {
                ActualizarFechasPorMes();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = tabFacturas;
        }

        private void MostrarDetalleFactura(string NumFactura)
        {
            CN_FacturDetalle objetoFactura = new CN_FacturDetalle();
            dataDetalleFactura.DataSource = objetoFactura.MostrarDetalleFactura(
                NumFactura
            );
        }

        private void CalcularTotalesPorTipoPago()
        {
            decimal totalEfectivo = 0;
            decimal totalDeposito = 0;
            decimal totalTarjeta = 0;
            decimal totalCheque = 0;
            decimal totalTransferencia = 0;

            foreach (DataGridViewRow fila in dataFacturas.Rows)
            {
                // Ignorar fila nueva del DataGridView
                if (fila.IsNewRow)
                    continue;

                // Obtener estado
                string estado = Convert.ToString(
                    fila.Cells["Estado"].Value
                ).Trim();

                // Solo sumar facturas completadas
                if (!estado.Equals(
                    "Completado",
                    StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                // Obtener tipo de pago
                string tipoPago = Convert.ToString(
                    fila.Cells["Tipo_Pago"].Value
                ).Trim().ToUpper();

                // Obtener monto de la factura
                decimal monto = 0;

                if (fila.Cells["MontoTotal_a_Pagar"].Value != null &&
                    fila.Cells["MontoTotal_a_Pagar"].Value != DBNull.Value)
                {
                    decimal.TryParse(
                        fila.Cells["MontoTotal_a_Pagar"].Value.ToString(),
                        out monto
                    );
                }

                // Sumar según el tipo de pago
                switch (tipoPago)
                {
                    case "EFECTIVO":
                        totalEfectivo += monto;
                        break;

                    case "DEPOSITO":
                    case "DEPÓSITO":
                        totalDeposito += monto;
                        break;

                    case "TARJETA":
                        totalTarjeta += monto;
                        break;

                    case "CHEQUE":
                        totalCheque += monto;
                        break;

                    case "TRANSFERENCIA":
                        totalTransferencia += monto;
                        break;
                }
            }

            // Mostrar resultados
            txtEfectivo.Text = "C$ " + totalEfectivo.ToString("N2");
            txtDeposito.Text = "C$ " + totalDeposito.ToString("N2");
            txtTarjeta.Text = "C$ " + totalTarjeta.ToString("N2");
            txtCheque.Text = "C$ " + totalCheque.ToString("N2");
            txtTransferencia.Text = "C$ " + totalTransferencia.ToString("N2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ExportarExcel(dataFacturas);
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void ExportarExcel(DataGridView data)
        {
            if (data.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No hay información para exportar.",
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            SaveFileDialog guardar = new SaveFileDialog();

            guardar.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
            guardar.FileName = "Reporte_Facturas.xlsx";

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                DataTable tabla = new DataTable();

                // Columnas visibles
                foreach (DataGridViewColumn columna in data.Columns)
                {
                    if (columna.Visible)
                    {
                        tabla.Columns.Add(columna.HeaderText);
                    }
                }

                // Filas
                foreach (DataGridViewRow fila in data.Rows)
                {
                    if (fila.IsNewRow)
                        continue;

                    DataRow nuevaFila = tabla.NewRow();

                    int indice = 0;

                    foreach (DataGridViewColumn columna in data.Columns)
                    {
                        if (columna.Visible)
                        {
                            nuevaFila[indice] =
                                fila.Cells[columna.Index].Value ?? "";

                            indice++;
                        }
                    }

                    tabla.Rows.Add(nuevaFila);
                }

                using (XLWorkbook libro = new XLWorkbook())
                {
                    libro.Worksheets.Add(tabla, "Facturas");

                    libro.SaveAs(guardar.FileName);
                }

                MessageBox.Show(
                    "El reporte se exportó correctamente.",
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
}
