using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Utils;
using System.IO;
using System.Linq;




namespace CaoaPresentacion
{
    public partial class Frm_Facturacion : Form
    {
       

        //*************** Variables **************************

        string CodigoFactura;
        string Nombres, Apellidos, Cedula, Carnet, Cod_Matricula, NombreCurso, Turno, Horario;
        string FechaProgramada_, Concepto_, Monto_, Descripcion_, Estado_, FechaVencimiento_, Mora_, NumProgramacion_, Id_Detalle_Programacion_, IdMoneda_, TasaCambio_;
        string VariableFactura;
        bool MensualidadEncontrada;
        string TipoOrigenMatricula;
        string IdActivacionMatricula;
        string CodigoComparacion;

        CD_Conexion conexion = new CD_Conexion();

        string name = System.Windows.Forms.SystemInformation.ComputerName;
        string ValorMoneda;
        public string CodigoFactu { get; set; }

        //Cargamos el PrintDocument y el PrintDialog
        private PrintDocument printDocument1 = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

        //Cargamos el PrintDocument y el PrintDialog para los pagos por Deposito
        private PrintDocument printDocument2 = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog2 = new PrintPreviewDialog();



        //Credenciales cuenta de Google para enviar Notificaciones del sistema
        const string Usuario = "CecnicManagua2023@gmail.com";
        const string Password = "ajkxkeukzfjsptmk";


        string PrimerIdDetalleProgramacion;
        string ActualIdDetalleProgramacion;
        bool MoraAplicada = false;
        DateTime FechaVencimientoSolvencia;
        int DiaVencimientoMensualidad;
        DateTime fechaVencimientoMensualidad;
        string CodigoSolicitud;
        string TipoAccion;
        int rowIndex;
        private DateTime fechaMasRecienteGlobal;
        int copias = 0; // cantidad de copias deseadas
        int CopiasReinicio = 0;
        string LetraCaja;

        //*****************************************************

        public Frm_Facturacion()
        {
            InitializeComponent();

            // Asignar DropDownStyle a ComboBoxes en un método para evitar redundancia
            ConfigurarComboBoxes();

            // Eventos para los documentos de impresión
            printDocument1.PrintPage += new PrintPageEventHandler(PrintDocument1_PrintPage);
            printDocument2.PrintPage += new PrintPageEventHandler(PrintDocument2_PrintPage);
            
            DataGridViewConfigurator.Configure(this.TablaDetalleFactura,this.dataEstudiantes,this.dataMensualidadesEstudiante,this.dataMensualidadesEstudiante,this.dataDetalles);
            // Cargar los ComboBoxes necesarios
            CargarCombos();
            Cargar_ComboMonedaMensualidad();
        }

        private void ConfigurarComboBoxes()
        {
            // Lista de ComboBoxes a configurar
            var comboBoxes = new ComboBox[]
            {
        cmbAranceles, cmbtipobusqueda, cmbBusquedas, cmbTipoMonedaLibreria,
        cmbTipoPago, cmbTipoMonedaPago, cmbMonedaAbono, cmbmes,cmbaño, cmbTipoMonedaMensualidad,cmbDescuentos
            };

            // Asignar DropDownList a todos los ComboBoxes
            foreach (var comboBox in comboBoxes)
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private void CargarCombos()
        {
            Cargar_ComboDepartamento();
            Cargar_ComboMonedaLibreria();
            Cargar_ComboMonedaPago();
            Cargar_ComboMonedaAbono();
        }

        private void ObtenerNumerosCopias()
        {
            CD_ConfiguracionImpresiones objetoCD = new CD_ConfiguracionImpresiones();
            DataTable tabla = objetoCD.ObtenerNumerosCopia("Factura");

            if (tabla.Rows.Count > 0)
            {
                copias = int.Parse(tabla.Rows[0][0].ToString());
                CopiasReinicio = copias;
            }
            else
            {
                copias = 1; // valor por defecto
                CopiasReinicio = copias;
            }
        }
        
        private void PrintDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                // ============================
                // Definición de fuentes
                // ============================
                Font fontTitulo = new Font("Courier New", 12, FontStyle.Bold);
                Font fontSubTitulo = new Font("Courier New", 9, FontStyle.Bold);
                Font fontDetalle = new Font("Courier New", 9, FontStyle.Bold);
                Font fontTotal = new Font("Courier New", 9, FontStyle.Bold);

                int y = 20; // posición vertical inicial
                int salto = 15; // espacio entre líneas
             
           

                // ============================
                // ENCABEZADO
                // ============================
                e.Graphics.DrawString("CECNIC", fontTitulo, Brushes.Black, new PointF(80, y)); y += salto;
                e.Graphics.DrawString("Capacitación sin Límites", fontSubTitulo, Brushes.Black, new PointF(40, y)); y += salto;
                e.Graphics.DrawString("RUC: J0310000121974", fontSubTitulo, Brushes.Black, new PointF(40, y)); y += salto;
                e.Graphics.DrawString("FACTURA: " + this.CodigoFactu, fontSubTitulo, Brushes.Black, new PointF(30, y)); y += salto;

             
                e.Graphics.DrawLine(Pens.Black, 10, y, 280, y); y += salto;
                e.Graphics.DrawString("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"), fontSubTitulo, Brushes.Black, new PointF(20, y)); y += salto;
                e.Graphics.DrawString("Cajero:", fontSubTitulo, Brushes.Black, new PointF(20, y)); y += salto;
                e.Graphics.DrawString(txtCajeroPago.Text, fontSubTitulo, Brushes.Black, new PointF(20, y)); y += salto;
                e.Graphics.DrawLine(Pens.Black, 10, y, 280, y); y += salto;

                // ============================
                // DATOS DEL CLIENTE
                // ============================
                e.Graphics.DrawString(txtNombredeFacturaPago.Text, fontSubTitulo, Brushes.Black, new PointF(10, y)); y += salto;
                e.Graphics.DrawString("Carnet: " + txtCarnetPago.Text, fontSubTitulo, Brushes.Black, new PointF(10, y)); y += salto;
                e.Graphics.DrawString(txtCursoPago.Text, fontSubTitulo, Brushes.Black, new PointF(10, y)); y += salto;

                y += 10; // espacio antes del detalle

                // ============================
                // COLUMNAS DETALLE
                // ============================
                e.Graphics.DrawString("DESCRIPCION", fontDetalle, Brushes.Black, new PointF(10, y));
                e.Graphics.DrawString("IMPORTE", fontDetalle, Brushes.Black,
                    new RectangleF(170, y, 100, salto),
                    new StringFormat { Alignment = StringAlignment.Far });
                y += salto;
                e.Graphics.DrawLine(Pens.Black, 10, y, 280, y); y += salto;

                // ============================
                // DETALLE DE FACTURA
                // ============================
                int anchoDescripcion = 160;
                int xDescripcion = 10;
                int altoLinea = 15;

                foreach (DataGridViewRow row in dataDetalles.Rows)
                {
                    if (row.IsNewRow) continue;

                    string descripcion = row.Cells["Observaciones"].Value?.ToString() ?? "";
                    string importe = "C$ " + (row.Cells["Total_en_Cordobas"].Value?.ToString() ?? "0");

                    // Dividir descripción en varias líneas si excede el ancho
                    string[] lineas = DividirTexto(e.Graphics, descripcion, fontDetalle, anchoDescripcion);

                    // Imprimir cada línea de la descripción
                    foreach (string linea in lineas)
                    {
                        e.Graphics.DrawString(linea, fontDetalle, Brushes.Black,
                            new RectangleF(xDescripcion, y, anchoDescripcion, altoLinea));
                        y += altoLinea;
                    }

                    // Dejar un pequeño espacio y dibujar el importe DEBAJO de la descripción
                    y += 2;
                    e.Graphics.DrawString(importe, fontDetalle, Brushes.Black,
                        new RectangleF(xDescripcion, y, anchoDescripcion, altoLinea),
                        new StringFormat { Alignment = StringAlignment.Near });

                    // Espacio entre ítems
                    y += altoLinea + 5;
                }


                y += 10;
                e.Graphics.DrawLine(Pens.Black, 10, y, 280, y); y += salto;

                // ============================
                // TOTALES
                // ============================
                e.Graphics.DrawString("No. ITEMS: " + this.dataDetalles.Rows.Count.ToString(), fontDetalle, Brushes.Black, new PointF(10, y)); y += salto;

                e.Graphics.DrawString("TOTAL: C$" + this.txttotalPago.Text, fontTotal, Brushes.Black, new PointF(10, y));
                y += salto;

                e.Graphics.DrawString("PAGO CON: " + this.txtSeleccionTipoPago.Text.ToUpper(), fontDetalle, Brushes.Black, new PointF(10, y)); y += salto;
                e.Graphics.DrawString("REFERENCIA: " + this.txtReferenciaPago.Text, fontDetalle, Brushes.Black, new PointF(10, y)); y += salto;
                e.Graphics.DrawString("CAMBIO: " + this.txtCambioPago.Text, fontDetalle, Brushes.Black, new PointF(10, y)); y += salto;

                y += 20;
                e.Graphics.DrawString("X  _______________________", fontDetalle, Brushes.Black, new PointF(40, y)); y += salto;
                e.Graphics.DrawString("FIRMA DEL ESTUDIANTE", fontDetalle, Brushes.Black, new PointF(50, y)); y += salto;

                y += 10;
                e.Graphics.DrawLine(Pens.Black, 10, y, 280, y); y += salto;
                e.Graphics.DrawString("Gracias por tu pago", fontDetalle, Brushes.Black, new PointF(50, y)); y += salto;
                e.Graphics.DrawString("¡NO SE REALIZA DEVOLUCIÓN!", fontDetalle, Brushes.Black, new PointF(20, y)); y += salto;
                e.Graphics.DrawLine(Pens.Black, 10, y, 280, y);

                // ============================
                // CONTROL DE COPIAS
                // ============================
                copias--;

                if (copias > 0)
                {
                    e.HasMorePages = true; // vuelve a imprimir
                }
                else
                {
                    copias = CopiasReinicio; // reinicia para la próxima impresión
                    e.HasMorePages = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de impresión: " + ex.Message,
                    "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                // ===== TU CÓDIGO DE IMPRESIÓN COMPLETO =====
                Font fontTitulo = new Font("Courier New", 12, FontStyle.Bold);
                Font fontSubTitulo = new Font("Courier New", 9, FontStyle.Bold);
                Font fontDetalle = new Font("Courier New", 9, FontStyle.Bold);
                Font fontTotal = new Font("Courier New", 9, FontStyle.Bold);

                int y = 20;
                int salto = 15;

         

                // ENCABEZADO
                e.Graphics.DrawString("CECNIC", fontTitulo, Brushes.Black, new PointF(80, y)); y += salto;
                e.Graphics.DrawString("Capacitación sin Límites", fontSubTitulo, Brushes.Black, new PointF(40, y)); y += salto;
                e.Graphics.DrawString("RUC: J0310000121974", fontSubTitulo, Brushes.Black, new PointF(40, y)); y += salto;
                e.Graphics.DrawString("FACTURA: " + this.CodigoFactu, fontSubTitulo, Brushes.Black, new PointF(30, y)); y += salto;
                e.Graphics.DrawLine(Pens.Black, 10, y, 280, y); y += salto;

             

                e.Graphics.DrawString("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"), fontSubTitulo, Brushes.Black, new PointF(20, y)); y += salto;
                e.Graphics.DrawString("Cajero:", fontSubTitulo, Brushes.Black, new PointF(20, y)); y += salto;
                e.Graphics.DrawString(txtCajeroPago.Text, fontSubTitulo, Brushes.Black, new PointF(20, y)); y += salto;
                e.Graphics.DrawLine(Pens.Black, 10, y, 280, y); y += salto;

                // CLIENTE
                e.Graphics.DrawString(txtNombredeFacturaPago.Text, fontSubTitulo, Brushes.Black, new PointF(10, y)); y += salto;
                e.Graphics.DrawString("Carnet: " + txtCarnetPago.Text, fontSubTitulo, Brushes.Black, new PointF(10, y)); y += salto;
                e.Graphics.DrawString(txtCursoPago.Text, fontSubTitulo, Brushes.Black, new PointF(10, y)); y += salto;

                y += 10;
                e.Graphics.DrawString("DESCRIPCION", fontDetalle, Brushes.Black, new PointF(10, y));
                e.Graphics.DrawString("IMPORTE", fontDetalle, Brushes.Black, new RectangleF(170, y, 100, salto), new StringFormat { Alignment = StringAlignment.Far });
                y += salto;
                e.Graphics.DrawLine(Pens.Black, 10, y, 280, y); y += salto;

                int anchoDescripcion = 160;
                int xDescripcion = 10;
                int altoLinea = 15;

                foreach (DataGridViewRow row in dataDetalles.Rows)
                {
                    if (row.IsNewRow) continue;

                    string descripcion = row.Cells["Observaciones"].Value?.ToString() ?? "";
                    string importe = "C$ " + (row.Cells["Total_en_Cordobas"].Value?.ToString() ?? "0");

                    // Dividir descripción en varias líneas si excede el ancho
                    string[] lineas = DividirTexto(e.Graphics, descripcion, fontDetalle, anchoDescripcion);

                    // Imprimir cada línea de la descripción
                    foreach (string linea in lineas)
                    {
                        e.Graphics.DrawString(linea, fontDetalle, Brushes.Black,
                            new RectangleF(xDescripcion, y, anchoDescripcion, altoLinea));
                        y += altoLinea;
                    }

                    // Dejar un pequeño espacio y dibujar el importe DEBAJO de la descripción
                    y += 2;
                    e.Graphics.DrawString(importe, fontDetalle, Brushes.Black,
                        new RectangleF(xDescripcion, y, anchoDescripcion, altoLinea),
                        new StringFormat { Alignment = StringAlignment.Near });

                    // Espacio entre ítems
                    y += altoLinea + 5;
                }

                y += 10;
                e.Graphics.DrawLine(Pens.Black, 10, y, 280, y); y += salto;
                e.Graphics.DrawString("No. ITEMS: " + this.dataDetalles.Rows.Count.ToString(), fontDetalle, Brushes.Black, new PointF(10, y)); y += salto;
                e.Graphics.DrawString("TOTAL: C$" + this.txttotalPago.Text, fontTotal, Brushes.Black, new PointF(10, y));
               y += salto;

                e.Graphics.DrawString("PAGO CON: EFECTIVO", fontDetalle, Brushes.Black, new PointF(10, y)); y += salto;
                e.Graphics.DrawString("CAMBIO: " + this.txtCambioPago.Text, fontDetalle,Brushes.Black,new PointF(10, y)); y += salto;
                e.Graphics.DrawString(this.txtReferenciaPago.Text, fontDetalle, Brushes.Black, new PointF(10, y)); y += salto;

                y += 20;
                e.Graphics.DrawString("X  _______________________", fontDetalle, Brushes.Black, new PointF(40, y)); y += salto;
                e.Graphics.DrawString("FIRMA DEL ESTUDIANTE", fontDetalle, Brushes.Black, new PointF(50, y)); y += salto;

                y += 10;
                e.Graphics.DrawLine(Pens.Black, 10, y, 280, y); y += salto;
                e.Graphics.DrawString("Gracias por tu pago", fontDetalle, Brushes.Black, new PointF(50, y)); y += salto;
                e.Graphics.DrawString("¡NO SE REALIZA DEVOLUCIÓN!", fontDetalle, Brushes.Black, new PointF(20, y)); y += salto;
                e.Graphics.DrawLine(Pens.Black, 10, y, 280, y);

                // ============================
                // CONTROL DE COPIAS
                // ============================
                copias--;

                if (copias > 0)
                {
                    e.HasMorePages = true; // vuelve a imprimir
                }
                else
                {
                    copias = CopiasReinicio; // reinicia para la próxima impresión
                    e.HasMorePages = false;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error de impresión", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        // ==========================
        // MÉTODO AUXILIAR
        // ==========================
        private string[] DividirTexto(Graphics g, string texto, Font fuente, int anchoMax)
        {
            List<string> lineas = new List<string>();
            string[] palabras = texto.Split(' ');
            string linea = "";

            foreach (string palabra in palabras)
            {
                string prueba = (linea.Length == 0) ? palabra : linea + " " + palabra;
                SizeF medida = g.MeasureString(prueba, fuente);

                if (medida.Width > anchoMax)
                {
                    if (!string.IsNullOrEmpty(linea))
                        lineas.Add(linea);
                    linea = palabra;
                }
                else
                {
                    linea = prueba;
                }
            }

            if (!string.IsNullOrEmpty(linea))
                lineas.Add(linea);

            return lineas.ToArray();
        }

        

      


        private void CargarFacturacion()
        {
            try
            {
                // Métodos de inicialización
                CargarControlesFacturacion();
                CargarComboboxNuevaMensualidad();
                EvitarReordenacionDataGridView();
                obtenerMesAñoActual();
                AgregarBtnDatagridView();
                AgregarBtnDatagridViewEstudiantes();
                VerificarTextBox();
                this.panel2.Enabled = false;
                this.panel2.Visible = false;

                if (CacheDatos.TipoFactura == "NuevaMatricula")
                {
                    if (CacheDatos.OrigenMatricula == "RECEPCION" || CacheDatos.OrigenMatricula == "RELACIONESPUBLICAS")
                    {
                        int MontoEnCordobas = Convert.ToInt32(CacheDatos.Precio) * Convert.ToInt32(CacheDatos.ValorMoneda);
                        AgregarFilaDetalleFactura(CacheDatos.IdArancel, CacheDatos.IdMoneda, CacheDatos.ValorMoneda, MontoEnCordobas.ToString(), "1", "5", CacheDatos.Precio, CacheDatos.NombreArancel, "-");
                        calcularSubtotal();
                        this.CalcularTotal(Convert.ToDouble(this.txtSubtotal.Text), 0, 0);
                    }

                    this.DatosEstudiante(CacheDatos.NombreMatricula, CacheDatos.ApellidosMatricula, CacheDatos.CedulaMatricula, CacheDatos.CarnetEstudianteMatricula, CacheDatos.CodMatricula);
                }



            }
            catch (Exception)
            {
                MessageBox.Show($"Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    


        private void EvitarReordenacionDataGridView()
        {
            foreach (DataGridViewColumn columna in dataMensualidadesEstudiante.Columns)
            {
                // Deshabilita el ordenamiento en cada columna
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void CargarControlesFacturacion()
        {
            try
            {
                // Inicialización de radio buttons y paneles
                radioButton6.Checked = true;
            
                // Limpiar campos de texto
                LimpiarTextBoxes(new TextBox[] {  txtSubtotalPago, txtDescuentoPago, txtIvaPago, txtPagoCon, txttotalPago, txtCambioPago });

                // Configurar datos del cajero
                txtCajeroPago.Text = $"{CacheUsuario.Nombres} {CacheUsuario.Apellidos}";
                txtCaja.Text = CacheUsuario.Caja;

                // Configuración predeterminada de ComboBoxes
                const string DefaultPago = "EFECTIVO";
                const string DefaultBusqueda = "Apellidos";
                const string DefaultTipoBusqueda = "CARNET";
                const string DefaultArancel = "MENSUALIDAD";

                cmbTipoPago.Text = DefaultPago;
                cmbBusquedas.Text = DefaultBusqueda;
                cmbtipobusqueda.Text = DefaultTipoBusqueda;
                cmbAranceles.Text = DefaultArancel;

                // Deshabilitar botón agregar abono
                btnAgregarAbono.Enabled = false;

                // Cargar datos de la matrícula
                TipoOrigenMatricula = CacheDatos.TipoMatriculaOrigen;
                IdActivacionMatricula = CacheDatos.IdEstadoMatriculaActivacion;

                // Opcional: Si el CheckBox se habilita y luego se deshabilita, no es necesario
                Habilitar.Checked = false;

                this.txtSubtotal.Text = "0";
                this.CalcularTotal(Convert.ToDouble(this.txtSubtotal.Text), 0, 0);

            }
            catch (Exception)
            {
                MessageBox.Show($"Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarTextBoxes(TextBox[] textBoxes)
        {
            foreach (var textBox in textBoxes)
            {
                textBox.Text = "0"; // Asignar valor por defecto
            }
        }



        private void VerificarTextBox()
        {
            // Primero deshabilitamos todos por defecto
            btnMensualidades.Enabled = false;
            btnRegistroVenta.Enabled = false;
            btnAgregarArancel.Enabled = false;

            switch (txtnombreArancel.Text.Trim().ToUpper())
            {
                case "MENSUALIDAD":
                case "ABONO DE MENSUALIDAD":
                    btnMensualidades.Enabled = true;
                    break;

                case "VENTA LIBRERIA":
                    btnRegistroVenta.Enabled = true;
                    break;

                default:
                    btnAgregarArancel.Enabled = true;
                    break;
            }
        }
        
        private void Frm_Facturacion_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormClosed += new FormClosedEventHandler(CerrarForm);
                this.AgregarColumnaConIcono();
                this.AgregarColumnasFacturaDetalles();
                this.ObtenerNumerosCopias();
               
                this.CargarFacturacion();

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Cargar_ComboMonedaMensualidad()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("Select IdMoneda,Descripcion from Tbl_TipoMoneda", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Descripcion"] = "Selecciona una Moneda";
                dt.Rows.InsertAt(fila, 0);

                cmbTipoMonedaMensualidad.ValueMember = "IdMoneda";
                cmbTipoMonedaMensualidad.DisplayMember = "Descripcion";
                cmbTipoMonedaMensualidad.DataSource = dt;


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CargarComboboxNuevaMensualidad()
        {
            try
            {
                // Limpiar para evitar duplicados
                cmbmes.Items.Clear();
                cmbaño.Items.Clear();

                // Cargar meses en letras automáticamente (en mayúsculas)
                foreach (string mes in System.Globalization.DateTimeFormatInfo.CurrentInfo.MonthNames)
                {
                    if (!string.IsNullOrEmpty(mes))
                        cmbmes.Items.Add(mes.ToUpper());
                }

                // Cargar años del 2024 al 2035
                for (int año = 2024; año <= 2035; año++)
                {
                    cmbaño.Items.Add(año.ToString());
                }

                // Seleccionar el mes actual como predeterminado
                cmbmes.SelectedIndex = DateTime.Now.Month - 1;

                // Seleccionar el año actual como predeterminado si está en el rango
                int añoActual = DateTime.Now.Year;
                if (añoActual >= 2024 && añoActual <= 2035)
                {
                    cmbaño.SelectedItem = añoActual.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema: ",
                                "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void obtenerMesAñoActual()
        {
            // Obtener el mes actual en letras
            string mesActual = DateTime.Now.ToString("MMMM", new System.Globalization.CultureInfo("es-ES")).ToUpper();

            // Obtener el año actual
            int añoActual = DateTime.Now.Year;

            cmbmes.Text = mesActual.ToString();
            cmbaño.Text = añoActual.ToString();


        }
        

        private void CerrarForm(object sender, EventArgs e)
        {
            try
            {
                // Limpiar los datos de la programación en caché
                CacheDetalleProgramacion.NombreCurso = string.Empty;
                CacheDetalleProgramacion.Dias = string.Empty;
                CacheDetalleProgramacion.Horario = string.Empty;

                this.AnularAbonosEnProceso();
                // Actualizar la factura general a estado pendiente
                CN_FacturaGeneral objetoCNFac = new CN_FacturaGeneral();
                objetoCNFac.ActualizarFacturaGeneralPendiente("1");

                // Cerrar el formulario
                this.Hide();
            }
            catch (Exception)
            {
                // Mostrar el mensaje de error en caso de excepción
                MessageBox.Show($"Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarBtnDatagridView()
        {
            // Agregar botón a DataGridView 'dataNotas'
            AgregarBotonADataGridView(dataMensualidadesEstudiante, "Seleccionar", "Seleccionar", "Seleccionar");
        }

        // Método auxiliar para agregar columnas de botón a un DataGridView
        private void AgregarBotonADataGridView(DataGridView dataGrid, string headerText, string buttonText, string columnName)
        {
            dataGrid.Columns.Add(
                new DataGridViewButtonColumn()
                {
                    HeaderText = headerText,
                    Name = columnName,
                    Text = buttonText,
                    UseColumnTextForButtonValue = true
                });
        }
        
        public void Cargar_ComboDepartamento()
        {
            try
            {

                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("Select Id_Arancel,Nombre_Arancel from Tbl_Aranceles where Id_Estado = '3' and Id_Arancel != '12' order by Nombre_Arancel asc", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Nombre_Arancel"] = "selecciona un Arancel";
                dt.Rows.InsertAt(fila, 0);

                cmbAranceles.ValueMember = "Id_Arancel";
                cmbAranceles.DisplayMember = "Nombre_Arancel";
                cmbAranceles.DataSource = dt;


            }
            catch (Exception)
            {
                MessageBox.Show("");
            }

        }
        
        private void txtIdMoneda_TextChanged(object sender, EventArgs e)
        {

            CD_Conexion conexion = new CD_Conexion();
            conexion.AbrirConexion();
            SqlCommand cm = new SqlCommand("select ValorMoneda from Tbl_TipoMoneda where IdMoneda = '2'", conexion.Conexion());
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read() == true)
            {
                this.txtValorMoneda.Text = dr["ValorMoneda"].ToString();

            }
            conexion.CerrarConexion();
        }

        private void cmbAranceles_SelectedIndexChanged(object sender, EventArgs e)
        {

            conexion.AbrirConexion();
            SqlCommand cm = new SqlCommand("select a.Id_Arancel,a.Nombre_Arancel,a.Precio,b.Descripcion,b.ValorMoneda, c.Estado, c.Id_estado, b.IdMoneda from Tbl_Aranceles a join Tbl_TipoMoneda b on a.IdMoneda = b.IdMoneda join Tbl_Estados c on c.Id_estado = a.Id_estado where a.Id_Arancel = '" + cmbAranceles.SelectedValue + "'", conexion.Conexion());
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read() == true)
            {
               
                double Precio = Convert.ToDouble(dr["Precio"].ToString());
                double TasaCambio = Convert.ToDouble(dr["ValorMoneda"].ToString());
                this.TxtEncordobas.Text = Convert.ToString(Precio*TasaCambio);
                this.txtnombreArancel.Text = dr["Nombre_Arancel"].ToString();
                this.txtIdArancel.Text = dr["Id_Arancel"].ToString();
                this.txtMoneda.Text = dr["Descripcion"].ToString();
                this.txtIdeMoneda.Text = dr["IdMoneda"].ToString();
                this.txtPrecio.Text = Precio.ToString();
                this.txtTasaCambio.Text = TasaCambio.ToString();
                this.VerificarTextBox();

                
            }
            conexion.CerrarConexion();
        }

        private void btnMensualidades_Click(object sender, EventArgs e)
        {
        
            if (this.cmbAranceles.Text == "MENSUALIDAD")
            {
                if (this.txtcodigocarnet.Text == string.Empty)
                {
                    MessageBox.Show("Ningun estudiante seleccionado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // this.txtbuscar.Text = this.txtcodigocarnet.Text;
                    this.txtMensualidadFactura.Text = this.txtCodigoFactura.Text;
                    this.Mostrar();
                    this.tabControl1.SelectedTab = TabMensualidades;
                }

            }

        }



        private void AnularAbonosEnProceso()
        {
            try
            {
                CN_Abonos objetoCN = new CN_Abonos();
                int anulados = 0;

                foreach (DataGridViewRow row in dataAbonos.Rows)
                {
                    if (row.IsNewRow) continue; // Evita la fila en blanco del DataGridView

                    string estado = row.Cells["Estado"]?.Value?.ToString();

                    if (estado == "En proceso")
                    {
                        string idAbono = row.Cells["Id_Abono"]?.Value?.ToString();

                        if (!string.IsNullOrEmpty(idAbono))
                        {
                            objetoCN.AnularAbono(idAbono);
                            anulados++;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema",
                                "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
           try
            {
                 AgregarFilaDetalleFactura(this.txtIdArancel.Text,this.txtIdeMoneda.Text,this.txtTasaCambio.Text,this.TxtEncordobas.Text,"1","5",this.txtPrecio.Text,this.txtnombreArancel.Text,"-");
                 calcularSubtotal();
                 this.CalcularTotal(Convert.ToDouble(this.txtSubtotal.Text), 0, 0);
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarFilaDetalleFactura(string idArancel,string idMoneda,string valorMoneda,string totalCordobas,string cantidad,string idEstado,string monto,string observaciones,string IdDetalleProgramacion)
        {
            int rowIndex = this.TablaDetalleFactura.Rows.Add();
            DataGridViewRow row = this.TablaDetalleFactura.Rows[rowIndex];

            row.Cells["Id_Arancel"].Value = idArancel;
            row.Cells["IdMoneda"].Value = idMoneda;
            row.Cells["Valor_Moneda"].Value = valorMoneda;
            row.Cells["Total_en_Cordobas"].Value = totalCordobas;
            row.Cells["Cantidad"].Value = cantidad;
            row.Cells["Id_estado"].Value = idEstado;
            row.Cells["Monto"].Value = monto;
            row.Cells["Observaciones"].Value = observaciones;
            row.Cells["Id_Detalle_Programacion"].Value = IdDetalleProgramacion;
        }
        
        private void calcularSubtotal()
        {
            double subtotal = 0;
            foreach (DataGridViewRow row in TablaDetalleFactura.Rows)
            {
                subtotal += Convert.ToDouble(row.Cells["Total_en_Cordobas"].Value);
            }

            this.txtSubtotal.Text = Convert.ToString(subtotal);
        }

       
        private void CalcularTotal(double Subtotal, double Iva, double Descuento)
        {
            double Total = Subtotal + Iva - Descuento;
            this.txtDescuento.Text = Descuento.ToString();
            this.txtTotal.Text = Total.ToString();

        }

    
        private void Habilitar_CheckedChanged(object sender, EventArgs e)
        {
            bool habilitado = Habilitar.Checked;

            txtNombreFactura.Enabled = habilitado;
            txtCedulaRuc.Enabled = habilitado;

            if (habilitado)
            {
                txtNombreFactura.Text = string.Empty;
                txtCedulaRuc.Text = string.Empty;
                txtNombreFactura.Focus();
            }
            else
            {
                txtNombreFactura.Text = txtestudiante.Text;
            }

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtestudiante.Text) && string.IsNullOrWhiteSpace(txtNombreFactura.Text))
                {
                    MessageBox.Show("Debes de Seleccionar el Estudiante",
                                    "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ContinuarPago();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ContinuarPago()
        {
            try
            {
                if (!double.TryParse(txtTotal.Text, out double montoApagar))
                {
                    MessageBox.Show("Monto inválido", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (montoApagar == 0)
                {
                    MessageBox.Show("Sin nada por facturar", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Asignación de valores a campos de pago
                txtFacturaTemporal.Text = txtCodigoFactura.Text;
                txtSubtotalPago.Text = txtTotal.Text;
                txttotalPago.Text = txtTotal.Text;
                txtIvaPago.Text = txtIva.Text;
                txtDescuentoPago.Text = txtDescuento.Text;
                txtNombredeFacturaPago.Text = txtNombreFactura.Text;
                txtCarnetPago.Text = txtcodigocarnet.Text;
                txtCedulaPago.Text = txtcodigocarnet.Text;

                txtCursoPago.Text = NombreCurso;
                txtDiasPago.Text = Turno;
                txtHorarioPago.Text = Horario;

                this.ObtenerDatos();
               
                // Cambiar de tab y deshabilitar grupo
                tabControl1.SelectedTab = TabPago;
            }
            catch (Exception)
            {
                MessageBox.Show($"Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerDatos()
        {
            try
            {
                // Limpiar columnas y filas del segundo DataGridView
                dataDetalles.Columns.Clear();
                dataDetalles.Rows.Clear();

                // Copiar columnas (excluyendo botones)
                foreach (DataGridViewColumn col in TablaDetalleFactura.Columns)
                {
                    if (!(col is DataGridViewButtonColumn)) // excluye botones
                    {
                        DataGridViewColumn nuevaCol = (DataGridViewColumn)col.Clone();
                        nuevaCol.Visible = col.Visible; // conserva la visibilidad original
                        dataDetalles.Columns.Add(nuevaCol);
                    }
                }

                // Copiar filas
                foreach (DataGridViewRow row in TablaDetalleFactura.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        int index = dataDetalles.Rows.Add();
                        for (int i = 0, j = 0; i < TablaDetalleFactura.Columns.Count; i++)
                        {
                            if (!(TablaDetalleFactura.Columns[i] is DataGridViewButtonColumn))
                            {
                                dataDetalles.Rows[index].Cells[j].Value = row.Cells[i].Value;
                                j++; // solo incrementa si es columna copiada
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void txtcarnetEstudiante_TextChanged(object sender, EventArgs e)
        {

            CD_Conexion conexion = new CD_Conexion();
            conexion.AbrirConexion();
            SqlCommand cm = new SqlCommand("select c.Cod_Matricula,d.Cod_carnet,e.Nombres,e.Apellidos,e.Cedula from Tbl_Factura_Gnral a join Tbl_Facturas_Matriculas b on a.Num_Factura = b.Num_Factura join Tbl_Matricula c on b.Cod_Matricula = c.Cod_Matricula join Tbl_Estudiantes d on d.Id_estudiante = c.Id_estudiante join Tbl_Personas e on e.Id_persona = d.Id_persona where d.Cod_carnet = '" + txtcarnetEstudiante.Text + "'", conexion.Conexion());
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read() == true)
            {
                this.txtestudiante.Text = dr["Nombres"].ToString() + " " + dr["Apellidos"].ToString();
                this.txtcodigocarnet.Text = dr["Cod_carnet"].ToString();

                CacheDatos.CodigodeCarnet = this.txtcodigocarnet.Text;
                CacheDatos.ValorVentanaProgramacion = "nuevamatricula";
                
                this.txtNombreFactura.Text = dr["Nombres"].ToString() + " " + dr["Apellidos"].ToString();
                this.txtCedulaRuc.Text = dr["Cedula"].ToString();
                

            }
            conexion.CerrarConexion();
        }

       

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {

                this.Close();
                this.AnularAbonosEnProceso();
                CN_FacturaGeneral objetoCNFac = new CN_FacturaGeneral();
                objetoCNFac.ActualizarFacturaGeneralPendiente("1");
                
                this.BorrarDatosCurso();
                Frm_Facturacion frm = new Frm_Facturacion();
                frm.Show();
                
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
      
        private void button8_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBusquedaEstudiante.Text))
                {
                    tabControl1.SelectedTab = TabBusquedaEstudiante;
                }
                else
                {
                    switch (cmbtipobusqueda.Text.ToUpper())
                    {
                        case "CARNET":
                            BuscarPorCarnet();
                            break;

                        case "CEDULA":
                            BuscarPorCedulaEstudiante();
                            break;

                        default:
                            // Opcional: manejar opción inválida
                            break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema",
                                "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
        private void BuscarPorCarnet()
        {
            try
            {

                this.txtestudiante.Text = string.Empty;
                this.txtcodigocarnet.Text = string.Empty;
                this.txtNombreFactura.Text = string.Empty;
                this.txtCedulaRuc.Text = string.Empty;
                
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cm = new SqlCommand("select a.Id_estudiante,a.Cod_carnet,b.Nombres,b.Apellidos,b.Cedula,c.NombreSucursal,d.Estado from Tbl_Estudiantes a join Tbl_Personas b on a.Id_persona = b.Id_persona join TblSucursales c on a.Id_sucursal = c.Id_sucursal join Tbl_Estados d on  a.Id_estado = d.Id_estado where a.Cod_carnet = '" + txtBusquedaEstudiante.Text + "'", conexion.Conexion());
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read() == true)
                {
                    this.txtestudiante.Text = dr["Nombres"].ToString() + " " + dr["Apellidos"].ToString();
                    this.txtcodigocarnet.Text = dr["Cod_carnet"].ToString();

                    this.txtNombreFactura.Text = dr["Nombres"].ToString() + " " + dr["Apellidos"].ToString();
                    this.txtCedulaRuc.Text = dr["Cedula"].ToString();
                }
                conexion.CerrarConexion();

                CacheDatos.CodCarnet = this.txtcodigocarnet.Text;
                CacheDatos.PasarCarnet = true;

                CacheBusquedaEstudiante.CodigoDeCarnet = this.txtcodigocarnet.Text;
                
            }
            catch (Exception)
            {
                MessageBox.Show("");
            }
        }

       
        private void BuscarPorCedulaEstudiante()
        {
            try
            {
                this.txtestudiante.Text = string.Empty;
                this.txtcodigocarnet.Text = string.Empty;
                this.txtNombreFactura.Text = string.Empty;
                this.txtCedulaRuc.Text = string.Empty;

                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cm = new SqlCommand("select a.Id_estudiante,a.Cod_carnet,b.Nombres,b.Apellidos,b.Cedula,c.NombreSucursal,d.Estado from Tbl_Estudiantes a join Tbl_Personas b on a.Id_persona = b.Id_persona join TblSucursales c on a.Id_sucursal = c.Id_sucursal join Tbl_Estados d on  a.Id_estado = d.Id_estado where b.cedula = '" + txtBusquedaEstudiante.Text + "' and d.Id_estado = '3'", conexion.Conexion());
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read() == true)
                {
                    this.txtestudiante.Text = dr["Nombres"].ToString() + " " + dr["Apellidos"].ToString();
                    this.txtcodigocarnet.Text = dr["Cod_carnet"].ToString();

                    this.txtNombreFactura.Text = dr["Nombres"].ToString() + " " + dr["Apellidos"].ToString();
                    this.txtCedulaRuc.Text = dr["Cedula"].ToString();
                }
                conexion.CerrarConexion();

                CacheDatos.CodCarnet = this.txtcodigocarnet.Text;
                CacheDatos.PasarCarnet = true;

                CacheBusquedaEstudiante.CodigoDeCarnet = this.txtcodigocarnet.Text;
                
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            // Habilitar o deshabilitar el groupBox basado en el estado del CheckBox
            groupBox1.Enabled = checkBox1.Checked;
        }
        
        private void btnRegistroVenta_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtNumeroFacturaLibreria.Text = this.CodigoFactura;
                this.tabControl1.SelectedTab = TabLibreria;

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Cargar_ComboMonedaLibreria()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("Select IdMoneda,Descripcion from Tbl_TipoMoneda", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Descripcion"] = "Selecciona una Moneda";
                dt.Rows.InsertAt(fila, 0);

                cmbTipoMonedaLibreria.ValueMember = "IdMoneda";
                cmbTipoMonedaLibreria.DisplayMember = "Descripcion";
                cmbTipoMonedaLibreria.DataSource = dt;
                
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Cargar_ComboMonedaPago()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("Select IdMoneda,Descripcion from Tbl_TipoMoneda", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Descripcion"] = "Selecciona una Moneda";
                dt.Rows.InsertAt(fila, 0);

                cmbTipoMonedaPago.ValueMember = "IdMoneda";
                cmbTipoMonedaPago.DisplayMember = "Descripcion";
                cmbTipoMonedaPago.DataSource = dt;


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Cargar_ComboMonedaAbono()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("Select IdMoneda,Descripcion from Tbl_TipoMoneda", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Descripcion"] = "Selecciona una Moneda";
                dt.Rows.InsertAt(fila, 0);

                cmbMonedaAbono.ValueMember = "IdMoneda";
                cmbMonedaAbono.DisplayMember = "Descripcion";
                cmbMonedaAbono.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
       
        
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            this.Estado_ = "3";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            this.Estado_ = "4";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                switch (this.cmbBusquedas.Text)
                {
                    case "Carnet":
                        MostrarPorCarnet();
                        break;

                    case "Nombres":
                        MostrarPorNombre();
                        break;

                    case "Apellidos":
                        MostrarPorApellidos();
                        break;

                    default:
                        MessageBox.Show("Seleccione un tipo de búsqueda válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }

                OcultarColumnas("Fecha", "Fecha_Registro", "HoraRegistro", "Cedula", "Direccion", "NombreTutor", "CelularTutor", "Parentesco", "FechaNacimiento", "Estado", "Id_Matricula", "Id_Grupo");

            }
            catch (Exception)
            {
                MessageBox.Show("Error: ", "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void OcultarColumnas(params string[] nombresColumnas)
        {
            foreach (string nombre in nombresColumnas)
            {
                if (dataEstudiantes.Columns.Contains(nombre))
                {
                    dataEstudiantes.Columns[nombre].Visible = false;
                }
            }
        }

        public void MostrarPorCarnet()
        {
            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            this.dataEstudiantes.DataSource = objetoCN.MostrarPorCarnet(this.txtbusqueda.Text, Estado_);

        }
        private void MostrarPorNombre()
        {
            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            this.dataEstudiantes.DataSource = objetoCN.MostrarPorNombre(this.txtbusqueda.Text, Estado_);

        }


        private void MostrarPorApellidos()
        {
            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            this.dataEstudiantes.DataSource = objetoCN.MostrarPorApellidos(this.txtbusqueda.Text, Estado_);

        }
        
        

        private void CargarInformacionCurso(string CodMatricula, string NombreCurso, string Turno, string Horario)
        {
            this.txtNombre_Curso.Text = NombreCurso.ToString();
            this.txtDia.Text = Turno.ToString();
            this.txtHorario_.Text = Horario.ToString();
            Cod_Matricula = CodMatricula;

            this.NombreCurso = NombreCurso.ToString();
            this.Turno = Turno.ToString();
            this.Horario = Horario.ToString();

        }

        private void MostrarDetallePago(string NumProg)
        {
            CN_Detalle_Programacion objetoCN = new CN_Detalle_Programacion();
            this.dataMensualidadesEstudiante.DataSource = objetoCN.BuscarDetallesPagos(NumProg);
            this.dataMensualidadesEstudiante.Columns["Cod_Matricula"].Visible = false;
            this.dataMensualidadesEstudiante.Columns["Num_programacion"].Visible = false;
            this.dataMensualidadesEstudiante.Columns["Tasa de Cambio"].Visible = false;
            this.dataMensualidadesEstudiante.Columns["Id_Detalle_Programacion"].Visible = false;
            this.dataMensualidadesEstudiante.Columns["IdMoneda"].Visible = false;

            foreach (DataGridViewColumn columna in dataMensualidadesEstudiante.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }



        private void dataNotas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (this.dataMensualidadesEstudiante.Columns[e.ColumnIndex].Name == "Estado")
                {
                    // Definir los colores según el estado
                    Color foreColor;
                    Color backColor;

                    switch (Convert.ToString(e.Value))
                    {
                        case "Pendiente":
                            foreColor = Color.White;
                            backColor = Color.Red;
                            break;

                        case "Completado":
                            foreColor = Color.White;
                            backColor = Color.Green;
                            break;

                        case "En proceso":
                            foreColor = Color.Black;
                            backColor = Color.Yellow;
                            break;

                        default:
                            // Si no coincide con ningún estado, salir sin aplicar cambios
                            return;
                    }

                    // Aplicar los colores a la celda
                    e.CellStyle.ForeColor = foreColor;
                    e.CellStyle.BackColor = backColor;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema: ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtestado.Text == "En proceso")
                {
                    MessageBox.Show("Ya seleccionado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (this.txtestado.Text == "Completado")
                {
                    MessageBox.Show("Mensualidad ya Pagada", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    if (this.txtSubtotalCordobas_.Text == "0" && this.txtestado.Text == "Pendiente")
                    {
                        MessageBox.Show("Error, no se puede procesar el pago", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DialogResult opcion;
                        opcion = MessageBox.Show("Verifique bien la Informacion, si es correcta Presione Ok", "SISTEMA CECNIC", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (opcion == DialogResult.OK)
                        {
                            CN_Factura objetoCN = new CN_Factura();
                            objetoCN.ModificarEstadoEnProceso(this.txtIDDETALLEPROGRAMACION.Text);

                            AgregarFilaDetalleFactura("11","1","1", this.txtsaldoPendiente.Text, "1", "5", this.txtsaldoPendiente.Text, Concepto_,this.txtIDDETALLEPROGRAMACION.Text);
                            calcularSubtotal();
                            this.CalcularTotal(Convert.ToDouble(this.txtSubtotal.Text), 0, 0);
                           
                            this.tabControl1.SelectedTab = TabFacturacion;
                            this.MostrarDetallePago(NumProgramacion_);

                        }
                        
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    

        private void ProcesarFilaSeleccionada(int currentRowIndex)
        {
            try
            {
                DataGridViewRow selectedRow = dataMensualidadesEstudiante.Rows[currentRowIndex];

                // Obtenemos los valores de la fila seleccionada
                string FechaProgramada = selectedRow.Cells["Fecha_Programada"].Value?.ToString();
                string Concepto = selectedRow.Cells["Concepto"].Value?.ToString();
                string Monto = selectedRow.Cells["Monto"].Value?.ToString();
                string Descripcion = selectedRow.Cells["Descripcion"].Value?.ToString();
                string Estado = selectedRow.Cells["Estado"].Value?.ToString();
                string FechaVencimiento = selectedRow.Cells["Fecha_Vencimiento"].Value?.ToString();
                string Mora = selectedRow.Cells["Mora"].Value?.ToString();
                string NumProgramacion = selectedRow.Cells["Num_programacion"].Value?.ToString();
                string IdDetalleProgramacion = selectedRow.Cells["Id_Detalle_Programacion"].Value?.ToString();
                string IdMoneda = selectedRow.Cells["IdMoneda"].Value?.ToString();
                string TasaCambio = selectedRow.Cells["Tasa de Cambio"].Value?.ToString();

                string fechaIngresada = Convert.ToDateTime(FechaVencimiento).ToShortDateString();
                this.FechaVencimientoSolvencia = this.ObtenerUltimoDiaDelMes(Convert.ToDateTime(fechaIngresada));


                string FechaActual = DateTime.Now.ToShortDateString();
                string FechaVenc = Convert.ToDateTime(FechaVencimiento).ToShortDateString();

                if (Convert.ToDateTime(FechaActual) <= Convert.ToDateTime(FechaVenc))
                {
                    EjecutarMetodosProgramacion(FechaProgramada, Concepto, Monto, Descripcion, Estado, FechaVencimiento, Mora, NumProgramacion, IdDetalleProgramacion, IdMoneda, TasaCambio);
                }
                else if (Convert.ToDateTime(FechaActual) > Convert.ToDateTime(FechaVenc))
                {
                    if (MoraAplicada == false)
                    {
                        this.AplicarMoraAutomaticamente(Convert.ToDateTime(FechaActual), Convert.ToDateTime(FechaVenc), IdDetalleProgramacion);
                        this.MoraAplicada = true;
                        MessageBox.Show("Mora Aplicada Automaticamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (MoraAplicada == true)
                    {
                        EjecutarMetodosProgramacion(FechaProgramada, Concepto, Monto, Descripcion, Estado, FechaVencimiento, Mora, NumProgramacion, IdDetalleProgramacion, IdMoneda, TasaCambio);

                    }

                }


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DateTime ObtenerUltimoDiaDelMes(DateTime fecha)
        {
            int ultimoDia = DateTime.DaysInMonth(fecha.Year, fecha.Month);
            return new DateTime(fecha.Year, fecha.Month, ultimoDia);
        }

        

        private void EjecutarMetodosProgramacion(string FechaProgramada, string Concepto, string Monto, string Descripcion, string Estado, string FechaVencimiento, string Mora, string NumProgramacion, string IdDetalleProgramacion, string IdMoneda, string TasaCambio)
        {
            this.ObtenerPrimerDetalleProgramacion(this.txtNumProgramacionEstudiante.Text);
            ActualIdDetalleProgramacion = IdDetalleProgramacion;
            this.CargarInformacionMensualidad(FechaProgramada, Concepto, Monto, Descripcion, Estado, FechaVencimiento, Mora, NumProgramacion, IdDetalleProgramacion, IdMoneda, TasaCambio);
            this.MostrarABONOS(IdDetalleProgramacion);
            this.dataAbonos.Columns["Id_Abono"].Visible = false;
            this.dataAbonos.Columns["Id_Detalle_Programacion"].Visible = false;
            this.SumaAbonado();
        }

        private void AplicarMoraAutomaticamente(DateTime fechaActual, DateTime fechaVenc, string idDetalleProgramacion)
        {
            int diasDiferencia = ObtenerDiasEntreFechas(fechaVenc, fechaActual);

            if (diasDiferencia < 1)
                return; // No aplicar mora si no hay retraso

            string porcentajeMora;

            if (diasDiferencia <= 7)
                porcentajeMora = "25";
            else if (diasDiferencia <= 15)
                porcentajeMora = "50";
            else if (diasDiferencia <= 22)
                porcentajeMora = "75";
            else
                porcentajeMora = "100";

            CN_Detalle_Programacion objeto = new CN_Detalle_Programacion();
            objeto.ActualizarMora(porcentajeMora, idDetalleProgramacion);

            MostrarDetallePago(NumProgramacion_);
        }



        public int ObtenerDiasEntreFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            // Restar las fechas y obtener el resultado como TimeSpan
            TimeSpan diferencia = fechaFin - fechaInicio;

            // Devolver la diferencia en días
            return diferencia.Days;
        }


        private void CargarInformacionMensualidad(
      string fechaProgramada,
      string concepto,
      string monto,
      string descripcion,
      string estado,
      string fechaVencimiento,
      string mora,
      string numProgramacion,
      string idDetalleProgramacion,
      string idMoneda,
      string tasaCambio)
        {
            // Asignar valores a las propiedades
            FechaProgramada_ = fechaProgramada;
            Concepto_ = concepto;
            Monto_ = monto;
            Descripcion_ = descripcion;
            Estado_ = estado;
            FechaVencimiento_ = fechaVencimiento;
            Mora_ = mora;
            NumProgramacion_ = numProgramacion;
            Id_Detalle_Programacion_ = idDetalleProgramacion;
            IdMoneda_ = idMoneda;
            TasaCambio_ = tasaCambio;

            // Cargar información en los campos de texto
            txtConcepto.Text = Concepto_;
            txtsubtotal_.Text = Monto_;
            txtmora.Text = Mora_;
            txtestado.Text = Estado_;

            // Calcular y mostrar el subtotal en córdobas
            txtSubtotalCordobas_.Text = CalcularSubtotalCordobas(Monto_, Mora_, TasaCambio_);
        }


        private string CalcularSubtotalCordobas(string monto, string mora, string tasaCambio)
        {
            try
            {
                // Convertir las cadenas a double y calcular el subtotal
                double montoDouble = Convert.ToDouble(monto);
                double moraDouble = Convert.ToDouble(mora);
                double tasaCambioDouble = Convert.ToDouble(tasaCambio);

                double subtotal = (montoDouble * tasaCambioDouble) + moraDouble;
                return subtotal.ToString("F2"); // Formato a 2 decimales
            }
            catch (FormatException)
            {
                MessageBox.Show("Error en los datos de entrada. Asegúrese de que los montos y tasas sean numéricos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "0.00"; // Valor predeterminado en caso de error
            }
            catch (Exception)
            {
                MessageBox.Show($"Error al calcular el subtotal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "0.00"; // Valor predeterminado en caso de error
            }
        }


        private void button3_Click_2(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipoMonedaLibreria.Text == "Selecciona una Moneda")
                {
                    MessageBox.Show("Selecciona una Moneda Primeramente");
                }
                else if (this.cmbTipoMonedaLibreria.Text != "Selecciona una Moneda")
                {
                    this.Calculos();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTipoMonedaLibreria_SelectedIndexChanged(object sender, EventArgs e)
        {
            CD_Conexion conexion = new CD_Conexion();
            conexion.AbrirConexion();
            SqlCommand cm = new SqlCommand("select  ValorMoneda from Tbl_TipoMoneda where IdMoneda = '" + this.cmbTipoMonedaLibreria.SelectedValue + "'", conexion.Conexion());
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read() == true)
            {
                this.txtTasaCambioLibreria.Text = dr["ValorMoneda"].ToString();

            }
            conexion.CerrarConexion();
        }


        private void Calculos()
        {
            if (!double.TryParse(txtmontoLibreria.Text, out double monto))
            {
                MessageBox.Show("Monto inválido", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontoEnCordobasLibreria.Text = string.Empty;
                return;
            }

            if (!double.TryParse(txtTasaCambioLibreria.Text, out double tasaCambio))
            {
                MessageBox.Show("Tasa de cambio inválida", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontoEnCordobasLibreria.Text = string.Empty;
                return;
            }

            if (monto <= 0)
            {
                MessageBox.Show("No se admite valor menor o igual a cero", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontoEnCordobasLibreria.Text = string.Empty;
                return;
            }

            double montoEnCordobas = monto * tasaCambio;
            txtMontoEnCordobasLibreria.Text = montoEnCordobas.ToString("N2");

            groupCompletarLibreria.Enabled = true;
            txtObservacionLibreria.Text = $"VENTA DE LIBRERIA {DateTime.Now:dd/MM/yyyy HH:mm}";
        }


        private void CalculosPago()
        {
            if (!double.TryParse(txtPagoConPago.Text, out double pago))
            {
                MessageBox.Show("Monto inválido", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPagoConPago.Clear();
                return;
            }

            if (!double.TryParse(txtTasaCambioPago.Text, out double tasaCambio))
            {
                MessageBox.Show("Tasa de cambio inválida", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pago <= 0)
            {
                MessageBox.Show("No se admite valor menor o igual a cero", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPagoConPago.Clear();
                return;
            }

            double montoCordobas = pago * tasaCambio;

            txtMontoCordobasPago.Text = montoCordobas.ToString("N2");
            txtPagoCon.Text = montoCordobas.ToString("N2");

            CalcularCambio(txtMontoCordobasPago.Text, txttotalPago.Text);
        }


        private void CalcularPagoDeposito()
        {
            try
            {
                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(txtMontoPago.Text) ||
                    string.IsNullOrWhiteSpace(txttotalPago.Text))
                {
                    MessageBox.Show("Por favor, complete ambos campos",
                                  "SISTEMA CECNIC",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }

                // Intentar convertir los valores con manejo específico de formatos
                if (!double.TryParse(txtMontoPago.Text, out double montoPagado) ||
                    !double.TryParse(txttotalPago.Text, out double totalPagar))
                {
                    MessageBox.Show("Por favor, ingrese valores numéricos válidos",
                                  "SISTEMA CECNIC",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                    return;
                }

                // Validar que los montos sean positivos
                if (montoPagado < 0 || totalPagar < 0)
                {
                    MessageBox.Show("Los montos no pueden ser negativos",
                                  "SISTEMA CECNIC",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                    return;
                }

                // Realizar cálculos
                if (montoPagado < totalPagar)
                {
                    MessageBox.Show("Error: Dinero insuficiente",
                                  "SISTEMA CECNIC",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
                else if (montoPagado > totalPagar)
                {
                    // En lugar de mostrar error, calcular cambio cuando se paga de más
                    double cambio = montoPagado - totalPagar;

                    txtPagoCon.Text = montoPagado.ToString("N2"); // Formato de moneda
                    txtCambioPago.Text = cambio.ToString("N2");   // Formato de moneda

                    MessageBox.Show($"Cambio a devolver: {cambio:N2}",
                                  "SISTEMA CECNIC",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
                else // montoPagado == totalPagar
                {
                    txtPagoCon.Text = montoPagado.ToString("N2");
                    txtCambioPago.Text = "0";

                    MessageBox.Show("Pago exacto realizado",
                                  "SISTEMA CECNIC",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato de número inválido",
                              "SISTEMA CECNIC",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
            catch (OverflowException)
            {
                MessageBox.Show("El valor ingresado es demasiado grande",
                              "SISTEMA CECNIC",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                // Loggear la excepción para debugging (opcional)
                // Logger.Error(ex, "Error en CalcularPagoDeposito");

                MessageBox.Show($"Error de sistema",
                              "SISTEMA CECNIC",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void CalcularCambio(string pagoCon, string total)
        {
            try
            {
                // Validar entradas
                if (string.IsNullOrWhiteSpace(pagoCon) || string.IsNullOrWhiteSpace(total))
                {
                    MostrarMensaje("Por favor, complete ambos campos", MessageBoxIcon.Warning);
                    LimpiarCamposPago();
                    return;
                }

                // Convertir valores con validación
                if (!double.TryParse(pagoCon, out double montoPagado) ||
                    !double.TryParse(total, out double totalPagar))
                {
                    MostrarMensaje("Por favor, ingrese valores numéricos válidos", MessageBoxIcon.Error);
                    LimpiarCamposPago();
                    return;
                }

                // Validar valores positivos
                if (montoPagado < 0 || totalPagar < 0)
                {
                    MostrarMensaje("Los montos no pueden ser negativos", MessageBoxIcon.Error);
                    LimpiarCamposPago();
                    return;
                }

                // Validar que total no sea cero
                if (totalPagar == 0)
                {
                    MostrarMensaje("El total a pagar no puede ser cero", MessageBoxIcon.Warning);
                    LimpiarCamposPago();
                    return;
                }

                // Calcular cambio
                if (montoPagado < totalPagar)
                {
                    LimpiarCamposPago();
                    MostrarMensaje("Error: Dinero insuficiente para realizar el pago", MessageBoxIcon.Error);
                }
                else
                {
                    double cambio = montoPagado - totalPagar;
                    double cambioRedondeado = Math.Round(cambio, 2); // Redondear a 2 decimales

                    txtPagoCon.Text = montoPagado.ToString("N2"); // Formato numérico con 2 decimales
                    txtCambioPago.Text = cambioRedondeado.ToString("N2");

                 
                }
            }
            catch (FormatException)
            {
                MostrarMensaje("Formato de número inválido", MessageBoxIcon.Error);
                LimpiarCamposPago();
            }
            catch (OverflowException)
            {
                MostrarMensaje("El valor ingresado es demasiado grande", MessageBoxIcon.Error);
                LimpiarCamposPago();
            }
            catch (Exception)
            {
                // Loggear error para debugging (opcional)
                // Logger.Error(ex, "Error en CalcularCambio");

                MostrarMensaje($"Error de sistema", MessageBoxIcon.Error);
                LimpiarCamposPago();
            }
        }


        private void MostrarMensaje(string mensaje, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, "SISTEMA CECNIC", MessageBoxButtons.OK, icono);
        }

        private void LimpiarCamposPago()
        {
            txtPagoCon.Text = "0";
            txtCambioPago.Text = "0";
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedTab = TabFacturacion;
                this.LimpiarLibreria();

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarLibreria()
        {
            this.txtmontoLibreria.Text = string.Empty;
            this.txtTasaCambioLibreria.Text = string.Empty;
            this.txtMontoEnCordobasLibreria.Text = string.Empty;
            this.txtObservacionLibreria.Text = string.Empty;
            this.Cargar_ComboMonedaLibreria();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMontoEnCordobasLibreria.Text))
                {
                    MessageBox.Show("Ingrese el monto", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(txtSubtotal.Text, out double subtotal))
                {
                    MessageBox.Show("El subtotal no es válido", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int rowIndex = this.TablaDetalleFactura.Rows.Add();
                DataGridViewRow row = this.TablaDetalleFactura.Rows[rowIndex];

                row.Cells["Id_Arancel"].Value = "14";
                row.Cells["IdMoneda"].Value = "1";
                row.Cells["Valor_Moneda"].Value = this.txtTasaCambioLibreria.Text;
                row.Cells["Total_en_Cordobas"].Value = this.txtMontoEnCordobasLibreria.Text;
                row.Cells["Cantidad"].Value = "1";
                row.Cells["Id_estado"].Value = "5";
                row.Cells["Monto"].Value = this.txtMontoEnCordobasLibreria.Text;
                row.Cells["Observaciones"].Value = this.txtObservacionLibreria.Text;

                calcularSubtotal();
                this.CalcularTotal(Convert.ToDouble(this.txtSubtotal.Text), 0, 0);

                txtNombreFactura.Text = "VENTA DE LIBRERIA";
                
                tabControl1.SelectedTab = TabFacturacion;
                LimpiarLibreria();
            }
            catch (Exception)
            {
                MessageBox.Show($"Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbTipoMonedaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cm = new SqlCommand("select  ValorMoneda from Tbl_TipoMoneda where IdMoneda = '" + this.cmbTipoMonedaPago.SelectedValue + "'", conexion.Conexion());
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read() == true)
                {
                    this.txtTasaCambioPago.Text = dr["ValorMoneda"].ToString();

                }
                conexion.CerrarConexion();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnObtenerMontoEnCordobas_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipoMonedaPago.Text == "Selecciona una Moneda")
                {
                    MessageBox.Show("Selecciona una Moneda Primeramente");
                }
                else if (this.cmbTipoMonedaPago.Text != "Selecciona una Moneda")
                {
                    this.CalculosPago();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void cmbTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Primero habilitamos todas las pestañas
                foreach (TabPage tab in tabControl3.TabPages)
                    tab.Enabled = true;

                string tipoPago = cmbTipoPago.SelectedItem?.ToString() ?? string.Empty;

                if (string.IsNullOrEmpty(tipoPago))
                    return; // Si no hay selección, no hacemos nada

                switch (tipoPago)
                {
                    case "EFECTIVO":
                        tabControl3.TabPages[0].Enabled = true;
                        tabControl3.TabPages[1].Enabled = false;
                        tabControl3.SelectedIndex = 0;

                        txtSeleccionTipoPago.Clear(); // Limpia el valor
                        break;

                    case "DEPOSITO":
                    case "TARJETA":
                    case "CHEQUE":
                    case "TRANSFERENCIA":
                        tabControl3.TabPages[0].Enabled = false;
                        tabControl3.TabPages[1].Enabled = true;
                        tabControl3.SelectedIndex = 1;

                        // Reiniciar valores por defecto
                        txtReferenciaPago.Clear();
                        txtMontoPago.Text = "0";
                        txtMontoPago.Enabled = false;
                        btnContinuarProceso.Enabled = false;

                        // Guardamos directamente el tipo seleccionado
                        txtSeleccionTipoPago.Text = tipoPago;
                        break;

                    default:
                        MessageBox.Show("Seleccione un tipo de pago válido.", "SISTEMA CECNIC",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema: ", "SISTEMA CECNIC",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbTipoPago.Text == "EFECTIVO")
                {
                    GuardarFactura("EFECTIVO");
                }
                else if (this.cmbTipoPago.Text == "DEPOSITO")
                {
                    GuardarFactura("DEPOSITO");
                }
                else if (this.cmbTipoPago.Text == "CHEQUE")
                {
                    GuardarFactura("CHEQUE");
                }
                else if (this.cmbTipoPago.Text == "TARJETA")
                {
                    GuardarFactura("TARJETA");
                }
                else if (this.cmbTipoPago.Text == "TRANSFERENCIA")
                {
                    GuardarFactura("TRANSFERENCIA");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GuardarFactura(string TipoFactura)
        {
            try
            {
                if (TipoFactura == "EFECTIVO")
                {
                    if (this.txtPagoCon.Text == "0")
                    {
                        MessageBox.Show("No se puede realizar el Pago", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (this.txtPagoCon.Text != "0")
                    {

                        DialogResult result = MessageBox.Show("¿Qué acción desea realizar?\nYES: Guardar e Imprimir\nNO: Solo Guardar", "EFECTIVO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (result == DialogResult.Yes)
                        {
                            //Logica para Guardar e Imprimir
                            int IdCaja = Convert.ToInt32(CacheUsuario.IdCaja);

                            if (IdCaja == 1)
                            {
                                LetraCaja = "A";
                            }
                            else if (IdCaja == 2)
                            {
                                LetraCaja = "B";
                            }
                            else if (IdCaja == 3)
                            {
                                LetraCaja = "C";
                            }

                            CN_Usuarios objetoUsuario = new CN_Usuarios();
                            //Obtener Numero de Caja
                            string CodigoFact = objetoUsuario.ObtenerNumCaja(LetraCaja);
                            this.CodigoFactu = CodigoFact;

                            void GuardarFactura()
                            {
                                string FechaActual = Convert.ToString(DateTime.Now.ToShortDateString());
                                string nombreEquipo = Environment.MachineName;
                                string HoraRegistro = DateTime.Now.ToLongTimeString();

                                //Guardamos la Factura
                                CN_Factura objetoFactura = new CN_Factura();
                                objetoFactura.Insertar(CodigoFact, "EFECTIVO", this.txtSubtotalPago.Text, "0", this.txttotalPago.Text, this.cmbTipoMonedaPago.SelectedValue.ToString(), "6", CacheUsuario.IdUsuario, nombreEquipo, FechaActual, this.txtNombredeFacturaPago.Text, this.txtCarnetPago.Text, this.txtCarnetPago.Text);
                                //Insertamos Detalle del Pago
                                objetoFactura.InsertarDetallePago(CodigoFact, "EFECTIVO", this.txtPagoConPago.Text, this.cmbTipoMonedaPago.SelectedValue.ToString(), this.txtTasaCambioPago.Text, this.txtPagoCon.Text, this.txttotalPago.Text, this.txtCambioPago.Text, "");
                                //Insertamos Movimiento de Caja
                                objetoFactura.InsertarMovimientoCaja("FACTURA", CodigoFact, "ENTRADA", this.txttotalPago.Text, "1", FechaActual, CacheUsuario.IdUsuario, CacheUsuario.IdCaja, HoraRegistro);
                                //InsertamoS Factura detalle
                                CN_FacturDetalle objetoDetalle = new CN_FacturDetalle();
                                CN_Abonos objetoAbono = new CN_Abonos();
                                CN_FacturaMensualidades objetoFacMensualidades = new CN_FacturaMensualidades();

                                foreach (DataGridViewRow fila in dataDetalles.Rows)
                                {
                                    if (!fila.IsNewRow) // Evitar la fila vacía al final
                                    {
                                        string observaciones = fila.Cells["Observaciones"].Value?.ToString();
                                        string cantidad = fila.Cells["Cantidad"].Value?.ToString();
                                        string totalCordobas = fila.Cells["Total_en_Cordobas"].Value?.ToString();
                                        string idEstado = fila.Cells["Id_estado"].Value?.ToString();
                                        string idMoneda = fila.Cells["IdMoneda"].Value?.ToString();
                                        string idArancel = fila.Cells["Id_Arancel"].Value?.ToString();
                                        string valorMoneda = fila.Cells["Valor_Moneda"].Value?.ToString();
                                        string monto = fila.Cells["Monto"].Value?.ToString();
                                        string IdDetalleProgramacion = fila.Cells["Id_Detalle_Programacion"].Value?.ToString();

                                        if (idArancel == "11")
                                        {
                                            objetoFacMensualidades.InsertarFacturaMensualidades(CodigoFact,IdDetalleProgramacion,observaciones);
                                            objetoFactura.ModificarEstadoaCompletado(IdDetalleProgramacion);
                                        }
                                        else if (idArancel == "12")
                                        {
                                            objetoAbono.InsertarAbono(FechaActual, monto, idMoneda, CacheUsuario.IdUsuario, IdDetalleProgramacion, CodigoFact, "6", observaciones, NumProgramacion_);
                                            objetoFactura.ModificarEstadoaPendiente(IdDetalleProgramacion);
                                        }

                                        objetoDetalle.InsertarDetalleFactura(CodigoFact, idArancel, idMoneda, valorMoneda, totalCordobas, cantidad, idEstado, monto, observaciones);


                                    }
                                }

                                CacheReferencia.Subtotal = this.txtSubtotalPago.Text;
                                CacheReferencia.Descuento = this.txtDescuentoPago.Text;
                                CacheReferencia.Iva = this.txtIvaPago.Text;
                                CacheReferencia.Total = this.txttotalPago.Text;
                                CacheReferencia.PagoCon = this.txtMontoCordobasPago.Text;
                                CacheReferencia.Cambio = this.txtCambioPago.Text;

                                this.Hide();
                                Frm_Cambio frm = new Frm_Cambio();
                                frm.Show();

                            }

                            CustomPrintPreviewForm previewForm = new CustomPrintPreviewForm(printDocument1, GuardarFactura, this);
                            previewForm.ShowDialog();




                        }
                        else if (result == DialogResult.No)
                        {
                            //Logica para solo Guardar la factura
                            int IdCaja = Convert.ToInt32(CacheUsuario.IdCaja);

                            if (IdCaja == 1)
                            {
                                LetraCaja = "A";
                            }
                            else if (IdCaja == 2)
                            {
                                LetraCaja = "B";
                            }
                            else if (IdCaja == 3)
                            {
                                LetraCaja = "C";
                            }

                            CN_Usuarios objetoUsuario = new CN_Usuarios();
                            //Obtener Numero de Caja
                            string CodigoFact = objetoUsuario.ObtenerNumCaja(LetraCaja);
                            //Variables
                            this.CodigoFactu = CodigoFact;
                            string FechaActual = Convert.ToString(DateTime.Now.ToShortDateString());
                            string nombreEquipo = Environment.MachineName;
                            string HoraRegistro = DateTime.Now.ToLongTimeString();

                            //Guardamos la Factura
                            CN_Factura objetoFactura = new CN_Factura();
                            objetoFactura.Insertar(CodigoFact, "EFECTIVO", this.txtSubtotalPago.Text, "0", this.txttotalPago.Text, this.cmbTipoMonedaPago.SelectedValue.ToString(), "6", CacheUsuario.IdUsuario, nombreEquipo, FechaActual, this.txtNombredeFacturaPago.Text, this.txtCarnetPago.Text, this.txtCarnetPago.Text);
                            //Insertamos Detalle del Pago
                            objetoFactura.InsertarDetallePago(CodigoFact, "EFECTIVO", this.txtPagoConPago.Text, this.cmbTipoMonedaPago.SelectedValue.ToString(), this.txtTasaCambioPago.Text, this.txtPagoCon.Text, this.txttotalPago.Text, this.txtCambioPago.Text, "");
                            //Insertamos Movimiento de Caja
                            objetoFactura.InsertarMovimientoCaja("FACTURA", CodigoFact, "ENTRADA", this.txttotalPago.Text, "1", FechaActual, CacheUsuario.IdUsuario, CacheUsuario.IdCaja, HoraRegistro);

                            //InsertamoS Factura detalle
                            CN_FacturDetalle objetoDetalle = new CN_FacturDetalle();
                            CN_Abonos objetoAbono = new CN_Abonos();
                            CN_FacturaMensualidades objetoFacMensualidades = new CN_FacturaMensualidades();

                            foreach (DataGridViewRow fila in dataDetalles.Rows)
                            {
                                if (!fila.IsNewRow) // Evitar la fila vacía al final
                                {
                                    string observaciones = fila.Cells["Observaciones"].Value?.ToString();
                                    string cantidad = fila.Cells["Cantidad"].Value?.ToString();
                                    string totalCordobas = fila.Cells["Total_en_Cordobas"].Value?.ToString();
                                    string idEstado = fila.Cells["Id_estado"].Value?.ToString();
                                    string idMoneda = fila.Cells["IdMoneda"].Value?.ToString();
                                    string idArancel = fila.Cells["Id_Arancel"].Value?.ToString();
                                    string valorMoneda = fila.Cells["Valor_Moneda"].Value?.ToString();
                                    string monto = fila.Cells["Monto"].Value?.ToString();
                                    string IdDetalleProgramacion = fila.Cells["Id_Detalle_Programacion"].Value?.ToString();

                                    if (idArancel == "11")
                                    {
                                        objetoFacMensualidades.InsertarFacturaMensualidades(CodigoFact, IdDetalleProgramacion, observaciones);
                                        objetoFactura.ModificarEstadoaCompletado(IdDetalleProgramacion);
                                    }else if (idArancel == "12")
                                    {
                                        objetoAbono.InsertarAbono(FechaActual,monto,idMoneda,CacheUsuario.IdUsuario,IdDetalleProgramacion,CodigoFact,"6",observaciones,NumProgramacion_);
                                        objetoFactura.ModificarEstadoaPendiente(IdDetalleProgramacion);
                                    }

                                    objetoDetalle.InsertarDetalleFactura(CodigoFact,idArancel,idMoneda,valorMoneda,totalCordobas,cantidad,idEstado,monto,observaciones);
                                  
                                    
                                }
                            }


                            CacheReferencia.Subtotal = this.txtSubtotalPago.Text;
                            CacheReferencia.Descuento = this.txtDescuentoPago.Text;
                            CacheReferencia.Iva = this.txtIvaPago.Text;
                            CacheReferencia.Total = this.txttotalPago.Text;
                            CacheReferencia.PagoCon = this.txtMontoCordobasPago.Text;
                            CacheReferencia.Cambio = this.txtCambioPago.Text;

                            this.Hide();
                            Frm_Cambio frm = new Frm_Cambio();
                            frm.Show();




                        }
                    }
                }else if (TipoFactura == "DEPOSITO" || TipoFactura == "TARJETA" || TipoFactura == "CHEQUE" || TipoFactura == "TRANSFERENCIA")
                {
                    if (this.txtPagoCon.Text == "0")
                    {
                        MessageBox.Show("No se puede realizar el Pago", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (this.txtPagoCon.Text != "0")
                    {
                        DialogResult result = MessageBox.Show("¿Qué acción desea realizar?\nYES: Guardar e Imprimir\nNO: Solo Guardar", "EFECTIVO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (result == DialogResult.Yes)
                        {
                            int IdCaja = Convert.ToInt32(CacheUsuario.IdCaja);

                            if (IdCaja == 1)
                            {
                                LetraCaja = "A";
                            }
                            else if (IdCaja == 2)
                            {
                                LetraCaja = "B";
                            }
                            else if (IdCaja == 3)
                            {
                                LetraCaja = "C";
                            }

                            CN_Usuarios objetoUsuario = new CN_Usuarios();
                            //Obtener Numero de Caja
                            string CodigoFact = objetoUsuario.ObtenerNumCaja(LetraCaja);
                            //Variables
                            this.CodigoFactu = CodigoFact;

                            void GuardarFactura()
                            {
                                string FechaActual = Convert.ToString(DateTime.Now.ToShortDateString());
                                string nombreEquipo = Environment.MachineName;
                                string HoraRegistro = DateTime.Now.ToLongTimeString();

                                //Guardamos la Factura
                                CN_Factura objetoFactura = new CN_Factura();
                                objetoFactura.Insertar(CodigoFact, this.txtSeleccionTipoPago.Text.ToUpper(), this.txtSubtotalPago.Text, "0", this.txttotalPago.Text, "1", "6", CacheUsuario.IdUsuario, nombreEquipo, FechaActual, this.txtNombredeFacturaPago.Text, this.txtCarnetPago.Text, this.txtCarnetPago.Text);
                                //Insertamos Detalle del Pago
                                objetoFactura.InsertarDetallePago(CodigoFact, this.txtSeleccionTipoPago.Text.ToUpper(), this.txtPagoCon.Text, "1", "1", this.txtPagoCon.Text, this.txttotalPago.Text, this.txtCambioPago.Text, this.txtReferenciaPago.Text);
                                //Insertamos Movimiento de Caja
                                objetoFactura.InsertarMovimientoCaja("FACTURA", CodigoFact, "ENTRADA", this.txttotalPago.Text, "1", FechaActual, CacheUsuario.IdUsuario, CacheUsuario.IdCaja, HoraRegistro);


                                //InsertamoS Factura detalle
                                CN_FacturDetalle objetoDetalle = new CN_FacturDetalle();
                                CN_Abonos objetoAbono = new CN_Abonos();
                                CN_FacturaMensualidades objetoFacMensualidades = new CN_FacturaMensualidades();

                                foreach (DataGridViewRow fila in dataDetalles.Rows)
                                {
                                    if (!fila.IsNewRow) // Evitar la fila vacía al final
                                    {
                                        string observaciones = fila.Cells["Observaciones"].Value?.ToString();
                                        string cantidad = fila.Cells["Cantidad"].Value?.ToString();
                                        string totalCordobas = fila.Cells["Total_en_Cordobas"].Value?.ToString();
                                        string idEstado = fila.Cells["Id_estado"].Value?.ToString();
                                        string idMoneda = fila.Cells["IdMoneda"].Value?.ToString();
                                        string idArancel = fila.Cells["Id_Arancel"].Value?.ToString();
                                        string valorMoneda = fila.Cells["Valor_Moneda"].Value?.ToString();
                                        string monto = fila.Cells["Monto"].Value?.ToString();
                                        string IdDetalleProgramacion = fila.Cells["Id_Detalle_Programacion"].Value?.ToString();

                                        if (idArancel == "11")
                                        {
                                            objetoFacMensualidades.InsertarFacturaMensualidades(CodigoFact, IdDetalleProgramacion, observaciones);
                                            objetoFactura.ModificarEstadoaCompletado(IdDetalleProgramacion);
                                        }
                                        else if (idArancel == "12")
                                        {
                                            objetoAbono.InsertarAbono(FechaActual, monto, idMoneda, CacheUsuario.IdUsuario, IdDetalleProgramacion, CodigoFact, "6", observaciones, NumProgramacion_);
                                            objetoFactura.ModificarEstadoaPendiente(IdDetalleProgramacion);
                                        }

                                        objetoDetalle.InsertarDetalleFactura(CodigoFact, idArancel, idMoneda, valorMoneda, totalCordobas, cantidad, idEstado, monto, observaciones);


                                    }
                                }

                                CacheReferencia.Subtotal = this.txtSubtotalPago.Text;
                                CacheReferencia.Descuento = this.txtDescuentoPago.Text;
                                CacheReferencia.Iva = this.txtIvaPago.Text;
                                CacheReferencia.Total = this.txttotalPago.Text;
                                CacheReferencia.PagoCon = this.txtMontoPago.Text;
                                CacheReferencia.Cambio = this.txtCambioPago.Text;

                                this.Hide();
                                Frm_Cambio frm = new Frm_Cambio();
                                frm.Show();



                            }


                            // Mostrar vista previa de la impresión utilizando la clase personalizada
                            CustomPrintPreviewForm previewForm = new CustomPrintPreviewForm(printDocument2, GuardarFactura, this);
                            previewForm.ShowDialog();

                        }
                        else if (result == DialogResult.No)
                        {
                            //Logica para solo Guardar la factura
                            int IdCaja = Convert.ToInt32(CacheUsuario.IdCaja);

                            if (IdCaja == 1)
                            {
                                LetraCaja = "A";
                            }
                            else if (IdCaja == 2)
                            {
                                LetraCaja = "B";
                            }
                            else if (IdCaja == 3)
                            {
                                LetraCaja = "C";
                            }

                            CN_Usuarios objetoUsuario = new CN_Usuarios();
                            //Obtener Numero de Caja
                            string CodigoFact = objetoUsuario.ObtenerNumCaja(LetraCaja);
                            //Variables
                            this.CodigoFactu = CodigoFact;
                            string FechaActual = Convert.ToString(DateTime.Now.ToShortDateString());
                            string nombreEquipo = Environment.MachineName;
                            string HoraRegistro = DateTime.Now.ToLongTimeString();

                            //Guardamos la Factura
                            CN_Factura objetoFactura = new CN_Factura();
                            objetoFactura.Insertar(CodigoFact, this.txtSeleccionTipoPago.Text.ToUpper(), this.txtSubtotalPago.Text, "0", this.txttotalPago.Text, "1", "6", CacheUsuario.IdUsuario, nombreEquipo, FechaActual, this.txtNombredeFacturaPago.Text, this.txtCarnetPago.Text, this.txtCarnetPago.Text);
                            //Insertamos Detalle del Pago
                            objetoFactura.InsertarDetallePago(CodigoFact, this.txtSeleccionTipoPago.Text.ToUpper(), this.txtPagoCon.Text, "1", "1", this.txtPagoCon.Text, this.txttotalPago.Text, this.txtCambioPago.Text, this.txtReferenciaPago.Text);
                            //Insertamos Movimiento de Caja
                            objetoFactura.InsertarMovimientoCaja("FACTURA", CodigoFact, "ENTRADA", this.txttotalPago.Text, "1", FechaActual, CacheUsuario.IdUsuario, CacheUsuario.IdCaja, HoraRegistro);

                            //InsertamoS Factura detalle
                            CN_FacturDetalle objetoDetalle = new CN_FacturDetalle();
                            CN_Abonos objetoAbono = new CN_Abonos();
                            CN_FacturaMensualidades objetoFacMensualidades = new CN_FacturaMensualidades();

                            foreach (DataGridViewRow fila in dataDetalles.Rows)
                            {
                                if (!fila.IsNewRow) // Evitar la fila vacía al final
                                {
                                    string observaciones = fila.Cells["Observaciones"].Value?.ToString();
                                    string cantidad = fila.Cells["Cantidad"].Value?.ToString();
                                    string totalCordobas = fila.Cells["Total_en_Cordobas"].Value?.ToString();
                                    string idEstado = fila.Cells["Id_estado"].Value?.ToString();
                                    string idMoneda = fila.Cells["IdMoneda"].Value?.ToString();
                                    string idArancel = fila.Cells["Id_Arancel"].Value?.ToString();
                                    string valorMoneda = fila.Cells["Valor_Moneda"].Value?.ToString();
                                    string monto = fila.Cells["Monto"].Value?.ToString();
                                    string IdDetalleProgramacion = fila.Cells["Id_Detalle_Programacion"].Value?.ToString();

                                    if (idArancel == "11")
                                    {
                                        objetoFacMensualidades.InsertarFacturaMensualidades(CodigoFact, IdDetalleProgramacion, observaciones);
                                        objetoFactura.ModificarEstadoaCompletado(IdDetalleProgramacion);
                                    }
                                    else if (idArancel == "12")
                                    {
                                        objetoAbono.InsertarAbono(FechaActual, monto, idMoneda, CacheUsuario.IdUsuario, IdDetalleProgramacion, CodigoFact, "6", observaciones, NumProgramacion_);
                                        objetoFactura.ModificarEstadoaPendiente(IdDetalleProgramacion);
                                    }

                                    objetoDetalle.InsertarDetalleFactura(CodigoFact, idArancel, idMoneda, valorMoneda, totalCordobas, cantidad, idEstado, monto, observaciones);


                                }
                            }


                            CacheReferencia.Subtotal = this.txtSubtotalPago.Text;
                            CacheReferencia.Descuento = this.txtDescuentoPago.Text;
                            CacheReferencia.Iva = this.txtIvaPago.Text;
                            CacheReferencia.Total = this.txttotalPago.Text;
                            CacheReferencia.PagoCon = this.txtMontoPago.Text;
                            CacheReferencia.Cambio = this.txtCambioPago.Text;

                            this.Hide();
                            Frm_Cambio frm = new Frm_Cambio();
                            frm.Show();




                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        
        
        private void button5_Click_2(object sender, EventArgs e)
        {
            try
            {
                DataTable tabla = new DataTable();
                CN_Movimientos objetoCN = new CN_Movimientos();

                tabla = objetoCN.VerificarSiExisteReferencia(this.txtReferenciaPago.Text);
                if (tabla.Rows.Count == 0)
                {
                    //Si no esta Registrada

                    this.txtMontoPago.Enabled = true;
                    this.btnContinuarProceso.Enabled = true;

                }
                else if (tabla.Rows.Count != 0)
                {
                    //Si esta Registrada

                    CacheReferencia.Factura = tabla.Rows[0][0].ToString();
                    CacheReferencia.Tipo = tabla.Rows[0][1].ToString();
                    CacheReferencia.NReferencia = tabla.Rows[0][2].ToString();
                    CacheReferencia.FechaRegistro = tabla.Rows[0][3].ToString();
                    CacheReferencia.Estudiante = tabla.Rows[0][4].ToString();
                    CacheReferencia.Carnet = tabla.Rows[0][5].ToString();

                    this.txtMontoPago.Enabled = false;
                    this.btnContinuarProceso.Enabled = false;

                    Frm_VerificacionReferencia frm = new Frm_VerificacionReferencia();
                    frm.Show();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnContinuarPago_Click(object sender, EventArgs e)
        {
            this.CalcularPagoDeposito();
        }


        private void RealizarCalculosAbonos()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.txtmontototalAbonar.Text))
                {
                    MessageBox.Show("Campo vacío, agrega una cantidad",
                        "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Intentamos convertir los valores de forma segura
                if (!double.TryParse(this.txtmontototalAbonar.Text, out double montoAbonar) ||
                    !double.TryParse(this.txtTasaCambioAbono.Text, out double tasaCambio) ||
                    !double.TryParse(this.txtSubtotalAbono.Text, out double subtotal) ||
                    !double.TryParse(this.txtTotalAbonos.Text, out double totalAbonos))
                {
                    MessageBox.Show("Ingrese valores numéricos válidos",
                        "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (montoAbonar <= 0)
                {
                    MessageBox.Show("El monto a abonar debe ser mayor a cero",
                        "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cálculo del total abonado en córdobas
                double totalCordobasAbonado = montoAbonar * tasaCambio;
                this.txtMontoTotalAbonadoCordobas.Text = totalCordobasAbonado.ToString("N2");

                // Cálculo del saldo
                double saldo = subtotal - totalAbonos - totalCordobasAbonado;
                this.txtProximoSaldo.Text = saldo.ToString("N2");

                // Habilitamos el botón
                this.btnAgregarAbono.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de sistema: ",
                    "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void LimpiarControlesAbono()
        {
            this.txtSubtotalAbono.Text = string.Empty;
            this.txtTotalAbonos.Text = string.Empty;
            this.txtFacturaABONO.Text = string.Empty;
            this.txtNumProgramacionAbono.Text = string.Empty;
            this.txtIdDetalleProgramacionAbono.Text = string.Empty;
            this.txtCursoAbono.Text = string.Empty;
            this.txtDiasAbono.Text = string.Empty;
            this.txtHorariosAbono.Text = string.Empty;
            this.txtConceptoAbono.Text = string.Empty;
            this.txtTasaCambioAbono.Text = string.Empty;
            this.txtmontototalAbonar.Text = string.Empty;
            this.txtMontoTotalAbonadoCordobas.Text = string.Empty;
            this.txtProximoSaldo.Text = string.Empty;
        }



        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button17_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


      
        private void button20_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedTab = TabFacturacion;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarABONOS(string IdDetalleProgramacion)
        {
            try
            {
                CN_Abonos objetoCN = new CN_Abonos();
                this.dataAbonos.DataSource = objetoCN.Mostrar(IdDetalleProgramacion);
            }
            catch (Exception)
            {
                MessageBox.Show("");
            }
        }

        private void dataEstudiantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (this.dataEstudiantes.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                    string Nombres = this.dataEstudiantes.CurrentRow.Cells["Nombres"].Value.ToString();
                    string Apellidos = this.dataEstudiantes.CurrentRow.Cells["Apellidos"].Value.ToString();
                    string Cedula = this.dataEstudiantes.CurrentRow.Cells["Cedula"].Value.ToString();
                    string Carnet = this.dataEstudiantes.CurrentRow.Cells["Carnet Estudiantil"].Value.ToString();
                    string CodMat = this.dataEstudiantes.CurrentRow.Cells["Cod_Matricula"].Value.ToString();
                    this.DatosEstudiante(Nombres, Apellidos, Cedula, Carnet, CodMat);

                    this.tabControl1.SelectedTab = TabMensualidades;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DatosEstudiante(string NombreEst, string ApellidosEst, string CedulaEst, string CarnetEst, string CodMatricula)
        {
            this.txtNombreEstudiante.Text = NombreEst;
            this.txtApellidosEstudiante.Text = ApellidosEst;
            this.txtCedulaEstudiante.Text = CedulaEst;
            this.txtCodEstudiante.Text = CarnetEst;

            this.txtBusquedaEstudiante.Text = CarnetEst;
            this.txtestudiante.Text = NombreEst + " " + ApellidosEst;
            this.txtcodigocarnet.Text = CarnetEst;
            this.txtNombreFactura.Text = NombreEst + " " + ApellidosEst;
            this.txtCedulaRuc.Text = CarnetEst;
            this.txtCedulaPago.Text = CarnetEst;

            this.Nombres = NombreEst;
            this.Apellidos = ApellidosEst;
            this.Cedula = CedulaEst;
            this.Carnet = CarnetEst;

            CN_Matriculas objetoCN = new CN_Matriculas();
            DataTable tabla = new DataTable();

            tabla = objetoCN.MostrarNumprogramacion(CodMatricula);
            if (tabla.Rows.Count == 0)
            {
                this.txtNumProgramacionEstudiante.Text = "";
                this.txtCodMatEstudiante.Text = "";
            }
            else
            {
                this.txtNumProgramacionEstudiante.Text = tabla.Rows[0][0].ToString();
                NumProgramacion_ = tabla.Rows[0][0].ToString();
                this.txtCodMatEstudiante.Text = tabla.Rows[0][1].ToString();


                this.MostrarDetallePago(NumProgramacion_);


            }

            CN_Matriculas objetoMatriculas = new CN_Matriculas();
            DataTable tabla2 = new DataTable();
            tabla2 = objetoMatriculas.ObtenerCursoMatricula(CodMatricula);
            if (tabla2.Rows.Count == 0)
            {
                this.txtNombreCursoEstudiante.Text = "";
                this.txtTurnoEstudiante.Text = "";
                this.txtHorarioEstudiante.Text = "";
            }
            else
            {
                this.txtNombreCursoEstudiante.Text = tabla2.Rows[0][0].ToString();
                this.txtTurnoEstudiante.Text = tabla2.Rows[0][1].ToString();
                this.txtHorarioEstudiante.Text = tabla2.Rows[0][2].ToString();

                this.CargarInformacionCurso(CodMatricula, this.txtNombreCursoEstudiante.Text, this.txtTurnoEstudiante.Text, this.txtHorarioEstudiante.Text);
            }


        }


        private void ObtenerPrimerDetalleProgramacion(string NumProgramacion)
        {
            try
            {
                CN_Detalle_Programacion objetoCN = new CN_Detalle_Programacion();
                DataTable tabla = new DataTable();
                tabla = objetoCN.ObtenerPrimerDetalleProgramacion(NumProgramacion);
                if (tabla.Rows.Count != 0)
                {
                    PrimerIdDetalleProgramacion = tabla.Rows[0][0].ToString();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button18_Click_2(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedTab = TabFacturacion;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarAbono_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Verificar si el monto a abonar está vacío
                if (string.IsNullOrEmpty(this.txtmontototalAbonar.Text))
                {
                    MessageBox.Show("No se ha Agregado el Monto a Abonar", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Salir del método
                }

                double saldoPendiente = Convert.ToDouble(this.txtProximoSaldo.Text);
                double montoAbonoCordobas = Convert.ToDouble(this.txtMontoTotalAbonadoCordobas.Text);

                // Verificar si el saldo pendiente es negativo
                if (saldoPendiente < 0)
                {
                    MessageBox.Show("Error: El saldo no puede ser negativo", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método
                }

                CN_Abonos objetoCN = new CN_Abonos();
                string fechaActualAbono = DateTime.Now.ToShortDateString();
                DateTime fechaActual = DateTime.ParseExact(fechaActualAbono, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                // Lógica para abono o cancelación de mensualidad
                if (saldoPendiente > 0)
                {
                    // Verificamos si queda un saldo el pago queda como Abono

                    AgregarFilaDetalleFactura("12","1","1", this.txtMontoTotalAbonadoCordobas.Text, "1", "5", this.txtMontoTotalAbonadoCordobas.Text, "ABONO A, " + this.txtConceptoAbono.Text,this.txtIdDetalleProgramacionAbono.Text);

                    
                }
                else // SaldoPendiente == 0
                {
                    AgregarFilaDetalleFactura("11", "1", "1", this.txtMontoTotalAbonadoCordobas.Text, "1", "5", this.txtMontoTotalAbonadoCordobas.Text, "CANCELACION A, " + this.txtConceptoAbono.Text, this.txtIdDetalleProgramacionAbono.Text);

                }

                CN_Factura objetoFactura = new CN_Factura();
                objetoFactura.ModificarEstadoEnProceso(this.txtIdDetalleProgramacionAbono.Text);

                // Actualizar detalles y UI
               
                this.calcularSubtotal();
                this.CalcularTotal(Convert.ToDouble(this.txtSubtotal.Text), 0, 0);
                this.tabControl1.SelectedTab = TabFacturacion;
                this.LimpiarControlesAbono();
                this.btnAgregarAbono.Enabled = false;
                this.Cargar_ComboMonedaAbono();
                this.MostrarDetallePago(NumProgramacion_);
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema: ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button9_Click_3(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedTab = TabFacturacion;
                this.LimpiarControlesAbono();
                this.btnAgregarAbono.Enabled = false;
                this.Cargar_ComboMonedaAbono();

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.TablaDetalleFactura.Rows.Count != 0)
                {
                    MessageBox.Show("Tienes aranceles por Cancelar, cierre esta ventana y vuelva a facturar", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.txtBusquedaEstudiante.Text = string.Empty;
                    this.txtestudiante.Text = string.Empty;
                    this.txtcodigocarnet.Text = string.Empty;
                    this.txtNombreFactura.Text = string.Empty;
                    this.txtCedulaRuc.Text = string.Empty;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbMonedaAbono_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cm = new SqlCommand("select  ValorMoneda from Tbl_TipoMoneda where IdMoneda = '" + this.cmbMonedaAbono.SelectedValue + "'", conexion.Conexion());
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read() == true)
                {
                    this.txtTasaCambioAbono.Text = dr["ValorMoneda"].ToString();

                }
                conexion.CerrarConexion();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click_4(object sender, EventArgs e)
        {
            try
            {
                this.RealizarCalculosAbonos();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void anularMoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.panel2.Enabled = true;
                this.panel2.Visible = true;
                this.tabControl2.SelectedTab = TabAnularMora;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtMotivoAnulacionMora.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese el Motivo", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }else if (this.txtMotivoAnulacionMora.Text != string.Empty)
                {
                    CodigoSolicitud = GenerarCodigo();
                    string fechaActual = DateTime.Now.ToLongDateString();

                    CN_Autorizaciones objetoCN = new CN_Autorizaciones();
                    objetoCN.Insertar(fechaActual,"ANULACION DE MORA DE:" + this.txtNombreEstudiante.Text + " MOTIVO: " +  this.txtMotivoAnulacionMora.Text,CodigoSolicitud,"NO",CacheUsuario.IdUsuario);
                    MessageBox.Show("Solicitud de Anulacion enviada", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSolicitudAnulacion.Enabled = false;                        
                    TipoAccion = "ANULACION_MORA";
                    timer1.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerarCodigo()
        {
            string Codigo = string.Empty;
            //creando una instancia de random
            Random aleatorio = new Random();
            Codigo = Convert.ToString(aleatorio.Next(99999, 999999));
            this.CodigoComparacion = Codigo;
            return Codigo;
        }

        private void ConsultarAnulacion()
        {
            try
            {
                CN_Autorizaciones objetoCN = new CN_Autorizaciones();
                DataTable tabla = new DataTable();
                tabla = objetoCN.ConsultarAutorizacion(CodigoSolicitud);
                if (tabla.Rows.Count != 0)
                {
                    string Autorizacion = tabla.Rows[0][0].ToString();
                    if (Autorizacion == "SI")
                    {
                        timer1.Stop();

                        CN_Detalle_Programacion objetoDetalle = new CN_Detalle_Programacion();
                        objetoDetalle.EliminarMora(this.txtIdDetalleProg_Anulacion.Text);
                        MessageBox.Show("Mora Anulada Correctamente","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        this.txtMotivoAnulacionMora.Text = string.Empty;
                        this.btnSolicitudAnulacion.Enabled = true;
                        this.panel2.Enabled = false;
                        this.panel2.Visible = false;

                        this.MostrarDetallePago(NumProgramacion_);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de sistema: ",
                       "SISTEMA CECNIC",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
            }
        }

        private void ConsultarAnulacionMatricula()
        {
            try
            {
                CN_Autorizaciones objetoCN = new CN_Autorizaciones();
                DataTable tabla = new DataTable();
                tabla = objetoCN.ConsultarAutorizacion(CodigoSolicitud);
                if (tabla.Rows.Count != 0)
                {
                    string Autorizacion = tabla.Rows[0][0].ToString();
                    if (Autorizacion == "SI")
                    {
                        timer1.Stop();
                        CN_FacturDetalle facturaDetalle = new CN_FacturDetalle();
                        facturaDetalle.Eliminar(this.txtNumeroFilaMatricula.Text);
                        MessageBox.Show("Matricula Anulada Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        TablaDetalleFactura.Rows.RemoveAt(Convert.ToInt32(txtNumeroFilaMatricula.Text));
                        calcularSubtotal();
                        CalcularTotal(Convert.ToDouble(txtSubtotal.Text), 0, 0);
                        MostrarDetallePago(txtNumProgramacionEstudiante.Text);
                        this.tabControl1.SelectedTab = TabFacturacion;

                        this.btnSolicitudAnulacionMatricula.Enabled = true;
                        this.txtMotivoAnulacionMatricula.Enabled = true;
                        this.txtMotivoAnulacionMatricula.Text = string.Empty;
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de sistema: ",
               "SISTEMA CECNIC",
               MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }


        private void ConsultarDescuentoMatricula()
        {
            try
            {
                CN_Autorizaciones objetoCN = new CN_Autorizaciones();
                DataTable tabla = new DataTable();
                tabla = objetoCN.ConsultarAutorizacion(CodigoSolicitud);
                if (tabla.Rows.Count != 0)
                {
                    string Autorizacion = tabla.Rows[0][0].ToString();
                    if (Autorizacion == "SI")
                    {
                        timer1.Stop();

                        int filaIndex = int.Parse(txtIdDetalleFct.Text);
                        TablaDetalleFactura.Rows[filaIndex].Cells["Monto"].Value = this.txtMatriculaConDescuento.Text;
                        TablaDetalleFactura.Rows[filaIndex].Cells["Total_en_Cordobas"].Value = this.txtMatriculaConDescuento.Text;

                        MessageBox.Show("Descuento Aplicado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);

                  
                        calcularSubtotal();
                        CalcularTotal(Convert.ToDouble(txtSubtotal.Text), 0, 0);
                        MostrarDetallePago(txtNumProgramacionEstudiante.Text);
                        this.tabControl1.SelectedTab = TabFacturacion;
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de sistema: ",
               "SISTEMA CECNIC",
               MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }


        private void ConsultarModificacionMensualidad()
        {
            try
            {
                CN_Autorizaciones objetoCN = new CN_Autorizaciones();
                DataTable tabla = new DataTable();
                tabla = objetoCN.ConsultarAutorizacion(CodigoSolicitud);
                if (tabla.Rows.Count != 0)
                {
                    string Autorizacion = tabla.Rows[0][0].ToString();
                    if (Autorizacion == "SI")
                    {
                        timer1.Stop();
                        CN_Detalle_Programacion ObjetoCN2 = new CN_Detalle_Programacion();
                        ObjetoCN2.ModificarMensualidad(this.txtIdDetalleMensualidad.Text,this.txtNuevoMonto.Text);

                        MessageBox.Show("Mensualidad Modificada Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        
                        calcularSubtotal();
                        CalcularTotal(Convert.ToDouble(txtSubtotal.Text), 0, 0);
                        MostrarDetallePago(txtNumProgramacionEstudiante.Text);
                        this.tabControl2.Visible = false;
                        this.tabControl2.Enabled = false;
                     
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de sistema: ",
               "SISTEMA CECNIC",
               MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtMotivoAnulacionMatricula.Text == string.Empty)
                {
                    MessageBox.Show("Ingresa el Motivo de la Anulacion", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }else if (this.txtMotivoAnulacionMatricula.Text != string.Empty)
                {
                    this.CodigoSolicitud = string.Empty;
                    CodigoSolicitud = GenerarCodigo();
                    string fechaActual = DateTime.Now.ToLongDateString();

                    CN_Autorizaciones objetoCN = new CN_Autorizaciones();
                    objetoCN.Insertar(fechaActual,"ANULACION MATRICULA " + " MOTIVO: " +  this.txtMotivoAnulacionMora.Text, CodigoSolicitud, "NO", CacheUsuario.IdUsuario);
                    MessageBox.Show("Solicitud de Anulacion enviada", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.btnSolicitudAnulacionMatricula.Enabled = false;
                    this.txtMotivoAnulacionMatricula.Enabled = false;
                    TipoAccion = "ANULACION_MATRICULA";
                    timer1.Start();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de sistema: ",
                  "SISTEMA CECNIC",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                string estado = this.txtestado.Text;

                switch (estado)
                {
                    case "En proceso":
                        MessageBox.Show("Ya seleccionado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return; // Salir si el estado es "En proceso"

                    case "Completado":
                        MessageBox.Show("Mensualidad ya Pagada", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Salir si el estado es "Completado"
                }

                // Variables para realizar el abono
                string saldoAnt = this.txttotalAbonado.Text;
                string factTemp = this.txtMensualidadFactura.Text;
                string nombCurso = this.txtNombre_Curso.Text;
                string diasCurso = this.txtDia.Text;
                string horarioCurso = this.txtHorario_.Text;
                string subtotalAbono = this.txtSubtotalCordobas_.Text;
                string concepto = this.txtConcepto.Text;
                string numProgramacionAbono = NumProgramacion_;
                string idDetalleProgramacionAbono = this.Id_Detalle_Programacion_;

                // Realizar el abono
                this.RealizarAbono(saldoAnt, factTemp, nombCurso, diasCurso, horarioCurso, subtotalAbono, concepto, numProgramacionAbono, idDetalleProgramacionAbono);

                // Cambiar a la pestaña correspondiente
                this.tabControl1.SelectedTab = TabAbonos;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema: ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

  

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedTab = TabFacturacion;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                this.panel8.Enabled = true;
                this.panel14.Enabled = true;
                this.txtMatriculaConDescuento.Enabled = false;
                this.panel18.Enabled = false;
                this.textBox1.Text = string.Empty;
                this.txtMatriculaConDescuento.Text = string.Empty;
                this.cmbDescuentos.Text = "Seleccione";
                BuscarMatricula();
               
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void BuscarMatricula()
        {
            try
            {
                foreach (DataGridViewRow row in TablaDetalleFactura.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string idArancel = row.Cells["Id_Arancel"].Value?.ToString();
                        if (idArancel == "8" || idArancel == "20")
                        {
                            txtIdDetalleFct.Text = row.Index.ToString();
                            this.txtMontoMatricula.Text = row.Cells["Monto"].Value?.ToString();
                            this.tabControl1.SelectedTab = TabDescuentoMatricula;
                            return;
                        }
                    }
                }

                MessageBox.Show("Debe ingresar la matrícula para continuar.",
                    "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema",
                    "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button10_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.txtMatriculaConDescuento.Text = string.Empty;

                if (this.cmbDescuentos.Text == "Seleccione")
                {
                    MessageBox.Show("Seleccione el descuento", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (this.cmbDescuentos.Text == "Descuento de 5%")
                {
                    this.txtMatriculaConDescuento.Text = CalcularDescuento(Convert.ToDecimal(this.txtMontoMatricula.Text), Convert.ToDecimal(5)).ToString();
                }
                else if (this.cmbDescuentos.Text == "Descuento de 10%")
                {
                    this.txtMatriculaConDescuento.Text = CalcularDescuento(Convert.ToDecimal(this.txtMontoMatricula.Text), Convert.ToDecimal(10)).ToString();

                }
                else if (this.cmbDescuentos.Text == "Descuento de 25%")
                {
                    this.txtMatriculaConDescuento.Text = CalcularDescuento(Convert.ToDecimal(this.txtMontoMatricula.Text), Convert.ToDecimal(25)).ToString();
                }
                else if (this.cmbDescuentos.Text == "Descuento de 50%")
                {
                    this.txtMatriculaConDescuento.Text = CalcularDescuento(Convert.ToDecimal(this.txtMontoMatricula.Text), Convert.ToDecimal(50)).ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private decimal CalcularDescuento(decimal valor, decimal porcentaje)
        {
            return  valor - ( valor * (porcentaje / 100));
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                int MontoDescuento = Convert.ToInt32(this.textBox1.Text);
                int MontoMatricula = Convert.ToInt32(this.txtMontoMatricula.Text);


                if (MontoDescuento < 0)
                {
                    MessageBox.Show("No se admiten valores Negativos", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }else if (MontoDescuento > MontoMatricula)
                {
                    MessageBox.Show("Descuento es Mayor que la Matricula", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }else if (MontoDescuento > 0 && MontoDescuento < MontoMatricula)
                {
                    this.txtMatriculaConDescuento.Text = string.Empty;
                    this.txtMatriculaConDescuento.Text = Convert.ToString(MontoMatricula - MontoDescuento);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite dígitos y teclas de control (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignora la tecla
            }
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.panel8.Enabled = false;
                this.panel14.Enabled = false;
                this.txtMatriculaConDescuento.Enabled = false;
                this.panel18.Enabled = true;
                this.txtMotivoDescuentoMatricula.Enabled = true;
                


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtMotivoDescuentoMatricula.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese el Motivo del Descuento", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }else
                {
                    CodigoSolicitud = GenerarCodigo();
                    string fechaActual = DateTime.Now.ToLongDateString();

                    CN_Autorizaciones objetoCN = new CN_Autorizaciones();
                    objetoCN.Insertar(fechaActual, "DESCUENTO DE MATRICULA: MOTIVO: " + this.txtMotivoDescuentoMatricula.Text, CodigoSolicitud, "NO", CacheUsuario.IdUsuario);
                    MessageBox.Show(
                        "La solicitud de descuento ha sido enviada correctamente.",
                        "SISTEMA CECNIC",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.panel18.Enabled = false;

                    TipoAccion = "DESCUENTO_MATRICULA";
                    timer1.Start();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNuevoMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite dígitos y teclas de control (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignora la tecla
            }
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (this.txtNuevoMonto.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese el Monto", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }else if (this.txtMotivoModificacionMensualidad.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese el Motivo de la Modificacion", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }else
                {
                    CodigoSolicitud = GenerarCodigo();
                    string fechaActual = DateTime.Now.ToLongDateString();

                    CN_Autorizaciones objetoCN = new CN_Autorizaciones();
                    objetoCN.Insertar(fechaActual, "MODIFICACION DE MENSUALIDAD DE:" + this.txtNombreEstudiante.Text + " MOTIVO: " + this.txtMotivoModificacionMensualidad.Text, CodigoSolicitud, "NO", CacheUsuario.IdUsuario);
                    MessageBox.Show("Solicitud de Modificacion enviada", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.txtNuevoMonto.Enabled = false;
                    this.txtMotivoModificacionMensualidad.Enabled = false;
                    this.panel2.Enabled = false;

                    TipoAccion = "MODIFICACION_MENSUALIDAD";
                    timer1.Start();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " +  ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarMensualidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel2.Enabled = true;
            this.panel2.Visible = true;
            this.tabControl2.SelectedTab = TabModificacionMensualidad;
        }

        private void TablaDetalleFactura_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == TablaDetalleFactura.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Cargar el ícono desde recursos (recomendado) o archivo
                Bitmap icon = Properties.Resources.delete; // Usa tu recurso de imagen
                int iconWidth = 16;
                int iconHeight = 16;

                // Posición centrada en la celda
                int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                e.Graphics.DrawImage(icon, new Rectangle(x, y, iconWidth, iconHeight));
                e.Handled = true; // Indica que la celda está completamente pintada
            }

        }

        private void dataMensualidadesEstudiante_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Verificar que el clic fue en una fila válida y en la columna "Seleccionar"
                if (e.RowIndex >= 0 && dataMensualidadesEstudiante.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                    string IDDETALLEPROGRAMACION = this.dataMensualidadesEstudiante.CurrentRow.Cells["Id_Detalle_Programacion"].Value.ToString();
                    this.txtIDDETALLEPROGRAMACION.Text = IDDETALLEPROGRAMACION;
                    this.txtIdDetalleProg_Anulacion.Text = IDDETALLEPROGRAMACION.ToString();
                    this.txtIdDetalleMensualidad.Text = IDDETALLEPROGRAMACION.ToString();
                    int currentRowIndex = e.RowIndex;

                    // Obtener estado de la fila actual (manejo seguro con null)
                    string estadoFilaActual = dataMensualidadesEstudiante.Rows[currentRowIndex].Cells["Estado"].Value?.ToString() ?? "";

                    // Verificamos el estado de la fila actual
                    if (estadoFilaActual.Equals("Completado", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Mensualidad ya cancelada", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (estadoFilaActual.Equals("En proceso", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Mensualidad en proceso", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Fecha de la fila seleccionada
                    DateTime fechaSeleccionada = Convert.ToDateTime(
                        dataMensualidadesEstudiante.CurrentRow.Cells["Fecha_Vencimiento"].Value
                    );

                    int cantidadPendientesAnteriores = 0;

                    foreach (DataGridViewRow fila in dataMensualidadesEstudiante.Rows)
                    {
                        if (fila.IsNewRow) continue;

                        DateTime fechaFila = Convert.ToDateTime(
                            fila.Cells["Fecha_Vencimiento"].Value
                        );

                        string estadoFila = fila.Cells["Estado"].Value.ToString();

                        // Solo fechas anteriores
                        if (fechaFila < fechaSeleccionada && estadoFila == "Pendiente")
                        {
                            cantidadPendientesAnteriores++;
                        }
                    }


                    if (cantidadPendientesAnteriores > 0)
                    {
                        MessageBox.Show(
                            $"No puede seleccionar esta mensualidad.\n" +
                            $"Existen {cantidadPendientesAnteriores} mensualidad(es) anterior(es) pendientes.",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                   
                     ProcesarFilaSeleccionada(currentRowIndex);
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"Ocurrió un error", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TablaDetalleFactura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Evitar clic en encabezado
                {
                    if (e.ColumnIndex == TablaDetalleFactura.Columns["Eliminar"].Index)
                    {
                        //Variables
                        string idArancel = TablaDetalleFactura.Rows[e.RowIndex].Cells["Id_Arancel"].Value?.ToString();
                        string IdDetalleProgramacion = TablaDetalleFactura.Rows[e.RowIndex].Cells["Id_Detalle_Programacion"].Value?.ToString();
                        rowIndex = e.RowIndex;
                        CN_Factura objetoCN = new CN_Factura();

                        if (idArancel == "11" || idArancel == "12" )
                        {
                            //Eliminar Mensualidad o Abono
                            objetoCN.ModificarEstadoaPendiente(IdDetalleProgramacion);
                            TablaDetalleFactura.Rows.RemoveAt(e.RowIndex);
                            this.MostrarDetallePago(NumProgramacion_);
                        }
                        else if (idArancel == "8" || idArancel == "20")
                        {
                            //Anular Matricula Recepcion o Relaciones Publicas
                            this.txtNumeroFilaMatricula.Text = rowIndex.ToString();
                            this.btnSolicitudAnulacionMatricula.Enabled = true;
                            this.txtMotivoAnulacionMatricula.Enabled = true;
                            this.tabControl1.SelectedTab = TabAnulacionMatricula;
                     
                        }else
                        {
                            TablaDetalleFactura.Rows.RemoveAt(e.RowIndex);
                        }

                        this.MostrarDetallePago(NumProgramacion_);
                        calcularSubtotal();
                        this.CalcularTotal(Convert.ToDouble(this.txtSubtotal.Text), 0, 0);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema: ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void RealizarAbono(string SaldoAnterior, string FacturaTemporal, string NombreCurso, string DiasCurso, string HorarioCurso, string SubtotalAbono, string Concepto, string NumProgramacion, string IdDetalleProgramacion)
        {
            this.txtTotalAbonos.Text = SaldoAnterior;
            this.txtFacturaABONO.Text = FacturaTemporal;
            this.txtCursoAbono.Text = NombreCurso;
            this.txtDiasAbono.Text = DiasCurso;
            this.txtHorariosAbono.Text = HorarioCurso;
            this.txtSubtotalAbono.Text = SubtotalAbono;
            this.txtConceptoAbono.Text = Concepto;
            this.txtNumProgramacionAbono.Text = NumProgramacion;
            this.txtIdDetalleProgramacionAbono.Text = IdDetalleProgramacion;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (TipoAccion == "ANULACION_MORA")
                {
                    ConsultarAnulacion();
                }else if(TipoAccion == "ANULACION_MATRICULA")
                {
                    ConsultarAnulacionMatricula();
                }else if (TipoAccion == "DESCUENTO_MATRICULA")
                {
                    ConsultarDescuentoMatricula();
                }else if (TipoAccion == "MODIFICACION_MENSUALIDAD")
                {
                    ConsultarModificacionMensualidad();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void modificarMontoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel2.Enabled = true;
            this.panel2.Visible = true;
            this.tabControl2.SelectedIndex = 1;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
             fechaMasRecienteGlobal = dataMensualidadesEstudiante.Rows
             .Cast<DataGridViewRow>()
             .Where(row => row.Cells["Fecha_Vencimiento"].Value != null)
             .Select(row => Convert.ToDateTime(row.Cells["Fecha_Vencimiento"].Value))
             .Max();

                int ContadorCompletados = 0;
                int TotalRegistros = dataMensualidadesEstudiante.Rows.Count;
                

                foreach (DataGridViewRow row in dataMensualidadesEstudiante.Rows)
                {
                    if (row.Cells["Estado"].Value.ToString() == "Completado")
                    {
                        ContadorCompletados = ContadorCompletados + 1;
                    }
                }

                if (TotalRegistros == ContadorCompletados)
                {
                    this.txtNombresMensualidad.Text = this.txtNombreEstudiante.Text;
                    this.txtApellidoMensualidad.Text = this.txtApellidosEstudiante.Text;
                    this.txtNProgramacionMensualidad.Text = this.txtNumProgramacionEstudiante.Text;
                    this.txtCodMatMensualidad.Text = this.txtCodMatEstudiante.Text;

                    this.tabControl1.SelectedTab = TabNuevaMensualidad;
                    this.ObtenerelDiaDeVencimiento();


                }
                else if (TotalRegistros != ContadorCompletados)
                {
                    MessageBox.Show("Para poder agregar un Nuevo Pago, todos los anteriores deben de estar Completados", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error de sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ObtenerelDiaDeVencimiento()
        {
            try
            {
                if (dataMensualidadesEstudiante.Rows.Count > 0)
                {
                    // Última fila
                    var ultimaFila = dataMensualidadesEstudiante.Rows[dataMensualidadesEstudiante.Rows.Count - 1];

                    // Validar que no sea una fila "nueva" del DataGridView
                    if (!ultimaFila.IsNewRow)
                    {
                        // Extraer valores con null-check
                        string fechaStr = ultimaFila.Cells["Fecha_Vencimiento"]?.Value?.ToString();
                        string montoStr = ultimaFila.Cells["Monto"]?.Value?.ToString();
                        string descripcionStr = ultimaFila.Cells["Descripcion"]?.Value?.ToString();

                        // Asignar monto y descripción
                        this.txtMontoMensualidad.Text = montoStr ?? string.Empty;
                        this.cmbTipoMonedaMensualidad.Text = descripcionStr ?? string.Empty;

                        // Intentar convertir la fecha
                        if (DateTime.TryParse(fechaStr, out DateTime fecha))
                        {
                            DiaVencimientoMensualidad = fecha.Day; // Solo el día
                        }
                        else
                        {
                            MessageBox.Show("La fecha de vencimiento no es válida.",
                                "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema",
                    "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button26_Click(object sender, EventArgs e)
        {
            try
            {


                

                int numeroMes = DateTime.ParseExact(cmbmes.Text, "MMMM", new System.Globalization.CultureInfo("es-ES")).Month;
                fechaVencimientoMensualidad = new DateTime(int.Parse(cmbaño.Text), numeroMes, int.Parse(DiaVencimientoMensualidad.ToString()));

                if (fechaVencimientoMensualidad <= fechaMasRecienteGlobal)
                {
                    MessageBox.Show("ya esta mensualidad se encuentra cancelada", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtConceptoMensualidad.Text = string.Empty;
                } else if (fechaVencimientoMensualidad > fechaMasRecienteGlobal)
                {
                    this.txtConceptoMensualidad.Text = "MENSUALIDAD, " + cmbmes.Text + " " + cmbaño.Text;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarMensualidad_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtConceptoMensualidad.Text = string.Empty;
                this.txtMontoMensualidad.Text = string.Empty;
                this.tabControl1.SelectedTab = TabMensualidades;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptarMensualidad_Click(object sender, EventArgs e)
        {
            try
            {
                // VALIDACIONES
                if (cmbTipoMonedaMensualidad.Text == "Selecciona una Moneda")
                {
                    MessageBox.Show("Selecciona una Moneda", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMontoMensualidad.Text))
                {
                    MessageBox.Show("El monto no puede estar vacío", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMontoMensualidad.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtConceptoMensualidad.Text))
                {
                    MessageBox.Show("Selecciona el mes y año a cancelar", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConceptoMensualidad.Focus();
                    return;
                }

                // PROCESO DE INSERCIÓN
                CN_Detalle_Programacion objetoCN = new CN_Detalle_Programacion();

                string numeroProgramacion = txtNProgramacionMensualidad.Text;
                string fechaVencimiento = fechaVencimientoMensualidad.ToShortDateString();
                string concepto = txtConceptoMensualidad.Text;
                string monto = txtMontoMensualidad.Text;
                string tipoMoneda = cmbTipoMonedaMensualidad.SelectedValue.ToString();

                objetoCN.Insertar(
                    numeroProgramacion,
                    fechaVencimiento,
                    concepto,
                    monto,
                    tipoMoneda,
                    fechaVencimiento,
                    "0",
                    "10"
                );

                // ACTUALIZAR INTERFAZ
                MostrarDetallePago(txtNumProgramacionEstudiante.Text);

                MessageBox.Show("Mensualidad agregada correctamente",
                                "SISTEMA CECNIC",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                tabControl1.SelectedTab = TabMensualidades;
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato de datos incorrecto. Verifique el monto ingresado.",
                                "SISTEMA CECNIC",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema: " + ex.Message,
                                "SISTEMA CECNIC",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }

        private void txtMontoMensualidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números (0-9), el carácter de punto (.) y la tecla de retroceso (Backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b')
            {
                e.Handled = true; // Cancela el evento si no es un carácter válido
            }

            // Evitar más de un punto decimal
            if (e.KeyChar == '.' && ((sender as TextBox).Text.Contains(".")))
            {
                e.Handled = true;
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                CacheDatos.NumeroDeProgramacionAbono = this.txtNumProgramacionEstudiante.Text;
                Frm_SolicitudArreglo frm = new Frm_SolicitudArreglo();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void SumaAbonado()
        {
            try
            {
                double subtotal = 0;

                // Calcular el monto total abonado solo en mensualidades "Completado"
                foreach (DataGridViewRow row in dataAbonos.Rows)
                {
                    if (row.IsNewRow) continue; // Ignorar fila nueva vacía del DataGridView

                    string estado = row.Cells["Estado"]?.Value?.ToString();
                    string montoStr = row.Cells["Monto"]?.Value?.ToString();

                    if (estado == "Completado" && double.TryParse(montoStr, out double monto))
                    {
                        subtotal += monto;
                    }
                }

                // Mostrar subtotal en textbox con 2 decimales
                txttotalAbonado.Text = subtotal.ToString("F2");

                // Validar conversiones antes de calcular saldo pendiente
                bool montoOk = double.TryParse(Monto_, out double montoOriginal);
                bool tasaOk = double.TryParse(TasaCambio_, out double tasaCambio);
                bool moraOk = double.TryParse(Mora_, out double mora);

                if (montoOk && tasaOk && moraOk)
                {
                    double saldoPendiente = (montoOriginal * tasaCambio) - subtotal + mora;
                    txtsaldoPendiente.Text = saldoPendiente.ToString("F2");
                }
                else
                {
                    MessageBox.Show("Error al convertir los valores de Monto, Tasa de Cambio o Mora.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error en cálculo de abonos",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BorrarDatosCurso()
        {
            CacheDetalleProgramacion.NombreCurso = string.Empty;
            CacheDetalleProgramacion.Dias = string.Empty;
            CacheDetalleProgramacion.Horario = string.Empty;
        }

        
        private void Mostrar()
        {
            CN_Personas objeto = new CN_Personas();
            //this.dataPersonas.DataSource = objeto.BuscarPorApellidos(this.txtbuscar.Text);
        }

      
        private void AgregarBtnDatagridViewEstudiantes()
        {
            dataEstudiantes.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Seleccionar",
                Name = "Seleccionar",
                Text = "Seleccionar",
                UseColumnTextForButtonValue = true

            });

            DataGridViewColumn columna = dataEstudiantes.Columns["Seleccionar"];

            // Establece el ancho deseado para la columna (en píxeles)
            columna.Width = 70;
        }


        private void AgregarColumnaConIcono()
        {
            try
            {
                // Agregar columna de botón
                DataGridViewButtonColumn btnColumna = new DataGridViewButtonColumn();
                btnColumna.HeaderText = "Eliminar";
                btnColumna.Name = "Eliminar";
                btnColumna.Text = ""; // El texto no se usará porque dibujaremos un ícono
                btnColumna.UseColumnTextForButtonValue = false;
                TablaDetalleFactura.Columns.Add(btnColumna);
                

                // Evento para pintar el botón con un ícono
                TablaDetalleFactura.CellPainting += TablaDetalleFactura_CellPainting;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarColumnasFacturaDetalles()
        {
            try
            {


                this.TablaDetalleFactura.Columns.Add("Observaciones", "Observaciones");
                this.TablaDetalleFactura.Columns.Add("Cantidad", "Cantidad");
                this.TablaDetalleFactura.Columns.Add("Total_en_Cordobas", "Total_en_Cordobas");
                this.TablaDetalleFactura.Columns.Add("Id_estado", "Id_estado");
                this.TablaDetalleFactura.Columns.Add("IdMoneda", "IdMoneda");
                this.TablaDetalleFactura.Columns.Add("Id_Arancel", "Id_Arancel");
                this.TablaDetalleFactura.Columns.Add("Valor_Moneda", "Valor_Moneda");
                this.TablaDetalleFactura.Columns.Add("Monto", "Monto");
                this.TablaDetalleFactura.Columns.Add("Id_Detalle_Programacion", "Id_Detalle_Programacion");


                this.TablaDetalleFactura.Columns["Id_estado"].Visible = false;
                this.TablaDetalleFactura.Columns["IdMoneda"].Visible = false;
                this.TablaDetalleFactura.Columns["Id_Arancel"].Visible = false;
                this.TablaDetalleFactura.Columns["Valor_Moneda"].Visible = false;
                this.TablaDetalleFactura.Columns["Monto"].Visible = false;
                this.TablaDetalleFactura.Columns["Id_Detalle_Programacion"].Visible = false;


        

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
