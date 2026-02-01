namespace CaoaPresentacion
{
    partial class Frm_SolicitudesDeArreglos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_SolicitudesDeArreglos));
            this.dataSolicitudes = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNombreEstudiante = new System.Windows.Forms.TextBox();
            this.txtApellidosEstudiante = new System.Windows.Forms.TextBox();
            this.txtCarnetEstudiante = new System.Windows.Forms.TextBox();
            this.datadetalles = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtIdArreglo = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataSolicitudes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datadetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSolicitudes
            // 
            this.dataSolicitudes.AllowUserToAddRows = false;
            this.dataSolicitudes.AllowUserToDeleteRows = false;
            this.dataSolicitudes.AllowUserToOrderColumns = true;
            this.dataSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSolicitudes.Location = new System.Drawing.Point(338, 84);
            this.dataSolicitudes.Name = "dataSolicitudes";
            this.dataSolicitudes.ReadOnly = true;
            this.dataSolicitudes.Size = new System.Drawing.Size(923, 176);
            this.dataSolicitudes.TabIndex = 0;
            this.dataSolicitudes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataSolicitudes_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 327);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Motivo de Solicitud del Arreglo";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Enabled = false;
            this.txtObservaciones.Location = new System.Drawing.Point(339, 346);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(922, 67);
            this.txtObservaciones.TabIndex = 6;
            this.txtObservaciones.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(340, 270);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Nombre de Estudiante";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(792, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Apellidos de Estudiante";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(356, 300);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Carnet Estudiantil";
            // 
            // txtNombreEstudiante
            // 
            this.txtNombreEstudiante.Enabled = false;
            this.txtNombreEstudiante.Location = new System.Drawing.Point(458, 267);
            this.txtNombreEstudiante.Name = "txtNombreEstudiante";
            this.txtNombreEstudiante.Size = new System.Drawing.Size(326, 20);
            this.txtNombreEstudiante.TabIndex = 15;
            // 
            // txtApellidosEstudiante
            // 
            this.txtApellidosEstudiante.Enabled = false;
            this.txtApellidosEstudiante.Location = new System.Drawing.Point(918, 270);
            this.txtApellidosEstudiante.Name = "txtApellidosEstudiante";
            this.txtApellidosEstudiante.Size = new System.Drawing.Size(343, 20);
            this.txtApellidosEstudiante.TabIndex = 16;
            // 
            // txtCarnetEstudiante
            // 
            this.txtCarnetEstudiante.Enabled = false;
            this.txtCarnetEstudiante.Location = new System.Drawing.Point(458, 293);
            this.txtCarnetEstudiante.Name = "txtCarnetEstudiante";
            this.txtCarnetEstudiante.Size = new System.Drawing.Size(326, 20);
            this.txtCarnetEstudiante.TabIndex = 17;
            // 
            // datadetalles
            // 
            this.datadetalles.AllowUserToAddRows = false;
            this.datadetalles.AllowUserToDeleteRows = false;
            this.datadetalles.AllowUserToOrderColumns = true;
            this.datadetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datadetalles.Location = new System.Drawing.Point(338, 451);
            this.datadetalles.Name = "datadetalles";
            this.datadetalles.ReadOnly = true;
            this.datadetalles.Size = new System.Drawing.Size(923, 149);
            this.datadetalles.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(967, 615);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 53);
            this.button1.TabIndex = 19;
            this.button1.Text = "Aprobar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1117, 615);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 53);
            this.button2.TabIndex = 20;
            this.button2.Text = "Denegar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 433);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Pagos a Modificar Fecha Limite de Vencimiento";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::CaoaPresentacion.Properties.Resources._4882066;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1284, 50);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // txtIdArreglo
            // 
            this.txtIdArreglo.Enabled = false;
            this.txtIdArreglo.Location = new System.Drawing.Point(918, 296);
            this.txtIdArreglo.Name = "txtIdArreglo";
            this.txtIdArreglo.Size = new System.Drawing.Size(100, 20);
            this.txtIdArreglo.TabIndex = 24;
            this.txtIdArreglo.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 699);
            this.panel1.TabIndex = 25;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CaoaPresentacion.Properties.Resources.Cecnic_Logo_Nuevo_300x2531;
            this.pictureBox2.Location = new System.Drawing.Point(33, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(163, 151);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            // 
            // Frm_SolicitudesDeArreglos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 749);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtIdArreglo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.datadetalles);
            this.Controls.Add(this.txtCarnetEstudiante);
            this.Controls.Add(this.txtApellidosEstudiante);
            this.Controls.Add(this.txtNombreEstudiante);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataSolicitudes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1386, 788);
            this.MinimumSize = new System.Drawing.Size(1278, 726);
            this.Name = "Frm_SolicitudesDeArreglos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: SOLICITUDES DE ARREGLOS DE PAGO :.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_SolicitudesDeArreglos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSolicitudes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datadetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataSolicitudes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNombreEstudiante;
        private System.Windows.Forms.TextBox txtApellidosEstudiante;
        private System.Windows.Forms.TextBox txtCarnetEstudiante;
        private System.Windows.Forms.DataGridView datadetalles;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtIdArreglo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}