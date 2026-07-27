using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.Diagnostics;
using System.Drawing.Text;
using System.Windows.Forms;
using Utils;
using ZXing;
using ZXing.Common;
using System.Windows.Forms.DataVisualization.Charting;
using QRCoder;
using System.IO;
using System.Linq;


namespace CaoaPresentacion
{
    public partial class Frm_BusquedaEstudiantes : Form
    {
        string Estado;
        CN_VistaUniverso objetoCN = new CN_VistaUniverso();
        string FechaActual = DateTime.Now.ToShortDateString();
        CN_Reingreso objetoCN1 = new CN_Reingreso();

        CD_Conexion conexion = new CD_Conexion();
        DataTable tabla = new DataTable();
        DataTable tablaFactura = new DataTable();
        DataTable tablaDetalle = new DataTable();
        string IdMatriculaHistorial;

        private PrintDocument documentoCarnet;
        private Bitmap imagenCarnetImprimir;


        public Frm_BusquedaEstudiantes()
        {

            InitializeComponent();

            try
            {
                this.Cargar_Cursos();
                this.Cargar_Estados();

                this.cmbTurnos.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cmbBusquedas.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cmbEstados.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cmbConceptoBaja.DropDownStyle = ComboBoxStyle.DropDownList;
                DataGridViewConfigurator.Configure(this.dataEstudiantes, this.dataGrupos);


                // Configurar controles de búsqueda
                SetupSearchControls();



                // Configurar el estado del combo box
                cmbEstados.Text = "Activo";

                documentoCarnet = new PrintDocument();

                documentoCarnet.PrintPage += DocumentoCarnet_PrintPage;
                documentoCarnet.EndPrint += DocumentoCarnet_EndPrint;

            }
            catch (Exception)
            {
                // Manejo de excepciones con un mensaje más claro
                MessageBox.Show($"Ocurrió un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        

        private void SetupSearchControls()
        {
            // Configurar controles de búsqueda
            radioButton2.Checked = true; // Puedes considerar si este valor por defecto es necesario
            cmbBusquedas.Text = "CARNET";
            radioButton1.Checked = true; // Igual aquí, verifica si es necesario
        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.Estado = "3";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.Estado = "4";
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void MostrarMatriculas()
        {
            try
            {
                CN_Matriculas objetoCN = new CN_Matriculas();
                dataEstudiantes.DataSource = objetoCN.MostrarMatriculas(this.txtbusqueda.Text, Convert.ToInt32(Estado), cmbBusquedas.Text);
                OcultarColumnas();
                ContarFilas();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK);
            }
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

        private void Frm_BusquedaEstudiantes_Load(object sender, EventArgs e)
        {
          
            string TipoUsuario = CacheUsuario.TipoUsuario;



            // Agregar botones a DataGridView
            this.AgregarColumnaConIcono();
            AgregarBtnDatagridViewGrupos();
            this.radioButton1.Checked = true;

            this.BuscarPorFecha();
            this.OcultarColumnas();

            ContarFilas();
            this.cmbConceptoBaja.Text = "BAJA";


            this.tabControl1.SelectedTab = TabUniverso; ;
        }

        private void ContarFilas()
        {
            this.lbltotal.Text = Convert.ToString(this.dataEstudiantes.Rows.Count);
        }


        private void button7_Click_1(object sender, EventArgs e)
        {
            try
            {

                this.BuscarPorFecha();

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void BuscarPorFecha()
        {
            try
            {
                CN_Matriculas objetoCN = new CN_Matriculas();

                DateTime fechaInicial = dateTimePicker1.Value.Date;
                DateTime fechaFinal = dateTimePicker2.Value.Date;

                if (fechaInicial > fechaFinal)
                {
                    MessageBox.Show(
                        "La fecha inicial no puede ser mayor que la fecha final.",
                        "SISTEMA CECNIC",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    dateTimePicker1.Focus();
                    return;
                }

                this.dataEstudiantes.DataSource =
                    objetoCN.MostrarMatriculasPorFecha(
                        fechaInicial,
                        fechaFinal,
                        Convert.ToInt32(Estado));

                this.OcultarColumnas();
                ContarFilas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al consultar las matrículas por fecha.\n\n" +
                    "Detalle: " + ex.Message,
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void AgregarColumnaConIcono()
        {
            try
            {
                // Movimientos
                DataGridViewButtonColumn btnColumna = new DataGridViewButtonColumn();
                btnColumna.HeaderText = "Movimientos";
                btnColumna.Name = "Movimientos";
                btnColumna.UseColumnTextForButtonValue = false;
                btnColumna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                btnColumna.Width = 70; // 👈 ancho fijo
                dataEstudiantes.Columns.Add(btnColumna);

                // Detalle Matrícula
                DataGridViewButtonColumn btnColumna2 = new DataGridViewButtonColumn();
                btnColumna2.HeaderText = "Detalle Matrícula";
                btnColumna2.Name = "Detalle";
                btnColumna2.UseColumnTextForButtonValue = false;
                btnColumna2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                btnColumna2.Width = 60;
                dataEstudiantes.Columns.Add(btnColumna2);

                // Actualizar Grupo
                DataGridViewButtonColumn btnColumna3 = new DataGridViewButtonColumn();
                btnColumna3.HeaderText = "Actualizar Grupo";
                btnColumna3.Name = "Actualizar";
                btnColumna3.UseColumnTextForButtonValue = false;
                btnColumna3.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                btnColumna3.Width = 60;
                dataEstudiantes.Columns.Add(btnColumna3);

                DataGridViewButtonColumn btnColumna4 = new DataGridViewButtonColumn();
                btnColumna4.HeaderText = "Cambiar Estado";
                btnColumna4.Name = "Cambiar";
                btnColumna4.UseColumnTextForButtonValue = false;
                btnColumna4.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                btnColumna4.Width = 60;
                dataEstudiantes.Columns.Add(btnColumna4);

                // Evento para dibujar iconos
                dataEstudiantes.CellPainting += dataEstudiantes_CellPainting;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void RealizarImpresionExpediente(string CodigoMatricula)
        {
            CN_VistaUniverso objetoCN = new CN_VistaUniverso();

            tabla = objetoCN.GenerarExpediente(CodigoMatricula);
            tablaFactura = objetoCN.ObtenerFacturaInicio(CodigoMatricula);

            this.ImprimirReporte(tabla, tablaFactura);



        }


        private void ImprimirReporte(DataTable tabla, DataTable tabla2)
        {
            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDocument1;
                DialogResult result = printDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
        }





        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            // Mejora la calidad de impresión
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint =
                System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // =========================================================
            // FUENTES
            // =========================================================
            using (Font fuenteInstitucion =
                   new Font("Arial", 19, FontStyle.Bold))
            using (Font fuenteTitulo =
                   new Font("Arial", 12, FontStyle.Bold))
            using (Font fuenteSeccion =
                   new Font("Arial", 9, FontStyle.Bold))
            using (Font fuenteEtiqueta =
                   new Font("Arial", 8.5f, FontStyle.Bold))
            using (Font fuenteTexto =
                   new Font("Arial", 8.5f, FontStyle.Regular))
            using (Font fuenteObservacion =
                   new Font("Arial", 8.5f, FontStyle.Italic))
            using (Font fuentePie =
                   new Font("Arial", 7.5f, FontStyle.Italic))
            {
                // =====================================================
                // CONFIGURACIÓN GENERAL
                // =====================================================
                int margenX = 45;
                int anchoPagina = e.PageBounds.Width - (margenX * 2);
                int y = 35;

                Pen bordePrincipal = new Pen(Color.Black, 1.2f);
                Pen bordeSecundario = new Pen(Color.Black, 0.7f);
                Pen lineaDelgada = new Pen(Color.Black, 0.5f);

                StringFormat centrado = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                StringFormat izquierdaCentro = new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center,
                    Trimming = StringTrimming.EllipsisCharacter
                };

                // =====================================================
                // ENCABEZADO INSTITUCIONAL
                // =====================================================
                Rectangle encabezado = new Rectangle(
                    margenX,
                    y,
                    anchoPagina,
                    88);

                g.DrawRectangle(bordePrincipal, encabezado);

                // Línea decorativa superior
                g.FillRectangle(
                    Brushes.Black,
                    margenX,
                    y,
                    anchoPagina,
                    5);

                g.DrawString(
                    "CECNIC",
                    fuenteInstitucion,
                    Brushes.Black,
                    new Rectangle(
                        margenX,
                        y + 12,
                        anchoPagina,
                        30),
                    centrado);

                g.DrawString(
                    "CENTRO DE ESTUDIOS COMPUTARIZADOS NICARAGÜENSES",
                    fuenteSeccion,
                    Brushes.Black,
                    new Rectangle(
                        margenX,
                        y + 42,
                        anchoPagina,
                        18),
                    centrado);

                g.DrawLine(
                    bordeSecundario,
                    margenX + 120,
                    y + 63,
                    margenX + anchoPagina - 120,
                    y + 63);

                g.DrawString(
                    "EXPEDIENTE ESTUDIANTIL",
                    fuenteTitulo,
                    Brushes.Black,
                    new Rectangle(
                        margenX,
                        y + 64,
                        anchoPagina,
                        20),
                    centrado);

                y += 100;

                // =====================================================
                // NÚMERO DE MATRÍCULA Y ESTADO
                // =====================================================
                Rectangle barraIdentificacion = new Rectangle(
                    margenX,
                    y,
                    anchoPagina,
                    34);

                g.DrawRectangle(bordePrincipal, barraIdentificacion);

                int mitadBarra = anchoPagina / 2;

                g.DrawLine(
                    bordeSecundario,
                    margenX + mitadBarra,
                    y,
                    margenX + mitadBarra,
                    y + barraIdentificacion.Height);

                DibujarDatoHorizontal(
                    g,
                    "MATRÍCULA:",
                    tabla.Rows[0][1].ToString(),
                    fuenteEtiqueta,
                    fuenteTexto,
                    new Rectangle(
                        margenX + 10,
                        y + 1,
                        mitadBarra - 20,
                        32));

                DibujarDatoHorizontal(
                    g,
                    "ESTADO:",
                    tabla.Rows[0][16].ToString(),
                    fuenteEtiqueta,
                    fuenteTexto,
                    new Rectangle(
                        margenX + mitadBarra + 10,
                        y + 1,
                        mitadBarra - 20,
                        32));

                y += 46;

                // =====================================================
                // INFORMACIÓN DE REGISTRO
                // =====================================================
                y = DibujarTituloSeccion(
                    g,
                    "INFORMACIÓN DE REGISTRO",
                    margenX,
                    y,
                    anchoPagina,
                    fuenteSeccion);

                Rectangle detalleRegistro = new Rectangle(
                    margenX,
                    y,
                    anchoPagina,
                    76);

                g.DrawRectangle(bordeSecundario, detalleRegistro);

                int anchoColumna = anchoPagina / 2;

                g.DrawLine(
                    lineaDelgada,
                    margenX + anchoColumna,
                    y,
                    margenX + anchoColumna,
                    y + detalleRegistro.Height);

                g.DrawLine(
                    lineaDelgada,
                    margenX,
                    y + 38,
                    margenX + anchoPagina,
                    y + 38);

                DibujarCampo(
                    g,
                    "Código de matrícula",
                    tabla.Rows[0][1].ToString(),
                    fuenteEtiqueta,
                    fuenteTexto,
                    new Rectangle(
                        margenX + 8,
                        y + 3,
                        anchoColumna - 16,
                        32));

                DibujarCampo(
                    g,
                    "Fecha de inicio",
                    FormatearFecha(tabla.Rows[0][3]),
                    fuenteEtiqueta,
                    fuenteTexto,
                    new Rectangle(
                        margenX + anchoColumna + 8,
                        y + 3,
                        anchoColumna - 16,
                        32));

                DibujarCampo(
                    g,
                    "Matriculado por",
                    tabla.Rows[0][2].ToString(),
                    fuenteEtiqueta,
                    fuenteTexto,
                    new Rectangle(
                        margenX + 8,
                        y + 41,
                        anchoColumna - 16,
                        32));

                DibujarCampo(
                    g,
                    "Fecha de registro",
                    FormatearFecha(tabla.Rows[0][4]),
                    fuenteEtiqueta,
                    fuenteTexto,
                    new Rectangle(
                        margenX + anchoColumna + 8,
                        y + 41,
                        anchoColumna - 16,
                        32));

                y += 90;

                // =====================================================
                // DATOS DEL ESTUDIANTE
                // =====================================================
                y = DibujarTituloSeccion(
                    g,
                    "DATOS PERSONALES DEL ESTUDIANTE",
                    margenX,
                    y,
                    anchoPagina,
                    fuenteSeccion);

                Rectangle datosPersonales = new Rectangle(
                    margenX,
                    y,
                    anchoPagina,
                    118);

                g.DrawRectangle(bordeSecundario, datosPersonales);

                g.DrawLine(
                    lineaDelgada,
                    margenX,
                    y + 40,
                    margenX + anchoPagina,
                    y + 40);

                g.DrawLine(
                    lineaDelgada,
                    margenX,
                    y + 79,
                    margenX + anchoPagina,
                    y + 79);

                g.DrawLine(
                    lineaDelgada,
                    margenX + anchoColumna,
                    y + 40,
                    margenX + anchoColumna,
                    y + 118);

                DibujarCampo(
                    g,
                    "Nombre completo",
                    $"{tabla.Rows[0][6]} {tabla.Rows[0][7]}",
                    fuenteEtiqueta,
                    fuenteTexto,
                    new Rectangle(
                        margenX + 8,
                        y + 4,
                        anchoPagina - 16,
                        32));

                DibujarCampo(
                    g,
                    "Fecha de nacimiento",
                    FormatearFecha(tabla.Rows[0][8]),
                    fuenteEtiqueta,
                    fuenteTexto,
                    new Rectangle(
                        margenX + 8,
                        y + 43,
                        anchoColumna - 16,
                        32));

                DibujarCampo(
                    g,
                    "Número celular",
                    tabla.Rows[0][9].ToString(),
                    fuenteEtiqueta,
                    fuenteTexto,
                    new Rectangle(
                        margenX + anchoColumna + 8,
                        y + 43,
                        anchoColumna - 16,
                        32));

                DibujarCampo(
                    g,
                    "Nombre del tutor",
                    ObtenerTextoSeguro(tabla.Rows[0][10], "No registrado"),
                    fuenteEtiqueta,
                    fuenteTexto,
                    new Rectangle(
                        margenX + 8,
                        y + 82,
                        anchoColumna - 16,
                        32));

                DibujarCampo(
                    g,
                    "Celular del tutor",
                    ObtenerTextoSeguro(tabla.Rows[0][11], "----------"),
                    fuenteEtiqueta,
                    fuenteTexto,
                    new Rectangle(
                        margenX + anchoColumna + 8,
                        y + 82,
                        anchoColumna - 16,
                        32));

                y += 132;

                // =====================================================
                // INFORMACIÓN ACADÉMICA
                // =====================================================
                y = DibujarTituloSeccion(
                    g,
                    "INFORMACIÓN ACADÉMICA",
                    margenX,
                    y,
                    anchoPagina,
                    fuenteSeccion);

                Rectangle datosAcademicos = new Rectangle(
                    margenX,
                    y,
                    anchoPagina,
                    118);

                g.DrawRectangle(bordeSecundario, datosAcademicos);

                g.DrawLine(
                    lineaDelgada,
                    margenX,
                    y + 40,
                    margenX + anchoPagina,
                    y + 40);

                g.DrawLine(
                    lineaDelgada,
                    margenX,
                    y + 79,
                    margenX + anchoPagina,
                    y + 79);

                g.DrawLine(
                    lineaDelgada,
                    margenX + anchoColumna,
                    y,
                    margenX + anchoColumna,
                    y + 118);

                DibujarCampo(
                    g,
                    "Carnet estudiantil",
                    tabla.Rows[0][5].ToString(),
                    fuenteEtiqueta,
                    fuenteTexto,
                    new Rectangle(
                        margenX + 8,
                        y + 4,
                        anchoColumna - 16,
                        32));

                DibujarCampo(
                    g,
                    "Tipo de curso",
                    tabla.Rows[0][13].ToString(),
                    fuenteEtiqueta,
                    fuenteTexto,
                    new Rectangle(
                        margenX + anchoColumna + 8,
                        y + 4,
                        anchoColumna - 16,
                        32));

                DibujarCampo(
                    g,
                    "Curso",
                    tabla.Rows[0][12].ToString(),
                    fuenteEtiqueta,
                    fuenteTexto,
                    new Rectangle(
                        margenX + 8,
                        y + 43,
                        anchoColumna - 16,
                        32));

                DibujarCampo(
                    g,
                    "Docente",
                    tabla.Rows[0][18].ToString(),
                    fuenteEtiqueta,
                    fuenteTexto,
                    new Rectangle(
                        margenX + anchoColumna + 8,
                        y + 43,
                        anchoColumna - 16,
                        32));

                DibujarCampo(
                    g,
                    "Turno",
                    tabla.Rows[0][14].ToString(),
                    fuenteEtiqueta,
                    fuenteTexto,
                    new Rectangle(
                        margenX + 8,
                        y + 82,
                        anchoColumna - 16,
                        32));

                DibujarCampo(
                    g,
                    "Horario",
                    tabla.Rows[0][15].ToString(),
                    fuenteEtiqueta,
                    fuenteTexto,
                    new Rectangle(
                        margenX + anchoColumna + 8,
                        y + 82,
                        anchoColumna - 16,
                        32));

                y += 132;

                // =====================================================
                // OBSERVACIONES
                // =====================================================
                y = DibujarTituloSeccion(
                    g,
                    "OBSERVACIONES",
                    margenX,
                    y,
                    anchoPagina,
                    fuenteSeccion);

                Rectangle observaciones = new Rectangle(
                    margenX,
                    y,
                    anchoPagina,
                    62);

                g.DrawRectangle(bordeSecundario, observaciones);

                string textoObservacion =
                    ObtenerTextoSeguro(
                        tabla.Rows[0][17],
                        "Sin observaciones registradas.");

                g.DrawString(
                    textoObservacion,
                    fuenteObservacion,
                    Brushes.Black,
                    new Rectangle(
                        margenX + 10,
                        y + 9,
                        anchoPagina - 20,
                        45));

                y += 76;

                // =====================================================
                // DETALLE DE PAGOS
                // =====================================================
                y = DibujarTituloSeccion(
                    g,
                    "DETALLE DE PAGOS",
                    margenX,
                    y,
                    anchoPagina,
                    fuenteSeccion);

                Rectangle pagos = new Rectangle(
                    margenX,
                    y,
                    anchoPagina,
                    100);

                g.DrawRectangle(bordeSecundario, pagos);

                int anchoCodigo = 220;
                int anchoFacturas = anchoPagina - anchoCodigo;

                g.DrawLine(
                    lineaDelgada,
                    margenX + anchoFacturas,
                    y,
                    margenX + anchoFacturas,
                    y + pagos.Height);

                g.DrawString(
                    "FACTURAS REGISTRADAS",
                    fuenteEtiqueta,
                    Brushes.Black,
                    new Rectangle(
                        margenX + 10,
                        y + 8,
                        anchoFacturas - 20,
                        18));

                string facturas = tablaFactura.Rows.Count > 0
                    ? string.Join(
                        ", ",
                        tablaFactura.AsEnumerable()
                            .Select(r => r[0].ToString()))
                    : "No hay registros";

                g.DrawString(
                    facturas,
                    fuenteTexto,
                    Brushes.Black,
                    new Rectangle(
                        margenX + 10,
                        y + 30,
                        anchoFacturas - 20,
                        58));

                g.DrawString(
                    "CÓDIGO DE MATRÍCULA",
                    fuenteEtiqueta,
                    Brushes.Black,
                    new Rectangle(
                        margenX + anchoFacturas,
                        y + 6,
                        anchoCodigo,
                        18),
                    centrado);

                using (Bitmap codigo =
                       GenerarCodigoDeBarras(
                           tabla.Rows[0][1].ToString()))
                {
                    Rectangle rectCodigo = new Rectangle(
                        margenX + anchoFacturas + 15,
                        y + 27,
                        anchoCodigo - 30,
                        55);

                    g.DrawImage(codigo, rectCodigo);
                }

                g.DrawString(
                    tabla.Rows[0][1].ToString(),
                    fuentePie,
                    Brushes.Black,
                    new Rectangle(
                        margenX + anchoFacturas,
                        y + 82,
                        anchoCodigo,
                        15),
                    centrado);

                y += 114;

                // =====================================================
                // FIRMAS
                // =====================================================
                Rectangle firmas = new Rectangle(
                    margenX,
                    y,
                    anchoPagina,
                    72);

                g.DrawRectangle(bordeSecundario, firmas);

                int centroFirmaIzquierda =
                    margenX + (anchoColumna / 2);

                int centroFirmaDerecha =
                    margenX + anchoColumna + (anchoColumna / 2);

                int anchoLineaFirma = 230;
                int yLineaFirma = y + 39;

                g.DrawLine(
                    bordeSecundario,
                    centroFirmaIzquierda - (anchoLineaFirma / 2),
                    yLineaFirma,
                    centroFirmaIzquierda + (anchoLineaFirma / 2),
                    yLineaFirma);

                g.DrawLine(
                    bordeSecundario,
                    centroFirmaDerecha - (anchoLineaFirma / 2),
                    yLineaFirma,
                    centroFirmaDerecha + (anchoLineaFirma / 2),
                    yLineaFirma);

                g.DrawString(
                    "Firma del estudiante",
                    fuenteTexto,
                    Brushes.Black,
                    new Rectangle(
                        margenX,
                        y + 43,
                        anchoColumna,
                        20),
                    centrado);

                g.DrawString(
                    "Firma y sello autorizado",
                    fuenteTexto,
                    Brushes.Black,
                    new Rectangle(
                        margenX + anchoColumna,
                        y + 43,
                        anchoColumna,
                        20),
                    centrado);

                // =====================================================
                // PIE DE PÁGINA
                // =====================================================
                int pieY = e.PageBounds.Bottom - 55;

                g.DrawLine(
                    bordeSecundario,
                    margenX,
                    pieY,
                    margenX + anchoPagina,
                    pieY);

                string fechaImpresion =
                    DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");

                g.DrawString(
                    $"Documento generado el {fechaImpresion}",
                    fuentePie,
                    Brushes.Black,
                    margenX,
                    pieY + 7);

                StringFormat alineacionDerecha = new StringFormat
                {
                    Alignment = StringAlignment.Far
                };

                g.DrawString(
                    "Sistema Académico CECNIC",
                    fuentePie,
                    Brushes.Black,
                    new Rectangle(
                        margenX,
                        pieY + 7,
                        anchoPagina,
                        16),
                    alineacionDerecha);

                bordePrincipal.Dispose();
                bordeSecundario.Dispose();
                lineaDelgada.Dispose();
                centrado.Dispose();
                izquierdaCentro.Dispose();
                alineacionDerecha.Dispose();
            }

            e.HasMorePages = false;
        }

        private int DibujarTituloSeccion(
    Graphics g,
    string titulo,
    int x,
    int y,
    int ancho,
    Font fuente)
        {
            Rectangle encabezado = new Rectangle(x, y, ancho, 24);

            g.FillRectangle(Brushes.Black, encabezado);

            g.DrawString(
                titulo,
                fuente,
                Brushes.White,
                new Rectangle(
                    x + 8,
                    y,
                    ancho - 16,
                    24),
                new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center
                });

            return y + 24;
        }

        private void DibujarCampo(
    Graphics g,
    string etiqueta,
    string valor,
    Font fuenteEtiqueta,
    Font fuenteValor,
    Rectangle rectangulo)
        {
            string textoEtiqueta = etiqueta.ToUpper() + ":";

            SizeF medidaEtiqueta = g.MeasureString(
                textoEtiqueta,
                fuenteEtiqueta);

            g.DrawString(
                textoEtiqueta,
                fuenteEtiqueta,
                Brushes.Black,
                rectangulo.X,
                rectangulo.Y);

            Rectangle rectValor = new Rectangle(
                rectangulo.X,
                rectangulo.Y + 14,
                rectangulo.Width,
                rectangulo.Height - 14);

            StringFormat formato = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near,
                Trimming = StringTrimming.EllipsisCharacter,
                FormatFlags = StringFormatFlags.LineLimit
            };

            g.DrawString(
                valor ?? string.Empty,
                fuenteValor,
                Brushes.Black,
                rectValor,
                formato);

            formato.Dispose();
        }

        private void DibujarDatoHorizontal(
    Graphics g,
    string etiqueta,
    string valor,
    Font fuenteEtiqueta,
    Font fuenteValor,
    Rectangle rectangulo)
        {
            float anchoEtiqueta = g.MeasureString(
                etiqueta,
                fuenteEtiqueta).Width;

            g.DrawString(
                etiqueta,
                fuenteEtiqueta,
                Brushes.Black,
                new RectangleF(
                    rectangulo.X,
                    rectangulo.Y,
                    anchoEtiqueta + 5,
                    rectangulo.Height),
                new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center
                });

            g.DrawString(
                valor ?? string.Empty,
                fuenteValor,
                Brushes.Black,
                new RectangleF(
                    rectangulo.X + anchoEtiqueta + 8,
                    rectangulo.Y,
                    rectangulo.Width - anchoEtiqueta - 8,
                    rectangulo.Height),
                new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center,
                    Trimming = StringTrimming.EllipsisCharacter
                });
        }

        private string FormatearFecha(object valor)
        {
            if (valor == null || valor == DBNull.Value)
                return "No registrada";

            DateTime fecha;

            if (DateTime.TryParse(valor.ToString(), out fecha))
                return fecha.ToString("dd/MM/yyyy");

            return valor.ToString();
        }

        private string ObtenerTextoSeguro(
    object valor,
    string textoPredeterminado)
        {
            if (valor == null || valor == DBNull.Value)
                return textoPredeterminado;

            string texto = valor.ToString().Trim();

            return string.IsNullOrWhiteSpace(texto)
                ? textoPredeterminado
                : texto;
        }
        
        public Bitmap GenerarCodigoDeBarras(string contenido)
        {
            BarcodeWriter writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new EncodingOptions
                {
                    Height = 100, // Altura del código de barras
                    Width = 300    // Ancho del código de barras
                }
            };

            return writer.Write(contenido); // Devuelve el código de barras como un objeto Bitmap
        }


        private void MostrarDatosMatriculasPorCodigo(string CodigoMAT)
        {
            try
            {
                DataTable tablaMat = new DataTable();
                CN_Matriculas objetoUniverso = new CN_Matriculas();

                tablaMat = objetoUniverso.MostrarInformacion_Matricula(CodigoMAT);
                if (tablaMat.Rows.Count == 1)
                {
                    this.txtNombres.Text = tablaMat.Rows[0][0].ToString();
                    this.txtApellidos.Text = tablaMat.Rows[0][1].ToString();
                    this.txtfechainicio.Text = Convert.ToDateTime(tablaMat.Rows[0][2].ToString()).ToShortDateString();
                    this.txtfecharegistro.Text = Convert.ToDateTime(tablaMat.Rows[0][3].ToString()).ToShortDateString();
                    this.txtCedula.Text = tablaMat.Rows[0][4].ToString();
                    this.txtGenero.Text = tablaMat.Rows[0][5].ToString();
                    this.txtTipoSANGRE.Text = tablaMat.Rows[0][6].ToString();
                    this.txtCiudad.Text = tablaMat.Rows[0][7].ToString();
                    this.txtDepartamento.Text = tablaMat.Rows[0][8].ToString();
                    this.txtDireccionEstudiante.Text = tablaMat.Rows[0][9].ToString();
                    this.txtcodigopersona.Text = tablaMat.Rows[0][10].ToString();
                    this.txtCarnetEstudiante.Text = tablaMat.Rows[0][11].ToString();
                    this.txtCodigoMatricula.Text = tablaMat.Rows[0][12].ToString();
                    this.txtCodigoMatricula2.Text = tablaMat.Rows[0][12].ToString();
                    this.txtOrigenMatricula.Text = tablaMat.Rows[0][13].ToString();
                    this.txtObservacion.Text = tablaMat.Rows[0][14].ToString();
                    this.txtHorario.Text = tablaMat.Rows[0][15].ToString();
                    this.txtCurso.Text = tablaMat.Rows[0][16].ToString();
                    this.txtSucursal.Text = tablaMat.Rows[0][17].ToString();
                    this.txthoraregistro.Text = tablaMat.Rows[0][19].ToString();
                    this.txtFechaNacimiento.Text = Convert.ToDateTime(tablaMat.Rows[0][20].ToString()).ToShortDateString(); ;
                    this.txtNivelAcademico.Text = tablaMat.Rows[0][21].ToString();
                    this.txtOcupacion.Text = tablaMat.Rows[0][22].ToString();
                    this.txtTurno.Text = tablaMat.Rows[0][23].ToString();
                    this.txtDocente.Text = tablaMat.Rows[0][24].ToString();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataEstudiantes_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (this.dataEstudiantes.Columns[e.ColumnIndex].Name == "Movimientos")
                {

                    this.IdMatriculaHistorial = this.dataEstudiantes.CurrentRow.Cells["Id_Matricula"].Value.ToString();
                    this.tabControl1.SelectedTab = TabHistorialMatricula;

                }
                else if (this.dataEstudiantes.Columns[e.ColumnIndex].Name == "Detalle")
                {
                    string CodMAT = this.dataEstudiantes.CurrentRow.Cells["Cod_Matricula"].Value.ToString();
                    this.txtIdMatricula.Text = this.dataEstudiantes.CurrentRow.Cells["Id_Matricula"].Value.ToString();
                    this.MostrarDatosMatriculasPorCodigo(CodMAT);

                    this.tabControl1.SelectedTab = TabMatricula;
                }
                else if (this.dataEstudiantes.Columns[e.ColumnIndex].Name == "Actualizar")
                {
                    this.txtCodMatriculaEstudiante.Text = this.dataEstudiantes.CurrentRow.Cells["Cod_Matricula"].Value.ToString();
                    this.tabControl1.SelectedTab = TabGrupo;
                }
                else if (this.dataEstudiantes.Columns[e.ColumnIndex].Name == "Cambiar")
                {
                    string TipoUsuario = CacheUsuario.TipoUsuario;

                    if (TipoUsuario == "ADMINISTRADOR" || TipoUsuario == "COORDINACION" || TipoUsuario == "SUPER_USUARIO")
                    {
                        string Estado = this.dataEstudiantes.CurrentRow.Cells["Estado"].Value.ToString();
                        string IdMatricula = this.dataEstudiantes.CurrentRow.Cells["Id_Matricula"].Value.ToString();
                        if (Estado == "Activo")
                        {
                           this.txtIdMatricula_Baja.Text = IdMatricula;
                            this.tabControl1.SelectedTab = TabBajas;

                        }
                        else if (Estado == "Inactivo")
                        {
                            //Aca guardamos el Reingreso en la Tabla de Reingreso
                            string nombrePC = Environment.MachineName;
                            objetoCN1.Insertar(FechaActual, IdMatricula, CacheUsuario.IdUsuario, nombrePC);
                            objetoCN1.ActivarEstudiante(IdMatricula);
                            MessageBox.Show("Reingreso Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.radioButton1.Checked = true;
                            this.MostrarUniverso();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No tienes Acceso para realizar esta Accion", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtCodigoMatricula.Text == string.Empty)
                {
                    MessageBox.Show("No se ha seleccionado Ninguna Matricula", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.RealizarImpresionExpediente(this.txtCodigoMatricula.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Cargar_Cursos()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("Select Id_curso,Nombre_curso from Tbl_Cursos where id_estado = '3' ORDER BY Nombre_curso asc", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Nombre_curso"] = "Selecciona un Curso";
                dt.Rows.InsertAt(fila, 0);

                cmbTurnos.ValueMember = "Id_curso";
                cmbTurnos.DisplayMember = "Nombre_curso";
                cmbTurnos.DataSource = dt;


            }
            catch (Exception)
            {
                MessageBox.Show("Error de sistema, el error es ");
            }
        }

        public void Cargar_Estados()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("select Id_estado,Estado from Tbl_Estados where Id_estado = 3 or Id_estado = 4", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Estado"] = "Selecciona un Estado";
                dt.Rows.InsertAt(fila, 0);

                cmbEstados.ValueMember = "Id_estado";
                cmbEstados.DisplayMember = "Estado";
                cmbEstados.DataSource = dt;


            }
            catch (Exception)
            {
                MessageBox.Show("Error de sistema");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbTurnos.Text == "Selecciona un Curso")
                {
                    MessageBox.Show("Error, selecciona un curso", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (this.cmbEstados.Text == "Selecciona un Estado")
                {
                    MessageBox.Show("Error, selecciona un estado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CN_Grupos objetoCN = new CN_Grupos();
                    this.dataGrupos.DataSource = objetoCN.MostrarPorGrupoPorEstado(this.cmbEstados.Text, this.cmbTurnos.Text);
                    this.dataGrupos.Columns["Id_Grupo"].Visible = false;
                    this.dataGrupos.Columns["Tipo_Empleado"].Visible = false;
                    this.dataGrupos.Columns["Precio"].Visible = false;
                    this.dataGrupos.Columns["Simbolo"].Visible = false;
                    this.dataGrupos.Columns["Id_Curso_turno"].Visible = false;
                    this.dataGrupos.Columns["Id_empleado"].Visible = false;
                    this.dataGrupos.Columns["Id_Horario"].Visible = false;
                    this.dataGrupos.Columns["Id_estado"].Visible = false;
                    this.dataGrupos.Columns["Cedula"].Visible = false;
                    this.dataGrupos.Columns["Duracion"].Visible = false;
                    this.dataGrupos.Columns["IdMoneda"].Visible = false;
                    this.dataGrupos.Columns["Descripcion"].Visible = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarBtnDatagridViewGrupos()
        {
            dataGrupos.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Seleccionar",
                Name = "Seleccionar",
                Text = "Seleccionar",
                UseColumnTextForButtonValue = true

            });

            DataGridViewColumn columna = dataGrupos.Columns["Seleccionar"];

            // Establece el ancho deseado para la columna (en píxeles)
            columna.Width = 70;
        }

        private void dataGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataGrupos.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                    string IdGrupo = this.dataGrupos.CurrentRow.Cells["Id_Grupo"].Value.ToString();
                    string IdMoneda = this.dataGrupos.CurrentRow.Cells["IdMoneda"].Value.ToString();
                    string Monto = this.dataGrupos.CurrentRow.Cells["Precio"].Value.ToString();

                    CN_Matriculas objetoCN = new CN_Matriculas();
                    objetoCN.ActualizarMatriculaGrupo(IdGrupo, this.txtCodMatriculaEstudiante.Text);

                    MostrarMatriculas();

                    MessageBox.Show("Matricula Actualizada Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.tabControl1.SelectedIndex = 0;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                CacheMovimientoEstudiante.TipoMovimiento = "Reingresos";
                CacheMovimientoEstudiante.IdMatricula = this.IdMatriculaHistorial;
                Frm_MovimientosEstudiante frm = new Frm_MovimientosEstudiante();
                frm.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                CacheMovimientoEstudiante.TipoMovimiento = "Bajas";
                CacheMovimientoEstudiante.IdMatricula = this.IdMatriculaHistorial;

                Frm_MovimientosEstudiante frm = new Frm_MovimientosEstudiante();
                frm.ShowDialog();



            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 0;
        }

      
        private void button17_Click(object sender, EventArgs e)
        {
            GenerarCarnetEstudiante();
        }

        private void GenerarCarnetEstudiante()
        {
            try
            {
                string[] nombres = txtNombres.Text.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string[] apellidos = txtApellidos.Text.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string nombreMostrar = "";

                // Primer nombre
                if (nombres.Length > 0)
                {
                    nombreMostrar = nombres[0];
                }

                // Inicial del segundo nombre
                if (nombres.Length > 1)
                {
                    nombreMostrar += " " + nombres[1].Substring(0, 1).ToUpper() + ".";
                }

                // Primer apellido
                if (apellidos.Length > 0)
                {
                    nombreMostrar += " " + apellidos[0];
                }

                this.lblEstudiante_Carnet.Text = nombreMostrar;

                this.lblSucursal_Carnet.Text = this.txtSucursal.Text;
                this.lblCarnet_Carnet.Text = this.txtCarnetEstudiante.Text;
                this.txtCurso_Carnet.Text = this.txtCurso.Text;
                this.lblTurno_Carnet.Text = this.txtTurno.Text;
                this.lblHorario_Carnet.Text = this.txtHorario.Text;

                DateTime fechaActual = DateTime.Now;

                // Sumarle 1 año a la fecha actual
                DateTime fechaVencimiento = fechaActual.AddYears(1);

                this.lblFechaEmision_Carnet.Text = fechaActual.ToShortDateString();
                this.lblFechaVencimiento_Carnet.Text = fechaVencimiento.ToShortDateString();
                this.GenerarCodigoBarraEstudiante(this.txtCarnetEstudiante.Text);
                this.tabControl1.SelectedTab = tabCarnetEstudiante;

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarCodigoBarraEstudiante(string codigoCarnet)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(codigoCarnet))
                {
                    if (pictureBoxBarcode.Image != null)
                    {
                        pictureBoxBarcode.Image.Dispose();
                        pictureBoxBarcode.Image = null;
                    }

                    return;
                }

                codigoCarnet = codigoCarnet.Trim().ToUpper();

                BarcodeWriter barcodeWriter = new BarcodeWriter
                {
                    Format = BarcodeFormat.CODE_128,
                    Options = new EncodingOptions
                    {
                        Width = 200,
                        Height = 40,
                        Margin = 2,
                        PureBarcode = true
                    }
                };

                Bitmap barcode = barcodeWriter.Write(codigoCarnet);

                if (pictureBoxBarcode.Image != null)
                    pictureBoxBarcode.Image.Dispose();

                pictureBoxBarcode.Image = barcode;
                pictureBoxBarcode.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxBarcode.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible generar el código de barras.\n\n" + ex.Message,
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarUniverso();
        }

        private void MostrarUniverso()
        {
            try
            {
                this.cmbBusquedas.Text = "CARNET";

                this.txtbusqueda.Text = string.Empty;
                if (this.cmbBusquedas.Text == "CARNET")
                {
                    MostrarMatriculas();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void incentivoEjecutivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                CacheIncentivo.FechaInicial = this.dateTimePicker1.Text;
                CacheIncentivo.FechaFinal = this.dateTimePicker2.Text;
                CacheIncentivo.Estado = Estado.ToString();

                Frm_PagoIncentivo frm = new Frm_PagoIncentivo();
                frm.Show();


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void bajasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Tbl_Bajas frm = new Tbl_Bajas();
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void historialMatriculasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 4;
        }

        private void dataEstudiantes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    Color fondo = Color.White;
                    Bitmap icon = null;

                    if (e.ColumnIndex == dataEstudiantes.Columns["Movimientos"].Index)
                    {
                        fondo = Color.FromArgb(225, 242, 255); // Azul hielo
                        icon = Properties.Resources.historial_de_pedidos;
                    }
                    else if (e.ColumnIndex == dataEstudiantes.Columns["Detalle"].Index)
                    {
                        fondo = Color.FromArgb(239, 232, 255); // Lavanda suave
                        icon = Properties.Resources.archivo;
                    }
                    else if (e.ColumnIndex == dataEstudiantes.Columns["Actualizar"].Index)
                    {
                        fondo = Color.FromArgb(220, 250, 245); // Turquesa suave
                        icon = Properties.Resources.archivo__1_;
                    }
                    else if (e.ColumnIndex == dataEstudiantes.Columns["Cambiar"].Index)
                    {
                        fondo = Color.FromArgb(255, 235, 220); // Melocotón suave
                        icon = Properties.Resources.actualizar_accion;
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CN_Bajas objetoCN = new CN_Bajas();
                string nombrePC = Environment.MachineName;
                objetoCN.Insertar(this.cmbConceptoBaja.Text, this.txtmotivo.Text,this.txtIdMatricula_Baja.Text, CacheUsuario.IdUsuario, nombrePC);
                objetoCN.DarBaja(this.txtIdMatricula_Baja.Text);

                MessageBox.Show(
                  "El estudiante ha sido dado de baja de forma exitosa en el sistema.",
                  "Sistema CECNIC",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information
              );
                this.Limpiar();
                this.radioButton1.Checked = true;
                this.MostrarUniverso();
                this.tabControl1.SelectedTab = TabUniverso;

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            this.txtIdMatricula_Baja.Clear();
            this.txtmotivo.Text = string.Empty;
            this.cmbConceptoBaja.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = TabUniverso;
        }

        private void btnCopiarCedula_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                Clipboard.SetText(txtCedula.Text.Trim());

                MessageBox.Show(
                    "La cédula se copió al portapapeles correctamente.",
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    "No hay ninguna cédula para copiar.",
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnGenerarCarnet_Click(object sender, EventArgs e)
        {
            GenerarImagenCarnet();
        }

        private void GenerarImagenCarnet()
        {
            try
            {
                if (pbcarnet.Image == null)
                {
                    MessageBox.Show(
                        "No se encontró el diseño del carnet.",
                        "SISTEMA CECNIC",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (string.IsNullOrWhiteSpace(lblEstudiante_Carnet.Text))
                {
                    MessageBox.Show(
                        "Debe seleccionar un estudiante antes de generar el carnet.",
                        "SISTEMA CECNIC",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // Actualizar los controles antes de generar la imagen.
                panelCarnet.PerformLayout();
                panelCarnet.Refresh();
                Application.DoEvents();

                using (Bitmap carnet = CrearBitmapCarnet())
                using (SaveFileDialog guardar = new SaveFileDialog())
                {
                    string estudiante = LimpiarNombreArchivo(
                        lblEstudiante_Carnet.Text.Trim());

                    guardar.Title = "Guardar carnet estudiantil";
                    guardar.Filter = "Imagen PNG (*.png)|*.png";
                    guardar.DefaultExt = "png";
                    guardar.AddExtension = true;
                    guardar.RestoreDirectory = true;

                    guardar.FileName =
                        estudiante + "_" +
                        DateTime.Now.ToString("yyyy-MM-dd_HH-mm");

                    if (guardar.ShowDialog() != DialogResult.OK)
                        return;

                    carnet.Save(
                        guardar.FileName,
                        ImageFormat.Png);

                    DialogResult resultado = MessageBox.Show(
                        "El carnet estudiantil fue generado correctamente.\n\n" +
                        "¿Desea abrir la imagen?",
                        "SISTEMA CECNIC",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);

                    if (resultado == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = guardar.FileName,
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible generar el carnet.\n\n" + ex.Message,
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private Bitmap CrearBitmapCarnet()
        {
            const int anchoFinal = 996;
            const int altoFinal = 1580;

            if (panelCarnet.ClientSize.Width <= 0 ||
                panelCarnet.ClientSize.Height <= 0)
            {
                throw new Exception(
                    "El panel del carnet no tiene un tamaño válido.");
            }

            if (pbcarnet.Image == null)
            {
                throw new Exception(
                    "No se encontró la imagen del diseño del carnet.");
            }

            float escalaX =
                (float)anchoFinal / panelCarnet.ClientSize.Width;

            float escalaY =
                (float)altoFinal / panelCarnet.ClientSize.Height;

            // Para las fuentes se usa una escala promedio.
            float escalaFuente =
                Math.Min(escalaX, escalaY);

            Bitmap imagenFinal = new Bitmap(
                anchoFinal,
                altoFinal,
                PixelFormat.Format32bppArgb);

            imagenFinal.SetResolution(600, 600);

            using (Graphics g = Graphics.FromImage(imagenFinal))
            {
                g.Clear(Color.White);

                g.SmoothingMode =
                    SmoothingMode.HighQuality;

                g.InterpolationMode =
                    InterpolationMode.HighQualityBicubic;

                g.PixelOffsetMode =
                    PixelOffsetMode.HighQuality;

                g.CompositingQuality =
                    CompositingQuality.HighQuality;

                g.TextRenderingHint =
                    TextRenderingHint.ClearTypeGridFit;

                // Dibujar la plantilla del carnet.
                g.DrawImage(
                    pbcarnet.Image,
                    new Rectangle(
                        0,
                        0,
                        anchoFinal,
                        altoFinal));

                // Dibujar los Label.
                Label[] etiquetas =
                {
            lblSucursal_Carnet,
            lblCarnet_Carnet,
            lblEstudiante_Carnet,
            lblTurno_Carnet,
            lblHorario_Carnet,
            lblFechaEmision_Carnet,
            lblFechaVencimiento_Carnet
        };

                foreach (Label etiqueta in etiquetas)
                {
                    DibujarControlTexto(
                        g,
                        etiqueta,
                        etiqueta.Text,
                        etiqueta.TextAlign,
                        escalaX,
                        escalaY,
                        escalaFuente);
                }

                // Dibujar el contenido del TextBox del curso.
                ContentAlignment alineacionCurso =
                    ContentAlignment.MiddleLeft;

                switch (txtCurso_Carnet.TextAlign)
                {
                    case HorizontalAlignment.Center:
                        alineacionCurso =
                            ContentAlignment.MiddleCenter;
                        break;

                    case HorizontalAlignment.Right:
                        alineacionCurso =
                            ContentAlignment.MiddleRight;
                        break;
                }

                DibujarControlTexto(
                    g,
                    txtCurso_Carnet,
                    txtCurso_Carnet.Text,
                    alineacionCurso,
                    escalaX,
                    escalaY,
                    escalaFuente);

                // Dibujar el código de barras.
                if (pictureBoxBarcode.Visible &&
                    pictureBoxBarcode.Image != null)
                {
                    Rectangle destinoBarcode = new Rectangle(
                        (int)Math.Round(
                            pictureBoxBarcode.Left * escalaX),

                        (int)Math.Round(
                            pictureBoxBarcode.Top * escalaY),

                        (int)Math.Round(
                            pictureBoxBarcode.Width * escalaX),

                        (int)Math.Round(
                            pictureBoxBarcode.Height * escalaY));

                    // Fondo blanco para facilitar la lectura.
                    using (Brush fondo = new SolidBrush(Color.White))
                    {
                        g.FillRectangle(
                            fondo,
                            destinoBarcode);
                    }

                    InterpolationMode interpolacionAnterior =
                        g.InterpolationMode;

                    PixelOffsetMode pixelAnterior =
                        g.PixelOffsetMode;

                    // Evita que las barras queden borrosas.
                    g.InterpolationMode =
                        InterpolationMode.NearestNeighbor;

                    g.PixelOffsetMode =
                        PixelOffsetMode.Half;

                    g.DrawImage(
                        pictureBoxBarcode.Image,
                        destinoBarcode);

                    g.InterpolationMode =
                        interpolacionAnterior;

                    g.PixelOffsetMode =
                        pixelAnterior;
                }
            }

            return imagenFinal;
        }

        private void DibujarControlTexto(
     Graphics g,
     Control control,
     string texto,
     ContentAlignment alineacion,
     float escalaX,
     float escalaY,
     float escalaFuente)
        {
            if (control == null ||
                !control.Visible ||
                string.IsNullOrWhiteSpace(texto))
            {
                return;
            }

            Rectangle rectangulo = new Rectangle(
                (int)Math.Round(control.Left * escalaX),
                (int)Math.Round(control.Top * escalaY),
                (int)Math.Round(control.Width * escalaX),
                (int)Math.Round(control.Height * escalaY));

            // Convierte el tamaño original de puntos a píxeles.
            float fuentePixeles =
                control.Font.SizeInPoints *
                96f / 72f *
                escalaFuente;

            using (Font fuente = new Font(
                control.Font.FontFamily,
                fuentePixeles,
                control.Font.Style,
                GraphicsUnit.Pixel))
            {
                /*
                 * Si es un TextBox Multiline, se utiliza DrawString
                 * para permitir que el texto continúe en otra línea.
                 */
                TextBox textBox = control as TextBox;

                if (textBox != null && textBox.Multiline)
                {
                    using (Brush brocha = new SolidBrush(control.ForeColor))
                    using (StringFormat formato = new StringFormat())
                    {
                        // Alineación horizontal.
                        switch (alineacion)
                        {
                            case ContentAlignment.TopCenter:
                            case ContentAlignment.MiddleCenter:
                            case ContentAlignment.BottomCenter:
                                formato.Alignment = StringAlignment.Center;
                                break;

                            case ContentAlignment.TopRight:
                            case ContentAlignment.MiddleRight:
                            case ContentAlignment.BottomRight:
                                formato.Alignment = StringAlignment.Far;
                                break;

                            default:
                                formato.Alignment = StringAlignment.Near;
                                break;
                        }

                        // Alineación vertical.
                        switch (alineacion)
                        {
                            case ContentAlignment.MiddleLeft:
                            case ContentAlignment.MiddleCenter:
                            case ContentAlignment.MiddleRight:
                                formato.LineAlignment = StringAlignment.Center;
                                break;

                            case ContentAlignment.BottomLeft:
                            case ContentAlignment.BottomCenter:
                            case ContentAlignment.BottomRight:
                                formato.LineAlignment = StringAlignment.Far;
                                break;

                            default:
                                formato.LineAlignment = StringAlignment.Near;
                                break;
                        }

                        // Permite el salto automático entre palabras.
                        formato.Trimming = StringTrimming.EllipsisWord;

                        // No colocar NoWrap, porque impediría las múltiples líneas.
                        formato.FormatFlags = StringFormatFlags.LineLimit;

                        RectangleF areaTexto = new RectangleF(
                            rectangulo.X,
                            rectangulo.Y,
                            rectangulo.Width,
                            rectangulo.Height);

                        g.DrawString(
                            texto,
                            fuente,
                            brocha,
                            areaTexto,
                            formato);
                    }

                    return;
                }

                /*
                 * Para Label y controles de una sola línea,
                 * se mantiene TextRenderer.
                 */
                TextFormatFlags flags =
                    TextFormatFlags.NoPadding |
                    TextFormatFlags.EndEllipsis;

                switch (alineacion)
                {
                    case ContentAlignment.TopLeft:
                        flags |= TextFormatFlags.Left |
                                 TextFormatFlags.Top;
                        break;

                    case ContentAlignment.TopCenter:
                        flags |= TextFormatFlags.HorizontalCenter |
                                 TextFormatFlags.Top;
                        break;

                    case ContentAlignment.TopRight:
                        flags |= TextFormatFlags.Right |
                                 TextFormatFlags.Top;
                        break;

                    case ContentAlignment.MiddleLeft:
                        flags |= TextFormatFlags.Left |
                                 TextFormatFlags.VerticalCenter;
                        break;

                    case ContentAlignment.MiddleCenter:
                        flags |= TextFormatFlags.HorizontalCenter |
                                 TextFormatFlags.VerticalCenter;
                        break;

                    case ContentAlignment.MiddleRight:
                        flags |= TextFormatFlags.Right |
                                 TextFormatFlags.VerticalCenter;
                        break;

                    case ContentAlignment.BottomLeft:
                        flags |= TextFormatFlags.Left |
                                 TextFormatFlags.Bottom;
                        break;

                    case ContentAlignment.BottomCenter:
                        flags |= TextFormatFlags.HorizontalCenter |
                                 TextFormatFlags.Bottom;
                        break;

                    case ContentAlignment.BottomRight:
                        flags |= TextFormatFlags.Right |
                                 TextFormatFlags.Bottom;
                        break;
                }

                TextRenderer.DrawText(
                    g,
                    texto,
                    fuente,
                    rectangulo,
                    control.ForeColor,
                    Color.Transparent,
                    flags);
            }
        }




        private string LimpiarNombreArchivo(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return "Carnet_Estudiante";

            texto = texto.Trim();

            foreach (char caracter in
                Path.GetInvalidFileNameChars())
            {
                texto = texto.Replace(
                    caracter,
                    '_');
            }

            texto = texto.Replace(" ", "_");

            while (texto.Contains("__"))
            {
                texto = texto.Replace(
                    "__",
                    "_");
            }

            return texto;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = TabUniverso;
            LimpiarControlesCarnet();
        }

       private void LimpiarControlesCarnet()
        {
            this.lblSucursal_Carnet.Text = string.Empty;
            this.lblCarnet_Carnet.Text = string.Empty;
            this.lblEstudiante_Carnet.Text = string.Empty;
            this.lblTurno_Carnet.Text = string.Empty;
            this.lblHorario_Carnet.Text = string.Empty;
            this.txtCurso_Carnet.Clear();
            this.lblFechaEmision_Carnet.Text = string.Empty;
            this.lblFechaVencimiento_Carnet.Text = string.Empty;
            pictureBoxBarcode.Image?.Dispose();
            pictureBoxBarcode.Image = null;
            pictureBoxBarcode.Refresh();

        }

        private void btnImprimirCarnet_Click(object sender, EventArgs e)
        {
            ImprimirCarnet();
        }

        private void ImprimirCarnet()
        {
            try
            {
                if (pbcarnet.Image == null)
                {
                    MessageBox.Show(
                        "No se encontró el diseño del carnet.",
                        "SISTEMA CECNIC",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (string.IsNullOrWhiteSpace(lblEstudiante_Carnet.Text))
                {
                    MessageBox.Show(
                        "Debe seleccionar un estudiante antes de imprimir el carnet.",
                        "SISTEMA CECNIC",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // Actualizar los controles.
                panelCarnet.PerformLayout();
                panelCarnet.Refresh();
                Application.DoEvents();

                // Liberar cualquier imagen anterior.
                if (imagenCarnetImprimir != null)
                {
                    imagenCarnetImprimir.Dispose();
                    imagenCarnetImprimir = null;
                }

                // Crear el carnet mediante tu método actual.
                imagenCarnetImprimir = CrearBitmapCarnet();

                documentoCarnet.DocumentName =
                    "Carnet - " + lblEstudiante_Carnet.Text.Trim();

                documentoCarnet.DefaultPageSettings.Margins =
               new System.Drawing.Printing.Margins(0, 0, 0, 0);

                documentoCarnet.DefaultPageSettings.Color = true;

                using (PrintDialog dialogoImpresion = new PrintDialog())
                {
                    dialogoImpresion.Document = documentoCarnet;
                    dialogoImpresion.AllowCurrentPage = false;
                 
                    dialogoImpresion.AllowSelection = false;
                    dialogoImpresion.UseEXDialog = true;

                    if (dialogoImpresion.ShowDialog() != DialogResult.OK)
                    {
                        imagenCarnetImprimir.Dispose();
                        imagenCarnetImprimir = null;
                        return;
                    }

                    documentoCarnet.PrinterSettings =
                        dialogoImpresion.PrinterSettings;

                    documentoCarnet.Print();
                }
            }
            catch (InvalidPrinterException)
            {
                LiberarImagenImpresion();

                MessageBox.Show(
                    "La impresora seleccionada no está disponible o no está configurada correctamente.",
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LiberarImagenImpresion();

                MessageBox.Show(
                    "No fue posible imprimir el carnet.\n\n" +
                    ex.Message,
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DocumentoCarnet_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (imagenCarnetImprimir == null)
                return;

            // Área imprimible real de la impresora seleccionada
            Rectangle area = e.MarginBounds;

            // Si no hay márgenes, usa toda la página
            if (area.Width <= 0 || area.Height <= 0)
                area = e.PageBounds;

            // Escala para ocupar el mayor espacio posible
            float escalaX = (float)area.Width / imagenCarnetImprimir.Width;
            float escalaY = (float)area.Height / imagenCarnetImprimir.Height;

            float escala = Math.Min(escalaX, escalaY);

            int ancho = (int)(imagenCarnetImprimir.Width * escala);
            int alto = (int)(imagenCarnetImprimir.Height * escala);

            // Centrar
            int x = area.Left + (area.Width - ancho) / 2;
            int y = area.Top + (area.Height - alto) / 2;

            e.Graphics.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            e.Graphics.DrawImage(
                imagenCarnetImprimir,
                x,
                y,
                ancho,
                alto);

            e.HasMorePages = false;
        }

        private Rectangle CalcularRectanguloProporcional(
    Size tamañoImagen,
    Rectangle areaDisponible)
        {
            if (tamañoImagen.Width <= 0 ||
                tamañoImagen.Height <= 0)
            {
                return areaDisponible;
            }

            float escalaAncho =
                (float)areaDisponible.Width /
                tamañoImagen.Width;

            float escalaAlto =
                (float)areaDisponible.Height /
                tamañoImagen.Height;

            float escala =
                Math.Min(escalaAncho, escalaAlto);

            int nuevoAncho =
                (int)Math.Round(tamañoImagen.Width * escala);

            int nuevoAlto =
                (int)Math.Round(tamañoImagen.Height * escala);

            int posicionX =
                areaDisponible.Left +
                (areaDisponible.Width - nuevoAncho) / 2;

            int posicionY =
                areaDisponible.Top +
                (areaDisponible.Height - nuevoAlto) / 2;

            return new Rectangle(
                posicionX,
                posicionY,
                nuevoAncho,
                nuevoAlto);
        }


        private void DocumentoCarnet_EndPrint(
    object sender,
    PrintEventArgs e)
        {
            LiberarImagenImpresion();
        }

        private void LiberarImagenImpresion()
        {
            if (imagenCarnetImprimir != null)
            {
                imagenCarnetImprimir.Dispose();
                imagenCarnetImprimir = null;
            }
        }
    }

}






