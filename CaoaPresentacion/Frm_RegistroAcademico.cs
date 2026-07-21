using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using System.Data.SqlClient;
using Utils;
using System.Globalization;
using System.Diagnostics;
using PdfSharp.Drawing;
using PdfSharp.Pdf;


namespace CaoaPresentacion
{
    public partial class Frm_RegistroAcademico : Form
    {
        private enum OrigenEdicion
        {
            Ninguno,
            ConsultaGeneral,
            ConsultaPorLibro
        }

        private OrigenEdicion origenActual = OrigenEdicion.Ninguno;

        public Frm_RegistroAcademico()
        {
            InitializeComponent();
            cbTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLibroRegistro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLibroRegistro2.DropDownStyle = ComboBoxStyle.DropDownList;

            DataGridViewConfigurator.Configure(this.dataFacturas,dataConsultaInformacionAcademica);
            CargarTiposDocumentos();
            CargarLibrosBusqueda();
        }

        private void Frm_RegistroAcademico_Load(object sender, EventArgs e)
        {
            try
            {
                this.AgregarColumnaConIcono();

                dpFechaBusqueda.Enabled = false;
                chkFiltrarFecha.Checked = false;

                this.cmbBusqueda.Text = "CODIGO MATRICULA";
                this.ConsultaGeneralRegistroAcademico(this.cmbBusqueda.Text,this.txtBusquedaConsultaAcademica.Text);
                
                string Fecha = DateTime.Now.ToShortDateString();

                this.dtFechaDocumento.Text = Fecha;
                this.txtFechaDocumento.Text = Fecha;

                txtEstadoLibro.ReadOnly = true;
                txtEstadoLibro.ForeColor = Color.Green;

                txtNumeroRegistro.ReadOnly = true;
                txtNumeroRegistro.ForeColor = Color.SteelBlue;

                txtCodigoDocumento.ReadOnly = true;
                txtCodigoDocumento.ForeColor = Color.SteelBlue;

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

       

        private void cbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbTipoDocumento.Text == "-- Seleccione --")
                {
                    LimpiarInformacionRegistro();
                   

                }

                if (cbTipoDocumento.SelectedValue.ToString() != null)
                {

                    string idTipoDocumento = cbTipoDocumento.SelectedValue.ToString();
                    this.CargarLibrosPorTipoDocumento(idTipoDocumento);

                   

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarTiposDocumentos()
        {
            try
            {
                CN_TiposDocumento objetoCN = new CN_TiposDocumento();

                DataTable dt = objetoCN.CargaTiposDocumentos();

                DataRow fila = dt.NewRow();
                fila["IdTipoDocumento"] = 0;
                fila["NombreDocumento"] = "-- Seleccione --";

                dt.Rows.InsertAt(fila, 0);

                cbTipoDocumento.ValueMember = "IdTipoDocumento";
                cbTipoDocumento.DisplayMember = "NombreDocumento";
                cbTipoDocumento.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        public void CargarLibrosPorTipoDocumento(string idTipoDocumento)
        {
            try
            {
                CN_Libros objLibros = new CN_Libros();

                DataTable dt = objLibros.CargarLibrosPorTipoDocumento(Convert.ToInt32(idTipoDocumento));

                DataRow fila = dt.NewRow();
                fila["IdLibro"] = 0;
                fila["Libro"] = "-- Seleccione --";
                dt.Rows.InsertAt(fila, 0);

                cbLibroRegistro.ValueMember = "IdLibro";
                cbLibroRegistro.DisplayMember = "Libro";
                cbLibroRegistro.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void CargarLibrosBusqueda()
        {
            try
            {
                CN_Libros objLibros = new CN_Libros();

                DataTable dt = objLibros.CargarLibros();

                DataRow fila = dt.NewRow();
                fila["IdLibro"] = 0;
                fila["Libro"] = "-- Seleccione --";
                dt.Rows.InsertAt(fila, 0);

                cbLibroRegistro2.ValueMember = "IdLibro";
                cbLibroRegistro2.DisplayMember = "Libro";
                cbLibroRegistro2.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerDatosRegistro()
        {
            try
            {
                CN_Libros obj = new CN_Libros();

                DataTable dt = obj.ObtenerSiguienteRegistro(
                    Convert.ToInt32(cbLibroRegistro.SelectedValue),
                    Convert.ToInt32(cbTipoDocumento.SelectedValue));

                if (dt.Rows.Count > 0)
                {
                    txtEstadoLibro.Text = dt.Rows[0]["Estado"].ToString();
                    txtNumeroRegistro.Text = dt.Rows[0]["SiguienteRegistro"].ToString();
                    txtCodigoDocumento.Text = dt.Rows[0]["CodigoDocumento"].ToString();

                    txtSiguienteRegistro.Text = txtNumeroRegistro.Text;
                    txtCodDocumento.Text = this.txtCodigoDocumento.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbLibroRegistro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbLibroRegistro.Text == "-- Seleccione --")
            {
                LimpiarInformacionRegistro();
            }

            if (cbLibroRegistro.SelectedValue == null)
                return;

            if (cbLibroRegistro.SelectedValue.ToString() == "0")
                return;

            ObtenerDatosRegistro();
            this.txtLibroTomo.Text = cbLibroRegistro.Text;
            this.txtTipoDocumento.Text = cbTipoDocumento.Text;
        }

        private void LimpiarInformacionRegistro()
        {
            this.txtEstadoLibro.Text = string.Empty;
            this.txtNumeroRegistro.Text = string.Empty;
            this.txtCodigoDocumento.Text = string.Empty;
            this.txtTipoDocumento.Text = string.Empty;
            this.txtLibroTomo.Text = string.Empty;
            this.txtSiguienteRegistro.Text = string.Empty;
            this.txtCodDocumento.Text = string.Empty;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ObtenerInformacionMatricula(this.txtCodMatricula.Text);
        }

        private void ObtenerInformacionMatricula(string CodMatricula)
        {
            try
            {
                CN_Matriculas ObjetoCN = new CN_Matriculas();
                DataTable tb = new DataTable();
                tb = ObjetoCN.ObtenerInformacionMatricula(CodMatricula);
                if (tb.Rows.Count > 0)
                {
                    this.txtIdMatricula.Text = tb.Rows[0][0].ToString();
                    string Estudiante = tb.Rows[0][1].ToString();
                    this.txtNombreCompleto.Text = Estudiante;
                    this.txtEstudiante.Text = Estudiante;
                    this.txtCedula.Text = tb.Rows[0][2].ToString();
                    this.txtCodigoMatricula.Text = tb.Rows[0][3].ToString();
                    this.txtCurso.Text = tb.Rows[0][4].ToString();
                    this.txtSucursal.Text = tb.Rows[0][5].ToString();
                    this.txtFechaFinalizacion.Text = Convert.ToDateTime(tb.Rows[0][6].ToString()).ToShortDateString();
                }else if (tb.Rows.Count == 0)
                {
                    MessageBox.Show("Matricula no Encontrada","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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
                if (this.txtCodigoMatricula.Text == string.Empty)
                {
                    MessageBox.Show(
                    "No se ha seleccionado ninguna matrícula. Busque una matrícula para continuar con el proceso.",
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    return;
                }

                ObtenerPagosEstudiante(txtCodigoMatricula.Text);
                this.tabControl1.SelectedTab = tabFactura;

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerPagosEstudiante(string CodMatricula)
        {
            try
            {
                CN_Factura ObjetoCN = new CN_Factura();
                dataFacturas.DataSource = ObjetoCN.MostrarPagosEstudiante(CodMatricula);
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = tabRegistro;
        }


        private void AgregarColumnaConIcono()
        {
            try
            {
                DataGridViewButtonColumn btnColumna1 = new DataGridViewButtonColumn();
                btnColumna1.HeaderText = "Seleccionar";
                btnColumna1.Name = "Seleccionar";
                btnColumna1.Text = "";
                btnColumna1.UseColumnTextForButtonValue = false;

                dataFacturas.Columns.Add(btnColumna1);

                DataGridViewButtonColumn btnColumna2 = new DataGridViewButtonColumn();
                btnColumna2.HeaderText = "Editar";
                btnColumna2.Name = "Editar";
                btnColumna2.Text = "";
                btnColumna2.UseColumnTextForButtonValue = false;

                dataConsultaInformacionAcademica.Columns.Add(btnColumna2);

                DataGridViewButtonColumn btnColumna3 = new DataGridViewButtonColumn();
                btnColumna3.HeaderText = "Editar";
                btnColumna3.Name = "Editar";
                btnColumna3.Text = "";
                btnColumna3.UseColumnTextForButtonValue = false;

                dataRegistrosPorUbicacion.Columns.Add(btnColumna3);

                DataGridViewButtonColumn btnColumna4 = new DataGridViewButtonColumn();
                btnColumna4.HeaderText = "Anular";
                btnColumna4.Name = "Anular";
                btnColumna4.Text = "";
                btnColumna4.UseColumnTextForButtonValue = false;

                dataConsultaInformacionAcademica.Columns.Add(btnColumna4);

                DataGridViewButtonColumn btnColumna5 = new DataGridViewButtonColumn();
                btnColumna5.HeaderText = "Anular";
                btnColumna5.Name = "Anular";
                btnColumna5.Text = "";
                btnColumna5.UseColumnTextForButtonValue = false;

                dataRegistrosPorUbicacion.Columns.Add(btnColumna5);

                DataGridViewButtonColumn btnColumna6 = new DataGridViewButtonColumn();
                btnColumna6.HeaderText = "Diploma";
                btnColumna6.Name = "Diploma";
                btnColumna6.Text = "";
                btnColumna6.UseColumnTextForButtonValue = false;

                dataConsultaInformacionAcademica.Columns.Add(btnColumna6);



                DataGridViewButtonColumn btnColumna7 = new DataGridViewButtonColumn();
                btnColumna7.HeaderText = "Diploma";
                btnColumna7.Name = "Diploma";
                btnColumna7.Text = "";
                btnColumna7.UseColumnTextForButtonValue = false;

                dataRegistrosPorUbicacion.Columns.Add(btnColumna7);




                dataFacturas.CellPainting += dataFacturas_CellPainting;
                dataConsultaInformacionAcademica.CellPainting += dataConsultaInformacionAcademica_CellPainting;
                dataRegistrosPorUbicacion.CellPainting += dataRegistrosPorUbicacion_CellPainting;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "ControlPlus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataFacturas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataFacturas.Columns["Seleccionar"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, false);

                using (SolidBrush brush = new SolidBrush(Color.DodgerBlue))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }

                Bitmap icon = Properties.Resources.edit_button;

                int iconWidth = 16;
                int iconHeight = 16;

                int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                e.Graphics.DrawImage(icon, new Rectangle(x, y, iconWidth, iconHeight));

                // Borde
                e.Graphics.DrawRectangle(Pens.White,
                    e.CellBounds.Left,
                    e.CellBounds.Top,
                    e.CellBounds.Width - 1,
                    e.CellBounds.Height - 1);

                e.Handled = true;
            }
        }

        private void dataFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Evitar clic en encabezado
                {
                    if (e.ColumnIndex == dataFacturas.Columns["Seleccionar"].Index)
                    {
                        string NumFactura = this.dataFacturas.CurrentRow.Cells["Num_Factura"].Value.ToString();

                        this.txtFacturaDocumento.Text = NumFactura;
                        this.txtFactura.Text = NumFactura;

                        this.tabControl1.SelectedTab = tabRegistro;


                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFolio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir teclas de control (Backspace, Supr, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Permitir únicamente números
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_RegistroAcademico frm = new Frm_RegistroAcademico();
                frm.Show();
                this.Close();
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
                if (string.IsNullOrWhiteSpace(txtCodigoMatricula.Text))
                {
                    MessageBox.Show(
                        "Debe seleccionar una matrícula.",
                        "SISTEMA CECNIC",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (cbLibroRegistro.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar el libro.",
                        "SISTEMA CECNIC",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    cbLibroRegistro.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtFolio.Text))
                {
                    MessageBox.Show(
                        "Debe ingresar el folio.",
                        "SISTEMA CECNIC",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtFolio.Focus();
                    return;
                }

                if (!int.TryParse(txtFolio.Text, out int folio))
                {
                    MessageBox.Show(
                        "El folio debe ser un número entero.",
                        "SISTEMA CECNIC",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtFolio.Focus();
                    return;
                }

                if (folio < 1 || folio > 200)
                {
                    MessageBox.Show(
                        "El folio debe estar entre 1 y 200.",
                        "SISTEMA CECNIC",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtFolio.Focus();
                    txtFolio.SelectAll();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtFacturaDocumento.Text))
                {
                    MessageBox.Show(
                        "Debe ingresar el número de factura.",
                        "SISTEMA CECNIC",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtFacturaDocumento.Focus();
                    return;
                }


                DialogResult respuesta = MessageBox.Show(
                    "¿Está seguro de registrar este documento?",
                    "SISTEMA CECNIC",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.No)
                    return;


                int idRegistro;
                int numeroRegistro;
                string codigoDocumentoGenerado;
                string nombreEstudiante;
                int folioGenerado;
                DateTime fechaDocumentoGenerada;
                string libroTomo;


                int IdMatricula = Convert.ToInt32(txtIdMatricula.Text);
                DateTime FechaFinalizacion = Convert.ToDateTime(txtFechaFinalizacion.Text);

                CN_Libros ObjetoCN = new CN_Libros();


                ObjetoCN.InsertarRegistroAcademico(
                    txtCodigoDocumento.Text.Trim(),
                    Convert.ToInt32(cbTipoDocumento.SelectedValue),
                    Convert.ToInt32(cbLibroRegistro.SelectedValue),
                    folio,
                    dtFechaDocumento.Value.Date,
                    IdMatricula,
                    txtFacturaDocumento.Text.Trim(),
                    txtNombreCompleto.Text.Trim(),
                    txtCedula.Text.Trim(),
                    txtCodigoMatricula.Text.Trim(),
                    txtCurso.Text.Trim(),
                    txtSucursal.Text.Trim(),
                    FechaFinalizacion,
                    txtObservaciones.Text.Trim(),
                    Convert.ToInt32(CacheUsuario.IdUsuario),
                    out idRegistro,
                    out numeroRegistro,
                    out codigoDocumentoGenerado,
                    out nombreEstudiante,
                    out folioGenerado,
                    out fechaDocumentoGenerada,
                    out libroTomo);


                txtNumeroRegistro.Text = numeroRegistro.ToString();


                MessageBox.Show(
                    "Registro Académico realizado correctamente.\n\n" +
                    "Código Documento : " + codigoDocumentoGenerado + "\n" +
                    "Registro          : " + numeroRegistro + "\n" +
                    "Libro             : " + libroTomo + "\n" +
                    "Folio             : " + folioGenerado + "\n" +
                    "Estudiante        : " + nombreEstudiante,
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                Frm_RegistroAcademico frm = new Frm_RegistroAcademico();
                frm.Show();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txtFolio_TextChanged(object sender, EventArgs e)
        {
            txtFolioResumen.Text = txtFolio.Text;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                ConsultaGeneralRegistroAcademico(this.cmbBusqueda.Text,this.txtBusquedaConsultaAcademica.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex.Message, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConsultaGeneralRegistroAcademico(string TipoBusqueda,string ValorBusqueda)
        {
            try
            {
                CN_Libros ObjetoCN = new CN_Libros();
                dataConsultaInformacionAcademica.DataSource = ObjetoCN.ConsultaGeneralRegistroAcademico(TipoBusqueda,ValorBusqueda);
                dataConsultaInformacionAcademica.Columns["IdRegistro"].Visible = false;
                label28.Text = "Total de Registros: " + dataConsultaInformacionAcademica.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex.Message, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buquedaRapidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabBuscarRegistros;
        }

        private void nuevoRegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabRegistro;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir teclas de control (Backspace, Supr, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Permitir únicamente números
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbLibroRegistro2.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar un libro.",
                        "SISTEMA CECNIC",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                int idLibro = Convert.ToInt32(cbLibroRegistro2.SelectedValue);


                int? folio = null;

                if (!string.IsNullOrWhiteSpace(txtFolioBusqueda.Text))
                {
                    if (!int.TryParse(txtFolioBusqueda.Text, out int numeroFolio))
                    {
                        MessageBox.Show(
                            "El folio debe ser un número válido.",
                            "SISTEMA CECNIC",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        txtFolioBusqueda.Focus();
                        return;
                    }

                    folio = numeroFolio;
                }


                DateTime? fecha = null;

                if (chkFiltrarFecha.Checked)
                {
                    fecha = dpFechaBusqueda.Value.Date;
                }


                ConsultaPorLibroRegistro(idLibro, folio, fecha);

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error de Sistema\n\n" + ex.Message,
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ConsultaPorLibroRegistro(int IdLibro, int? Folio, DateTime? Fecha)
        {
            try
            {
                CN_Libros ObjetoCN = new CN_Libros();

                dataRegistrosPorUbicacion.DataSource =
                    ObjetoCN.ConsultaPorLibroRegistro(
                        IdLibro,
                        Folio,
                        Fecha);
                this.dataRegistrosPorUbicacion.Columns["IdRegistro"].Visible = false;

                this.label33.Text = "Total de Registros: " + dataRegistrosPorUbicacion.Rows.Count;


            }
            catch (Exception ex)
            {
                MessageBox.Show(
            ex.Message,
            "SISTEMA CECNIC",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
            }
        }

        private void busquedaDeUbicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabBuscarPorUbicacion;
        }

        private void dataConsultaInformacionAcademica_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataConsultaInformacionAcademica.Columns["Editar"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, false);

                using (SolidBrush brush = new SolidBrush(Color.DodgerBlue))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }

                Bitmap icon = Properties.Resources.edit_button;

                int iconWidth = 16;
                int iconHeight = 16;

                int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                e.Graphics.DrawImage(icon, new Rectangle(x, y, iconWidth, iconHeight));

                // Borde
                e.Graphics.DrawRectangle(Pens.White,
                    e.CellBounds.Left,
                    e.CellBounds.Top,
                    e.CellBounds.Width - 1,
                    e.CellBounds.Height - 1);

                e.Handled = true;
            }

            if (e.ColumnIndex == dataConsultaInformacionAcademica.Columns["Anular"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, false);

                // Anular
                using (SolidBrush brush = new SolidBrush(Color.Firebrick))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }

                Bitmap icon = Properties.Resources.nulo;

                int iconWidth = 16;
                int iconHeight = 16;

                int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                e.Graphics.DrawImage(icon, new Rectangle(x, y, iconWidth, iconHeight));

                // Borde
                e.Graphics.DrawRectangle(Pens.White,
                    e.CellBounds.Left,
                    e.CellBounds.Top,
                    e.CellBounds.Width - 1,
                    e.CellBounds.Height - 1);

                e.Handled = true;
            }

            if (e.ColumnIndex == dataConsultaInformacionAcademica.Columns["Diploma"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, false);

                using (SolidBrush brush = new SolidBrush(Color.DodgerBlue))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }

                Bitmap icon = Properties.Resources.ganador;

                int iconWidth = 16;
                int iconHeight = 16;

                int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                e.Graphics.DrawImage(icon, new Rectangle(x, y, iconWidth, iconHeight));

                // Borde
                e.Graphics.DrawRectangle(Pens.White,
                    e.CellBounds.Left,
                    e.CellBounds.Top,
                    e.CellBounds.Width - 1,
                    e.CellBounds.Height - 1);

                e.Handled = true;
            }
        }

        private void dataRegistrosPorUbicacion_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataRegistrosPorUbicacion.Columns["Editar"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, false);

                using (SolidBrush brush = new SolidBrush(Color.DodgerBlue))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }

                Bitmap icon = Properties.Resources.edit_button;

                int iconWidth = 16;
                int iconHeight = 16;

                int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                e.Graphics.DrawImage(icon, new Rectangle(x, y, iconWidth, iconHeight));

                // Borde
                e.Graphics.DrawRectangle(Pens.White,
                    e.CellBounds.Left,
                    e.CellBounds.Top,
                    e.CellBounds.Width - 1,
                    e.CellBounds.Height - 1);

                e.Handled = true;
            }

            if (e.ColumnIndex == dataRegistrosPorUbicacion.Columns["Anular"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, false);

                // Anular
                using (SolidBrush brush = new SolidBrush(Color.Firebrick))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }

                Bitmap icon = Properties.Resources.nulo;

                int iconWidth = 16;
                int iconHeight = 16;

                int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                e.Graphics.DrawImage(icon, new Rectangle(x, y, iconWidth, iconHeight));

                // Borde
                e.Graphics.DrawRectangle(Pens.White,
                    e.CellBounds.Left,
                    e.CellBounds.Top,
                    e.CellBounds.Width - 1,
                    e.CellBounds.Height - 1);

                e.Handled = true;
            }

            if (e.ColumnIndex == dataRegistrosPorUbicacion.Columns["Diploma"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, false);

                using (SolidBrush brush = new SolidBrush(Color.DodgerBlue))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }

                Bitmap icon = Properties.Resources.ganador;

                int iconWidth = 16;
                int iconHeight = 16;

                int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                e.Graphics.DrawImage(icon, new Rectangle(x, y, iconWidth, iconHeight));

                // Borde
                e.Graphics.DrawRectangle(Pens.White,
                    e.CellBounds.Left,
                    e.CellBounds.Top,
                    e.CellBounds.Width - 1,
                    e.CellBounds.Height - 1);

                e.Handled = true;
            }

        }

        private void dataConsultaInformacionAcademica_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Evitar clic en encabezado
                {
                    if (e.ColumnIndex == dataConsultaInformacionAcademica.Columns["Editar"].Index)
                    {
                        origenActual = OrigenEdicion.ConsultaGeneral;
                        CargarRegistroEditar(dataConsultaInformacionAcademica, e.RowIndex);
                        
                    }

                    if (e.ColumnIndex == dataConsultaInformacionAcademica.Columns["Anular"].Index)
                    {
                        origenActual = OrigenEdicion.ConsultaGeneral;
                        CargarIdRegistroAnulacion(dataConsultaInformacionAcademica,e.RowIndex);
                    }

                    if (e.ColumnIndex == dataConsultaInformacionAcademica.Columns["Diploma"].Index)
                    {
                        origenActual = OrigenEdicion.ConsultaGeneral;
                        CargarDatosDiploma(dataConsultaInformacionAcademica, e.RowIndex);

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarRegistroEditar(DataGridView dgv, int rowIndex)
        {
            try
            {
                DataGridViewRow fila = dgv.Rows[rowIndex];

                string Estado = fila.Cells["Estado"].Value?.ToString() ?? "";
                if (Estado == "ANULADO")
                {
                    MessageBox.Show("Este Registro ya se encuentra Anulado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                txtIdRegistro_Edit.Text = fila.Cells["IdRegistro"].Value?.ToString() ?? "";
                txtCodDocumento_Edit.Text = fila.Cells["CodigoDocumento"].Value?.ToString() ?? "";
                txtNumeroRegistro_Edit.Text = fila.Cells["NumeroRegistro"].Value?.ToString() ?? "";
                txtLibro_Edit.Text = fila.Cells["NombreLibro"].Value?.ToString() ?? "";
                txtTomo_Edit.Text = fila.Cells["Tomo"].Value?.ToString() ?? "";
                txtFolio_Edit.Text = fila.Cells["Folio"].Value?.ToString() ?? "";
                txtTipoDocumento_Edit.Text = fila.Cells["TipoDocumento"].Value?.ToString() ?? "";
                txtFechaDocumento_Edit.Text = Convert.ToDateTime(fila.Cells["FechaDocumento"].Value).ToString("dd/MM/yyyy");

                txtEstudiante_Edit.Text = fila.Cells["NombreCompleto"].Value?.ToString() ?? "";
                txtCedula_Edit.Text = fila.Cells["Cedula"].Value?.ToString() ?? "";
                txtMatricula_Edit.Text = fila.Cells["CodigoMatricula"].Value?.ToString() ?? "";
                txtCurso_Edit.Text = fila.Cells["NombreCurso"].Value?.ToString() ?? "";
                txtFactura_Edit.Text = fila.Cells["Num_Factura"].Value?.ToString() ?? "";

                if (fila.Cells["FechaFinalizacionCurso"].Value != DBNull.Value)
                {
                    txtFechaFinalizacion_Edit.Text =
                        Convert.ToDateTime(fila.Cells["FechaFinalizacionCurso"].Value).ToString("dd/MM/yyyy");
                }
                else
                {
                    txtFechaFinalizacion_Edit.Clear();
                }

                txtObservaciones_Edit.Text = fila.Cells["Observaciones"].Value?.ToString() ?? "";

                // Cambiar al Tab de edición
                tabControl1.SelectedTab = tabEditar;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar la información del registro.\n\n" + ex.Message,
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void CargarIdRegistroAnulacion(DataGridView dgv, int rowIndex)
        {
            try
            {
                DataGridViewRow fila = dgv.Rows[rowIndex];
                string Estado =  fila.Cells["Estado"].Value?.ToString() ?? "";
                if (Estado == "ANULADO")
                {
                    MessageBox.Show("Este Registro ya se encuentra Anulado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                txtIdRegistro_Anulacion.Text = fila.Cells["IdRegistro"].Value?.ToString() ?? "";
                tabControl1.SelectedTab = tabAnulacion;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarDatosDiploma(DataGridView dgv, int rowIndex)
        {
            try
            {
                DataGridViewRow fila = dgv.Rows[rowIndex];
                string TipoDocumento = fila.Cells["TipoDocumento"].Value?.ToString() ?? "";
                if (TipoDocumento != "Diploma Cecnic")
                {
                    MessageBox.Show(
                      "La emisión de diplomas desde este módulo está disponible únicamente para los diplomas oficiales emitidos por CECNIC.",
                      "SISTEMA CECNIC",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
                    return;
                }

                this.lblEstudiante_Diploma.Text = fila.Cells["NombreCompleto"].Value?.ToString() ?? "";
                this.lblCurso_Diploma.Text = fila.Cells["NombreCurso"].Value?.ToString() ?? "";
                this.lblRegistro_Diploma.Text = fila.Cells["NumeroRegistro"].Value?.ToString() ?? "";
                this.lblFolio_Diploma.Text = fila.Cells["Folio"].Value?.ToString() ?? "";
                this.lblTomo_Diploma.Text = fila.Cells["Tomo"].Value?.ToString() ?? "";
                this.lblLibro_Diploma.Text = fila.Cells["NombreLibro"].Value?.ToString() ?? "";
                this.lblCodigoDocumento_Diploma.Text = fila.Cells["CodigoDocumento"].Value?.ToString() ?? "";

                DateTime fechaDocumento = Convert.ToDateTime(fila.Cells["FechaDocumento"].Value);

                lblDias_Diploma.Text = fechaDocumento.Day.ToString();

                string mes = fechaDocumento.ToString("MMMM", new CultureInfo("es-ES"));
                lblMes_Diploma.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(mes);

                lblAño_Diploma.Text = fechaDocumento.Year.ToString();

                this.tabControl1.SelectedTab = tabDiploma;

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void dataRegistrosPorUbicacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Evitar clic en encabezado
                {
                    if (e.ColumnIndex == dataRegistrosPorUbicacion.Columns["Editar"].Index)
                    {
                        origenActual = OrigenEdicion.ConsultaPorLibro;
                        CargarRegistroEditar(dataRegistrosPorUbicacion, e.RowIndex);

                    }

                    if (e.ColumnIndex == dataRegistrosPorUbicacion.Columns["Anular"].Index)
                    {
                        origenActual = OrigenEdicion.ConsultaPorLibro;
                        CargarIdRegistroAnulacion(dataRegistrosPorUbicacion, e.RowIndex);
                    }

                    if (e.ColumnIndex == dataRegistrosPorUbicacion.Columns["Diploma"].Index)
                    {
                        origenActual = OrigenEdicion.ConsultaPorLibro;
                        CargarDatosDiploma(dataRegistrosPorUbicacion, e.RowIndex);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            switch (origenActual)
            {
                case OrigenEdicion.ConsultaGeneral:
                    tabControl1.SelectedTab = tabBuscarRegistros;
                    
                    break;

                case OrigenEdicion.ConsultaPorLibro:
                    tabControl1.SelectedTab = tabBuscarPorUbicacion;

                    break;
            }


            LimpiarControlesEdicion();

        }

        private void LimpiarControlesEdicion()
        {
            txtIdRegistro_Edit.Clear();
            txtCodDocumento_Edit.Clear();
            txtNumeroRegistro_Edit.Clear();
            txtLibro_Edit.Clear();
            txtTomo_Edit.Clear();
            txtFolio_Edit.Clear();
            txtTipoDocumento_Edit.Clear();
            txtFechaDocumento_Edit.Clear();
            txtEstudiante_Edit.Clear();
            txtCedula_Edit.Clear();
            txtMatricula_Edit.Clear();
            txtCurso_Edit.Clear();
            txtFactura_Edit.Clear();
            txtFechaFinalizacion_Edit.Clear();
            txtObservaciones_Edit.Clear();
        }


        private void LimpiarControlesAnulacion()
        {
            txtIdRegistro_Anulacion.Clear();
            txtMotivo_Anulacion.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdRegistro_Edit.Text))
                {
                    MessageBox.Show(
                        "No existe un registro seleccionado.",
                        "SISTEMA CECNIC",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Está seguro de actualizar este registro académico?",
                    "SISTEMA CECNIC",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.No)
                    return;

                CN_Libros ObjetoCN = new CN_Libros();

                ObjetoCN.ActualizarRegistroAcademico(
                    Convert.ToInt32(txtIdRegistro_Edit.Text),
                    txtFactura_Edit.Text.Trim(),
                    txtObservaciones_Edit.Text.Trim());

                MessageBox.Show(
                    "Registro Académico actualizado correctamente.",
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                RegresarConsultaOrigen();
                LimpiarControlesEdicion();

                origenActual = OrigenEdicion.Ninguno;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void RegresarConsultaOrigen()
        {
            switch (origenActual)
            {
                case OrigenEdicion.ConsultaGeneral:

                    ConsultaGeneralRegistroAcademico(
                        cmbBusqueda.Text,
                        txtBusquedaConsultaAcademica.Text);

                    tabControl1.SelectedTab = tabBuscarRegistros;
                    break;

                case OrigenEdicion.ConsultaPorLibro:

                    int? folio = null;

                    if (int.TryParse(txtFolioBusqueda.Text.Trim(), out int valorFolio))
                    {
                        folio = valorFolio;
                    }

                    DateTime? fecha = null;

                    if (chkFiltrarFecha.Checked)
                    {
                        fecha = dpFechaBusqueda.Value.Date;
                    }

                    ConsultaPorLibroRegistro(
                        Convert.ToInt32(cbLibroRegistro2.SelectedValue),
                        folio,
                        fecha);

                    tabControl1.SelectedTab = tabBuscarPorUbicacion;
                    break;
            }
        }

        private void chkFiltrarFecha_CheckedChanged(object sender, EventArgs e)
        {
            dpFechaBusqueda.Enabled = chkFiltrarFecha.Checked;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdRegistro_Anulacion.Text))
                {
                    MessageBox.Show(
                        "Debe seleccionar un registro.",
                        "SISTEMA CECNIC",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMotivo_Anulacion.Text))
                {
                    MessageBox.Show(
                        "Debe ingresar el motivo de la anulación.",
                        "SISTEMA CECNIC",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtMotivo_Anulacion.Focus();
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Está seguro de anular este registro académico?\n\nEsta acción no podrá deshacerse.",
                    "SISTEMA CECNIC",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (respuesta == DialogResult.No)
                    return;

                CN_Libros ObjetoCN = new CN_Libros();

                ObjetoCN.AnularRegistroAcademico(
                    Convert.ToInt32(txtIdRegistro_Anulacion.Text),
                    txtMotivo_Anulacion.Text.Trim(),
                    Convert.ToInt32(CacheUsuario.IdUsuario));

                MessageBox.Show(
                    "Registro Académico anulado correctamente.",
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                RegresarConsultaOrigen();
                this.LimpiarControlesAnulacion();
                origenActual = OrigenEdicion.Ninguno;



            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            switch (origenActual)
            {
                case OrigenEdicion.ConsultaGeneral:
                    tabControl1.SelectedTab = tabBuscarRegistros;

                    break;

                case OrigenEdicion.ConsultaPorLibro:
                    tabControl1.SelectedTab = tabBuscarPorUbicacion;

                    break;
            }

            this.LimpiarControlesAnulacion();
            origenActual = OrigenEdicion.Ninguno;



        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                switch (origenActual)
                {
                    case OrigenEdicion.ConsultaGeneral:
                        tabControl1.SelectedTab = tabBuscarRegistros;

                        break;

                    case OrigenEdicion.ConsultaPorLibro:
                        tabControl1.SelectedTab = tabBuscarPorUbicacion;

                        break;
                }

                LimpiarControlesDiploma();

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarControlesDiploma()
        {
            this.lblEstudiante_Diploma.Text = string.Empty;
            this.lblCurso_Diploma.Text = string.Empty;
            this.lblRegistro_Diploma.Text = string.Empty;
            this.lblFolio_Diploma.Text = string.Empty;
            this.lblTomo_Diploma.Text = string.Empty;
            this.lblLibro_Diploma.Text = string.Empty;
            this.lblCodigoDocumento_Diploma.Text = string.Empty;
            lblDias_Diploma.Text = string.Empty;
            lblMes_Diploma.Text = string.Empty;
            lblAño_Diploma.Text = string.Empty;
        }

        private void GenerarImagenDiploma()
        {
            try
            {
                using (Bitmap diploma = CrearBitmapDiploma())
                {
                    SaveFileDialog guardar = new SaveFileDialog();

                    guardar.Title = "Guardar Diploma";

                    guardar.Filter = "Imagen PNG (*.png)|*.png";

                    guardar.FileName =
                        LimpiarNombreArchivo(lblEstudiante_Diploma.Text) + "_" +
                        LimpiarNombreArchivo(lblCodigoDocumento_Diploma.Text) + "_" +
                        DateTime.Now.ToString("yyyy-MM-dd_HH-mm");

                    if (guardar.ShowDialog() != DialogResult.OK)
                        return;

                    diploma.Save(
                        guardar.FileName,
                        ImageFormat.Png);

                    DialogResult abrir = MessageBox.Show(
                        "El diploma fue generado correctamente.\n\n¿Desea abrir la imagen?",
                        "SISTEMA CECNIC",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);

                    RegresarConsultaOrigen();

                    if (abrir == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo()
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
                    ex.Message,
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    


        private string LimpiarNombreArchivo(string texto)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                texto = texto.Replace(c, '_');
            }

            return texto;
        }

        private void DibujarLabel(Graphics g, Label lbl, float escalaX, float escalaY)
        {
            float x = lbl.Left * escalaX;
            float y = lbl.Top * escalaY;

            float ancho = lbl.Width * escalaX;
            float alto = lbl.Height * escalaY;

            using (Font fuente = new Font(
                lbl.Font.FontFamily,
                lbl.Font.Size * escalaX,
                lbl.Font.Style,
                GraphicsUnit.Point))
            {
                using (Brush brocha = new SolidBrush(lbl.ForeColor))
                {
                    StringFormat formato = new StringFormat();

                    switch (lbl.TextAlign)
                    {
                        case ContentAlignment.TopLeft:
                            formato.Alignment = StringAlignment.Near;
                            formato.LineAlignment = StringAlignment.Near;
                            break;

                        case ContentAlignment.TopCenter:
                            formato.Alignment = StringAlignment.Center;
                            formato.LineAlignment = StringAlignment.Near;
                            break;

                        case ContentAlignment.TopRight:
                            formato.Alignment = StringAlignment.Far;
                            formato.LineAlignment = StringAlignment.Near;
                            break;

                        case ContentAlignment.MiddleLeft:
                            formato.Alignment = StringAlignment.Near;
                            formato.LineAlignment = StringAlignment.Center;
                            break;

                        case ContentAlignment.MiddleCenter:
                            formato.Alignment = StringAlignment.Center;
                            formato.LineAlignment = StringAlignment.Center;
                            break;

                        case ContentAlignment.MiddleRight:
                            formato.Alignment = StringAlignment.Far;
                            formato.LineAlignment = StringAlignment.Center;
                            break;

                        case ContentAlignment.BottomLeft:
                            formato.Alignment = StringAlignment.Near;
                            formato.LineAlignment = StringAlignment.Far;
                            break;

                        case ContentAlignment.BottomCenter:
                            formato.Alignment = StringAlignment.Center;
                            formato.LineAlignment = StringAlignment.Far;
                            break;

                        case ContentAlignment.BottomRight:
                            formato.Alignment = StringAlignment.Far;
                            formato.LineAlignment = StringAlignment.Far;
                            break;
                    }

                    RectangleF rect = new RectangleF(
                        x,
                        y,
                        ancho,
                        alto);

                    g.DrawString(
                        lbl.Text,
                        fuente,
                        brocha,
                        rect,
                        formato);
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                GenerarImagenDiploma();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Bitmap CrearBitmapDiploma()
        {
            if (pbDiseñoDiploma.Image == null)
                throw new Exception("No se encontró el diseño del diploma.");

            Bitmap imagenOriginal = new Bitmap(pbDiseñoDiploma.Image);

            Bitmap imagenFinal = new Bitmap(
                imagenOriginal.Width,
                imagenOriginal.Height);

            float escalaX = (float)imagenOriginal.Width / panelDiploma.Width;
            float escalaY = (float)imagenOriginal.Height / panelDiploma.Height;

            using (Graphics g = Graphics.FromImage(imagenFinal))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                // Dibujar el diploma
                g.DrawImage(
                    imagenOriginal,
                    new Rectangle(0, 0, imagenFinal.Width, imagenFinal.Height));

                // Dibujar todos los Labels
                foreach (Label lbl in panelDiploma.Controls.OfType<Label>())
                {
                    DibujarLabel(g, lbl, escalaX, escalaY);
                }
            }

            imagenOriginal.Dispose();

            return imagenFinal;
        }

        private void GenerarPdfDiploma()
        {
            try
            {
                using (Bitmap diploma = CrearBitmapDiploma())
                {
                    SaveFileDialog guardar = new SaveFileDialog();

                    guardar.Title = "Guardar Diploma";

                    guardar.Filter = "Documento PDF (*.pdf)|*.pdf";

                    guardar.FileName =
                        LimpiarNombreArchivo(lblEstudiante_Diploma.Text) + "_" +
                        LimpiarNombreArchivo(lblCodigoDocumento_Diploma.Text) + "_" +
                        DateTime.Now.ToString("yyyy-MM-dd_HH-mm");

                    if (guardar.ShowDialog() != DialogResult.OK)
                        return;

                    string imagenTemporal = Path.Combine(
                        Path.GetTempPath(),
                        Guid.NewGuid().ToString() + ".png");

                    diploma.Save(imagenTemporal, ImageFormat.Png);

                    PdfDocument documento = new PdfDocument();

                    PdfPage pagina = documento.AddPage();

                    pagina.Size = PdfSharp.PageSize.Letter;
                    pagina.Orientation = PdfSharp.PageOrientation.Landscape;

                    using (XGraphics gfx = XGraphics.FromPdfPage(pagina))
                    {
                        using (XImage img = XImage.FromFile(imagenTemporal))
                        {
                            gfx.DrawImage(
                                img,
                                0,
                                0,
                                pagina.Width,
                                pagina.Height);
                        }
                    }

                    documento.Save(guardar.FileName);

                    if (File.Exists(imagenTemporal))
                        File.Delete(imagenTemporal);

                    MessageBox.Show(
                        "Diploma generado correctamente en formato PDF.",
                        "SISTEMA CECNIC",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    RegresarConsultaOrigen();

                    Process.Start(new ProcessStartInfo()
                    {
                        FileName = guardar.FileName,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                GenerarPdfDiploma();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
