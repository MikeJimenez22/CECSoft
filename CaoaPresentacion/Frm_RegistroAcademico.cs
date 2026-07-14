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
using System.Data.SqlClient;
using Utils;


namespace CaoaPresentacion
{
    public partial class Frm_RegistroAcademico : Form
    {
        public Frm_RegistroAcademico()
        {
            InitializeComponent();
            cbTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLibroRegistro.DropDownStyle = ComboBoxStyle.DropDownList;

            DataGridViewConfigurator.Configure(this.dataFacturas);
            CargarTiposDocumentos();
        }

        private void Frm_RegistroAcademico_Load(object sender, EventArgs e)
        {
            try
            {
                this.AgregarColumnaConIcono();
                string Fecha = DateTime.Now.ToShortDateString();

                this.dtpFechaDocumento.Text = Fecha;
                this.txtFechaDocumento.Text = Fecha;
               
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
                    this.CargarLibros(idTipoDocumento);

                   

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

        public void CargarLibros(string idTipoDocumento)
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




                dataFacturas.CellPainting += dataFacturas_CellPainting;
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
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
