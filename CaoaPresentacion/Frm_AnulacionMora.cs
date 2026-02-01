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


namespace CaoaPresentacion
{
    public partial class Frm_AnulacionMora : Form
    {
        public Frm_AnulacionMora()
        {
            InitializeComponent();
        }

        CN_FacturDetalle objetoCN = new CN_FacturDetalle();
        CN_Detalle_Programacion objetoCN2 = new CN_Detalle_Programacion();
        string Id_Detalle_Programacion;
        string  Monto, Mora,Estado;
        string IdMoneda;
        string ValorMoneda;
        string TasadeCambio;
        string Descripcion;


        private void Frm_RegistroNotas_Load(object sender, EventArgs e)
        {

            try { 

            this.txtbuscar.Text = CacheBusquedaEstudiante.CodigoDeCarnet;
            this.AgregarBtnDatagridView();
           this.Mostrar();
           
            
                LiberadorDeMemoria objeto1 = new LiberadorDeMemoria();
                objeto1.alzheimer();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void AgregarBtnDatagridView()
        {
            dataNotas.Columns.Add(
       new DataGridViewButtonColumn()
       {
           HeaderText = "Seleccionar",
           Name = "Seleccionar",
           Text = "Seleccionar",
           UseColumnTextForButtonValue = true
       });

        
      
        }







        private void MostrarMatriculas()
        {
            CN_Matriculas objetoCN = new CN_Matriculas();
            this.datamatriculas.DataSource = objetoCN.BuscarMatricula(CacheDatos.Id_CodigoEstudiante);
        }


        private void MostrarNotas()
        {
            CN_Detalle_Programacion objetoCN = new CN_Detalle_Programacion();
            this.dataNotas.DataSource = objetoCN.BuscarDetallesPagos(CacheDatos.Id_NumProgramacion);
            
        }

      
        private void Mostrar()
        {
            CN_Personas objeto = new CN_Personas();
            this.dataPersonas.DataSource = objeto.BuscarPorApellidos(this.txtbuscar.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            this.Mostrar();

        }

        private void dataPersonas_Click(object sender, EventArgs e)
        {
            try
            {
               if(dataPersonas.Rows.Count == 0)
                {
                    MessageBox.Show("No hay Ningun Registro");
                    
                }
                else if(dataPersonas.Rows.Count != 0)
                {
                    CacheDatos.Id_CodigoEstudiante = this.dataPersonas.CurrentRow.Cells["Id_estudiante"].Value.ToString();
                    this.MostrarMatriculas();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void datamatriculas_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.datamatriculas.Rows.Count == 0)
                {
                    MessageBox.Show("No se encuentra ningun Registro en el sistema");
                }else
                {
                    CacheDatos.Id_NumProgramacion = this.datamatriculas.CurrentRow.Cells["Num_programacion"].Value.ToString();
                    this.MostrarNotas();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error de sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
           

        private void dataNotas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(this.dataNotas.Columns[e.ColumnIndex].Name == "Estado")
            {
                if(Convert.ToString(e.Value) ==  "Pendiente")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.Red;
                }else if(Convert.ToString(e.Value) == "Completado")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.Green;
                }else if(Convert.ToString(e.Value) == "En proceso")
                {
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.BackColor = Color.Yellow;
                }
            }
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataNotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
              

                if (this.dataNotas.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                        this.Id_Detalle_Programacion = this.dataNotas.CurrentRow.Cells["Id_Detalle_Programacion"].Value.ToString();
                        this.Monto = this.dataNotas.CurrentRow.Cells["Monto"].Value.ToString();
                        this.Mora = this.dataNotas.CurrentRow.Cells["Mora"].Value.ToString();
                        this.Estado = this.dataNotas.CurrentRow.Cells["Estado"].Value.ToString();
                        CacheDatos.Id_Detalle_Programacion = this.dataNotas.CurrentRow.Cells["Id_Detalle_Programacion"].Value.ToString();
                        CacheDatos.NumeroProgramacion = this.dataNotas.CurrentRow.Cells["Num_programacion"].Value.ToString();
                        Descripcion = this.dataNotas.CurrentRow.Cells["Descripcion"].Value.ToString();


                        IdMoneda = this.dataNotas.CurrentRow.Cells["IdMoneda"].Value.ToString();
                        ValorMoneda = this.dataNotas.CurrentRow.Cells["Tasa de Cambio"].Value.ToString();
                        

                        CacheFactura_Mensualidad.Num_Programacion = this.dataNotas.CurrentRow.Cells["Num_programacion"].Value.ToString();
                        CacheFactura_Mensualidad.IdDetalleProgramacion = this.dataNotas.CurrentRow.Cells["Id_Detalle_Programacion"].Value.ToString();

                        this.MostrarABONOS();
                        this.SumaAbonado();

                        double TotalAbonado = Convert.ToDouble(this.txttotalAbonado.Text);
                        double MontoTotalAcancelar = Convert.ToDouble(this.txtmontototal.Text);

                       

                    }
                
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void MostrarABONOS()
        {
            try
            {
                CN_Abonos objetoCN = new CN_Abonos();
                this.dataAbonos.DataSource = objetoCN.Mostrar(this.Id_Detalle_Programacion);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtestado.Text == "Completado")
                {
                    MessageBox.Show("Mensualidad ya Pagada", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }else if (this.txtestado.Text == "En proceso")
                {
                    MessageBox.Show("Ya seleccionado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  }
                else
                {
                    CacheDatos.IdDetalleProgramacionAbonos = this.dataNotas.CurrentRow.Cells["Id_Detalle_Programacion"].Value.ToString();
                    CacheDatos.Moneda = "Cordobas";
                    CacheDatos.Monto = this.txtmontototal.Text;

                    Frm_Abonos frm = new Frm_Abonos();
                    frm.ShowDialog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (this.txtestado.Text == "En proceso")
                {
                    MessageBox.Show("Ya seleccionado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }else if (this.txtestado.Text == "Completado")
                {
                    MessageBox.Show("Mensualidad ya Pagada", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }else
                {

                   

                    CacheFactura_Mensualidad.Concepto = "MENSUALIDAD";

                    CN_Factura_Mensualidad objeto = new CN_Factura_Mensualidad();
                    objeto.InsertarFactura_Mensualidad(CacheFactura_Mensualidad.CodigoFacturacion,CacheFactura_Mensualidad.Num_Programacion,CacheFactura_Mensualidad.IdDetalleProgramacion,CacheFactura_Mensualidad.Concepto);

                    DataTable TablaPagos = new DataTable();
                    CN_Factura_Mensualidad objetoMens = new CN_Factura_Mensualidad();

                    TablaPagos = objetoMens.MostrarPagosMensualidad(CacheFactura_Mensualidad.CodigoFacturacion);

                    ///////////////////////////////////////////////////////////////////
                    /// aqui lo pasamos a estado en Proceso/// 


                
                    foreach (DataRow row in TablaPagos.Rows)
                    {
                        string Concepto = row["Concepto"].ToString();


                        if (Concepto == "MENSUALIDAD")
                        {
                            string Codigo = row["Id_Detalle_Programacion"].ToString();
                            objetoMens.ModificarEstadoEnProceso(Codigo);
                        }

                    }


                    CacheDetalleProgramacion.CodigoFacturacion = CacheDatos.CodigoFacturacion;
                    CacheDetalleProgramacion.IdArancel = "11";
                    CacheDetalleProgramacion.IdMoneda = "1";
                    CacheDetalleProgramacion.ValorMoneda = ValorMoneda;
                    CacheDetalleProgramacion.TotalPago = this.txtsaldoPendiente.Text;
                    CacheDetalleProgramacion.Cantidad = "1";
                    CacheDetalleProgramacion.IdEstado = "10";
                    CacheDetalleProgramacion.Monto = this.txtsaldoPendiente.Text;

                    CacheDetalleProgramacion.Contador = true;


                    this.Hide();


                }


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.HabilitarComboDigiteCarnet();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            try
            {
                CN_Detalle_Programacion objeto = new CN_Detalle_Programacion();
                objeto.EliminarMora(Id_Detalle_Programacion);

                MessageBox.Show("La mora se ha Eliminado Correctamente","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Hide();

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SumaAbonado()
        {
            double subtotal = 0;

            //Aca calculamos el MONTO total Abonado a x Mensualidad
            foreach (DataGridViewRow row in dataAbonos.Rows)
            {
                if (row.Cells["Estado"].Value.ToString() == "Completado")
                {
                    subtotal += Convert.ToDouble(row.Cells["Monto"].Value);
                }
             
            }

            this.txttotalAbonado.Text = subtotal.ToString();
            //Fin

            //Aqui agregamos el subtotal 
            this.txtsubtotal.Text = this.Monto;
            //Aqui agregamos si tiene que pagar Mora
            this.txtmora.Text = this.Mora;
            //Aqui calculamos el Total convertido en Moneda Local
            double TotalPago = Convert.ToDouble(ValorMoneda) * Convert.ToDouble(Monto);
            this.txtSubtotalCordobas.Text = TotalPago.ToString();
            //aqui Mostramos el estado
            this.txtestado.Text = Estado.ToString();
            //aqui mostramos el Tipo de Moneda del pago
            this.txtDescripcionMoneda.Text = Descripcion.ToString();

            //aqui Calcularemos el Subtotal + la Mora
            double MontoMasMora = TotalPago + Convert.ToDouble(Mora);
            this.txtmontototal.Text = MontoMasMora.ToString();
            //aqui calcularemos el Saldo Pendiente a pagar
            double SaldoPendiente = Convert.ToDouble(MontoMasMora) - Convert.ToDouble(subtotal);
            this.txtsaldoPendiente.Text = SaldoPendiente.ToString();
           
        }


        private void HabilitarComboDigiteCarnet()
        {
            if (this.checkBox1.Checked == false)
            {
                this.txtbuscar.Enabled = false;
            }else
            {

                this.txtbuscar.Enabled = true;
            }
        }

     




    }
}
