using CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace CaoaPresentacion
{
    public partial class Frm_CambioDolar : Form
    {

        CN_Moneda objetoCN = new CN_Moneda();


        public Frm_CambioDolar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtValorDolar.Text == string.Empty)
                {
                    MessageBox.Show("Campo Vacio");
                }
                else if (this.txtValorDolar.Text != string.Empty)
                {
                    double ValorDolar = Convert.ToDouble(this.txtValorDolar.Text);

                    if (ValorDolar < 0)
                    {
                        MessageBox.Show("Error no se Puede agregar un Valor Negativo");
                    }
                    else
                    {
                        objetoCN.Editar(Convert.ToDouble(this.txtValorDolar.Text));


                        MessageBox.Show("Modificado Correctamente");
                       

                        this.txtValorDolar.Text = string.Empty;
                        this.Hide();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "CECNIC SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_CambioDolar_Load(object sender, EventArgs e)
        {

            this.MostrarValor();
            
        }

        private void MostrarValor()
        {
            DataTable tabla = new DataTable();

            CN_Moneda objetoCN = new CN_Moneda();



            tabla = objetoCN.ValorMoneda();
            if (tabla.Rows.Count == 0)
            {
                this.label4.Text = "";
            }
            else if (tabla.Rows.Count != 0)
            {
                this.label4.Text = tabla.Rows[0][1].ToString();
            }

        }
    }

}
