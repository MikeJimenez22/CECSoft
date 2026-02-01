namespace CaoaPresentacion
{
    partial class Frm_CarnetEstudiantil
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.dataListadoCarnet = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelSucursal = new System.Windows.Forms.Label();
            this.labelHorario = new System.Windows.Forms.Label();
            this.lblTurno = new System.Windows.Forms.Label();
            this.pictureBoxBarcode = new System.Windows.Forms.PictureBox();
            this.lblFechaVencimiento = new System.Windows.Forms.Label();
            this.lblFechaEmision = new System.Windows.Forms.Label();
            this.lblCodigoCarnet = new System.Windows.Forms.Label();
            this.lblcurso = new System.Windows.Forms.Label();
            this.lblNombres = new System.Windows.Forms.Label();
            this.PictureBoxCarnet = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoCarnet)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxCarnet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(7, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1399, 920);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.dataListadoCarnet);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1391, 894);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::CaoaPresentacion.Properties.Resources._728898_page_folder_add_plus_file_icon;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(1117, 616);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(181, 52);
            this.button2.TabIndex = 7;
            this.button2.Text = "Generar todos los carnet";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataListadoCarnet
            // 
            this.dataListadoCarnet.AllowUserToAddRows = false;
            this.dataListadoCarnet.AllowUserToDeleteRows = false;
            this.dataListadoCarnet.AllowUserToOrderColumns = true;
            this.dataListadoCarnet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataListadoCarnet.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataListadoCarnet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListadoCarnet.Location = new System.Drawing.Point(6, 88);
            this.dataListadoCarnet.Name = "dataListadoCarnet";
            this.dataListadoCarnet.ReadOnly = true;
            this.dataListadoCarnet.Size = new System.Drawing.Size(1292, 522);
            this.dataListadoCarnet.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1292, 76);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Image = global::CaoaPresentacion.Properties.Resources._1814075_find_magnifier_magnifying_glass_search_icon;
            this.button1.Location = new System.Drawing.Point(498, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 37);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(361, 37);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(134, 26);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(263, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Final";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(111, 37);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(134, 26);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha Inicio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Generar Carnet Masivos";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1391, 894);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelSucursal);
            this.panel2.Controls.Add(this.labelHorario);
            this.panel2.Controls.Add(this.lblTurno);
            this.panel2.Controls.Add(this.pictureBoxBarcode);
            this.panel2.Controls.Add(this.lblFechaVencimiento);
            this.panel2.Controls.Add(this.lblFechaEmision);
            this.panel2.Controls.Add(this.lblCodigoCarnet);
            this.panel2.Controls.Add(this.lblcurso);
            this.panel2.Controls.Add(this.lblNombres);
            this.panel2.Controls.Add(this.PictureBoxCarnet);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(667, 1100);
            this.panel2.TabIndex = 3;
            // 
            // labelSucursal
            // 
            this.labelSucursal.AutoSize = true;
            this.labelSucursal.Font = new System.Drawing.Font("Arial", 14.25F);
            this.labelSucursal.ForeColor = System.Drawing.Color.Navy;
            this.labelSucursal.Location = new System.Drawing.Point(32, 292);
            this.labelSucursal.Name = "labelSucursal";
            this.labelSucursal.Size = new System.Drawing.Size(123, 22);
            this.labelSucursal.TabIndex = 12;
            this.labelSucursal.Text = "labelSucursal";
            // 
            // labelHorario
            // 
            this.labelHorario.AutoSize = true;
            this.labelHorario.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.labelHorario.ForeColor = System.Drawing.Color.Navy;
            this.labelHorario.Location = new System.Drawing.Point(333, 593);
            this.labelHorario.Name = "labelHorario";
            this.labelHorario.Size = new System.Drawing.Size(102, 19);
            this.labelHorario.TabIndex = 11;
            this.labelHorario.Text = "labelHorario";
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurno.ForeColor = System.Drawing.Color.Navy;
            this.lblTurno.Location = new System.Drawing.Point(48, 593);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(72, 19);
            this.lblTurno.TabIndex = 10;
            this.lblTurno.Text = "lblTurno";
            // 
            // pictureBoxBarcode
            // 
            this.pictureBoxBarcode.Location = new System.Drawing.Point(223, 837);
            this.pictureBoxBarcode.Name = "pictureBoxBarcode";
            this.pictureBoxBarcode.Size = new System.Drawing.Size(384, 147);
            this.pictureBoxBarcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBarcode.TabIndex = 8;
            this.pictureBoxBarcode.TabStop = false;
            // 
            // lblFechaVencimiento
            // 
            this.lblFechaVencimiento.AutoSize = true;
            this.lblFechaVencimiento.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaVencimiento.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaVencimiento.Location = new System.Drawing.Point(333, 702);
            this.lblFechaVencimiento.Name = "lblFechaVencimiento";
            this.lblFechaVencimiento.Size = new System.Drawing.Size(186, 22);
            this.lblFechaVencimiento.TabIndex = 6;
            this.lblFechaVencimiento.Text = "lblFechaVencimiento";
            // 
            // lblFechaEmision
            // 
            this.lblFechaEmision.AutoSize = true;
            this.lblFechaEmision.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaEmision.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaEmision.Location = new System.Drawing.Point(63, 702);
            this.lblFechaEmision.Name = "lblFechaEmision";
            this.lblFechaEmision.Size = new System.Drawing.Size(150, 22);
            this.lblFechaEmision.TabIndex = 5;
            this.lblFechaEmision.Text = "lblFechaEmision";
            // 
            // lblCodigoCarnet
            // 
            this.lblCodigoCarnet.AutoSize = true;
            this.lblCodigoCarnet.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoCarnet.ForeColor = System.Drawing.Color.Navy;
            this.lblCodigoCarnet.Location = new System.Drawing.Point(399, 287);
            this.lblCodigoCarnet.Name = "lblCodigoCarnet";
            this.lblCodigoCarnet.Size = new System.Drawing.Size(201, 29);
            this.lblCodigoCarnet.TabIndex = 4;
            this.lblCodigoCarnet.Text = "lblCodigoCarnet";
            // 
            // lblcurso
            // 
            this.lblcurso.AutoSize = true;
            this.lblcurso.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcurso.ForeColor = System.Drawing.Color.Navy;
            this.lblcurso.Location = new System.Drawing.Point(32, 476);
            this.lblcurso.Name = "lblcurso";
            this.lblcurso.Size = new System.Drawing.Size(63, 19);
            this.lblcurso.TabIndex = 3;
            this.lblcurso.Text = "label44";
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Font = new System.Drawing.Font("Arial", 14.25F);
            this.lblNombres.ForeColor = System.Drawing.Color.Navy;
            this.lblNombres.Location = new System.Drawing.Point(32, 373);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(107, 22);
            this.lblNombres.TabIndex = 1;
            this.lblNombres.Text = "lblNombres";
            // 
            // PictureBoxCarnet
            // 
            this.PictureBoxCarnet.Image = global::CaoaPresentacion.Properties.Resources.Carnet_Estudiantil4;
            this.PictureBoxCarnet.Location = new System.Drawing.Point(13, 16);
            this.PictureBoxCarnet.Name = "PictureBoxCarnet";
            this.PictureBoxCarnet.Size = new System.Drawing.Size(638, 1013);
            this.PictureBoxCarnet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBoxCarnet.TabIndex = 0;
            this.PictureBoxCarnet.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Image = global::CaoaPresentacion.Properties.Resources.geometric_gc4e25bd3d_1920;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1284, 52);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // Frm_CarnetEstudiantil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 881);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(1027, 595);
            this.Name = "Frm_CarnetEstudiantil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carnet Estudiantil";
            this.Load += new System.EventHandler(this.Frm_CarnetEstudiantil_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoCarnet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxCarnet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataListadoCarnet;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelSucursal;
        private System.Windows.Forms.Label labelHorario;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.PictureBox pictureBoxBarcode;
        private System.Windows.Forms.Label lblFechaVencimiento;
        private System.Windows.Forms.Label lblFechaEmision;
        private System.Windows.Forms.Label lblCodigoCarnet;
        private System.Windows.Forms.Label lblcurso;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.PictureBox PictureBoxCarnet;
        private System.Windows.Forms.Button button2;
    }
}