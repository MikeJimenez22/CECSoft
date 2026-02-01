namespace CaoaPresentacion.Formularios_Vistas
{
    partial class Frm_VistaPadreTutor
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
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dataPadreTutor = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataPadreTutor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(18, 54);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(55, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Buscar";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(91, 53);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(634, 20);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // dataPadreTutor
            // 
            this.dataPadreTutor.AllowUserToAddRows = false;
            this.dataPadreTutor.AllowUserToDeleteRows = false;
            this.dataPadreTutor.AllowUserToOrderColumns = true;
            this.dataPadreTutor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPadreTutor.Location = new System.Drawing.Point(7, 79);
            this.dataPadreTutor.Name = "dataPadreTutor";
            this.dataPadreTutor.ReadOnly = true;
            this.dataPadreTutor.Size = new System.Drawing.Size(718, 247);
            this.dataPadreTutor.TabIndex = 2;
            this.dataPadreTutor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataPadreTutor_CellClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::CaoaPresentacion.Properties.Resources._4882066;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(731, 41);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Frm_VistaPadreTutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(731, 358);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataPadreTutor);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.materialLabel1);
            this.MaximumSize = new System.Drawing.Size(747, 397);
            this.MinimumSize = new System.Drawing.Size(747, 397);
            this.Name = "Frm_VistaPadreTutor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: TUTORES :.";
            this.Load += new System.EventHandler(this.Frm_VistaPadreTutor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataPadreTutor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dataPadreTutor;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}