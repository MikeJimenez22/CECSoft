using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CaoaPresentacion
{
    public partial class Frm_Incentivo : Form
    {
        public Frm_Incentivo()
        {
            InitializeComponent();
        }

        CN_Incentivo objetoCN = new CN_Incentivo();

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int Valor = Convert.ToInt32(this.txtIncentivo.Text);
                if (Valor < 0)
                {
                    MessageBox.Show("Error no se admite numeros negativos");
                }
                else
                {
                    objetoCN.CambiarValorINcentivo(this.txtIncentivo.Text);
                    MessageBox.Show("Se ha Modificado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Frm_Incentivo_Load(object sender, EventArgs e)
        {

        }
    }
}
