namespace CaoaPresentacion
{
    partial class Frm_NotasEstudiante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_NotasEstudiante));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabNotasEstudiante = new System.Windows.Forms.TabPage();
            this.dataNotasEstudiante = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.txtEstudiante = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TabBusquedaEstudiante = new System.Windows.Forms.TabPage();
            this.dataEstudiantes = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbusqueda = new System.Windows.Forms.TextBox();
            this.cmbBusquedas = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.notasPorEstudianteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.TabNotasEstudiante.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataNotasEstudiante)).BeginInit();
            this.TabBusquedaEstudiante.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataEstudiantes)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabNotasEstudiante);
            this.tabControl1.Controls.Add(this.TabBusquedaEstudiante);
            this.tabControl1.Location = new System.Drawing.Point(4, 44);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(916, 461);
            this.tabControl1.TabIndex = 0;
            // 
            // TabNotasEstudiante
            // 
            this.TabNotasEstudiante.Controls.Add(this.dataNotasEstudiante);
            this.TabNotasEstudiante.Controls.Add(this.button1);
            this.TabNotasEstudiante.Controls.Add(this.txtEstudiante);
            this.TabNotasEstudiante.Controls.Add(this.label1);
            this.TabNotasEstudiante.Location = new System.Drawing.Point(4, 22);
            this.TabNotasEstudiante.Name = "TabNotasEstudiante";
            this.TabNotasEstudiante.Padding = new System.Windows.Forms.Padding(3);
            this.TabNotasEstudiante.Size = new System.Drawing.Size(908, 435);
            this.TabNotasEstudiante.TabIndex = 0;
            this.TabNotasEstudiante.Text = "TabNotasEstudiante";
            this.TabNotasEstudiante.UseVisualStyleBackColor = true;
            // 
            // dataNotasEstudiante
            // 
            this.dataNotasEstudiante.AllowUserToAddRows = false;
            this.dataNotasEstudiante.AllowUserToDeleteRows = false;
            this.dataNotasEstudiante.AllowUserToOrderColumns = true;
            this.dataNotasEstudiante.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataNotasEstudiante.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataNotasEstudiante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataNotasEstudiante.Location = new System.Drawing.Point(21, 74);
            this.dataNotasEstudiante.Name = "dataNotasEstudiante";
            this.dataNotasEstudiante.ReadOnly = true;
            this.dataNotasEstudiante.Size = new System.Drawing.Size(869, 310);
            this.dataNotasEstudiante.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Image = global::CaoaPresentacion.Properties.Resources._1814075_find_magnifier_magnifying_glass_search_icon;
            this.button1.Location = new System.Drawing.Point(479, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 33);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtEstudiante
            // 
            this.txtEstudiante.Enabled = false;
            this.txtEstudiante.Font = new System.Drawing.Font("Arial", 12F);
            this.txtEstudiante.Location = new System.Drawing.Point(124, 31);
            this.txtEstudiante.Name = "txtEstudiante";
            this.txtEstudiante.Size = new System.Drawing.Size(351, 26);
            this.txtEstudiante.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estudiante";
            // 
            // TabBusquedaEstudiante
            // 
            this.TabBusquedaEstudiante.Controls.Add(this.dataEstudiantes);
            this.TabBusquedaEstudiante.Controls.Add(this.panel1);
            this.TabBusquedaEstudiante.Location = new System.Drawing.Point(4, 22);
            this.TabBusquedaEstudiante.Name = "TabBusquedaEstudiante";
            this.TabBusquedaEstudiante.Padding = new System.Windows.Forms.Padding(3);
            this.TabBusquedaEstudiante.Size = new System.Drawing.Size(908, 435);
            this.TabBusquedaEstudiante.TabIndex = 1;
            this.TabBusquedaEstudiante.Text = "TabBusquedaEstudiante";
            this.TabBusquedaEstudiante.UseVisualStyleBackColor = true;
            // 
            // dataEstudiantes
            // 
            this.dataEstudiantes.AllowUserToAddRows = false;
            this.dataEstudiantes.AllowUserToDeleteRows = false;
            this.dataEstudiantes.AllowUserToOrderColumns = true;
            this.dataEstudiantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEstudiantes.Location = new System.Drawing.Point(8, 69);
            this.dataEstudiantes.Name = "dataEstudiantes";
            this.dataEstudiantes.ReadOnly = true;
            this.dataEstudiantes.Size = new System.Drawing.Size(894, 360);
            this.dataEstudiantes.TabIndex = 17;
            this.dataEstudiantes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataEstudiantes_CellClick);
            this.dataEstudiantes.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataEstudiantes_CellPainting);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtbusqueda);
            this.panel1.Controls.Add(this.cmbBusquedas);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(896, 57);
            this.panel1.TabIndex = 16;
            // 
            // button3
            // 
            this.button3.Image = global::CaoaPresentacion.Properties.Resources._1814075_find_magnifier_magnifying_glass_search_icon;
            this.button3.Location = new System.Drawing.Point(518, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(49, 36);
            this.button3.TabIndex = 14;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton2);
            this.groupBox4.Controls.Add(this.radioButton1);
            this.groupBox4.Location = new System.Drawing.Point(690, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(186, 42);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(97, 14);
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
            this.radioButton1.Location = new System.Drawing.Point(17, 13);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(69, 22);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Activo";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Buscar";
            // 
            // txtbusqueda
            // 
            this.txtbusqueda.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbusqueda.Location = new System.Drawing.Point(72, 13);
            this.txtbusqueda.Name = "txtbusqueda";
            this.txtbusqueda.Size = new System.Drawing.Size(270, 26);
            this.txtbusqueda.TabIndex = 12;
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
            this.cmbBusquedas.Location = new System.Drawing.Point(348, 13);
            this.cmbBusquedas.Name = "cmbBusquedas";
            this.cmbBusquedas.Size = new System.Drawing.Size(164, 26);
            this.cmbBusquedas.TabIndex = 13;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notasPorEstudianteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(924, 26);
            this.menuStrip1.TabIndex = 10002;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // notasPorEstudianteToolStripMenuItem
            // 
            this.notasPorEstudianteToolStripMenuItem.Font = new System.Drawing.Font("Arial", 12F);
            this.notasPorEstudianteToolStripMenuItem.Image = global::CaoaPresentacion.Properties.Resources.test;
            this.notasPorEstudianteToolStripMenuItem.Name = "notasPorEstudianteToolStripMenuItem";
            this.notasPorEstudianteToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.notasPorEstudianteToolStripMenuItem.Text = "Notas por Estudiante";
            this.notasPorEstudianteToolStripMenuItem.Click += new System.EventHandler(this.notasPorEstudianteToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::CaoaPresentacion.Properties.Resources._4882066;
            this.pictureBox1.Location = new System.Drawing.Point(0, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(924, 40);
            this.pictureBox1.TabIndex = 10001;
            this.pictureBox1.TabStop = false;
            // 
            // Frm_NotasEstudiante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(924, 530);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(940, 569);
            this.MinimumSize = new System.Drawing.Size(940, 569);
            this.Name = "Frm_NotasEstudiante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notas";
            this.Load += new System.EventHandler(this.Frm_NotasEstudiante_Load);
            this.tabControl1.ResumeLayout(false);
            this.TabNotasEstudiante.ResumeLayout(false);
            this.TabNotasEstudiante.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataNotasEstudiante)).EndInit();
            this.TabBusquedaEstudiante.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataEstudiantes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabNotasEstudiante;
        private System.Windows.Forms.TabPage TabBusquedaEstudiante;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEstudiante;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataNotasEstudiante;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cmbBusquedas;
        private System.Windows.Forms.TextBox txtbusqueda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataEstudiantes;
        private System.Windows.Forms.ToolStripMenuItem notasPorEstudianteToolStripMenuItem;
    }
}