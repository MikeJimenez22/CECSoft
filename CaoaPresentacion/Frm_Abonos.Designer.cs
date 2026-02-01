namespace CaoaPresentacion
{
    partial class Frm_Abonos
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
            this.components = new System.ComponentModel.Container();
            this.lblFechaActual = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmontototalAbonar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSaldopendiente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMontocordobas = new System.Windows.Forms.TextBox();
            this.txtmontodolares = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dataAbonos = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalAbonado = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtMontoTotalAbonado = new System.Windows.Forms.TextBox();
            this.txtvalor = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtProximoSaldo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtcodigoFactura = new System.Windows.Forms.TextBox();
            this.txtNombreCurso = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDias = new System.Windows.Forms.TextBox();
            this.txtHorarios = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtconcepto = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataAbonos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFechaActual
            // 
            this.lblFechaActual.AutoSize = true;
            this.lblFechaActual.Location = new System.Drawing.Point(29, 123);
            this.lblFechaActual.Name = "lblFechaActual";
            this.lblFechaActual.Size = new System.Drawing.Size(35, 13);
            this.lblFechaActual.TabIndex = 0;
            this.lblFechaActual.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Monto a Abonar:";
            // 
            // txtmontototalAbonar
            // 
            this.txtmontototalAbonar.Location = new System.Drawing.Point(126, 189);
            this.txtmontototalAbonar.Name = "txtmontototalAbonar";
            this.txtmontototalAbonar.Size = new System.Drawing.Size(293, 20);
            this.txtmontototalAbonar.TabIndex = 2;
            this.txtmontototalAbonar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmontototalAbonar_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre de Curso: ";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(126, 162);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(293, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(27, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 4);
            this.panel1.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(439, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 53);
            this.button1.TabIndex = 10;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(610, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Su Saldo Actual Pendiente  es:";
            // 
            // txtSaldopendiente
            // 
            this.txtSaldopendiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtSaldopendiente.Enabled = false;
            this.txtSaldopendiente.Location = new System.Drawing.Point(602, 291);
            this.txtSaldopendiente.Name = "txtSaldopendiente";
            this.txtSaldopendiente.Size = new System.Drawing.Size(168, 20);
            this.txtSaldopendiente.TabIndex = 13;
            this.txtSaldopendiente.TextChanged += new System.EventHandler(this.txtSaldopendiente_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(639, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Monto en C$";
            // 
            // txtMontocordobas
            // 
            this.txtMontocordobas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtMontocordobas.Enabled = false;
            this.txtMontocordobas.Location = new System.Drawing.Point(602, 203);
            this.txtMontocordobas.Name = "txtMontocordobas";
            this.txtMontocordobas.Size = new System.Drawing.Size(168, 20);
            this.txtMontocordobas.TabIndex = 15;
            this.txtMontocordobas.TextChanged += new System.EventHandler(this.txtMontocordobas_TextChanged);
            // 
            // txtmontodolares
            // 
            this.txtmontodolares.Enabled = false;
            this.txtmontodolares.Location = new System.Drawing.Point(602, 246);
            this.txtmontodolares.Name = "txtmontodolares";
            this.txtmontodolares.Size = new System.Drawing.Size(168, 20);
            this.txtmontodolares.TabIndex = 17;
            this.txtmontodolares.TextChanged += new System.EventHandler(this.txtmontodolares_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(656, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Monto en $";
            // 
            // dataAbonos
            // 
            this.dataAbonos.AllowUserToAddRows = false;
            this.dataAbonos.AllowUserToDeleteRows = false;
            this.dataAbonos.AllowUserToOrderColumns = true;
            this.dataAbonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAbonos.Location = new System.Drawing.Point(12, 325);
            this.dataAbonos.Name = "dataAbonos";
            this.dataAbonos.ReadOnly = true;
            this.dataAbonos.Size = new System.Drawing.Size(776, 117);
            this.dataAbonos.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Location = new System.Drawing.Point(29, 315);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(743, 4);
            this.panel2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Total Abonado:";
            // 
            // txtTotalAbonado
            // 
            this.txtTotalAbonado.Enabled = false;
            this.txtTotalAbonado.Location = new System.Drawing.Point(126, 279);
            this.txtTotalAbonado.Name = "txtTotalAbonado";
            this.txtTotalAbonado.Size = new System.Drawing.Size(293, 20);
            this.txtTotalAbonado.TabIndex = 20;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Monto C$";
            // 
            // txtMontoTotalAbonado
            // 
            this.txtMontoTotalAbonado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtMontoTotalAbonado.Enabled = false;
            this.txtMontoTotalAbonado.Location = new System.Drawing.Point(126, 215);
            this.txtMontoTotalAbonado.Name = "txtMontoTotalAbonado";
            this.txtMontoTotalAbonado.Size = new System.Drawing.Size(293, 20);
            this.txtMontoTotalAbonado.TabIndex = 22;
            this.txtMontoTotalAbonado.TextChanged += new System.EventHandler(this.txtvalor_TextChanged);
            // 
            // txtvalor
            // 
            this.txtvalor.Enabled = false;
            this.txtvalor.Location = new System.Drawing.Point(602, 158);
            this.txtvalor.Name = "txtvalor";
            this.txtvalor.Size = new System.Drawing.Size(168, 20);
            this.txtvalor.TabIndex = 23;
            this.txtvalor.Visible = false;
            this.txtvalor.TextChanged += new System.EventHandler(this.txtvalor_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::CaoaPresentacion.Properties.Resources._4882066;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 50);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // txtProximoSaldo
            // 
            this.txtProximoSaldo.Enabled = false;
            this.txtProximoSaldo.Location = new System.Drawing.Point(126, 246);
            this.txtProximoSaldo.Name = "txtProximoSaldo";
            this.txtProximoSaldo.Size = new System.Drawing.Size(293, 20);
            this.txtProximoSaldo.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Proximo Saldo";
            // 
            // txtcodigoFactura
            // 
            this.txtcodigoFactura.Enabled = false;
            this.txtcodigoFactura.Location = new System.Drawing.Point(600, 54);
            this.txtcodigoFactura.Name = "txtcodigoFactura";
            this.txtcodigoFactura.Size = new System.Drawing.Size(170, 20);
            this.txtcodigoFactura.TabIndex = 27;
            // 
            // txtNombreCurso
            // 
            this.txtNombreCurso.Enabled = false;
            this.txtNombreCurso.Location = new System.Drawing.Point(125, 77);
            this.txtNombreCurso.Name = "txtNombreCurso";
            this.txtNombreCurso.Size = new System.Drawing.Size(645, 20);
            this.txtNombreCurso.TabIndex = 2;
            this.txtNombreCurso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmontototalAbonar_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(79, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Dias";
            // 
            // txtDias
            // 
            this.txtDias.Enabled = false;
            this.txtDias.Location = new System.Drawing.Point(125, 101);
            this.txtDias.Name = "txtDias";
            this.txtDias.Size = new System.Drawing.Size(293, 20);
            this.txtDias.TabIndex = 2;
            this.txtDias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmontototalAbonar_KeyPress);
            // 
            // txtHorarios
            // 
            this.txtHorarios.Enabled = false;
            this.txtHorarios.Location = new System.Drawing.Point(477, 101);
            this.txtHorarios.Name = "txtHorarios";
            this.txtHorarios.Size = new System.Drawing.Size(293, 20);
            this.txtHorarios.TabIndex = 2;
            this.txtHorarios.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmontototalAbonar_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(427, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Horarios";
            // 
            // txtconcepto
            // 
            this.txtconcepto.Enabled = false;
            this.txtconcepto.Location = new System.Drawing.Point(339, 125);
            this.txtconcepto.Name = "txtconcepto";
            this.txtconcepto.Size = new System.Drawing.Size(431, 20);
            this.txtconcepto.TabIndex = 2;
            this.txtconcepto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmontototalAbonar_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(280, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Concepto";
            // 
            // Frm_Abonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtcodigoFactura);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtProximoSaldo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtvalor);
            this.Controls.Add(this.txtMontoTotalAbonado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotalAbonado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataAbonos);
            this.Controls.Add(this.txtmontodolares);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMontocordobas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSaldopendiente);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombreCurso);
            this.Controls.Add(this.txtconcepto);
            this.Controls.Add(this.txtHorarios);
            this.Controls.Add(this.txtDias);
            this.Controls.Add(this.txtmontototalAbonar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFechaActual);
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Frm_Abonos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "e";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Frm_Abonos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataAbonos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFechaActual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtmontototalAbonar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSaldopendiente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMontocordobas;
        private System.Windows.Forms.TextBox txtmontodolares;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataAbonos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalAbonado;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMontoTotalAbonado;
        private System.Windows.Forms.TextBox txtvalor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtProximoSaldo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtcodigoFactura;
        private System.Windows.Forms.TextBox txtNombreCurso;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDias;
        private System.Windows.Forms.TextBox txtHorarios;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtconcepto;
        private System.Windows.Forms.Label label11;
    }
}