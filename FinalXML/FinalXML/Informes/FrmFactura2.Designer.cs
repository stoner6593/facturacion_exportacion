﻿namespace FinalXML.Informes
{
    partial class FrmFactura2
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DetalleDocumentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ContribuyenteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DocumentoElectronicoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ClsDatosReportesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DetalleDocumentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContribuyenteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentoElectronicoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClsDatosReportesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DetalleDocumento";
            reportDataSource1.Value = this.DetalleDocumentoBindingSource;
            reportDataSource2.Name = "Empresa";
            reportDataSource2.Value = this.ContribuyenteBindingSource;
            reportDataSource3.Name = "General";
            reportDataSource3.Value = this.DocumentoElectronicoBindingSource;
            reportDataSource4.Name = "Receptor";
            reportDataSource4.Value = this.ContribuyenteBindingSource;
            reportDataSource5.Name = "Otros";
            reportDataSource5.Value = this.ClsDatosReportesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinalXML.Informes.DTFactura2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(842, 504);
            this.reportViewer1.TabIndex = 0;
            // 
            // DetalleDocumentoBindingSource
            // 
            this.DetalleDocumentoBindingSource.DataSource = typeof(WinApp.Comun.Dto.Modelos.DetalleDocumento);
            // 
            // ContribuyenteBindingSource
            // 
            this.ContribuyenteBindingSource.DataSource = typeof(WinApp.Comun.Dto.Modelos.Contribuyente);
            // 
            // DocumentoElectronicoBindingSource
            // 
            this.DocumentoElectronicoBindingSource.DataSource = typeof(WinApp.Comun.Dto.Modelos.DocumentoElectronico);
            // 
            // ClsDatosReportesBindingSource
            // 
            this.ClsDatosReportesBindingSource.DataSource = typeof(FinalXML.ClsDatosReportes);
            // 
            // FrmFactura2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 504);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmFactura2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmFactura2";
            this.Load += new System.EventHandler(this.FrmFactura2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DetalleDocumentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContribuyenteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentoElectronicoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClsDatosReportesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DetalleDocumentoBindingSource;
        private System.Windows.Forms.BindingSource ContribuyenteBindingSource;
        private System.Windows.Forms.BindingSource DocumentoElectronicoBindingSource;
        private System.Windows.Forms.BindingSource ClsDatosReportesBindingSource;
    }
}