﻿namespace SPV.Presentation.Reports
{
    partial class Frm_Rpt_Punto_Venta
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
            this.Txt_p1 = new System.Windows.Forms.TextBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet_DatosMaestros = new SPV.Presentation.Reports.DataSet_DatosMaestros();
            this.uSPListadopvBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSP_Listado_pvTableAdapter = new SPV.Presentation.Reports.DataSet_DatosMaestrosTableAdapters.USP_Listado_pvTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_DatosMaestros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPListadopvBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Txt_p1
            // 
            this.Txt_p1.Location = new System.Drawing.Point(56, 68);
            this.Txt_p1.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_p1.Name = "Txt_p1";
            this.Txt_p1.Size = new System.Drawing.Size(132, 22);
            this.Txt_p1.TabIndex = 1;
            this.Txt_p1.Visible = false;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.uSPListadopvBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SPV.Presentation.Reports.Rpt_Punto_Venta.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1111, 694);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSet_DatosMaestros
            // 
            this.dataSet_DatosMaestros.DataSetName = "DataSet_DatosMaestros";
            this.dataSet_DatosMaestros.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uSPListadopvBindingSource
            // 
            this.uSPListadopvBindingSource.DataMember = "USP_Listado_pv";
            this.uSPListadopvBindingSource.DataSource = this.dataSet_DatosMaestros;
            // 
            // uSP_Listado_pvTableAdapter
            // 
            this.uSP_Listado_pvTableAdapter.ClearBeforeFill = true;
            // 
            // Frm_Rpt_Punto_Venta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 694);
            this.Controls.Add(this.Txt_p1);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Frm_Rpt_Punto_Venta";
            this.Text = "Frm_Rpt_Punto_Venta";
            this.Load += new System.EventHandler(this.Frm_Rpt_Punto_Venta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_DatosMaestros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPListadopvBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox Txt_p1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource uSPListadopvBindingSource;
        private DataSet_DatosMaestros dataSet_DatosMaestros;
        private DataSet_DatosMaestrosTableAdapters.USP_Listado_pvTableAdapter uSP_Listado_pvTableAdapter;
    }
}