namespace CaoaPresentacion.Formularios_Vistas
{
    partial class Frm_VistaGrupos
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
            this.dataGrupos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTurnos = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrupos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrupos
            // 
            this.dataGrupos.AllowUserToAddRows = false;
            this.dataGrupos.AllowUserToDeleteRows = false;
            this.dataGrupos.AllowUserToOrderColumns = true;
            this.dataGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrupos.Location = new System.Drawing.Point(14, 79);
            this.dataGrupos.Name = "dataGrupos";
            this.dataGrupos.ReadOnly = true;
            this.dataGrupos.Size = new System.Drawing.Size(1344, 524);
            this.dataGrupos.TabIndex = 0;
            this.dataGrupos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrupos_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cursos";
            // 
            // cmbTurnos
            // 
            this.cmbTurnos.FormattingEnabled = true;
            this.cmbTurnos.Location = new System.Drawing.Point(145, 54);
            this.cmbTurnos.Name = "cmbTurnos";
            this.cmbTurnos.Size = new System.Drawing.Size(716, 21);
            this.cmbTurnos.TabIndex = 2;
            this.cmbTurnos.SelectedIndexChanged += new System.EventHandler(this.cmbTurnos_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::CaoaPresentacion.Properties.Resources._4882066;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1284, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Frm_VistaGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 749);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmbTurnos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrupos);
            this.MaximumSize = new System.Drawing.Size(1386, 788);
            this.MinimumSize = new System.Drawing.Size(1278, 726);
            this.Name = "Frm_VistaGrupos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: GRUPOS :.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_VistaGrupos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrupos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrupos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTurnos;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}