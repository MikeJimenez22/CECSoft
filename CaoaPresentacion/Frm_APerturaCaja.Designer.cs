namespace CaoaPresentacion
{
    partial class Frm_APerturaCaja
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtTotalCordobas = new System.Windows.Forms.TextBox();
            this.txtEnCordobas = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbTipoMoneda = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtmonto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.txtTotalCordobas);
            this.groupBox1.Controls.Add(this.txtEnCordobas);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmbTipoMoneda);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtmonto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(16, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(553, 180);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Apertura de Caja ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::CaoaPresentacion.Properties.Resources._4882066;
            this.pictureBox1.Location = new System.Drawing.Point(3, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(547, 54);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // txtTotalCordobas
            // 
            this.txtTotalCordobas.Enabled = false;
            this.txtTotalCordobas.Location = new System.Drawing.Point(6, 154);
            this.txtTotalCordobas.Name = "txtTotalCordobas";
            this.txtTotalCordobas.Size = new System.Drawing.Size(210, 20);
            this.txtTotalCordobas.TabIndex = 9;
            // 
            // txtEnCordobas
            // 
            this.txtEnCordobas.Enabled = false;
            this.txtEnCordobas.Location = new System.Drawing.Point(222, 154);
            this.txtEnCordobas.Name = "txtEnCordobas";
            this.txtEnCordobas.Size = new System.Drawing.Size(64, 20);
            this.txtEnCordobas.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(386, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 42);
            this.button1.TabIndex = 6;
            this.button1.Text = "Crear Apertura de Caja ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbTipoMoneda
            // 
            this.cmbTipoMoneda.FormattingEnabled = true;
            this.cmbTipoMoneda.Location = new System.Drawing.Point(277, 91);
            this.cmbTipoMoneda.Name = "cmbTipoMoneda";
            this.cmbTipoMoneda.Size = new System.Drawing.Size(211, 21);
            this.cmbTipoMoneda.TabIndex = 5;
            this.cmbTipoMoneda.SelectedIndexChanged += new System.EventHandler(this.cmbTipoMoneda_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(327, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo de Moneda ";
            // 
            // txtmonto
            // 
            this.txtmonto.Location = new System.Drawing.Point(150, 92);
            this.txtmonto.Name = "txtmonto";
            this.txtmonto.Size = new System.Drawing.Size(122, 20);
            this.txtmonto.TabIndex = 3;
            this.txtmonto.TextChanged += new System.EventHandler(this.txtmonto_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Monto de Apertura";
            // 
            // Frm_APerturaCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 212);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(602, 251);
            this.MinimumSize = new System.Drawing.Size(602, 251);
            this.Name = "Frm_APerturaCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: APERTURA DE CAJA :.";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Frm_APerturaCaja_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbTipoMoneda;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtmonto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEnCordobas;
        private System.Windows.Forms.TextBox txtTotalCordobas;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}