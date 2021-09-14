namespace labor_data
{
    partial class profit_loss_Report
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
            this.profit_loss_tbBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.profit_loss_data = new labor_data.profit_loss_data();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.profit_loss_tbTableAdapter = new labor_data.profit_loss_dataTableAdapters.profit_loss_tbTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.profit_loss_tbBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profit_loss_data)).BeginInit();
            this.SuspendLayout();
            // 
            // profit_loss_tbBindingSource
            // 
            this.profit_loss_tbBindingSource.DataMember = "profit_loss_tb";
            this.profit_loss_tbBindingSource.DataSource = this.profit_loss_data;
            // 
            // profit_loss_data
            // 
            this.profit_loss_data.DataSetName = "profit_loss_data";
            this.profit_loss_data.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.profit_loss_tbBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "labor_data.Profit_loss_data_Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(994, 967);
            this.reportViewer1.TabIndex = 0;
            // 
            // profit_loss_tbTableAdapter
            // 
            this.profit_loss_tbTableAdapter.ClearBeforeFill = true;
            // 
            // profit_loss_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 967);
            this.Controls.Add(this.reportViewer1);
            this.Name = "profit_loss_Report";
            this.Text = "profit_loss_Report";
            this.Load += new System.EventHandler(this.profit_loss_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.profit_loss_tbBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profit_loss_data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource profit_loss_tbBindingSource;
        private profit_loss_data profit_loss_data;
        private profit_loss_dataTableAdapters.profit_loss_tbTableAdapter profit_loss_tbTableAdapter;
    }
}