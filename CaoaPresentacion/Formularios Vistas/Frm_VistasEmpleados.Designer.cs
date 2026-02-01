namespace CaoaPresentacion.Formularios_Vistas
{
    partial class Frm_VistasEmpleados
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
            this.dataEmpleados = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataEmpleados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataEmpleados
            // 
            this.dataEmpleados.AllowUserToAddRows = false;
            this.dataEmpleados.AllowUserToDeleteRows = false;
            this.dataEmpleados.AllowUserToOrderColumns = true;
            this.dataEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEmpleados.Location = new System.Drawing.Point(15, 84);
            this.dataEmpleados.Name = "dataEmpleados";
            this.dataEmpleados.ReadOnly = true;
            this.dataEmpleados.Size = new System.Drawing.Size(854, 286);
            this.dataEmpleados.TabIndex = 0;
            this.dataEmpleados.Click += new System.EventHandler(this.dataEmpleados_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::CaoaPresentacion.Properties.Resources._4882066;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(888, 50);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Frm_VistasEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 386);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataEmpleados);
            this.MaximumSize = new System.Drawing.Size(904, 425);
            this.MinimumSize = new System.Drawing.Size(904, 425);
            this.Name = "Frm_VistasEmpleados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: LISTA DE EMPLEADOS :.";
            this.Load += new System.EventHandler(this.Frm_VistasEmpleados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataEmpleados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataEmpleados;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}