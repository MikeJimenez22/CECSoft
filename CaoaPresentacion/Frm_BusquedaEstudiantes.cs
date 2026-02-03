using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
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
        string IdMatriculaEst;
    


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
                DataGridViewConfigurator.Configure(this.dataEstudiantes,this.dataGrupos);
               

                // Configurar controles de búsqueda
                SetupSearchControls();

            

                // Configurar el estado del combo box
                cmbEstados.Text = "Activo";

  
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
            cmbBusquedas.Text = "Carnet";
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
                MessageBox.Show("opps!, No hay nada que buscar", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (this.txtbusqueda.Text != string.Empty)
            {
                if (this.cmbBusquedas.Text == "Carnet")
                {
                    ObtenerUniversoTotal();
                    this.MostrarPorCarnet();

                }
                else if (this.cmbBusquedas.Text == "Nombres")
                {
                    ObtenerUniversoTotal();
                    this.MostrarPorNombre();

                }
                else if (this.cmbBusquedas.Text == "Apellidos")
                {
                    ObtenerUniversoTotal();
                    this.MostrarPorApellidos();

                }
                else if (this.cmbBusquedas.Text == "Codigo Matricula")
                {
                    ObtenerUniversoTotal();
                    this.MostrarPorCodigoMatricula();
                }
            }


        }

        public void MostrarPorCarnet()
        {
            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            this.dataEstudiantes.DataSource = objetoCN.MostrarPorCarnet(this.txtbusqueda.Text, Estado);
            this.OcultarColumnas();
            this.ContarFilas();
        }
        private void MostrarPorNombre()
        {
            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            this.dataEstudiantes.DataSource = objetoCN.MostrarPorNombre(this.txtbusqueda.Text, Estado);
            this.OcultarColumnas();
            this.ContarFilas();
        }

        private void MostrarPorCodigoMatricula()
        {
            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            this.dataEstudiantes.DataSource = objetoCN.MostrarPorCodMatricula(this.txtbusqueda.Text, Estado);
            this.OcultarColumnas();
            this.ContarFilas();
        }


        private void MostrarPorApellidos()
        {
            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            this.dataEstudiantes.DataSource = objetoCN.MostrarPorApellidos(this.txtbusqueda.Text, Estado);
            this.OcultarColumnas();
            this.ContarFilas();
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
            this.ConfigurarGrafico();
            string TipoUsuario = CacheUsuario.TipoUsuario;

           

            // Agregar botones a DataGridView
            this.AgregarColumnaConIcono();
            AgregarBtnDatagridViewGrupos();
            this.radioButton1.Checked = true;

            this.BuscarPorFecha();
            this.OcultarColumnas();
          
            ContarFilas();
            this.cmbConceptoBaja.Text = "OTRO";


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
              
                this.ContarFilas();
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
                DateTime fecha1 = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime fecha2 = DateTime.ParseExact(dateTimePicker2.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                this.dataEstudiantes.DataSource = objetoCN.MostrarUniversoPorDia(fecha1, fecha2, Estado);
                this.OcultarColumnas();
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
            Font tituloFont = new Font("Arial", 16, FontStyle.Bold);
            Font subtituloFont = new Font("Arial", 14, FontStyle.Bold);
            Font textoDestacadoFont = new Font("Arial", 12, FontStyle.Italic);
            Font textoPequenioFont = new Font("Arial", 10);

            Bitmap codigoDeBarras = GenerarCodigoDeBarras(tabla.Rows[0][1].ToString());


            

            Font detalleFont = new Font("Arial", 12);
            int x = 100;
            int y = 100;
            int interlineado = 20;


            // e.Graphics.DrawImage(imageToPrint, destRect); // Cambia las coordenadas (100, 100) según sea necesario
            e.Graphics.DrawString("CECNIC - ¡CAPACITACION SIN LIMITES!", tituloFont, Brushes.Black, x, y);
            y += interlineado * 2;
            e.Graphics.DrawString("Expediente estudiantil", subtituloFont, Brushes.Black, x, y);
            y += interlineado;
            e.Graphics.DrawString("_____________________________________________________", subtituloFont, Brushes.Black, x, y);
            y += interlineado * 2;
            e.Graphics.DrawString("Detalle de Registro", textoDestacadoFont, Brushes.Black, x, y);
            y += interlineado * 2;
            e.Graphics.DrawString("Código de Matrícula: " + tabla.Rows[0][1].ToString() + "  " + "  Fecha de Inicio: " + Convert.ToDateTime(tabla.Rows[0][3]).ToShortDateString(), textoPequenioFont, Brushes.Black, x, y);
            y += interlineado;
            e.Graphics.DrawString("Matriculado Por: " + tabla.Rows[0][2].ToString() + " " + "  Fecha de Registro: " + Convert.ToDateTime(tabla.Rows[0][4]).ToShortDateString(), textoPequenioFont, Brushes.Black, x, y);
            y += interlineado * 2;
            e.Graphics.DrawString("Datos Personales", textoDestacadoFont, Brushes.Black, x, y);
            y += interlineado;
            e.Graphics.DrawString("_____________________________________________________", subtituloFont, Brushes.Black, x, y);
            y += interlineado * 2;
            e.Graphics.DrawString("Nombres Estudiante(*): " + tabla.Rows[0][6].ToString() + " " + tabla.Rows[0][7].ToString(), textoPequenioFont, Brushes.Black, x, y);
            y += interlineado;
            e.Graphics.DrawString("Fecha de Nacimiento: " + Convert.ToDateTime(tabla.Rows[0][8]).ToShortDateString(), textoPequenioFont, Brushes.Black, x, y);
            y += interlineado;
            e.Graphics.DrawString("Celular 1: " + tabla.Rows[0][9].ToString(), textoPequenioFont, Brushes.Black, x, y);
            y += interlineado;
            e.Graphics.DrawString("Nombre del Tutor: " + tabla.Rows[0][10].ToString() + "  Celular del Tutor: " + tabla.Rows[0][11].ToString(), textoPequenioFont, Brushes.Black, x, y);
            y += interlineado;

            e.Graphics.DrawString("Detalle de Estudiante", textoDestacadoFont, Brushes.Black, x, y);
            y += interlineado;
            e.Graphics.DrawString("_____________________________________________________", subtituloFont, Brushes.Black, x, y);
            y += interlineado * 2;
            e.Graphics.DrawString("Carnet Estudiantil: " + tabla.Rows[0][5].ToString(), textoPequenioFont, Brushes.Black, x, y);
            y += interlineado;
            e.Graphics.DrawString("Nombre del Curso: " + tabla.Rows[0][12].ToString(), textoPequenioFont, Brushes.Black, x, y);
            y += interlineado;
            e.Graphics.DrawString("Turno: " + tabla.Rows[0][14].ToString() + "  Horario: " + tabla.Rows[0][15].ToString(), textoPequenioFont, Brushes.Black, x, y);
            y += interlineado * 2;
            e.Graphics.DrawString("Observaciones (*): " + tabla.Rows[0][17].ToString(), textoPequenioFont, Brushes.Black, x, y);
            y += interlineado * 3;
            e.Graphics.DrawString("Firma del Estudiante X_____________       Firma Cajero  X_____________ ", textoPequenioFont, Brushes.Black, x, y);
            y += interlineado * 2;
            e.Graphics.DrawString("Detalle de Pagos", textoDestacadoFont, Brushes.Black, x, y);
            y += interlineado;
            // Verificamos si hay registros en la tabla
            // Inicializa una lista para almacenar las facturas
            List<string> facturas = new List<string>();

            // Recorre todas las filas en la tabla de facturas
            foreach (DataRow row in tablaFactura.Rows)
            {
                // Verifica que el valor no sea DBNull antes de agregarlo
                if (row[0] != DBNull.Value)
                {
                    facturas.Add(row[0].ToString());
                }
            }

            // Si hay facturas, las unimos en una sola cadena separada por comas
            if (facturas.Count > 0)
            {
                string todasLasFacturas = string.Join(", ", facturas);
                e.Graphics.DrawString(todasLasFacturas, subtituloFont, Brushes.Black, x, y);
            }
            else
            {
                // Si no hay registros, mostramos "No hay registro"
                e.Graphics.DrawString("No hay registro", subtituloFont, Brushes.Black, x, y);
            }


            y += interlineado;
            e.Graphics.DrawString("_____________________________________________________", subtituloFont, Brushes.Black, x, y);
            y += interlineado * 3;

            e.Graphics.DrawString("Tipo de Matricula:     1.Nuevo Ingreso_____     2.Reingreso______   3.Segundo Curso o mas____   ", textoPequenioFont, Brushes.Black, x, y);
            y += interlineado * 2;
            e.Graphics.DrawImage(codigoDeBarras, x, y); // Posición de dibujo del código de barras en el documento




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



        private void ObtenerUniversoTotal()
        {
            string CantidadUniverso;
            string CantidadUniversoHoy;

            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            DataTable tabla = new DataTable();

            tabla = objetoCN.CalcularCantidadActualUniverso();
            if (tabla.Rows.Count == 0)
            {
                CantidadUniverso = "0".ToString();
            }
            else
            {
                CantidadUniverso = tabla.Rows[0][0].ToString();
            }

            CN_VistaUniverso objetoCN2 = new CN_VistaUniverso();
            DataTable tabla2 = new DataTable();

            string FechaActual = DateTime.Now.ToShortDateString();

            tabla2 = objetoCN.CalcularCantidadActualUniversoHoy(Convert.ToDateTime(FechaActual));
            if (tabla2.Rows.Count == 0)
            {
                CantidadUniversoHoy = "0".ToString();
            }
            else
            {
                CantidadUniversoHoy = tabla2.Rows[0][0].ToString();
            }


            CN_VistaUniverso objetoCN3 = new CN_VistaUniverso();
            DataTable tabla3 = new DataTable();

            string FechaHoy = DateTime.Now.ToShortDateString();

            tabla3 = objetoCN.VERIFICARREGISTRO_MATRICULAS(Convert.ToDateTime(FechaActual));
            if (tabla.Rows.Count == 0)
            {
                CN_VistaUniverso objetoUniverso = new CN_VistaUniverso();
                objetoUniverso.InsertarREGISTROFECHA(Convert.ToDateTime(FechaActual), CantidadUniverso);
            }
            else
            {
                CN_VistaUniverso objetoUniversoHoy = new CN_VistaUniverso();
                objetoUniversoHoy.ActualizarREGISTROFECHA(Convert.ToDateTime(FechaActual), CantidadUniversoHoy);
            }

        }


        private void MostrarDatosMatriculasPorCodigo(string CodigoMAT)
        {
            try
            {
                DataTable tablaMat = new DataTable();
                CN_VistaUniverso objetoUniverso = new CN_VistaUniverso();

                tablaMat = objetoUniverso.MostrarMatriculasPorCodigo(CodigoMAT);
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
                            IdMatriculaEst = IdMatricula;
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
                    
                  

                    if (this.cmbBusquedas.Text == "Carnet")
                    {
                        ObtenerUniversoTotal();
                        this.MostrarPorCarnet();

                    }
                    else if (this.cmbBusquedas.Text == "Nombres")
                    {
                        ObtenerUniversoTotal();
                        this.MostrarPorNombre();

                    }
                    else if (this.cmbBusquedas.Text == "Apellidos")
                    {
                        ObtenerUniversoTotal();
                        this.MostrarPorApellidos();

                    }
                    else if (this.cmbBusquedas.Text == "Codigo Matricula")
                    {
                        ObtenerUniversoTotal();
                        this.MostrarPorCodigoMatricula();
                    }
                    
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
                MessageBox.Show("Error de Sistema","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                string FechaInicio = Convert.ToDateTime(this.dateTimePicker3.Text).ToShortDateString();
                string FechaFinal = Convert.ToDateTime(this.dateTimePicker4.Text).ToShortDateString();

                TimeSpan diferencia = Convert.ToDateTime(FechaFinal) - Convert.ToDateTime(FechaInicio);
                // Obtén los días de diferencia
                int diasDiferencia = diferencia.Days;

                if (diasDiferencia < 0)
                {
                    MessageBox.Show("La fecha Inicio es mayor que la fecha final", "Aviso de Restricción",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
                else if (diasDiferencia > 30) 
                {
                    MessageBox.Show("Por motivos de visibilidad, solo se pueden mostrar un máximo de 30 fechas. Por favor, ajuste el rango de fechas seleccionado.",
                 "Aviso de Restricción",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information);

                }else if ((diasDiferencia >= 1 && diasDiferencia <= 30) || (diasDiferencia == 0))
                {
                    CN_Matriculas objetoCN = new CN_Matriculas();
                    DataTable dt = new DataTable();
                    dt = objetoCN.MostrarUniversoPorfechas(FechaInicio, FechaFinal);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No hay Registros", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Limpia series previas en caso de actualizaciones
                        chart1.Series.Clear();

                        // Crea una nueva serie
                        Series serie = new Series("Historial de Matrículas");
                        serie.ChartType = SeriesChartType.Column; // Tipo de gráfico (puedes usar Line, Bar, etc.)

                        // Añade datos al eje X (Fecha) y Y (Total)
                        int? totalAnterior = null; // Variable para guardar el total del punto anterior
                        Color colorAnterior = Color.Blue; // Color inicial para manejar totales iguales

                        foreach (DataRow fila in dt.Rows)
                        {
                            string fecha = Convert.ToDateTime(fila["Fecha"]).ToShortDateString(); // Obtén la fecha en formato corto
                            int total = Convert.ToInt32(fila["Total"]); // Obtén el total desde el DataTable

                            // Crea un punto de datos
                            DataPoint punto = new DataPoint();
                            punto.SetValueXY(fecha, total); // Establece X como fecha y Y como total
                            punto.Label = total.ToString(); // Configura la etiqueta que se mostrará encima

                            // Determinar el color del punto
                            if (totalAnterior != null) // Si hay un valor anterior para comparar
                            {
                                if (total > totalAnterior) // Si aumenta, color verde
                                {
                                    punto.Color = Color.Green;
                                    colorAnterior = Color.Green; // Actualiza el color para manejar totales iguales
                                }
                                else if (total < totalAnterior) // Si disminuye, color rojo
                                {
                                    punto.Color = Color.Red;
                                    colorAnterior = Color.Red; // Actualiza el color para manejar totales iguales
                                }
                                else // Si son iguales
                                {
                                    punto.Color = colorAnterior; // Usa el mismo color que el anterior
                                }
                            }
                            else
                            {
                                // Si no hay un valor anterior (primer punto), compara con el segundo
                                if (dt.Rows.Count > 1)
                                {
                                    int segundoTotal = Convert.ToInt32(dt.Rows[1]["Total"]);
                                    if (total < segundoTotal) // Primer registro menor que el segundo
                                    {
                                        punto.Color = Color.Red;
                                        colorAnterior = Color.Red;
                                    }
                                    else // Primer registro mayor o igual que el segundo
                                    {
                                        punto.Color = Color.Green;
                                        colorAnterior = Color.Green;
                                    }
                                }
                                else
                                {
                                    punto.Color = Color.Blue; // Color por defecto si es el único registro
                                    colorAnterior = Color.Blue;
                                }
                            }

                            totalAnterior = total; // Actualiza el total anterior para la siguiente iteración

                            // Agrega el punto a la serie
                            serie.Points.Add(punto);
                        }


                        // Añade la serie al Chart
                        chart1.Series.Add(serie);

                        // Configuración opcional de ejes
                        chart1.ChartAreas[0].AxisX.Title = "Fecha";
                        chart1.ChartAreas[0].AxisY.Title = "Total";
                        chart1.ChartAreas[0].AxisX.Interval = 1; // Opcional: controla el espaciado de etiquetas en el eje X
                        chart1.ChartAreas[0].RecalculateAxesScale(); // Ajusta los valores automáticamente


                    }


                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrafico()
        {
            // Código de configuración del gráfico
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.ChartAreas.Clear();
            chart1.Legends.Clear();

            // Configuración del área del gráfico
            ChartArea area = new ChartArea("Principal");
            area.BackColor = Color.WhiteSmoke;
            area.BorderColor = Color.Gray;
            area.BorderWidth = 1;
            area.ShadowColor = Color.LightGray;
            area.ShadowOffset = 2;

            area.AxisX.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.AxisX.LabelStyle.ForeColor = Color.Black;
            area.AxisY.LabelStyle.ForeColor = Color.Black;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            chart1.ChartAreas.Add(area);

            // Configuración de la serie
            Series serie = new Series("Historial de Matrículas");
            serie.ChartType = SeriesChartType.Column;
            serie.Color = Color.DodgerBlue;
            serie.BorderWidth = 1;
            serie.BackGradientStyle = GradientStyle.TopBottom;
            serie.BackSecondaryColor = Color.LightSkyBlue;
            serie.ShadowOffset = 2;
            serie.IsValueShownAsLabel = true;
            serie.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            serie.LabelForeColor = Color.DarkBlue;

          

            // Configuración del título
            Title titulo = new Title();
            titulo.Text = "Historial de Matrículas por Fecha";
            titulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            titulo.ForeColor = Color.DarkSlateGray;
            titulo.Alignment = ContentAlignment.TopCenter;
            chart1.Titles.Add(titulo);

            // Configuración de la leyenda
            Legend leyenda = new Legend("Leyenda");
            leyenda.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            leyenda.ForeColor = Color.DarkSlateGray;
            leyenda.Docking = Docking.Top;
            chart1.Legends.Add(leyenda);
        }

        

        private void button16_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 0;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                string Cursos = this.txtCurso.Text;
                string Turnos = this.txtTurno.Text;
                string Horarios = this.txtHorario.Text;

                this.lblNombres.Text = this.txtNombres.Text;
                this.lblApellidos.Text = this.txtApellidos.Text;
                this.lblcurso.Text =   string.Join(Environment.NewLine, Enumerable.Range(0, (Cursos.Length + 59) / 60).Select(i => Cursos.Substring(i * 60, Math.Min(60, Cursos.Length - i * 60))));
                this.lblTurno.Text = string.Join(Environment.NewLine, Enumerable.Range(0, (Turnos.Length + 24) / 25).Select(i => Turnos.Substring(i * 20, Math.Min(20, Turnos.Length - i * 25))));
                this.lblCodigoCarnet.Text = this.txtCarnetEstudiante.Text;
                this.labelHorario.Text = string.Join(Environment.NewLine, Enumerable.Range(0, (Horarios.Length + 24) / 25).Select(i => Horarios.Substring(i * 20, Math.Min(20, Horarios.Length - i * 25))));
                this.labelSucursal.Text = this.txtSucursal.Text;
                DateTime fechaActual = DateTime.Now;

                // Sumarle 1 año a la fecha actual
                DateTime fechaVencimiento = fechaActual.AddYears(1);

                this.lblFechaEmision.Text = fechaActual.ToShortDateString();
                this.lblFechaVencimiento.Text = fechaVencimiento.ToShortDateString();

               
                this.GenerarCodigoBarraEstudiante(this.txtCarnetEstudiante.Text);
                // Obtener la fecha actual

                this.GenerarCodigoImpresionCarnet();
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



        private void GenerarCodigoImpresionCarnet()
        {

            try
            {
                // Crear un Bitmap del tamaño especificado
                int ancho = 638;
                int alto = 1013;
                Bitmap imagenGuardada = new Bitmap(ancho, alto);
                string fecha = DateTime.Now.ToString("ddMMyyyy");

                // Crear un objeto Graphics para dibujar los controles en el Bitmap

                using (Graphics g = Graphics.FromImage(imagenGuardada))
                {
                    // Fondo blanco
                    g.Clear(Color.White);

                    // Dibujar el PictureBox principal (asumiendo que su imagen está asignada)
                    if (PictureBoxCarnet.Image != null)
                    {
                        g.DrawImage(PictureBoxCarnet.Image, 0, 0, PictureBoxCarnet.Width, PictureBoxCarnet.Height);
                    }

                    // Dibujar los otros PictureBox (debes posicionarlos como se muestra en el formulario)
                   

                    if (pictureBoxBarcode.Image != null)
                    {
                        g.DrawImage(pictureBoxBarcode.Image, pictureBoxBarcode.Location.X, pictureBoxBarcode.Location.Y, pictureBoxBarcode.Width, pictureBoxBarcode.Height);
                    }


                    // Dibujar los Labels (puedes agregar más labels si es necesario)
                    g.DrawString(lblNombres.Text, lblNombres.Font, Brushes.Navy, lblNombres.Location);
                    g.DrawString(lblApellidos.Text, lblApellidos.Font, Brushes.Navy, lblApellidos.Location);
                    g.DrawString(lblcurso.Text, lblcurso.Font, Brushes.Navy, lblcurso.Location);
                    g.DrawString(lblCodigoCarnet.Text, lblCodigoCarnet.Font, Brushes.Navy, lblCodigoCarnet.Location);
                    g.DrawString(lblFechaEmision.Text, lblFechaEmision.Font, Brushes.Navy, lblFechaEmision.Location);
                    g.DrawString(labelHorario.Text,labelHorario.Font,Brushes.Navy,labelHorario.Location);
                    g.DrawString(lblFechaVencimiento.Text, lblFechaVencimiento.Font, Brushes.Navy, lblFechaVencimiento.Location);
                    g.DrawString(lblTurno.Text, lblTurno.Font, Brushes.Navy, lblTurno.Location);
                    g.DrawString(labelSucursal.Text,labelSucursal.Font,Brushes.Navy,labelSucursal.Location);
                    // Añadir más labels según sea necesario
                }

                string NombreImagen = "Carnet_" + txtNombres.Text + "_" + this.txtApellidos.Text + "_" + fecha;

                // Mostrar un cuadro de diálogo para seleccionar el lugar de guardado
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Archivos PNG|*.png|Archivos JPG|*.jpg|Archivos JPEG|*.jpeg",
                    FileName = NombreImagen,
                    Title = "Guardar imagen como"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Guardar la imagen en el formato seleccionado
                    string archivoGuardado = saveFileDialog.FileName;

                    // Guardar la imagen como PNG, JPG o JPEG
                    string extension = System.IO.Path.GetExtension(archivoGuardado).ToLower();
                    switch (extension)
                    {
                        case ".png":
                            imagenGuardada.Save(archivoGuardado, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        case ".jpg":
                        case ".jpeg":
                            imagenGuardada.Save(archivoGuardado, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        default:
                            MessageBox.Show("Formato no soportado","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            break;
                    }

                    MessageBox.Show("Imagen guardada correctamente", "SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Information);


                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                this.cmbBusquedas.Text = "Carnet";

                this.txtbusqueda.Text = string.Empty;
                if (this.cmbBusquedas.Text == "Carnet")
                {
                    this.MostrarPorCarnet();

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
                if (e.ColumnIndex == dataEstudiantes.Columns["Movimientos"].Index && e.RowIndex >= 0)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    // Cargar el ícono desde recursos (recomendado) o archivo
                    Bitmap icon = Properties.Resources.historial_de_pedidos; // Usa tu recurso de imagen
                    int iconWidth = 16;
                    int iconHeight = 16;

                    // Posición centrada en la celda
                    int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                    int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                    e.Graphics.DrawImage(icon, new Rectangle(x, y, iconWidth, iconHeight));
                    e.Handled = true; // Indica que la celda está completamente pintada
                }
                else if (e.ColumnIndex == dataEstudiantes.Columns["Detalle"].Index && e.RowIndex >= 0)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    // Cargar el ícono desde recursos (recomendado) o archivo
                    Bitmap icon = Properties.Resources.archivo; // Usa tu recurso de imagen
                    int iconWidth = 16;
                    int iconHeight = 16;

                    // Posición centrada en la celda
                    int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                    int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                    e.Graphics.DrawImage(icon, new Rectangle(x, y, iconWidth, iconHeight));
                    e.Handled = true; // Indica que la celda está completamente pintada
                }
                else if (e.ColumnIndex == dataEstudiantes.Columns["Actualizar"].Index && e.RowIndex >= 0)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    // Cargar el ícono desde recursos (recomendado) o archivo
                    Bitmap icon = Properties.Resources.archivo__1_; // Usa tu recurso de imagen
                    int iconWidth = 16;
                    int iconHeight = 16;

                    // Posición centrada en la celda
                    int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                    int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                    e.Graphics.DrawImage(icon, new Rectangle(x, y, iconWidth, iconHeight));
                    e.Handled = true; // Indica que la celda está completamente pintada
                }
                else if (e.ColumnIndex == dataEstudiantes.Columns["Cambiar"].Index && e.RowIndex >= 0)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    // Cargar el ícono desde recursos (recomendado) o archivo
                    Bitmap icon = Properties.Resources.actualizar_accion; // Usa tu recurso de imagen
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CN_Bajas objetoCN = new CN_Bajas();
                string nombrePC = Environment.MachineName;
                objetoCN.Insertar(this.cmbConceptoBaja.Text, this.txtmotivo.Text, FechaActual,IdMatriculaEst, CacheUsuario.IdUsuario, nombrePC);
                objetoCN.DarBaja(IdMatriculaEst);

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
            this.txtmotivo.Text = string.Empty;
            this.cmbConceptoBaja.Text = string.Empty;
            IdMatriculaEst = string.Empty;
        }

    }

}






