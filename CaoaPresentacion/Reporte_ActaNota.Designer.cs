namespace CaoaPresentacion
{
    partial class Reporte_ActaNota
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cecnicSystemDataSet1 = new CaoaPresentacion.CecnicSystemDataSet();
            this.sP_ObtenerActaNotaTableAdapter1 = new CaoaPresentacion.CecnicSystemDataSetTableAdapters.SP_ObtenerActaNotaTableAdapter();
            this.sP_ObtenerDetalleActaTableAdapter1 = new CaoaPresentacion.CecnicSystemDataSetTableAdapters.SP_ObtenerDetalleActaTableAdapter();
            this.CecnicSystemDataSet = new CaoaPresentacion.CecnicSystemDataSet();
            this.SP_ObtenerActaNotaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SP_ObtenerActaNotaTableAdapter = new CaoaPresentacion.CecnicSystemDataSetTableAdapters.SP_ObtenerActaNotaTableAdapter();
            this.SP_ObtenerDetalleActaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SP_ObtenerDetalleActaTableAdapter = new CaoaPresentacion.CecnicSystemDataSetTableAdapters.SP_ObtenerDetalleActaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.cecnicSystemDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CecnicSystemDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_ObtenerActaNotaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_ObtenerDetalleActaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SP_ObtenerActaNotaBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.SP_ObtenerDetalleActaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CaoaPresentacion.ReporteActa.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(639, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // cecnicSystemDataSet1
            // 
            this.cecnicSystemDataSet1.DataSetName = "CecnicSystemDataSet";
            this.cecnicSystemDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sP_ObtenerActaNotaTableAdapter1
            // 
            this.sP_ObtenerActaNotaTableAdapter1.ClearBeforeFill = true;
            // 
            // sP_ObtenerDetalleActaTableAdapter1
            // 
            this.sP_ObtenerDetalleActaTableAdapter1.ClearBeforeFill = true;
            // 
            // CecnicSystemDataSet
            // 
            this.CecnicSystemDataSet.DataSetName = "CecnicSystemDataSet";
            this.CecnicSystemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SP_ObtenerActaNotaBindingSource
            // 
            this.SP_ObtenerActaNotaBindingSource.DataMember = "SP_ObtenerActaNota";
            this.SP_ObtenerActaNotaBindingSource.DataSource = this.CecnicSystemDataSet;
            // 
            // SP_ObtenerActaNotaTableAdapter
            // 
            this.SP_ObtenerActaNotaTableAdapter.ClearBeforeFill = true;
            // 
            // SP_ObtenerDetalleActaBindingSource
            // 
            this.SP_ObtenerDetalleActaBindingSource.DataMember = "SP_ObtenerDetalleActa";
            this.SP_ObtenerDetalleActaBindingSource.DataSource = this.CecnicSystemDataSet;
            // 
            // SP_ObtenerDetalleActaTableAdapter
            // 
            this.SP_ObtenerDetalleActaTableAdapter.ClearBeforeFill = true;
            // 
            // Reporte_ActaNota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Reporte_ActaNota";
            this.Text = "Reporte_ActaNota";
            this.Load += new System.EventHandler(this.Reporte_ActaNota_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cecnicSystemDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CecnicSystemDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_ObtenerActaNotaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_ObtenerDetalleActaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SP_ObtenerActaNotaBindingSource;
        private CecnicSystemDataSet CecnicSystemDataSet;
        private System.Windows.Forms.BindingSource SP_ObtenerDetalleActaBindingSource;
        private CecnicSystemDataSet cecnicSystemDataSet1;
        private CecnicSystemDataSetTableAdapters.SP_ObtenerActaNotaTableAdapter sP_ObtenerActaNotaTableAdapter1;
        private CecnicSystemDataSetTableAdapters.SP_ObtenerDetalleActaTableAdapter sP_ObtenerDetalleActaTableAdapter1;
        private CecnicSystemDataSetTableAdapters.SP_ObtenerActaNotaTableAdapter SP_ObtenerActaNotaTableAdapter;
        private CecnicSystemDataSetTableAdapters.SP_ObtenerDetalleActaTableAdapter SP_ObtenerDetalleActaTableAdapter;
    }
}