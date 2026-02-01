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
namespace CaoaPresentacion
{
    public partial class Frm_NotasEstudiante : Form
    {
        public Frm_NotasEstudiante()
        {
            InitializeComponent();
            this.cmbBusquedas.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        string Estado;
        
        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            this.Estado = "3";
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            this.Estado = "4";
        }

        private void Frm_NotasEstudiante_Load(object sender, EventArgs e)
        {
            try
            {
                this.radioButton1.Checked = true;
                this.cmbBusquedas.Text = "Apellidos";
                this.AgregarColumnaConIcono();

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
                if (this.txtbusqueda.Text == string.Empty)
                {
                    MessageBox.Show("opps!, No hay nada que buscar", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (this.txtbusqueda.Text != string.Empty)
                {
                    if (this.cmbBusquedas.Text == "Carnet")
                    {
                        this.MostrarPorCarnet();

                    }
                    else if (this.cmbBusquedas.Text == "Nombres")
                    {
                        this.MostrarPorNombre();

                    }
                    else if (this.cmbBusquedas.Text == "Apellidos")
                    {
                        this.MostrarPorApellidos();

                    }
                    else if (this.cmbBusquedas.Text == "Codigo Matricula")
                    {
                        this.MostrarPorCodigoMatricula();
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void MostrarPorCarnet()
        {
            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            this.dataEstudiantes.DataSource = objetoCN.MostrarPorCarnet(this.txtbusqueda.Text, Estado);
            this.OcultarColumnas();
            
        }
        private void MostrarPorNombre()
        {
            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            this.dataEstudiantes.DataSource = objetoCN.MostrarPorNombre(this.txtbusqueda.Text, Estado);
            this.OcultarColumnas();
         
        }

        private void MostrarPorCodigoMatricula()
        {
            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            this.dataEstudiantes.DataSource = objetoCN.MostrarPorCodMatricula(this.txtbusqueda.Text, Estado);
            this.OcultarColumnas();
           
        }


        private void MostrarPorApellidos()
        {
            CN_VistaUniverso objetoCN = new CN_VistaUniverso();
            this.dataEstudiantes.DataSource = objetoCN.MostrarPorApellidos(this.txtbusqueda.Text, Estado);
            this.OcultarColumnas();
           
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = TabBusquedaEstudiante;
            this.txtbusqueda.Focus();
        }


        private void AgregarColumnaConIcono()
        {
            try
            {
                // Agregar columna de botón
                DataGridViewButtonColumn btnColumna = new DataGridViewButtonColumn();
                btnColumna.HeaderText = "Seleccionar";
                btnColumna.Name = "Seleccionar";
                btnColumna.Text = ""; // El texto no se usará porque dibujaremos un ícono
                btnColumna.UseColumnTextForButtonValue = false;
                dataEstudiantes.Columns.Add(btnColumna);


                // Evento para pintar el botón con un ícono
                dataEstudiantes.CellPainting += dataEstudiantes_CellPainting;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataEstudiantes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataEstudiantes.Columns["Seleccionar"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Cargar el ícono desde recursos (recomendado) o archivo
                Bitmap icon = Properties.Resources.check; // Usa tu recurso de imagen
                int iconWidth = 16;
                int iconHeight = 16;

                // Posición centrada en la celda
                int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                e.Graphics.DrawImage(icon, new Rectangle(x, y, iconWidth, iconHeight));
                e.Handled = true; // Indica que la celda está completamente pintada
            }
        }

        private void dataEstudiantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Evitar clic en encabezado
                {
                    if (e.ColumnIndex == dataEstudiantes.Columns["Seleccionar"].Index)
                    {
                        this.txtEstudiante.Text = this.dataEstudiantes.CurrentRow.Cells["Nombres"].Value.ToString() + " " + this.dataEstudiantes.CurrentRow.Cells["Apellidos"].Value.ToString();
                        this.MostrarNotasEstudiante(this.dataEstudiantes.CurrentRow.Cells["Id_Matricula"].Value.ToString());
                        this.tabControl1.SelectedTab = TabNotasEstudiante;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema: ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarNotasEstudiante(string IdMatricula)
        {
            try
            {
                CN_NotaModulos objetoCN = new CN_NotaModulos();
                this.dataNotasEstudiante.DataSource = objetoCN.MostrarNotaEstudiante(IdMatricula);
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void notasPorEstudianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = TabNotasEstudiante;
        }
    }
}
