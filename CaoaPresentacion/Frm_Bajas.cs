using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CaoaPresentacion
{
    public partial class Frm_Bajas : Form
    {
        string FechaActual = DateTime.Now.ToShortDateString();
        CN_Bajas objetoCN = new CN_Bajas();

        public Frm_Bajas()
        {
            InitializeComponent();
            this.cmbConceptoBaja.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbConceptoBaja.Text == string.Empty)
                {
                    MessageBox.Show("Selecciona Primero el Motivo de la Baja");
                }
                else
                {
                    string nombrePC = Environment.MachineName;
                    objetoCN.Insertar(this.cmbConceptoBaja.Text, this.txtmotivo.Text, FechaActual, CacheDatos.Id_CodigoMatricula, CacheUsuario.IdUsuario, nombrePC);
                    MessageBox.Show("Se le ha dado de Baja al estudiante Correctamente");
                    objetoCN.DarBaja(CacheDatos.Id_CodigoMatricula);
                    this.Limpiar();
                    CacheDatos.Id_CodigoMatricula = string.Empty;
                    this.Hide();


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

        }


        private void Limpiar()
        {
            this.txtmotivo.Text = string.Empty;
            this.cmbConceptoBaja.Text = string.Empty;
            CacheDatos.Id_CodigoMatricula = string.Empty;
        }

        private void Frm_Bajas_Load(object sender, EventArgs e)
        {
           
        }
    }
}
