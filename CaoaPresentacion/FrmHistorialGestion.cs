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
using Utils;
using System.Diagnostics;



namespace CaoaPresentacion
{
    public partial class FrmHistorialGestion : Form
    {
        private string _Carnet;
        private string _Estudiante;
        private string _Celular;
        private string _Curso;
        private string _Turno;
        private string _Horario;
        private string _Concepto;
        private string _FechaVencimiento;
        private string _Total;
        private string _Mora;
        private string _MontoAbonado;
        private string _SaldoPendiente;
        private string _DiasDiferencia;
        private string _NivelMora;
        private string _EstadoCartera;
        private int _IdDetalleProgramacion;


        public FrmHistorialGestion(string Carnet,string Estudiante,string Celular,string Curso,string Turno,string Horario,string Concepto,string FechaVencimiento,string Total,string Mora,string MontoAbonado,string SaldoPendiente,string DiasDiferencia,string  NivelMora,string EstadoCartera,int IdDetalleProgramacion)
        {
            InitializeComponent();

            _Carnet = Carnet;
            _Estudiante = Estudiante;
            _Celular = Celular;
            _Curso = Curso;
            _Turno = Turno;
            _Horario = Horario;
            _Concepto = Concepto;
            _FechaVencimiento = FechaVencimiento;
            _Total = Total;
            _Mora = Mora;
            _MontoAbonado = MontoAbonado;
            _SaldoPendiente = SaldoPendiente;
            _DiasDiferencia = DiasDiferencia;
            _NivelMora = NivelMora;
            _EstadoCartera = EstadoCartera;
            _IdDetalleProgramacion = IdDetalleProgramacion;

            this.cbTipoGestion.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbResultado.DropDownStyle = ComboBoxStyle.DropDownList;
          //  DataGridViewConfigurator.Configure(this.dataHistorialGestion);
        }

        private void FrmHistorialGestion_Load(object sender, EventArgs e)
        {
            try
            {
                EstiloDataGridView(dataHistorialGestion);
                this.lblCarnet.Text = _Carnet;
                this.lblEstudiante.Text = _Estudiante;
                this.lblCelular.Text = _Celular;
                this.lblCurso.Text = _Curso;
                this.lblTurno.Text = _Turno;
                this.lblHorario.Text = _Horario;
                this.lblConcepto.Text = _Concepto;
                this.lblFechaVencimiento.Text = _FechaVencimiento;
                this.lblMonto.Text = _Total;
                this.lblMora.Text = _Mora;
                this.lblAbonado.Text = _MontoAbonado;
                this.lblSaldo.Text = _SaldoPendiente;
                this.lblDiasDiferencia.Text = _DiasDiferencia;

                this.ConfigurarPanelCuenta();
                this.CargarTiposGestion();
                MostrarHistorialGestionCobro(Convert.ToInt32(_IdDetalleProgramacion));
                this.dataHistorialGestion.Columns["IdGestion"].Visible = false;
       
                dtpFechaPromesa.Enabled = false;

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstiloDataGridView(DataGridView dgv)
        {
            // General
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Encabezados
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 78, 121);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 40;

            // Filas
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 235, 252);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Filas alternas
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // Bordes
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.LightGray;

            // Altura de filas
            dgv.RowTemplate.Height = 30;

            // Centrar encabezados
            foreach (DataGridViewColumn columna in dgv.Columns)
            {
                columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void MostrarHistorialGestionCobro(int IdDetalleProgramacion)
        {
            try
            {
                CN_GestionCobro ObjetoCN = new CN_GestionCobro();
                dataHistorialGestion.DataSource = ObjetoCN.MostrarHistorialGestion(IdDetalleProgramacion);
                this.label26.Text = "Total de Registros: " + dataHistorialGestion.Rows.Count.ToString();
                
                
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarPanelCuenta()
        {
            if (_EstadoCartera == "Solvente")
            {
                lblEstadoCartera.Text = "Solvente";
                PanelEstadoCartera.BackColor = Color.FromArgb(40, 167, 69);
                lblEstadoCartera.ForeColor = Color.White;

                lblNivelMora.Text = "Al Día";
                PanelNivelMora.BackColor = Color.FromArgb(40, 167, 69);
                lblNivelMora.ForeColor = Color.White;
            }
            else // Insolvente
            {
                lblEstadoCartera.Text = "Insolvente";
                PanelEstadoCartera.BackColor = Color.FromArgb(220, 53, 69);
                lblEstadoCartera.ForeColor = Color.White;

                if (_NivelMora == "Al Dia")
                {
                    lblNivelMora.Text = "Pendiente (No Vencida)";
                    PanelNivelMora.BackColor = Color.FromArgb(23, 162, 184); // Azul
                    lblNivelMora.ForeColor = Color.White;
                }
                else if (_NivelMora == "Baja")
                {
                    lblNivelMora.Text = "Baja (1-7 días)";
                    PanelNivelMora.BackColor = Color.FromArgb(255, 193, 7);
                    lblNivelMora.ForeColor = Color.Black;
                }
                else if (_NivelMora == "Media")
                {
                    lblNivelMora.Text = "Media (8-15 días)";
                    PanelNivelMora.BackColor = Color.FromArgb(255, 140, 0);
                    lblNivelMora.ForeColor = Color.White;
                }
                else if (_NivelMora == "Alta")
                {
                    lblNivelMora.Text = "Alta (16-30 días)";
                    PanelNivelMora.BackColor = Color.FromArgb(220, 53, 69);
                    lblNivelMora.ForeColor = Color.White;
                }
                else if (_NivelMora == "Critica")
                {
                    lblNivelMora.Text = "Crítica (> 30 días)";
                    PanelNivelMora.BackColor = Color.FromArgb(111, 66, 193);
                    lblNivelMora.ForeColor = Color.White;
                }
            }
        }

        private void CargarTiposGestion()
        {
            cbTipoGestion.Items.Clear();

            cbTipoGestion.Items.Add("Seleccionar...");
            cbTipoGestion.Items.Add("Llamada");
            cbTipoGestion.Items.Add("WhatsApp");
            cbTipoGestion.Items.Add("SMS");
            cbTipoGestion.Items.Add("Correo");
            cbTipoGestion.Items.Add("Visita");

            cbTipoGestion.SelectedIndex = 0;

            cbResultado.Items.Clear();
            cbResultado.Items.Add("Seleccionar...");
            cbResultado.SelectedIndex = 0;
        }

        private void cbTipoGestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbResultado.Items.Clear();
            cbResultado.Items.Add("Seleccionar...");

            switch (cbTipoGestion.Text)
            {
                case "Llamada":

                    cbResultado.Items.Add("Contestó");
                    cbResultado.Items.Add("No contestó");
                    cbResultado.Items.Add("Teléfono apagado");
                    cbResultado.Items.Add("Número incorrecto");
                    cbResultado.Items.Add("Promesa de pago");
                    cbResultado.Items.Add("Pago realizado");
                    cbResultado.Items.Add("Solicita prórroga");
                    cbResultado.Items.Add("Reagendar contacto");

                    break;

                case "WhatsApp":

                    cbResultado.Items.Add("Mensaje enviado");
                    cbResultado.Items.Add("Visto");
                    cbResultado.Items.Add("Respondió");
                    cbResultado.Items.Add("Sin respuesta");
                    cbResultado.Items.Add("Promesa de pago");
                    cbResultado.Items.Add("Pago realizado");
                    cbResultado.Items.Add("Número no registrado");

                    break;

                case "SMS":

                    cbResultado.Items.Add("Enviado");
                    cbResultado.Items.Add("Entregado");
                    cbResultado.Items.Add("Sin respuesta");
                    cbResultado.Items.Add("Promesa de pago");
                    cbResultado.Items.Add("Pago realizado");

                    break;

                case "Correo":

                    cbResultado.Items.Add("Enviado");
                    cbResultado.Items.Add("Leído");
                    cbResultado.Items.Add("Sin respuesta");
                    cbResultado.Items.Add("Promesa de pago");
                    cbResultado.Items.Add("Pago realizado");

                    break;

                case "Visita":

                    cbResultado.Items.Add("Se encontró al estudiante");
                    cbResultado.Items.Add("No se encontró");
                    cbResultado.Items.Add("Promesa de pago");
                    cbResultado.Items.Add("Pago realizado");
                    cbResultado.Items.Add("Rechazó el pago");

                    break;
            }

            cbResultado.SelectedIndex = 0;
        }

        private void cbResultado_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            bool esPromesaPago = cbResultado.Text == "Promesa de pago";

            
            dtpFechaPromesa.Enabled = esPromesaPago;

            if (!esPromesaPago)
            {
                
                dtpFechaPromesa.Value = DateTime.Today;
            }

            CalcularProximaGestion();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Limpiar();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            try
            {
                this.CargarTiposGestion();

                dtpFechaPromesa.Enabled = false;
                dtpFechaPromesa.Text = DateTime.Now.ToShortDateString();
                this.txtObservacion.Text = string.Empty;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularProximaGestion()
        {
            string resultado = cbResultado.Text;

            switch (resultado)
            {
                // Contactar al día siguiente
                case "No contestó":
                case "Teléfono apagado":
                case "Sin respuesta":
                case "No se encontró":
                    dtpProximaGestion.Value = DateTime.Today.AddDays(1);
                    break;

                // Seguimiento en 2 días
                case "Mensaje enviado":
                case "Enviado":
                case "Visto":
                case "Leído":
                case "Respondió":
                case "Entregado":
                    dtpProximaGestion.Value = DateTime.Today.AddDays(2);
                    break;

                // Seguimiento en 3 días
                case "Contestó":
                case "Solicita prórroga":
                case "Se encontró al estudiante":
                case "Reagendar contacto":
                    dtpProximaGestion.Value = DateTime.Today.AddDays(3);
                    break;

                // Usar la fecha prometida
                case "Promesa de pago":
                    dtpProximaGestion.Value = dtpFechaPromesa.Value.Date;
                    break;

                // Casos cerrados
                case "Pago realizado":
                case "Número incorrecto":
                case "Número no registrado":
                case "Rechazó el pago":
                    dtpProximaGestion.Checked = false; // si ShowCheckBox = true
                    break;
            }
        }

        private void chkFechaPromesaPago_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void dtpFechaPromesa_ValueChanged(object sender, EventArgs e)
        {
            if (cbResultado.Text == "Promesa de pago")
            {
                dtpProximaGestion.Value = dtpFechaPromesa.Value.Date;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CN_GestionCobro ObjetoCN = new CN_GestionCobro();

                if (this.cbTipoGestion.Text == "Seleccionar...")
                {
                    MessageBox.Show("Selecciona el Tipo de Gestion", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (this.cbResultado.Text == "Seleccionar...")
                {
                    MessageBox.Show("Selecciona el Resultado de la Gestion", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtObservacion.Text))
                {
                    MessageBox.Show("Debe escribir una observación.", "SISTEMA CECNIC",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtObservacion.Focus();
                    return;
                }

                if (cbResultado.Text == "Promesa de pago")
                {
                    if (dtpFechaPromesa.Value.Date < DateTime.Today)
                    {
                        MessageBox.Show("La fecha de promesa no puede ser menor a hoy.",
                            "SISTEMA CECNIC",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        dtpFechaPromesa.Focus();
                        return;
                    }
                }

                DateTime? FechaPromesa = null;
                DateTime? FechaProximaGestion = null;

                switch (cbResultado.Text)
                {
                    case "Promesa de pago":

                        FechaPromesa = dtpFechaPromesa.Value.Date;
                        FechaProximaGestion = dtpProximaGestion.Value.Date;
                        break;

                    case "Pago realizado":
                    case "Número incorrecto":
                    case "Número no registrado":
                    case "Rechazó el pago":

                        FechaPromesa = null;
                        FechaProximaGestion = null;
                        break;

                    default:

                        FechaPromesa = null;
                        FechaProximaGestion = dtpProximaGestion.Value.Date;
                        break;
                }

                DataTable tabla = new DataTable();
                tabla = ObjetoCN.ValidarDuplicados(_IdDetalleProgramacion);
                if (tabla.Rows.Count != 0)
                {
                    MessageBox.Show("Ya existe una gestión registrada para este estudiante el día de hoy.",
                    "SISTEMA CECNIC",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }else
                {
                    CN_GestionCobro ObjetoCN2 = new CN_GestionCobro();
                    ObjetoCN2.InsertarGestionCobro(_IdDetalleProgramacion.ToString(), this.cbTipoGestion.Text, this.cbResultado.Text, this.txtObservacion.Text.Trim(), FechaPromesa.ToString(), FechaProximaGestion.ToString(), CacheUsuario.IdUsuario);
                    MessageBox.Show("Registro Guardado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarHistorialGestionCobro(Convert.ToInt32(_IdDetalleProgramacion));
                    this.Limpiar();
                }
                
               
               
            }
            catch (Exception )
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                string telefono = this.lblCelular.Text;

                string estudiante = this.lblEstudiante.Text;

                string saldo = this.lblSaldo.Text;

                string mensaje =
                 $" Hola *{estudiante}*,\n\n" +
                 $" Le saludamos de *CECNIC*.\n\n" +
                 $" Queremos recordarle que actualmente presenta un *saldo pendiente de C$ {saldo}* correspondiente a sus cuotas académicas.\n\n" +
                 $" Le invitamos cordialmente a ponerse al día con sus pagos para evitar inconvenientes en sus servicios académicos.\n\n" +
                 $" Si ya realizó su pago o necesita apoyo para regularizar su situación, por favor comuníquese con nosotros. Con gusto le atenderemos.\n\n" +
                 $" Gracias por su atención y colaboración.\n\n" +
                 $" *CECNIC - Formando Profesionales para el Futuro*";

                // Quitar espacios, guiones, etc.
                telefono = telefono.Replace("-", "")
                                   .Replace(" ", "");

                // Agregar código de Nicaragua si no existe
                if (!telefono.StartsWith("505"))
                {
                    telefono = "505" + telefono;
                }

                string url = $"https://wa.me/{telefono}?text={Uri.EscapeDataString(mensaje)}";

                Process.Start(new ProcessStartInfo()
                {
                    FileName = url,
                    UseShellExecute = true
                });

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


    }
}
