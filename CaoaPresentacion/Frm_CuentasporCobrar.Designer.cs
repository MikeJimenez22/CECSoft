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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TabBusqueda = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblEstudiantesSinAbono = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblEstudiantesConAbonos = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lbltotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbbusquedaAño = new System.Windows.Forms.ComboBox();
            this.cmbbusquedaMes = new System.Windows.Forms.ComboBox();
            this.dataCartera = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.TabBusqueda.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataCartera)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
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
            this.TabBusqueda.Size = new System.Drawing.Size(1250, 590);
            this.TabBusqueda.TabIndex = 0;
            this.TabBusqueda.Text = "TabBusqueda";
            this.TabBusqueda.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbEstado);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbbusquedaAño);
            this.groupBox1.Controls.Add(this.cmbbusquedaMes);
            this.groupBox1.Location = new System.Drawing.Point(8, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1234, 194);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // cbEstado
            // 
            this.cbEstado.Font = new System.Drawing.Font("Arial", 12F);
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Items.AddRange(new object[] {
            "Completado",
            "Pendiente"});
            this.cbEstado.Location = new System.Drawing.Point(72, 119);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(187, 26);
            this.cbEstado.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 18);
            this.label8.TabIndex = 31;
            this.label8.Text = "Estado";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Orange;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.lblEstudiantesSinAbono);
            this.panel3.Location = new System.Drawing.Point(524, 29);
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
            this.panel2.Location = new System.Drawing.Point(395, 29);
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
            this.panel1.Location = new System.Drawing.Point(267, 29);
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
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Arial", 12F);
            this.btnBuscar.Image = global::CaoaPresentacion.Properties.Resources._1814075_find_magnifier_magnifying_glass_search_icon;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(158, 151);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(101, 32);
            this.btnBuscar.TabIndex = 26;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
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
            this.comboBox1.Location = new System.Drawing.Point(72, 87);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(187, 26);
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
            this.cmbbusquedaAño.Location = new System.Drawing.Point(72, 57);
            this.cmbbusquedaAño.Name = "cmbbusquedaAño";
            this.cmbbusquedaAño.Size = new System.Drawing.Size(187, 26);
            this.cmbbusquedaAño.TabIndex = 16;
            // 
            // cmbbusquedaMes
            // 
            this.cmbbusquedaMes.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbbusquedaMes.FormattingEnabled = true;
            this.cmbbusquedaMes.Location = new System.Drawing.Point(72, 29);
            this.cmbbusquedaMes.Name = "cmbbusquedaMes";
            this.cmbbusquedaMes.Size = new System.Drawing.Size(187, 26);
            this.cmbbusquedaMes.TabIndex = 15;
            // 
            // dataCartera
            // 
            this.dataCartera.AllowUserToAddRows = false;
            this.dataCartera.AllowUserToDeleteRows = false;
            this.dataCartera.AllowUserToOrderColumns = true;
            this.dataCartera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataCartera.Location = new System.Drawing.Point(7, 199);
            this.dataCartera.Name = "dataCartera";
            this.dataCartera.ReadOnly = true;
            this.dataCartera.Size = new System.Drawing.Size(1237, 387);
            this.dataCartera.TabIndex = 0;
            this.dataCartera.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataCartera_CellClick);
            this.dataCartera.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataCartera_CellPainting);
            this.dataCartera.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataCartera_RowPrePaint);
            this.dataCartera.Paint += new System.Windows.Forms.PaintEventHandler(this.dataCartera_Paint);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabBusqueda);
            this.tabControl1.Location = new System.Drawing.Point(4, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1258, 616);
            this.tabControl1.TabIndex = 6;
            // 
            // Frm_CuentasporCobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 650);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataCartera)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage TabBusqueda;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbbusquedaAño;
        private System.Windows.Forms.ComboBox cmbbusquedaMes;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataCartera;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblEstudiantesConAbonos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblEstudiantesSinAbono;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Label label8;
    }
}