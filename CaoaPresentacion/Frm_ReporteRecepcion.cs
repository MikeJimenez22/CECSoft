using CapaDatos;
using CapaNegocio;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace CaoaPresentacion
{
    public partial class Frm_ReporteRecepcion : Form
    {
        public Frm_ReporteRecepcion()
        {
            InitializeComponent();
            this.Cargar_ComboCaja();
            this.combocaja.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        CD_Conexion conexion = new CD_Conexion();

        double TotalEntradas = 0, TotalSalidas = 0, TotalFacturasAnuladas = 0;
        double ROC = 0;
        double ROS = 0;
        string fechaVerificacion = DateTime.Now.ToShortDateString();



        private void Frm_ReporteRecepcion_Load(object sender, EventArgs e)
        {
            try
            {
                this.dateTimePicker1.Text = fechaVerificacion.ToString();
                this.dateTimePicker2.Text = fechaVerificacion.ToString();
                this.combocaja.Text = "CAJA 01";
                this.Buscar();
       
            }
            catch (Exception)
            {
                MessageBox.Show("Error de sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Cargar_ComboCaja()
        {
            try
            {

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


        private void BuscarMovimientos()
        {
            CN_Arqueos objetoCN = new CN_Arqueos();


            DateTime fecha1 = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);


            this.dataMovimientos.DataSource = objetoCN.BuscarMovimientos(fecha1, this.combocaja.SelectedValue.ToString());

        }


        private void BuscarMovimientosTodasLasCajas()
        {
            CN_Arqueos objetoCN = new CN_Arqueos();


            DateTime fecha = DateTime.ParseExact(dateTimePicker2.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);


            this.dataGridView2.DataSource = objetoCN.BuscarMovimientosTodasLasCajas(fecha);

        }






        private void button2_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void CalcularVentaTotalLibreriaHoy()
        {
            CN_FacturaGeneral objetoCN = new CN_FacturaGeneral();
            DataTable tabla = new DataTable();
            DateTime fecha1 = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            tabla = objetoCN.BuscarVentaLibreriaHoy(fecha1);
            if (tabla.Rows.Count == 0)
            {
                this.textBox2.Text = "0";
            }
            else
            {
                this.textBox2.Text = tabla.Rows[0][0].ToString();
            }



        }



        private void Buscar()
        {
            try
            {
                TotalEntradas = 0;
                TotalSalidas = 0;
                TotalFacturasAnuladas = 0;
                ROC = 0;
                ROS = 0;

                this.BuscarMovimientos();
                this.BuscarFacturaInicial();
                this.BuscarFacturaFinal();
                this.MostrarRocYRos();
                this.ContadorROCYROS();
                this.MostrarMovimientosAgrupadosHoy();
                this.CalcularVentaTotalLibreriaHoy();

                this.textBox1.Text = this.txtFacturaInicial.Text + "-" + this.txtFacturaFinal.Text;



            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarMovimientosAgrupadosHoy()
        {
            DateTime fecha1 = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            CN_FacturaGeneral objetoCN = new CN_FacturaGeneral();

            this.dataGridView1.DataSource = objetoCN.BuscarMoviemientosHoy(fecha1, this.combocaja.SelectedValue.ToString());


        }


        private void MostrarRocYRos()
        {



            CN_FacturDetalle objetocn = new CN_FacturDetalle();

            foreach (DataGridViewRow row in dataMovimientos.Rows)
            {
                string Tipo = row.Cells["Tipo_documento"].Value.ToString();
                if (Tipo == "FACTURA")
                {
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



            }

            this.txtTotalRoc.Text = contRoc.ToString();
            this.txtTotalRos.Text = contRos.ToString();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.textBox1.Text);
            MessageBox.Show("El texto se ha copiado al portapapeles.", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.BuscarMovimientosTodasLasCajas();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarFacturaInicial()
        {
            CN_Denominaciones objetoCN = new CN_Denominaciones();


            DateTime fecha1 = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DataTable tabla = new DataTable();



            tabla = objetoCN.MostrarFacturaInicial(fecha1, this.combocaja.SelectedValue.ToString());
            if (tabla.Rows.Count == 0)
            {
                this.txtFacturaInicial.Text = "-";
            }
            else if (tabla.Rows.Count != 0)
            {
                this.txtFacturaInicial.Text = tabla.Rows[0][0].ToString();
            }

        }



        private void BuscarFacturaFinal()
        {
            CN_Denominaciones objetoCN = new CN_Denominaciones();


            DateTime fecha1 = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DataTable tabla = new DataTable();



            tabla = objetoCN.MostrarFacturaFinal(fecha1, this.combocaja.SelectedValue.ToString());
            if (tabla.Rows.Count == 0)
            {
                this.txtFacturaFinal.Text = "-";
            }
            else if (tabla.Rows.Count != 0)
            {
                this.txtFacturaFinal.Text = tabla.Rows[0][0].ToString();
            }




        }
    }
}
