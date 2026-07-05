namespace CaoaPresentacion
{
    partial class Frm_HistorialGestiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_HistorialGestiones));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabHistorial = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBuscarPorCedula = new System.Windows.Forms.Button();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBusqueda = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGestiones = new System.Windows.Forms.DataGridView();
            this.tabGestionesparaHoy = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGestionesProgramadas = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.historialDeGestionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionesHoyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGestiones)).BeginInit();
            this.tabGestionesparaHoy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGestionesProgramadas)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabHistorial);
            this.tabControl1.Controls.Add(this.tabGestionesparaHoy);
            this.tabControl1.Location = new System.Drawing.Point(3, 17);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1224, 583);
            this.tabControl1.TabIndex = 0;
            // 
            // tabHistorial
            // 
            this.tabHistorial.BackColor = System.Drawing.Color.Gainsboro;
            this.tabHistorial.Controls.Add(this.label5);
            this.tabHistorial.Controls.Add(this.btnBuscarPorCedula);
            this.tabHistorial.Controls.Add(this.dtpFechaFinal);
            this.tabHistorial.Controls.Add(this.label3);
            this.tabHistorial.Controls.Add(this.dtpFechaInicial);
            this.tabHistorial.Controls.Add(this.label2);
            this.tabHistorial.Controls.Add(this.cbBusqueda);
            this.tabHistorial.Controls.Add(this.label1);
            this.tabHistorial.Controls.Add(this.dataGestiones);
            this.tabHistorial.Location = new System.Drawing.Point(4, 22);
            this.tabHistorial.Name = "tabHistorial";
            this.tabHistorial.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistorial.Size = new System.Drawing.Size(1216, 557);
            this.tabHistorial.TabIndex = 0;
            this.tabHistorial.Text = "tabPage1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 527);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 18);
            this.label5.TabIndex = 10002;
            this.label5.Text = "label5";
            // 
            // btnBuscarPorCedula
            // 
            this.btnBuscarPorCedula.Font = new System.Drawing.Font("Arial", 12F);
            this.btnBuscarPorCedula.Image = global::CaoaPresentacion.Properties.Resources._1814075_find_magnifier_magnifying_glass_search_icon;
            this.btnBuscarPorCedula.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarPorCedula.Location = new System.Drawing.Point(907, 27);
            this.btnBuscarPorCedula.Name = "btnBuscarPorCedula";
            this.btnBuscarPorCedula.Size = new System.Drawing.Size(43, 36);
            this.btnBuscarPorCedula.TabIndex = 10001;
            this.btnBuscarPorCedula.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarPorCedula.UseVisualStyleBackColor = true;
            this.btnBuscarPorCedula.Click += new System.EventHandler(this.btnBuscarPorCedula_Click);
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(725, 33);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(176, 26);
            this.dtpFechaFinal.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(624, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha Inicial";
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicial.Location = new System.Drawing.Point(441, 32);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(176, 26);
            this.dtpFechaInicial.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(340, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha Inicial";
            // 
            // cbBusqueda
            // 
            this.cbBusqueda.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBusqueda.FormattingEnabled = true;
            this.cbBusqueda.Items.AddRange(new object[] {
            "HOY",
            "POR RANGO"});
            this.cbBusqueda.Location = new System.Drawing.Point(115, 31);
            this.cbBusqueda.Name = "cbBusqueda";
            this.cbBusqueda.Size = new System.Drawing.Size(217, 26);
            this.cbBusqueda.TabIndex = 2;
            this.cbBusqueda.SelectedIndexChanged += new System.EventHandler(this.cbBusqueda_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Buscar por";
            // 
            // dataGestiones
            // 
            this.dataGestiones.AllowUserToAddRows = false;
            this.dataGestiones.AllowUserToDeleteRows = false;
            this.dataGestiones.AllowUserToOrderColumns = true;
            this.dataGestiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGestiones.Location = new System.Drawing.Point(6, 69);
            this.dataGestiones.Name = "dataGestiones";
            this.dataGestiones.ReadOnly = true;
            this.dataGestiones.Size = new System.Drawing.Size(1202, 448);
            this.dataGestiones.TabIndex = 0;
            // 
            // tabGestionesparaHoy
            // 
            this.tabGestionesparaHoy.BackColor = System.Drawing.Color.Gainsboro;
            this.tabGestionesparaHoy.Controls.Add(this.label6);
            this.tabGestionesparaHoy.Controls.Add(this.label4);
            this.tabGestionesparaHoy.Controls.Add(this.dataGestionesProgramadas);
            this.tabGestionesparaHoy.Location = new System.Drawing.Point(4, 22);
            this.tabGestionesparaHoy.Name = "tabGestionesparaHoy";
            this.tabGestionesparaHoy.Padding = new System.Windows.Forms.Padding(3);
            this.tabGestionesparaHoy.Size = new System.Drawing.Size(1216, 557);
            this.tabGestionesparaHoy.TabIndex = 1;
            this.tabGestionesparaHoy.Text = "tabPage2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 528);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 18);
            this.label6.TabIndex = 10003;
            this.label6.Text = "label6";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(266, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Gestiones Programadas para Hoy";
            // 
            // dataGestionesProgramadas
            // 
            this.dataGestionesProgramadas.AllowUserToAddRows = false;
            this.dataGestionesProgramadas.AllowUserToDeleteRows = false;
            this.dataGestionesProgramadas.AllowUserToOrderColumns = true;
            this.dataGestionesProgramadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGestionesProgramadas.Location = new System.Drawing.Point(7, 58);
            this.dataGestionesProgramadas.Name = "dataGestionesProgramadas";
            this.dataGestionesProgramadas.ReadOnly = true;
            this.dataGestionesProgramadas.Size = new System.Drawing.Size(1202, 467);
            this.dataGestionesProgramadas.TabIndex = 1;
            this.dataGestionesProgramadas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGestionesProgramadas_CellClick);
            this.dataGestionesProgramadas.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGestionesProgramadas_CellPainting);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historialDeGestionesToolStripMenuItem,
            this.gestionesHoyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1230, 39);
            this.menuStrip1.TabIndex = 10002;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // historialDeGestionesToolStripMenuItem
            // 
            this.historialDeGestionesToolStripMenuItem.ForeColor = System.Drawing.Color.SteelBlue;
            this.historialDeGestionesToolStripMenuItem.Name = "historialDeGestionesToolStripMenuItem";
            this.historialDeGestionesToolStripMenuItem.Size = new System.Drawing.Size(174, 35);
            this.historialDeGestionesToolStripMenuItem.Text = "Historial de Gestiones";
            this.historialDeGestionesToolStripMenuItem.Click += new System.EventHandler(this.historialDeGestionesToolStripMenuItem_Click);
            // 
            // gestionesHoyToolStripMenuItem
            // 
            this.gestionesHoyToolStripMenuItem.ForeColor = System.Drawing.Color.SteelBlue;
            this.gestionesHoyToolStripMenuItem.Name = "gestionesHoyToolStripMenuItem";
            this.gestionesHoyToolStripMenuItem.Size = new System.Drawing.Size(144, 35);
            this.gestionesHoyToolStripMenuItem.Text = "Gestiones de Hoy";
            this.gestionesHoyToolStripMenuItem.Click += new System.EventHandler(this.gestionesHoyToolStripMenuItem_Click);
            // 
            // Frm_HistorialGestiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1230, 603);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1246, 642);
            this.MinimumSize = new System.Drawing.Size(1246, 642);
            this.Name = "Frm_HistorialGestiones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestiones de cobros";
            this.Load += new System.EventHandler(this.Frm_HistorialGestiones_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabHistorial.ResumeLayout(false);
            this.tabHistorial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGestiones)).EndInit();
            this.tabGestionesparaHoy.ResumeLayout(false);
            this.tabGestionesparaHoy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGestionesProgramadas)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabHistorial;
        private System.Windows.Forms.TabPage tabGestionesparaHoy;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem historialDeGestionesToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGestiones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBusqueda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscarPorCedula;
        private System.Windows.Forms.ToolStripMenuItem gestionesHoyToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGestionesProgramadas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}