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
    public partial class Form9 : Form
    {
        int input;
        Profit_Loss_Calculations psc;
        public Form9(Profit_Loss_Calculations psf)
        {
            InitializeComponent();
            textBox1.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox2.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox3.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox4.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            psc = psf;
            button5.Click += new EventHandler(button5_Click);
        }
       public static SqlCommand cmd2 = new SqlCommand();
       public static SqlConnection db_conect = new SqlConnection();
       public static SqlDataAdapter adopt = new SqlDataAdapter();
       public static DataTable dt_values_data = new DataTable();
        public static DataTable defineds = new DataTable();
        //string con_str = "Data Source =DESKTOP-D8I8EQJ;Initial Catalog=rms_db;Integrated Security=True";
        public static string con_str => ConfigurationManager.ConnectionStrings["con_str"].ConnectionString;

        public void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '-' || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Enter || e.KeyChar <= '.') //The  character represents a backspace
            {
                //e.Handled = false; //Do not reject the input
                input = 1;

            }
            else
            {
                //e.Handled = true; //Reject the input
                string message = "Please Enter Numeric Values Only";
                string title = "Alert";
                MessageBox.Show(message, title);
                input = 0;
            }
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

        private void Form9_Load(object sender, EventArgs e)
        {
            //db_conect.ConnectionString = con_str;
            //db_conect.Open();
            contest();

            string qry = "select * From free_values";
            cmd2.CommandText = qry;
            cmd2.Connection = db_conect;
            adopt = new SqlDataAdapter(cmd2);
            adopt.Fill(dt_values_data);
            string perr_x, perr_xx, per_v, dollar_z;
            //dt_values_data.rows[rowindex][colum]
            foreach (DataRow dr in dt_values_data.Rows)
            {
                perr_x = dr["percent_x"].ToString();
                textBox1.Text = perr_x;
                perr_xx = dr["percent_xx"].ToString();
                textBox2.Text = perr_xx;

                per_v = dr["percent_v"].ToString();
                textBox3.Text = per_v;
                dollar_z = dr["dollar_z"].ToString();
                textBox4.Text = dollar_z;
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                //MessageBox.Show("Failed to Save Data");
                String emt_str = "Null";
                cmd2.Parameters.Clear();
                string qry = "UPDATE free_values SET percent_x=@per_x where v_id=1 ";
                cmd2.CommandText = qry;
                cmd2.Connection = db_conect;
                //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                cmd2.Parameters.Add("@per_x", emt_str);
                int rows = cmd2.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show(" X% Value is SET to 'null'");
                }
                else
                {
                    MessageBox.Show("Failed to Save Data");
                }
            }
            else
            {
                cmd2.Parameters.Clear();
                string qry = "UPDATE free_values SET percent_x=@per_x where v_id=1 ";
                cmd2.CommandText = qry;
                cmd2.Connection = db_conect;
                //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                cmd2.Parameters.Add("@per_x", textBox1.Text);
                int rows = cmd2.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show(rows + " Record Saved TO Database Sucessfully");
                }
                else
                {
                    MessageBox.Show("Failed to Save Data");
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                //MessageBox.Show("Failed to Save Data");
                String ept_str = "Null";
                cmd2.Parameters.Clear();
                string qry = "UPDATE free_values SET percent_xx=@per_xx where v_id=1 ";
                cmd2.CommandText = qry;
                cmd2.Connection = db_conect;
                //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                cmd2.Parameters.Add("@per_xx", ept_str);
                int rows = cmd2.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("XX% value is SET to 'null'");
                }
                else
                {
                    MessageBox.Show("Failed to Save Data");
                }
            }
            else
            {
                cmd2.Parameters.Clear();
                string qry = "UPDATE free_values SET percent_xx=@per_xx where v_id=1 ";
                cmd2.CommandText = qry;
                cmd2.Connection = db_conect;
                //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                cmd2.Parameters.Add("@per_xx", textBox2.Text);
                int rows = cmd2.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show(rows + " Record Saved TO Database Sucessfully");
                }
                else
                {
                    MessageBox.Show("Failed to Save Data");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                //MessageBox.Show("Failed to Save Data");
                String empt_str = "Null";
                cmd2.Parameters.Clear();
                string qry = "UPDATE free_values SET percent_v=@per_v where v_id=1 ";
                cmd2.CommandText = qry;
                cmd2.Connection = db_conect;
                //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                cmd2.Parameters.Add("@per_v", empt_str);
                int rows = cmd2.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("V% Value Set to 'Null' ");
                }
                else
                {
                    MessageBox.Show("Failed to Save Data");
                }
            }
            else
            {
                cmd2.Parameters.Clear();
                string qry = "UPDATE free_values SET percent_v=@per_v where v_id=1 ";
                cmd2.CommandText = qry;
                cmd2.Connection = db_conect;
                //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                cmd2.Parameters.Add("@per_v", textBox3.Text);
                int rows = cmd2.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show(rows + " Record Saved TO Database Sucessfully");
                }
                else
                {
                    MessageBox.Show("Failed to Save Data");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                //MessageBox.Show("Failed to Save Data");
                String emt_str = "Null";
                cmd2.Parameters.Clear();
                string qry = "UPDATE free_values SET dollar_z=@dollar_z where v_id=1 ";
                cmd2.CommandText = qry;
                cmd2.Connection = db_conect;
                //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                cmd2.Parameters.Add("@dollar_z", emt_str);
                int rows = cmd2.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show(" $Z value SET to 'Null'");
                }
                else
                {
                    MessageBox.Show("Failed to Save Data");
                }
            }
            else
            {
                cmd2.Parameters.Clear();
                string qry = "UPDATE free_values SET dollar_z=@dollar_z where v_id=1 ";
                cmd2.CommandText = qry;
                cmd2.Connection = db_conect;
                //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                cmd2.Parameters.Add("@dollar_z", textBox4.Text);
                int rows = cmd2.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show(rows + " Record Saved TO Database Sucessfully");
                }
                else
                {
                    MessageBox.Show("Failed to Save Data");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            string qry = "select * From free_values WHERE v_id=1";
            cmd2.CommandText = qry;
            cmd2.Connection = db_conect;
            adopt = new SqlDataAdapter(cmd2);
            adopt.Fill(defineds);
            string pperr_x, pperr_xx, pper_v, ddollar_z;
            foreach (DataRow dr in defineds.Rows)
            {
                pperr_x = dr["percent_x"].ToString();
                psc.label26.Text = pperr_x;
                pperr_xx = dr["percent_xx"].ToString();
                psc.label38.Text = pperr_xx;

                pper_v = dr["percent_v"].ToString();
                psc.label63.Text = pper_v;
                ddollar_z = dr["dollar_z"].ToString();
                psc.label79.Text = ddollar_z;
            }
            //Profit_Loss_Calculations f7 = new Profit_Loss_Calculations();
            //f7.Show();
            this.Hide();
        }
    }
}
