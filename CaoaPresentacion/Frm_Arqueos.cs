using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using System.Globalization;
using System.Drawing.Printing;
using System.Net;
using System.Net.NetworkInformation;
using System.Data.SqlClient;
using CapaDatos;


namespace CaoaPresentacion
{
    public partial class Frm_Arqueos : Form
    {
        CN_Arqueos objetoCN = new CN_Arqueos();
        CN_Movimientos objetoMovimiento1 = new CN_Movimientos();
        CN_Movimientos objetoMovimiento2 = new CN_Movimientos();
        CN_Movimientos objetoMovimiento3 = new CN_Movimientos();
        CN_Movimientos objetoMovimiento4 = new CN_Movimientos();
        CN_Movimientos objetoMovimiento5 = new CN_Movimientos();
        CN_Movimientos objetoMovimiento6 = new CN_Movimientos();
        CN_Movimientos objetoCN2 = new CN_Movimientos();
      

        double TotalEntradas = 0, TotalSalidas = 0 , TotalFacturasAnuladas = 0;
        double ROC = 0;
        double ROS = 0;

        string fechaVerificacion = DateTime.Now.ToShortDateString();

        CD_Conexion conexion = new CD_Conexion();


        public Frm_Arqueos()
        {
            InitializeComponent();
            timer1.Start();
            this.Cargar_ComboCaja();
            this.combocaja.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        int i;

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblFecha.Text = DateTime.Now.ToString();
        }

        private void Frm_Arqueos_Load(object sender, EventArgs e)
        {
            timer1.Start();
            this.lblUsuario.Text = CacheUsuario.Nombres + "  " + CacheUsuario.Apellidos;
            this.Contar();
            this.groupBox5.Visible = false;
          

            
            
        }

        private void ContadorROCYROS()
        {
            int contRoc = 0;
            int contRos = 0;

            foreach (DataGridViewRow row in dataDetalleFactura.Rows)
            {
                if (row.Cells["Tipo"].Value.ToString() == "ROC")
                {
                    contRoc = contRoc + 1;
                }

                if (row.Cells["Tipo"].Value.ToString() == "ROS")
                {
                    contRos = contRos + 1;
                }


                this.label25.Text = "ROC: " + contRoc;
                this.label26.Text = "ROS: " + contRos;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.CargarCierreCaja();
               
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void MostrarSalidas1()
        {
            DataTable tabla = new DataTable();
            DateTime FechaActual = DateTime.ParseExact(fechaVerificacion, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            tabla = objetoMovimiento1.ObteniendoTotalSalidas("1",FechaActual,"SALIDA");
            //CacheUsuario.IdCaja
            if (tabla.Rows.Count == 0)
            {
                this.txtSalidas.Text = "0";
            }
            else
            {
                this.txtSalidas.Text = tabla.Rows[0][0].ToString();
            }

        }


        private void MostrarEntradas1()
        {
            DataTable tabla = new DataTable();
            DateTime FechaActual = DateTime.ParseExact(fechaVerificacion, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            tabla = objetoMovimiento2.ObteniendoTotalDia("1", FechaActual,"ENTRADA");
            if (tabla.Rows.Count == 0) 
            {
                this.txtEntrada.Text = "0";
            } else
            {
                this.txtEntrada.Text = tabla.Rows[0][0].ToString();
            }
        }

        private void CalcularTotal1()
        {
            if (this.txtEntrada.Text == string.Empty && this.txtSalidas.Text == string.Empty)
            {
             //   MessageBox.Show("Error no se han Encontrado Movimientos","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.txtEntrada.Text = "0";
                this.txtSalidas.Text = "0";
                this.txtTotal.Text = "0";
            } else {
                double Entradas;
                double Salidas;

                if (this.txtEntrada.Text == string.Empty)
                {
                    Entradas = 0;
                    this.txtEntrada.Text = "0";

                    if (this.txtSalidas.Text == string.Empty)
                    {
                        Salidas = 0;
                        this.txtSalidas.Text = "0";

                        double Total = Entradas - Salidas;
                        this.txtTotal.Text = Total.ToString();
                    }
                    else if (this.txtSalidas.Text != string.Empty)
                    {
                        Salidas = Convert.ToDouble(this.txtSalidas.Text);

                        double Total = Entradas - Salidas;
                        this.txtTotal.Text = Total.ToString();

                    }

                }else if(this.txtEntrada.Text != string.Empty)
                {
                    Entradas = Convert.ToDouble(this.txtEntrada.Text);

                    if (this.txtSalidas.Text == string.Empty)
                    {
                        Salidas = 0;
                        this.txtSalidas.Text = "0";

                        double Total = Entradas - Salidas;
                        this.txtTotal.Text = Total.ToString();
                    }
                    else if (this.txtSalidas.Text != string.Empty)
                    {
                        Salidas = Convert.ToDouble(this.txtSalidas.Text);

                        double Total = Entradas - Salidas;
                        this.txtTotal.Text = Total.ToString();

                    }

                }
         
               
          


            }
        }


        private void MostrarSalidas2()
        {
            DataTable tabla = new DataTable();
            DateTime FechaActual = DateTime.ParseExact(fechaVerificacion, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            tabla = objetoMovimiento3.ObteniendoTotalSalidas("2", FechaActual, "SALIDA");
            //CacheUsuario.IdCaja
            if (tabla.Rows.Count == 0)
            {
                this.txtSalidas2.Text = "0";
            }
            else
            {
                this.txtSalidas2.Text = tabla.Rows[0][0].ToString();
            }

        }


        private void MostrarEntradas2()
        {
            DataTable tabla = new DataTable();
            DateTime FechaActual = DateTime.ParseExact(fechaVerificacion, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            tabla = objetoMovimiento4.ObteniendoTotalDia("2", FechaActual, "ENTRADA");
            if (tabla.Rows.Count == 0)
            {
                this.txtEntrada2.Text = "0";
            }
            else
            {
                this.txtEntrada2.Text = tabla.Rows[0][0].ToString();
            }
        }

        private void CalcularTotal2()
        {
            if (this.txtEntrada2.Text == string.Empty && this.txtSalidas2.Text == string.Empty)
            {
                //   MessageBox.Show("Error no se han Encontrado Movimientos","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.txtEntrada2.Text = "0";
                this.txtSalidas2.Text = "0";
                this.txtTotal2.Text = "0";
            }
            else
            {
                double Entradas;
                double Salidas;

                if (this.txtEntrada2.Text == string.Empty)
                {
                    Entradas = 0;
                    this.txtEntrada2.Text = "0";

                    if (this.txtSalidas2.Text == string.Empty)
                    {
                        Salidas = 0;
                        this.txtSalidas2.Text = "0";

                        double Total = Entradas - Salidas;
                        this.txtTotal2.Text = Total.ToString();
                    }
                    else if (this.txtSalidas2.Text != string.Empty)
                    {
                        Salidas = Convert.ToDouble(this.txtSalidas2.Text);

                        double Total = Entradas - Salidas;
                        this.txtTotal2.Text = Total.ToString();

                    }

                }
                else if (this.txtEntrada2.Text != string.Empty)
                {
                    Entradas = Convert.ToDouble(this.txtEntrada2.Text);

                    if (this.txtSalidas2.Text == string.Empty)
                    {
                        Salidas = 0;
                        this.txtSalidas2.Text = "0";

                        double Total = Entradas - Salidas;
                        this.txtTotal2.Text = Total.ToString();
                    }
                    else if (this.txtSalidas2.Text != string.Empty)
                    {
                        Salidas = Convert.ToDouble(this.txtSalidas2.Text);

                        double Total = Entradas - Salidas;
                        this.txtTotal2.Text = Total.ToString();

                    }

                }





            }
        }


        private void MostrarSalidas3()
        {
            DataTable tabla = new DataTable();
            DateTime FechaActual = DateTime.ParseExact(fechaVerificacion, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            tabla = objetoMovimiento5.ObteniendoTotalSalidas("3", FechaActual, "SALIDA");
            //CacheUsuario.IdCaja
            if (tabla.Rows.Count == 0)
            {
                this.txtSalidas3.Text = "0";
            }
            else
            {
                this.txtSalidas3.Text = tabla.Rows[0][0].ToString();
            }

        }


        private void MostrarEntradas3()
        {
            DataTable tabla = new DataTable();
            DateTime FechaActual = DateTime.ParseExact(fechaVerificacion, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            tabla = objetoMovimiento6.ObteniendoTotalDia("3", FechaActual, "ENTRADA");
            if (tabla.Rows.Count == 0)
            {
                this.txtEntrada3.Text = "0";
            }
            else
            {
                this.txtEntrada3.Text = tabla.Rows[0][0].ToString();
            }
        }

        private void CalcularTotal3()
        {
            if (this.txtEntrada3.Text == string.Empty && this.txtSalidas3.Text == string.Empty)
            {
                //   MessageBox.Show("Error no se han Encontrado Movimientos","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.txtEntrada3.Text = "0";
                this.txtSalidas3.Text = "0";
                this.txtTotal3.Text = "0";
            }
            else
            {
                double Entradas;
                double Salidas;

                if (this.txtEntrada3.Text == string.Empty)
                {
                    Entradas = 0;
                    this.txtEntrada3.Text = "0";

                    if (this.txtSalidas3.Text == string.Empty)
                    {
                        Salidas = 0;
                        this.txtSalidas3.Text = "0";

                        double Total = Entradas - Salidas;
                        this.txtTotal3.Text = Total.ToString();
                    }
                    else if (this.txtSalidas3.Text != string.Empty)
                    {
                        Salidas = Convert.ToDouble(this.txtSalidas3.Text);

                        double Total = Entradas - Salidas;
                        this.txtTotal3.Text = Total.ToString();

                    }

                }
                else if (this.txtEntrada3.Text != string.Empty)
                {
                    Entradas = Convert.ToDouble(this.txtEntrada2.Text);

                    if (this.txtSalidas3.Text == string.Empty)
                    {
                        Salidas = 0;
                        this.txtSalidas3.Text = "0";

                        double Total = Entradas - Salidas;
                        this.txtTotal3.Text = Total.ToString();
                    }
                    else if (this.txtSalidas3.Text != string.Empty)
                    {
                        Salidas = Convert.ToDouble(this.txtSalidas3.Text);

                        double Total = Entradas - Salidas;
                        this.txtTotal3.Text = Total.ToString();

                    }

                }





            }
        }

        private void Eliminar()
        {
            this.txtEntrada.Text = string.Empty;
            this.txtSalidas.Text = string.Empty;
            this.txtTotal.Text = string.Empty;
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void CargarCierreCaja()
        {

            //cargamos caja 1
            this.MostrarEntradas1();
            this.MostrarSalidas1();
            this.CalcularTotal1();

            double total1 = Convert.ToDouble(this.txtTotal.Text);
            double TotalRedondeado1 = Math.Round(total1);
            this.txttotal1Redondeado.Text = Convert.ToString(string.Format("{0:N2}",TotalRedondeado1));

            //cargamos caja 2
            this.MostrarEntradas2();
            this.MostrarSalidas2();
            this.CalcularTotal2();

            double total2 = Convert.ToDouble(this.txtTotal2.Text);
            double TotalRedondeado2 = Math.Round(total2);
            this.txttotal2Redondeado.Text = Convert.ToString(string.Format("{0:N2}", TotalRedondeado2));
            //cargamos caja 3
            this.MostrarEntradas3();
            this.MostrarSalidas3();
            this.CalcularTotal3();
            
            double total3 = Convert.ToDouble(this.txtTotal3.Text);
            double TotalRedondeado3 = Math.Round(total3);
            this.txttotal3Redondeado.Text = Convert.ToString(string.Format("{0:N2}", TotalRedondeado3));


            double totalGeneral = total1 + total2 + total3;
            this.txttotalGeneral.Text = totalGeneral.ToString();

            double TotalRedondeado = Math.Round(totalGeneral);
            this.txttotalRedondeado.Text = Convert.ToString(string.Format("{0:N2}", TotalRedondeado));

            

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            this.CargarCierreCaja();
        }


        public void Cargar_ComboCaja()
        {
            try
            {
               

                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("select IdCaja,NombreCaja from Tbl_Cajas",conexion.Conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["NombreCaja"] = "Selecciona una Caja";
                dt.Rows.InsertAt(fila, 0);

                combocaja.ValueMember = "IdCaja";
               combocaja.DisplayMember = "NombreCaja";
                combocaja.DataSource = dt;


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                TotalEntradas = 0;
                TotalSalidas = 0;
                TotalFacturasAnuladas = 0;
                ROC = 0;
                ROS = 0;

                this.BuscarMovimientos();

                /////////////////////////
                this.RealizarCalculos();
                this.MostrarRocYRos();
                this.Contar();
                this.ContadorROCYROS();
                this.groupBox5.Visible = true;
                ////////////////////////
                ///
              
                
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Contar()
        {
            this.label23.Text = "Total de Registros "+  dataMovimientos.Rows.Count;
            this.label24.Text = "Total de Registros " + dataDetalleFactura.Rows.Count;
        }

        private void BuscarMovimientos()
        {
            CN_Arqueos objetoCN = new CN_Arqueos();


            DateTime fecha1 = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

          
            this.dataMovimientos.DataSource = objetoCN.BuscarMovimientos(fecha1,this.combocaja.SelectedValue.ToString());
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                // Mandamos a Imprimir la Factura
                printDocument1 = new PrintDocument();
                PrinterSettings ps = new PrinterSettings();
                printDocument1.PrinterSettings = ps;
                printDocument1.PrintPage += ImprimirArqueo;
                printDocument1.Print();

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RealizarCalculos()
        {
            

            foreach (DataGridViewRow row in dataMovimientos.Rows)
            {
                if (row.Cells["Tipo_Movimiento"].Value.ToString() == "ENTRADA")
                {
                    TotalEntradas = TotalEntradas + Convert.ToDouble(row.Cells["Cantidad"].Value);
                }

                if (row.Cells["Tipo_Movimiento"].Value.ToString() == "SALIDA")
                {
                    TotalSalidas = TotalSalidas + Convert.ToDouble(row.Cells["Cantidad"].Value);
                }

                if (row.Cells["Tipo_Movimiento"].Value.ToString() == "FACTURA ANULADA")
                {
                    TotalFacturasAnuladas = TotalFacturasAnuladas + Convert.ToDouble(row.Cells["Cantidad"].Value);
                }

            }

            this.txttotalEntradas.Text = TotalEntradas.ToString();
            this.txtTotalFacAnuladas.Text = TotalFacturasAnuladas.ToString();
            this.txtTotalSalidas.Text = TotalSalidas.ToString();

            this.Txttotalentradass.Text = TotalEntradas.ToString();
            txttotalsalidass.Text = Convert.ToString(TotalFacturasAnuladas + TotalSalidas);
            this.txttotalencaja.Text = Convert.ToString(TotalEntradas - TotalSalidas);

            double Totalencaja = Math.Round(Convert.ToDouble(txttotalencaja.Text));
            this.txttotalencajaredondeado.Text = Convert.ToString(string.Format("{0:N2}", Totalencaja));



        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.txtEntrada.Text = "0";
        }

        private void dataDetalleFactura_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataDetalleFactura.Columns[e.ColumnIndex].Name == "Tipo")
            {
                if (Convert.ToString(e.Value) == "ROC")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.Red;
                }
                else if (Convert.ToString(e.Value) == "ROS")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.Green;
                }
                
            }
        }

        private void ImprimirArqueo(object sender, PrintPageEventArgs e)
        {

            Font font3 = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point);


            DateTime tiempo = new DateTime();
            tiempo = Convert.ToDateTime(DateTime.Now.ToString());
            string NombreCentro = CacheUsuario.NombreSucursal;

            e.Graphics.DrawString("        " + CacheUsuario.NombreSucursal + "   ", font3, Brushes.Black, new RectangleF(5, 10, 250, 30));
            e.Graphics.DrawString("Capacitación sin Limites", font3, Brushes.Black, new RectangleF(5, 23, 250, 30));
            e.Graphics.DrawString("Ruc:  J0310000121974   ", font3, Brushes.Black, new RectangleF(5, 43, 250, 30));
            e.Graphics.DrawString("Direccion:" + CacheUsuario.DireccionSucursal, font3, Brushes.Black, new RectangleF(5, 63, 250, 60));
            e.Graphics.DrawString("*************************** ", font3, Brushes.Black, new RectangleF(5, 83, 250, 30));
            e.Graphics.DrawString(tiempo.ToString(), font3, Brushes.Black, new RectangleF(5, 103, 250, 30));
            e.Graphics.DrawString(" ARQUEO DE CAJAS ", font3, Brushes.Black, new RectangleF(5, 123, 250, 30));
            e.Graphics.DrawString("--- CAJA 1 --- ", font3, Brushes.Black, new RectangleF(5, 143, 250, 30));
            e.Graphics.DrawString("Entradas.......C$ " + txtEntrada.Text + " ", font3, Brushes.Black, new RectangleF(5, 163, 250, 30));
            e.Graphics.DrawString("Salidas........C$ " + txtSalidas.Text + " ", font3, Brushes.Black, new RectangleF(5, 183, 250, 30));
            e.Graphics.DrawString("TOTAL..........C$" + txtTotal.Text + " ", font3, Brushes.Black, new RectangleF(5, 203, 250, 30));



            e.Graphics.DrawString("--- CAJA 2 --- ", font3, Brushes.Black, new RectangleF(5, 223, 250, 30));
            e.Graphics.DrawString("Entradas.......C$ " + txtEntrada2.Text + " ", font3, Brushes.Black, new RectangleF(5, 243, 250, 30));
            e.Graphics.DrawString("Salidas........C$ " + txtSalidas2.Text + " ", font3, Brushes.Black, new RectangleF(5, 263, 250, 30));
            e.Graphics.DrawString("TOTAL..........C$" + txtTotal2.Text + " ", font3, Brushes.Black, new RectangleF(5, 283, 250, 30));



            e.Graphics.DrawString("--- CAJA 3 --- ", font3, Brushes.Black, new RectangleF(5, 303, 250, 30));
            e.Graphics.DrawString("Entradas.......C$ " + txtEntrada3.Text + " ", font3, Brushes.Black, new RectangleF(5, 323, 250, 30));
            e.Graphics.DrawString("Salidas........C$ " + txtSalidas3.Text + " ", font3, Brushes.Black, new RectangleF(5, 343, 250, 30));
            e.Graphics.DrawString("TOTAL..........C$" + txtTotal3.Text + " ", font3, Brushes.Black, new RectangleF(5, 363, 250, 30));

            e.Graphics.DrawString("Total Dinero:  C$" + txttotalGeneral.Text + " ", font3, Brushes.Black, new RectangleF(5, 383, 250, 30));

            e.Graphics.DrawString("----------------------- ", font3, Brushes.Black, new RectangleF(5, 403, 250, 30));


        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                printDocument2 = new PrintDocument();
                PrinterSettings ps = new PrinterSettings();
                printDocument2.PrinterSettings = ps;
                printDocument2.PrintPage += Imprimir;
                printDocument2.Print();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

       
        }

        private void MostrarRocYRos()
        {



            CN_FacturDetalle objetocn = new CN_FacturDetalle();

            foreach (DataGridViewRow row in dataMovimientos.Rows)
            {
                string Tipo = row.Cells["Tipo_documento"].Value.ToString();
                if (Tipo == "FACTURA") {
                    this.dataDetalleFactura.DataSource = objetocn.MostraRocyRos(row.Cells["Num_Documento"].Value.ToString());
                }
            }


            ROC = 0;
            ROS = 0;

            foreach (DataGridViewRow row2 in dataDetalleFactura.Rows)
            {
                string TipoArancel = row2.Cells["Tipo"].Value.ToString();
                if (TipoArancel == "ROC")
                {
                    ROC += Convert.ToDouble(row2.Cells["Total_en_Cordobas"].Value);
                }

                if (TipoArancel == "ROS")
                {
                    ROS += Convert.ToDouble(row2.Cells["Total_en_Cordobas"].Value);
                }

            }

            this.txtRoc.Text = ROC.ToString();
            this.txtRos.Text = ROS.ToString();

        }

        private void Imprimir(object sender, PrintPageEventArgs e)
        {

            Font font3 = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point);
            

            DateTime tiempo = new DateTime();
            tiempo = Convert.ToDateTime(DateTime.Now.ToString());
            string NombreCentro = CacheUsuario.NombreSucursal;

            e.Graphics.DrawString("            " + CacheUsuario.NombreSucursal + "   ", font3, Brushes.Black, new RectangleF(5, 10, 250, 30));
            e.Graphics.DrawString("            Capacitación sin Limites", font3, Brushes.Black, new RectangleF(5, 23, 250, 30));
            e.Graphics.DrawString("             Ruc:  J0310000121974   ", font3, Brushes.Black, new RectangleF(5, 43, 250, 30));
            e.Graphics.DrawString("          Direccion:" + CacheUsuario.DireccionSucursal, font3, Brushes.Black, new RectangleF(5, 63, 250, 60));
            e.Graphics.DrawString("*********************************", font3, Brushes.Black, new RectangleF(5,83, 250, 30));
            e.Graphics.DrawString("         "+tiempo.ToString(), font3, Brushes.Black, new RectangleF(5,103, 250, 30));
            e.Graphics.DrawString("          ----- CORTE DEL DIA -----", font3, Brushes.Black, new RectangleF(5,123, 250, 30));
            e.Graphics.DrawString("           CAJA: " + combocaja.Text, font3, Brushes.Black, new RectangleF(5,143, 250, 30));
            e.Graphics.DrawString("             ==     ROC     ==", font3, Brushes.Black, new RectangleF(5,163, 250, 30));
            e.Graphics.DrawString("            TOTAL C$: " + this.txtRoc.Text, font3, Brushes.Black, new RectangleF(5,183, 250, 30));
            e.Graphics.DrawString("             ==     ROS     ==", font3, Brushes.Black, new RectangleF(5,203, 250, 30));
            e.Graphics.DrawString("            TOTAL C$: " + this.txtRos.Text, font3, Brushes.Black, new RectangleF(5,223, 250, 30));
            e.Graphics.DrawString("             ==     ENTRADAS     ==", font3, Brushes.Black, new RectangleF(5,243, 250, 30));
            e.Graphics.DrawString("            TOTAL C$: " + this.Txttotalentradass.Text, font3, Brushes.Black, new RectangleF(5,263, 250, 30));
            e.Graphics.DrawString("             ==     EGRESOS     ==", font3, Brushes.Black, new RectangleF(5,283, 250, 30));
            e.Graphics.DrawString("            TOTAL C$: " + this.txtTotalSalidas.Text, font3, Brushes.Black, new RectangleF(5,303, 250, 30));
            e.Graphics.DrawString("==   FACTURAS ANULADAS     ==", font3, Brushes.Black, new RectangleF(5,323, 250, 30));
            e.Graphics.DrawString("             TOTAL C$: " + this.txtTotalFacAnuladas.Text, font3, Brushes.Black, new RectangleF(5,343, 250, 30));
            e.Graphics.DrawString("    *********************************", font3, Brushes.Black, new RectangleF(5,363, 250, 30));
            e.Graphics.DrawString("  ==     DINERO EN CAJA     ==", font3, Brushes.Black, new RectangleF(5, 383, 250, 30));
            e.Graphics.DrawString("             TOTAL C$: " + this.txttotalencaja.Text, font3, Brushes.Black, new RectangleF(5,403, 250, 30));

            e.Graphics.DrawString("    *********************************", font3, Brushes.Black, new RectangleF(5,433, 250, 30));










        }


    }
}
