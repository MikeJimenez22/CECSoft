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
    public partial class Reporte_ActaNota : Form
    {
        public Reporte_ActaNota()
        {
            InitializeComponent();
        }

        private void Reporte_ActaNota_Load(object sender, EventArgs e)
        {
            string CodigoActa = CacheDatosImpresion.CodigoActa;
            this.FormClosed += new FormClosedEventHandler(cerrarform);
            // TODO: esta línea de código carga datos en la tabla 'CecnicSystemDataSet.SP_ObtenerActaNota' Puede moverla o quitarla según sea necesario.
            this.SP_ObtenerActaNotaTableAdapter.Fill(this.CecnicSystemDataSet.SP_ObtenerActaNota,CodigoActa);
            // TODO: esta línea de código carga datos en la tabla 'CecnicSystemDataSet.SP_ObtenerDetalleActa' Puede moverla o quitarla según sea necesario.
            this.SP_ObtenerDetalleActaTableAdapter.Fill(this.CecnicSystemDataSet.SP_ObtenerDetalleActa,CodigoActa);
            this.reportViewer1.RefreshReport();
        }

        private void cerrarform(object sender, EventArgs e)
        {
            
            Frm_Docente frm = new Frm_Docente();
            frm.Show();
            this.Hide();

        }
    }
}
