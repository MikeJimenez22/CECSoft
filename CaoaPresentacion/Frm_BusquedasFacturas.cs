using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using Utils;
using System.Data.SqlClient;
using System.Data;


namespace CaoaPresentacion
{
    public partial class Frm_BusquedasFacturas : Form
    {
        public Frm_BusquedasFacturas()
        {
            InitializeComponent();

            this.cmbopcionfactura.DropDownStyle = ComboBoxStyle.DropDownList;
            DataGridViewConfigurator.Configure(this.dataGridView1,this.dataGridView2);

            timer = new Timer();
            timer.Interval = 1000; // 1 segundo
            timer.Tick += Timer_Tick;

            // NOTA: No usamos timer.Start() aquí
        }

        CD_Conexion conexion = new CD_Conexion();
        int TamañoInicial = 10;
        int TamañoFinal = 829;
        private Timer timer;
        string codigo;
        string TipoAccion;

        //Credenciales cuenta de Google para enviar Notificaciones del sistema
        const string Usuario = "registroacademico.mga2023@gmail.com";
        const string Password = "wxdeymkcmdrpszdx";

        string name = System.Windows.Forms.SystemInformation.ComputerName;

        string localIP = "";
        string NumeroFacturaBuscar;
        string CodigoComparacion;



        private void ObtenerIp()
        {
            IPHostEntry host;

            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.BuscarFacturaGnral();
        }

        private void BuscarFacturaGnral()
        {
            try
            {
                CN_BusquedaFacturas ObjetoCN = new CN_BusquedaFacturas();
                this.dataGridView1.DataSource = ObjetoCN.Mostrar(this.txtFactura.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema: " + ex);
            }
        }

        private void BuscarFacturaGnrallIMPIAR()
        {
            try
            {
                CN_BusquedaFacturas ObjetoCN = new CN_BusquedaFacturas();
                this.dataGridView1.DataSource = ObjetoCN.Mostrar("!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema: " + ex);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Error la tabla se encuentra vacia", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.txtNumFactura.Text = this.dataGridView1.CurrentRow.Cells["Num_Factura"].Value.ToString();
                    this.txtFechaFactura.Text = this.dataGridView1.CurrentRow.Cells["Fecha_factura"].Value.ToString();
                    this.txtFacturaA.Text = this.dataGridView1.CurrentRow.Cells["Nombre_Completo"].Value.ToString();
                    this.txtCarnetEstudiantil.Text = this.dataGridView1.CurrentRow.Cells["CarnetEstudiantil"].Value.ToString();
                    this.txtNIdentificacion.Text = this.dataGridView1.CurrentRow.Cells["NIdentificacion"].Value.ToString();
                    this.txtHoraFactura.Text = this.dataGridView1.CurrentRow.Cells["Hora"].Value.ToString();
                    this.txtTipoPago.Text = this.dataGridView1.CurrentRow.Cells["Tipo_Pago"].Value.ToString();
                    this.txtPagoCon.Text = this.dataGridView1.CurrentRow.Cells["PagoCon"].Value.ToString();
                    this.txtMoneda.Text = this.dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                    this.txtReferencia.Text = this.dataGridView1.CurrentRow.Cells["NReferencia"].Value.ToString();
                    this.txtTotalCordobas.Text = this.dataGridView1.CurrentRow.Cells["TotalEnCordobas"].Value.ToString();
                    this.txtCambio.Text = this.dataGridView1.CurrentRow.Cells["Cambio"].Value.ToString();
                    this.txtEstado.Text = this.dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
                    this.txtNombreCajero.Text = this.dataGridView1.CurrentRow.Cells["Nombre cajero"].Value.ToString();
                    this.txtApellidosCajero.Text = this.dataGridView1.CurrentRow.Cells["Apellidos cajero"].Value.ToString();
                    this.txtTotal.Text = this.dataGridView1.CurrentRow.Cells["MontoTotal_a_Pagar"].Value.ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema" + ex);
            }
        }

        private void txtNumFactura_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CN_BusquedaFacturas objetoCN = new CN_BusquedaFacturas();
                this.dataGridView2.DataSource = objetoCN.MostrarDetalleFactura(this.txtNumFactura.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema" + ex);
            }

        }

        private void Limpiar2()
        {
            try
            {
                CN_BusquedaFacturas objetoCN = new CN_BusquedaFacturas();
                this.dataGridView2.DataSource = objetoCN.MostrarDetalleFactura("!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema" + ex);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panel4.Width == TamañoFinal)
            {
                panel4.Width = TamañoInicial;


            }
            else
            {
                panel4.Width = TamañoFinal;

            }

        }



        private void Frm_BusquedasFacturas_Load(object sender, EventArgs e)
        {
            try
            {
                this.panel4.Width = TamañoInicial;
                panelReimpresionCodigo.Enabled = false;
                this.cmbopcionfactura.Text = "ENVIAR CODIGO AUT.";
                this.tabControl1.SelectedIndex = 3;
                this.groupBox1.Enabled = true;



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema" + ex);
            }
        }


        private void TipoMensaje(int Numero)
        {
            if (Numero == 1)
            {
                this.txtPara.Text = "registroacademico.mga2023@gmail.com";
                this.txtAsunto.Text = "NOTIFICACION REIMPRESION FACTURA - SISTEMA CECNIC";
                this.txtDe.Text = "registroacademico.mga2023@gmail.com";
            }
            else if (Numero == 2)
            {
                this.txtPara.Text = "registroacademico.mga2023@gmail.com";
                this.txtAsunto.Text = "NOTIFICACION ANULACION FACTURA - SISTEMA CECNIC";
                this.txtDe.Text = "registroacademico.mga2023@gmail.com";
            }
        }


        private void GuardarRegistroImpresion(string IdUsuario, string NumFactura, string TipoImpresion, string Descripcion)
        {
            try
            {
                string FechaImpresion = DateTime.Now.ToShortDateString();
                string HoraImpresion = DateTime.Now.ToShortTimeString();


                CN_Impresiones objetoCN = new CN_Impresiones();
                objetoCN.InsertarRegistroImpresiones(FechaImpresion, HoraImpresion, IdUsuario, NumFactura, TipoImpresion, Descripcion, localIP, name);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void Limpiar()
        {
            List<TextBox> textBoxes = new List<TextBox>();

            textBoxes.Add(txtNumFactura);
            textBoxes.Add(txtFechaFactura);
            textBoxes.Add(txtHoraFactura);
            textBoxes.Add(txtFacturaA);
            textBoxes.Add(txtCarnetEstudiantil);
            textBoxes.Add(txtNIdentificacion);
            textBoxes.Add(txtTipoPago);
            textBoxes.Add(txtPagoCon);
            textBoxes.Add(txtMoneda);
            textBoxes.Add(txtReferencia);
            textBoxes.Add(txtTotalCordobas);
            textBoxes.Add(txtCambio);
            textBoxes.Add(txtEstado);
            textBoxes.Add(txtNombreCajero);
            textBoxes.Add(txtApellidosCajero);
            textBoxes.Add(txtTotal);

            foreach (TextBox textBox in textBoxes)
            {
                textBox.Text = "";
            }



        }


        private void button4_Click(object sender, EventArgs e)
        {
            Frm_Anulacion_Egreso frm = new Frm_Anulacion_Egreso();
            frm.ShowDialog();
        }



        public static void Enviar(StringBuilder Mensaje, string De, string Para, string Asunto, out string Error)
        {
            Error = "";
            try
            {
                Mensaje.Append(Environment.NewLine);

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(De);
                mail.To.Add(Para);
                mail.Subject = Asunto;
                mail.Body = Mensaje.ToString();

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(Usuario, Password);
                smtp.EnableSsl = true;
                smtp.Send(mail);
                Error = "Notificación enviada correctamente al correo";
                MessageBox.Show(Error, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                Error = "Error: " + ex;
                MessageBox.Show(Error);

                return;
            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (panel4.Width == TamañoFinal)
            {
                panel4.Width = TamañoInicial;

            }
        }





        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                int i = 0;
                Font font1 = new Font("Arial Black", 11, FontStyle.Regular, GraphicsUnit.Point);
                Font font2 = new Font("Arial", 11, FontStyle.Regular, GraphicsUnit.Point);
                Font font3 = new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point);
                Font font4 = new Font("Arial", 7, FontStyle.Bold, GraphicsUnit.Point);

                DateTime tiempo = new DateTime();
                tiempo = Convert.ToDateTime(DateTime.Now.ToString());

                e.Graphics.DrawString("CECNIC", font1, Brushes.Black, new RectangleF(80, 20, 250, 30));
                e.Graphics.DrawString("Capacitación sin Limites", font2, Brushes.Black, new RectangleF(40, 38, 250, 30));
                e.Graphics.DrawString("Ruc:  J0310000121974   ", font3, Brushes.Black, new RectangleF(50, 56, 250, 30));
                e.Graphics.DrawString("FACTURA." + this.txtNumFactura.Text, font2, Brushes.Black, new RectangleF(30, 74, 250, 30));
                e.Graphics.DrawString("_________________________________", font2, Brushes.Black, new RectangleF(10, 80, 250, 30));
                e.Graphics.DrawString("Fecha " + tiempo, font3, Brushes.Black, new RectangleF(20, 98, 250, 30));
                e.Graphics.DrawString("Cajero: " + this.txtNombreCajero.Text + " " + this.txtApellidosCajero.Text, font4, Brushes.Black, new RectangleF(10, 116, 250, 30));
                e.Graphics.DrawString("_________________________________", font2, Brushes.Black, new RectangleF(10, 122, 250, 30));

                e.Graphics.DrawString(this.txtFacturaA.Text, font4, Brushes.Black, new RectangleF(10, 145, 250, 60));
                e.Graphics.DrawString("Carnet : " + txtCarnetEstudiantil.Text, font4, Brushes.Black, new RectangleF(10, 165, 250, 30));



                i = 185;

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    e.Graphics.DrawString(row.Cells["Observaciones"].Value.ToString(), font4, Brushes.Black, new RectangleF(10, i, 160, 60));
                    e.Graphics.DrawString("C$" + row.Cells["Total_en_Cordobas"].Value.ToString(), font4, Brushes.Black, new RectangleF(170, i, 110, 60));

                    i = i + 25;
                }

                i = i + 18;

                e.Graphics.DrawString("NO.ITEMS.............................", font3, Brushes.Black, new RectangleF(10, i, 250, 30));
                e.Graphics.DrawString(" " + this.dataGridView2.Rows.Count.ToString(), font3, Brushes.Black, new RectangleF(170, i, 250, 30));

                i = i + 18;

                e.Graphics.DrawString("TOTAL   .............................", font3, Brushes.Black, new RectangleF(10, i, 250, 30));
                e.Graphics.DrawString("C$" + this.txtTotal.Text, font3, Brushes.Black, new RectangleF(170, i, 250, 30));

                i = i + 18;

                e.Graphics.DrawString("PAGO CON.............................", font3, Brushes.Black, new RectangleF(10, i, 250, 30));
                e.Graphics.DrawString("C$" + this.txtPagoCon.Text, font3, Brushes.Black, new RectangleF(170, i, 250, 30));

                i = i + 18;

                e.Graphics.DrawString("SU CAMBIO .............................", font3, Brushes.Black, new RectangleF(10, i, 250, 30));
                e.Graphics.DrawString("C$" + this.txtCambio.Text, font3, Brushes.Black, new RectangleF(170, i, 250, 30));

                i = i + 30;

                e.Graphics.DrawString("X  _______________________", font4, Brushes.Black, new RectangleF(50, i, 250, 30));
                i = i + 18;
                e.Graphics.DrawString(" FIRMA DEL ESTUDIANTE", font4, Brushes.Black, new RectangleF(55, i, 250, 30));
                i = i + 18;
                e.Graphics.DrawString("_________________________________", font2, Brushes.Black, new RectangleF(10, i, 250, 30));
                i = i + 18;
                e.Graphics.DrawString("Gracias por tu pago", font2, Brushes.Black, new RectangleF(40, i, 250, 30));
                i = i + 18;
                e.Graphics.DrawString("¡No se realiza devolucion de dinero!", font2, Brushes.Black, new RectangleF(10, i, 250, 40));
                i = i + 30;
                e.Graphics.DrawString("::::::::     REIMPRESION     ::::::::", font2, Brushes.Black, new RectangleF(10, i, 250, 40));
                i = i + 18;
                e.Graphics.DrawString("___________________________", font2, Brushes.Black, new RectangleF(10, i, 250, 40));
                i = i + 30;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema" + ex);

            }

        }

        public void Imprimir()
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema" + ex);
            }


        }

        public void Imprimir2()
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(printDocument2_PrintPage);
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema" + ex);
            }


        }

        public void ImprimirAnulacion()
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(printDocument3_PrintPage);
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema" + ex);
            }


        }

        public void ImprimirAnulacionDeposito()
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(printDocument4_PrintPage);
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema" + ex);
            }


        }


        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                int i = 0;
                Font font1 = new Font("Arial Black", 11, FontStyle.Regular, GraphicsUnit.Point);
                Font font2 = new Font("Arial", 11, FontStyle.Regular, GraphicsUnit.Point);
                Font font3 = new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point);
                Font font4 = new Font("Arial", 7, FontStyle.Bold, GraphicsUnit.Point);

                DateTime tiempo = new DateTime();
                tiempo = Convert.ToDateTime(DateTime.Now.ToString());

                e.Graphics.DrawString("CECNIC", font1, Brushes.Black, new RectangleF(80, 20, 250, 30));
                e.Graphics.DrawString("Capacitación sin Limites", font2, Brushes.Black, new RectangleF(40, 38, 250, 30));
                e.Graphics.DrawString("Ruc:  J0310000121974   ", font3, Brushes.Black, new RectangleF(50, 56, 250, 30));
                e.Graphics.DrawString("FACTURA." + txtNumFactura.Text, font2, Brushes.Black, new RectangleF(30, 74, 250, 30));
                e.Graphics.DrawString("_________________________________", font2, Brushes.Black, new RectangleF(10, 80, 250, 30));
                e.Graphics.DrawString("Fecha " + tiempo, font3, Brushes.Black, new RectangleF(20, 98, 250, 30));
                e.Graphics.DrawString("Cajero: " + this.txtNombreCajero.Text + " " + this.txtApellidosCajero.Text, font4, Brushes.Black, new RectangleF(10, 116, 250, 30));
                e.Graphics.DrawString("_________________________________", font2, Brushes.Black, new RectangleF(10, 122, 250, 30));

                e.Graphics.DrawString(txtFacturaA.Text, font4, Brushes.Black, new RectangleF(10, 145, 250, 60));
                e.Graphics.DrawString("Carnet : " + this.txtCarnetEstudiantil.Text, font4, Brushes.Black, new RectangleF(10, 165, 250, 30));



                i = 215;

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    e.Graphics.DrawString(row.Cells["Observaciones"].Value.ToString(), font4, Brushes.Black, new RectangleF(10, i, 160, 60));
                    e.Graphics.DrawString("C$" + row.Cells["Total_en_Cordobas"].Value.ToString(), font4, Brushes.Black, new RectangleF(170, i, 110, 60));

                    i = i + 25;
                }

                i = i + 18;

                e.Graphics.DrawString("NO.ITEMS.............................", font3, Brushes.Black, new RectangleF(10, i, 250, 30));
                e.Graphics.DrawString(" " + this.dataGridView2.Rows.Count.ToString(), font3, Brushes.Black, new RectangleF(170, i, 250, 30));

                i = i + 18;

                e.Graphics.DrawString("TOTAL   .............................", font3, Brushes.Black, new RectangleF(10, i, 250, 30));
                e.Graphics.DrawString("C$" + this.txtTotal.Text, font3, Brushes.Black, new RectangleF(170, i, 250, 30));

                i = i + 18;

                e.Graphics.DrawString("PAGO CON " + this.txtTipoPago.Text.ToUpper(), font3, Brushes.Black, new RectangleF(10, i, 250, 30));
                e.Graphics.DrawString(this.txtReferencia.Text, font3, Brushes.Black, new RectangleF(150, i, 250, 30));


                i = i + 30;

                e.Graphics.DrawString("X  _______________________", font4, Brushes.Black, new RectangleF(50, i, 250, 30));
                i = i + 18;
                e.Graphics.DrawString(" FIRMA DEL ESTUDIANTE", font4, Brushes.Black, new RectangleF(55, i, 250, 30));
                i = i + 18;
                e.Graphics.DrawString("_________________________________", font2, Brushes.Black, new RectangleF(10, i, 250, 30));
                i = i + 18;
                e.Graphics.DrawString("Gracias por tu pago", font2, Brushes.Black, new RectangleF(40, i, 250, 30));
                i = i + 18;
                e.Graphics.DrawString("¡No se realiza devolucion de dinero!", font2, Brushes.Black, new RectangleF(10, i, 250, 40));
                i = i + 30;
                e.Graphics.DrawString("::::::::     REIMPRESION    ::::::::", font2, Brushes.Black, new RectangleF(10, i, 250, 40));
                i = i + 18;
                e.Graphics.DrawString("___________________________", font2, Brushes.Black, new RectangleF(10, i, 250, 40));

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema" + ex);

            }

        }

        private void printDocument3_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                int i = 0;
                Font font1 = new Font("Arial Black", 11, FontStyle.Regular, GraphicsUnit.Point);
                Font font2 = new Font("Arial", 11, FontStyle.Regular, GraphicsUnit.Point);
                Font font3 = new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point);
                Font font4 = new Font("Arial", 7, FontStyle.Bold, GraphicsUnit.Point);

                DateTime tiempo = new DateTime();
                tiempo = Convert.ToDateTime(DateTime.Now.ToString());

                e.Graphics.DrawString("CECNIC", font1, Brushes.Black, new RectangleF(80, 20, 250, 30));
                e.Graphics.DrawString("Capacitación sin Limites", font2, Brushes.Black, new RectangleF(40, 38, 250, 30));
                e.Graphics.DrawString("Ruc:  J0310000121974   ", font3, Brushes.Black, new RectangleF(50, 56, 250, 30));
                e.Graphics.DrawString("FACTURA." + txtNumFactura.Text, font2, Brushes.Black, new RectangleF(30, 74, 250, 30));
                e.Graphics.DrawString("_________________________________", font2, Brushes.Black, new RectangleF(10, 80, 250, 30));
                e.Graphics.DrawString("Fecha " + tiempo, font3, Brushes.Black, new RectangleF(20, 98, 250, 30));
                e.Graphics.DrawString("Cajero: " + this.txtNombreCajero.Text + " " + this.txtApellidosCajero.Text, font4, Brushes.Black, new RectangleF(10, 116, 250, 30));
                e.Graphics.DrawString("_________________________________", font2, Brushes.Black, new RectangleF(10, 122, 250, 30));

                e.Graphics.DrawString(txtFacturaA.Text, font4, Brushes.Black, new RectangleF(10, 145, 250, 60));
                e.Graphics.DrawString("Carnet : " + this.txtCarnetEstudiantil.Text, font4, Brushes.Black, new RectangleF(10, 165, 250, 30));



                i = 215;

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    e.Graphics.DrawString(row.Cells["Observaciones"].Value.ToString(), font4, Brushes.Black, new RectangleF(10, i, 160, 60));
                    e.Graphics.DrawString("C$" + row.Cells["Total_en_Cordobas"].Value.ToString(), font4, Brushes.Black, new RectangleF(170, i, 110, 60));

                    i = i + 25;
                }

                i = i + 18;

                e.Graphics.DrawString("NO.ITEMS.............................", font3, Brushes.Black, new RectangleF(10, i, 250, 30));
                e.Graphics.DrawString(" " + this.dataGridView2.Rows.Count.ToString(), font3, Brushes.Black, new RectangleF(170, i, 250, 30));

                i = i + 18;

                e.Graphics.DrawString("TOTAL   .............................", font3, Brushes.Black, new RectangleF(10, i, 250, 30));
                e.Graphics.DrawString("C$" + this.txtTotal.Text, font3, Brushes.Black, new RectangleF(170, i, 250, 30));

                i = i + 18;

                e.Graphics.DrawString("PAGO CON " + this.txtTipoPago.Text.ToUpper(), font3, Brushes.Black, new RectangleF(10, i, 250, 30));
                e.Graphics.DrawString(this.txtReferencia.Text, font3, Brushes.Black, new RectangleF(150, i, 250, 30));


                i = i + 30;

                e.Graphics.DrawString("X  _______________________", font4, Brushes.Black, new RectangleF(50, i, 250, 30));
                i = i + 18;
                e.Graphics.DrawString(" FIRMA DEL ESTUDIANTE", font4, Brushes.Black, new RectangleF(55, i, 250, 30));
                i = i + 18;
                e.Graphics.DrawString("_________________________________", font2, Brushes.Black, new RectangleF(10, i, 250, 30));
                i = i + 18;
                e.Graphics.DrawString("Gracias por tu pago", font2, Brushes.Black, new RectangleF(40, i, 250, 30));
                i = i + 18;
                e.Graphics.DrawString("¡No se realiza devolucion de dinero!", font2, Brushes.Black, new RectangleF(10, i, 250, 40));
                i = i + 30;
                e.Graphics.DrawString("::::::::     FACTURA ANULADA     ::::::::", font2, Brushes.Black, new RectangleF(10, i, 250, 40));
                i = i + 18;
                e.Graphics.DrawString("___________________________", font2, Brushes.Black, new RectangleF(10, i, 250, 40));

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema" + ex);

            }

        }

        private void printDocument4_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                int i = 0;
                Font font1 = new Font("Arial Black", 11, FontStyle.Regular, GraphicsUnit.Point);
                Font font2 = new Font("Arial", 11, FontStyle.Regular, GraphicsUnit.Point);
                Font font3 = new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point);
                Font font4 = new Font("Arial", 7, FontStyle.Bold, GraphicsUnit.Point);

                DateTime tiempo = new DateTime();
                tiempo = Convert.ToDateTime(DateTime.Now.ToString());

                e.Graphics.DrawString("CECNIC", font1, Brushes.Black, new RectangleF(80, 20, 250, 30));
                e.Graphics.DrawString("Capacitación sin Limites", font2, Brushes.Black, new RectangleF(40, 38, 250, 30));
                e.Graphics.DrawString("Ruc:  J0310000121974   ", font3, Brushes.Black, new RectangleF(50, 56, 250, 30));
                e.Graphics.DrawString("FACTURA." + txtNumFactura.Text, font2, Brushes.Black, new RectangleF(30, 74, 250, 30));
                e.Graphics.DrawString("_________________________________", font2, Brushes.Black, new RectangleF(10, 80, 250, 30));
                e.Graphics.DrawString("Fecha " + tiempo, font3, Brushes.Black, new RectangleF(20, 98, 250, 30));
                e.Graphics.DrawString("Cajero: " + this.txtNombreCajero.Text + " " + this.txtApellidosCajero.Text, font4, Brushes.Black, new RectangleF(10, 116, 250, 30));
                e.Graphics.DrawString("_________________________________", font2, Brushes.Black, new RectangleF(10, 122, 250, 30));

                e.Graphics.DrawString(txtFacturaA.Text, font4, Brushes.Black, new RectangleF(10, 145, 250, 60));
                e.Graphics.DrawString("Carnet : " + this.txtCarnetEstudiantil.Text, font4, Brushes.Black, new RectangleF(10, 165, 250, 30));



                i = 215;

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    e.Graphics.DrawString(row.Cells["Observaciones"].Value.ToString(), font4, Brushes.Black, new RectangleF(10, i, 160, 60));
                    e.Graphics.DrawString("C$" + row.Cells["Total_en_Cordobas"].Value.ToString(), font4, Brushes.Black, new RectangleF(170, i, 110, 60));

                    i = i + 25;
                }

                i = i + 18;

                e.Graphics.DrawString("NO.ITEMS.............................", font3, Brushes.Black, new RectangleF(10, i, 250, 30));
                e.Graphics.DrawString(" " + this.dataGridView2.Rows.Count.ToString(), font3, Brushes.Black, new RectangleF(170, i, 250, 30));

                i = i + 18;

                e.Graphics.DrawString("TOTAL   .............................", font3, Brushes.Black, new RectangleF(10, i, 250, 30));
                e.Graphics.DrawString("C$" + this.txtTotal.Text, font3, Brushes.Black, new RectangleF(170, i, 250, 30));

                i = i + 18;

                e.Graphics.DrawString("PAGO CON " + this.txtTipoPago.Text.ToUpper(), font3, Brushes.Black, new RectangleF(10, i, 250, 30));
                e.Graphics.DrawString(this.txtReferencia.Text, font3, Brushes.Black, new RectangleF(150, i, 250, 30));


                i = i + 30;

                e.Graphics.DrawString("X  _______________________", font4, Brushes.Black, new RectangleF(50, i, 250, 30));
                i = i + 18;
                e.Graphics.DrawString(" FIRMA DEL ESTUDIANTE", font4, Brushes.Black, new RectangleF(55, i, 250, 30));
                i = i + 18;
                e.Graphics.DrawString("_________________________________", font2, Brushes.Black, new RectangleF(10, i, 250, 30));
                i = i + 18;
                e.Graphics.DrawString("Gracias por tu pago", font2, Brushes.Black, new RectangleF(40, i, 250, 30));
                i = i + 18;
                e.Graphics.DrawString("¡No se realiza devolucion de dinero!", font2, Brushes.Black, new RectangleF(10, i, 250, 40));
                i = i + 30;
                e.Graphics.DrawString("::::::::     FACTURA ANULADA     ::::::::", font2, Brushes.Black, new RectangleF(10, i, 250, 40));
                i = i + 18;
                e.Graphics.DrawString("___________________________", font2, Brushes.Black, new RectangleF(10, i, 250, 40));

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema" + ex);

            }

        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            try
            {
                NumeroFacturaBuscar = this.dataGridView2.CurrentRow.Cells["Num_Factura"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema" + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 1;
        }

        private void btnEnviarCodigoReimpresion_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación de número de factura
                if (string.IsNullOrWhiteSpace(txtNumFactura.Text))
                {
                    MessageBox.Show("No se encuentra ninguna factura seleccionada",
                                    "SISTEMA CECNIC",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return; // Evitamos seguir ejecutando
                }

                // Validación de motivo
                if (string.IsNullOrWhiteSpace(txtmensaje1.Text))
                {
                    MessageBox.Show("Debes ingresar un motivo para la reimpresión",
                                    "SISTEMA CECNIC",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                // Obtener fecha y hora actuales
                string fechaActual = DateTime.Now.ToLongDateString();
                string horaActual = DateTime.Now.ToLongTimeString();

                // Generar código de autorización
                codigo = generarcodigoSolicitudAnulacion();

                // Registrar en base de datos
                CN_Autorizaciones autorizacionCN = new CN_Autorizaciones();
                autorizacionCN.Insertar(DateTime.Now.ToShortDateString(),
                                        "REIMPRESION - " + txtmensaje1.Text,
                                        codigo,
                                        "NO",
                                        CacheUsuario.IdUsuario);

              

                // Deshabilitar controles tras envío
                TipoAccion = "REIMPRESION";
                timer.Start();
                txtmensaje1.Enabled = false;
                btnEnviarCodigoReimpresion.Enabled = false;
                panelReimpresionCodigo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema: " + ex.Message,
                                "SISTEMA CECNIC",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (TipoAccion == "REIMPRESION")
                {
                    ConsultarAutorizacion();
                }else if (TipoAccion == "ANULACION")
                {
                    ConsultarAnulacion();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema: " + ex.Message,
                               "SISTEMA CECNIC",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }


  

        private void ConsultarAnulacion()
        {
            try
            {
                CN_Autorizaciones objetoCN = new CN_Autorizaciones();
                DataTable tabla = new DataTable();
                tabla = objetoCN.ConsultarAutorizacion(codigo);
                if (tabla.Rows.Count != 0)
                {
                    string Autorizacion = tabla.Rows[0][0].ToString();
                    if (Autorizacion == "SI")
                    {
                        this.txtCodigo2.Text = codigo;
                        timer.Stop();
                        Anulacion();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema: " + ex.Message,
                       "SISTEMA CECNIC",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
            }
        }


        private void ConsultarAutorizacion()
        {
            try
            {
                CN_Autorizaciones objetoCN = new CN_Autorizaciones();
                DataTable tabla = new DataTable();
                tabla = objetoCN.ConsultarAutorizacion(codigo);
                if (tabla.Rows.Count != 0)
                {
                    string Autorizacion = tabla.Rows[0][0].ToString();
                    if (Autorizacion == "SI")
                    {
                        this.txtCodigo1.Text = codigo;
                        timer.Stop();
                        Reimpresion();
                        
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema: " + ex.Message,
                               "SISTEMA CECNIC",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        private string generarcodigoSolicitudAnulacion()
        {
            string CodigoAnulacion = string.Empty;
            //creando una instancia de random
            Random aleatorio = new Random();
            CodigoAnulacion = Convert.ToString(aleatorio.Next(99999, 999999));
            this.CodigoComparacion = CodigoAnulacion.ToString();
            return CodigoAnulacion;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                timer.Stop();
                Reimpresion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema" + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Reimpresion()
        {
            //Reimpresion de Facturas por medio de codigo de autorizacion enviado a Gerencia General
            try
            {
                if (this.txtCodigo1.Text == string.Empty)
                {
                    MessageBox.Show("Campo Vacio, ingresa un codigo", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (this.txtCodigo1.Text != CodigoComparacion)
                    {
                        MessageBox.Show("Codigo Incorrecto", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (this.txtTipoPago.Text == "EFECTIVO")
                        {
                            this.Imprimir();


                        }
                        else if (this.txtTipoPago.Text == "DEPOSITO" || this.txtTipoPago.Text == "CHEQUE" || this.txtTipoPago.Text == "TARJETA")
                        {
                            this.Imprimir2();


                        }

                        if (panel4.Width == TamañoFinal)
                        {
                            panel4.Width = TamañoInicial;

                        }

                        this.txtmensaje1.Text = string.Empty;
                        this.txtCodigo1.Text = string.Empty;
                        this.panelReimpresionCodigo.Enabled = false;
                        this.tabControl1.SelectedIndex = 3;

                        this.BuscarFacturaGnrallIMPIAR();
                        this.Limpiar();
                        this.Limpiar2();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema" + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbopcionfactura.Text == "ENVIAR CODIGO AUT.")
                {
                    this.tabControl1.SelectedIndex = 1;
                }
                else if (this.cmbopcionfactura.Text == "REIMPRIMIR CON USUARIO")
                {
                    this.tabControl1.SelectedIndex = 2;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema" + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEnviarCodigoAnulacion_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación de factura seleccionada
                if (string.IsNullOrWhiteSpace(txtNumFactura.Text))
                {
                    MessageBox.Show("No se encuentra ninguna factura seleccionada",
                                    "SISTEMA CECNIC",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                // Validación de motivo
                if (string.IsNullOrWhiteSpace(txtmensaje2.Text))
                {
                    MessageBox.Show("Tienes que agregar un Motivo",
                                    "SISTEMA CECNIC",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                // Obtener fecha y hora actual
                string fechaActual = DateTime.Now.ToLongDateString();
                string horaActual = DateTime.Now.ToLongTimeString();

                // Generar código de autorización
                codigo = generarcodigoSolicitudAnulacion();

                // Registrar en base de datos
                var autorizacionCN = new CN_Autorizaciones();
                autorizacionCN.Insertar(
                    DateTime.Now.ToShortDateString(),
                    "ANULACION - " + txtmensaje2.Text,
                    codigo,
                    "NO",
                    CacheUsuario.IdUsuario
                );

             

                // Actualizar controles
                TipoAccion = "ANULACION";
                timer.Start();
                txtmensaje2.Enabled = false;
                btnEnviarCodigoAnulacion.Enabled = false;
                panelAnulacionCodigo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema: " + ex.Message,
                                "SISTEMA CECNIC",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            timer.Stop();
            Anulacion();
        }

        private void Anulacion()
        {
            //Reimpresion de Facturas por medio de codigo de autorizacion enviado a Gerencia General
            try
            {
                if (this.txtCodigo2.Text == string.Empty)
                {
                    MessageBox.Show("Campo Vacio, ingresa un codigo", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (this.txtCodigo2.Text != CodigoComparacion)
                    {
                        MessageBox.Show("Codigo Incorrecto", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (this.txtTipoPago.Text == "EFECTIVO")
                        {
                            CN_ProcesosFactura ObjetoCN = new CN_ProcesosFactura();
                            ObjetoCN.EjecutarProcesosFactura(txtNumFactura.Text);
                            MessageBox.Show("FACTURA ANULADA CORRECTAMENTE", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.ImprimirAnulacion();


                        }
                        else if (this.txtTipoPago.Text == "DEPOSITO" || this.txtTipoPago.Text == "CHEQUE" || this.txtTipoPago.Text == "TARJETA")
                        {
                            CN_ProcesosFactura ObjetoCN = new CN_ProcesosFactura();
                            ObjetoCN.EjecutarProcesosFactura(txtNumFactura.Text);
                            MessageBox.Show("FACTURA ANULADA CORRECTAMENTE", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.ImprimirAnulacionDeposito();



                        }

                        if (panel4.Width == TamañoFinal)
                        {
                            panel4.Width = TamañoInicial;

                        }

                        this.txtmensaje2.Text = string.Empty;
                        this.txtCodigo2.Text = string.Empty;
                        this.panelAnulacionCodigo.Enabled = false;
                        this.tabControl1.SelectedIndex = 3;

                        this.BuscarFacturaGnrallIMPIAR();
                        this.Limpiar();
                        this.Limpiar2();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema" + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 2;
        }
    }
}


