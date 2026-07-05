using System;
using System.Windows.Forms;

namespace CaoaPresentacion
{
    public partial class FrmLoad : Form
    {
        public FrmLoad()
        {
            InitializeComponent();
            this.circularProgressBar1.Value = 0;
        }

        private void FrmLoad_Load(object sender, EventArgs e)
        {
            this.Enabled = true;
       
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.circularProgressBar1.Value += 1;
            this.circularProgressBar1.Text = circularProgressBar1.Value.ToString() + " %";
            if (circularProgressBar1.Value == 100)
            {
                timer1.Enabled = false;
                FrmInicioSesion frm = new FrmInicioSesion();
                frm.Show();
                this.Hide();
            }
        }
    }
}
