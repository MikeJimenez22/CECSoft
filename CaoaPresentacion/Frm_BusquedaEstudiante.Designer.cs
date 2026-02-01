namespace CaoaPresentacion
{
    partial class Frm_BusquedaEstudiante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_BusquedaEstudiante));
            this.label1 = new System.Windows.Forms.Label();
            this.dataestudiantes = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtbuscar = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataestudiantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Busqueda";
            // 
            // dataestudiantes
            // 
            this.dataestudiantes.AllowUserToAddRows = false;
            this.dataestudiantes.AllowUserToDeleteRows = false;
            this.dataestudiantes.AllowUserToOrderColumns = true;
            this.dataestudiantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataestudiantes.Location = new System.Drawing.Point(8, 105);
            this.dataestudiantes.Name = "dataestudiantes";
            this.dataestudiantes.ReadOnly = true;
            this.dataestudiantes.Size = new System.Drawing.Size(684, 212);
            this.dataestudiantes.TabIndex = 6;
            this.dataestudiantes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataestudiantes_CellClick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Cedula",
            "Apellidos"});
            this.comboBox1.Location = new System.Drawing.Point(86, 80);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(139, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // txtbuscar
            // 
            this.txtbuscar.Location = new System.Drawing.Point(231, 80);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.Size = new System.Drawing.Size(311, 20);
            this.txtbuscar.TabIndex = 8;
            this.txtbuscar.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::CaoaPresentacion.Properties.Resources._4882066;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(696, 58);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Frm_BusquedaEstudiante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 319);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtbuscar);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataestudiantes);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(712, 358);
            this.MinimumSize = new System.Drawing.Size(712, 358);
            this.Name = "Frm_BusquedaEstudiante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: BUSCAR ESTUDIANTE :.";
            this.Load += new System.EventHandler(this.Frm_BusquedaEstudiante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataestudiantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataestudiantes;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtbuscar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}