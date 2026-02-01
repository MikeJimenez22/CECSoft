namespace CaoaPresentacion
{
    partial class Frm_Docente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Docente));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.txtCodigoActa = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataEstudiantes = new System.Windows.Forms.DataGridView();
            this.txtNombreModulo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.cmbEstados = new System.Windows.Forms.ComboBox();
            this.cmbGrupos = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.dataModulosCurso = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dataMatriculas = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button7 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbBusquedas = new System.Windows.Forms.ComboBox();
            this.txtbusqueda = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataEstudiantes)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataModulosCurso)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataMatriculas)).BeginInit();
            this.panel5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 881);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(6, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Registro de Notas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(217, 14);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1064, 1013);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1056, 987);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "inicio";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1056, 987);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "notas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button5);
            this.panel4.Controls.Add(this.lblMensaje);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.txtObservaciones);
            this.panel4.Controls.Add(this.txtCodigoActa);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.dataEstudiantes);
            this.panel4.Controls.Add(this.txtNombreModulo);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(18, 121);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1022, 687);
            this.panel4.TabIndex = 8;
            // 
            // button5
            // 
            this.button5.Image = global::CaoaPresentacion.Properties.Resources._1814075_find_magnifier_magnifying_glass_search_icon;
            this.button5.Location = new System.Drawing.Point(656, 10);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(33, 32);
            this.button5.TabIndex = 20;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Location = new System.Drawing.Point(162, 43);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(211, 18);
            this.lblMensaje.TabIndex = 19;
            this.lblMensaje.Text = "(*) Este campo es obligatorio";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Gainsboro;
            this.panel7.Controls.Add(this.button4);
            this.panel7.Location = new System.Drawing.Point(761, 560);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(251, 107);
            this.panel7.TabIndex = 17;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button4.Image = global::CaoaPresentacion.Properties.Resources._285657_floppy_guardar_save_icon;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(15, 7);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(222, 44);
            this.button4.TabIndex = 15;
            this.button4.Text = "Guardar";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::CaoaPresentacion.Properties.Resources._118805_accessories_text_editor_editor_accessories_text;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(828, 42);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(184, 34);
            this.button3.TabIndex = 14;
            this.button3.Text = "Agregar Estudiante";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(21, 539);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 18);
            this.label8.TabIndex = 13;
            this.label8.Text = "Observaciones";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(18, 560);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(737, 107);
            this.txtObservaciones.TabIndex = 12;
            // 
            // txtCodigoActa
            // 
            this.txtCodigoActa.Enabled = false;
            this.txtCodigoActa.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoActa.Location = new System.Drawing.Point(828, 10);
            this.txtCodigoActa.Name = "txtCodigoActa";
            this.txtCodigoActa.Size = new System.Drawing.Size(184, 26);
            this.txtCodigoActa.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(782, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 18);
            this.label7.TabIndex = 9;
            this.label7.Text = "Acta";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataEstudiantes
            // 
            this.dataEstudiantes.AllowUserToAddRows = false;
            this.dataEstudiantes.AllowUserToDeleteRows = false;
            this.dataEstudiantes.AllowUserToOrderColumns = true;
            this.dataEstudiantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataEstudiantes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataEstudiantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEstudiantes.Location = new System.Drawing.Point(18, 82);
            this.dataEstudiantes.Name = "dataEstudiantes";
            this.dataEstudiantes.ReadOnly = true;
            this.dataEstudiantes.Size = new System.Drawing.Size(990, 421);
            this.dataEstudiantes.TabIndex = 8;
            this.dataEstudiantes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataEstudiantes_CellContentClick);
            this.dataEstudiantes.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataEstudiantes_CellEndEdit);
            // 
            // txtNombreModulo
            // 
            this.txtNombreModulo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreModulo.Location = new System.Drawing.Point(162, 13);
            this.txtNombreModulo.Name = "txtNombreModulo";
            this.txtNombreModulo.Size = new System.Drawing.Size(488, 26);
            this.txtNombreModulo.TabIndex = 7;
            this.txtNombreModulo.TextChanged += new System.EventHandler(this.txtNombreModulo_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "Nombre de Modulo";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.cmbEstados);
            this.panel3.Controls.Add(this.cmbGrupos);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(18, 36);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1022, 80);
            this.panel3.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Image = global::CaoaPresentacion.Properties.Resources._1814075_find_magnifier_magnifying_glass_search_icon;
            this.button2.Location = new System.Drawing.Point(964, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(44, 44);
            this.button2.TabIndex = 8;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmbEstados
            // 
            this.cmbEstados.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstados.FormattingEnabled = true;
            this.cmbEstados.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbEstados.Location = new System.Drawing.Point(90, 27);
            this.cmbEstados.Name = "cmbEstados";
            this.cmbEstados.Size = new System.Drawing.Size(195, 26);
            this.cmbEstados.TabIndex = 6;
            this.cmbEstados.SelectedIndexChanged += new System.EventHandler(this.cmbEstados_SelectedIndexChanged);
            // 
            // cmbGrupos
            // 
            this.cmbGrupos.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGrupos.FormattingEnabled = true;
            this.cmbGrupos.Location = new System.Drawing.Point(361, 27);
            this.cmbGrupos.Name = "cmbGrupos";
            this.cmbGrupos.Size = new System.Drawing.Size(597, 26);
            this.cmbGrupos.TabIndex = 1;
            this.cmbGrupos.SelectedIndexChanged += new System.EventHandler(this.cmbGrupos_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "Estado";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(291, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Grupos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registro de Notas";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button6);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.dataModulosCurso);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1056, 987);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ModulosCurso";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Image = global::CaoaPresentacion.Properties.Resources._60181_back_go_icon;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(476, 32);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(128, 36);
            this.button6.TabIndex = 7;
            this.button6.Text = "Regresar";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(30, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 18);
            this.label9.TabIndex = 6;
            this.label9.Text = "Modulos de curso";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataModulosCurso
            // 
            this.dataModulosCurso.AllowUserToAddRows = false;
            this.dataModulosCurso.AllowUserToDeleteRows = false;
            this.dataModulosCurso.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataModulosCurso.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataModulosCurso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataModulosCurso.Location = new System.Drawing.Point(20, 74);
            this.dataModulosCurso.Name = "dataModulosCurso";
            this.dataModulosCurso.ReadOnly = true;
            this.dataModulosCurso.Size = new System.Drawing.Size(584, 344);
            this.dataModulosCurso.TabIndex = 0;
            this.dataModulosCurso.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataModulosCurso_CellClick);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dataMatriculas);
            this.tabPage4.Controls.Add(this.panel5);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1056, 987);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Estudiantes";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataMatriculas
            // 
            this.dataMatriculas.AllowUserToAddRows = false;
            this.dataMatriculas.AllowUserToDeleteRows = false;
            this.dataMatriculas.AllowUserToOrderColumns = true;
            this.dataMatriculas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataMatriculas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataMatriculas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataMatriculas.Location = new System.Drawing.Point(12, 105);
            this.dataMatriculas.Name = "dataMatriculas";
            this.dataMatriculas.ReadOnly = true;
            this.dataMatriculas.Size = new System.Drawing.Size(1038, 461);
            this.dataMatriculas.TabIndex = 20;
            this.dataMatriculas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataMatriculas_CellClick);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.Controls.Add(this.groupBox4);
            this.panel5.Controls.Add(this.button7);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.cmbBusquedas);
            this.panel5.Controls.Add(this.txtbusqueda);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Location = new System.Drawing.Point(12, 17);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1038, 82);
            this.panel5.TabIndex = 19;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton2);
            this.groupBox4.Controls.Add(this.radioButton1);
            this.groupBox4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(688, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(186, 58);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Estados";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(102, 25);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(78, 22);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Inactivo";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged_1);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(23, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(69, 22);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Activo";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(551, 27);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(129, 36);
            this.button7.TabIndex = 21;
            this.button7.Text = "Buscar";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(366, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(155, 18);
            this.label10.TabIndex = 20;
            this.label10.Text = "Opcion de Busqueda";
            // 
            // cmbBusquedas
            // 
            this.cmbBusquedas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBusquedas.FormattingEnabled = true;
            this.cmbBusquedas.Items.AddRange(new object[] {
            "Apellidos",
            "Nombres",
            "Carnet",
            "Codigo Matricula"});
            this.cmbBusquedas.Location = new System.Drawing.Point(354, 37);
            this.cmbBusquedas.Name = "cmbBusquedas";
            this.cmbBusquedas.Size = new System.Drawing.Size(190, 26);
            this.cmbBusquedas.TabIndex = 19;
            // 
            // txtbusqueda
            // 
            this.txtbusqueda.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbusqueda.Location = new System.Drawing.Point(79, 37);
            this.txtbusqueda.Name = "txtbusqueda";
            this.txtbusqueda.Size = new System.Drawing.Size(270, 26);
            this.txtbusqueda.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(16, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 18);
            this.label11.TabIndex = 17;
            this.label11.Text = "Buscar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(121, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(212, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1072, 36);
            this.panel2.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(13, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Bienvenido | ";
            // 
            // Frm_Docente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 881);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1300, 1044);
            this.MinimumSize = new System.Drawing.Size(1278, 726);
            this.Name = "Frm_Docente";
            this.Text = "Portal Docente";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Docente_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataEstudiantes)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataModulosCurso)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataMatriculas)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbGrupos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbEstados;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtNombreModulo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodigoActa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataEstudiantes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataModulosCurso;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataMatriculas;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbBusquedas;
        private System.Windows.Forms.TextBox txtbusqueda;
        private System.Windows.Forms.Label label11;
    }
}