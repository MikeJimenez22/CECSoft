using System;
using System.Windows.Forms;

namespace CaoaPresentacion.Formularios_Vistas
{
    public partial class Frm_VistaEstados : Form
    {
        public Frm_VistaEstados()
        {
            InitializeComponent();

        }

        private void Frm_VistaEstados_Load(object sender, EventArgs e)
        {

        }



        private void dataestados_Click(object sender, EventArgs e)
        {
            try
            {
                CacheDatos.Id_Estado = this.dataestados.CurrentRow.Cells["Id_estado"].Value.ToString();
                MessageBox.Show("El estado *** " + this.dataestados.CurrentRow.Cells["Estado"].Value.ToString() + "*** se Selecciono Correctamente");

                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema, el error es " + ex);
            }
        }
    }
}
