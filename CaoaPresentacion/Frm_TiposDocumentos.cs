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
    public partial class Frm_TiposDocumentos : Form
    {

        bool Editar;
        public Frm_TiposDocumentos()
        {
            InitializeComponent();
            DataGridViewConfigurator.Configure(dataDocumentos);

      
        }

        private void Frm_TiposDocumentos_Load(object sender, EventArgs e)
        {
            try
            {
                Editar = false;
                this.AgregarColumnaConIcono();
                ListarDocumentos("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " +ex,"SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void ListarDocumentos(string Buscar)
        {
            try
            {
                CN_TiposDocumento ObjetoCN = new CN_TiposDocumento();
                this.dataDocumentos.DataSource = ObjetoCN.ListarDocumento(Buscar);
                this.dataDocumentos.Columns["IdTipoDocumento"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " +ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarColumnaConIcono()
        {
            try
            {
              

                DataGridViewButtonColumn btnColumna1 = new DataGridViewButtonColumn();
                btnColumna1.HeaderText = "Editar";
                btnColumna1.Name = "Editar";
                btnColumna1.Text = "";
                btnColumna1.UseColumnTextForButtonValue = false;

                dataDocumentos.Columns.Add(btnColumna1);

                // Agregar columna de botón
                DataGridViewButtonColumn btnColumna = new DataGridViewButtonColumn();
                btnColumna.HeaderText = "Actualizar estado";
                btnColumna.Name = "Actualizar";
                btnColumna.Text = ""; // El texto no se usará porque dibujaremos un ícono
                btnColumna.UseColumnTextForButtonValue = false;

                dataDocumentos.Columns.Add(btnColumna);



                dataDocumentos.CellPainting += dataDocumentos_CellPainting;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataDocumentos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
           


            if (e.ColumnIndex == dataDocumentos.Columns["Actualizar"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, false);

                // Editar
                using (SolidBrush brush = new SolidBrush(Color.DodgerBlue))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }
                Bitmap icon = Properties.Resources.procesamiento_de_datos;

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

            if (e.ColumnIndex == dataDocumentos.Columns["Editar"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, false);

                // Editar
                using (SolidBrush brush = new SolidBrush(Color.Orange))
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ListarDocumentos(this.txtBuscar.Text);
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
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Editar == false)
                {
                    if (this.txtNombreDocumento.Text == string.Empty)
                    {
                        MessageBox.Show("Ingrese un Nombre de Documento","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }else
                    {
                        CN_TiposDocumento ObjetoCN = new CN_TiposDocumento();
                        ObjetoCN.InsertarDocumento(this.txtNombreDocumento.Text,this.txtPrefijo.Text);
                        MessageBox.Show("Registrado Correctamente","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        this.txtBuscar.Text = string.Empty;
                        this.ListarDocumentos("");
                        this.tabControl1.SelectedTab = tabPage1;
                        this.Limpiar();

                    }

                }else if (Editar == true)
                {
                    if (this.txtNombreDocumento.Text == string.Empty)
                    {
                        MessageBox.Show("Ingrese un Nombre de Documento", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }else
                    {
                        CN_TiposDocumento ObjetoCN = new CN_TiposDocumento();
                        ObjetoCN.EditarDocumento(this.txtIdDocumento.Text,this.txtNombreDocumento.Text,this.txtPrefijo.Text);
                        MessageBox.Show("Actualizado Correctamente","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        this.txtBuscar.Text = string.Empty;
                        this.ListarDocumentos("");
                        this.tabControl1.SelectedTab = tabPage1;
                        this.Limpiar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void Limpiar()
        {
            try
            {
                this.txtIdDocumento.Text = string.Empty;
                this.txtNombreDocumento.Text = string.Empty;
                this.txtPrefijo.Text = string.Empty;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerarPrefijo(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return string.Empty;

            // Palabras que no se tomarán en cuenta
            string[] excluir =
            {
        "DE","DEL","LA","LAS","EL","LOS",
        "Y","E","PARA","POR","EN"
    };

            List<string> palabras = nombre
                .Trim()
                .ToUpper()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(p => !excluir.Contains(p))
                .ToList();

            if (palabras.Count == 0)
                return string.Empty;

            // Una sola palabra
            if (palabras.Count == 1)
            {
                return palabras[0].Length >= 3
                    ? palabras[0].Substring(0, 3)
                    : palabras[0];
            }

            // Dos palabras
            if (palabras.Count == 2)
            {
                string primera = palabras[0].Length >= 2
                    ? palabras[0].Substring(0, 2)
                    : palabras[0];

                return primera + palabras[1].Substring(0, 1);
            }

            // Tres o más palabras
            StringBuilder prefijo = new StringBuilder();

            foreach (string palabra in palabras)
            {
                prefijo.Append(palabra[0]);
            }

            return prefijo.ToString();
        }

        private void txtNombreDocumento_TextChanged(object sender, EventArgs e)
        {
            txtPrefijo.Text = GenerarPrefijo(txtNombreDocumento.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Frm_TiposDocumentos frm = new Frm_TiposDocumentos();
            frm.Show();
            this.Close();
        }

        private void dataDocumentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Evitar clic en encabezado
                {
                    if (e.ColumnIndex == dataDocumentos.Columns["Actualizar"].Index)
                    {
                        string IdDocumento = this.dataDocumentos.CurrentRow.Cells["IdTipoDocumento"].Value.ToString();
                        string Estado = this.dataDocumentos.CurrentRow.Cells["Estado"].Value.ToString();

                        CN_TiposDocumento ObjetoCN = new CN_TiposDocumento();
                        ObjetoCN.ActualizarEstado(IdDocumento);

                        if (Estado == "ACTIVO")
                        {
                            MessageBox.Show("Inactivado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }else if (Estado == "INACTIVO")
                        {
                            MessageBox.Show("Activado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        this.txtBuscar.Text = string.Empty;
                        this.ListarDocumentos("");

                    }

                   


                    if (e.ColumnIndex == dataDocumentos.Columns["Editar"].Index)
                    {
                        this.txtIdDocumento.Text = this.dataDocumentos.CurrentRow.Cells["IdTipoDocumento"].Value.ToString();
                        this.txtNombreDocumento.Text = this.dataDocumentos.CurrentRow.Cells["NombreDocumento"].Value.ToString();
                        this.txtPrefijo.Text = this.dataDocumentos.CurrentRow.Cells["Prefijo"].Value.ToString();

                        Editar = true;
                        this.tabControl1.SelectedTab = tabPage2;
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
