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
using System.Data.SqlClient;
using CapaDatos;
using System.Net;
using System.Net.NetworkInformation;
using System.Globalization;

namespace CaoaPresentacion
{
    public partial class Frm_APerturaCaja : Form
    {
        CN_AperturaCaja objetoCN = new CN_AperturaCaja();
        double Total;
        string Fecha = Convert.ToString(DateTime.Now.ToShortDateString());
        string Hora = Convert.ToString(DateTime.Now.ToShortTimeString());
        CN_Movimientos objetoMovimiento = new CN_Movimientos();

        string name = System.Windows.Forms.SystemInformation.ComputerName;
        CD_Conexion conexion = new CD_Conexion();


        public Frm_APerturaCaja()
        {
            InitializeComponent();

            this.cmbTipoMoneda.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Cargar_ComboDepartamento();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CN_AperturaCaja objetoCN = new CN_AperturaCaja();
                DataTable tabla = new DataTable();
                DateTime fecha1 = DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);


                tabla = objetoCN.VerificarSiEXISTE(fecha1,CacheUsuario.IdCaja);
                if (tabla.Rows.Count != 0)
                {
                    MessageBox.Show("Se encuentra ya Creada una Apertura de Caja", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (tabla.Rows.Count == 0)
                {
                    
                    double ValorMoneda = Convert.ToDouble(this.txtEnCordobas.Text);
                    double ValorMonto = Convert.ToDouble(this.txtmonto.Text);
                    if (ValorMonto < 0)
                    {
                        MessageBox.Show("No se Permite Valores Negativos", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Cargar_ComboDepartamento();
                        this.txtTotalCordobas.Text = string.Empty;

                    } else if (ValorMonto > 0)
                    {
                       //aca validamos si el Valor de la Moneda es Menor que 0 no se Permite  
                    Total = Convert.ToDouble(this.txtmonto.Text) * ValorMoneda;
                    objetoCN.InsertarApertura(CacheUsuario.IdCaja, this.txtmonto.Text, this.cmbTipoMoneda.SelectedValue.ToString(), Fecha, CacheUsuario.IdUsuario, name, Total.ToString(),Hora);
                    string FechaActual = DateTime.Now.ToShortDateString();
                    DateTime fecha2 = DateTime.ParseExact(FechaActual, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                        string HoraRegistro = DateTime.Now.ToLongTimeString();
                       

                        objetoMovimiento.Insertar("APERTURA CAJA","", "ENTRADA",this.txtTotalCordobas.Text, "1", fecha2, CacheUsuario.IdUsuario, CacheUsuario.IdCaja,HoraRegistro);
                        
                    MessageBox.Show("Apertura Creada Corretamente","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Hide();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public void Cargar_ComboDepartamento()
        {
            try
            {

                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("Select IdMoneda,Descripcion from Tbl_TipoMoneda ", conexion.Conexion);
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
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


      
        private void Frm_APerturaCaja_Load(object sender, EventArgs e)
        {
            LiberadorDeMemoria objeto1 = new LiberadorDeMemoria();
            objeto1.alzheimer();
        }

        private void cmbTipoMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            CD_Conexion conexion = new CD_Conexion();
            conexion.AbrirConexion();
            SqlCommand cm = new SqlCommand("select ValorMoneda from Tbl_TipoMoneda where IdMoneda = '" + this.cmbTipoMoneda.SelectedValue + "'", conexion.Conexion);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read() == true)
            {
                this.txtEnCordobas.Text = dr["ValorMoneda"].ToString();
                this.txtTotalCordobas.Text = Convert.ToString(Convert.ToInt32(this.txtmonto.Text) * Convert.ToDouble(dr["ValorMoneda"].ToString()));
            }
            conexion.CerrarConexion();
        }

        private void txtmonto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
