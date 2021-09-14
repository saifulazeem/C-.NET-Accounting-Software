namespace labor_data
{
    partial class sales_volume_report
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sales_vol_data = new labor_data.sales_vol_data();
            this.sales_volume_tbBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sales_volume_tbTableAdapter = new labor_data.sales_vol_dataTableAdapters.sales_volume_tbTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sales_vol_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sales_volume_tbBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sales_volume_tbBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "labor_data.Sales_Vol_Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(924, 828);
            this.reportViewer1.TabIndex = 0;
            // 
            // sales_vol_data
            // 
            this.sales_vol_data.DataSetName = "sales_vol_data";
            this.sales_vol_data.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sales_volume_tbBindingSource
            // 
            this.sales_volume_tbBindingSource.DataMember = "sales_volume_tb";
            this.sales_volume_tbBindingSource.DataSource = this.sales_vol_data;
            // 
            // sales_volume_tbTableAdapter
            // 
            this.sales_volume_tbTableAdapter.ClearBeforeFill = true;
            // 
            // sales_volume_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 828);
            this.Controls.Add(this.reportViewer1);
            this.Name = "sales_volume_report";
            this.Text = "sales_volume_report";
            this.Load += new System.EventHandler(this.sales_volume_report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sales_vol_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sales_volume_tbBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sales_volume_tbBindingSource;
        private sales_vol_data sales_vol_data;
        private sales_vol_dataTableAdapters.sales_volume_tbTableAdapter sales_volume_tbTableAdapter;
    }
}