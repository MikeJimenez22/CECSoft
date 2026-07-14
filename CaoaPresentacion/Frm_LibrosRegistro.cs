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

namespace CaoaPresentacion
{
    public partial class Frm_LibrosRegistro : Form
    {
        bool Editar;
        public Frm_LibrosRegistro()
        {
            InitializeComponent();
            cbTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
            DataGridViewConfigurator.Configure(dataLibros);

            this.CargarTiposDocumentos();
            
        }

        private void Frm_LibrosRegistro_Load(object sender, EventArgs e)
        {
            try
            {
                Editar = false;
                this.AgregarColumnaConIcono();
                ListarLibros("");
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListarLibros(string Buscar)
        {
            try
            {
                CN_Libros ObjetoCN = new CN_Libros();
                this.dataLibros.DataSource = ObjetoCN.ListarLibros(Buscar);
                this.dataLibros.Columns["IdLibro"].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ListarLibros(txtBuscar.Text);
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
                Editar = false;
                this.tabControl1.SelectedTab = tabPage2;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Editar == false)
                {
                    if (this.txtNombreLibro.Text == string.Empty)
                    {
                        MessageBox.Show("Ingrese Nombre del Libro", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }else if (this.txtTomo.Text == string.Empty  || this.txtTomo.Text == "0")
                    {
                        MessageBox.Show("Ingrese un Numero de Tomo valido", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }else
                    {
                        CN_Libros ObjetoCN = new CN_Libros();
                        ObjetoCN.InsertarlibroRegistro(this.txtNombreLibro.Text,this.txtTomo.Text,this.txtObservaciones.Text,Convert.ToInt32(cbTipoDocumento.SelectedValue));
                        MessageBox.Show("Registrado Correctamente","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        this.txtBuscar.Text = string.Empty;
                        ListarLibros("");
                        this.tabControl1.SelectedTab = tabPage1;
                        this.Limpiar();
                        Editar = false;
                    }


                }else if (Editar == true)
                {
                    if (this.txtNombreLibro.Text == string.Empty)
                    {
                        MessageBox.Show("Ingrese Nombre del Libro", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (this.txtTomo.Text == string.Empty || this.txtTomo.Text == "0")
                    {
                        MessageBox.Show("Ingrese un Numero de Tomo valido", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }else
                    {
                        CN_Libros ObjetoCN = new CN_Libros();
                        ObjetoCN.EditarlibroRegistro(this.txtIdLibro.Text,this.txtNombreLibro.Text,this.txtTomo.Text,this.txtObservaciones.Text);
                        MessageBox.Show("Actualizado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtBuscar.Text = string.Empty;
                        ListarLibros("");
                        this.tabControl1.SelectedTab = tabPage1;
                        this.Limpiar();
                        Editar = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTomo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir únicamente números y la tecla Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Limpiar()
        {
            this.txtNombreLibro.Text = string.Empty;
            this.txtTomo.Text = string.Empty;
            this.txtObservaciones.Text = string.Empty;
            
        }

        private void AgregarColumnaConIcono()
        {
            try
            {
                DataGridViewButtonColumn btnColumna1 = new DataGridViewButtonColumn();
                btnColumna1.HeaderText = "Abrir";
                btnColumna1.Name = "Abrir";
                btnColumna1.Text = "";
                btnColumna1.UseColumnTextForButtonValue = false;

                dataLibros.Columns.Add(btnColumna1);

                DataGridViewButtonColumn btnColumna2 = new DataGridViewButtonColumn();
                btnColumna2.HeaderText = "Cerrar";
                btnColumna2.Name = "Cerrar";
                btnColumna2.Text = "";
                btnColumna2.UseColumnTextForButtonValue = false;

                dataLibros.Columns.Add(btnColumna2);

                DataGridViewButtonColumn btnColumna3 = new DataGridViewButtonColumn();
                btnColumna3.HeaderText = "Editar";
                btnColumna3.Name = "Editar";
                btnColumna3.Text = "";
                btnColumna3.UseColumnTextForButtonValue = false;

                dataLibros.Columns.Add(btnColumna3);

                DataGridViewButtonColumn btnColumna4 = new DataGridViewButtonColumn();
                btnColumna4.HeaderText = "Anular";
                btnColumna4.Name = "Anular";
                btnColumna4.Text = "";
                btnColumna4.UseColumnTextForButtonValue = false;

                dataLibros.Columns.Add(btnColumna4);

                dataLibros.CellPainting += dataLibros_CellPainting;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "ControlPlus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataLibros_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataLibros.Columns["Abrir"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, false);

                // Abrir
                using (SolidBrush brush = new SolidBrush(Color.SeaGreen))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }

                Bitmap icon = Properties.Resources.abrir_paginas_de_libros_en_blanco;

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

            if (e.ColumnIndex == dataLibros.Columns["Cerrar"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, false);
                // Cerrar
                using (SolidBrush brush = new SolidBrush(Color.DarkOrange))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }

                Bitmap icon = Properties.Resources.libro;

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


            if (e.ColumnIndex == dataLibros.Columns["Editar"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, false);

                // Editar
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

            if (e.ColumnIndex == dataLibros.Columns["Anular"].Index && e.RowIndex >= 0)
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
        }

        private void dataLibros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Evitar clic en encabezado
                {
                    if (e.ColumnIndex == dataLibros.Columns["Abrir"].Index)
                    {
                      string IdLibro = this.dataLibros.CurrentRow.Cells["IdLibro"].Value.ToString();
                        string Estado = this.dataLibros.CurrentRow.Cells["Estado"].Value.ToString();
                        CN_Libros ObjetoCN = new CN_Libros();
                        if (Estado == "ABIERTO")
                        {
                            MessageBox.Show("El Libro ya se encuentra Abierto","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        }else if (Estado == "CERRADO")
                        {
                            ObjetoCN.AbrirLibro(IdLibro);
                            MessageBox.Show("Libro Abierto Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.ListarLibros("");
                        }else if (Estado == "ANULADO")
                        {
                            MessageBox.Show("Error, este libro esta Anulado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                    if (e.ColumnIndex == dataLibros.Columns["Cerrar"].Index)
                    {
                        string IdLibro = this.dataLibros.CurrentRow.Cells["IdLibro"].Value.ToString();
                        string Estado = this.dataLibros.CurrentRow.Cells["Estado"].Value.ToString();
                        CN_Libros ObjetoCN = new CN_Libros();
                        if (Estado == "ABIERTO")
                        {
                         
                            ObjetoCN.CerrarLibro(IdLibro);
                            MessageBox.Show("Libro Cerrado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.ListarLibros("");

                        }
                        else if (Estado == "CERRADO")
                        {
                            MessageBox.Show("El Libro ya se encuentra Cerrado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else if (Estado == "ANULADO")
                        {
                            MessageBox.Show("Error, este libro esta Anulado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }


                    if (e.ColumnIndex == dataLibros.Columns["Editar"].Index)
                    {
                        txtIdLibro.Text = this.dataLibros.CurrentRow.Cells["IdLibro"].Value.ToString();
                        txtNombreLibro.Text = this.dataLibros.CurrentRow.Cells["NombreLibro"].Value.ToString();
                        txtTomo.Text = this.dataLibros.CurrentRow.Cells["Tomo"].Value.ToString();
                        txtObservaciones.Text = this.dataLibros.CurrentRow.Cells["Observaciones"].Value.ToString();
                        this.cbTipoDocumento.SelectedValue = this.dataLibros.CurrentRow.Cells["IdTipoDocumento"].Value;
                        this.cbTipoDocumento.Enabled = false;

                        Editar = true;
                        this.tabControl1.SelectedTab = tabPage2;
                    }

                    if (e.ColumnIndex == dataLibros.Columns["Anular"].Index)
                    {
                        txtIdLibro.Text = this.dataLibros.CurrentRow.Cells["IdLibro"].Value.ToString();
                        CN_Libros ObjetoCN = new CN_Libros();
                        ObjetoCN.AnularLibro(this.txtIdLibro.Text);
                        MessageBox.Show("Libro Anulado correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtBuscar.Text = string.Empty;
                        this.ListarLibros("");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Frm_LibrosRegistro frm = new Frm_LibrosRegistro();
            frm.Show();
            this.Close();
        }
    }
}
