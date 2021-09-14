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
    public partial class sales_volume_report : Form
    {
        public sales_volume_report()
        {
            InitializeComponent();
        }

        private void sales_volume_report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sales_vol_data.sales_volume_tb' table. You can move, or remove it, as needed.
            this.sales_volume_tbTableAdapter.Fill(this.sales_vol_data.sales_volume_tb);

            this.reportViewer1.RefreshReport();
        }
    }
}
