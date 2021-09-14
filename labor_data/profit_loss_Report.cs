using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace labor_data
{
    public partial class profit_loss_Report : Form
    {
        public static SqlCommand cmd = new SqlCommand();
        public static SqlConnection db_conect = new SqlConnection();
        public static SqlDataAdapter adopt = new SqlDataAdapter();
        public static string con_str => ConfigurationManager.ConnectionStrings["con_str"].ConnectionString;
        public profit_loss_Report()
        {
            InitializeComponent();
        }

        private void profit_loss_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'profit_loss_data.profit_loss_tb' table. You can move, or remove it, as needed.
            this.profit_loss_tbTableAdapter.Fill(this.profit_loss_data.profit_loss_tb);

            this.reportViewer1.RefreshReport();

            contest();
            //databse
            cmd.Parameters.Clear();
            //string qry = "INSERT INTO reused_values_tb (dollars_f,percent_g) VALUES (@dol_f,@percent_g) ";
            string qry = "UPDATE reused_values_tb SET key_status='3' WHERE key_status='2'";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
            //cmd.Parameters.Add("@dol_f", txt1.Text);
            //cmd.Parameters.Add("@percent_g", mylab.Text);
            int rows = cmd.ExecuteNonQuery();
        }
        public static void contest()
        {
            try
            {
                if (db_conect.State != ConnectionState.Open)
                {
                    db_conect.ConnectionString = con_str;
                    db_conect.Open();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
