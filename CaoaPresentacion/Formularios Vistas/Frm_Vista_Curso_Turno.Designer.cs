namespace CaoaPresentacion.Formularios_Vistas
{
    partial class Frm_Vista_Curso_Turno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataTurnoCursos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataTurnoCursos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataTurnoCursos
            // 
            this.dataTurnoCursos.AllowUserToAddRows = false;
            this.dataTurnoCursos.AllowUserToDeleteRows = false;
            this.dataTurnoCursos.AllowUserToOrderColumns = true;
            this.dataTurnoCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTurnoCursos.Location = new System.Drawing.Point(21, 80);
            this.dataTurnoCursos.Name = "dataTurnoCursos";
            this.dataTurnoCursos.ReadOnly = true;
            this.dataTurnoCursos.Size = new System.Drawing.Size(1325, 441);
            this.dataTurnoCursos.TabIndex = 0;
            this.dataTurnoCursos.Click += new System.EventHandler(this.dataTurnoCursos_Click);
            this.dataTurnoCursos.Paint += new System.Windows.Forms.PaintEventHandler(this.dataTurnoCursos_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Buscar Curso";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(214, 44);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(450, 20);
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // Frm_Vista_Curso_Turno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 549);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataTurnoCursos);
            this.MinimumSize = new System.Drawing.Size(1039, 588);
            this.Name = "Frm_Vista_Curso_Turno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: TURNO Y CURSO :.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Vista_Curso_Turno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTurnoCursos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataTurnoCursos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
    }
}