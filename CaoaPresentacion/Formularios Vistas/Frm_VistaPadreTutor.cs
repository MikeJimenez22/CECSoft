using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CaoaPresentacion.Formularios_Vistas
{
    public partial class Frm_VistaPadreTutor : Form
    {
        CN_Padre_Tutor objetoCN = new CN_Padre_Tutor();

        public Frm_VistaPadreTutor()
        {
            InitializeComponent();

        }

        private void Frm_VistaPadreTutor_Load(object sender, EventArgs e)
        {
            try
            {
                if (CacheDatos.VentanaProp2 == "Tutor")
                {
                    this.AgregarBtnDatagridViewTutor();
                    this.BuscarPadre();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema, el error es " + ex);
            }



        }


        private void BuscarPadre()
        {
            CN_Padre_Tutor objetoCN = new CN_Padre_Tutor();
            this.dataPadreTutor.DataSource = objetoCN.Mostrar(this.txtBuscar.Text);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarPadre();
        }

        private void AgregarBtnDatagridViewTutor()
        {
            dataPadreTutor.Columns.Add(
                new DataGridViewButtonColumn()
                {
                    HeaderText = "Seleccionar Tutor",
                    Name = "Seleccionar_Tutor",
                    Text = "Seleccionar",
                    UseColumnTextForButtonValue = true

                });
        }

        private void dataPadreTutor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataPadreTutor.Columns[e.ColumnIndex].Name == "Seleccionar_Tutor")
                {
                    CacheDatos.VarIdPersonaTutor = this.dataPadreTutor.CurrentRow.Cells["Id_padre_tutor"].Value.ToString();
                    MessageBox.Show("Tutor Seleccionado Correctamente");
                    this.Hide();
                    CacheDatos.contador4 = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema, el Error es " + ex);
            }

        }
    }
}
