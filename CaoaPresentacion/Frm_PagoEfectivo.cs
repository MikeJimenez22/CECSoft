using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Globalization;

using System.Net;
using System.Net.NetworkInformation;

namespace CaoaPresentacion
{
    public partial class Frm_PagoEfectivo : Form
    {
        CN_FacturDetalle objetoCN = new CN_FacturDetalle();
        CN_Factura objetoCN2 = new CN_Factura();
        CN_Movimientos objetoMovimiento = new CN_Movimientos();

        CD_Conexion conexion = new CD_Conexion();

        string name = System.Windows.Forms.SystemInformation.ComputerName;
        
        string localIP = "";



        string NumeroFactura;

        string VariableFactura;

        public Frm_PagoEfectivo()
        {
            InitializeComponent();
            this.cmbTipoMoneda.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Cargar_ComboMoneda();
        }

        int i;

        string Mensaje;

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


        private void InsertarSolvencia(string Tipo)
        {
            
            ObtenerIp();
            string name = System.Windows.Forms.SystemInformation.ComputerName;
            string FechaActual = DateTime.Now.ToShortDateString();
            string HoraActual = DateTime.Now.ToShortTimeString();
            string TotalEfectivo = this.TxtTotalPago.Text;
            string PagoCon = this.txtpagoCon.Text;
            string Cambio = this.txtCambio.Text;
            string TotalDeposito = this.textBox1.Text;
            string NReferencia = this.textBox4.Text;
            string PagoDeposito = this.textBox5.Text;
            string IdUsuario = CacheUsuario.IdUsuario;
            string CodigoCarnet = this.txtcodigoCarnet.Text;

         

            //foreach (DataGridViewRow row in dataDetalles.Rows)
            //{
            //    // Verificar si la celda contiene "MENSUALIDAD"
            //    if (row.Cells["Nombre_Arancel"].Value != null && row.Cells["Nombre_Arancel"].Value.ToString() == "MENSUALIDAD")
            //    {
            //        // Acción que deseas realizar

            //        if (Tipo == "EFECTIVO")
            //        {
                        
            //            CN_Solvencia objetoEfectivo = new CN_Solvencia();
            //            objetoEfectivo.InsertarSolvencia(CodigoSolvencia.ToString(), CodigoCarnet, FechaActual, PagoCon, TotalEfectivo, Cambio, "-", FechaActual, "-", IdUsuario, name, localIP, IdUsuario, "PENDIENTE", row.Cells["Observaciones"].Value.ToString());
            //        }
            //        else if (Tipo == "OTRO")
            //        {
                     
            //            CN_Solvencia objetoSolvencia = new CN_Solvencia();
            //            objetoSolvencia.InsertarSolvencia(CodigoSolvencia.ToString(), CodigoCarnet, FechaActual, PagoDeposito, TotalDeposito, "0", NReferencia, FechaActual, "-", IdUsuario, name, localIP, IdUsuario,"PENDIENTE",row.Cells["Observaciones"].Value.ToString());

            //        }




            //    }
            //}



         



        }

        private int generarcodigo()
        {
            //creando una instancia de random
            Random aleatorio = new Random();
            int numero = aleatorio.Next(1, 99999999);

            return numero;
        }


        private void Frm_PagoEfectivo_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormClosed += new FormClosedEventHandler(cerrarform);

                this.txtNombredeFactura.Text = CacheVentaPagos.NombreFactura;
                this.txtSubtotal.Text = CacheVentaPagos.Subtotal;
                this.txtva.Text = CacheVentaPagos.Iva;
                this.TxtTotalPago.Text = CacheVentaPagos.Total;
                this.textBox1.Text = CacheVentaPagos.Total;
                this.lblfactura.Text = CacheVentaPagos.NumeroFacturacion;
                this.textBox2.Text = CacheVentaPagos.NumeroFacturacion;
                this.txtcodigoCarnet.Text = CacheVentaPagos.NumeroCarnet;
                this.txtCurso.Text = CacheVentaPagos.NombreCurso;
                this.txtHorario.Text = CacheVentaPagos.Horario;
                this.txtDias.Text = CacheVentaPagos.Dia;
                this.txtDescuento.Text = CacheVentaPagos.DescuentoMatricula;
                this.cmbTipoMoneda.Text = "Cordobas";
                this.txtCajero.Text = CacheUsuario.Nombres + " " + CacheUsuario.Apellidos;
                this.txtcaja.Text = CacheUsuario.Caja;


                this.MostraDetallesAbonos();
                this.MostraDetallesMensualidades();
                this.groupBox2.Enabled = true;
                this.groupBox10.Enabled = false;
                this.groupBox10.Visible = false;
                this.CargarCambioDolares();
                this.textBox5.Enabled = false;

                this.OcultarPaneles();
                this.radioButton1.Checked = true;
                this.EleccionTipoPago();

              

                this.MostraDetalles();

                LiberadorDeMemoria objeto1 = new LiberadorDeMemoria();
                objeto1.alzheimer();

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCambioDolares()
        {
            CD_Conexion conexion = new CD_Conexion();
            conexion.AbrirConexion();
            SqlCommand cm = new SqlCommand("select  ValorMoneda from Tbl_TipoMoneda where IdMoneda = '2'", conexion.Conexion);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read() == true)
            {
                this.txtTipoCambio.Text = dr["ValorMoneda"].ToString();

            }
          conexion.CerrarConexion();
            dr.Close();
        }

        private void OcultarPaneles()
        {
            this.panel4.Visible = false;
            this.panel5.Visible = false;
            this.panel6.Visible = false;
            this.panel7.Visible = false;
        }


        private void EleccionTipoPago()
        {
            if (this.radioButton1.Checked == true)
            {
                this.panel4.Visible = true;
                this.panel5.Visible = false;
                this.panel6.Visible = false;
                this.panel7.Visible = false;
            }else if (this.radioButton2.Checked == true)
            {
                this.panel4.Visible = false;
                this.panel5.Visible = true;
                this.panel6.Visible = false;
                this.panel7.Visible = false;

            }else if (this.radioButton3.Checked == true)
            {
                this.panel4.Visible = false;
                this.panel5.Visible = false;
                this.panel6.Visible = true;
                this.panel7.Visible = false;
            }else if (this.radioButton4.Checked == true)
            {
                this.panel4.Visible = false;
                this.panel5.Visible = false;
                this.panel6.Visible = false;
                this.panel7.Visible = true;
            }
        }

        private void SeleccionTipoPago()
        {
            if (this.radioButton1.Checked == true)
            {
                this.groupBox9.Enabled = false;
                this.groupBox9.Visible = false;
                this.groupBox2.Visible = true;
                this.groupBox2.Enabled = true;
                this.groupBox2.Location = new Point(705,224);
                

            }else if (this.radioButton2.Checked == true)
            {
                this.groupBox9.Enabled = true;
                this.groupBox9.Visible = true;
                this.groupBox2.Visible = false;
                this.groupBox2.Enabled = false;

                this.txtTipoPago.Text = "DEPOSITO";
                this.groupBox2.Location = new Point(704, 427);
            }
            else if (this.radioButton3.Checked == true)
            {
                this.groupBox9.Enabled = true;
                this.groupBox9.Visible = true;
                this.groupBox2.Visible = false;
                this.groupBox2.Enabled = false;
                this.txtTipoPago.Text = "TARJETA";
                this.groupBox2.Location = new Point(704, 427);
            }
            else if (this.radioButton4.Checked == true)
            {
                this.groupBox9.Enabled = true;
                this.groupBox9.Visible = true;
                this.groupBox2.Visible = false;
                this.groupBox2.Enabled = false;
                this.txtTipoPago.Text = "CHEQUE";
                this.groupBox2.Location = new Point(704, 427);
            }
        }


        private void MostraDetallesAbonos()
        {
             CN_FacturaGeneral objetoCN3 = new CN_FacturaGeneral();
            this.dataAbonos.DataSource = objetoCN3.MostrarAbonosFactura(this.lblfactura.Text);

        }

        private void MostraDetallesMensualidades()
        {
            CN_FacturaGeneral objetoCN3 = new CN_FacturaGeneral();
            this.dataMensualidades.DataSource = objetoCN3.MostrarMensualidadesFactura(this.lblfactura.Text);

        }

        private void MostraDetalles()
        {
            CN_FacturDetalle objetoCN3 = new CN_FacturDetalle();
            this.dataDetalles.DataSource = objetoCN3.Mostrar(this.lblfactura.Text);

        }

        public void Cargar_ComboMoneda()
        {
            try
            {
              
                SqlCommand cmd = new SqlCommand("Select IdMoneda,Descripcion from Tbl_TipoMoneda", conexion.Conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Descripcion"] = "Selecciona una Moneda";
                dt.Rows.InsertAt(fila, 0);

                cmbTipoMoneda.ValueMember = "IdMoneda";
                cmbTipoMoneda.DisplayMember = "Descripcion";
                cmbTipoMoneda.DataSource = dt;
                this.cmbTipoMoneda.Text = "Cordoba";
                

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

       

      


        private void cmbTipoMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            CD_Conexion conexion = new CD_Conexion();
            conexion.AbrirConexion();
            SqlCommand cm = new SqlCommand("select  ValorMoneda from Tbl_TipoMoneda where IdMoneda = '" + this.cmbTipoMoneda.SelectedValue + "'", conexion.Conexion);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read() == true)
            {
                this.txtTasaCambio.Text = dr["ValorMoneda"].ToString();

            }
            conexion.CerrarConexion();
        }

        private void Calculos()
        {
            double X;
            double Y;
            double Z;
          
            double TotalPago;

            X = Convert.ToDouble(this.txtTasaCambio.Text);
            Y = Convert.ToDouble(this.txtpagoCon.Text);
            TotalPago = Convert.ToDouble(this.TxtTotalPago.Text);
            Z = X * Y;
            this.txtPagoenCordobas.Text = Z.ToString();
            if (Z < TotalPago)
            {
                MessageBox.Show("Dinero Insuficiente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if (Z >= TotalPago)
            {
                double Cambio;

                Cambio = Z - TotalPago;
                this.txtCambio.Text =  Convert.ToString(Math.Round(Cambio, 2));

            }



        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                int i = 0;
                Font font1 = new Font("Arial Black",11, FontStyle.Regular, GraphicsUnit.Point);
                Font font2 = new Font("Arial", 11, FontStyle.Regular, GraphicsUnit.Point);
                Font font3 = new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point);
                Font font4 = new Font("Arial", 7, FontStyle.Bold, GraphicsUnit.Point);

                DateTime tiempo = new DateTime();
                tiempo = Convert.ToDateTime(DateTime.Now.ToString());

                e.Graphics.DrawString("CECNIC",font1, Brushes.Black, new RectangleF(80,20,250,30));
                e.Graphics.DrawString("Capacitación sin Limites", font2, Brushes.Black, new RectangleF(40,38, 250, 30));
                e.Graphics.DrawString("Ruc:  J0310000121974   ", font3, Brushes.Black, new RectangleF(50,56, 250, 30));
                e.Graphics.DrawString("FACTURA." + NumeroFactura, font2, Brushes.Black, new RectangleF(30, 74, 250, 30));
                e.Graphics.DrawString("_________________________________", font2, Brushes.Black, new RectangleF(10,80, 250, 30));
                e.Graphics.DrawString("Fecha " + tiempo, font3, Brushes.Black, new RectangleF(20,98, 250, 30));
                e.Graphics.DrawString("Cajero: " + txtCajero.Text, font4, Brushes.Black, new RectangleF(10,116, 250, 30));
                e.Graphics.DrawString("_________________________________", font2, Brushes.Black, new RectangleF(10,122, 250, 30));

                e.Graphics.DrawString(txtNombredeFactura.Text, font4, Brushes.Black, new RectangleF(10, 145, 250, 60));
                e.Graphics.DrawString("Carnet : " + txtcodigoCarnet.Text, font4, Brushes.Black, new RectangleF(10, 165, 250, 30));
                e.Graphics.DrawString(this.txtCurso.Text, font4, Brushes.Black, new RectangleF(10, 189, 250, 30));
             
              
                i = 215;

                foreach (DataGridViewRow row in dataDetalles.Rows)
                {
                    e.Graphics.DrawString(row.Cells["Observaciones"].Value.ToString(), font4, Brushes.Black, new RectangleF(10, i, 160, 60));
                    e.Graphics.DrawString("C$" + row.Cells["Total_en_Cordobas"].Value.ToString(), font4, Brushes.Black, new RectangleF(170, i, 110, 60));

                    i = i + 25;
                }

                i = i + 18;
                
                e.Graphics.DrawString("NO.ITEMS.............................", font3, Brushes.Black, new RectangleF(10, i, 250, 30));
                e.Graphics.DrawString(" " + this.dataDetalles.Rows.Count.ToString(), font3, Brushes.Black, new RectangleF(170, i, 250, 30));

                i = i + 18;

                e.Graphics.DrawString("TOTAL   .............................", font3, Brushes.Black, new RectangleF(10, i, 250, 30));
                e.Graphics.DrawString("C$" + this.TxtTotalPago.Text, font3, Brushes.Black, new RectangleF(170, i, 250, 30));

                i = i + 18;

                e.Graphics.DrawString("PAGO CON.............................", font3, Brushes.Black, new RectangleF(10, i, 250, 30));
                e.Graphics.DrawString("C$" + this.txtPagoenCordobas.Text, font3, Brushes.Black, new RectangleF(170, i, 250, 30));

                i = i + 18;

                e.Graphics.DrawString("SU CAMBIO .............................", font3, Brushes.Black, new RectangleF(10, i, 250, 30));
                e.Graphics.DrawString("C$" + this.txtCambio.Text, font3, Brushes.Black, new RectangleF(170, i, 250, 30));
                
                i = i + 30;

                e.Graphics.DrawString("X  _______________________", font4, Brushes.Black, new RectangleF(50, i, 250, 30));
                i = i + 18;
                e.Graphics.DrawString(" FIRMA DEL ESTUDIANTE", font4, Brushes.Black, new RectangleF(55, i, 250, 30));
                i = i + 18;
                e.Graphics.DrawString("_________________________________", font2, Brushes.Black, new RectangleF(10,i, 250, 30));
                i = i + 18;
                e.Graphics.DrawString("Gracias por tu pago", font2, Brushes.Black, new RectangleF(40, i, 250, 30));
                i = i + 18;
                e.Graphics.DrawString("¡No se realiza devolucion de dinero!", font2, Brushes.Black, new RectangleF(10, i, 250, 40));
                i = i + 18;
                e.Graphics.DrawString("___________________________", font2, Brushes.Black, new RectangleF(10, i, 250, 40));
                i = i + 30;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema" + ex);
              
            }


        }

    



        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblfecha.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.CrearFactura();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex);
            }
        }

        // Tenemos que pasar los parametros para poder hacer el registro de la Impresion

        private void GuardarRegistroImpresion(string IdUsuario,string NumFactura,string TipoImpresion,string Descripcion)
        {
            try
            {
                string FechaImpresion = DateTime.Now.ToShortDateString();
                string HoraImpresion = DateTime.Now.ToShortTimeString();


                CN_Impresiones objetoCN = new CN_Impresiones();
                objetoCN.InsertarRegistroImpresiones(FechaImpresion,HoraImpresion,IdUsuario,NumFactura,TipoImpresion,Descripcion,localIP,name);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void CrearFactura()
        {
            try
            {

                if (this.cmbTipoMoneda.Text == "Selecciona una Moneda")
                {
                    MessageBox.Show("Primero Selecciona una Moneda", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (this.cmbTipoMoneda.Text != "Selecciona una Moneda")
                {
                    if (this.txtpagoCon.Text == string.Empty)
                    {
                        MessageBox.Show("Error no se ha ingresado con cuanto pagara", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (this.txtpagoCon.Text != string.Empty)
                    {
                        if (this.txtPagoenCordobas.Text == string.Empty)
                        {
                            MessageBox.Show("Primero Ingresa el Monto y Luego Presiona el Monto", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else if (this.txtPagoenCordobas.Text != string.Empty)
                        {
                            //Generaremos el Numero de Carnet dependiendo la caja

                            int IdCaja = Convert.ToInt32(CacheUsuario.IdCaja);
                            if (IdCaja == 1)
                            {
                                this.GenerarCarnet_caja1();
                            }else if(IdCaja == 2)
                            {
                                this.GenerarCarnet_caja2();
                            }else if (IdCaja == 3)
                            {
                                this.GenerarCarnet_caja3();
                            }

                          //  string CodFact = GenerarNumeroFactura();

                            //Actualizaremos los datos de la Factura General

                            string FechaActual = Convert.ToString(DateTime.Now.ToShortDateString());
                            CN_FacturaGeneral objetoCN = new CN_FacturaGeneral();
                            objetoCN.ActualizarFacturaGeneral(NumeroFactura,"EFECTIVO",this.txtSubtotal.Text,"0",this.TxtTotalPago.Text,this.cmbTipoMoneda.SelectedValue.ToString(),"6",FechaActual,this.txtNombredeFactura.Text,this.txtcodigoCarnet.Text,"",this.lblfactura.Text);
                            

                            //Verificaremos que se haya actualizado la factura
                            CN_FacturaGeneral objetoCN2 = new CN_FacturaGeneral();
                            DataTable tabla = new DataTable();
                            tabla = objetoCN2.MostrarFacturaRealizada(NumeroFactura);
                            if (tabla.Rows.Count == 0)
                            {
                                //aqui estara el codigo en el caso de que no se haya agregado
                                CN_FacturaGeneral objetoCNFac = new CN_FacturaGeneral();
                                objetoCNFac.ActualizarFacturaGeneralPendiente("1");

                                MessageBox.Show("Error de Sistema, Intentelo de nuevo", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                               
                                this.Close();
                                this.Dispose();

                            }else if (tabla.Rows.Count != 0)
                            {
                                //Inserta todo el detalle de la Factura
                                objetoCN2.InsertarDetallePago(NumeroFactura,"EFECTIVO", this.txtpagoCon.Text, this.cmbTipoMoneda.SelectedValue.ToString(), this.txtTasaCambio.Text, this.txtPagoenCordobas.Text, TxtTotalPago.Text, this.txtCambio.Text, "");
                                /////////////////////////////////////////////////////////////////////

                                //Insertar Movimiento de Caja
                                CN_FacturaGeneral objetoCN3 = new CN_FacturaGeneral();
                                string HoraRegistro = DateTime.Now.ToLongTimeString();
                                string Fecha = DateTime.Now.ToShortDateString();
                               
                                objetoCN3.InsertarMovimientoCaja("FACTURA",NumeroFactura, "ENTRADA", this.TxtTotalPago.Text, "1",Fecha, CacheUsuario.IdUsuario, CacheUsuario.IdCaja, HoraRegistro);
                                /////////////////////////////////////////////////////////////////////

                                //Zen.Barcode.Code128BarcodeDraw mGenerador = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                                //pxBarcode.Image = mGenerador.Draw(NumeroFactura,60);

                                CN_FacturaGeneral objetoFact = new CN_FacturaGeneral();
                                foreach (DataGridViewRow row in dataDetalles.Rows)
                                {
                                    objetoFact.ActualizarFacturaDetalle(NumeroFactura,row.Cells["Id_Factura_Detalle"].Value.ToString());
                                }

                                CN_FacturaGeneral objetoFact2 = new CN_FacturaGeneral();
                                foreach (DataGridViewRow row in dataMensualidades.Rows)
                                {
                                    //Aca actualizamos a estado completado la mensualidad
                                    objetoFact2.ActualizarMensualidadFactura(row.Cells["Id_Detalle_Programacion"].Value.ToString());

                                    //Aca Actualizamos la tabla de FacturaMensualidades
                                    objetoFact2.ActualizarMensualidadesFactura(row.Cells["Id_Factura_Mensualidades"].Value.ToString(),NumeroFactura);

                                }

                                CN_FacturaGeneral objetoAbono = new CN_FacturaGeneral();
                                foreach (DataGridViewRow row in dataAbonos.Rows)
                                {
                                    objetoAbono.ActualizarAbonoFactura(row.Cells["Id_Abono"].Value.ToString());

                                }
                                
                                CacheReferencia.Subtotal = this.txtSubtotal.Text;
                                CacheReferencia.Descuento = this.txtDescuento.Text;
                                CacheReferencia.Iva = this.txtva.Text;
                                CacheReferencia.Total = this.TxtTotalPago.Text;
                                CacheReferencia.PagoCon = this.txtPagoenCordobas.Text;
                                CacheReferencia.Cambio = this.txtCambio.Text;


                             

                                this.Imprimir();

                                this.Hide();

                                Frm_Cambio frm = new Frm_Cambio();
                                frm.Show();



                            }

                          

                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema" + ex);
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




        /// <summary>
        /// Aqui Generamos el Nuevo codigo que tendra la Factura
        /// </summary>
        private void GenerarCarnet()
        {
            try
            {
                CN_Factura objetoCN = new CN_Factura();
                DataTable Tabla = new DataTable();
                Tabla = objetoCN.ObtenerCodigoFact();
                VariableFactura = Tabla.Rows[0][0].ToString();
                NumeroFactura = Tabla.Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarCarnet_caja1()
        {
            try
            {
                CN_Factura objetoCN = new CN_Factura();
                DataTable Tabla = new DataTable();
                Tabla = objetoCN.ObtenerCodigoFactura_Caja1();
                VariableFactura = Tabla.Rows[0][0].ToString();
                NumeroFactura = Tabla.Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GenerarCarnet_caja2()
        {
            try
            {
                CN_Factura objetoCN = new CN_Factura();
                DataTable Tabla = new DataTable();
                Tabla = objetoCN.ObtenerCodigoFactura_Caja2();
                VariableFactura = Tabla.Rows[0][0].ToString();
                NumeroFactura = Tabla.Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarCarnet_caja3()
        {
            try
            {
                CN_Factura objetoCN = new CN_Factura();
                DataTable Tabla = new DataTable();
                Tabla = objetoCN.ObtenerCodigoFactura_Caja3();
                VariableFactura = Tabla.Rows[0][0].ToString();
                NumeroFactura = Tabla.Rows[0][0].ToString();
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
                if (this.cmbTipoMoneda.Text == "Selecciona una Moneda")
                {
                    MessageBox.Show("Primero Selecciona una Moneda", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (this.cmbTipoMoneda.Text != "Selecciona una Moneda")
                {
                    if (this.txtpagoCon.Text == string.Empty)
                    {
                        MessageBox.Show("Error no se ha ingresado con cuanto pagara", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (this.txtpagoCon.Text != string.Empty)
                    {
                        if (this.txtPagoenCordobas.Text == string.Empty)
                        {
                            MessageBox.Show("Primero Ingresa el Monto y Luego Presiona el Monto", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (this.txtPagoenCordobas.Text != string.Empty)
                        {
                            //Generaremos el Numero de Carnet
                            int IdCaja = Convert.ToInt32(CacheUsuario.IdCaja);
                            if (IdCaja == 1)
                            {
                                this.GenerarCarnet_caja1();
                            }
                            else if (IdCaja == 2)
                            {
                                this.GenerarCarnet_caja2();
                            }
                            else if (IdCaja == 3)
                            {
                                this.GenerarCarnet_caja3();
                            }
                            string FechaActual = Convert.ToString(DateTime.Now.ToShortDateString());
                            CN_FacturaGeneral objetoCN = new CN_FacturaGeneral();
                            objetoCN.ActualizarFacturaGeneral(NumeroFactura, "EFECTIVO", this.txtSubtotal.Text, "0", this.TxtTotalPago.Text, this.cmbTipoMoneda.SelectedValue.ToString(), "6", FechaActual, this.txtNombredeFactura.Text, this.txtcodigoCarnet.Text, "", this.lblfactura.Text);
                        
                            //Verificaremos que se haya actualizado la factura
                            CN_FacturaGeneral objetoCN2 = new CN_FacturaGeneral();
                            DataTable tabla = new DataTable();
                            tabla = objetoCN2.MostrarFacturaRealizada(NumeroFactura);
                            if (tabla.Rows.Count == 0)
                            {
                                //aqui estara el codigo en el caso de que no se haya agregado
                                CN_FacturaGeneral objetoCNFac = new CN_FacturaGeneral();
                                objetoCNFac.ActualizarFacturaGeneralPendiente("1");

                                MessageBox.Show("Error de Sistema, Intentelo de nuevo", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                this.Close();
                                this.Dispose();

                            }
                            else if (tabla.Rows.Count != 0)
                            {
                                //Inserta todo el detalle de la Factura
                                objetoCN2.InsertarDetallePago(NumeroFactura, "EFECTIVO", this.txtpagoCon.Text, this.cmbTipoMoneda.SelectedValue.ToString(), this.txtTasaCambio.Text, this.txtPagoenCordobas.Text, TxtTotalPago.Text, this.txtCambio.Text, "");
                                /////////////////////////////////////////////////////////////////////

                                //Insertar Movimiento de Caja
                                CN_FacturaGeneral objetoCN3 = new CN_FacturaGeneral();
                                string HoraRegistro = DateTime.Now.ToLongTimeString();
                                string Fecha = DateTime.Now.ToShortDateString();

                                objetoCN3.InsertarMovimientoCaja("FACTURA",NumeroFactura, "ENTRADA", this.TxtTotalPago.Text, "1", Fecha, CacheUsuario.IdUsuario, CacheUsuario.IdCaja, HoraRegistro);
                                /////////////////////////////////////////////////////////////////////

                                //Zen.Barcode.Code128BarcodeDraw mGenerador = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                                //pxBarcode.Image = mGenerador.Draw(NumeroFactura,60);

                                CN_FacturaGeneral objetoFact = new CN_FacturaGeneral();
                                foreach (DataGridViewRow row in dataDetalles.Rows)
                                {
                                    objetoFact.ActualizarFacturaDetalle(NumeroFactura, row.Cells["Id_Factura_Detalle"].Value.ToString());
                                }

                                CN_FacturaGeneral objetoFact2 = new CN_FacturaGeneral();
                                foreach (DataGridViewRow row in dataMensualidades.Rows)
                                {
                                    //Aca actualizamos a estado completado la mensualidad
                                    objetoFact2.ActualizarMensualidadFactura(row.Cells["Id_Detalle_Programacion"].Value.ToString());

                                    //Aca Actualizamos la tabla de FacturaMensualidades
                                    objetoFact2.ActualizarMensualidadesFactura(row.Cells["Id_Factura_Mensualidades"].Value.ToString(), NumeroFactura);

                                }

                                CN_FacturaGeneral objetoAbono = new CN_FacturaGeneral();
                                foreach (DataGridViewRow row in dataAbonos.Rows)
                                {
                                    objetoAbono.ActualizarAbonoFactura(row.Cells["Id_Abono"].Value.ToString());
                                    
                                }

                               


                                CacheReferencia.Subtotal = this.txtSubtotal.Text;
                                CacheReferencia.Descuento = this.txtDescuento.Text;
                                CacheReferencia.Iva = this.txtva.Text;
                                CacheReferencia.Total = this.TxtTotalPago.Text;
                                CacheReferencia.PagoCon = this.txtPagoenCordobas.Text;
                                CacheReferencia.Cambio = this.txtCambio.Text;

                                //this.Imprimir();
                                //this.InsertarSolvencia("EFECTIVO");
                               // GuardarRegistroImpresion(CacheUsuario.IdUsuario, NumeroFactura, "ORIGINAL", "IMPRESION FACTURA ORIGINAL");

                                this.Hide();

                                Frm_Cambio frm = new Frm_Cambio();
                                frm.Show();
                                
                            }
                            
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema" + ex);
            }
        }

        private void txtcodigoCarnet_TextChanged(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            CN_Estudiantes estudiante = new CN_Estudiantes();

            tabla = estudiante.BuscarNumeroTelefonico(this.txtcodigoCarnet.Text);

            if (tabla.Rows.Count == 0)
            {
                this.txtCelular.Text = string.Empty;
            }
            else
            {
                this.txtCelular.Text = tabla.Rows[0][0].ToString();
            
            }

            }

        private void MensajeWhatsapp()
        {
            Mensaje = " *Notificacion Cecnic Managua* " +
                       " Muchas gracias  por tu pago  " +
                        "=== Detalles de Pago   ===   " +
                        "Subtotal                     "+
                       " Descuento                    " +
                       "Total                         "+

                       "Pago Realizado Exitosamente    "+
                       "===========================";

            this.sendWhatsApp("76521745",Mensaje);

        }

        private void sendWhatsApp(string number, string message)

        {

            try

            {

                if (number == "")

                {

                    MessageBox.Show("No hay ningun numero Agregado");

                }

                if (number.Length <= 8)

                {

                    MessageBox.Show("Inidan Code added automatically");

                    number = "+505" + number;

                }

                number = number.Replace(" ", "");



                System.Diagnostics.Process.Start("http://api.whatsapp.com/send?phone=" + number + "&text=" + message);

            }

            catch (Exception ex)

            {
                MessageBox.Show("Error de SIstema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                
                    if (cmbTipoMoneda.Text == "Selecciona una Moneda")
                    {
                        MessageBox.Show("Selecciona una Moneda Primeramente");
                    }
                    else if (this.cmbTipoMoneda.Text != "Selecciona una Moneda")
                    {
                       if(this.txtpagoCon.Text == string.Empty)
                       {
                        MessageBox.Show("Ingresa la cantidad con que pagara", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       }else{
                        double ValorX, ValorY;
                        ValorX = Convert.ToDouble(this.txtpagoCon.Text);
                        ValorY = Convert.ToDouble(this.TxtTotalPago.Text);
                        if (ValorX < ValorY)
                        {
                            MessageBox.Show("La cantidad que ingreso es menor al monto a pagar", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }else
                        {
                            this.groupBox2.Enabled = true;
                            this.Calculos();
                        }
                        
                    }
                       
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try {
                this.LimpiarGroupBoxOtroPago();
                this.EleccionTipoPago();
                this.SeleccionTipoPago();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex);
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.LimpiarGroupBoxEfectivo();
                this.EleccionTipoPago();
                this.SeleccionTipoPago();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.LimpiarGroupBoxEfectivo();
                this.EleccionTipoPago();
                this.SeleccionTipoPago();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex);
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.LimpiarGroupBoxEfectivo();
                this.EleccionTipoPago();
                this.SeleccionTipoPago();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex);
            }
        }

        private void LimpiarGroupBoxEfectivo()
        {
            this.txtpagoCon.Text = string.Empty;
            this.txtPagoenCordobas.Text = string.Empty;
            this.txtCambio.Text = string.Empty;

        }

        private void LimpiarGroupBoxOtroPago()
        {
            this.textBox4.Text = string.Empty;
            this.textBox5.Text = string.Empty;
        }

        private void LimpiarCambioDolar()
        {
            this.txtCantidadDolar.Text = string.Empty;
            this.TxtCambioEnCordobas.Text = string.Empty;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtCantidadDolar.Text = "0";
                this.groupBox2.Enabled = false;
                this.groupBox6.Enabled = false;
                this.groupBox10.Enabled = true;
                this.groupBox10.Visible = true;
                this.txtCantidadDolar.Focus();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                this.groupBox2.Enabled = true;
                this.groupBox6.Enabled = true;
                this.groupBox10.Enabled = true;
                this.groupBox10.Visible = false;
                this.LimpiarCambioDolar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema" + ex);
            }
        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.TxtCambioEnCordobas.Text == string.Empty)
                {
                    MessageBox.Show("Campo Vacio", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }else
                {
                    this.txtpagoCon.Text = this.TxtCambioEnCordobas.Text;
                    this.TxtCambioEnCordobas.Text = string.Empty;
                    this.groupBox2.Enabled = true;
                    this.groupBox6.Enabled = true;
                    this.groupBox10.Enabled = true;
                    this.groupBox10.Visible = false;
                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema" + ex);
            }
        }

        private void Calcular()
        {
            double ValorTexto = 0;
            double ValorDolar = Convert.ToDouble(this.txtTipoCambio.Text);
            double Total = 0;

            try
            {
                if (this.txtCantidadDolar.Text == string.Empty)
                {
                    MessageBox.Show("Campo vacio, ingrese una cantidad","MENSAJE",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    this.TxtCambioEnCordobas.Text = string.Empty;
                } else if (this.txtCantidadDolar.Text != string.Empty )
                {
                    ValorTexto = Convert.ToDouble(this.txtCantidadDolar.Text);
                    Total = ValorTexto * ValorDolar;
                    this.TxtCambioEnCordobas.Text = Total.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema" + ex);
                

            }


               
        }

        private void txtCantidadDolar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) /*&&*/
            //    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtCantidadDolar_TextChanged(object sender, EventArgs e)
        {
            this.Calcular();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            CN_Movimientos objetoCN = new CN_Movimientos();

            tabla = objetoCN.VerificarSiExisteReferencia(this.textBox4.Text);
            if (tabla.Rows.Count == 0)
            {
                //Si no esta Registrada

                this.textBox5.Enabled = true;

            }
            else if (tabla.Rows.Count != 0)
            {
                //Si esta Registrada

                CacheReferencia.Factura = tabla.Rows[0][0].ToString();
                CacheReferencia.Tipo = tabla.Rows[0][1].ToString();
                CacheReferencia.NReferencia = tabla.Rows[0][2].ToString();
                CacheReferencia.FechaRegistro = tabla.Rows[0][3].ToString();
                CacheReferencia.Estudiante = tabla.Rows[0][4].ToString();
                CacheReferencia.Carnet = tabla.Rows[0][5].ToString();

                this.textBox5.Enabled = false;

                Frm_VerificacionReferencia frm = new Frm_VerificacionReferencia();
                frm.Show();

            }
        }


        private void cerrarform(object sender, EventArgs e)
        {

            try
            {
                CacheDetalleProgramacion.NombreCurso = string.Empty;
                CacheDetalleProgramacion.Dias = string.Empty;
                CacheDetalleProgramacion.Horario = string.Empty;


                CN_FacturaGeneral objetoCNFac = new CN_FacturaGeneral();
                objetoCNFac.ActualizarFacturaGeneralPendiente("1");
                
                LiberadorDeMemoria objeto1 = new LiberadorDeMemoria();
                objeto1.alzheimer();

                this.Hide();




            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void CrearFacturaDeposito()
        {
            try
            {
                if (this.textBox5.Text != string.Empty)
                {

                    double TotalAcancelar, MontoPgado;
                    TotalAcancelar = Convert.ToDouble(this.textBox1.Text);
                    MontoPgado = Convert.ToDouble(this.textBox5.Text);

                    if (TotalAcancelar == MontoPgado)
                    {
                        //Generaremos el Numero de Carnet
                        int IdCaja = Convert.ToInt32(CacheUsuario.IdCaja);
                        if (IdCaja == 1)
                        {
                            this.GenerarCarnet_caja1();
                        }
                        else if (IdCaja == 2)
                        {
                            this.GenerarCarnet_caja2();
                        }
                        else if (IdCaja == 3)
                        {
                            this.GenerarCarnet_caja3();
                        }


                        //Actualizaremos los datos de la Factura General

                        string FechaActual = Convert.ToString(DateTime.Now.ToShortDateString());
                        CN_FacturaGeneral objetoCN = new CN_FacturaGeneral();
                        objetoCN.ActualizarFacturaGeneral(NumeroFactura, this.txtTipoPago.Text, this.txtSubtotal.Text, "0", this.TxtTotalPago.Text, "1", "6", FechaActual, this.txtNombredeFactura.Text, this.txtcodigoCarnet.Text, "", this.lblfactura.Text);


                        //Verificaremos que se haya actualizado la factura
                        CN_FacturaGeneral objetoCN2 = new CN_FacturaGeneral();
                        DataTable tabla = new DataTable();
                        tabla = objetoCN2.MostrarFacturaRealizada(NumeroFactura);
                        if (tabla.Rows.Count == 0)
                        {
                            //aqui estara el codigo en el caso de que no se haya agregado
                         
                            CN_FacturaGeneral objetoCNFac = new CN_FacturaGeneral();
                            objetoCNFac.ActualizarFacturaGeneralPendiente("1");

                            MessageBox.Show("Error de Sistema, Intentelo de nuevo", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            this.Close();
                            this.Dispose();

                        }
                        else if (tabla.Rows.Count != 0)
                        {
                            //Inserta todo el detalle de la Factura
                            objetoCN2.InsertarDetallePago(NumeroFactura, this.txtTipoPago.Text, this.textBox5.Text, "1", "1", this.textBox5.Text, this.textBox5.Text, "0", this.textBox4.Text);
                            /////////////////////////////////////////////////////////////////////

                            //Insertar Movimiento de Caja
                            CN_FacturaGeneral objetoCN3 = new CN_FacturaGeneral();
                            string HoraRegistro = DateTime.Now.ToLongTimeString();
                            string Fecha = DateTime.Now.ToShortDateString();

                            objetoCN3.InsertarMovimientoCaja("FACTURA", NumeroFactura, "ENTRADA", this.textBox5.Text, "1", Fecha, CacheUsuario.IdUsuario, CacheUsuario.IdCaja, HoraRegistro);
                            /////////////////////////////////////////////////////////////////////

                            //Zen.Barcode.Code128BarcodeDraw mGenerador = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                            //pxBarcode.Image = mGenerador.Draw(NumeroFactura,60);                   

                            CN_FacturaGeneral objetoFact = new CN_FacturaGeneral();
                            foreach (DataGridViewRow row in dataDetalles.Rows)
                            {
                                objetoFact.ActualizarFacturaDetalle(NumeroFactura, row.Cells["Id_Factura_Detalle"].Value.ToString());
                            }

                            CN_FacturaGeneral objetoFact2 = new CN_FacturaGeneral();
                            foreach (DataGridViewRow row in dataMensualidades.Rows)
                            {
                                //Aca actualizamos a estado completado la mensualidad
                                objetoFact2.ActualizarMensualidadFactura(row.Cells["Id_Detalle_Programacion"].Value.ToString());

                                //Aca Actualizamos la tabla de FacturaMensualidades
                                objetoFact2.ActualizarMensualidadesFactura(row.Cells["Id_Factura_Mensualidades"].Value.ToString(), NumeroFactura);

                            }

                            CN_FacturaGeneral objetoAbono = new CN_FacturaGeneral();
                            foreach (DataGridViewRow row in dataAbonos.Rows)
                            {
                                objetoAbono.ActualizarAbonoFactura(row.Cells["Id_Abono"].Value.ToString());


                            }

                            

                            //this.InsertarSolvencia("OTRO");
                            // GuardarRegistroImpresion(CacheUsuario.IdUsuario, NumeroFactura, "ORIGINAL", "IMPRESION FACTURA ORIGINAL");

                            this.Imprimir2();
                            this.Hide();
                            
                        }
                        
                    }
                    else if (TotalAcancelar != MontoPgado)
                    {
                        MessageBox.Show("El monto debe ser Igual a la Cantidad a Cancelar", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }
                else if (this.textBox5.Text == string.Empty)
                {
                    MessageBox.Show("No se ha ingresado el Monto, verifique por favor", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema" + ex);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                this.CrearFacturaDeposito();
                
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
                e.Graphics.DrawString("FACTURA." + NumeroFactura, font2, Brushes.Black, new RectangleF(30, 74, 250, 30));
                e.Graphics.DrawString("_________________________________", font2, Brushes.Black, new RectangleF(10, 80, 250, 30));
                e.Graphics.DrawString("Fecha " + tiempo, font3, Brushes.Black, new RectangleF(20, 98, 250, 30));
                e.Graphics.DrawString("Cajero: " + txtCajero.Text, font4, Brushes.Black, new RectangleF(10, 116, 250, 30));
                e.Graphics.DrawString("_________________________________", font2, Brushes.Black, new RectangleF(10, 122, 250, 30));

                e.Graphics.DrawString(txtNombredeFactura.Text, font4, Brushes.Black, new RectangleF(10, 145, 250, 60));
                e.Graphics.DrawString("Carnet : " + txtcodigoCarnet.Text, font4, Brushes.Black, new RectangleF(10, 165, 250, 30));
                e.Graphics.DrawString(this.txtCurso.Text, font4, Brushes.Black, new RectangleF(10, 189, 250, 30));


                i = 215;

                foreach (DataGridViewRow row in dataDetalles.Rows)
                {
                    e.Graphics.DrawString(row.Cells["Observaciones"].Value.ToString(), font4, Brushes.Black, new RectangleF(10, i, 160, 60));
                    e.Graphics.DrawString("C$" + row.Cells["Total_en_Cordobas"].Value.ToString(), font4, Brushes.Black, new RectangleF(170, i, 110, 60));

                    i = i + 25;
                }

                i = i + 18;

                e.Graphics.DrawString("NO.ITEMS.............................", font3, Brushes.Black, new RectangleF(10, i, 250, 30));
                e.Graphics.DrawString(" " + this.dataDetalles.Rows.Count.ToString(), font3, Brushes.Black, new RectangleF(170, i, 250, 30));

                i = i + 18;

                e.Graphics.DrawString("TOTAL   .............................", font3, Brushes.Black, new RectangleF(10, i, 250, 30));
                e.Graphics.DrawString("C$" + this.TxtTotalPago.Text, font3, Brushes.Black, new RectangleF(170, i, 250, 30));

                i = i + 18;

                e.Graphics.DrawString("PAGO CON " + this.txtTipoPago.Text.ToUpper(), font3, Brushes.Black, new RectangleF(10, i, 250, 30));
                e.Graphics.DrawString(this.textBox4.Text, font3, Brushes.Black, new RectangleF(150, i, 250, 30));

         
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
                i = i + 18;
                e.Graphics.DrawString("___________________________", font2, Brushes.Black, new RectangleF(10, i, 250, 40));
                i = i + 30;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema" + ex);

            }

        }

        private void button8_Click(object sender, EventArgs e)
        {

            try
            {
                if (this.textBox5.Text != string.Empty)
                {

                    double TotalAcancelar, MontoPgado;
                    TotalAcancelar = Convert.ToDouble(this.textBox1.Text);
                    MontoPgado = Convert.ToDouble(this.textBox5.Text);

                    if (TotalAcancelar == MontoPgado)
                    {
                        //Generaremos el Numero de Carnet
                        int IdCaja = Convert.ToInt32(CacheUsuario.IdCaja);
                        if (IdCaja == 1)
                        {
                            this.GenerarCarnet_caja1();
                        }
                        else if (IdCaja == 2)
                        {
                            this.GenerarCarnet_caja2();
                        }
                        else if (IdCaja == 3)
                        {
                            this.GenerarCarnet_caja3();
                        }


                        //Actualizaremos los datos de la Factura General

                        string FechaActual = Convert.ToString(DateTime.Now.ToShortDateString());
                        CN_FacturaGeneral objetoCN = new CN_FacturaGeneral();
                        objetoCN.ActualizarFacturaGeneral(NumeroFactura, this.txtTipoPago.Text, this.txtSubtotal.Text, "0", this.TxtTotalPago.Text, "1", "6", FechaActual, this.txtNombredeFactura.Text, this.txtcodigoCarnet.Text, "", this.lblfactura.Text);


                        //Verificaremos que se haya actualizado la factura
                        CN_FacturaGeneral objetoCN2 = new CN_FacturaGeneral();
                        DataTable tabla = new DataTable();
                        tabla = objetoCN2.MostrarFacturaRealizada(NumeroFactura);
                        if (tabla.Rows.Count == 0)
                        {
                            //aqui estara el codigo en el caso de que no se haya agregado

                            CN_FacturaGeneral objetoCNFac = new CN_FacturaGeneral();
                            objetoCNFac.ActualizarFacturaGeneralPendiente("1");

                            MessageBox.Show("Error de Sistema, Intentelo de nuevo", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            this.Close();
                            this.Dispose();

                        }
                        else if (tabla.Rows.Count != 0)
                        {
                            //Inserta todo el detalle de la Factura
                            objetoCN2.InsertarDetallePago(NumeroFactura, this.txtTipoPago.Text, this.textBox5.Text, "1", "1", this.textBox5.Text, this.textBox5.Text, "0", this.textBox4.Text);
                            /////////////////////////////////////////////////////////////////////

                            //Insertar Movimiento de Caja
                            CN_FacturaGeneral objetoCN3 = new CN_FacturaGeneral();
                            string HoraRegistro = DateTime.Now.ToLongTimeString();
                            string Fecha = DateTime.Now.ToShortDateString();

                            objetoCN3.InsertarMovimientoCaja("FACTURA", NumeroFactura, "ENTRADA", this.textBox5.Text, "1", Fecha, CacheUsuario.IdUsuario, CacheUsuario.IdCaja, HoraRegistro);
                            /////////////////////////////////////////////////////////////////////

                            //Zen.Barcode.Code128BarcodeDraw mGenerador = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                            //pxBarcode.Image = mGenerador.Draw(NumeroFactura,60);                   

                            CN_FacturaGeneral objetoFact = new CN_FacturaGeneral();
                            foreach (DataGridViewRow row in dataDetalles.Rows)
                            {
                                objetoFact.ActualizarFacturaDetalle(NumeroFactura, row.Cells["Id_Factura_Detalle"].Value.ToString());
                            }

                            CN_FacturaGeneral objetoFact2 = new CN_FacturaGeneral();
                            foreach (DataGridViewRow row in dataMensualidades.Rows)
                            {
                                //Aca actualizamos a estado completado la mensualidad
                                objetoFact2.ActualizarMensualidadFactura(row.Cells["Id_Detalle_Programacion"].Value.ToString());

                                //Aca Actualizamos la tabla de FacturaMensualidades
                                objetoFact2.ActualizarMensualidadesFactura(row.Cells["Id_Factura_Mensualidades"].Value.ToString(), NumeroFactura);

                            }

                            CN_FacturaGeneral objetoAbono = new CN_FacturaGeneral();
                            foreach (DataGridViewRow row in dataAbonos.Rows)
                            {
                                objetoAbono.ActualizarAbonoFactura(row.Cells["Id_Abono"].Value.ToString());

                            }



                          

                          //  this.InsertarSolvencia("OTRO");
                            // GuardarRegistroImpresion(CacheUsuario.IdUsuario, NumeroFactura, "ORIGINAL", "IMPRESION FACTURA ORIGINAL");
                            //this.Imprimir2();
                            this.Hide();

                        }

                    }
                    else if (TotalAcancelar != MontoPgado)
                    {
                        MessageBox.Show("El monto debe ser Igual a la Cantidad a Cancelar", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }
                else if (this.textBox5.Text == string.Empty)
                {
                    MessageBox.Show("No se ha ingresado el Monto, verifique por favor", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema" + ex);
            }


        }

        /**********************************************************************************************************************/
        //Codigo para generar un Numero de factura



        public static string GenerarNumeroFactura()
        {
            CD_Conexion conexion = new CD_Conexion();


            string numeroFactura = "";

            using (SqlConnection connection = new SqlConnection(conexion.Conexion.ToString()))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.Transaction = transaction;

                    SqlCommand command2 = connection.CreateCommand();
                    command2.Transaction = transaction;

                    // Obtener el número consecutivo de la factura y actualizarlo en la tabla
                    command.CommandText = "UPDATE Facturas SET Consecutivo = Consecutivo + 1  WHERE Id = 1";
                    command.CommandText = "UPDATE Facturas SET NumeroFactura =  CONCAT('FAC',YEAR(GETDATE()),Consecutivo)";
                    command2.CommandText = "select NumeroFactura from Facturas";
                    numeroFactura = (string)command2.ExecuteScalar();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }

            return numeroFactura;
        }
    }
}


