namespace CaoaPresentacion
{
    partial class Frm_Formularios_por_Roles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Formularios_por_Roles));
            this.dataFormularios = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataFormularios)).BeginInit();
            this.SuspendLayout();
            // 
            // dataFormularios
            // 
            this.dataFormularios.AllowUserToAddRows = false;
            this.dataFormularios.AllowUserToDeleteRows = false;
            this.dataFormularios.AllowUserToOrderColumns = true;
            this.dataFormularios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataFormularios.Location = new System.Drawing.Point(21, 61);
            this.dataFormularios.Name = "dataFormularios";
            this.dataFormularios.ReadOnly = true;
            this.dataFormularios.Size = new System.Drawing.Size(1073, 454);
            this.dataFormularios.TabIndex = 0;
            this.dataFormularios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataFormularios_CellClick);
            this.dataFormularios.Click += new System.EventHandler(this.dataFormularios_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rol";
            // 
            // cmbRol
            // 
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(63, 16);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(255, 21);
            this.cmbRol.TabIndex = 2;
            this.cmbRol.SelectedIndexChanged += new System.EventHandler(this.cmbRol_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(339, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Actualizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(469, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(176, 25);
            this.button2.TabIndex = 4;
            this.button2.Text = "Inactivar todos Los Formularios";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(651, 15);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(176, 25);
            this.button3.TabIndex = 5;
            this.button3.Text = "Activar todos Los Formularios";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Frm_Formularios_por_Roles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 527);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataFormularios);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1122, 566);
            this.MinimumSize = new System.Drawing.Size(1122, 566);
            this.Name = "Frm_Formularios_por_Roles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: FORMULARIOS POR ROL :.";
            this.Load += new System.EventHandler(this.Frm_Formularios_por_Roles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataFormularios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataFormularios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}