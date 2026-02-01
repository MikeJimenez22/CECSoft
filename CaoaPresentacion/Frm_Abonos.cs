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
using CapaDatos;
using System.Data.SqlClient;
using System.Globalization;

namespace CaoaPresentacion
{
    public partial class Frm_Abonos : Form
    {
        string ValorMonedaDolar;
        CN_Abonos objetoCN = new CN_Abonos();
        CN_Detalle_Programacion objetoCN2 = new CN_Detalle_Programacion();


        CD_Conexion conexion = new CD_Conexion();
        double TotalAbonado = 0;
        string fechaVerificacion = DateTime.Now.ToShortDateString();
        double tasaCambio;
        double SaldoPendiente;

        public Frm_Abonos()
        {
            InitializeComponent();
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Cargar_ComboDepartamento();
        }


        private void CalcularSaldoPendiente()
        {
            this.txtSaldopendiente.Text = string.Empty;
            double MontoCurso = Convert.ToDouble(this.txtMontocordobas.Text);
            SaldoPendiente = MontoCurso - TotalAbonado;
            this.txtSaldopendiente.Text = SaldoPendiente.ToString();

        }

        private void ObtenerMontoTotal_Abonado()
        {
            CN_Abonos objetoCN = new CN_Abonos();
            DataTable tabla = new DataTable();

            tabla = objetoCN.ObtenerMonto(CacheDatos.IdDetalleProgramacionAbonos);

            foreach (DataGridViewRow row in dataAbonos.Rows)
            {
                if (row.Cells["Estado"].Value.ToString() == "Completado")
                {
                    TotalAbonado = TotalAbonado + Convert.ToDouble(row.Cells["Monto"].Value);
                }
               
            }

            txtTotalAbonado.Text = TotalAbonado.ToString();

        }


        private void CargarDatosCurso()
        {
            this.txtNombreCurso.Text = CacheDatos.NombreCurso;
            this.txtDias.Text = CacheDatos.Dias;
            this.txtHorarios.Text = CacheDatos.Horarios;
        }


        private void Frm_Abonos_Load(object sender, EventArgs e)
        {


            try
            {


                if (CacheDatos.Moneda == "Cordobas")
                {

                    this.CargarDatosCurso();
                    this.CargarValorDolar();
                    this.txtMontocordobas.Text = CacheDatos.Monto;
                    double TotalEnDolares;
                    TotalEnDolares = Convert.ToDouble(txtMontocordobas.Text) / Convert.ToDouble(ValorMonedaDolar);
                    TotalEnDolares = Math.Round(TotalEnDolares, 2);
                    this.txtmontodolares.Text = Convert.ToString(TotalEnDolares);
                    this.txtcodigoFactura.Text = Convert.ToString(CacheFacturaAbono.CodigoFactura);
                    this.txtconcepto.Text = "ABONO A " + CacheDatos.Concepto;

                }
                //}else if (CacheDatos.Moneda == "Dolar")
                //{
                //    this.CargarValorDolar();
                //    this.txtmontodolares.Text = CacheDatos.Monto;
                //    double TotalEnCordobas;
                //    TotalEnCordobas = Convert.ToDouble(txtmontodolares.Text) * Convert.ToDouble(ValorMonedaDolar);
                //    TotalEnCordobas = Math.Round(TotalEnCordobas,2);
                //    this.txtMontocordobas.Text = Convert.ToString(TotalEnCordobas);
                //}


                this.Mostrar();
                this.ObtenerMontoTotal_Abonado();
                this.CalcularSaldoPendiente();
                LiberadorDeMemoria objeto1 = new LiberadorDeMemoria();
                objeto1.alzheimer();
            }



            catch (Exception)
            {
                this.txtSaldopendiente.Text = this.txtMontocordobas.Text;
                this.txtTotalAbonado.Text = "0";

            }
        }


        private void Mostrar()
        {
            try { 
            CN_Abonos objetoCN = new CN_Abonos();
            this.dataAbonos.DataSource = objetoCN.Mostrar(CacheDatos.IdDetalleProgramacionAbonos);
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

  

        private void CargarValorDolar()
        {
            try {

                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
            SqlCommand cm = new SqlCommand("select ValorMoneda from Tbl_TipoMoneda where IdMoneda = '2'",conexion.Conexion);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read() == true)
            {
               ValorMonedaDolar = dr["ValorMoneda"].ToString();
              
            }
            conexion.CerrarConexion();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblFechaActual.Text = DateTime.Now.ToString();
        }


        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtMontoTotalAbonado.Text == string.Empty) {
                    MessageBox.Show("No se ha Agregado el Monto a Abonar", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }else { 

                ///////////////////// Aqui empieza el Codigo para Generar un Abono a una Mensualidad de un Estudiante
                double X = Convert.ToDouble(this.txtMontoTotalAbonado.Text);
                double Y = Convert.ToDouble(this.txtSaldopendiente.Text);

                if (X > Y)
                {
                    MessageBox.Show("El saldo Pendiente es Menor al Monto que usted Ingreso","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }else if ( X <= Y)
                {

                        DateTime FechaActual = DateTime.ParseExact(fechaVerificacion, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        objetoCN.InsertarAbono(FechaActual, this.txtMontoTotalAbonado.Text, this.comboBox1.SelectedValue.ToString(), CacheUsuario.IdUsuario,CacheDatos.IdDetalleProgramacionAbonos,txtcodigoFactura.Text, "1");
                        
                        MessageBox.Show("Abono Registrado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.ProcesarABONO();
                        
                    }



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }



        }

        private void CargarDatosCursoEstudiante() {

            CacheDetalleProgramacion.NombreCurso = this.txtNombreCurso.Text;
            CacheDetalleProgramacion.Dias = this.txtDias.Text;
            CacheDetalleProgramacion.Horario = this.txtHorarios.Text;
                
        }


        private void ProcesarABONO()
        {
            this.Mostrar();
            this.ObtenerMontoTotal_Abonado();
            this.CalcularSaldoPendiente();

            CN_FacturDetalle objetoCN = new CN_FacturDetalle();
            objetoCN.InsertarDetalleFactura(CacheFactura_Mensualidad.CodigoFacturacion, "12", "1", "1", this.txtMontoTotalAbonado.Text,"1","10",this.txtMontoTotalAbonado.Text,this.txtconcepto.Text);

            
            

            this.CargarDatosCursoEstudiante();

            CacheDetalleProgramacion.Contador2 = true;

            this.Hide();
        }



        public void Cargar_ComboDepartamento()
        {
            try
            {

                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("select Descripcion,IdMoneda from Tbl_TipoMoneda", conexion.Conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Descripcion"] = "Selecciona el Tipo de Moneda";
                dt.Rows.InsertAt(fila, 0);

                comboBox1.ValueMember = "IdMoneda";
                comboBox1.DisplayMember = "Descripcion";
                comboBox1.DataSource = dt;


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMonto();
        }

        private void CargarMonto()
        {
            CD_Conexion conexion = new CD_Conexion();
            conexion.AbrirConexion();
            SqlCommand cm = new SqlCommand("select ValorMoneda from Tbl_TipoMoneda where IdMoneda = '" + this.comboBox1.SelectedValue + "'", conexion.Conexion);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read() == true)
            {
                tasaCambio = Convert.ToDouble(dr["ValorMoneda"].ToString());

            }
            conexion.CerrarConexion();

            this.txtvalor.Text = tasaCambio.ToString();


        }

        private void txtvalor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmontototalAbonar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (comboBox1.Text == "Selecciona el Tipo de Moneda")
                {
                    MessageBox.Show("Selecciona una Moneda Primeramente");
                }
                else if (this.comboBox1.Text != "Selecciona el Tipo de Moneda")
                {
                    this.Calculos();

                }
            }
        }

        private void Calculos()
        {
            try { 
            double X;
            double Y;
            double Z;
           

            X = Convert.ToDouble(this.txtvalor.Text);
            Y = Convert.ToDouble(this.txtmontototalAbonar.Text);
            Z = X * Y;
            this.txtMontoTotalAbonado.Text = Z.ToString();

                double SaldoActual = Convert.ToDouble(this.txtSaldopendiente.Text);
                double NuevoSaldo;


                NuevoSaldo = SaldoActual - Convert.ToDouble(this.txtMontoTotalAbonado.Text);
                this.txtProximoSaldo.Text = NuevoSaldo.ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void txtMontoTotalAbonado_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMontocordobas_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmontodolares_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSaldopendiente_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
