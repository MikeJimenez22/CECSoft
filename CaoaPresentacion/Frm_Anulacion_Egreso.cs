using CapaDatos;
using CapaNegocio;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CaoaPresentacion
{
    public partial class Frm_Anulacion_Egreso : Form
    {
        public Frm_Anulacion_Egreso()
        {
            InitializeComponent();
        }

        CD_Conexion conexion = new CD_Conexion();
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.Limpiar();



                conexion.AbrirConexion();
                SqlCommand cm = new SqlCommand("select a.Num_egreso,a.Monto,b.Descripcion,a.Descripcion as Concepto from Tbl_Egresos a join Tbl_TipoMoneda b on a.IdMoneda = B.IdMoneda where Num_egreso = '" + this.txtCodigoEgreso.Text + "'", conexion.Conexion());
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read() == true)
                {
                    this.txtmonto.Text = dr["Monto"].ToString();
                    this.txtDescripcion.Text = dr["Descripcion"].ToString();
                    this.txtConcepto.Text = dr["Concepto"].ToString();

                }
                conexion.CerrarConexion();




                conexion.AbrirConexion();
                SqlCommand cm2 = new SqlCommand("select Tipo_Movimiento from Tbl_MovimientoCaja where Num_Documento = '" + this.txtCodigoEgreso.Text + "'", conexion.Conexion());
                SqlDataReader dr2 = cm2.ExecuteReader();
                if (dr2.Read() == true)
                {
                    this.txtTipoMovimiento.Text = dr2["Tipo_Movimiento"].ToString();


                }
                conexion.CerrarConexion();

            }
            catch (Exception)
            {
                MessageBox.Show("");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.txtCodigoEgreso.Text = this.textBox1.Text;
        }

        private void Frm_Anulacion_Egreso_Load(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            this.txtConcepto.Text = string.Empty;
            this.txtmonto.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
        }

        private void txtTipoMovimiento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtTipoMovimiento.Text == "SALIDA")
                {
                    this.TXTEstado.Text = "Completado";
                }
                else if (this.txtTipoMovimiento.Text == "FACTURA ANULADA")
                {
                    this.TXTEstado.Text = "Anulado";
                }
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
                if (this.TXTEstado.Text == "Anulado")
                {
                    MessageBox.Show("Este Egreso ya se Esta Anulado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (this.TXTEstado.Text == "Completado")
                {
                    CN_egreso objetoCN = new CN_egreso();
                    objetoCN.AnularEgreso(this.txtCodigoEgreso.Text);
                    MessageBox.Show("Egreso Anulado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
