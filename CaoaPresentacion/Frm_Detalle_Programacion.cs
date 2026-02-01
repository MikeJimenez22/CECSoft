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


namespace CaoaPresentacion
{
    public partial class Frm_Detalle_Programacion : Form
    {
        public Frm_Detalle_Programacion()
        {
            InitializeComponent();
            this.Cargar_ComboUsuario();
            this.Cargar_ComboUsuario2();
            this.cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        CN_FacturDetalle objetoCN = new CN_FacturDetalle();
        CN_Detalle_Programacion objetoCN2 = new CN_Detalle_Programacion();
        string Id_Detalle_Programacion;
        string  Monto, Mora,Estado,Concepto;
        string IdMoneda;
        string ValorMoneda;
        string TasadeCambio;
        string Descripcion;

        CD_Conexion conexion = new CD_Conexion();

        private void Frm_RegistroNotas_Load(object sender, EventArgs e)
        {

            try {
                this.groupBox5.Visible = false;
           this.groupBox3.Enabled = false;
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
            this.AgregarBtnDatagridView();
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

                    this.txtNombreCurso.Text = this.datamatriculas.CurrentRow.Cells["Nombre_curso"].Value.ToString();
                    this.txtDias.Text = this.datamatriculas.CurrentRow.Cells["Dias"].Value.ToString();
                    this.txtHorario.Text = this.datamatriculas.CurrentRow.Cells["Horario"].Value.ToString();



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
                    this.txtIdDetalleProgramacion.Text = this.dataNotas.CurrentRow.Cells["Id_Detalle_Programacion"].Value.ToString();
                    this.Monto = this.dataNotas.CurrentRow.Cells["Monto"].Value.ToString();
                    this.Mora = this.dataNotas.CurrentRow.Cells["Mora"].Value.ToString();
                    this.Estado = this.dataNotas.CurrentRow.Cells["Estado"].Value.ToString();
                    CacheDatos.Id_Detalle_Programacion = this.dataNotas.CurrentRow.Cells["Id_Detalle_Programacion"].Value.ToString();
                    CacheDatos.NumeroProgramacion = this.dataNotas.CurrentRow.Cells["Num_programacion"].Value.ToString();
                    Descripcion = this.dataNotas.CurrentRow.Cells["Descripcion"].Value.ToString();
                    this.txtConcepto.Text = this.dataNotas.CurrentRow.Cells["Concepto"].Value.ToString();
                    this.txtDescripcion.Text = this.dataNotas.CurrentRow.Cells["Descripcion"].Value.ToString();
                    this.txtFechaProgramada.Text = this.dataNotas.CurrentRow.Cells["Fecha_Programada"].Value.ToString();
                    this.txtFechaVencimiento.Text = this.dataNotas.CurrentRow.Cells["Fecha_Vencimiento"].Value.ToString();


                    IdMoneda = this.dataNotas.CurrentRow.Cells["IdMoneda"].Value.ToString();
                    ValorMoneda = this.dataNotas.CurrentRow.Cells["Tasa de Cambio"].Value.ToString();


                    CacheFactura_Mensualidad.Num_Programacion = this.dataNotas.CurrentRow.Cells["Num_programacion"].Value.ToString();
                    CacheFactura_Mensualidad.IdDetalleProgramacion = this.dataNotas.CurrentRow.Cells["Id_Detalle_Programacion"].Value.ToString();

                    this.MostrarABONOS();
                    this.SumaAbonado();

                    double TotalAbonado = Convert.ToDouble(this.txttotalAbonado.Text);
                    double MontoTotalAcancelar = Convert.ToDouble(this.txtmontototal.Text);


                    this.button2.Enabled = true;
                    this.button3.Enabled = true;

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
                    CacheDatos.Concepto = this.txtConcepto.Text;

                    CacheDatos.NombreCurso = this.txtNombreCurso.Text;
                    CacheDatos.Dias = this.txtDias.Text;
                    CacheDatos.Horarios = this.txtHorario.Text;

                    this.Hide();

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

                    DialogResult opcion;
                    opcion = MessageBox.Show("Verifique bien la Informacion, si es correcta Presione Ok", "SISTEMA CECNIC", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (opcion == DialogResult.OK)
                    {
                        CacheFactura_Mensualidad.Concepto = "MENSUALIDAD";

                        CN_Factura_Mensualidad objeto = new CN_Factura_Mensualidad();
                        objeto.InsertarFactura_Mensualidad(CacheFactura_Mensualidad.CodigoFacturacion, CacheFactura_Mensualidad.Num_Programacion, CacheFactura_Mensualidad.IdDetalleProgramacion, CacheFactura_Mensualidad.Concepto);

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


                        CN_FacturDetalle objetoCN = new CN_FacturDetalle();
                        objetoCN.InsertarDetalleFactura(CacheFactura_Mensualidad.CodigoFacturacion,"11","1",ValorMoneda,this.txtsaldoPendiente.Text,"1","10",this.txtsaldoPendiente.Text,this.txtConcepto.Text);

                       


                        CacheDetalleProgramacion.NombreCurso = this.txtNombreCurso.Text;
                        CacheDetalleProgramacion.Dias = this.txtDias.Text;
                        CacheDetalleProgramacion.Horario = this.txtHorario.Text;

                        CacheDetalleProgramacion.Contador = true;


                        this.Hide();

                    }else if (opcion == DialogResult.Cancel)
                    {
                        this.checkBox1.Checked = true;
                        this.txtbuscar.Focus();
                    }




                }


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                this.groupBox5.Visible = true;
                this.tabControl1.SelectedIndex = 1;

                this.groupBox4.Enabled = true;
                this.groupBox4.Visible = true;
                this.txtclave2.Text = string.Empty;
                this.txtclave2.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (this.txtIdDetalleProgramacion.Text == string.Empty)
                {
                    MessageBox.Show("Primero debes de Seleccionar un Pago", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {


                    string IdDetalle = this.txtIdDetalleProgramacion.Text;

                    CN_Detalle_Programacion objeto = new CN_Detalle_Programacion();
                    objeto.EditarEstadoCancelado(IdDetalle);
                    MessageBox.Show("Registro Actualizado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.groupBox3.Enabled = false;

                    this.groupBox5.Visible = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtIdDetalleProgramacion.Text == string.Empty)
                {
                    MessageBox.Show("Primero debes de Seleccionar un Pago", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    
                    string IdDetalle = this.txtIdDetalleProgramacion.Text;

                    CN_Detalle_Programacion objeto = new CN_Detalle_Programacion();
                    objeto.EstadoPendiente(IdDetalle);
                    MessageBox.Show("Registro Actualizado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.groupBox3.Enabled = false;
                    this.groupBox5.Visible = false;
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataNotas_Paint(object sender, PaintEventArgs e)
        {
            this.dataNotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtclave1.Text == string.Empty)
                {
                    MessageBox.Show("no se ha ingresado ninguna clave de acceso", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else
                {
                    DataTable tabla = new DataTable();
                    CN_ClavesAprobacion objetoCN = new CN_ClavesAprobacion();

                    tabla = objetoCN.LoginModificacion(this.comboBox1.SelectedValue.ToString(),this.txtclave1.Text);
                    if (tabla.Rows.Count == 0)
                    {
                        MessageBox.Show("Error clave Incorrecta", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtclave1.Text = string.Empty;
                        this.txtclave1.Focus();
                    }else if (tabla.Rows.Count != 0)
                    {
                        this.groupBox3.Enabled = true;


                    }


                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtclave2.Text == string.Empty)
                {
                    MessageBox.Show("no se ha ingresado ninguna clave de acceso", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DataTable tabla = new DataTable();
                    CN_ClavesAprobacion objetoCN = new CN_ClavesAprobacion();

                    tabla = objetoCN.LoginModificacion(this.cmbUsuario.SelectedValue.ToString(), this.txtclave2.Text);
                    if (tabla.Rows.Count == 0)
                    {
                        MessageBox.Show("Error clave Incorrecta", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtclave2.Text = string.Empty;
                        this.txtclave2.Focus();
                    }
                    else if (tabla.Rows.Count != 0)
                    {
                        CacheModificacionMensualidad.IdDetalleProgramacion = this.txtIdDetalleProgramacion.Text;
                        CacheModificacionMensualidad.Monto = this.txtsubtotal.Text;
                        CacheModificacionMensualidad.Mora = this.txtmora.Text;
                        CacheModificacionMensualidad.Concepto = this.txtConcepto.Text;
                        CacheModificacionMensualidad.Descripcion = this.txtDescripcion.Text;
                        CacheModificacionMensualidad.FechaProgramada = this.txtFechaProgramada.Text;
                        CacheModificacionMensualidad.FechaVencimiento = this.txtFechaVencimiento.Text;

                        this.groupBox4.Enabled = false;
                        this.groupBox5.Visible = false;

                        this.txtclave2.Text = string.Empty;


                        Frm_ModificacionMensualidad frm = new Frm_ModificacionMensualidad();
                        frm.ShowDialog();

                        
                    }


                }


              



            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void Cargar_ComboUsuario()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("select Id_usuario, Usuario from Tbl_Usuarios where Id_estado = '3'", conexion.Conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Usuario"] = "Seleccione un Usuario";
                dt.Rows.InsertAt(fila, 0);

                cmbUsuario.ValueMember = "Id_usuario";
                cmbUsuario.DisplayMember = "Usuario";
                cmbUsuario.DataSource = dt;

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Cargar_ComboUsuario2()
        {
            try
            {

                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("select Id_usuario, Usuario from Tbl_Usuarios where Id_estado = '3'", conexion.Conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Usuario"] = "Seleccione un Usuario";
                dt.Rows.InsertAt(fila, 0);

                comboBox1.ValueMember = "Id_usuario";
                comboBox1.DisplayMember = "Usuario";
                comboBox1.DataSource = dt;

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtestado.Text == "En proceso")
                {
                    CN_Detalle_Programacion ObjetoCN = new CN_Detalle_Programacion();
                    ObjetoCN.EstadoPendiente(this.txtIdDetalleProgramacion.Text);

                    MessageBox.Show("Actualizado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }else
                {
                    MessageBox.Show("Solamente se puede actualizar cuando esta en Proceso", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                this.groupBox5.Visible = true;
                this.tabControl1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                this.groupBox5.Visible = true;
                this.tabControl1.SelectedIndex = 2;




            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                string IdDetalle = this.txtIdDetalleProgramacion.Text;
                if (this.txtIdDetalleProgramacion.Text == string.Empty)
                {
                    MessageBox.Show("Primero Selecciona un Pago ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }else
                {
                    if (this.textBox1.Text == string.Empty)
                    {
                        MessageBox.Show("Ingresa el Numero de Referencia", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }else
                    {
                        CN_Detalle_Programacion objetoCN = new CN_Detalle_Programacion();
                        string FechaActual = DateTime.Now.ToShortDateString();
                        string HoraActual = DateTime.Now.ToShortTimeString();
                        string name = System.Windows.Forms.SystemInformation.ComputerName;
                       

                        objetoCN.EliminarMora(IdDetalle);
                        objetoCN.InsertarExoneracionMora(this.dateTimePicker1.Text, this.textBox1.Text,this.textBox2.Text,FechaActual,HoraActual,CacheUsuario.IdUsuario,IdDetalle,name,FechaActual,HoraActual,"Pendiente");

                        MessageBox.Show("Se quito la Mora Correctamente ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.groupBox5.Visible = false;
                        this.textBox1.Text = string.Empty;
                        this.textBox2.Text = string.Empty;
                        this.dateTimePicker1.Text = DateTime.Now.ToShortDateString();

                    }
                    
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
