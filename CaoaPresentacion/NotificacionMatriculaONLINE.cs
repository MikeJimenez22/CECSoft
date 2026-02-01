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
    public partial class NotificacionMatriculaONLINE : Form
    {
        public NotificacionMatriculaONLINE()
        {
            InitializeComponent();
        }

        private void NotificacionMatriculaONLINE_Load(object sender, EventArgs e)
        {
            try
            {
                this.lblnombreestudiante.Text = CacheDetalleMatricula.NombreEstudianteOnline;
                this.txtcurso.Text = CacheDetalleMatricula.NombreCursoOnline;
                this.txtturno.Text = CacheDetalleMatricula.TurnoOnline;
                this.txthorario.Text = CacheDetalleMatricula.HorarioOnline;
                this.txtfechainicio.Text = Convert.ToDateTime(CacheDetalleMatricula.FechaInicioOnline).ToShortDateString();
                this.txtmatriculadopor.Text = CacheDetalleMatricula.OrigenMatriculaOnline;
                this.txtobservaciones.Text = CacheDetalleMatricula.ObservacionesOnline;


            } catch (Exception) {
                MessageBox.Show("Error de Sistema","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
