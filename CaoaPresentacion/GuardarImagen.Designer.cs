namespace CaoaPresentacion
{
    partial class GuardarImagen
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ptbImagen = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(359, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(219, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = "cargar imagen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(359, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(219, 38);
            this.button2.TabIndex = 2;
            this.button2.Text = "guardar imagen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.ptbImagen);
            this.panel1.Location = new System.Drawing.Point(22, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 268);
            this.panel1.TabIndex = 3;
            // 
            // ptbImagen
            // 
            this.ptbImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbImagen.Location = new System.Drawing.Point(18, 20);
            this.ptbImagen.Name = "ptbImagen";
            this.ptbImagen.Size = new System.Drawing.Size(235, 229);
            this.ptbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbImagen.TabIndex = 0;
            this.ptbImagen.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(359, 111);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(219, 38);
            this.button3.TabIndex = 4;
            this.button3.Text = "ver Imagen";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(359, 155);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(219, 38);
            this.button4.TabIndex = 5;
            this.button4.Text = "Borrar Imagenes";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // GuardarImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(617, 323);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MaximumSize = new System.Drawing.Size(633, 362);
            this.MinimumSize = new System.Drawing.Size(633, 362);
            this.Name = "GuardarImagen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GuardarImagen";
            this.Load += new System.EventHandler(this.GuardarImagen_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbImagen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbImagen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}