using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labor_data
{
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
        }

        private void report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'labor_dataset.labor_data_tb' table. You can move, or remove it, as needed.
            this.labor_data_tbTableAdapter.Fill(this.labor_dataset.labor_data_tb);

            this.reportViewer1.RefreshReport();
        }
    }
}
