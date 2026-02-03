namespace CaoaPresentacion
{
    partial class Frm_CambioDolar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_CambioDolar));
            this.label2 = new System.Windows.Forms.Label();
            this.txtValorDolar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGetRate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(176, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "TIPO DE CAMBIO";
            // 
            // txtValorDolar
            // 
            this.txtValorDolar.Font = new System.Drawing.Font("Arial", 12F);
            this.txtValorDolar.Location = new System.Drawing.Point(123, 121);
            this.txtValorDolar.Name = "txtValorDolar";
            this.txtValorDolar.Size = new System.Drawing.Size(257, 26);
            this.txtValorDolar.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Dolar";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::CaoaPresentacion.Properties.Resources._4882066;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(536, 44);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 12F);
            this.button1.Image = global::CaoaPresentacion.Properties.Resources._285657_floppy_guardar_save_icon;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(386, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 43);
            this.button1.TabIndex = 3;
            this.button1.Text = "Guardar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(60, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Cambio Actual";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F);
            this.label4.Location = new System.Drawing.Point(350, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Cambio Actual";
            // 
            // btnGetRate
            // 
            this.btnGetRate.Font = new System.Drawing.Font("Arial", 12F);
            this.btnGetRate.Image = global::CaoaPresentacion.Properties.Resources._118805_accessories_text_editor_editor_accessories_text;
            this.btnGetRate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetRate.Location = new System.Drawing.Point(24, 198);
            this.btnGetRate.Name = "btnGetRate";
            this.btnGetRate.Size = new System.Drawing.Size(123, 43);
            this.btnGetRate.TabIndex = 11;
            this.btnGetRate.Text = "Obtener";
            this.btnGetRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGetRate.UseVisualStyleBackColor = true;
            this.btnGetRate.Click += new System.EventHandler(this.btnGetRate_ClickAsync);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(118, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(307, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "TIPO DE CAMBIO EN LINEA";
            // 
            // txtRate
            // 
            this.txtRate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.Location = new System.Drawing.Point(153, 207);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(206, 26);
            this.txtRate.TabIndex = 13;
            // 
            // Frm_CambioDolar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(536, 291);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGetRate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtValorDolar);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(552, 198);
            this.Name = "Frm_CambioDolar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".:  CAMBIO DE DOLAR :.";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Frm_CambioDolar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValorDolar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGetRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRate;
    }
}