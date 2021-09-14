namespace labor_data
{
    partial class DMS
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defineValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tool1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tool2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tool3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1716, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defineValuesToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // defineValuesToolStripMenuItem
            // 
            this.defineValuesToolStripMenuItem.Name = "defineValuesToolStripMenuItem";
            this.defineValuesToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.defineValuesToolStripMenuItem.Text = "Define Values";
            this.defineValuesToolStripMenuItem.Click += new System.EventHandler(this.defineValuesToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool1ToolStripMenuItem,
            this.tool2ToolStripMenuItem,
            this.tool3ToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // tool1ToolStripMenuItem
            // 
            this.tool1ToolStripMenuItem.Name = "tool1ToolStripMenuItem";
            this.tool1ToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.tool1ToolStripMenuItem.Text = "Tool 1";
            this.tool1ToolStripMenuItem.Click += new System.EventHandler(this.tool1ToolStripMenuItem_Click);
            // 
            // tool2ToolStripMenuItem
            // 
            this.tool2ToolStripMenuItem.Name = "tool2ToolStripMenuItem";
            this.tool2ToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.tool2ToolStripMenuItem.Text = "Tool 2";
            this.tool2ToolStripMenuItem.Click += new System.EventHandler(this.tool2ToolStripMenuItem_Click);
            // 
            // tool3ToolStripMenuItem
            // 
            this.tool3ToolStripMenuItem.Name = "tool3ToolStripMenuItem";
            this.tool3ToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.tool3ToolStripMenuItem.Text = "Tool 3";
            this.tool3ToolStripMenuItem.Click += new System.EventHandler(this.tool3ToolStripMenuItem_Click);
            // 
            // DMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1716, 723);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DMS";
            this.Text = "DMS";
            this.Load += new System.EventHandler(this.DMS_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defineValuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tool1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tool2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tool3ToolStripMenuItem;
    }
}