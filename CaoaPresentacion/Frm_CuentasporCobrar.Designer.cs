namespace CaoaPresentacion
{
    partial class Frm_CuentasporCobrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_CuentasporCobrar));
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TabBusqueda = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblEstudiantesSinAbono = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblEstudiantesConAbonos = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lbltotal = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbbusquedaAño = new System.Windows.Forms.ComboBox();
            this.cmbbusquedaMes = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.dataCartera = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabEstadisticas = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dataEstadisticasCartera = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.TabBusqueda.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataCartera)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.TabEstadisticas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataEstadisticasCartera)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(368, 63);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(191, 20);
            this.dateTimePicker2.TabIndex = 8;
            this.dateTimePicker2.Value = new System.DateTime(2022, 3, 8, 0, 0, 0, 0);
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Y";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(565, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 21);
            this.button1.TabIndex = 6;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(128, 64);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(191, 20);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.Value = new System.DateTime(2022, 3, 8, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Buscar Pagos entre";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::CaoaPresentacion.Properties.Resources._4882066;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1262, 31);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // TabBusqueda
            // 
            this.TabBusqueda.Controls.Add(this.groupBox1);
            this.TabBusqueda.Controls.Add(this.dataCartera);
            this.TabBusqueda.Location = new System.Drawing.Point(4, 22);
            this.TabBusqueda.Name = "TabBusqueda";
            this.TabBusqueda.Padding = new System.Windows.Forms.Padding(3);
            this.TabBusqueda.Size = new System.Drawing.Size(1250, 605);
            this.TabBusqueda.TabIndex = 0;
            this.TabBusqueda.Text = "TabBusqueda";
            this.TabBusqueda.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbbusquedaAño);
            this.groupBox1.Controls.Add(this.cmbbusquedaMes);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(8, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1238, 160);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Orange;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.lblEstudiantesSinAbono);
            this.panel3.Location = new System.Drawing.Point(600, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(125, 123);
            this.panel3.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(8, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 32);
            this.label7.TabIndex = 11;
            this.label7.Text = "Estudiantes sin \r\nAbonos";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEstudiantesSinAbono
            // 
            this.lblEstudiantesSinAbono.AutoSize = true;
            this.lblEstudiantesSinAbono.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstudiantesSinAbono.ForeColor = System.Drawing.Color.White;
            this.lblEstudiantesSinAbono.Location = new System.Drawing.Point(38, 62);
            this.lblEstudiantesSinAbono.Name = "lblEstudiantesSinAbono";
            this.lblEstudiantesSinAbono.Size = new System.Drawing.Size(45, 19);
            this.lblEstudiantesSinAbono.TabIndex = 12;
            this.lblEstudiantesSinAbono.Text = "label";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Green;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblEstudiantesConAbonos);
            this.panel2.Location = new System.Drawing.Point(471, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(125, 123);
            this.panel2.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(8, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 32);
            this.label6.TabIndex = 11;
            this.label6.Text = "Estudiantes con \r\nAbonos";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEstudiantesConAbonos
            // 
            this.lblEstudiantesConAbonos.AutoSize = true;
            this.lblEstudiantesConAbonos.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstudiantesConAbonos.ForeColor = System.Drawing.Color.White;
            this.lblEstudiantesConAbonos.Location = new System.Drawing.Point(38, 62);
            this.lblEstudiantesConAbonos.Name = "lblEstudiantesConAbonos";
            this.lblEstudiantesConAbonos.Size = new System.Drawing.Size(45, 19);
            this.lblEstudiantesConAbonos.TabIndex = 12;
            this.lblEstudiantesConAbonos.Text = "label";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lbltotal);
            this.panel1.Location = new System.Drawing.Point(343, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(125, 123);
            this.panel1.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(8, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Total de Registros";
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotal.ForeColor = System.Drawing.Color.White;
            this.lbltotal.Location = new System.Drawing.Point(38, 62);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(45, 19);
            this.lbltotal.TabIndex = 12;
            this.lbltotal.Text = "label";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Arial", 12F);
            this.button4.Image = global::CaoaPresentacion.Properties.Resources._118903_office_spreadsheet_x_office_spreadsheet;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(1093, 13);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(139, 42);
            this.button4.TabIndex = 10;
            this.button4.Text = "Estadisticas";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "Filtros de Busqueda";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial", 12F);
            this.button3.Image = global::CaoaPresentacion.Properties.Resources._1814075_find_magnifier_magnifying_glass_search_icon;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(103, 117);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 32);
            this.button3.TabIndex = 26;
            this.button3.Text = "Buscar";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Arial", 12F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Todos",
            "Regular",
            "Jueves",
            "Viernes",
            "Sabados",
            "Domingos"});
            this.comboBox1.Location = new System.Drawing.Point(52, 87);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(152, 26);
            this.comboBox1.TabIndex = 25;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(4, 94);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(46, 18);
            this.label22.TabIndex = 24;
            this.label22.Text = "Turno";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 18);
            this.label11.TabIndex = 23;
            this.label11.Text = "Año";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 18);
            this.label9.TabIndex = 17;
            this.label9.Text = "mes";
            // 
            // cmbbusquedaAño
            // 
            this.cmbbusquedaAño.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbbusquedaAño.FormattingEnabled = true;
            this.cmbbusquedaAño.Location = new System.Drawing.Point(52, 57);
            this.cmbbusquedaAño.Name = "cmbbusquedaAño";
            this.cmbbusquedaAño.Size = new System.Drawing.Size(152, 26);
            this.cmbbusquedaAño.TabIndex = 16;
            // 
            // cmbbusquedaMes
            // 
            this.cmbbusquedaMes.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbbusquedaMes.FormattingEnabled = true;
            this.cmbbusquedaMes.Location = new System.Drawing.Point(52, 29);
            this.cmbbusquedaMes.Name = "cmbbusquedaMes";
            this.cmbbusquedaMes.Size = new System.Drawing.Size(152, 26);
            this.cmbbusquedaMes.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(210, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(125, 130);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Arial", 12F);
            this.radioButton2.Location = new System.Drawing.Point(10, 55);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(102, 22);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Insolventes";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(10, 25);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(94, 22);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Solventes";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // dataCartera
            // 
            this.dataCartera.AllowUserToAddRows = false;
            this.dataCartera.AllowUserToDeleteRows = false;
            this.dataCartera.AllowUserToOrderColumns = true;
            this.dataCartera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataCartera.Location = new System.Drawing.Point(7, 164);
            this.dataCartera.Name = "dataCartera";
            this.dataCartera.ReadOnly = true;
            this.dataCartera.Size = new System.Drawing.Size(1237, 422);
            this.dataCartera.TabIndex = 0;
            this.dataCartera.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataCartera_CellClick);
            this.dataCartera.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataCartera_CellPainting);
            this.dataCartera.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataCartera_RowPrePaint);
            this.dataCartera.Paint += new System.Windows.Forms.PaintEventHandler(this.dataCartera_Paint);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabBusqueda);
            this.tabControl1.Controls.Add(this.TabEstadisticas);
            this.tabControl1.Location = new System.Drawing.Point(4, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1258, 631);
            this.tabControl1.TabIndex = 6;
            // 
            // TabEstadisticas
            // 
            this.TabEstadisticas.Controls.Add(this.button5);
            this.TabEstadisticas.Controls.Add(this.label5);
            this.TabEstadisticas.Controls.Add(this.dataEstadisticasCartera);
            this.TabEstadisticas.Location = new System.Drawing.Point(4, 22);
            this.TabEstadisticas.Name = "TabEstadisticas";
            this.TabEstadisticas.Padding = new System.Windows.Forms.Padding(3);
            this.TabEstadisticas.Size = new System.Drawing.Size(1250, 605);
            this.TabEstadisticas.TabIndex = 1;
            this.TabEstadisticas.Text = "TabEstadisticas";
            this.TabEstadisticas.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Arial", 12F);
            this.button5.Image = global::CaoaPresentacion.Properties.Resources._134213_home_house_building_main_icon;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(512, 11);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(139, 42);
            this.button5.TabIndex = 19;
            this.button5.Text = "Menu";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "Estadisticas";
            // 
            // dataEstadisticasCartera
            // 
            this.dataEstadisticasCartera.AllowUserToAddRows = false;
            this.dataEstadisticasCartera.AllowUserToDeleteRows = false;
            this.dataEstadisticasCartera.AllowUserToOrderColumns = true;
            this.dataEstadisticasCartera.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataEstadisticasCartera.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataEstadisticasCartera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEstadisticasCartera.Location = new System.Drawing.Point(15, 58);
            this.dataEstadisticasCartera.Name = "dataEstadisticasCartera";
            this.dataEstadisticasCartera.ReadOnly = true;
            this.dataEstadisticasCartera.Size = new System.Drawing.Size(635, 328);
            this.dataEstadisticasCartera.TabIndex = 0;
            // 
            // Frm_CuentasporCobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 650);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1278, 689);
            this.MinimumSize = new System.Drawing.Size(1278, 689);
            this.Name = "Frm_CuentasporCobrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Cobranza";
            this.Load += new System.EventHandler(this.Frm_CuentasporCobrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.TabBusqueda.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataCartera)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.TabEstadisticas.ResumeLayout(false);
            this.TabEstadisticas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataEstadisticasCartera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage TabBusqueda;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbbusquedaAño;
        private System.Windows.Forms.ComboBox cmbbusquedaMes;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.DataGridView dataCartera;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabPage TabEstadisticas;
        private System.Windows.Forms.DataGridView dataEstadisticasCartera;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblEstudiantesConAbonos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblEstudiantesSinAbono;
    }
}