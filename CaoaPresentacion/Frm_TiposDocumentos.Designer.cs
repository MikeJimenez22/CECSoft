namespace CaoaPresentacion
{
    partial class Frm_TiposDocumentos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_TiposDocumentos));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataDocumentos = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtIdDocumento = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtPrefijo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombreDocumento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDocumentos)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(696, 391);
            this.tabControl1.TabIndex = 10003;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataDocumentos);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Controls.Add(this.txtBuscar);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(688, 365);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataDocumentos
            // 
            this.dataDocumentos.AllowUserToAddRows = false;
            this.dataDocumentos.AllowUserToDeleteRows = false;
            this.dataDocumentos.AllowUserToOrderColumns = true;
            this.dataDocumentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataDocumentos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataDocumentos.Location = new System.Drawing.Point(11, 51);
            this.dataDocumentos.Name = "dataDocumentos";
            this.dataDocumentos.ReadOnly = true;
            this.dataDocumentos.Size = new System.Drawing.Size(669, 308);
            this.dataDocumentos.TabIndex = 16;
            this.dataDocumentos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataDocumentos_CellClick);
            this.dataDocumentos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataDocumentos_CellPainting);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::CaoaPresentacion.Properties.Resources._728898_page_folder_add_plus_file_icon;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(542, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 44);
            this.button2.TabIndex = 15;
            this.button2.Text = "Nuevo";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::CaoaPresentacion.Properties.Resources._1814075_find_magnifier_magnifying_glass_search_icon;
            this.btnBuscar.Location = new System.Drawing.Point(303, 10);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(44, 36);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(82, 12);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(215, 26);
            this.txtBuscar.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "Buscar";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtIdDocumento);
            this.tabPage2.Controls.Add(this.button7);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.txtPrefijo);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtNombreDocumento);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(688, 365);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtIdDocumento
            // 
            this.txtIdDocumento.Enabled = false;
            this.txtIdDocumento.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdDocumento.Location = new System.Drawing.Point(446, 23);
            this.txtIdDocumento.Name = "txtIdDocumento";
            this.txtIdDocumento.Size = new System.Drawing.Size(98, 26);
            this.txtIdDocumento.TabIndex = 37;
            this.txtIdDocumento.Visible = false;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Image = global::CaoaPresentacion.Properties.Resources._1891023_cancel_cercle_close_delete_dismiss_icon;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(392, 119);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(152, 46);
            this.button7.TabIndex = 36;
            this.button7.Text = "Cancelar";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::CaoaPresentacion.Properties.Resources._285657_floppy_guardar_save_icon;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(234, 119);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(152, 46);
            this.button3.TabIndex = 35;
            this.button3.Text = "Guardar";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtPrefijo
            // 
            this.txtPrefijo.Enabled = false;
            this.txtPrefijo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrefijo.Location = new System.Drawing.Point(199, 87);
            this.txtPrefijo.Name = "txtPrefijo";
            this.txtPrefijo.Size = new System.Drawing.Size(345, 26);
            this.txtPrefijo.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(125, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "Prefijo";
            // 
            // txtNombreDocumento
            // 
            this.txtNombreDocumento.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreDocumento.Location = new System.Drawing.Point(199, 55);
            this.txtNombreDocumento.Name = "txtNombreDocumento";
            this.txtNombreDocumento.Size = new System.Drawing.Size(345, 26);
            this.txtNombreDocumento.TabIndex = 14;
            this.txtNombreDocumento.TextChanged += new System.EventHandler(this.txtNombreDocumento_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Nombre Documento";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::CaoaPresentacion.Properties.Resources._4882066;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(700, 31);
            this.pictureBox1.TabIndex = 10002;
            this.pictureBox1.TabStop = false;
            // 
            // Frm_TiposDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 402);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(716, 441);
            this.MinimumSize = new System.Drawing.Size(716, 441);
            this.Name = "Frm_TiposDocumentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipos de Documentos";
            this.Load += new System.EventHandler(this.Frm_TiposDocumentos_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDocumentos)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataDocumentos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreDocumento;
        private System.Windows.Forms.TextBox txtPrefijo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtIdDocumento;
    }
}