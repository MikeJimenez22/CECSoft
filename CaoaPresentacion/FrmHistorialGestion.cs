using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


        public FrmHistorialGestion(string Carnet,string Estudiante,string Celular,string Curso,string Turno,string Horario,string Concepto,string FechaVencimiento,string Total,string Mora,string MontoAbonado,string SaldoPendiente,string DiasDiferencia,string  NivelMora,string EstadoCartera)
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
        }

        private void FrmHistorialGestion_Load(object sender, EventArgs e)
        {
            try
            {
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
    }
}
