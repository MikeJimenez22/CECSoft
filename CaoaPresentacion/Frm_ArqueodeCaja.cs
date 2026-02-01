using CapaDatos;
using CapaNegocio;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using Utils;


namespace CaoaPresentacion
{
    public partial class Frm_ArqueodeCaja : Form
    {
        public Frm_ArqueodeCaja()
        {
            InitializeComponent();
            this.Cargar_ComboCaja();
            this.Cargar_ComboCajasFacturas();
            this.combocaja.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCajaFacturasCompletadas.DropDownStyle = ComboBoxStyle.DropDownList;
            DataGridViewConfigurator.Configure(this.dataGridView1,this.dataGridView5,this.dataGridView6,this.dataFacturasCompletadas,this.dataGridView2,this.dataGridView4,this.dataGridView3);

        }

        CD_Conexion conexion = new CD_Conexion();

        //Credenciales cuenta de Google para enviar Notificaciones del sistema
        const string Usuario = "CecnicManagua2023@gmail.com";
        const string Password = "ajkxkeukzfjsptmk";


        private void Frm_ArqueodeCaja_Load(object sender, EventArgs e)
        {
            try
            {
             
                this.dateTimePicker1.Text = DateTime.Now.ToShortDateString();
                this.tabControl1.SelectedIndex = 0;
                this.comboBox1.Text = "Todos";

                this.txtPara.Text = "CecnicManagua2023@gmail.com";

                this.txtAsunto.Text = "ACCESO A FINANZAS - SISTEMA CECNIC";
                this.txtDe.Text = "CecnicManagua2023@gmail.com";

                this.txtMensaje.Text = "Acceso a Finanzas";
                //this.EnviarNotificacionAcceso();

                this.ContadorFilas();

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void ContadorFilas()
        {
            this.label6.Text = "Total de Registros: " + this.dataGridView1.Rows.Count.ToString();
        }

        private void BuscarMovimientos()
        {
            CN_Arqueos objetoCN = new CN_Arqueos();


            DateTime fecha1 = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);


            this.dataGridView1.DataSource = objetoCN.BuscarMovimientosxCaja(fecha1, this.combocaja.SelectedValue.ToString());

        }


        private void BuscarMovimientosROCYROS()
        {
            CN_Arqueos objetoCN = new CN_Arqueos();


            DateTime fecha1 = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);


            this.dataGridView5.DataSource = objetoCN.BuscarMovimientosRocyRos(fecha1, this.combocaja.SelectedValue.ToString());

        }


        private void BuscarMovimientosAsc()
        {
            CN_Arqueos objetoCN = new CN_Arqueos();


            DateTime fecha1 = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);


            this.dataGridView1.DataSource = objetoCN.BuscarMovimientosxCajaAsc(fecha1, this.combocaja.SelectedValue.ToString());

        }


        private void BuscarMovimientosxTIPO()
        {
            CN_Arqueos objetoCN = new CN_Arqueos();


            DateTime fecha1 = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);


            this.dataGridView2.DataSource = objetoCN.BuscarMovimientosXtipo(fecha1, this.combocaja.SelectedValue.ToString());

        }

        private void BuscarMovimientosxTIPO_Movimiento()
        {
            CN_Arqueos objetoCN = new CN_Arqueos();


            DateTime fecha1 = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);


            this.dataGridView3.DataSource = objetoCN.BuscarMovimientosXtipo_Movimiento(fecha1, this.combocaja.SelectedValue.ToString());

        }


        private void BuscarMovimientosxRocRos()
        {
            CN_Arqueos objetoCN = new CN_Arqueos();


            DateTime fecha1 = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);


            this.dataGridView4.DataSource = objetoCN.BuscarMovimientosXRocRos(fecha1, this.combocaja.SelectedValue.ToString());

        }

        

        public void Cargar_ComboCaja()
        {
            try
            {

                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("select IdCaja,NombreCaja from Tbl_Cajas", conexion.Conexion());
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.BuscarMovimientos();
                this.BuscarMovimientosxTIPO();
                this.BuscarMovimientosxTIPO_Movimiento();
                this.BuscarMovimientosxRocRos();
                this.ObtenerMontoTotal();
                BuscarMovimientosROCYROS();
                

                this.ContadorFilas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.BuscarMovimientos();
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
                this.BuscarMovimientosAsc();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        

        private void ObtenerMontoTotal()
        {
            double subtotal = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Verificar si la fila tiene un valor en la columna "Estado" y si es "Completado"
                if (row.Cells["Estado"].Value != null && row.Cells["Estado"].Value.ToString() == "Completado")
                {
                    // Sumar solo las filas con Estado "Completado"
                    subtotal += Convert.ToDouble(row.Cells["MontoTotal_a_Pagar"].Value);
                }
            }

            // Mostrar el subtotal en el TextBox
            this.textBox1.Text = subtotal.ToString();
        }


        private void dataGridView5_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView5.Columns[e.ColumnIndex].Name == "Tipo")
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
        
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                this.MetodoBusqueda(this.comboBox1.Text);
                this.calcularSubtotal();


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MetodoBusqueda(string Opcion)
        {

            if (Opcion == "Todos")
            {
                this.MostrarMovimientosGeneral();

            }
            else if (Opcion == "CAJA 1")
            {
                this.MostrarMovimientosGeneralXCAJA("1");
            }
            else if (Opcion == "CAJA 2")
            {
                this.MostrarMovimientosGeneralXCAJA("2");
            }
            else if (Opcion == "CAJA 3")
            {
                this.MostrarMovimientosGeneralXCAJA("3");
            }


        }



        private void MostrarMovimientosGeneral()
        {
            DateTime fecha1 = DateTime.ParseExact(dateTimePicker2.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime fecha2 = DateTime.ParseExact(dateTimePicker3.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            CN_Arqueos objetoCN = new CN_Arqueos();

            this.dataGridView6.DataSource = objetoCN.BuscarMoviemientosGeneral(fecha1, fecha2);


        }


        private void MostrarMovimientosGeneralXCAJA(string IdCAJA)
        {
            DateTime fecha1 = DateTime.ParseExact(dateTimePicker2.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime fecha2 = DateTime.ParseExact(dateTimePicker3.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            CN_Arqueos objetoCN = new CN_Arqueos();

            this.dataGridView6.DataSource = objetoCN.BuscarMoviemientosGeneralxcaja(fecha1, fecha2, IdCAJA);


        }


        private void calcularSubtotal()
        {
            double subtotal = 0;
            foreach (DataGridViewRow row in dataGridView6.Rows)
            {
                subtotal += Convert.ToDouble(row.Cells["Total"].Value);
            }

            this.txtSubtotal.Text = Convert.ToString(subtotal);
        }



      
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

  

        public void Cargar_ComboCajasFacturas()
        {
            try
            {

                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("select IdCaja,NombreCaja from Tbl_Cajas", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["NombreCaja"] = "Selecciona una Caja";
                dt.Rows.InsertAt(fila, 0);

                cmbCajaFacturasCompletadas.ValueMember = "IdCaja";
                cmbCajaFacturasCompletadas.DisplayMember = "NombreCaja";
                cmbCajaFacturasCompletadas.DataSource = dt;


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbCajaFacturasCompletadas.Text == "Selecciona una Caja")
                {
                    MessageBox.Show("Tienes que seleccionar una Caja", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (this.cmbCajaFacturasCompletadas.Text != "Selecciona una Caja")
                {
                    DateTime fecha1 = DateTime.ParseExact(FechaInicialFacturas.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime fecha2 = DateTime.ParseExact(FechaFinalFacturas.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    string IdCaja = this.cmbCajaFacturasCompletadas.SelectedValue.ToString();

                    CN_Factura objeto = new CN_Factura();
                    this.dataFacturasCompletadas.DataSource = objeto.MostrarPorFechasFacturas(fecha1, fecha2, IdCaja);
                    this.calcularSubtotalPagos();
                    this.txtCantidadFacturas.Text = this.dataFacturasCompletadas.Rows.Count.ToString();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void calcularSubtotalPagos()
        {
            double subtotal = 0;

            foreach (DataGridViewRow row in dataFacturasCompletadas.Rows)
            {
                // Verificar si la fila tiene un valor en la columna "Estado" y si es "Completado"
                if (row.Cells["Estado"].Value != null && row.Cells["Estado"].Value.ToString() == "Completado")
                {
                    // Sumar solo las filas con Estado "Completado"
                    subtotal += Convert.ToDouble(row.Cells["MontoTotal_a_Pagar"].Value);
                }
            }

            // Mostrar el subtotal en el TextBox
            this.txtTotalFacturas.Text = subtotal.ToString();
        }

        
        private void arqueoDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedTab = TabArqueo;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reporteDeFacturasPorFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedTab = TabReportePorFecha;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedTab = TabReporte;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    
    }
}

