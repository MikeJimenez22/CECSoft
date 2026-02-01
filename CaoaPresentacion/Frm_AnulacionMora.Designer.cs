namespace CaoaPresentacion
{
    partial class Frm_AnulacionMora
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbuscar = new System.Windows.Forms.TextBox();
            this.dataPersonas = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.datamatriculas = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dataNotas = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataAbonos = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSubtotalCordobas = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDescripcionMoneda = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtestado = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtsaldoPendiente = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtmontototal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txttotalAbonado = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtmora = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtsubtotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataPersonas)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datamatriculas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataNotas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAbonos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar Carnet";
            // 
            // txtbuscar
            // 
            this.txtbuscar.Enabled = false;
            this.txtbuscar.Location = new System.Drawing.Point(112, 90);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.Size = new System.Drawing.Size(459, 20);
            this.txtbuscar.TabIndex = 1;
            this.txtbuscar.TextChanged += new System.EventHandler(this.txtbuscar_TextChanged);
            // 
            // dataPersonas
            // 
            this.dataPersonas.AllowUserToAddRows = false;
            this.dataPersonas.AllowUserToDeleteRows = false;
            this.dataPersonas.AllowUserToOrderColumns = true;
            this.dataPersonas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataPersonas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataPersonas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataPersonas.Location = new System.Drawing.Point(14, 135);
            this.dataPersonas.Name = "dataPersonas";
            this.dataPersonas.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataPersonas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataPersonas.Size = new System.Drawing.Size(547, 44);
            this.dataPersonas.TabIndex = 2;
            this.dataPersonas.Click += new System.EventHandler(this.dataPersonas_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.datamatriculas);
            this.groupBox1.Location = new System.Drawing.Point(701, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(657, 131);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Cursos Matriculados";
            // 
            // datamatriculas
            // 
            this.datamatriculas.AllowUserToAddRows = false;
            this.datamatriculas.AllowUserToDeleteRows = false;
            this.datamatriculas.AllowUserToOrderColumns = true;
            this.datamatriculas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datamatriculas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datamatriculas.Location = new System.Drawing.Point(8, 20);
            this.datamatriculas.Name = "datamatriculas";
            this.datamatriculas.ReadOnly = true;
            this.datamatriculas.Size = new System.Drawing.Size(643, 98);
            this.datamatriculas.TabIndex = 0;
            this.datamatriculas.Click += new System.EventHandler(this.datamatriculas_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Detalles de Pagos";
            // 
            // dataNotas
            // 
            this.dataNotas.AllowUserToAddRows = false;
            this.dataNotas.AllowUserToDeleteRows = false;
            this.dataNotas.AllowUserToOrderColumns = true;
            this.dataNotas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataNotas.Location = new System.Drawing.Point(12, 203);
            this.dataNotas.Name = "dataNotas";
            this.dataNotas.ReadOnly = true;
            this.dataNotas.Size = new System.Drawing.Size(1346, 197);
            this.dataNotas.TabIndex = 5;
            this.dataNotas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataNotas_CellClick);
            this.dataNotas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataNotas_CellFormatting);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(585, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::CaoaPresentacion.Properties.Resources._4882066;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1370, 43);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Informacion Estudiante";
            // 
            // dataAbonos
            // 
            this.dataAbonos.AllowUserToAddRows = false;
            this.dataAbonos.AllowUserToDeleteRows = false;
            this.dataAbonos.AllowUserToOrderColumns = true;
            this.dataAbonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAbonos.Location = new System.Drawing.Point(12, 407);
            this.dataAbonos.Name = "dataAbonos";
            this.dataAbonos.ReadOnly = true;
            this.dataAbonos.Size = new System.Drawing.Size(390, 253);
            this.dataAbonos.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txtSubtotalCordobas);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtDescripcionMoneda);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtestado);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.txtsaldoPendiente);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtmontototal);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txttotalAbonado);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtmora);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtsubtotal);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(436, 406);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(916, 254);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // txtSubtotalCordobas
            // 
            this.txtSubtotalCordobas.Enabled = false;
            this.txtSubtotalCordobas.Location = new System.Drawing.Point(164, 96);
            this.txtSubtotalCordobas.Name = "txtSubtotalCordobas";
            this.txtSubtotalCordobas.Size = new System.Drawing.Size(143, 20);
            this.txtSubtotalCordobas.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(49, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Subtotal en Cordobas";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(315, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Cordobas";
            // 
            // txtDescripcionMoneda
            // 
            this.txtDescripcionMoneda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcionMoneda.Enabled = false;
            this.txtDescripcionMoneda.Location = new System.Drawing.Point(313, 38);
            this.txtDescripcionMoneda.Name = "txtDescripcionMoneda";
            this.txtDescripcionMoneda.Size = new System.Drawing.Size(100, 13);
            this.txtDescripcionMoneda.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(315, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Cordobas";
            // 
            // txtestado
            // 
            this.txtestado.Enabled = false;
            this.txtestado.Location = new System.Drawing.Point(562, 32);
            this.txtestado.Name = "txtestado";
            this.txtestado.Size = new System.Drawing.Size(143, 20);
            this.txtestado.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(477, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Estado";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(57, 162);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 3);
            this.panel1.TabIndex = 10;
            // 
            // txtsaldoPendiente
            // 
            this.txtsaldoPendiente.Enabled = false;
            this.txtsaldoPendiente.Location = new System.Drawing.Point(164, 205);
            this.txtsaldoPendiente.Name = "txtsaldoPendiente";
            this.txtsaldoPendiente.Size = new System.Drawing.Size(143, 20);
            this.txtsaldoPendiente.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(75, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Saldo";
            // 
            // txtmontototal
            // 
            this.txtmontototal.Enabled = false;
            this.txtmontototal.Location = new System.Drawing.Point(164, 129);
            this.txtmontototal.Name = "txtmontototal";
            this.txtmontototal.Size = new System.Drawing.Size(143, 20);
            this.txtmontototal.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(75, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Monto Total ";
            // 
            // txttotalAbonado
            // 
            this.txttotalAbonado.Enabled = false;
            this.txttotalAbonado.Location = new System.Drawing.Point(164, 176);
            this.txttotalAbonado.Name = "txttotalAbonado";
            this.txttotalAbonado.Size = new System.Drawing.Size(143, 20);
            this.txttotalAbonado.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(72, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Abonado";
            // 
            // txtmora
            // 
            this.txtmora.Enabled = false;
            this.txtmora.Location = new System.Drawing.Point(164, 67);
            this.txtmora.Name = "txtmora";
            this.txtmora.Size = new System.Drawing.Size(143, 20);
            this.txtmora.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Mora";
            // 
            // txtsubtotal
            // 
            this.txtsubtotal.Enabled = false;
            this.txtsubtotal.Location = new System.Drawing.Point(164, 38);
            this.txtsubtotal.Name = "txtsubtotal";
            this.txtsubtotal.Size = new System.Drawing.Size(143, 20);
            this.txtsubtotal.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Subtotal";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(14, 58);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(457, 17);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Si Ocurre un problema con la busqueda, Presiona aqui y Digita Nuevamente";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(487, 68);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(218, 29);
            this.button2.TabIndex = 19;
            this.button2.Text = "Anular Mora";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // Frm_AnulacionMora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 672);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataAbonos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataNotas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataPersonas);
            this.Controls.Add(this.txtbuscar);
            this.Controls.Add(this.label1);
            this.Name = "Frm_AnulacionMora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: PAGOS :.";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_RegistroNotas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataPersonas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datamatriculas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataNotas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAbonos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbuscar;
        private System.Windows.Forms.DataGridView dataPersonas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView datamatriculas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataNotas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataAbonos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtsaldoPendiente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtmontototal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txttotalAbonado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtmora;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtsubtotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtestado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDescripcionMoneda;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSubtotalCordobas;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
    }
}