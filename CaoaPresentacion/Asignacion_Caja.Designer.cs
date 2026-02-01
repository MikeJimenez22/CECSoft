namespace CaoaPresentacion
{
    partial class Asignacion_Caja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Asignacion_Caja));
            this.datAsignacion = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCaja = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtcarnetEmpleado = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtNombreCompleto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCedulaIdentidad = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datAsignacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // datAsignacion
            // 
            this.datAsignacion.AllowUserToAddRows = false;
            this.datAsignacion.AllowUserToDeleteRows = false;
            this.datAsignacion.AllowUserToOrderColumns = true;
            this.datAsignacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datAsignacion.Location = new System.Drawing.Point(43, 110);
            this.datAsignacion.Name = "datAsignacion";
            this.datAsignacion.ReadOnly = true;
            this.datAsignacion.Size = new System.Drawing.Size(628, 168);
            this.datAsignacion.TabIndex = 0;
            this.datAsignacion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datAsignacion_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccionar Caja";
            // 
            // cmbCaja
            // 
            this.cmbCaja.FormattingEnabled = true;
            this.cmbCaja.Location = new System.Drawing.Point(147, 294);
            this.cmbCaja.Name = "cmbCaja";
            this.cmbCaja.Size = new System.Drawing.Size(174, 21);
            this.cmbCaja.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Seleccionar Usuario";
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(472, 294);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(199, 21);
            this.cmbUsuario.TabIndex = 4;
            this.cmbUsuario.SelectedIndexChanged += new System.EventHandler(this.cmbUsuario_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Estado";
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(147, 328);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(174, 21);
            this.cmbEstado.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Image = global::CaoaPresentacion.Properties.Resources._285657_floppy_guardar_save_icon;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(472, 323);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 38);
            this.button1.TabIndex = 7;
            this.button1.Text = "Guardar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 378);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Usuario Asignado";
            // 
            // txtuser
            // 
            this.txtuser.Enabled = false;
            this.txtuser.Location = new System.Drawing.Point(168, 375);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(153, 20);
            this.txtuser.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(345, 378);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Carnet Empleado";
            // 
            // txtcarnetEmpleado
            // 
            this.txtcarnetEmpleado.Enabled = false;
            this.txtcarnetEmpleado.Location = new System.Drawing.Point(472, 371);
            this.txtcarnetEmpleado.Name = "txtcarnetEmpleado";
            this.txtcarnetEmpleado.Size = new System.Drawing.Size(199, 20);
            this.txtcarnetEmpleado.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 411);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Nombre Empleado";
            // 
            // TxtNombreCompleto
            // 
            this.TxtNombreCompleto.Enabled = false;
            this.TxtNombreCompleto.Location = new System.Drawing.Point(168, 404);
            this.TxtNombreCompleto.Name = "TxtNombreCompleto";
            this.TxtNombreCompleto.Size = new System.Drawing.Size(503, 20);
            this.TxtNombreCompleto.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(65, 436);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Cedula";
            // 
            // txtCedulaIdentidad
            // 
            this.txtCedulaIdentidad.Enabled = false;
            this.txtCedulaIdentidad.Location = new System.Drawing.Point(168, 430);
            this.txtCedulaIdentidad.Name = "txtCedulaIdentidad";
            this.txtCedulaIdentidad.Size = new System.Drawing.Size(503, 20);
            this.txtCedulaIdentidad.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::CaoaPresentacion.Properties.Resources._4882066;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(729, 50);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(729, 29);
            this.panel1.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(16, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(323, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "(*) Solo se puede Registrar una Caja Por Usuario";
            // 
            // Asignacion_Caja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtCedulaIdentidad);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtNombreCompleto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtcarnetEmpleado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCaja);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datAsignacion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(745, 500);
            this.MinimumSize = new System.Drawing.Size(745, 500);
            this.Name = "Asignacion_Caja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: ASIGNACION DE CAJA:.";
            this.Load += new System.EventHandler(this.Asignacion_Caja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datAsignacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datAsignacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCaja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtcarnetEmpleado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtNombreCompleto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCedulaIdentidad;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
    }
}