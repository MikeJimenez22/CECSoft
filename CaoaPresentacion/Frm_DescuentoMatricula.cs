using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapaDatos;
using CapaNegocio;

namespace CaoaPresentacion
{
    public partial class Frm_DescuentoMatricula : Form
    {
        public Frm_DescuentoMatricula()
        {
            InitializeComponent();
        }

        double ValorDolar;
        double ValorMatricula;
        int ValorPorcentaje;

        CD_Conexion conexion = new CD_Conexion();

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                double ValorNegativo;
                double ValorDescuento = Convert.ToDouble(this.txttTotal.Text);
                double ValorMatricula = Convert.ToDouble(this.label3.Text);

            
                if (ValorDescuento < 0 )
                {
                    MessageBox.Show("No se Puede agregar Valores Negativos","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }else if (ValorDescuento > 0)
                {
                    if (ValorDescuento > ValorMatricula)
                    {
                        MessageBox.Show("Error el Descuento sobrepasa el Valor de la Matricula", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }else if (ValorDescuento <= ValorMatricula)
                    {

                        ValorNegativo = Convert.ToDouble(this.txttTotal.Text);
                        
                        CacheDetalleProgramacion.MontoDescuento = Convert.ToString(ValorNegativo);
                        

                        CacheDetalleProgramacion.Contador3 = true;
                        this.Hide();
                    }
                   
                }






            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void Frm_DescuentoMatricula_Load(object sender, EventArgs e)
        {
            try
            {
                this.ObtenerValorMonedaDolar();
                this.ObtenerValorMatricula();
                this.ObtenerPagoMatriculaEnCordoba();
                this.txtOtroValor.Enabled = false;

                this.txttTotal.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void ObtenerValorMonedaDolar()
        {
           

            conexion.AbrirConexion();
            SqlCommand cm = new SqlCommand("select  ValorMoneda from Tbl_TipoMoneda where IdMoneda = '2'", conexion.Conexion);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read() == true)
            {
                this.ValorDolar = Convert.ToDouble(dr["ValorMoneda"].ToString());

            }
           conexion.CerrarConexion();
        }


        private void ObtenerValorMatricula()
        {

            CD_Conexion conexion = new CD_Conexion();
            conexion.AbrirConexion();
            SqlCommand cm = new SqlCommand("select Precio from Tbl_Aranceles where Id_Arancel = '8'", conexion.Conexion);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read() == true)
            {
                this.ValorMatricula = Convert.ToDouble(dr["Precio"].ToString());

            }
          conexion.CerrarConexion();
        }

        private void ObtenerPagoMatriculaEnCordoba()
        {
            this.label3.Text = Convert.ToString(this.ValorMatricula * this.ValorDolar);
        }


        private void ObtenerDescuento()
        {
            double x; // este sera la Variable donde estara almacenado el Descuento
            double TotalMatricula;
            
            TotalMatricula = Convert.ToDouble(this.label3.Text); // convertimos el label 3 en un Numero 
            x = (TotalMatricula * ValorPorcentaje) / 100;

            this.txttTotal.Enabled = false;
            this.txttTotal.Text = Convert.ToString(x);
            
        }

        private void ObtenerDescuentoCordoba()
        {
            double x; // este sera la Variable donde estara almacenado el Descuento
            double TotalMatricula;

            TotalMatricula = Convert.ToDouble(this.label3.Text); // convertimos el label 3 en un Numero 
            x = TotalMatricula - Convert.ToDouble(this.txtOtroValor.Text);

            this.txttTotal.Enabled = false;
            this.txttTotal.Text = Convert.ToString(x);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.txtOtroValor.Text = string.Empty;
            ValorPorcentaje = 5;
            this.ObtenerDescuento();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.txtOtroValor.Text = string.Empty;
            ValorPorcentaje = 10;
            this.ObtenerDescuento();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.txtOtroValor.Text = string.Empty;
            ValorPorcentaje = 15;
            this.ObtenerDescuento();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.txtOtroValor.Text = string.Empty;
            ValorPorcentaje = 20;
            this.ObtenerDescuento();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            this.txtOtroValor.Text = string.Empty;
            ValorPorcentaje = 50;
            this.ObtenerDescuento();
        }  

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            this.txtOtroValor.Text = string.Empty;
            ValorPorcentaje = 100;
            this.ObtenerDescuento();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton7.Checked == true)
            {
                this.txtOtroValor.Enabled = true;

            }else if (this.radioButton7.Checked == false)
            {
                this.txtOtroValor.Enabled = false;
            }
        }

        private void txtOtroValor_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtOtroValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            
               
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) /*&&*/
                                                                            //    (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
            

            }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.txttTotal.Text = this.txtOtroValor.Text;
            }
            catch (Exception) {
                MessageBox.Show("Error de Sistema","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
    }

