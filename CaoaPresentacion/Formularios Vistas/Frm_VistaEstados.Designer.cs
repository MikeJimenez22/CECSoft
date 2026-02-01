namespace CaoaPresentacion.Formularios_Vistas
{
    partial class Frm_VistaEstados
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
            this.dataestados = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataestados)).BeginInit();
            this.SuspendLayout();
            // 
            // dataestados
            // 
            this.dataestados.AllowUserToAddRows = false;
            this.dataestados.AllowUserToDeleteRows = false;
            this.dataestados.AllowUserToOrderColumns = true;
            this.dataestados.BackgroundColor = System.Drawing.Color.White;
            this.dataestados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataestados.Location = new System.Drawing.Point(9, 12);
            this.dataestados.Name = "dataestados";
            this.dataestados.ReadOnly = true;
            this.dataestados.Size = new System.Drawing.Size(566, 263);
            this.dataestados.TabIndex = 0;
            this.dataestados.Click += new System.EventHandler(this.dataestados_Click);
            // 
            // Frm_VistaEstados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(587, 287);
            this.Controls.Add(this.dataestados);
            this.MaximumSize = new System.Drawing.Size(603, 326);
            this.MinimumSize = new System.Drawing.Size(603, 326);
            this.Name = "Frm_VistaEstados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: ESTADOS  DE SISTEMA :.";
            this.Load += new System.EventHandler(this.Frm_VistaEstados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataestados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataestados;
    }
}