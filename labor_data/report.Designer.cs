namespace labor_data
{
    partial class report
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
            this.labor_dataset = new labor_data.labor_dataset();
            this.labor_data_tbBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labor_data_tbTableAdapter = new labor_data.labor_datasetTableAdapters.labor_data_tbTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.labor_dataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labor_data_tbBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.labor_data_tbBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "labor_data.labor_data_report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1373, 747);
            this.reportViewer1.TabIndex = 0;
            // 
            // labor_dataset
            // 
            this.labor_dataset.DataSetName = "labor_dataset";
            this.labor_dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // labor_data_tbBindingSource
            // 
            this.labor_data_tbBindingSource.DataMember = "labor_data_tb";
            this.labor_data_tbBindingSource.DataSource = this.labor_dataset;
            // 
            // labor_data_tbTableAdapter
            // 
            this.labor_data_tbTableAdapter.ClearBeforeFill = true;
            // 
            // report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1373, 747);
            this.Controls.Add(this.reportViewer1);
            this.Name = "report";
            this.Text = "report";
            this.Load += new System.EventHandler(this.report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.labor_dataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labor_data_tbBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource labor_data_tbBindingSource;
        private labor_dataset labor_dataset;
        private labor_datasetTableAdapters.labor_data_tbTableAdapter labor_data_tbTableAdapter;
    }
}