using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CaoaPresentacion.Formularios_Vistas
{
    public partial class Frm_VistasEmpleados : Form
    {
        public Frm_VistasEmpleados()
        {
            InitializeComponent();
        }

        private void Frm_VistasEmpleados_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void Mostrar()
        {
            CN_Empleados objetoCN = new CN_Empleados();
            this.dataEmpleados.DataSource = objetoCN.Mostrar();
        }

        private void dataEmpleados_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataEmpleados.Rows.Count == 0)
                {
                    MessageBox.Show("No se encuentra ningun Registro en esta Tabla");
                }
                else if (this.dataEmpleados.Rows.Count != 0)
                {
                    CacheDatos.Id_Empleado = this.dataEmpleados.CurrentRow.Cells["Id_empleado"].Value.ToString();
                    MessageBox.Show("Empleado Seleccionado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema, el error es " + ex);
            }
        }
    }
}
