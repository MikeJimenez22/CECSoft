namespace CaoaPresentacion
{
    partial class Frm_AsistenciaEstudiantil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AsistenciaEstudiantil));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.asistenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadisticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.reporteAsistenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button5 = new System.Windows.Forms.Button();
            this.dataAsistencia = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.estudiantesPorGrupoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button9 = new System.Windows.Forms.Button();
            this.dataUniversoPorGrupo = new System.Windows.Forms.DataGridView();
            this.label27 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button10 = new System.Windows.Forms.Button();
            this.dataEstudiantesCurso = new System.Windows.Forms.DataGridView();
            this.label28 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button11 = new System.Windows.Forms.Button();
            this.dataEstudiantesCategorias = new System.Windows.Forms.DataGridView();
            this.label29 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.button12 = new System.Windows.Forms.Button();
            this.dataEstudiantesTurnos = new System.Windows.Forms.DataGridView();
            this.label30 = new System.Windows.Forms.Label();
            this.estudiantesPorCursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estudiantesPorCategoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estudiantesPorTurnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataAsistencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataUniversoPorGrupo)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataEstudiantesCurso)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataEstudiantesCategorias)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataEstudiantesTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asistenciaToolStripMenuItem,
            this.estadisticasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1445, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // asistenciaToolStripMenuItem
            // 
            this.asistenciaToolStripMenuItem.Image = global::CaoaPresentacion.Properties.Resources._118805_accessories_text_editor_editor_accessories_text;
            this.asistenciaToolStripMenuItem.Name = "asistenciaToolStripMenuItem";
            this.asistenciaToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.asistenciaToolStripMenuItem.Text = "Asistencia";
            // 
            // estadisticasToolStripMenuItem
            // 
            this.estadisticasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reporteAsistenciaToolStripMenuItem,
            this.estudiantesPorGrupoToolStripMenuItem,
            this.estudiantesPorCursoToolStripMenuItem,
            this.estudiantesPorCategoriaToolStripMenuItem,
            this.estudiantesPorTurnoToolStripMenuItem});
            this.estadisticasToolStripMenuItem.Image = global::CaoaPresentacion.Properties.Resources._118903_office_spreadsheet_x_office_spreadsheet;
            this.estadisticasToolStripMenuItem.Name = "estadisticasToolStripMenuItem";
            this.estadisticasToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.estadisticasToolStripMenuItem.Text = "Reportes";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Image = global::CaoaPresentacion.Properties.Resources._4882066;
            this.pictureBox2.Location = new System.Drawing.Point(0, 24);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1445, 50);
            this.pictureBox2.TabIndex = 58;
            this.pictureBox2.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(3, 53);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1430, 577);
            this.tabControl1.TabIndex = 59;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.dataAsistencia);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1422, 551);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Reporte Asistencia";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button9);
            this.tabPage2.Controls.Add(this.dataUniversoPorGrupo);
            this.tabPage2.Controls.Add(this.label27);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1422, 551);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ReportPorGrupos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // reporteAsistenciaToolStripMenuItem
            // 
            this.reporteAsistenciaToolStripMenuItem.Name = "reporteAsistenciaToolStripMenuItem";
            this.reporteAsistenciaToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.reporteAsistenciaToolStripMenuItem.Text = "Asistencia";
            this.reporteAsistenciaToolStripMenuItem.Click += new System.EventHandler(this.reporteAsistenciaToolStripMenuItem_Click);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.Teal;
            this.button5.Image = global::CaoaPresentacion.Properties.Resources._1814075_find_magnifier_magnifying_glass_search_icon;
            this.button5.Location = new System.Drawing.Point(415, 48);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(39, 36);
            this.button5.TabIndex = 12;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dataAsistencia
            // 
            this.dataAsistencia.AllowUserToAddRows = false;
            this.dataAsistencia.AllowUserToDeleteRows = false;
            this.dataAsistencia.AllowUserToOrderColumns = true;
            this.dataAsistencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataAsistencia.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataAsistencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAsistencia.Location = new System.Drawing.Point(18, 99);
            this.dataAsistencia.Name = "dataAsistencia";
            this.dataAsistencia.ReadOnly = true;
            this.dataAsistencia.Size = new System.Drawing.Size(1144, 422);
            this.dataAsistencia.TabIndex = 11;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(108, 54);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(301, 26);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(27, 57);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 18);
            this.label17.TabIndex = 9;
            this.label17.Text = "Fecha";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(27, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(162, 18);
            this.label16.TabIndex = 8;
            this.label16.Text = "Reporte de Asistencia";
            // 
            // button6
            // 
            this.button6.Image = global::CaoaPresentacion.Properties.Resources._118805_accessories_text_editor_editor_accessories_text;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(1064, 57);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(98, 36);
            this.button6.TabIndex = 13;
            this.button6.Text = "Copiar";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // estudiantesPorGrupoToolStripMenuItem
            // 
            this.estudiantesPorGrupoToolStripMenuItem.Name = "estudiantesPorGrupoToolStripMenuItem";
            this.estudiantesPorGrupoToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.estudiantesPorGrupoToolStripMenuItem.Text = "Estudiantes por Grupo";
            this.estudiantesPorGrupoToolStripMenuItem.Click += new System.EventHandler(this.estudiantesPorGrupoToolStripMenuItem_Click);
            // 
            // button9
            // 
            this.button9.Image = global::CaoaPresentacion.Properties.Resources._1814075_find_magnifier_magnifying_glass_search_icon;
            this.button9.Location = new System.Drawing.Point(268, 19);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(36, 31);
            this.button9.TabIndex = 65;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // dataUniversoPorGrupo
            // 
            this.dataUniversoPorGrupo.AllowUserToAddRows = false;
            this.dataUniversoPorGrupo.AllowUserToDeleteRows = false;
            this.dataUniversoPorGrupo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataUniversoPorGrupo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataUniversoPorGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataUniversoPorGrupo.Location = new System.Drawing.Point(32, 59);
            this.dataUniversoPorGrupo.Name = "dataUniversoPorGrupo";
            this.dataUniversoPorGrupo.ReadOnly = true;
            this.dataUniversoPorGrupo.Size = new System.Drawing.Size(1264, 496);
            this.dataUniversoPorGrupo.TabIndex = 64;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(38, 24);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(224, 18);
            this.label27.TabIndex = 63;
            this.label27.Text = "Reporte Estudiantes por Grupo";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button10);
            this.tabPage3.Controls.Add(this.dataEstudiantesCurso);
            this.tabPage3.Controls.Add(this.label28);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1422, 551);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ReportPorCursos";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Image = global::CaoaPresentacion.Properties.Resources._1814075_find_magnifier_magnifying_glass_search_icon;
            this.button10.Location = new System.Drawing.Point(256, 32);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(37, 35);
            this.button10.TabIndex = 66;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // dataEstudiantesCurso
            // 
            this.dataEstudiantesCurso.AllowUserToAddRows = false;
            this.dataEstudiantesCurso.AllowUserToDeleteRows = false;
            this.dataEstudiantesCurso.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataEstudiantesCurso.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataEstudiantesCurso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEstudiantesCurso.Location = new System.Drawing.Point(14, 73);
            this.dataEstudiantesCurso.Name = "dataEstudiantesCurso";
            this.dataEstudiantesCurso.ReadOnly = true;
            this.dataEstudiantesCurso.Size = new System.Drawing.Size(1264, 494);
            this.dataEstudiantesCurso.TabIndex = 65;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(27, 38);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(223, 18);
            this.label28.TabIndex = 64;
            this.label28.Text = "Reporte Estudiantes por Curso";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button11);
            this.tabPage4.Controls.Add(this.dataEstudiantesCategorias);
            this.tabPage4.Controls.Add(this.label29);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1422, 551);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "ReportPorCategorias";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Image = global::CaoaPresentacion.Properties.Resources._1814075_find_magnifier_magnifying_glass_search_icon;
            this.button11.Location = new System.Drawing.Point(292, 17);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(51, 40);
            this.button11.TabIndex = 68;
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // dataEstudiantesCategorias
            // 
            this.dataEstudiantesCategorias.AllowUserToAddRows = false;
            this.dataEstudiantesCategorias.AllowUserToDeleteRows = false;
            this.dataEstudiantesCategorias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataEstudiantesCategorias.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataEstudiantesCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEstudiantesCategorias.Location = new System.Drawing.Point(23, 63);
            this.dataEstudiantesCategorias.Name = "dataEstudiantesCategorias";
            this.dataEstudiantesCategorias.ReadOnly = true;
            this.dataEstudiantesCategorias.Size = new System.Drawing.Size(1264, 505);
            this.dataEstudiantesCategorias.TabIndex = 67;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(27, 27);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(259, 18);
            this.label29.TabIndex = 66;
            this.label29.Text = "Reporte Estudiantes por Categorias";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.button12);
            this.tabPage5.Controls.Add(this.dataEstudiantesTurnos);
            this.tabPage5.Controls.Add(this.label30);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1422, 551);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "ReportPorTurnos";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Image = global::CaoaPresentacion.Properties.Resources._1814075_find_magnifier_magnifying_glass_search_icon;
            this.button12.Location = new System.Drawing.Point(258, 26);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(34, 33);
            this.button12.TabIndex = 70;
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // dataEstudiantesTurnos
            // 
            this.dataEstudiantesTurnos.AllowUserToAddRows = false;
            this.dataEstudiantesTurnos.AllowUserToDeleteRows = false;
            this.dataEstudiantesTurnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataEstudiantesTurnos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataEstudiantesTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEstudiantesTurnos.Location = new System.Drawing.Point(20, 75);
            this.dataEstudiantesTurnos.Name = "dataEstudiantesTurnos";
            this.dataEstudiantesTurnos.ReadOnly = true;
            this.dataEstudiantesTurnos.Size = new System.Drawing.Size(1264, 511);
            this.dataEstudiantesTurnos.TabIndex = 69;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(25, 31);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(227, 18);
            this.label30.TabIndex = 68;
            this.label30.Text = "Reporte Estudiantes por Turnos";
            // 
            // estudiantesPorCursoToolStripMenuItem
            // 
            this.estudiantesPorCursoToolStripMenuItem.Name = "estudiantesPorCursoToolStripMenuItem";
            this.estudiantesPorCursoToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.estudiantesPorCursoToolStripMenuItem.Text = "Estudiantes Por Curso";
            this.estudiantesPorCursoToolStripMenuItem.Click += new System.EventHandler(this.estudiantesPorCursoToolStripMenuItem_Click);
            // 
            // estudiantesPorCategoriaToolStripMenuItem
            // 
            this.estudiantesPorCategoriaToolStripMenuItem.Name = "estudiantesPorCategoriaToolStripMenuItem";
            this.estudiantesPorCategoriaToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.estudiantesPorCategoriaToolStripMenuItem.Text = "Estudiantes Por Categoria";
            this.estudiantesPorCategoriaToolStripMenuItem.Click += new System.EventHandler(this.estudiantesPorCategoriaToolStripMenuItem_Click);
            // 
            // estudiantesPorTurnoToolStripMenuItem
            // 
            this.estudiantesPorTurnoToolStripMenuItem.Name = "estudiantesPorTurnoToolStripMenuItem";
            this.estudiantesPorTurnoToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.estudiantesPorTurnoToolStripMenuItem.Text = "Estudiantes Por Turno";
            this.estudiantesPorTurnoToolStripMenuItem.Click += new System.EventHandler(this.estudiantesPorTurnoToolStripMenuItem_Click);
            // 
            // Frm_AsistenciaEstudiantil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1445, 689);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Frm_AsistenciaEstudiantil";
            this.Text = "Estudiantes";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataAsistencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataUniversoPorGrupo)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataEstudiantesCurso)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataEstudiantesCategorias)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataEstudiantesTurnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem asistenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadisticasToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripMenuItem reporteAsistenciaToolStripMenuItem;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView dataAsistencia;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ToolStripMenuItem estudiantesPorGrupoToolStripMenuItem;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.DataGridView dataUniversoPorGrupo;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.DataGridView dataEstudiantesCurso;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.DataGridView dataEstudiantesCategorias;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.DataGridView dataEstudiantesTurnos;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ToolStripMenuItem estudiantesPorCursoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estudiantesPorCategoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estudiantesPorTurnoToolStripMenuItem;
    }
}