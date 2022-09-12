namespace SPV.Presentation.Reports
{
    partial class Frm_Rpt_Mesas
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Txt_p1 = new System.Windows.Forms.TextBox();
            this.dataSet_DatosMaestros = new SPV.Presentation.Reports.DataSet_DatosMaestros();
            this.uSPListadomeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSP_Listado_meTableAdapter = new SPV.Presentation.Reports.DataSet_DatosMaestrosTableAdapters.USP_Listado_meTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_DatosMaestros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPListadomeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.uSPListadomeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SPV.Presentation.Reports.Rpt_Mesas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1152, 636);
            this.reportViewer1.TabIndex = 0;
            // 
            // Txt_p1
            // 
            this.Txt_p1.Location = new System.Drawing.Point(37, 48);
            this.Txt_p1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_p1.Name = "Txt_p1";
            this.Txt_p1.Size = new System.Drawing.Size(132, 22);
            this.Txt_p1.TabIndex = 3;
            this.Txt_p1.Visible = false;
            // 
            // dataSet_DatosMaestros
            // 
            this.dataSet_DatosMaestros.DataSetName = "DataSet_DatosMaestros";
            this.dataSet_DatosMaestros.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uSPListadomeBindingSource
            // 
            this.uSPListadomeBindingSource.DataMember = "USP_Listado_me";
            this.uSPListadomeBindingSource.DataSource = this.dataSet_DatosMaestros;
            // 
            // uSP_Listado_meTableAdapter
            // 
            this.uSP_Listado_meTableAdapter.ClearBeforeFill = true;
            // 
            // Frm_Rpt_Mesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 636);
            this.Controls.Add(this.Txt_p1);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Frm_Rpt_Mesas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Rpt_Mesas";
            this.Load += new System.EventHandler(this.Frm_Rpt_Mesas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_DatosMaestros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPListadomeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        internal System.Windows.Forms.TextBox Txt_p1;
        private System.Windows.Forms.BindingSource uSPListadomeBindingSource;
        private DataSet_DatosMaestros dataSet_DatosMaestros;
        private DataSet_DatosMaestrosTableAdapters.USP_Listado_meTableAdapter uSP_Listado_meTableAdapter;
    }
}