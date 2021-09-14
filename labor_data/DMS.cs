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
    public partial class DMS : Form
    {
        public DMS()
        {
            InitializeComponent();
        }
        Form1 f1 = new Form1();
        Form9 f9 = new Form9();
        Form2 f2 = new Form2();
        Profit_Loss_Calculations f7 = new Profit_Loss_Calculations();
        Form8 f8 = new Form8();

        private void DMS_Load(object sender, EventArgs e)
        {
            //f1.MdiParent = this;
            //f1.Show();
            
        }

        private void defineValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //f9.MdiParent = this;
            //f9.Show();
        }

        private void tool1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           //f1.MdiParent = this;
           //f1.Show();
           //f2.Hide();
           //f7.Hide();
        }

        private void tool2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            //f2.MdiParent = this;
            //f2.Show();
            //f1.Hide();
            //f7.Hide();

        }

        private void tool3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //f7.MdiParent = this;
            //f7.Show();
            //f1.Hide();
            //f2.Hide();
        }

    
    }
}
