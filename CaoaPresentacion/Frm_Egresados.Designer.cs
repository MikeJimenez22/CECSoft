namespace CaoaPresentacion
{
    partial class Frm_Egresados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Egresados));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabEgresados = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataEgresados = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabEgresados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataEgresados)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabEgresados);
            this.tabControl1.Location = new System.Drawing.Point(8, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(997, 530);
            this.tabControl1.TabIndex = 0;
            // 
            // tabEgresados
            // 
            this.tabEgresados.BackColor = System.Drawing.Color.AliceBlue;
            this.tabEgresados.Controls.Add(this.label3);
            this.tabEgresados.Controls.Add(this.dataEgresados);
            this.tabEgresados.Controls.Add(this.button1);
            this.tabEgresados.Controls.Add(this.dpFechaFinal);
            this.tabEgresados.Controls.Add(this.label2);
            this.tabEgresados.Controls.Add(this.dpFechaInicio);
            this.tabEgresados.Controls.Add(this.label1);
            this.tabEgresados.Location = new System.Drawing.Point(4, 22);
            this.tabEgresados.Name = "tabEgresados";
            this.tabEgresados.Padding = new System.Windows.Forms.Padding(3);
            this.tabEgresados.Size = new System.Drawing.Size(989, 504);
            this.tabEgresados.TabIndex = 0;
            this.tabEgresados.Text = "tabEgresados";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::CaoaPresentacion.Properties.Resources._4882066;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1007, 23);
            this.pictureBox1.TabIndex = 10001;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha del";
            // 
            // dpFechaInicio
            // 
            this.dpFechaInicio.Font = new System.Drawing.Font("Arial", 12F);
            this.dpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaInicio.Location = new System.Drawing.Point(114, 23);
            this.dpFechaInicio.Name = "dpFechaInicio";
            this.dpFechaInicio.Size = new System.Drawing.Size(200, 26);
            this.dpFechaInicio.TabIndex = 4;
            this.dpFechaInicio.Value = new System.DateTime(2023, 1, 31, 0, 0, 0, 0);
            // 
            // dpFechaFinal
            // 
            this.dpFechaFinal.Font = new System.Drawing.Font("Arial", 12F);
            this.dpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaFinal.Location = new System.Drawing.Point(348, 23);
            this.dpFechaFinal.Name = "dpFechaFinal";
            this.dpFechaFinal.Size = new System.Drawing.Size(200, 26);
            this.dpFechaFinal.TabIndex = 7;
            this.dpFechaFinal.Value = new System.DateTime(2023, 1, 31, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.Location = new System.Drawing.Point(322, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "al";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 12F);
            this.button1.Image = global::CaoaPresentacion.Properties.Resources._1814075_find_magnifier_magnifying_glass_search_icon;
            this.button1.Location = new System.Drawing.Point(554, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 34);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataEgresados
            // 
            this.dataEgresados.AllowUserToAddRows = false;
            this.dataEgresados.AllowUserToDeleteRows = false;
            this.dataEgresados.AllowUserToOrderColumns = true;
            this.dataEgresados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEgresados.Location = new System.Drawing.Point(9, 71);
            this.dataEgresados.Name = "dataEgresados";
            this.dataEgresados.ReadOnly = true;
            this.dataEgresados.Size = new System.Drawing.Size(974, 381);
            this.dataEgresados.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 470);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "label3";
            // 
            // Frm_Egresados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1007, 540);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1023, 579);
            this.MinimumSize = new System.Drawing.Size(1023, 579);
            this.Name = "Frm_Egresados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Egresados";
            this.Load += new System.EventHandler(this.Frm_Egresados_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabEgresados.ResumeLayout(false);
            this.tabEgresados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataEgresados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabEgresados;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpFechaInicio;
        private System.Windows.Forms.DateTimePicker dpFechaFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataEgresados;
        private System.Windows.Forms.Label label3;
    }
}