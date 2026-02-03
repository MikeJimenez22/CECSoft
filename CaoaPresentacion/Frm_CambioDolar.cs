using CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;
using TuNamespace;
//using Newtonsoft.Json;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Net;

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

        private async void btnGetRate_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                btnGetRate.Enabled = false;
                txtRate.Text = "Obteniendo tasa...";
                Cursor = Cursors.WaitCursor;

                // Configurar TLS 1.2 para Windows
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

                // Usar WebClient que es más confiable
                using (System.Net.WebClient wc = new System.Net.WebClient())
                {
                    wc.Encoding = System.Text.Encoding.UTF8;
                    wc.Headers.Add("User-Agent", "Mozilla/5.0");

                    // ✅ URL que SÍ FUNCIONA (probada)
                    string url = "https://api.exchangerate-api.com/v4/latest/USD";

                    // Mostrar qué estamos intentando
                    txtRate.Text = $"Conectando a: exchangerate-api.com";

                    // Descargar datos
                    string json = wc.DownloadString(url);

                    // Parsear respuesta
                    var data = Newtonsoft.Json.Linq.JObject.Parse(json);
                    decimal tasa = (decimal)data["rates"]["NIO"];
                    string fecha = (string)data["date"];

                    // Mostrar resultado
                    txtRate.Text = $"C${tasa:N2}";
                                  
                   

                  
                }
            }
            catch (System.Net.WebException webEx)
            {
                txtRate.Text = $"Error: {webEx.Status}";

                if (webEx.Status == System.Net.WebExceptionStatus.ProtocolError)
                {
                    MessageBox.Show("Error 404: URL no encontrada\n\n" +
                                  "La API puede haber cambiado.\n" +
                                  "Intente con otra fuente.",
                                  "Error de URL",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                txtRate.Text = $"Error: {ex.GetType().Name}";
                MessageBox.Show($"Error detallado:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGetRate.Enabled = true;
                Cursor = Cursors.Default;
            }
        }
    }

}
