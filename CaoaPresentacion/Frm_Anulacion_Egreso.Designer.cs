namespace CaoaPresentacion
{
    partial class Frm_Anulacion_Egreso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Anulacion_Egreso));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCodigoEgreso = new System.Windows.Forms.TextBox();
            this.txtmonto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtTipoMovimiento = new System.Windows.Forms.TextBox();
            this.TXTEstado = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(110, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(203, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "N° De Egreso";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(319, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCodigoEgreso
            // 
            this.txtCodigoEgreso.Enabled = false;
            this.txtCodigoEgreso.Location = new System.Drawing.Point(532, 2);
            this.txtCodigoEgreso.Name = "txtCodigoEgreso";
            this.txtCodigoEgreso.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoEgreso.TabIndex = 3;
            this.txtCodigoEgreso.Visible = false;
            this.txtCodigoEgreso.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtmonto
            // 
            this.txtmonto.Enabled = false;
            this.txtmonto.Location = new System.Drawing.Point(110, 63);
            this.txtmonto.Name = "txtmonto";
            this.txtmonto.Size = new System.Drawing.Size(137, 20);
            this.txtmonto.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Monto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tipo de Moneda";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Location = new System.Drawing.Point(344, 63);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(137, 20);
            this.txtDescripcion.TabIndex = 7;
            // 
            // txtConcepto
            // 
            this.txtConcepto.Enabled = false;
            this.txtConcepto.Location = new System.Drawing.Point(41, 108);
            this.txtConcepto.Multiline = true;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(565, 140);
            this.txtConcepto.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Descripcion";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(492, 254);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 38);
            this.button2.TabIndex = 10;
            this.button2.Text = "Anular";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtTipoMovimiento
            // 
            this.txtTipoMovimiento.Enabled = false;
            this.txtTipoMovimiento.Location = new System.Drawing.Point(426, 2);
            this.txtTipoMovimiento.Name = "txtTipoMovimiento";
            this.txtTipoMovimiento.Size = new System.Drawing.Size(100, 20);
            this.txtTipoMovimiento.TabIndex = 11;
            this.txtTipoMovimiento.Visible = false;
            this.txtTipoMovimiento.TextChanged += new System.EventHandler(this.txtTipoMovimiento_TextChanged);
            // 
            // TXTEstado
            // 
            this.TXTEstado.Enabled = false;
            this.TXTEstado.Location = new System.Drawing.Point(532, 28);
            this.TXTEstado.Name = "TXTEstado";
            this.TXTEstado.Size = new System.Drawing.Size(100, 20);
            this.TXTEstado.TabIndex = 12;
            // 
            // Frm_Anulacion_Egreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 304);
            this.Controls.Add(this.TXTEstado);
            this.Controls.Add(this.txtTipoMovimiento);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtConcepto);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtmonto);
            this.Controls.Add(this.txtCodigoEgreso);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(654, 343);
            this.MinimumSize = new System.Drawing.Size(654, 343);
            this.Name = "Frm_Anulacion_Egreso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ANULACION DE EGRESOS";
            this.Load += new System.EventHandler(this.Frm_Anulacion_Egreso_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCodigoEgreso;
        private System.Windows.Forms.TextBox txtmonto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtTipoMovimiento;
        private System.Windows.Forms.TextBox TXTEstado;
    }
}